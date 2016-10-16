
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
    data: toJsonRequest(),
    columns: [
            { data: 'status'},
            { data: 'proxy' },
            { data: 'ip' },
            { data: 'country' },
            { data: 'city' },
            { data: 'speed' },
            { data: 'uptime' }
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

function toJsonRequest() {
    alert(winformObj.getProxyModel);
    var txt = winformObj.getProxyModel;
    txt.substring(0, txt.length - 1);
    txt.substr(1);
    alert(txt);
    return txt;
    }

    
