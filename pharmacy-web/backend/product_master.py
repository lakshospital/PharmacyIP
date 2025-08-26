from flask import Blueprint, render_template, request, redirect, url_for, flash
from db import get_db_connection

product_master_bp = Blueprint('product_master_bp', __name__)

@product_master_bp.route('/productmaster', methods=['GET', 'POST'])
def product_master():
    conn = get_db_connection()
    cursor = conn.cursor()
    # Fetch product groups
    cursor.execute('SELECT GroupName FROM ProductGroupMaster ORDER BY GroupName')
    product_groups = [row.GroupName for row in cursor.fetchall() if row.GroupName and row.GroupName.strip()]
    # Fetch doctor names
    cursor.execute('SELECT DoctorName FROM DoctorNameMaster ORDER BY DoctorName')
    doctor_names = [row.DoctorName for row in cursor.fetchall() if row.DoctorName and row.DoctorName.strip()]
    # Fetch combinations
    cursor.execute('SELECT CombinationName FROM CombinationMaster ORDER BY CombinationName')
    combinations = [row.CombinationName for row in cursor.fetchall() if row.CombinationName and row.CombinationName.strip()]
    if request.method == 'POST':
        # Add new product
        product_name = request.form['product_name']
        product_group = request.form['product_group']
        rack_no = request.form['rack_no']
        min_stock = request.form['min_stock']
        doctor_name = request.form['doctor_name']
        combination = request.form['combination']
        manufacturer = request.form['manufacturer']
        scheduleh = request.form['scheduleh']
        cursor.execute('''
            INSERT INTO ProductMaster (ProductName, ProductGroup, RackNo, MinimumStockToMaintain, DoctorName, Combination, Manufacturer, ScheduleH)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)
        ''', (product_name, product_group, rack_no, min_stock, doctor_name, combination, manufacturer, scheduleh))
        conn.commit()
        flash('Product added successfully!', 'success')
        return redirect(url_for('product_master_bp.product_master'))
    cursor.execute('SELECT * FROM ProductMaster ORDER BY ProductName')
    products = cursor.fetchall()
    conn.close()
    return render_template('master/product_master.html', products=products, product_groups=product_groups, doctor_names=doctor_names, combinations=combinations)

@product_master_bp.route('/productmaster/edit/<product_id>', methods=['GET', 'POST'])
def edit_product(product_id):
    if not product_id or not str(product_id).isdigit():
        flash('Invalid product ID for editing.', 'danger')
        return redirect(url_for('product_master_bp.product_master'))
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute('SELECT * FROM ProductMaster WHERE ProductID=?', (product_id,))
    product = cursor.fetchone()
    if not product:
        conn.close()
        flash('Product not found.', 'danger')
        return redirect(url_for('product_master_bp.product_master'))
    # Fetch product groups
    cursor.execute('SELECT GroupName FROM ProductGroupMaster ORDER BY GroupName')
    product_groups = [row.GroupName for row in cursor.fetchall()]
    # Fetch doctor names
    cursor.execute('SELECT DoctorName FROM DoctorNameMaster ORDER BY DoctorName')
    doctor_names = [row.DoctorName for row in cursor.fetchall()]
    # Fetch combinations (if you have a table, otherwise use a static list)
    cursor.execute('SELECT CombinationName FROM CombinationMaster ORDER BY CombinationName')
    combinations = [row.CombinationName for row in cursor.fetchall()]
    if request.method == 'POST':
        product_name = request.form['product_name']
        product_group = request.form['product_group']
        rack_no = request.form['rack_no']
        min_stock = request.form['min_stock']
        doctor_name = request.form['doctor_name']
        combination = request.form['combination']
        manufacturer = request.form['manufacturer']
        cursor.execute('''
            UPDATE ProductMaster SET ProductName=?, ProductGroup=?, RackNo=?, MinimumStockToMaintain=?, DoctorName=?, Combination=?, Manufacturer=? WHERE ProductID=?
        ''', (product_name, product_group, rack_no, min_stock, doctor_name, combination, manufacturer, product_id))
        conn.commit()
        conn.close()
        flash('Product updated!', 'success')
        return redirect(url_for('product_master_bp.product_master'))
    conn.close()
    return render_template('master/product_master.html', products=[], product=product, edit_mode=True, product_groups=product_groups, doctor_names=doctor_names, combinations=combinations)

@product_master_bp.route('/productmaster/delete/<product_id>', methods=['POST'])
def delete_product(product_id):
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute('DELETE FROM ProductMaster WHERE ProductID=?', (product_id,))
    conn.commit()
    conn.close()
    flash('Product deleted!', 'success')
    return redirect(url_for('product_master_bp.product_master'))
