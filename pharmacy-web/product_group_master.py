
from flask import Blueprint, render_template, request, redirect, url_for, flash
from db import get_db_connection

product_group_master_bp = Blueprint('product_group_master_bp', __name__)

@product_group_master_bp.route('/productgroupmaster', methods=['GET', 'POST'])
def product_group_master():
    conn = get_db_connection()
    cursor = conn.cursor()
    edit_id = request.args.get('edit')
    group_to_edit = None
    if edit_id and str(edit_id).isdigit():
        cursor.execute('SELECT * FROM ProductGroupMaster WHERE id=?', (edit_id,))
        group_to_edit = cursor.fetchone()

    if request.method == 'POST':
        action = request.form.get('action')
        group_name = request.form.get('group_name')
        group_id = request.form.get('group_id')
        if action == 'add':
            cursor.execute('INSERT INTO ProductGroupMaster (GroupName) VALUES (?)', (group_name,))
            conn.commit()
            flash('Product group added successfully!', 'success')
        elif action == 'edit' and group_id and str(group_id).isdigit():
            cursor.execute('UPDATE ProductGroupMaster SET GroupName=? WHERE id=?', (group_name, group_id))
            conn.commit()
            flash('Product group updated!', 'success')
        elif action == 'delete' and group_id and str(group_id).isdigit():
            cursor.execute('DELETE FROM ProductGroupMaster WHERE id=?', (group_id,))
            conn.commit()
            flash('Product group deleted!', 'success')
        return redirect(url_for('product_group_master_bp.product_group_master'))

    cursor.execute('SELECT * FROM ProductGroupMaster ORDER BY GroupName')
    groups = cursor.fetchall()
    conn.close()
    return render_template('master/product_group_master.html', groups=groups, group_to_edit=group_to_edit)
