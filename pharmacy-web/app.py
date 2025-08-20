from flask import Flask, render_template, request, jsonify
import datetime
from db import get_db_connection

app = Flask(__name__)
# SQL Server connection details
server = 'LAPTOP-C27U7D67\\SQLEXPRESS'
database = 'Pharmacy'

# Sales details API for dashboard modal
@app.route('/get_sales')
def get_sales():
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT BillNo, MIN(BillDate) AS BillDate, MAX(PatientName) AS PatientName
        FROM DrugSlipDetails
        WHERE BillNo IS NOT NULL AND BillDate >= ? AND BillDate <= ?
        GROUP BY BillNo
        ORDER BY MIN(BillDate) DESC
    """, (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    sales = [dict(zip([column[0] for column in cursor.description], row)) for row in cursor.fetchall()]
    conn.close()
    return jsonify({'sales': sales})

# Purchase details API for dashboard modal
@app.route('/get_purchases')
def get_purchases():
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""
        SELECT i.InvoiceNo, i.InvoiceDateTime, s.SupplierName
        FROM InvoiceDetails i
        LEFT JOIN SupplierMaster s ON i.SupplierID = s.SupplierID
        WHERE i.InvoiceDateTime >= ? AND i.InvoiceDateTime <= ?
        ORDER BY i.InvoiceDateTime DESC
    """, (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    purchases = [dict(zip([column[0] for column in cursor.description], row)) for row in cursor.fetchall()]
    conn.close()
    return jsonify({'purchases': purchases})

@app.route('/dashboard', methods=['GET', 'POST'])
def dashboard():
    conn = get_db_connection()
    cursor = conn.cursor()
    # Total Products (not date dependent)
    cursor.execute("SELECT COUNT(*) FROM ProductMaster")
    total_products = cursor.fetchone()[0]
    # Total Suppliers (not date dependent)
    cursor.execute("SELECT COUNT(*) FROM SupplierMaster")
    total_suppliers = cursor.fetchone()[0]

    # Get from_date and to_date from form, default to current month
    today = datetime.datetime.now()
    current_date_str = today.strftime('%Y-%m-%d')
    if request.method == 'POST':
        from_date = request.form.get('from_date', current_date_str)
        to_date = request.form.get('to_date', current_date_str)
    else:
        from_date = request.args.get('from_date', current_date_str)
        to_date = request.args.get('to_date', current_date_str)

    # Total Purchase Bills (InvoiceDetails)
    cursor.execute("SELECT COUNT(DISTINCT InvoiceNo) FROM InvoiceDetails WHERE InvoiceDateTime >= ? AND InvoiceDateTime <= ?", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    total_purchase_bills = cursor.fetchone()[0]
    # Total Sales Bills (DrugSlipDetails)
    cursor.execute("SELECT COUNT(DISTINCT BillNo) FROM DrugSlipDetails WHERE BillDate >= ? AND BillDate <= ?", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    total_sales_bills = cursor.fetchone()[0]
    # Total Purchase Value
    cursor.execute("SELECT ISNULL(SUM(Total),0) FROM InvoiceDetails WHERE InvoiceDateTime >= ? AND InvoiceDateTime <= ?", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    total_purchase_value = round(cursor.fetchone()[0] or 0, 2)
    # Total Sales Value
    cursor.execute("SELECT ISNULL(SUM(Total),0) FROM DrugSlipDetails WHERE BillDate >= ? AND BillDate <= ?", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    total_sales_value = round(cursor.fetchone()[0] or 0, 2)

    # Sales Return Value
    cursor.execute("SELECT ISNULL(SUM(ReturnQty * MRP),0) FROM SalesReturnDetails WHERE ReturnBillDateTime >= ? AND ReturnBillDateTime <= ?", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    sales_return_value = round(cursor.fetchone()[0] or 0, 2)

    # Purchase Return Value & Bill Count

    # Sales Return Value & Bill Count
    cursor.execute("IF OBJECT_ID('SalesReturnDetails', 'U') IS NOT NULL SELECT ISNULL(SUM(ReturnQty * MRP),0) FROM SalesReturnDetails WHERE ReturnBillDateTime >= ? AND ReturnBillDateTime <= ? ELSE SELECT 0", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    sales_return_value = round(cursor.fetchone()[0] or 0, 2)
    cursor.execute("IF OBJECT_ID('SalesReturnDetails', 'U') IS NOT NULL SELECT COUNT(DISTINCT ReturnBillNo) FROM SalesReturnDetails WHERE ReturnBillDateTime >= ? AND ReturnBillDateTime <= ? ELSE SELECT 0", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    sales_return_count = cursor.fetchone()[0]

    # Cashless Value & Bill Count (fix: cashless is cash = 'Y')
    cursor.execute("SELECT ISNULL(SUM(Total),0) FROM DrugSlipDetails WHERE BillDate >= ? AND BillDate <= ? AND cash = 'Y'", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    cashless_value = round(cursor.fetchone()[0] or 0, 2)
    cursor.execute("SELECT COUNT(DISTINCT BillNo) FROM DrugSlipDetails WHERE BillDate >= ? AND BillDate <= ? AND cash = 'Y'", (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    cashless_count = cursor.fetchone()[0]

    # Recent Sales grouped by BillNo (filtered by date)
    cursor.execute("""
        SELECT BillNo, MIN(BillDate) AS BillDate, MAX(PatientName) AS PatientName
        FROM DrugSlipDetails
        WHERE BillNo IS NOT NULL AND BillDate >= ? AND BillDate <= ?
        GROUP BY BillNo
        ORDER BY MIN(BillDate) DESC
    """, (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    recent_sales = [dict(zip([column[0] for column in cursor.description], row)) for row in cursor.fetchall()]

    # Recent Purchases grouped by InvoiceNo (filtered by date)
    cursor.execute("""
        SELECT i.InvoiceNo, MIN(i.InvoiceDateTime) AS InvoiceDateTime, MAX(s.SupplierName) AS SupplierName
        FROM InvoiceDetails i
        LEFT JOIN SupplierMaster s ON i.SupplierID = s.SupplierID
        WHERE i.InvoiceNo IS NOT NULL AND i.InvoiceDateTime >= ? AND i.InvoiceDateTime <= ?
        GROUP BY i.InvoiceNo
        ORDER BY MIN(i.InvoiceDateTime) DESC
    """, (from_date + ' 00:00:00', to_date + ' 23:59:59'))
    recent_purchases = [dict(zip([column[0] for column in cursor.description], row)) for row in cursor.fetchall()]
    conn.close()
    return render_template('dashboard.html',
        total_products=total_products,
        total_suppliers=total_suppliers,
        total_purchase_bills=total_purchase_bills,
        total_sales_bills=total_sales_bills,
        total_purchase_value=total_purchase_value,
        total_sales_value=total_sales_value,
        sales_return_value=sales_return_value,
        sales_return_count=sales_return_count,
        cashless_value=cashless_value,
        cashless_count=cashless_count,
        from_date=from_date,
        to_date=to_date,
        recent_sales=recent_sales,
        recent_purchases=recent_purchases)

@app.route('/get_suppliers', methods=['GET'])
def get_suppliers():
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT SupplierName, Street1, Street2, City, PINCode, Phone FROM SupplierMaster")
    suppliers = []
    for row in cursor.fetchall():
        address = f"{row.Street1 or ''}, {row.Street2 or ''}, {row.City or ''} - {row.PINCode or ''}".replace(' ,', '').strip(', ')
        suppliers.append({
            'SupplierName': row.SupplierName,
            'Address': address,
            'Phone': row.Phone or ''
        })
    conn.close()
    return jsonify({'suppliers': suppliers})


# Bill Details
@app.route('/billdetails', methods=['GET'])
def billdetails():
    bill_no = request.args.get('bill_no')
    rows = []
    header_data = {}
    print_time = None
    grand_total = 0
    year = None
    if bill_no:
        try:
            conn = get_db_connection()
            cursor = conn.cursor()
            # Get year from BillDate for the bill_no
            cursor.execute("SELECT TOP 1 YEAR(BillDate) FROM DrugSlipDetails WHERE BillNo = ?", (bill_no,))
            year_row = cursor.fetchone()
            if year_row:
                year = year_row[0]
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
                    rows = all_rows_for_bill
                    grand_total = sum(row.Total for row in rows)
        except Exception as e:
            print(f"Database error: {e}")
    return render_template('billdetails.html', rows=rows, header_data=header_data, print_time=print_time, grand_total=grand_total)


# Purchase Details
@app.route('/purchasedetails', methods=['GET'])
def purchasedetails():
    invoice_no = request.args.get('invoice_no')
    rows = []
    header_data = {}
    print_time = None
    grand_total = 0
    if invoice_no:
        try:
            conn = get_db_connection()
            cursor = conn.cursor()
            # Get header info
            cursor.execute("""
                SELECT TOP 1 i.InvoiceNo, i.InvoiceDateTime, s.SupplierName
                FROM InvoiceDetails i
                LEFT JOIN SupplierMaster s ON i.SupplierID = s.SupplierID
                WHERE i.InvoiceNo = ?
            """, (invoice_no,))
            header_row = cursor.fetchone()
            if header_row:
                header_data = {
                    'InvoiceNo': header_row.InvoiceNo,
                    'InvoiceDateTime': header_row.InvoiceDateTime,
                    'SupplierName': header_row.SupplierName
                }
            # Get product rows
            cursor.execute("""
                SELECT SNo, ProductName, Qty, BatchNo, ExpDate, VAT, MRP, HSR, Total
                FROM InvoiceDetails
                WHERE InvoiceNo = ?
            """, (invoice_no,))
            rows = cursor.fetchall()
            conn.close()
            if rows:
                print_time = datetime.datetime.now().strftime('%d/%b/%Y %I:%M:%S %p')
                grand_total = sum(row.Total for row in rows)
        except Exception as e:
            print(f"Database error: {e}")
    return render_template('purchasedetails.html', rows=rows, header_data=header_data, print_time=print_time, grand_total=grand_total)


# AJAX endpoint to get products for a selected group
@app.route('/get_products', methods=['POST'])
def get_products():
    group = request.json.get('group')
    conn = get_db_connection()
    cursor = conn.cursor()
    if group == 'All':
        cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> ''")
    else:
        cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductGroup=? AND ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> ''", (group,))
    products = [row[0] for row in cursor.fetchall()]
    conn.close()
    return jsonify({'products': products})

@app.route('/report1_data', methods=['POST'])
def report1_data():
    import sys
    conn = get_db_connection()
    cursor = conn.cursor()
    # Get parameters from AJAX
    offset = int(request.form.get('offset', 0))
    limit = int(request.form.get('limit', 50))
    selected_group = request.form.get('product_group', 'All')
    selected_product = request.form.get('product_name', 'All')
    from_date = request.form.get('from_date', datetime.datetime.now().strftime('%Y-%m-01'))
    to_date = request.form.get('to_date', datetime.datetime.now().strftime('%Y-%m-%d'))

    # Get product list
    if selected_product == 'All' and selected_group != 'All':
        cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductGroup=? AND ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> '' ORDER BY ProductName ASC", (selected_group,))
        product_list = [row[0] for row in cursor.fetchall()]
    elif selected_group == 'All' and selected_product == 'All':
        cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> '' ORDER BY ProductName ASC")
        product_list = [row[0] for row in cursor.fetchall()]
    else:
        product_list = [selected_product]

    paginated_products = product_list[offset:offset+limit]
    print(f"[DEBUG] paginated_products: {paginated_products}", file=sys.stderr)
    results = []

    # Batch queries for all paginated products
    placeholders = ','.join(['?'] * len(paginated_products))
    # Opening Stock
    cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM InvoiceDetails WHERE ProductName IN ({placeholders}) AND InvoiceDateTime<? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
    opening_purchase_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    cursor.execute(f"SELECT ProductName, ISNULL(SUM(ReturnQty),0) as Qty FROM SalesReturnDetails WHERE ProductName IN ({placeholders}) AND ReturnBillDateTime<? GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
    opening_sales_return_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate<? AND ESType='Excess' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
    opening_excess_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM DrugSlipDetails WHERE ProductName IN ({placeholders}) AND BillDate<? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
    opening_sales_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate<? AND ESType='Shortage' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
    opening_shortage_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    # Purchase in date range
    cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM InvoiceDetails WHERE ProductName IN ({placeholders}) AND InvoiceDateTime>=? AND InvoiceDateTime<=? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
    purchase_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    # Sales in date range
    cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM DrugSlipDetails WHERE ProductName IN ({placeholders}) AND BillDate>=? AND BillDate<=? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
    sales_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    # Sales Return in date range
    cursor.execute(f"SELECT ProductName, ISNULL(SUM(ReturnQty),0) as Qty FROM SalesReturnDetails WHERE ProductName IN ({placeholders}) AND ReturnBillDateTime>=? AND ReturnBillDateTime<=? GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
    sales_return_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    # Excess in date range
    cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate>=? AND ESDate<=? AND ESType='Excess' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
    excess_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    # Shortage in date range
    cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate>=? AND ESDate<=? AND ESType='Shortage' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
    shortage_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

    for pname in paginated_products:
        opening_purchase = opening_purchase_dict.get(pname, 0)
        opening_sales_return = opening_sales_return_dict.get(pname, 0)
        opening_excess = opening_excess_dict.get(pname, 0)
        opening_sales = opening_sales_dict.get(pname, 0)
        opening_shortage = opening_shortage_dict.get(pname, 0)
        opening_stock = (opening_purchase + opening_sales_return + opening_excess) - (opening_sales + opening_shortage)

        purchase = purchase_dict.get(pname, 0)
        sales = sales_dict.get(pname, 0)
        sales_return = sales_return_dict.get(pname, 0)
        excess = excess_dict.get(pname, 0)
        shortage = shortage_dict.get(pname, 0)
        closing_stock = opening_stock + purchase + sales_return + excess - sales - shortage

        # OpeningValue
        cursor.execute("SELECT ISNULL(SUM(Qty * ISNULL(HSR,0)),0) FROM InvoiceDetails WHERE ProductName=? AND InvoiceDateTime<? AND Status<>'C'", (pname, from_date + ' 00:00:00'))
        OpeningValue = cursor.fetchone()[0] or 0
        # PurchaseValue
        cursor.execute("SELECT ISNULL(SUM(Qty * ISNULL(HSR,0)),0) FROM InvoiceDetails WHERE ProductName=? AND InvoiceDateTime>=? AND InvoiceDateTime<=? AND Status<>'C'", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        PurchaseValue = cursor.fetchone()[0] or 0
        # SalesValue
        cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT Qty * ISNULL((SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.ProductName AND i.BatchNo = d.BatchNo AND i.InvoiceNo = SUBSTRING(d.InvoiceNo, 1, CHARINDEX('-', d.InvoiceNo)-1) AND YEAR(i.InvoiceDateTime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, 4)),0) AS total FROM DrugSlipDetails d WHERE ProductName=? AND BillDate>=? AND BillDate<=? AND Status<>'C') DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        SalesValue = cursor.fetchone()[0] or 0
        # SalesReturnValue
        cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT ReturnQty * ISNULL((SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.ProductName AND i.BatchNo = d.BatchNo AND i.InvoiceNo = SUBSTRING(d.InvoiceNo, 1, CHARINDEX('-', d.InvoiceNo)-1) AND YEAR(i.InvoiceDateTime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, 4)),0) AS total FROM SalesReturnDetails d WHERE ProductName=? AND ReturnBillDateTime>=? AND ReturnBillDateTime<=?) DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        SalesReturnValue = cursor.fetchone()[0] or 0
        # ExcessValue
        cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT ESQty * ISNULL((SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.ProductName AND i.BatchNo = d.BatchNo AND i.InvoiceNo = d.InvoiceNo AND YEAR(i.InvoiceDateTime) = d.InvoiceYear),0) AS total FROM ESTable d WHERE ProductName=? AND ESDate>=? AND ESDate<=? AND ESType='Excess') DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        ExcessValue = cursor.fetchone()[0] or 0
        # ShortageValue
        cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT ESQty * ISNULL((SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.ProductName AND i.BatchNo = d.BatchNo AND i.InvoiceNo = d.InvoiceNo AND YEAR(i.InvoiceDateTime) = d.InvoiceYear),0) AS total FROM ESTable d WHERE ProductName=? AND ESDate>=? AND ESDate<=? AND ESType='Shortage') DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        ShortageValue = cursor.fetchone()[0] or 0
        # Always append every product, even if all values are zero (match VB logic)
        cursor.execute("""
            SELECT ISNULL(SUM(s.CurrentQty * i.HSR), 0)
            FROM StockDetails s
            INNER JOIN InvoiceDetails i ON s.InvoiceNo = i.InvoiceNo AND s.BatchNo = i.BatchNo AND s.ProductName = i.ProductName
            WHERE s.ProductName = ? AND s.CurrentQty > 0
        """, (pname,))
        StockValue = cursor.fetchone()[0] or 0
        results.append({
            'ProductName': pname,
            'OpeningStock': opening_stock,
            'Purchase': purchase,
            'Sales': sales,
            'SalesReturn': sales_return,
            'Excess': excess,
            'Shortage': shortage,
            'ClosingStock': closing_stock,
            'StockValue': StockValue,
            'Date': from_date
        })
    conn.close()
    return jsonify({'results': results, 'has_more': offset+limit < len(product_list)})


# Report 1 (moved from report1.py)
@app.route('/report1', methods=['GET', 'POST'])
def report1():
    import sys
    print("=== [Flask] Entered report1() route from app.py ===", file=sys.stderr)
    conn = get_db_connection()
    cursor = conn.cursor()
    # Fetch product groups (exclude empty/null)
    cursor.execute("SELECT GroupName FROM ProductGroupMaster WHERE GroupName IS NOT NULL AND LTRIM(RTRIM(GroupName)) <> ''")
    groups = [row[0] for row in cursor.fetchall()]
    groups.insert(0, 'All')

    # Pagination: read from form for POST, args for GET
    try:
        if request.method == 'POST':
            page = int(request.form.get('page', 1))
        else:
            page = int(request.args.get('page', 1))
        if page < 1:
            page = 1
    except Exception:
        page = 1
    per_page = 50
    offset = (page - 1) * per_page

    selected_group = request.form.get('product_group', 'All')
    selected_product = request.form.get('product_name', 'All')
    from_date = request.form.get('from_date', datetime.datetime.now().strftime('%Y-%m-01'))
    to_date = request.form.get('to_date', datetime.datetime.now().strftime('%Y-%m-%d'))

    # Always update products list based on selected group
    if selected_group == 'All':
        cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> ''")
    else:
        cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductGroup=? AND ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> ''", (selected_group,))
    products = [row[0] for row in cursor.fetchall()]
    products.insert(0, 'All')
    products.insert(0, 'All')

    results = []
    total_records = 0
    if request.method == 'POST' and (request.form.get('product_group') or request.form.get('product_name')):
        # Determine product list for query
        if selected_product == 'All' and selected_group != 'All':
            cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductGroup=? AND ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> ''", (selected_group,))
            product_list = [row[0] for row in cursor.fetchall()]
        elif selected_group == 'All' and selected_product == 'All':
            cursor.execute("SELECT ProductName FROM ProductMaster WHERE ProductName IS NOT NULL AND LTRIM(RTRIM(ProductName)) <> ''")
            product_list = [row[0] for row in cursor.fetchall()]
        else:
            product_list = [selected_product]

        # Pagination: count total
        total_records = len(product_list)
        paginated_products = product_list[offset:offset+per_page]

        # Batch queries for all paginated products
        placeholders = ','.join(['?'] * len(paginated_products))
        # Opening Stock
        cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM InvoiceDetails WHERE ProductName IN ({placeholders}) AND InvoiceDateTime<? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
        opening_purchase_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        cursor.execute(f"SELECT ProductName, ISNULL(SUM(ReturnQty),0) as Qty FROM SalesReturnDetails WHERE ProductName IN ({placeholders}) AND ReturnBillDateTime<? GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
        opening_sales_return_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate<? AND ESType='Excess' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
        opening_excess_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM DrugSlipDetails WHERE ProductName IN ({placeholders}) AND BillDate<? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
        opening_sales_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate<? AND ESType='Shortage' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00'))
        opening_shortage_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        # Purchase in date range
        cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM InvoiceDetails WHERE ProductName IN ({placeholders}) AND InvoiceDateTime>=? AND InvoiceDateTime<=? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        purchase_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        # Sales in date range
        cursor.execute(f"SELECT ProductName, ISNULL(SUM(Qty),0) as Qty FROM DrugSlipDetails WHERE ProductName IN ({placeholders}) AND BillDate>=? AND BillDate<=? AND Status<>'C' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        sales_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        # Sales Return in date range
        cursor.execute(f"SELECT ProductName, ISNULL(SUM(ReturnQty),0) as Qty FROM SalesReturnDetails WHERE ProductName IN ({placeholders}) AND ReturnBillDateTime>=? AND ReturnBillDateTime<=? GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        sales_return_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        # Excess in date range
        cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate>=? AND ESDate<=? AND ESType='Excess' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        excess_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        # Shortage in date range
        cursor.execute(f"SELECT ProductName, ISNULL(SUM(ESQty),0) as Qty FROM ESTable WHERE ProductName IN ({placeholders}) AND ESDate>=? AND ESDate<=? AND ESType='Shortage' GROUP BY ProductName", (*paginated_products, from_date + ' 00:00:00', to_date + ' 23:59:59'))
        shortage_dict = {row.ProductName: row.Qty for row in cursor.fetchall()}

        # Value calculations using subqueries for HSR, matching VB logic
        for pname in paginated_products:
            opening_purchase = opening_purchase_dict.get(pname, 0)
            opening_sales_return = opening_sales_return_dict.get(pname, 0)
            opening_excess = opening_excess_dict.get(pname, 0)
            opening_sales = opening_sales_dict.get(pname, 0)
            opening_shortage = opening_shortage_dict.get(pname, 0)
            opening_stock = (opening_purchase + opening_sales_return + opening_excess) - (opening_sales + opening_shortage)

            purchase = purchase_dict.get(pname, 0)
            sales = sales_dict.get(pname, 0)
            sales_return = sales_return_dict.get(pname, 0)
            excess = excess_dict.get(pname, 0)
            shortage = shortage_dict.get(pname, 0)
            closing_stock = opening_stock + purchase + sales_return + excess - sales - shortage

            # OpeningValue
            cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT Qty * HSR as total FROM InvoiceDetails WHERE ProductName=? AND InvoiceDateTime<? AND Status<>'C') AS DERIVEDTBL", (pname, from_date + ' 00:00:00'))
            OpeningValue = cursor.fetchone()[0] or 0
            # PurchaseValue
            cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT Qty * HSR as total FROM InvoiceDetails WHERE ProductName=? AND InvoiceDateTime>=? AND InvoiceDateTime<=? AND Status<>'C') AS DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
            PurchaseValue = cursor.fetchone()[0] or 0
            # SalesValue
            cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT Qty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.productname AND i.BatchNo = d.batchno AND i.invoiceno = SUBSTRING(d.InvoiceNo, 1, CHARINDEX('-', d.InvoiceNo)-1) AND year(i.invoicedatetime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, 4)) AS total FROM DrugSlipDetails d WHERE ProductName=? AND BillDate>=? AND BillDate<=? AND Status<>'C') DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
            SalesValue = cursor.fetchone()[0] or 0
            # SalesReturnValue
            cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT ReturnQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.productname AND i.BatchNo = d.batchno AND i.invoiceno = SUBSTRING(d.InvoiceNo, 1, CHARINDEX('-', d.InvoiceNo)-1) AND year(i.invoicedatetime) = SUBSTRING(d.InvoiceNo, CHARINDEX('-', d.InvoiceNo) + 1, 4)) AS total FROM SalesReturnDetails d WHERE ProductName=? AND ReturnBillDateTime>=? AND ReturnBillDateTime<=?) DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
            SalesReturnValue = cursor.fetchone()[0] or 0
            # ExcessValue
            cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT ESQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.productname AND i.BatchNo = d.batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d.InvoiceYear) AS total FROM ESTable d WHERE ProductName=? AND ESDate>=? AND ESDate<=? AND ESType='Excess') DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
            ExcessValue = cursor.fetchone()[0] or 0
            # ShortageValue
            cursor.execute("SELECT ISNULL(SUM(total),0) FROM (SELECT ESQty * (SELECT TOP 1 i.HSR FROM InvoiceDetails i WHERE i.ProductName = d.productname AND i.BatchNo = d.batchno AND i.invoiceno = d.InvoiceNo AND year(i.invoicedatetime) = d.InvoiceYear) AS total FROM ESTable d WHERE ProductName=? AND ESDate>=? AND ESDate<=? AND ESType='Shortage') DERIVEDTBL", (pname, from_date + ' 00:00:00', to_date + ' 23:59:59'))
            ShortageValue = cursor.fetchone()[0] or 0

            StockValue = round((OpeningValue + PurchaseValue) - (SalesValue + SalesReturnValue + ExcessValue) - ShortageValue, 2)

            results.append({
                'ProductName': pname,
                'OpeningStock': opening_stock,
                'Purchase': purchase,
                'Sales': sales,
                'SalesReturn': sales_return,
                'Excess': excess,
                'Shortage': shortage,
                'ClosingStock': closing_stock,
                'StockValue': StockValue,
                'Date': from_date # Or use actual date if available
            })
    else:
        total_records = 0

    show_sales = request.form.get('show_sales') == 'on'
    hide_sales = request.form.get('hide_sales') == 'on'

    if show_sales:
        results = [row for row in results if row['Sales'] > 0 or row['SalesReturn'] > 0]
    elif hide_sales:
        results = [row for row in results if row['Sales'] == 0 and row['SalesReturn'] == 0]

    total_pages = (total_records + per_page - 1) // per_page if total_records else 1
    conn.close()
    return render_template('report1.html', groups=groups, products=products, selected_group=selected_group, selected_product=selected_product, from_date=from_date, to_date=to_date, results=results, page=page, total_pages=total_pages, show_sales=show_sales, hide_sales=hide_sales)


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
