from flask import Blueprint, render_template, request
from db import get_db_connection

consolidated_sales_return_report_bp = Blueprint('consolidated_sales_return_report_bp', __name__)

@consolidated_sales_return_report_bp.route('/consolidatedsalesreturnreport', methods=['GET'])
def consolidated_sales_return_report():
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    rows = []
    if from_date and to_date:
        try:
            conn = get_db_connection()
            cursor = conn.cursor()
            cursor.execute('''
                SELECT r.ReturnBillNo, r.ReturnBillDateTime, r.PatientName, r.ProductName, r.BatchNo, r.ReturnQty, r.MRP, r.Total
                FROM SalesReturnDetails r
                WHERE r.ReturnBillDateTime >= ? AND r.ReturnBillDateTime <= ?
                ORDER BY r.ReturnBillDateTime DESC
            ''', (from_date + ' 00:00:00', to_date + ' 23:59:59'))
            rows = cursor.fetchall()
            conn.close()
        except Exception as e:
            print(f"[ERROR] Consolidated Sales Return Report: {e}")
    return render_template('consolidated_sales_return_report.html', rows=rows, from_date=from_date, to_date=to_date)
