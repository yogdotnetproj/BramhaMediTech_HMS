<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>BramhaMediTech</title>
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
        <!-- Favicon icon-- >
        <link rel="icon" href="customTheme/images/favicon.png" type="image/x-icon">
        <link rel="shortcut icon" href="customTheme/images/favicon.png" type="image/x-icon">
        <!-- Google font-->
        <link href="https://fonts.googleapis.com/css2?family=Nunito+Sans:opsz,wght@6..12,200;6..12,300;6..12,400;6..12,500;6..12,600;6..12,700;6..12,800;6..12,900;6..12,1000&amp;display=swap" rel="stylesheet">
        <!-- Flag icon css -->
        <link rel="stylesheet" href="customTheme/css/vendors/flag-icon.css">
        <!-- iconly-icon-->
        <link rel="stylesheet" href="customTheme/css/iconly-icon.css">
        <link rel="stylesheet" href="customTheme/css/bulk-style.css">
        <!-- iconly-icon-->
        <link rel="stylesheet" href="customTheme/css/themify.css">
        <!--fontawesome-->
        <link rel="stylesheet" href="customTheme/css/fontawesome-min.css">
        <!-- Whether Icon css-->
        <link rel="stylesheet" type="text/css" href="customTheme/css/vendors/weather-icons/weather-icons.min.css">
        <!-- App css -->
        <link id="color" rel="stylesheet" href="customTheme/css/color-1.css" media="screen">
        <link rel="stylesheet" href="customTheme/css/style.css">
    </head>
    <class="hold-transition login-page">
    <body class="light">
        <!-- tap on top starts-->
        <div class="tap-top"><i class="iconly-Arrow-Up icli"></i></div>
        <!-- tap on tap ends-->
        <!-- loader-->
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <!-- login page start-->
            <div class="container-fluid p-0">
              <div class="row m-0">
                <div class="col-12 p-0">    
                  <div class="login-card login-dark">
                    <div>
                      <!--div><a class="logo"><img class="img-fluid for-light m-auto" src="customTheme/brahmaMedicalDark.png" alt="looginpage"><img class="img-fluid for-dark" src="customTheme/brahmaMedicalDark.png" alt="logo"></a></!--div-->
                      <!--div><h1 class="text-center mb-4">Bramha MediTech<br />Software Solution</h1></div-->
                      <h1 class="text-center" style="margin-bottom: 30px;">Hospital Information<br>Management System</h1>
                      <div class="login-main">
                        <form action="dashboard.html" method="post" class="theme-form">
                            <!--h2 class="text-center">Hospital information management system</!--h2-->
                            <div><a class="logo"><img width="170px" class="img-fluid for-light m-auto" src="customTheme/brahmaMedicalDark.png" alt="looginpage"><img width="170px" class="img-fluid for-dark" src="customTheme/brahmaMedicalDark.png" alt="logo"></a></div>
                            <!--p class="text-center">Tech-Driven Hospital Care</!--p-->
                            <div class="form-group">
                              <label class="col-form-label">Login ID</label>
                              <asp:TextBox ID="txtUName" runat="server" class="form-control" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label class="col-form-label">Password</label>
                              <div class="form-input position-relative">
                                <asp:textbox id="txtPassword" runat="server" class="form-control" textmode="Password"></asp:textbox>
                                <!--div class="show-hide" style="display: block;">
                                    <span class="show"></span>
                                </div-->
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtPassword" display="Dynamic" errormessage="*" setfocusonerror="True" validationgroup="loginGroup"> </asp:requiredfieldvalidator>
                              </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-4"></div>
                                <div class="col-xs-4">
                                    <!-- <button type="submit" class="btn btn-primary btn-block btn-flat">Login</button> -->
                                    <asp:button id="btnLogin" runat="server" class="btn btn-primary btn-block w-100" OnClick="btnLogin_Click" text="Login" validationgroup="loginGroup"  />
                                </div>
                                <div class="col-xs-4"></div>
                            </div>
                            <div class="row">
                                <div class="col-xs-2"></div>
                                <div class="col-xs-4">
                                    <asp:Label ID="lblerrorLogin" runat="server" ForeColor="Red" Width="300px" Text=""></asp:Label>
                                </div>
                                <div class="col-xs-4"></div>
                            </div>
                            <div class="row pt10">
                                <div class="col-xs-2"></div>
                                <div class="col-xs-8 text-center">
                                    <!-- <a href="#">Forgot Password?</a-->
                                </div>
                                <div class="col-xs-2"></div>
                            </div>
                        </form>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!--script src="plugins/jquery/jquery.min.js"></!--script>
            <script src="plugins/bootstrap/js/bootstrap.min.js"></script-->
            <!-- jquery-->
            <script src="customTheme/js/vendors/jquery/jquery.min.js"></script>
            <!-- bootstrap js-->
            <script src="customTheme/js/vendors/bootstrap/dist/js/bootstrap.bundle.min.js" defer=""></script>
            <script src="customTheme/js/vendors/bootstrap/dist/js/popper.min.js" defer=""></script>
            <!--fontawesome-->
            <script src="customTheme/js/vendors/font-awesome/fontawesome-min.js"></script>
            <!-- password_show-->
            <script src="customTheme/js/password.js"></script>
            <!-- custom script -->
            <script src="customTheme/js/script.js"></script>
        </form>
    </body>
</html>
