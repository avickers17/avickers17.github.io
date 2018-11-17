$(document).ready(function () {

    //ajax call to my controller to get json db data to display list of bids
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
    //if ajax successful, append new data to page in a table of bids, remove old data first
    function getData(data) {
        $(".table td").remove();
        $(".table thead").remove();
        $(".table").append("<thead class='thead'><tr><th scope='col'>Bidder Name: </th><th scope='col'>Bid Amount: </th></tr></thead> ");
        for (var i = 0; i < data.length; i++) {
            $(".table").append("<tbody><tr><td scope='row'>" + data[i].Name + "</td><td>" + "$" + Number(data[i].Amount).toLocaleString('en') + "</td>");  
        }
    }
    //function is ajax call has an error, console displays error
    function errorOnAjax() {
        console.log("error loading bids");
    }
    
    var interval = 1000 * 5; // where X is timer interval in X seconds

    //function to refresh details page every 5 seconds with new bid info
    window.setInterval(ajax_call, interval);

    //function to load details page with new bid info when opened
    window.onload = ajax_call();
});