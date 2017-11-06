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
<ul>							<!--text, link-->
   	<li>@Html.ActionLink("Page 1 - GET", "Page1")</li>
	<li>@Html.ActionLink("Page 2 - POST", "Page2")</li>
	<li>@Html.ActionLink("Page 3 - Model Binding", "Page3")</li>
</ul>
```


### Step 2: Page 1 

* **Converting US Dollar into Mexican Peso Vis Versa (`GET` Method)**

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
> *Note: I used `ViewBag` to put calculated data*

In the *TheBank View()* I extracted the calculated data and displayed the result if data is not null or empty

```html
@*Check if USD value is not Null or Empty*@
@if (ViewBag.USD != "" && ViewBag.USD != null) {
	<div class="alert">
		<p>Hi human, Here is your US Dollar amount: <u>$@ViewBag.USD</u></p>
	</div>
}
```
*Note: `@ViewBag.USD` to view calculated data*

### Step 3: Page 2

Creating *Page 2*: Uses HTML `POST` to post form data into the server. This page you'll be able to find the volume of any box. First part in creating *Page 2* is having a controller action method that is parameterless (GET).

```cs
[HttpGet]
public ActionResult Page2()
{
	return View();
}
```

In *Page 2 View()*, `POST` form is in action.
```html
<form method="post">
	<div class="form-group">
		<h3>Calculate Volume of Boxes</h3>
		<p><b>Measures by inches</b> EX: <i>3" x 5" x 7"</i></p>
	</div>
	<div class="form-group">
		<div><!--Length Label/Input-->
			<label>Length: </label>
			<input type="number" max="100" min="1" step="1" value="1" name="Length"/>
		</div>
	<!--Code Omitted-->
```

Then have a one parameter POST the uses `FormCollection` as the parameter.

```cs
[HttpPost]
public ActionResult Page2(FormCollection form)
{
	//... code omitted
}
```
*Note: not using model binding*

To retrieve the user data from *form*, use `Request.Form["element"]`.

```cs
if (!(IsNUll(form)))
	{
		int Length = int.Parse(Request.Form["Length"]);
		int Width = int.Parse(Request.Form["Width"]);
		int Height = int.Parse(Request.Form["Height"]);
```

*IsNull* is a private method; checks if any values are null or empty.
```cs
private bool IsNUll(FormCollection form)
{
	//...         

	if (string.IsNullOrEmpty(L) || string.IsNullOrEmpty(W) || string.IsNullOrEmpty(H))
		{
			ViewBag.IsNull = "true";
			return true;
		}
		else
		{
			ViewBag.IsNull = "false";
			return false;
		}
}
```
*Note I added a `ViewBag.IsNull`*

I then added the calculated results into `ViewBag`.

```cs
//Volume = Length * Width * Height
int Volume = Length * Width * Height; 
ViewBag.Volume = Volume.ToString();
```

Going back to *Page 2 View()* I displayed the result.
```cshtml
@*Checks if user enter values*@
@if (IsPost){
	@*Checks values are Empty or Null*@
	if(@ViewBag.IsNull != "true"){
		<div class="form-group">
			@*Creates Table*@
			<table class="table">
			<!--Code Omitted-->
			@*Final Result*@
			<p><b>Box Volume:</b> @ViewBag.Volume"</p>
		</div>
```


### Step 4: Page 3

Creating *Page 3*: Use model binding. This page is a loan calculator where a user can know how mush they will be paying if they plan on getting a loan. We have a choice if we want to use Razor HTML Helpers and `GET` or `Post`.

I decided to go with `POST`:

```cs
[HttpGet]
public ActionResult Page3()
{
	return View();
}
```

A code snippet of *Page 3 View()*

```html
<div class="container">
	<div class="form-group">
		<form method="post"> <!--post method-->
			<div id="slideAmount">
				<!--Loan Slider-->
				<span><b>Loan Amount:</b>$</span>
				<output name="outAmount">2000</output>
				<input type="range" min="1000" max="10000" value="2000" name="amount" class="slider" oninput="outAmount.value = amount.value">
			</div>
	<!--Code Omitted-->
```

Calculate Loan using model binding

```cs
[HttpPost]
public ActionResult Page3(double? amount, double? rate, double? time)
	{
		//...

		double Rate = (double)((double)(rate / 100) / time); //Annual Rate

		//Discount Factor
		double Factor = (Math.Pow((1 + Rate), Time) - 1) / (Rate * (Math.Pow((1 + Rate), Time)));

		double MonPay = Amount / Factor; //Monthly Pay
		double IntPay = (MonPay * Time) - Amount; //Period Rate
		double Total = Amount + IntPay; //Total Cost

		//...
	}
```

Display Loan Calculations

```html
<div class="container">
	<!--Displays Results-->
	<p><b>Loan Amount:</b> $@ViewBag.Amount</p>
	<p><b>Periodic Interest Rate:</b> % @ViewBag.Rate</p>
	<p><b>Months to Pay:</b> @ViewBag.Time</p>
	<p><b>Monthly Payment:</b> $@ViewBag.MonPay</p>
	<p><b>Total Interest:</b> $@ViewBag.IntPay</p>
	<p><b><u>Total Cost:</u></b> $@ViewBag.Total</p>
</div>
```







