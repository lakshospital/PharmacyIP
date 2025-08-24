from flask import Blueprint, render_template, request
from db import get_db_connection

consolidated_sales_report_bp = Blueprint('consolidated_sales_report_bp', __name__)

@consolidated_sales_report_bp.route('/consolidatedsalesreport', methods=['GET'])
def consolidated_sales_report():
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    rows = []
    if from_date and to_date:
        try:
            conn = get_db_connection()
            cursor = conn.cursor()
            # Efficient query: join DrugSlipDetails with PatientMaster if needed
            cursor.execute('''
                SELECT d.BillNo, d.BillDate, d.PatientName, d.ProductName, d.BatchNo, d.ExpDate, d.Qty, d.MRP, d.Total
                FROM DrugSlipDetails d
                WHERE d.BillDate >= ? AND d.BillDate <= ?
                ORDER BY d.BillDate DESC
            ''', (from_date + ' 00:00:00', to_date + ' 23:59:59'))
            rows = cursor.fetchall()
            conn.close()
        except Exception as e:
            print(f"[ERROR] Consolidated Sales Report: {e}")
    return render_template('consolidated_sales_report.html', rows=rows, from_date=from_date, to_date=to_date)
