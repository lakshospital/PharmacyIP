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
        FROM (
            SELECT InvoiceNo, CONVERT(VARCHAR(10), InvoiceDateTime, 120) AS InvoiceDate, SUM(Total) AS Total
            FROM InvoiceDetails
            WHERE InvoiceDateTime BETWEEN ? AND ?
            GROUP BY InvoiceNo, CONVERT(VARCHAR(10), InvoiceDateTime, 120)
        ) AS sub
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value

def get_sales_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(*) AS bill_count, ISNULL(SUM(Total),0) AS bill_value
        FROM (
            SELECT BillNo, BillDate, SUM(Total) AS Total
            FROM DrugSlipDetails
            WHERE BillDate BETWEEN ? AND ?
            GROUP BY BillNo, BillDate
        ) AS sub
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value

def get_sales_return_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(*) AS bill_count, ISNULL(SUM(Total),0) AS bill_value
        FROM (
            SELECT ReturnBillNo, CONVERT(VARCHAR(10), ReturnBillDateTime, 120) AS ReturnDate, SUM(Total) AS Total
            FROM SalesReturnDetails
            WHERE ReturnBillDateTime BETWEEN ? AND ?
            GROUP BY ReturnBillNo, CONVERT(VARCHAR(10), ReturnBillDateTime, 120)
        ) AS sub
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value

def get_cashless_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(*) AS bill_count, ISNULL(SUM(Total),0) AS bill_value
        FROM (
            SELECT BillNo, BillDate, SUM(Total) AS Total
            FROM DrugSlipDetails
            WHERE cash = 'Y' AND BillDate BETWEEN ? AND ?
            GROUP BY BillNo, BillDate
        ) AS sub
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.bill_value
def get_credit_metrics(from_date, to_date):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT COUNT(*) AS bill_count, ISNULL(SUM(BalanceAmount),0) AS total_balance
        FROM (
            SELECT p.BillNo, p.BillDate, SUM(p.BalanceAmount) AS BalanceAmount
            FROM PaymentDue p
            WHERE p.DueStatus = 'CT' AND p.BillStatus = 'P' AND p.DueDate BETWEEN ? AND ?
            GROUP BY p.BillNo, p.BillDate
        ) AS sub
    """, (from_date, to_date))
    row = cursor.fetchone()
    conn.close()
    return row.bill_count, row.total_balance
