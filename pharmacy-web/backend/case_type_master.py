from flask import Blueprint, render_template, request, redirect, url_for, flash, session
from db import get_db_connection

case_type_master_bp = Blueprint('case_type_master_bp', __name__)

@case_type_master_bp.route('/casetypemaster', methods=['GET', 'POST'])
def case_type_master():
    conn = get_db_connection()
    cursor = conn.cursor()
    edit_name = request.args.get('edit')
    case_to_edit = None
    if edit_name:
        cursor.execute('SELECT * FROM CaseTypeMaster WHERE CaseName=?', (edit_name,))
        case_to_edit = cursor.fetchone()

    if request.method == 'POST':
        action = request.form.get('action')
        case_name = request.form.get('case_name', '').strip()
        case_name_old = request.form.get('case_name_old')
        if not case_name:
            flash('Case name cannot be empty.', 'danger')
            return redirect(url_for('case_type_master_bp.case_type_master'))
        cursor.execute('SELECT CaseName FROM CaseTypeMaster WHERE CaseName=?', (case_name,))
        duplicate = cursor.fetchone()
        if action == 'add':
            if duplicate:
                flash('Case name already exists.', 'danger')
            else:
                cursor.execute('INSERT INTO CaseTypeMaster (CaseName) VALUES (?)', (case_name,))
                conn.commit()
                flash('Case type added successfully!', 'success')
            return redirect(url_for('case_type_master_bp.case_type_master'))
        elif action == 'edit' and case_name_old:
            if duplicate and case_name != case_name_old:
                flash('Case name already exists.', 'danger')
            else:
                cursor.execute('UPDATE CaseTypeMaster SET CaseName=? WHERE CaseName=?', (case_name, case_name_old))
                conn.commit()
                flash('Case type updated!', 'success')
            return redirect(url_for('case_type_master_bp.case_type_master'))
        elif action == 'delete' and case_name_old:
            cursor.execute('DELETE FROM CaseTypeMaster WHERE CaseName=?', (case_name_old,))
            conn.commit()
            flash('Case type deleted!', 'success')
            return redirect(url_for('case_type_master_bp.case_type_master'))
    cursor.execute('SELECT * FROM CaseTypeMaster ORDER BY CaseName')
    cases = cursor.fetchall()
    conn.close()
    return render_template('master/case_type_master.html', cases=cases, case_to_edit=case_to_edit)
