---
title: Daniel
layout: default
---

Quick links:

* Visit my GitHub [here](https://github.com/tapiad).

* Visit my [Portfolio](https://tapiad.github.io).

* Link to Homework 4 [assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4.html).


### Homework 4

We are going to be learning about ASP.NET MVC 5 in our Homework 4. We are going to write a simple MVC web application. We are going to make use of `ViewBag` or `ViewData`. Demonstrate use of the `Request` object. We are also going to understand the difference of `GET` and `POST` and how we can get information out of the user. 


### Step 1: Home

We create a new empty MVC project. It will have Visual Studio's `.gitignore` file. Make a feature branch for out homework 4. Then merge when finished. Our `Home` default page contains links to other pages I'll be creating for this assignment. I used Razor `@Html.ActionLink` to create the links.

```html
<ul>      						<!--text, link-->
   	<li>@Html.ActionLink("Page 1 - GET", "Page1")</li>
	<li>@Html.ActionLink("Page 2 - POST", "Page2")</li>
	<li>@Html.ActionLink("Page 3 - Model Binding", "Page3")</li>
</ul>
```


### Step 2: Page 1 



Creating *Page 1*: using method `GET` that contains user's input to controller. This page you will be able to convert your US Dollar into Mexican Peso; vis versa. In *Page 1 View()*, I wrote a simple HTML form to send data to the server as query strings after user clicks on *Submit* button. 

```html
<form action="/Home/TheBank" method="get"><!--submit click: TheBank/get method-->
    <div class="form-group">
     	<label for="USD">US Dollar</label><!--US Dollar Label-->
     	<div class="input-group">
       		<span class="input-group-addon">$</span>
 			<input name="USD" type="number" value="1" step="1" max="1000" min="1">
			<button type="submit"  class="btn btn-success">Submit</button>
      	</div>
    </div>
</form>
```

After *Submit* button has been clicked, data will be extracted within the *TheBank* controller by using the `Request` object.

```cs
string USD = Request.QueryString["USD"];
string MP = Request.QueryString["MP"];
```

Once I retrieved the data I can do calculations to convert US Dollars into Mexican Peso.

```cs
if (!string.IsNullOrEmpty(USD))
	{
	   	int US = int.Parse(USD);
	   	//US to MP is around 19.26 a Dollar as of November 2017
	   	ViewBag.MP = Math.Round((US * 19.264299), 2).ToString();
	   	return View();
	}
```

### Step 3:









