import datetime
from flask import Blueprint, render_template, session
from db import get_db_connection

credit_paid_bp = Blueprint('credit_paid_bp', __name__)

@credit_paid_bp.route('/credit_paid_till_date')
def credit_paid_till_date():
    today = datetime.datetime.now()
    current_date_str = today.strftime('%Y-%m-%d')
    # Get all paid credits from the earliest date to today
    conn = get_db_connection()
    cursor = conn.cursor()
    sql_query = '''
        SELECT 
            d.PatientID, 
            d.PatientName, 
            p.BillNo, 
            p.BillDate, 
            p.DueAmount,
            p.AmountReceived,
            p.BalanceAmount,
            p.DueStatus,
            (SELECT DueAmount FROM PaymentDue WHERE BillNo = p.BillNo AND BillDate = p.BillDate AND DueStatus='CT' AND BillStatus='P' AND DueNo=1) AS AmountReceived1,
            (SELECT ISNULL(SUM(DueAmount), 0) FROM PaymentDue WHERE billno = p.billno AND billdate = p.billdate AND (DueStatus = 'CT' OR DueStatus = 'CP') AND (DueNo <> 1 AND CONVERT(VARCHAR(10), DueDate, 120) < CONVERT(VARCHAR(10), GETDATE(), 120)) AND BillStatus = 'P') AS CreditPaidLastDues,
            (SELECT ISNULL(SUM(DueAmount), 0) FROM PaymentDue WHERE billno = p.billno AND billdate = p.billdate AND (DueStatus = 'CT' OR DueStatus = 'CP') AND (DueNo = (SELECT MAX(DueNo) FROM PaymentDue WHERE billno = p.billno AND billdate = p.billdate AND DueNo <> 1)) AND BillStatus = 'P' AND CONVERT(VARCHAR(10), DueDate, 120) = CONVERT(VARCHAR(10), GETDATE(), 120)) AS CreditPaid
        FROM PaymentDue p
        INNER JOIN DrugSlipDetails d ON p.BillNo = d.BillNo AND p.BillDate = d.BillDate
        WHERE p.DueNo = (SELECT MAX(DueNo) FROM PaymentDue WHERE BillNo = p.BillNo AND BillDate = p.BillDate AND BillStatus='P')
            AND p.DueStatus = 'CT'
            AND p.BillStatus = 'P'
        ORDER BY p.BillDate DESC
    '''
    print("[DEBUG] Executing SQL query for Credit to be Paid Till Date:")
    print(sql_query)
    cursor.execute(sql_query)
    paid_credit = []
    rows = cursor.fetchall()
    print(f"[DEBUG] Rows fetched: {len(rows)}")
    for row in rows:
        paid_credit.append({
            'PatientID': row.PatientID,
            'PatientName': row.PatientName,
            'BillNo': row.BillNo,
            'BillDate': row.BillDate,
            'DueAmount': getattr(row, 'DueAmount', 0),
            'BalanceAmount': getattr(row, 'BalanceAmount', 0),
            'AmountReceived': row.AmountReceived
        })
    conn.close()
    return render_template('credit_paid_till_date.html',
        paid_credit=paid_credit,
        current_date=current_date_str)
