---
title: Daniel
layout: default
---

Visit my GitHub [here](https://github.com/tapiad).
Visit my [Portfolio](https://tapiad.github.io). 

### Homework 1

For our first homework assignment we are to learn the basics of HTML and CSS. We are also required to use Bootstrap for our website we are to create. This assignment is where we are going to learn the basics of Git. We are to only use the command line while using Git. We are also going to have a working GitHub Pages repository/web page.

### Step 1: Using Git

I have never really used Git before but this assignment helped me learn the basics of Git. 

I first created a GitHub and I created my first repository on GitHub called hello-world. I can only use Git through the command line, as instructed.

I will make sure that I am in the folder where I'm going to clone my repository.

<!-- Code form  -->
```bash 
git clone https://github.com/tapiad/hello-world.git
cd hello-world
git config --global user.name "tapiad"
git config --global user.email "dtapia12@mail.wou.edu"
``` 

Now we are going to add a README.md file and `push` it to the repository.

```bash
git add README.md 
git commit -m "added README.md"
git push -u origin master
```

If I were to edit the README.md file I will need to `git pull` first and then `add`/`commit`/`push` again.

### Step 2: HTML

As I first started creating my HTML web-page I noticed that I have forgotten some of the basics. I received plenty of help by reading over this website on about [HTML](https://developer.mozilla.org/en-US/docs/Web/HTML). Helped me get something on my web-page like a simple header, image, and paragraph.

```html
<!DOCTYPE html>
<html>
  <head>
    <title>HW1 Webpage</title>
    <meta charset="utf-8">
  </head>
  <body>
  	<h1>Welcome To Daniel's Webpage</h1> <!-- Piano Image -->
	<img src="images/Piano-Keys.jpg" alt="Image of a Piano!" width="500" height="350">
	<p>I love playing the piano</p>
  </body>
</html>
```

### Step 3: Adding the CSS

We are to had a little flavor to our HTML web-site by using CSS. Here is a helpful link: [CSS](https://developer.mozilla.org/en-US/docs/Web/CSS).

Before adding CSS to your HTML you have to make the CSS is linked to your HTML. Here is an example of mine:

```html
<link href="styles/style.css" rel="stylesheet" type="text/css">
```

CSS helps with presentation of your website! It can be the padding of your body or adding a background color to changing the size of a paragraph. Here are some of the CSS elements I used for my web-page:

```CSS
html {
  background-color: #ABABB3;
  padding: 0 20px 20px 20px; /*values set top,right,bottom,left*/
}
h1 {
  text-align: center;
  margin: 0;/*space around outside of element*/
  padding: 20px 0;/*space around content(paragraph)*/    
  color: #00539F;
  text-shadow: 2px 2px 1px black;/*1:hor offset, 2:ver offeset, 3:blur radius, 4:base color shadow*/
}
body {
  width: all;/*forces the body to always be xxx pixels wide*/
  margin: 0 auto;/*first value affects element's top & bottom, second value right & left*/
  padding: 0 20px 20px 20px;/*values set top,right,bottom,left*/
  border: 5px solid black;/*solid line around padding*/
}
```

### Step 4: Bootstrap

I first had no idea what was bootstrap. I have always thought about it had to do something with a computing booting up. Anyways, here is a link I used to learn some basics of [Bootstrap](https://www.w3schools.com/bootstrap/bootstrap_get_started.asp).

Just like CSS you have to hook up bootstrap. Here is how I linked mine:

```html
 <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
```

You want to make sure you add this into your in the *<head>* part of your HTML.

There are many things that Bootstrap is useful for. I used a Navbar which was a requirement to add on to my web-page:

```html
<nav class="navbar navbar-inverse">  <!-- Bootstrap Navbar -->
  		<div class="container-fluid">
   			<div class="navbar-header">
      			<a class="navbar-brand" href="#">Daniel's Website</a>
    		</div>
    		<ul class="nav navbar-nav">
      			<li class="active"><a href="#">Home</a></li>
      			<li><a href="https://github.com/tapiad">GitHub Page</a></li>
      			<li><a href="https://tapiad.github.io/">Portfolio</a></li>
    		</ul>1
  		</div>
	</nav>
```

As part of the requirements of this assignment, I had to add a table, a `ol`, `ul`, and `dl` type of lists. All code has to be our own. We are not allowed to use designers such as Dreamweaver.

You can visit my completed web-site here at [CS460 HW1 Webpage](website)!!!