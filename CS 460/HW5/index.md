---
title: Daniel
layout: default
---

Quick links:

* Visit my GitHub [here](https://github.com/tapiad).

* Visit my [Portfolio](https://tapiad.github.io).

* Link to Homework 5 [assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW5.html).


### Homework 5

As we progress onto Homework 5 we are going to learn more ASP.NET MVC 5 and we are going to create a web application based on a DMV Request form. This form will be about requesting for an update of address, state, city, ect. 

### Step 1: Data Model

Creating the database with a single table that uses an integer primary key was one of our first task. I used the ID integer as my primary key. To create a table you need to add `CREATE TABLE DataBaseName.TableName` followed by a *variable datatype,*. Here I created the table (*up.sql*).

```sql
CREATE TABLE [dbo].[DMVRequest] (
    [ID]            INT	IDENTITY (1, 1) NOT NULL,
    [DOB]           NVARCHAR (64)   NOT NULL,
    [Name]          NVARCHAR (128)  NOT NULL,
    [Address]       NVARCHAR (128)  NOT NULL,
    [City]          NVARCHAR (64)  NOT NULL,
    [State]         NVARCHAR (64)  NOT NULL,
    [Zip]           INT            NOT NULL,
    [County]        NVARCHAR (64)  NOT NULL,
    [Email]         NVARCHAR (64)  NOT NULL,
    CONSTRAINT [PK_dbo.DMVRequest] PRIMARY KEY CLUSTERED (ID ASC)
);
```

I then added some values into the table. I used `INSERT INTO DataBase.Table` followed by *(variable) VALUES (value)*

```sql
INSERT INTO [dbo].[DMVRequest](ID, DOB, Name, Address, City, State, Zip, County, Email) VALUES
    (524, "2017-12-11 05:43:23", "Bob Lucas", "23142 Sand NE, Aurora", "OR", 97002, "Marion", "uTell@gmail.com"),
    (241, "2015-03-04 12:33:13", "Larry Bird", "23146 Lake Ct NE, Woodburn", "OR", 97071, "Marion", "daBird@gmail.com");
	
GO
```

To drop a table(*down.sql*) is simple as:

```sql
DROP TABLE dbo.DMVRequest;
``` 


### Step 2: Model class and Database Context class

In the Model class I have all the methods for the DMV Application. The Model class uses data annotations such as *[Required]* 

```cs
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The Model of a DMV Request
/// </summary>
public class DMVRequest
{
    [Required(ErrorMessage = "Your Id number please (3-digits)")]
    [MinLength(3)]
    [Display(Name = "Customer ID")]
    public int ID { get; set; }

    //...
}

```


### Step 3: Connect database

I connected the database using the *connection string*

```xml
<connectionStrings>
    <add name="MyDB" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Daniel\Desktop\tapiad.github.io\CS 460\HW5\DMV_Application\DMV_Application\App_Data\Database.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
 </connectionStrings>
```
>*Note: In the Web.config file*

### Step 4: GET-POST-Redirect

I have never thought about this concept. The PRG is *a web development design pattern that prevents some duplicate form submissions, creating a more intuitive interface for user agents (users). PRG supports bookmarks and the refresh button in a predictable way that does not create duplicate form submissions*. For more information about the PRG, [click here](https://en.wikipedia.org/wiki/Post/Redirect/Get)!

I used PRG method when someone is to submit there request. It redirects them to a different page after clicking the submit button. The user's input is placed in a *TempData* and redirected to a different method in the controller.

```cs
[HttpPost]
public ActionResult ChangeAdd(FormCollection form)
{
    TempData["CID"] = Request.Form["CID"];
    TempData["DOB"] = Request.Form["DOB"];
    TempData["Name"] = Request.Form["Name"];
    TempData["Address"] = Request.Form["Address"];
    TempData["City"] = Request.Form["City"];
    TempData["State"] = Request.Form["State"]; 
    TempData["Zip"] = Request.Form["Zip"];
    TempData["County"] = Request.Form["County"]; 
    TempData["Email"] = Request.Form["Email"];
    return RedirectToAction("PRG");
}
```

In the *PRG* method the values placed int the *TempData* is then moved into a *ViewBag*. The *TempData* is for storing temporary data.

```cs
public ActionResult PRG()
{
    ViewBag.CID = TempData["CID"];
    ViewBag.DOB = TempData["DOB"];
    ViewBag.Name = TempData["Name"];
    ViewBag.Address = TempData["Address"];
    ViewBag.City = TempData["City"];
    ViewBag.State = TempData["State"];
    ViewBag.Zip = TempData["Zip"];
    ViewBag.County = TempData["County"];
    ViewBag.Email = TempData["Email"];
    return View();
}
```

### Step 5: Miscellaneous

To make the a Model class available to a *View()* add *@model* followed by the model's name. Place on the top of the .cshtml file. 

```html
@model IEnumerable<DMV_Application.Models.DMVRequest>
```

Make visible by Razor HTML helper

```html
<!--Display Name-->
@Html.DisplayNameFor(model => model.ID)

<!--Display Item Value-->
@Html.DisplayFor(modelItem => item.ID)
```


### Step 6: ScreenShots

**Home Page**
![Alt text](/ScreenShots/Home.PNG?raw=true "Home Page")

**Pending Requests**


**Request Form** 


**Thank You Page**






