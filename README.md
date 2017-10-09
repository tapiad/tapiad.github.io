# tapiad.github.io

## Hi
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>My Web page</title>

	<link href="styles/bootcss.css" rel="stylesheet" type="text/css">
	<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet"> 
	<!-- Bootstrap CDN -->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
  </head>
  
  <body>
  	<div class="container">
  		<div class="row"><!-- Grid -->
  			<div class="col-lg-1 bg-warning">
  				1
  			</div>
  			<div class="col-lg-1 bg-danger">
  				2
  			</div>
  			<div class="col-lg-1 bg-info">
  				3
  			</div>
  			<div class="col-lg-1 bg-success">
  				4
  			</div>
  			<div class="col-lg-1 bg-warning">
  				5
  			</div>
  			<div class="col-lg-1 bg-danger">
  				6
  			</div>
  			<div class="col-lg-1 bg-info">
  				7
  			</div>
  			<div class="col-lg-1 bg-success">
  				8
  			</div>
  			<div class="col-lg-1 bg-warning">
  				9
  			</div>
  			<div class="col-lg-1 bg-danger">
  				10
  			</div>
  			<div class="col-lg-1 bg-info">
  				11
  			</div>
  			<div class="col-lg-1 bg-success">
  				12
  			</div>
  		</div>

  		<div class="row"><!-- Nesting -->
  			<div class="col-lg-6 bg-success">
  				<p>This is an outer div</p>
  				<div class="col-lg-6 bg-primary">
  					<p>This is an inner div</p>
  				</div>
  			</div>
  		</div>

  		<div class="row"><!-- Push/Pull -->
  			<div class="col-lg-4 col-lg-push-8 bg-warning">
  				Column 1
  			</div>
  			<div class="col-lg-8 col-lg-pull-4 bg-info">
  				Column 2
  			</div>
  		</div>

  		<div class="row"> <!-- Header -->
  			<div class="col-lg-12">
  				<h1>This is a header <small>This is a smaller header</small></h1>
  				<p>This is a normal paragraph</p>
  				<p><small>This is small text for like fine print</small></p>
  			</div>
  		</div>

  		<div class="row"> <!-- highlight/deleted text -->
  			<div class="col-lg-12">
  				You can <mark>highlight</mark> text using <mark>mark</mark>!
  				<del>Deleted text</del>
  				<s>Striked through text</s>
  			</div>
  		</div>

  		<div class="row"> <!-- text alignment -->
  			<div class="col-lg-12">
  				<p class="text-left">Left aligned text.</p>
  				<p class="text-center">Centered text.</p>
  				<p class="text-right">Right aligned text.</p>
  				<p class="text-justify">Justified text.</p>
  			</div>
  			<div class="col-lg-12"> <!-- lower/uppercase, blockquote -->
  				<p class="text-lowercase">THIS IS LOWERCASE</p>
  				<p class="text-uppercase">This is uppercase</p>
  				<blockquote><!-- rightside: class:blockquote-reverse -->
  					<p>"It's scary both ways, we are alone or we are not alone in this universe"</p>
  					<footer>Someone famous</footer>
  				</blockquote>
  			</div>
  			<div class="col-lg-12"> <!-- Table -->
  				<table class="table"> <!-- classes:table table-striped,bordered,hover,condensed -->
  					<tr class="active"> <!-- success,danger,ect.(color) -->
  						<th>
  							First Name
  						</th>
  						<th>
  							Last Name
  						</th>
  						<th>
  							Percentage
  						</th>
  					</tr>
  					<tr>
  						<th>
  							Daniel
  						</th>
  						<th>
  							Tap
  						</th>
  						<th>
  							89%
  						</th>
  					</tr>
  					<tr>
  						<th>
  							Maze
  						</th>
  						<th>
  							Stock
  						</th>
  						<th>
  							78%
  						</th>
  					</tr>
  					<tr>
  						<th>
  							Shane
  						</th>
  						<th>
  							Dang
  						</th>
  						<th>
  							91%
  						</th>
  					</tr>	
  				</table>
  			</div>
  		</div>

  		<div class="row"> <!-- Image -->
  			<div class="col-lg-4 col-md-4">
  				<img src="images/Piano-Keys.jpg" class="img-responsive img-rounded"> <!-- fits the size, rounded image -->
  			</div>
  		</div>
  		<div class="row">
  			<div class="col-lg-4 col-md-4">
  				<img src="images/Piano-Keys.jpg" class="img-responsive img-circled"> <!-- circle image -->
  			</div>
  		</div>
  		<div class="row">
  			<div class="col-lg-4 col-md-4">
  				<img src="images/Piano-Keys.jpg" class="img-responsive img-thumbnail"> <!-- thumbnail image -->
  			</div>
  		</div>

  		<div class="row"> <!-- Button -->
  			<div class="col-md-8"> <!-- Button creations -->
  				<a class="btn btn-default" href="#">Link</a>
  				<button class="btn btn-default"> Button </button> <!-- More for running scripts -->
  				<input class="btn btn-default" type="button" value="input">
  				<input class="btn btn-default" type="submit" value="submit">
  			</div>
  		</div>
  		<div class="row">
  			<div class="col-md-8"> <!-- Button colors --> 
  				<button class="btn btn-default"> Button </button>
  				<button class="btn btn-primary"> Button </button>
  				<button class="btn btn-success"> Button </button>
  				<button class="btn btn-info"> Button </button>
  				<button class="btn btn-warning"> Button </button>
  				<button class="btn btn-danger"> Button </button>
  				<button class="btn btn-link"> Button </button>
  			</div>
  		</div>
  		<div class="row">
  			<div class="col-md-8"> <!-- Button sizes --> 
  				<button class="btn btn-default"> Button </button>
  				<button class="btn btn-default btn-lg"> Lagre </button>
  				<button class="btn btn-default btn-small"> Small </button>
  				<button class="btn btn-default btn-xs"> xs </button>
  			</div>
  		</div>

  		<div class="row"> <!-- Basic forms -->
  			<div class="col-md-12">
  				<h2>Basic form</h2>
  				<form action="" method="">
  					<div class="form-group"> <!-- Email -->
  						<label for="Email">Email Address</label> <!-- for:highlights input table -->
  						<input type="Email" class="form-control" id="Email"/>
  					</div>
  					<div class="form-group"> <!-- Password -->
  						<label for="Password">Password</label>
  						<input type="Password" class="form-control" id="Password"/>
  					</div>
  					<div class="form-group"> <!-- File upload -->
  						<label for="File-upload">File upload</label>
  						<input type="File" id="File-upload"/><!-- For and id has to be the same -->
  					</div>
  					<div class="form-group"> <!-- Submit -->
  						<input type="Submit" class="submit" id="btn btn-default" value="submit" />
  					</div>
  				</form>
  			</div>
  		</div>
  	</div>

<!-- jQuery CDN -->
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
<!-- Bootstrap CDN -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
  </body>
</html>
