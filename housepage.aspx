<%@ Page Language="C#" AutoEventWireup="true" CodeFile="housepage.aspx.cs" Inherits="housepage" %>

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

		<!-- Heading -->
			<div id="heading" >
				<h1>information of the property</h1>
			</div>

		<!-- Main -->
			<section id="main" class="wrapper">
				<div class="inner">
					<div class="content">
						<!-- Row #1 -->
						<div class="row">
							<!-- Imagenes-->
							<div class="box alt">
								<div class="row gtr-50 gtr-uniform">
									<div class="col-3"><span class="image fit"><img src="images/<%= House.Facade %>" alt="" /></span></div>
									<div class="col-3"><span class="image fit"><img src="images/<%= House.Image1 %>" alt="" /></span></div>
									<div class="col-3"><span class="image fit"><img src="images/<%= House.Image2 %>" alt="" /></span></div>
									<div class="col-3"><span class="image fit"><img src="images/<%= House.Image3 %>" alt="" /></span></div>
								</div>
							</div>	
						</div>
						<br />
						<h3>Information house</h3>
						<!-- Row #2 -->
						<div class="row">
							<!-- Informacion de la casa -->
							<div class="col-8 col-12-small">
								<table class="alt">
									<tbody>
										<tr><td>
											<div class="row gtr-uniform">
												<div class="col-4 col-12-xsmall">
													<%= House.Price %> $ 
												</div>
												<div class="col-4 col-12-xsmall">
													<%= House.City %> 
												</div>
												<div class="col-4 col-12-xsmall">
													<%= House.Bathrooms %> <i class="fa fa-bath fa-2x" aria-hidden="true"></i>
													<%= House.Bedrooms %> <i class="fa fa-bed fa-2x" aria-hidden="true"></i>	
												</div>
											</div>
											<hr>
											<div class="row gtr-uniform">
												<div class="col-4 col-12-xsmall">
													<span style="font-weight: bold;">Property Type: </span><br />
													<%= House.PropertyType %>
												</div>
												<div class="col-4 col-12-xsmall">
													<span style="font-weight: bold;">Land Size: </span><br />
													<%= House.Area %>
												</div>
												<div class="col-4 col-12-xsmall">
													<span style="font-weight: bold;">Built in: </span><br />
													<%= House.ConstructionYear %>
												</div>
											</div>
											<hr>
											<div class="row gtr-uniform">
												<div class="col-12 col-12-xsmall">
													<span style="font-weight: bold;">Description: </span><br />
													<p><%= House.Description %></p>
												</div>
											</div>
										</td></tr>
									</tbody>
								</table>
							</div>
							<!-- Informacion del agente -->
							<div class="col-4 col-12-small">
								<table class="alt">
									<tbody>
										<tr><td>
											<div class="row gtr-uniform">
												<div class="col-6 col-12-xsmall">
													<span class="image fit"><img src="images/<%= Agent.Photo %>"></span>
												</div>
												<div class="col-6 col-12-xsmall">
													<span style="font-weight: bold;"><%= Agent.FullName %></span>
													Certified Real Estate Broker
												</div>
											</div>
											<hr>
											<div class="row gtr-uniform">
												<div class="col-12 col-12-xsmall">
													<i class="fa fa-phone fa-2x" aria-hidden="true"></i>
													<%= Agent.PhoneNumber %>
													<br />
													<i class="fa fa-envelope" aria-hidden="true"></i>
													<%= Agent.Email %>
												</div>
												<div class="col-12 col-12-xsmall">
													<form method="post" action="sendmail.aspx?refHouse=<%= House.RefHouse %>&refAgent=<%= Agent.RefEmployee %>">
														<div class="row gtr-uniform">
															<div class="col-12 col-12-xsmall">
																<input type="text" name="txtPhone" id="txtPhone" value="" placeholder="Pnone Number" required/>
															</div>
															<!-- Break -->
															<div class="col-12">
																<textarea name="txtMessage" id="txtMessage" placeholder="Message to the agent." rows="6"></textarea>
															</div>
															<!-- Break -->
															<div class="col-12">
																<ul class="actions">
																	<li><input type="submit" value="send mail" class="primary" /></li>
																	<!-- <li><input type="reset" value="Reset" /></li> -->
																</ul>
															</div>
														</div>
													</form>
												</div>
											</div>
										</td></tr>
									</tbody>
								</table>
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