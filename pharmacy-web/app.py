from flask import Flask, render_template, request
import pyodbc
import datetime

app = Flask(__name__)

# SQL Server connection details
server = 'LAPTOP-C27U7D67\\SQLEXPRESS'
database = 'Pharmacy'

def get_db_connection():
    conn_str = (
        'DRIVER={ODBC Driver 17 for SQL Server};'
        'SERVER=DESKTOP-A674QQN\\SQLEXPRESS01;'
        'DATABASE=InPatient_PharmcyDB;'
        'UID=lhs2;'
        'PWD=lhs2;'
    )
    return pyodbc.connect(conn_str)

@app.route('/', methods=['GET', 'POST'])
def index():
    rows = []
    header_data = {}
    print_time = None
    grand_total = 0
    show_sno = True
    show_seq_id = True
    
    current_year = datetime.datetime.now().year
    years = list(range(current_year, current_year - 4, -1))
    
    # Fetch last 10 bill numbers
    last_10_bills = []
    try:
        conn = get_db_connection()
        cursor = conn.cursor()
        sql_query = "SELECT DISTINCT TOP 10 BillNo FROM DrugSlipDetails WHERE YEAR(BillDate) = ? ORDER BY BillNo DESC"
        cursor.execute(sql_query, current_year)
        last_10_bills = [str(row.BillNo) for row in cursor.fetchall()]
        conn.close()
    except Exception as e:
        print(f"Database error fetching last 10 bills: {e}")

    if request.method == 'POST':
        show_sno = request.form.get('show_sno') == 'on'
        show_seq_id = request.form.get('show_seq_id') == 'on'
        bill_no = request.form.get('bill_no')
        year = request.form.get('year')
        
        # Store original results in session or pass them back to the template
        # For simplicity, we'll re-query, but a session-based approach would be more efficient
        if bill_no and year:
            try:
                conn = get_db_connection()
                cursor = conn.cursor()
                sql_query = """
                    SELECT BillNo, BillDate, DrName, PatientID, PatientName, CaseType,
                           SNo, ProductName, Qty, BatchNo, ExpDate, VAT, MRP, InvoiceNo, Total 
                    FROM DrugSlipDetails 
                    WHERE BillNo = ? AND YEAR(BillDate) = ?
                """
                cursor.execute(sql_query, (bill_no, year))
                all_rows_for_bill = cursor.fetchall()
                conn.close()

                if all_rows_for_bill:
                    print_time = datetime.datetime.now().strftime('%d/%b/%Y %I:%M:%S %p')
                    first_row = all_rows_for_bill[0]
                    header_data = {
                        'BillNo': first_row.BillNo,
                        'BillDate': first_row.BillDate,
                        'DrName': first_row.DrName,
                        'PatientID': first_row.PatientID,
                        'PatientName': first_row.PatientName,
                        'Case': first_row.CaseType
                    }

                    # Check if filtering by SNo
                    if 'search_sno' in request.form:
                        selected_snos = request.form.getlist('sno_checkbox')
                        if selected_snos:
                            # Convert SNo strings to int for comparison
                            selected_snos_int = [int(s) for s in selected_snos]
                            rows = [row for row in all_rows_for_bill if row.SNo in selected_snos_int]
                        else:
                            # If "Search with SNo" is clicked but none are selected, show all
                            rows = all_rows_for_bill
                    else:
                        # Initial search, show all rows
                        rows = all_rows_for_bill
                    
                    # Recalculate total based on displayed rows
                    grand_total = sum(row.Total for row in rows)
                
            except Exception as e:
                print(f"Database error: {e}")
                
    return render_template('index.html', rows=rows, years=years, header_data=header_data, print_time=print_time, grand_total=grand_total, show_sno=show_sno, show_seq_id=show_seq_id, last_10_bills=last_10_bills)

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000, debug=True)

