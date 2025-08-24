from flask import Blueprint, render_template, request
from db import get_db_connection

consolidated_credit_report_bp = Blueprint('consolidated_credit_report_bp', __name__)

@consolidated_credit_report_bp.route('/consolidatedcreditreport', methods=['GET'])
def consolidated_credit_report():
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    rows = []
    if from_date and to_date:
        try:
            conn = get_db_connection()
            cursor = conn.cursor()
            # Credit bills: DueStatus = 'CT', BillStatus = 'P', BalanceAmount > 0
            cursor.execute('''
                SELECT d.PatientID, d.BillNo, d.BillDate, d.PatientName, SUM(p.BalanceAmount) AS BalanceAmount
                FROM PaymentDue p
                INNER JOIN DrugSlipDetails d ON p.BillNo = d.BillNo AND p.BillDate = d.BillDate
                WHERE p.DueStatus = 'CT' AND p.BillStatus = 'P' AND p.BalanceAmount > 0
                    AND p.DueDate BETWEEN ? AND ?
                GROUP BY d.PatientID, d.BillNo, d.BillDate, d.PatientName
                ORDER BY d.BillDate DESC
            ''', (from_date + ' 00:00:00', to_date + ' 23:59:59'))
            rows = cursor.fetchall()
            conn.close()
        except Exception as e:
            print(f"[ERROR] Consolidated Credit Report: {e}")
    return render_template('consolidated_credit_report.html', rows=rows, from_date=from_date, to_date=to_date)
