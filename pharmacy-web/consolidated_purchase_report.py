from flask import Blueprint, render_template, request, current_app
import logging
from db import get_db_connection

# Register this blueprint in your main app:
# from consolidated_report import consolidated_report_bp
# app.register_blueprint(consolidated_report_bp)

consolidated_purchase_report_bp = Blueprint('consolidated_purchase_report_bp', __name__)

@consolidated_purchase_report_bp.route('/consolidatedpurchasereport', methods=['GET'])
def consolidated_purchase_report():
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    rows = []
    error = None
    try:
        conn = get_db_connection()
        if not conn:
            error = "Could not connect to the database."
        else:
            cursor = conn.cursor()
            if from_date and to_date:
                query = """
                    SELECT i.InvoiceNo, i.InvoiceDateTime, s.SupplierName,
                           i.ProductName, i.BatchNo, i.ExpDate, i.Qty, i.MRP, i.Total
                    FROM InvoiceDetails i
                    LEFT JOIN SupplierMaster s ON i.SupplierID = s.SupplierID
                    WHERE i.InvoiceDateTime >= ? AND i.InvoiceDateTime <= ?
                    ORDER BY i.InvoiceDateTime DESC
                """
                cursor.execute(query, (from_date + ' 00:00:00', to_date + ' 23:59:59'))
            rows = cursor.fetchall()
            conn.close()
    except Exception as e:
        error = f"Error fetching report: {e}"
        logging.error(error)
    return render_template('consolidated_purchase_report.html', rows=rows, from_date=from_date, to_date=to_date, error=error)
