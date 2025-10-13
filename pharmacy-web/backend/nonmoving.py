from flask import Blueprint, render_template, request, jsonify
import datetime
import sys
from db import get_db_connection

nonmoving_bp = Blueprint('nonmoving', __name__)

def format_date(date_str):
    if not date_str:
        return ''
    try:
        if isinstance(date_str, datetime.datetime):
            date_obj = date_str
        else:
            date_obj = datetime.datetime.strptime(date_str, '%Y-%m-%d')
        return date_obj.strftime('%d/%b/%Y')
    except:
        return date_str

# Register the template filter
nonmoving_bp.add_app_template_filter(format_date)

@nonmoving_bp.route('/nonmoving_data', methods=['POST'])
def nonmoving_data():
    conn = get_db_connection()
    cursor = conn.cursor()
    
    # Get parameters from AJAX
    offset = int(request.form.get('offset', 0))
    limit = int(request.form.get('limit', 50))
    selected_group = request.form.get('product_group', 'All')
    selected_product = request.form.get('product_name', 'All')
    from_date_str = request.form.get('from_date', datetime.datetime.now().strftime('%Y-%m-01'))
    to_date_str = request.form.get('to_date', datetime.datetime.now().strftime('%Y-%m-%d'))
    
    # Keep as strings for the database queries
    from_date = from_date_str
    to_date = to_date_str

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
    results = []

    for pname in paginated_products:
        # Opening Stock calculation using original logic from stock report
        cursor.execute("""
            SELECT 
                ISNULL(SUM(CASE WHEN Type = 'Purchase' THEN Qty ELSE 0 END), 0) as OpeningPurchase,
                ISNULL(SUM(CASE WHEN Type = 'SalesReturn' THEN Qty ELSE 0 END), 0) as OpeningSalesReturn,
                ISNULL(SUM(CASE WHEN Type = 'Excess' THEN Qty ELSE 0 END), 0) as OpeningExcess,
                ISNULL(SUM(CASE WHEN Type = 'Sales' THEN Qty ELSE 0 END), 0) as OpeningSales,
                ISNULL(SUM(CASE WHEN Type = 'Shortage' THEN Qty ELSE 0 END), 0) as OpeningShortage
            FROM (
                SELECT 'Purchase' as Type, Qty FROM InvoiceDetails 
                WHERE ProductName = ? AND InvoiceDateTime < ? AND Status <> 'C'
                UNION ALL
                SELECT 'SalesReturn', ReturnQty FROM SalesReturnDetails
                WHERE ProductName = ? AND ReturnBillDateTime < ?
                UNION ALL
                SELECT 'Excess', ESQty FROM ESTable
                WHERE ProductName = ? AND ESDate < ? AND ESType = 'Excess'
                UNION ALL
                SELECT 'Sales', Qty FROM DrugSlipDetails
                WHERE ProductName = ? AND BillDate < ? AND Status <> 'C'
                UNION ALL
                SELECT 'Shortage', ESQty FROM ESTable
                WHERE ProductName = ? AND ESDate < ? AND ESType = 'Shortage'
            ) as Combined
        """, (pname, from_date, pname, from_date, pname, from_date, pname, from_date, pname, from_date))
        
        opening_data = cursor.fetchone()
        opening_stock = (
            opening_data[0] +  # Purchase
            opening_data[1] +  # Sales Return
            opening_data[2] -  # Excess
            opening_data[3] -  # Sales
            opening_data[4]    # Shortage
        ) if opening_data else 0

        # Get sales in date range
        cursor.execute("""
            SELECT ISNULL(SUM(Qty), 0)
            FROM DrugSlipDetails
            WHERE ProductName = ? 
            AND BillDate BETWEEN ? AND ? 
            AND Status <> 'C'
        """, (pname, from_date, to_date))
        
        sales_data = cursor.fetchone()
        
        # Only include items with Opening Stock >= 1 and Sales = 0
        current_sales = sales_data[0] if sales_data else 0
        if opening_stock >= 1 and current_sales == 0:
            results.append({
                'Date': from_date,
                'ProductName': pname,
                'OpeningStock': opening_stock,
                'Sales': current_sales
            })

    conn.close()
    return jsonify({'results': results, 'has_more': offset+limit < len(product_list)})

