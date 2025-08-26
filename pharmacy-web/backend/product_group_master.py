from flask import Blueprint, render_template, request, redirect, url_for, flash
from db import get_db_connection

product_group_master_bp = Blueprint('product_group_master_bp', __name__)

@product_group_master_bp.route('/productgroupmaster', methods=['GET', 'POST'])
def product_group_master():
    conn = get_db_connection()
    cursor = conn.cursor()
    edit_name = request.args.get('edit')
    group_to_edit = None
    if edit_name:
        cursor.execute('SELECT * FROM ProductGroupMaster WHERE GroupName=?', (edit_name,))
        group_to_edit = cursor.fetchone()

    if request.method == 'POST':
        action = request.form.get('action')
        group_name = request.form.get('group_name', '').strip()
        group_name_old = request.form.get('group_name_old')
        if not group_name:
            flash('Group name cannot be empty.', 'danger')
            return redirect(url_for('product_group_master_bp.product_group_master'))
        # Check for duplicate group name
        cursor.execute('SELECT GroupName FROM ProductGroupMaster WHERE GroupName=?', (group_name,))
        duplicate = cursor.fetchone()
        if action == 'add':
            if duplicate:
                flash('Group name already exists.', 'danger')
            else:
                cursor.execute('INSERT INTO ProductGroupMaster (GroupName) VALUES (?)', (group_name,))
                conn.commit()
                flash('Product group added successfully!', 'success')
            return redirect(url_for('product_group_master_bp.product_group_master'))
        elif action == 'edit' and group_name_old:
            if duplicate and group_name != group_name_old:
                flash('Group name already exists.', 'danger')
            else:
                cursor.execute('UPDATE ProductGroupMaster SET GroupName=? WHERE GroupName=?', (group_name, group_name_old))
                conn.commit()
                flash('Product group updated!', 'success')
            return redirect(url_for('product_group_master_bp.product_group_master'))
        elif action == 'delete' and group_name_old:
            cursor.execute('DELETE FROM ProductGroupMaster WHERE GroupName=?', (group_name_old,))
            conn.commit()
            flash('Product group deleted!', 'success')
            return redirect(url_for('product_group_master_bp.product_group_master'))

    cursor.execute('SELECT * FROM ProductGroupMaster ORDER BY GroupName')
    groups = cursor.fetchall()
    conn.close()
    return render_template('master/product_group_master.html', groups=groups, group_to_edit=group_to_edit)
