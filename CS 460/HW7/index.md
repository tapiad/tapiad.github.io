---
title: Daniel
layout: default
---

Quick links:

* Visit my GitHub [here](https://github.com/tapiad).

* Visit my [Portfolio](https://tapiad.github.io).

* Link to Homework 7 [assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7.html).


### Homework 7

As we move on to homework 7, we start to use JSON and AJAX. Again we will write a MVC web application. This web application employs AJAX to build responsive views. We are going to learn how to use an existing API to acquire data, serverside. Demonstrate the use of JSON, AJAX, and custom routing URLs.

### Step #1: ScreenShots

This is a screenshot of the *Search Giphy* web application page.
**Search Giphy**
![Alt text](https://github.com/tapiad/tapiad.github.io/blob/hw7-Giphy/CS%20460/HW7/ScreenShots/SearchGiphy.PNG?raw=true "Search Giphy")


This is what a user gets after searching for *'Lazy Cat'*.
**Lazy Cat**
![Alt text](https://github.com/tapiad/tapiad.github.io/blob/hw7-Giphy/CS%20460/HW7/ScreenShots/LazyCat.PNG?raw=true "Lazy Cat")

### Step #2: Keep API Key A Secret!

We are to put our Giphy API Key a Secret so that no one can abuse the key. To do this I added the key outside of the repository. The key can later be retrieved through *<appSettings>* in the *Web.config*. Here is a snippet:

```config
<appSettings file="..\..\..\..\..\TopSecrets\AppSettingsSecrets.config">
    <add ...
```

It will first back out of the repository(i.e. '..\'). Then go into the *TopSecrets* directory, and then into *AppSettingsSecrets.config*. This is where the Giphy API Key is located.

```config
<appSettings>
<add key="GiphyAPIKey" value="API...Key!">
</appSettings>
```
>Thought I was going to expose my API Key huh! Not Today!

This is how you retrieve the API Key in your controller:

```cs
//Get Top Secret APIKey
string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
``` 

> Well that was a baby step.

### Step #3: AJAX and JSON

Who is AJAX an JSON? I don't know. Never heard of them. Well it's time to meet them...

Dealing with API, I found out that using [Firefox Developers Edition](https://www.mozilla.org/en-US/firefox/developer/) is really nice. It parses the HSON and displays it in tree form with syntax highlighting! Also, [Postman](https://www.getpostman.com/). As it is an easy way to send customized GET and POST requests(i.e. set header fields) and analyze the responses.

Let us GET a request, using the API Key, and send it off to Giphy's servers.

First we will set up our *URL*. Here we will get the User's input, rating preference, and Language preference. This will be done in a `JsonResult` Object.

```cs
public JsonResult Search()
        {
			//Get Top Secret APIKey
			string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
			string q = Request.QueryString["q"]; //User's Input
			string rating = Request.QueryString["rating"]; //Rating prefrence
			string lang = Request.QueryString["lang"]; //Language

			//...
```

With all User's inputs we will assemble the *URL*.

```cs
 //URL to Giphy API
string url = "https://api.giphy.com/v1/gifs/search?q=" + q + "&api_key=" + key +
    "&limit=9&rating=" + rating + "&lang=" + lang;
```

We can now send the *URL* to Giphy's services to a *response* containing *JSON*. The *URL* will send out a request followed a *response*. We take the *response* to a *data stream*. Then take the *Stream* to convert it into a *string reader*.

```cs
//Sends request to Giphy to get JSon
WebRequest request = WebRequest.Create(url);            
WebResponse response = request.GetResponse(); //The Response            
Stream dataStream = response.GetResponseStream(); //Start Data Stream from Server.            
string reader = new StreamReader(dataStream).ReadToEnd(); //Data Stream to a reader string
```

Once we have our JSON string we will need to change it to a JSON Object. We will get a *Serializer* to *Deserialize* JSON string into a JSON Object. After that we clean up and close up and now we have our JSON Object.
```cs
	//JSon string to a JSon object             
    var serializer = new JavaScriptSerializer();            
    var data = serializer.DeserializeObject(reader); //Deserialize string into JSon Object

    //Clean/Close Up
    response.Close();
    dataStream.Close();
    
    return Json(data, JsonRequestBehavior.AllowGet);
}
``` 

We are to use a custom route when handling the AJAX request.
Here is my Custom Route:

```cs
routes.MapRoute(
    name: "Search",
    url: "Giphy/{action}",
    defaults: new { controller = "Giphy", action = "Search", page = UrlParameter.Optional }
);
```
This is jQuery's AJAX method:

```js
function start() {
    var q = $("#UserInput").val(); //Get User Input
    var rating = $("#rating").val(); //Rating
    var lang = $("#lang").val(); //Language
    var source = "Giphy/Search?q=" + q + "&rating=" + rating + "&lang=" + lang; //Source

    //Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displaySearch,
        error: errorOnAjax
    });
}
```

### Step #4: Add additional features

The Gif images will not display until the User submits a search.

```html
@* Display Gifs after Search Button Clicked.*@
<div id="results" style="display: none">
```
Displays in the JavaScript:

```js
$("#results").css("display", "grid"); //Enable Display 
```


For each Gif image I made sure each one had a image type `img-thumbnail`. With the image has its Gif's title for that particular image. The image and their title are perfectly centered. 

```html
<div class="col-sm-4 gif-col">
    @*Gif Image*@
    <img id="G-1" src="" class="center-block img-thumbnail" />
    @*Gif Title*@
    <p id="GT-1"></p>
</div>
```


Later gets their values

```js
var gif = "#G-" + (i + 1); //Gifs
var title = "#GT-" + (i + 1); //Titles
if (data.data[i]) {
    if (animate == "yes") { //Animated
        $(gif).attr('src', data.data[i].images.fixed_width.url);
        $(title).text(data.data[i].title);
    }
//...
```
>Note: If User chooses *Animated*


User can choose *Animated* or *Still*

```html
 @*Animated or Still*@
<label class="radio-inline">
    <input type="radio" name="animated" value="yes" checked="checked">Animated
</label>
<label class="radio-inline">
    <input type="radio" name="animated" value="no">Still
</label>
```


Retrieves the *animated* through JavaScript:

```js
var animate = $("input[name=animated]:checked").val(); //Animated or Still
```


The user is allowed to choose their rating preferences.

```html
@*Rating*@
<label for="rating">Rating</label>
<select id="rating">
    <option value="g">G</option>
    <option value="pg">PG</option>
    <option value="pg-13">PG-13</option>
</select>
``` 


They can choose a preferred language.

```html
@*Language*@
<label for="lang">Language</label>
<select id="lang">
    <option selected="selected" value="en">English</option>
    <option value="es">Spanish</option>
    <option value="pt">Portugues</option>
    @*...*@
```

 
 Listeners for when the *'Search'* Button is clicked or if the User hits the *'Enter'* key.

```js
$("#UserInput").keypress(function (e) {
    //If 'Enter' Key Pressed
    if (e.keyCode == 13) {
        start();
        e.preventDefault;
    }
});

//When "Search" button clicked
$("#Search").click(start);
```
