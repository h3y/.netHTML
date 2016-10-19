var table;
$(document).ready(function () {
     table = $('#dataTable').DataTable({
        //"bProcessing": true,
        //"sScrollY": "600px",
        //"bPaginate": false,
        //"searching": false,
        //"bInfo": false,
        //"bPaginate": false,
        //"bLengthChange": false,
        //"iDisplayLength": 10,
        //"bProcessing": true,
        //"paging": true,
        //"sScrollY": "600px",
        //"bPaginate": false,
        //bInfo": false,
        ///"/"processing": true,
        //"ordering": true,
        //"paging": false,
        //"lengthChange": true,
        //"info": true,
        //"autoWidth": false,
        data: jQuery.parseJSON(winformObj.getProxyModel),
        columns: [
            {
                data: 'status', title: 'status', "width": "40px", "render": function (data, type, full, meta) {
                    switch (data) {
                        case 0: return '<i class="material-icons material-icons-customColorRed">help_outline</i>';
                        case 1: return '<i class="material-icons material-icons-customColorRed">cached</i>';
                        case 2: return '<i class="material-icons material-icons-customColorRed">highlight_off</i>';
                        case 3: return '<i class="material-icons material-icons-customColorRed">done</i>'; 
                    }
                }
            },
            { data: 'proxy', title: 'proxy', "width": "200px",'type': 'ip-address' },
            { data: 'ip', title: 'ip',"width": "200px", 'type': 'ip-address' },
            { data: 'country', title: 'country', "width": "100px" },
            { data: 'city', title: 'city', "width": "100px" },
            {
                data: 'speed', title: 'speed', 'type': 'natural',"width": "100px",  "render": function (data, type, full, meta) {
                    return data + ' Kbs';
                }
            },
            {
                data: 'uptime', title: 'uptime', "type": "natural","width": "100px", "render": function (data, type, full, meta) {
                    return data + ' min.';
                }
            }
        ],
        "bAutoWidth": false,
        columnDefs: [
        //{
        //    className: 'mdl-data-table__cell--non-numeric',
        //    targets: "_all"
        //},
        {
            "targets": [0],
           
        },
        {
            "targets": [1, 2],
            "width": "200px"
        },
        {
            "targets": [3, 4],
            "width": "100px"
        }
        ,
        {
            "targets": [5, 6],
            "width": "100px"
        }
        ]
    });
});
function ChangeColumn(ind,value) {
    var data = table.cell(ind, 0).data(value);
}
$('#example tbody').on('click', 'td', function () {
    var cell = table.cell(this);
    cell.data(cell.data() + 1).draw();
    // note - call draw() to update the table's draw state with the new data
});
var data = $('#example tbody').on('dblclick', '.even', function () {
    var data = table.row($(this)).data();
    return data;
});

$('#example tbody').on('dblclick', '.odd', function () {
    var data = table.row($(this)).data();
    $("#test").append("1212");
    var result = winformObj.GetProxyModel();
    $("#test").append(result);
});