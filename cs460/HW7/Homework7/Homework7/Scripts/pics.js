function clear() {
    $('#translator').empty();
}

function noenter() {
    return !(window.event && window.event.keyCode == 13);
}

function apiRequest(results) {
    var a = results.value;
    var source = "/API/Picture/" + a;
    console.log(source);

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData,
        error: errorOnAjax
    });
}

function displayData(data) {
     console.log(data);
    //$("#Message").text(data["message"]);
    //$("#Amount").text("Number of values requested " + data.num);
    //$("#Values").text(data.numbers);
    //var sum = data.numbers.reduce(function (a, b) { return a + b; });
    //var ave = sum / data.numbers.length;
    //$("#Average").text("Average of these values is " + ave);
}

function errorOnAjax() {
    console.log("error loading picture");
}

$('#translator').bind('keypress', function (e) {
    if (e.which === 32) {
        var input = document.getElementById('translator');
        $('#results').empty();
        $('#results').append("<p>" + input.value + "</p>");
        apiRequest(input);
        }
    }
);



    
    
    
    
    
    
    
    
    