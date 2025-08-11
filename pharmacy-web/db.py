import pyodbc

def get_db_connectionold():
    conn_strold = (
        'DRIVER={ODBC Driver 17 for SQL Server};'
        'SERVER=server\SQLEXPRESS;'
        'DATABASE=PharmacyDB;'
        'UID=sa;'
        # 'PWD=your_password;'  # Removed PWD for SQL Server authentication without password
        'Encrypt=no;'
    )
    return pyodbc.connect(conn_strold)
def get_db_connection():
    conn_str = (
        'DRIVER={ODBC Driver 17 for SQL Server};'
        'SERVER=LAPTOP-C27U7D67\\SQLEXPRESS;'
        'DATABASE=PharmacyDB;'
        'Trusted_Connection=yes;'
        'Encrypt=no;'
    )
    return pyodbc.connect(conn_str)