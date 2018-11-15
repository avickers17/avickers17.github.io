$(document).ready(function () {

    var ajax_call = function () {

        var input = document.getElementById('ident');
        var id = input.value;
        var source = "/Bids/List/" + id;
        console.log(id)
        console.log(source)
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
        console.log(data);
        data[0].Name
        
        
    }

    function appendInfo() {
        //var view = "";
        $
        $(".table").append("<tbody><tr><td scope='row'>" + "stuff" + "</td><td>Stuff</td>");
    }

    function errorOnAjax() {
        console.log("error loading bids");
    }

    var interval = 1000 * 5; // where X is your timer interval in X seconds

    window.setInterval(ajax_call, interval);

});