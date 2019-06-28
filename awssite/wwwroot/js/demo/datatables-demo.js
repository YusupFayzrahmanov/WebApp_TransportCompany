// Call the dataTables jQuery plugin
$(document).ready(function() {
    var dataTable = $('#dataTable').DataTable();
    $('#dataTable tbody').on('click', '.btn-danger', function () {
        setTimeout(function () {
            dataTable.row($(this).parents('tr')).remove().draw();
        }, 2000);
        
    });
});
