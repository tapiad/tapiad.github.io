//console.log("In giphySearch.js File:");

$("#UserInput").keypress(function (e) {
    //If 'Enter' Key Pressed
    if (e.keyCode == 13) {
        start();
        e.preventDefault;
    }
});

//When "Search" button clicked
$("#Search").click(start);

function start() {
    var q = $("#UserInput").val(); //Get User Input
    var rating = $("#rating").val(); //Rating
    var lang = $("#lang").val(); //Language
    //console.log("The user entered: " + q);
    var source = "Giphy/Search?q=" + q + "&rating=" + rating + "&lang=" + lang; //Source
    //console.log("Source: " + source);

    //Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displaySearch,
        error: errorOnAjax
    });
}


function displaySearch(data) {
    $("#results").css("display", "grid"); //Enable Display 
    //console.log("data rating: " + data.data[0].rating);
    //console.log("data title: " + data.data[0].title);
    //console.log("data.data[0].images.fixed_width.url: " + data.data[0].images.fixed_width.url);
    //console.log("data.pagination.total_count: " + data.pagination.total_count);
    var animate = $("input[name=animated]:checked").val(); //Animated or Still
    //$("#G-1").attr('src', data.data[0].images.fixed_width.url);
    //$("#GT-1").text("Title: " + data.data[0].title);


    if (data.pagination.total_count > 0)
    {
        for (i = 0; i < 9; i++) {
            var gif = "#G-" + (i + 1); //Gifs
            var title = "#GT-" + (i + 1); //Titles
            if (data.data[i]) {
                if (animate == "yes") { //Animated
                    $(gif).attr('src', data.data[i].images.fixed_width.url);
                    $(title).text(data.data[i].title);
                }
                else if (animate == "no") { //Still
                    $(gif).attr('src', data.data[i].images.fixed_width_still.url);
                    $(title).text(data.data[i].title);
                }
            }
        }
    }
    else { //Gif Not found
        for (i = 0; i < 9; i++) {
            var gif = "#G-" + (i + 1);
            var title = "#GT-" + (i + 1);
            $(gif).attr('src', "https://media2.giphy.com/media/YyKPbc5OOTSQE/200w.gif");
            $(title).text("Gif Not Found!");
        }
    }
}


function errorOnAjax() {
    console.log("error");
}