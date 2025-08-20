# metrics.py
# Centralized metric calculation functions for dashboard
import pyodbc
from db import get_db_connection

def get_total_products(from_date=None, to_date=None):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT COUNT(*) FROM ProductMaster")
    result = cursor.fetchone()[0]
    conn.close()
    return result

def get_total_suppliers():
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT COUNT(*) FROM SupplierMaster")
    result = cursor.fetchone()[0]
    conn.close()
    return result

def get_purchase_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(*) AS bill_count, ISNULL(SUM(Total),0) AS bill_value
        FROM InvoiceDetails
        WHERE InvoiceDateTime BETWEEN ? AND ?
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value

def get_sales_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(*) AS bill_count, ISNULL(SUM(Total),0) AS bill_value
        FROM DrugSlipDetails
        WHERE BillDate BETWEEN ? AND ?
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value

def get_sales_return_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(DISTINCT ReturnBillNo) AS bill_count, ISNULL(SUM(ReturnQty * MRP),0) AS bill_value
        FROM SalesReturnDetails
        WHERE ReturnBillDateTime BETWEEN ? AND ?
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value

def get_cashless_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(DISTINCT BillNo) AS bill_count, ISNULL(SUM(Total),0) AS bill_value
        FROM DrugSlipDetails
        WHERE cash = 'Y' AND BillDate BETWEEN ? AND ?
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value
def get_credit_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(DISTINCT p.BillNo) AS bill_count, ISNULL(SUM(p.BalanceAmount),0) AS total_balance
        FROM PaymentDue p
        WHERE p.DueStatus = 'CT' AND p.BillStatus = 'P' AND p.DueDate BETWEEN ? AND ?
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.total_balance
