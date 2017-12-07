
//If User Clicks
function genreClicked(genre) {
    //URL Display
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
    //Where result is Displayed
    var item = document.getElementById("resultsBody");
    //For each data
    jQuery.each(data, function (i, val){
        if (i == 0)
        {   //Adds 'Title' & 'Artist' to Table
            item.innerHTML = '<tr><td>' + val["Title"] + '</td><td>' + val["Artist"] + '</td></tr>';
        }
        else
        {
            item.innerHTML += '<tr><td>' + val["Title"] + '</td><td>' + val["Artist"] + '</td></tr>';
        }
    });
    $("#results").css("display", "block"); //Makes Table Visible
}

function error(){
    console.log("Error!");
}