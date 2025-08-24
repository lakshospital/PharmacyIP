from flask import Blueprint, render_template, session, request
import datetime
from db import get_db_connection

credit_paid_bp = Blueprint('credit_paid_bp', __name__)

@credit_paid_bp.route('/creditdetails')
def creditdetails():
    bill_no = request.args.get('bill_no', '')
    bill_date_raw = request.args.get('bill_date', '')
    details = []
    header_data = None
    print_time = datetime.datetime.now().strftime('%d/%b/%Y %I:%M %p')
    # Parse bill_date to YYYY-MM-DD
    bill_date = ''
    if bill_date_raw:
        try:
            bill_date_obj = datetime.datetime.strptime(bill_date_raw[:10], '%Y-%m-%d')
            bill_date = bill_date_obj.strftime('%Y-%m-%d')
        except Exception as e:
            bill_date = bill_date_raw[:10]
    if bill_no and bill_date:
        conn = get_db_connection()
        cursor = conn.cursor()
        # Fetch header data with only available columns
        header_query = '''
            SELECT TOP 1 
                d.PatientID, d.PatientName,
                p.BillNo, p.BillDate, p.BillStatus, p.DueAmount, p.BalanceAmount
            FROM PaymentDue p
            INNER JOIN DrugSlipDetails d ON p.BillNo = d.BillNo AND p.BillDate = d.BillDate
            WHERE p.BillNo = ? AND CONVERT(VARCHAR(10), p.BillDate, 120) = ?
        '''
        cursor.execute(header_query, (bill_no, bill_date))
        header_row = cursor.fetchone()
        if header_row:
            header_data = {
                'PatientID': getattr(header_row, 'PatientID', ''),
                'PatientName': getattr(header_row, 'PatientName', ''),
                'BillNo': getattr(header_row, 'BillNo', ''),
                'BillDate': getattr(header_row, 'BillDate', ''),
                'BillStatus': getattr(header_row, 'BillStatus', ''),
                'DueAmount': getattr(header_row, 'DueAmount', ''),
                'BalanceAmount': getattr(header_row, 'BalanceAmount', '')
            }
        # Fetch details
        sql_query = '''
            SELECT p.DueNo, p.DueDate, p.AmountReceived, p.BalanceAmount, p.DueStatus
            FROM PaymentDue p
            WHERE p.BillNo = ? AND CONVERT(VARCHAR(10), p.BillDate, 120) = ?
            ORDER BY p.DueNo
        '''
        cursor.execute(sql_query, (bill_no, bill_date))
        rows = cursor.fetchall()
        for row in rows:
            details.append({
                'DueNo': row.DueNo,
                'DueDate': row.DueDate,
                'AmountReceived': row.AmountReceived,
                'BalanceAmount': row.BalanceAmount,
                'DueStatus': row.DueStatus
            })
        # Calculate grand total
        grand_total = sum([r['AmountReceived'] for r in details]) if details else 0
        conn.close()
    else:
        grand_total = 0
    return render_template('creditdetails.html',
        bill_no=bill_no,
        bill_date=bill_date,
        header_data=header_data,
        rows=details,
        grand_total=grand_total,
        print_time=print_time)

@credit_paid_bp.route('/credit_paid_till_date')
def credit_paid_till_date():
    today = datetime.datetime.now()
    current_date_str = today.strftime('%Y-%m-%d')
    # Get all paid credits from the earliest date to today
    conn = get_db_connection()
    cursor = conn.cursor()
    sql_query = '''
        SELECT 
            p.BillNo, 
            p.BillDate, 
            MAX(d.PatientID) AS PatientID, 
            MAX(d.PatientName) AS PatientName, 
            SUM(p.DueAmount) AS DueAmount,
            SUM(p.BalanceAmount) AS BalanceAmount,
            SUM(p.AmountReceived) AS AmountReceived
        FROM PaymentDue p
        INNER JOIN DrugSlipDetails d ON p.BillNo = d.BillNo AND p.BillDate = d.BillDate
        WHERE p.DueNo = (SELECT MAX(DueNo) FROM PaymentDue WHERE BillNo = p.BillNo AND BillDate = p.BillDate AND BillStatus='P')
            AND p.DueStatus = 'CT'
            AND p.BillStatus = 'P'
        GROUP BY p.BillNo, p.BillDate
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
            'DueAmount': row.DueAmount,
            'BalanceAmount': row.BalanceAmount,
            'AmountReceived': row.AmountReceived
        })
    conn.close()
    return render_template('credit_paid_till_date.html',
        paid_credit=paid_credit,
        current_date=current_date_str)
