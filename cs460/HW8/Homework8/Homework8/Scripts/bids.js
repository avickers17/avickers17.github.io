$(document).ready(function () {

    var ajax_call = function () {
        var input = document.getElementById('ident');
        var id = input.value;
        var source = "/Bids/List/" + id;
        console.log(id);
        $.ajax({
            type: "GET",
            dataType: "json",
            data: { "id": id },
            url: source,
            success: getData,
            error: errorOnAjax
        });
    }

    function getData(data) {
        $(".table tr").remove();
        for (var i = 0; i < data.length; i++) {
            $(".table").append("<tbody><tr><td scope='row'>" + data[i].Name + "</td><td>" + "$" + Number(data[i].Amount).toLocaleString('en') + "</td>");  
        }
    }

    function errorOnAjax() {
        console.log("error loading bids");
    }

    var interval = 1000 * 5; // where X is your timer interval in X seconds

    window.setInterval(ajax_call, interval);
    window.onload = ajax_call();
});