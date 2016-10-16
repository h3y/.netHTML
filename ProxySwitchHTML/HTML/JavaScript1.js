
var table = $('#dataTable').DataTable({
    //"searching": false,
    //"bLengthChange": false,
    //"bProcessing": true,
    //"sScrollY": "600px",
    //"bPaginate": false,
    //"bInfo": false,
    //"processing": true,
    //"ordering": true,
    //"paging": true,
    //"lengthChange": true,
    //"info": true,
    //"autoWidth": false,
    data: jQuery.parseJSON(winformObj.getProxyModel),
    columns: [
            {
                data: 'status', title: 'status', "render": function (data, type, full, meta) {
                    return data + ' kbs';
                }
            },
            { data: 'proxy', title: 'proxy' },
            { data: 'ip', title: 'ip' },
            { data: 'country', title: 'country' },
            { data: 'city', title: 'city' },
            { data: 'speed', title: 'speed' },
            { data: 'uptime', title: 'uptime' }
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