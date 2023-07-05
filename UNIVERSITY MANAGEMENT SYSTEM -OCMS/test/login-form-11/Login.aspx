<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="test.login_form_11.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OCMS | Login</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet">

	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
	
	<link rel="stylesheet" href="css/style.css">
</head>
<body>
    
       	<section class="ftco-section">
		<div class="container">
	<%--		<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Login #01</h2>
				</div>
			</div>--%>
			<div class="row justify-content-center">
				<div class="col-md-7 col-lg-5">
					<div class="login-wrap p-4 p-md-5">
						<form id="form1" runat="server">
		      	<div class="icon d-flex align-items-center justify-content-center">
		      		<span class="fa fa-user-o">
                     
                    </span>
		      	</div>
		      	<h3 class="text-center mb-4">Sign In</h3>
		      		<div class="form-group">
						 <asp:TextBox ID="TextBoxusername" runat="server" class="form-control rounded-left" placeholder="Username" ></asp:TextBox>
		      			 
		      		</div>
	            <div class="form-group d-flex">
	            <asp:TextBox ID="TextBoxpassword" runat="server" class="form-control rounded-left" placeholder="Password" ></asp:TextBox>

					 
	            </div>
	            <div class="form-group">
	            	<%--<button type="submit" class="form-control btn btn-primary rounded submit px-3">Login</button>--%>
					<asp:Button ID="Button1" runat="server" Text="submit" class="form-control btn btn-primary rounded submit px-3" OnClick="Button1_Click" />
	            </div>
	            <div class="form-group d-md-flex">
	            	<div class="w-50">
	            		<label class="checkbox-wrap checkbox-primary">Remember Me
									  <input type="checkbox" checked>
									  <span class="checkmark"></span>
									</label>
								 
								</div>
								<div class="w-50 text-md-right">
									<a href="#">Forgot Password</a>
								</div>
	            </div>
	                    </form>
	        </div>
				</div>
			</div>
		</div>
	</section>

	<script src="js/jquery.min.js"></script>
  <script src="js/popper.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/main.js"></script>
 
</body>
</html>
