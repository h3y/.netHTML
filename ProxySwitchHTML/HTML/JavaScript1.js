var table = $('#dataTable').DataTable({
    "searching": true,
    "bPaginate": true,
    "bLengthChange": false,
    "iDisplayLength": 10,
    "bProcessing": true,
    "paging": true,
    //"sScrollY": "600px",
    //"bPaginate": false,
    //bInfo": false,
    ///"/"processing": true,
    //"ordering": true,
    //"paging": true,
    //"lengthChange": true,
    //"info": true,
    //"autoWidth": false,
    data: jQuery.parseJSON(winformObj.getProxyModel),
    columns: [
        {
            data: 'status', title: 'status', "render": function (data, type, full, meta) {
                switch (data) {
                    case 0: return '<i class="material-icons material-icons-customColorRed ">help_outline</i>';
                    case 1: return '<i class="material-icons">done</i>';
                    case 2: return '<i class="material-icons">highlight_off</i>';
                    case 3: return '<i class="material-icons">cached</i>';
                }
            }
        },
        { data: 'proxy', title: 'proxy', 'type': 'ip-address'},
        { data: 'ip', title: 'ip', 'type': 'ip-address'},
        { data: 'country', title: 'country'},
        { data: 'city', title: 'city'},
        {
            data: 'speed', title: 'speed', 'type': 'natural',  "render": function (data, type, full, meta) {
                return data + ' Kbs';
            }
        },
        {
            data: 'uptime', title: 'uptime', "type": "natural", "render": function (data, type, full, meta) {
                return data + ' min.';
            }
        }
    ],
    columnDefs: [
    {
        className: 'mdl-data-table__cell--non-numeric',
        targets: "_all"
    }
    ]
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