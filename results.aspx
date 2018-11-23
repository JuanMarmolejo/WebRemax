<%@ Page Language="C#" AutoEventWireup="true" CodeFile="results.aspx.cs" Inherits="results" %>

<!DOCTYPE HTML>
<!--
	Industrious by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
	<head>
		<title>Re/max - Results</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<link rel="stylesheet" href="assets/css/main.css" />
	</head>
	<body class="is-preload">

		<!-- Header -->
			<header id="header">
				<a class="logo" href="index.html"><img src="images/logoremax.jpg"></a>
				<nav>
					<a href="#menu">Menu</a>
				</nav>
			</header>

		<!-- Nav -->
			<nav id="menu">
				<ul class="links">
					<li><a href="index.aspx">Home</a></li>
				</ul>
			</nav>

		<!-- Heading -->
			<div id="heading" >
				<h1>Search results</h1>
			</div>

		<!-- Main -->
			<section id="main" class="wrapper">
				<div class="inner">
					<div class="content">
						<div class="row">
							<div class="box alt">
								<div class="row gtr-50 gtr-uniform">
									
                                    <% displayHouses(); %>

								</div>
							</div>
						</div>
					</div>
				</div>
			</section>

		<!-- Footer -->
			<footer id="footer">
				<div class="inner">
					<div class="content">
						<section>
							<p>RE/MAX Québec inc. 1500 rue Cunard Laval (Québec) Canada H7S 2B7 
							Phone : 450 668-7743 • Toll Free : 1 800 361-9325 • Fax : 450 668-2115 • Email : info@remax-quebec.com</p>
						</section>
						<section>
							<a href="#">CONTACT US</a>
						</section>
						<section>
							<a href="#">SITE PLAN</a>
						</section>
						<section>
							<a href="#">PRIVACY POLICY</a>
						</section>
						<section>
							<a href="#">USER POLICY</a>
						</section>
					</div>
					<div class="copyright">
						&copy; MarmolSoft.
					</div>
				</div>
			</footer>

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/browser.min.js"></script>
			<script src="assets/js/breakpoints.min.js"></script>
			<script src="assets/js/util.js"></script>
			<script src="assets/js/main.js"></script>

	</body>
</html>