def format_date(date_str):
    if not date_str:
        return ''
    try:
        if isinstance(date_str, datetime.datetime):
            date_obj = date_str
        else:
            date_obj = datetime.datetime.strptime(str(date_str), '%Y-%m-%d')
        return date_obj.strftime('%d/%b/%Y')
    except:
        return str(date_str)

@nonmoving_bp.route('/nonmoving', methods=['GET', 'POST'])
def nonmoving():
    print("=== [Flask] Entered nonmoving() route ===", file=sys.stderr)
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

        for pname in paginated_products:
            # Opening Stock calculation using original logic from stock report
            cursor.execute("""
                SELECT 
                    ISNULL(SUM(CASE WHEN Type = 'Purchase' THEN Qty ELSE 0 END), 0) as OpeningPurchase,
                    ISNULL(SUM(CASE WHEN Type = 'SalesReturn' THEN Qty ELSE 0 END), 0) as OpeningSalesReturn,
                    ISNULL(SUM(CASE WHEN Type = 'Excess' THEN Qty ELSE 0 END), 0) as OpeningExcess,
                    ISNULL(SUM(CASE WHEN Type = 'Sales' THEN Qty ELSE 0 END), 0) as OpeningSales,
                    ISNULL(SUM(CASE WHEN Type = 'Shortage' THEN Qty ELSE 0 END), 0) as OpeningShortage
                FROM (
                    SELECT 'Purchase' as Type, Qty FROM InvoiceDetails 
                    WHERE ProductName = ? AND InvoiceDateTime < ? AND Status <> 'C'
                    UNION ALL
                    SELECT 'SalesReturn', ReturnQty FROM SalesReturnDetails
                    WHERE ProductName = ? AND ReturnBillDateTime < ?
                    UNION ALL
                    SELECT 'Excess', ESQty FROM ESTable
                    WHERE ProductName = ? AND ESDate < ? AND ESType = 'Excess'
                    UNION ALL
                    SELECT 'Sales', Qty FROM DrugSlipDetails
                    WHERE ProductName = ? AND BillDate < ? AND Status <> 'C'
                    UNION ALL
                    SELECT 'Shortage', ESQty FROM ESTable
                    WHERE ProductName = ? AND ESDate < ? AND ESType = 'Shortage'
                ) as Combined
            """, (pname, from_date, pname, from_date, pname, from_date, pname, from_date, pname, from_date))
            
            opening_data = cursor.fetchone()
            opening_stock = (
                opening_data[0] +  # Purchase
                opening_data[1] +  # Sales Return
                opening_data[2] -  # Excess
                opening_data[3] -  # Sales
                opening_data[4]    # Shortage
            ) if opening_data else 0

            # Get sales in date range - using original logic
            cursor.execute("""
                SELECT ISNULL(SUM(Qty), 0)
                FROM DrugSlipDetails
                WHERE ProductName = ? 
                AND BillDate BETWEEN ? AND ? 
                AND Status <> 'C'
            """, (pname, from_date, to_date))
            
            sales_data = cursor.fetchone()
            
        results.append({
            'Date': format_date(from_date),
            'ProductName': pname,
            'OpeningStock': opening_stock,
            'Sales': sales_data[0] if sales_data else 0
        })        # Sort results by product name
        results.sort(key=lambda x: x['ProductName'])

    total_pages = (total_records + per_page - 1) // per_page if total_records else 1
    conn.close()
    return render_template('nonmoving.html', 
                         groups=groups, 
                         products=products, 
                         selected_group=selected_group, 
                         selected_product=selected_product, 
                         from_date=from_date, 
                         to_date=to_date, 
                         results=results, 
                         page=page, 
                         total_pages=total_pages,
                         format_date=format_date)