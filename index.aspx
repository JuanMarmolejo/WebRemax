<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE HTML>
<!--
	Industrious by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
	<head>
		<title>Condo, chalet ou maison &agrave; vendre avec un courtier immobilier | RE/MAX Qu&eacute;bec</title>
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

		<!-- Banner -->
			<section id="banner">
				<div class="inner">
					<h1>Find your dream home.</h1>
					<form method="post" action="results.aspx" runat="server">
						<div class="row gtr-uniform">
							
							<div class="col-4">
                                <asp:DropDownList ID="cboType" runat="server">
                                </asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="cboYear" runat="server">
                                </asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="cboCity" runat="server">
                                </asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="cboBath" runat="server">
                                </asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="cboBed" runat="server">
                                </asp:DropDownList>
							</div>
							<div class="col-4">
								<asp:DropDownList ID="cboPrice" runat="server">
                                </asp:DropDownList>
							</div>
							<div class="col-12">
								<ul class="actions">
									<li><input type="submit" value="Submit Form" class="primary" /></li>
									<li><input type="reset" value="Reset" /></li>
								</ul>
							</div>
						</div>
					</form>
				</div>
				<video autoplay loop muted playsinline src="images/ReMax.mp4"></video>
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