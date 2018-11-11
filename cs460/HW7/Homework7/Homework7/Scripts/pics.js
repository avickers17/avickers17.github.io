//function to clear the text field and screen
function clear() {
    $('#translator').empty();
}

//function that prevents the user from using the form field for a new GET request
function noenter() {
    return !(window.event && window.event.keyCode == 13);
}

//API function call, sends request to APIController
function apiRequest(c) {
    //create a source API path to my controller and include last word as url parameter
    var source = "/Search/Picture/" + c;

    //This makes the get request to my controller
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData,
        error: errorOnAjax
    });
}

//If Get Request is successful, get the json data and get the url out of it
function displayData(data) {
    //From the returned json data, get the url of the picture we wanted
    var image = data.data.images.original.url;

    //Append picture to the page using the url provided
    $('#results').append("<img src='" + image + "'/></div>");
    }

//If ajax call has an error, return an error to the console
function errorOnAjax() {
    console.log("error loading picture");
}

//Initial Function that starts Java once spacebar is pressed
$('#translator').bind('keypress', function (e) {
    if (e.which === 32) {
        var input = document.getElementById('translator');

        //Get the last value of what the user typed
        var a = input.value;
        var b = a.split(" ");
        var c = b[b.length - 1];
        var bool = true;

        //list of words not to be turned into pics
        var boringWords = ["and", "if", "or", "to", "I'm", "not", "for", "do", "my", "going", "be", "in", "but", "the", "at"];

        //Compare the last word entry to the list of boring words
        for (var i = 0; i < boringWords.length; i++) {
            if (boringWords[i].toUpperCase() === c.toUpperCase()) {
                bool = false;
            }
        }

        //If word was in list append word, if not call function for ajax GET Request
        if (bool == false) {
            $('#results').append("<label>" + c + "&nbsp;</label></div>");
        }
        else {
            //call api function and submit the text field value
            apiRequest(c);
        }
    }
});



    
    
    
    
    
    
    
    
    