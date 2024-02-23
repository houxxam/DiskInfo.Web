// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
   
    
    

    new DataTable('#dataTable',{
        dom: 'lBfrtip',
        // Configure the drop down options.
        lengthMenu: [
            [10, 25, 50, -1],
            ['10 rows', '25 rows', '150 rows', 'Show all']
        ],
        buttons: [
            'excel', 'print', 'colvis'
        ],
        order: [[7, 'desc']]
    });
});