from flask import Blueprint, render_template, request, redirect, url_for, flash, session
from db import get_db_connection

supplier_master_bp = Blueprint('supplier_master_bp', __name__)

@supplier_master_bp.route('/suppliermaster', methods=['GET', 'POST'])
def supplier_master():
    conn = get_db_connection()
    cursor = conn.cursor()
    edit_id = request.args.get('edit')
    supplier_to_edit = None
    if edit_id:
        cursor.execute('SELECT * FROM SupplierMaster WHERE SupplierID=?', (edit_id,))
        supplier_to_edit = cursor.fetchone()

    if request.method == 'POST':
        if session.get('role') != 'admin':
            flash('Only admin can perform this action.', 'danger')
            return redirect(url_for('supplier_master_bp.supplier_master'))
        action = request.form.get('action')
        supplier_id = request.form.get('supplier_id')
        supplier_name = request.form.get('supplier_name', '').strip()
        street1 = request.form.get('street1', '').strip()
        street2 = request.form.get('street2', '').strip()
        city = request.form.get('city', '').strip()
        pincode = request.form.get('pincode', '').strip()
        email = request.form.get('email', '').strip()
        phone = request.form.get('phone', '').strip()
        tinno = request.form.get('tinno', '').strip()
        if not supplier_name:
            flash('Supplier name cannot be empty.', 'danger')
            return redirect(url_for('supplier_master_bp.supplier_master'))
        if action == 'add':
            cursor.execute('SELECT SupplierName FROM SupplierMaster WHERE SupplierName=?', (supplier_name,))
            duplicate = cursor.fetchone()
            if duplicate:
                flash('Supplier name already exists.', 'danger')
            else:
                cursor.execute('''INSERT INTO SupplierMaster (SupplierName, Street1, Street2, City, PINCode, eMail, Phone, TINNo) VALUES (?, ?, ?, ?, ?, ?, ?, ?)''',
                    (supplier_name, street1, street2, city, pincode, email, phone, tinno))
                conn.commit()
                flash('Supplier added successfully!', 'success')
            return redirect(url_for('supplier_master_bp.supplier_master'))
        elif action == 'edit' and supplier_id:
            cursor.execute('UPDATE SupplierMaster SET SupplierName=?, Street1=?, Street2=?, City=?, PINCode=?, eMail=?, Phone=?, TINNo=? WHERE SupplierID=?',
                (supplier_name, street1, street2, city, pincode, email, phone, tinno, supplier_id))
            conn.commit()
            flash('Supplier updated!', 'success')
            return redirect(url_for('supplier_master_bp.supplier_master'))
        elif action == 'delete' and supplier_id:
            cursor.execute('DELETE FROM SupplierMaster WHERE SupplierID=?', (supplier_id,))
            conn.commit()
            flash('Supplier deleted!', 'success')
            return redirect(url_for('supplier_master_bp.supplier_master'))
    cursor.execute('SELECT * FROM SupplierMaster ORDER BY SupplierName')
    suppliers = cursor.fetchall()
    conn.close()
    return render_template('master/supplier_master.html', suppliers=suppliers, supplier_to_edit=supplier_to_edit)
