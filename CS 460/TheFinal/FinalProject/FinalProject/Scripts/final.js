﻿

function aClicked(genre) {
   
    var source = "/Home/GenreDetails/" + genre;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        error: error
    });
}

function displayResults(data) {
    //console.log("AJAX Success!");
    //console.log(data);

    //iterate through the json obj with jQuery
    //inspired by: https://stackoverflow.com/questions/1078118/how-do-i-iterate-over-a-json-structure
    var item = document.getElementById("resultsBody");
    jQuery.each(data, function (i, val) {
        //console.log(val["Title"]);
        //console.log(val["Artist"]);
        if (i == 0) {
            item.innerHTML = '<tr><td>' + val["Title"] + '</td><td>' + val["Artist"] + '</td></tr>';
        }
        else {
            item.innerHTML += '<tr><td>' + val["Title"] + '</td><td>' + val["Artist"] + '</td></tr>';
        }
    });
    $("#results").css("display", "block");
}

function error() {
    console.log("Error!");
}