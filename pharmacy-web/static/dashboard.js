// Dashboard JS: handles modals and localStorage for date filters
window.addEventListener('DOMContentLoaded', function() {
    const fromDateInput = document.getElementById('from_date');
    const toDateInput = document.getElementById('to_date');
    if(localStorage.getItem('dashboard_from_date')) {
        fromDateInput.value = localStorage.getItem('dashboard_from_date');
    }
    if(localStorage.getItem('dashboard_to_date')) {
        toDateInput.value = localStorage.getItem('dashboard_to_date');
    }
    const dashboardForm = fromDateInput.form;
    dashboardForm.addEventListener('submit', function() {
        localStorage.setItem('dashboard_from_date', fromDateInput.value);
        localStorage.setItem('dashboard_to_date', toDateInput.value);
    });
});
function showLoading() {
    document.getElementById('loadingSpinner').style.display = 'flex';
}
