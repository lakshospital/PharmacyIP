from flask import Blueprint, render_template, request, redirect, url_for, flash
from db import get_db_connection

dr_name_master_bp = Blueprint('dr_name_master_bp', __name__)

@dr_name_master_bp.route('/drnamemaster', methods=['GET', 'POST'])
def dr_name_master():
    conn = get_db_connection()
    cursor = conn.cursor()
    edit_name = request.args.get('edit')
    dr_to_edit = None
    if edit_name:
        cursor.execute('SELECT * FROM DoctorNameMaster WHERE DoctorName=?', (edit_name,))
        dr_to_edit = cursor.fetchone()

    if request.method == 'POST':
        action = request.form.get('action')
        dr_name = request.form.get('dr_name', '').strip()
        dr_name_old = request.form.get('dr_name_old')
        if not dr_name:
            flash('Doctor name cannot be empty.', 'danger')
            return redirect(url_for('dr_name_master_bp.dr_name_master'))
        cursor.execute('SELECT DoctorName FROM DoctorNameMaster WHERE DoctorName=?', (dr_name,))
        duplicate = cursor.fetchone()
        if action == 'add':
            if duplicate:
                flash('Doctor name already exists.', 'danger')
            else:
                cursor.execute('INSERT INTO DoctorNameMaster (DoctorName) VALUES (?)', (dr_name,))
                conn.commit()
                flash('Doctor added successfully!', 'success')
            return redirect(url_for('dr_name_master_bp.dr_name_master'))
        elif action == 'edit' and dr_name_old:
            if duplicate and dr_name != dr_name_old:
                flash('Doctor name already exists.', 'danger')
            else:
                cursor.execute('UPDATE DoctorNameMaster SET DoctorName=? WHERE DoctorName=?', (dr_name, dr_name_old))
                conn.commit()
                flash('Doctor updated!', 'success')
            return redirect(url_for('dr_name_master_bp.dr_name_master'))
        elif action == 'delete' and dr_name_old:
            cursor.execute('DELETE FROM DoctorNameMaster WHERE DoctorName=?', (dr_name_old,))
            conn.commit()
            flash('Doctor deleted!', 'success')
            return redirect(url_for('dr_name_master_bp.dr_name_master'))

    cursor.execute('SELECT * FROM DoctorNameMaster ORDER BY DoctorName')
    doctors = cursor.fetchall()
    conn.close()
    return render_template('master/dr_name_master.html', doctors=doctors, dr_to_edit=dr_to_edit)
