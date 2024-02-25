// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
   

    // Data Table
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

   let hddCount, ssdCount;

    function fetchData() {
       
        Promise.all([
            fetch('/api/disks/hddCount').then(response => response.json()),
            fetch('/api/disks/ssdCount').then(response => response.json())
        ]).then(([hddCount, ssdCount]) => {
            hddCount = hddCount;
            ssdCount = ssdCount;
           
        }).catch(error => {
            console.error('Error fetching data:', error);
            // Handle error
        });
    }
    
    // chart 
    let _hddCount, _ssdCount; // Declare variables at the global scope

    function fetchData() {
        Promise.all([
            fetch('/api/disks/hddCount').then(response => response.json()),
            fetch('/api/disks/ssdCount').then(response => response.json())
        ]).then(([hddCount, ssdCount]) => {
            // Assign the fetched counts to global variables
            _hddCount = hddCount;
            _ssdCount = ssdCount;

            // Log the fetched counts
            console.log('HDD Count:', hddCount);
            console.log('SSD Count:', ssdCount);

            // Call the function to draw the chart
            drawChart();
        }).catch(error => {
            console.error('Error fetching data:', error);
            // Handle error
        });
    }
    function drawChart() {
        // Create the data table.
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Topping');
        data.addColumn('number', 'Slices');
        data.addRows([
            ['HDD', _hddCount],
            ['SSD', _ssdCount]
        ]);

        // Set chart options
        var options = {
            'title': 'Disk Counts',
            
        };

        // Instantiate and draw our chart, passing in some options.
        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }

    // Load the Visualization API and the corechart package.
    google.charts.load('current', { 'packages': ['corechart'] });

    // Set a callback to run when the Google Visualization API is loaded.
    google.charts.setOnLoadCallback(fetchData);




});