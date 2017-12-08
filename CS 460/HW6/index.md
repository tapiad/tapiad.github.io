---
title: Daniel
layout: default
---

Quick links:

* Visit my GitHub [here](https://github.com/tapiad).

* Visit my [Portfolio](https://tapiad.github.io).

* Link to Homework 6 [assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW6.html).


### Demo Video:

[Video](https://www.youtube.com/watch?v=1NoL2G5nNuk&feature=youtu.be)

### Homework 6

Primary Objectives are to write a MVC web application that uses portions of a large, complex pre-existing database. Be able to derive C# models from an existing database using Entity Framework and “Code First with an Existing Database” workflow. Be able to write LINQ queries using fluent syntax. Learn to use C# language features: partial classes. Use more Razor language features to build feature-laden views.

### Step 1: Connect to AdventureWorks 2014

I had to extract [AdventureWorks 2014](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks) database to connect to my Visual Studio. I first downloaded Microsoft SQL Server Management Studio 17. Had the server connect with AdventureWorks2014.bak file. Then connected the server with Visual Studio were I got to retrieve the database table for *Products*. Model tables were created on the web application.

### Step 2: Entity Framework Code First

Reverse Engineer Model will help us map to the database and get our tables

* **Project -> Add New Item…**

* Select **Data** from the left menu and then **ADO.NET Entity Data Model**

* Enter **Context** as the name and click **OK**

* This launches the **Entity Data Model Wizard**

* Select **Code First from Database** and click **Next**

* Select the connection to the database you created in the first section and click **Next**

* Click the checkbox next to **Tables** to import all tables and click **Finish**

Check out [*Entity Framework Code First to an Existing Database*](https://msdn.microsoft.com/en-us/library/jj200620(v=vs.113)) for more information.

### Step #3: Browse Products

For a user to view a product they will need to first choose a *Category* and then a *SubCategory*.
This will get the product's categories from the database and return to the *Home* view: 

```cs
private AWContext db = new AWContext();

// GET: Home
public ActionResult Index()
{
    return View(db.ProductCategories.ToList());
}
```

The user will then have to click on *Category* located on the NavBar on top of the home page. Then a drop down will appear and the user will have to option to choose between *Bikes*, *Components*, *Clothing*, or *Accessories*. 

```html
<ul class="dropdown-menu">
    <li><a>@Html.ActionLink("Bikes", "Bikes", "SubCategory")</a></li>
    <li><a>@Html.ActionLink("Components", "Components", "SubCategory")</a></li>
    <li><a>@Html.ActionLink("Clothing", "Clothing", "SubCategory")</a></li>
    <li><a>@Html.ActionLink("Accessories", "Accessories", "SubCategory")</a></li>
</ul>
```

After a click on a category, it will take them to a page where the *SubCategorys* are displayed in buttons. This using form GET to a POST. 

```cs
// GET: SubCategory/Bikes
public ActionResult Bikes()
{
    //List of Bikes into ViewBag
    List<string> bikes = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Bikes").Select(sn => sn.Name).ToList();
    ViewBag.bikes = bikes;

    return View();
}
```

Bikes View:

```html
@model IEnumerable<AdventureWorks.Models.Product>

...

@foreach (string bike in @ViewBag.bikes)
{
    <th>
        <form method="post">
            <div class="btn-group btn-group-vertical">
                <button class="btn btn-primary" name="bike" value="@bike">@bike</button>
            </div>
        </form>
    </th>
}
```

After the button click, links(<a></a>) are presented for the subcategories.

```cs
[HttpPost]
public ActionResult Bikes(string bike)
{
    //List of Bikes into ViewBag
    List<string> bikes = db.ProductSubcategories.Where(b => b.ProductCategory.Name == "Bikes").Select(n => n.Name).ToList();
    ViewBag.bikes = bikes;

    //Class "H" Bikes
    var products = db.Products.Where(b => b.ProductSubcategory.Name == bike
                                            && b.Class == "H");
  
    if (products.Count() > 0)
    {
        return View(products);
    }
    return RedirectToAction("Bikes"); ;
}
```

Redirect back to *Bokes* View (POST):

```html
@foreach (var b in Model)
{
    <tr>
        <td>
            <a href="/SubCategory/Product?id=@b.ProductID">@b.Name</a>
        </td>
        <td>
            @b.ProductNumber
        </td>
        <td>
            $@b.ListPrice
        </td>
    </tr>
}
```

Click on a link and it will take you to the product's information page.
Here is a snippet:

```cs
// GET: SubCategory/Product?id=<product id>
public ActionResult Product()
{
    //Get Product's ID
    if (Request.QueryString["id"] == null)
    {
        return RedirectToAction("Index");
    }

    //String to int
    int id = Convert.ToInt32(Request.QueryString["id"]);
    //Get specific product
    var product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
    //Product Model ID
    int? pmi = product.ProductModelID;
    //Description
    string desc = "Not Availiable";

    if (pmi != null)
    {
        //Product Description
        desc = db.ProductModelProductDescriptionCultures.Where(p => p.ProductModelID == pmi)
                                                        .FirstOrDefault().ProductDescription
                                                        .Description;
    }
    //Description into View
    ViewBag.desc = desc;

    //Product's image
    byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
    //Product image into View
    ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

    return View(product);
}
```

Snippet of *Product* View

```html
@*Product's Information*@
<div class="panel-group col-lg-3">
    <div class="panel panel-default">
        <div class="panel-heading"><b>@Html.DisplayNameFor(model => model.ProductSubcategory)</b></div>
        <div class="panel-body">@Html.DisplayFor(model => model.ProductSubcategory.Name)</div>
    </div>

    ...
```

### Step #4: Add Review

When the user is on the product's page, they will be able to review the product if they wished to add a review. 
This is done sending the product's ID to the *ProductReview* method.
Here is a snippet:

```html
<input id="review" type="button" class="btn btn-default" value="Rate"
       onclick="return review_onclick()" />
<script language="javascript" type="text/javascript">
    function review_onclick() {
        window.location.href = "/SubCategory/ProductReview?id="+@Model.ProductID;
    }
</script>
```

The method of the Product review checking if id is null.

```cs
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult ProductReview([Bind(Include = "ProductReviewID, ProductID, ReviewerName, " +
    "ReviewDate, EmailAddress, Rating, Comments, CommentsModifiedDate, Product ")] ProductReview review)
{
    string id = Request.QueryString["id"];
    if (id == null)
    {
        return RedirectToAction("Index");
    }
```

If it's not null then gets the product's information like the image, and the name. and puts it *ViewBag*. This is for the user to know what they are rating.

```cs
//Get specific product
var product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();
//Get the product image
byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
//Give the product image to the View
ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);
ViewBag.PID = id;
ViewBag.PName = product.Name;
```

Here is a snippet on how the the review page is displayed.

```html
@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()
    <div class="form-horizontal">
        <h3>Fill Out Your Review:</h3>
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.ReviewerName, htmlAttributes: new { @class = "control-label" })
            @Html.EditorFor(model => model.ReviewerName, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.ReviewerName, "", new { @class = "text-danger" })
        </div>

        ...
```

This checks whether the review is valid and if so, it will be added and saved to the database.

```cs
if (ModelState.IsValid)
{
    //Set Values for Review
    review.ProductID = Convert.ToInt32(id);
    review.ReviewDate = DateTime.Now;
    review.ModifiedDate = review.ReviewDate;
    review.Product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();

    //Add & Save to DB
    db.ProductReviews.Add(review);
    db.SaveChanges();
                   
    return Redirect("/SubCategory/Product?id=" + id);
}
```

The review will now be visible to the corresponding product!

```html
@*View Reviews*@
@foreach (var review in Model.ProductReviews)
{
	...
            <thead>
                <tr>
                    <th>Rating</th>
                    <th>Reviewer</th>
                    <th>Date</th>
                    <th>Comment:</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>@review.Rating</td>
                    <td>@review.ReviewerName</td>
                    <td>@review.ReviewDate</td>
                    <td>@review.Comments</td>
                </tr>
    ...
```



