// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    new DataTable('#dataTable',{
        dom: 'Blfrtip',
        pagingType: 'full_numbers',
        buttons: ['copyHtml5', 'excelHtml5', 'csvHtml5', 'pdfHtml5'],
        lengthMenu: [[25, 50, 100, -1], [25, 50, 100, 'All']],
        pageLength: 25 // Set default page length
    });
});