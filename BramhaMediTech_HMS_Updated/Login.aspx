<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>Log in  </title>
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
        <%--<link href="https://fonts.googleapis.com/css2?family=Nunito:wght@400&display=swap" rel="stylesheet">--%>
    <!-- GLOBAL MAINLY STYLES-->
    <link href="cssmain/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="cssmain/master.css"/>
    <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css"/>
    <link href="cssmain/main.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="plugins/theme/css/theme.min.css">
        <link rel="stylesheet" href="css/style.css">
       <!-- <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">-->
        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
            <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->
      <!--  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"> -->
       <style type="text/css">
		body{
			font-family: 'Source Sans Pro';
		}

		.extralight{
			
			font-weight: 100;
		}

		.light{
			
			font-weight: 300;
		}

		.regular{
			
			font-weight: 400;
		}

		.semibold{
			
			font-weight: 600;	
		}

		.bold{
			
			font-weight: 700;	
		}

		.black{
			
			font-weight: 900;		
		}

        .form-control:focus, .form-control:hover {
    box-shadow: 0 8px 24px rgb(0 0 0 / 12%);
    color: #1f2022;
}
.form-control:hover {
    background: #ebebeb;
    border-color: #ebebeb;
}
.form-control {
    background: #ebebeb;
    border: 1px solid #ebebeb;
    border-radius: 20px;
    color: #1f2022;
    display: block;
    font-size: 1rem;
    height: auto;
    line-height: 1.43;
    outline: none;
    padding: calc(0.61429rem - 1px) 1.42857rem !important;
    transition: background .2s ease-in-out,border .2s ease-in-out,box-shadow .2s ease-in-out,color .2s ease-in-out;
    
    width: 100%;
}
	</style>
    </head>
<class="hold-transition login-page" >
 <body class="hold-transition login-page">
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div  class="regular">
       <div class="login-box">
            <div class="login-box-body">
                <div class="login-logo">
                    <img src="images/pis-logo.jpg" alt="" class="logo-img">
                   
                </div>  
                      <div class="content-body">
                          <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                         <asp:Panel ID="PopupGrid" runat="server" Height="50px" Width="1000px">
        <table border="0" cellpadding="0" cellspacing="0" style="border-right: steelblue 2px solid;
            border-top: steelblue 2px solid; font-size: 8pt; text-transform: capitalize;
            border-left: steelblue 2px solid; color: #043454; border-bottom: steelblue 2px solid;
            font-family: Verdana; background-color: #e5f4ff; text-align: left" width="900">
            <tr>
                <td align="center" colspan="1" style="width: 10px; height: 14px">
                </td>
                <td align="center" colspan="6" style="height: 14px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="1" style="width: 10px; height: 14px">
                    &nbsp; &nbsp;
                </td>
                <td align="center" colspan="6" style="height: 14px">
                    <strong>To use this product, you must buy it.&nbsp;</strong>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="1" style="width: 10px; height: 14px">
                </td>
                <td align="center" colspan="6" style="height: 14px">
                    You have installed products in evaluation mode.
                </td>
            </tr>
            </table>
                             </asp:Panel>
                    <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" backgroundcssclass="AutoPOPup"
        dropshadow="true" popupcontrolid="PopupGrid" targetcontrolid="hdnTarget">
    </cc1:modalpopupextender>
    <asp:HiddenField ID="lblhide" runat="server" />
    <asp:HiddenField ID="hdnTarget" runat="server" />
                    </ContentTemplate>
                        </asp:UpdatePanel>--%>
                <h3 class="login-box-msg mb-5">Login to your account</h3>
                <form action="dashboard.html" method="post" >
                    
                    <div class="form-group has-feedback mb-3 d-flex mt-3">
                       <!-- <input type="email" class="form-control" placeholder="Email"> -->
                        <!--<span class="far fa-user mr-1"></span>-->
                        <asp:TextBox ID="txtUName" runat="server" class="form-control" ></asp:TextBox>
                    </div>
                    <div class="form-group has-feedback d-flex mb-5 mt-5">
                      <!--  <input type="password" class="form-control" placeholder="Password">-->
                       <!-- <span class="fas fa-key mr-1"></span>-->
                             <asp:textbox id="txtPassword" runat="server" class="form-control" textmode="Password" >
                                </asp:textbox>
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server"
                                    controltovalidate="txtPassword" display="Dynamic" errormessage="*" setfocusonerror="True"
                                    validationgroup="loginGroup"> </asp:requiredfieldvalidator>
                        
                    </div>
                    <div class="row">
                        <div class="col-xs-4"></div>
                        <div class="col-xs-4">
                           <!-- <button type="submit" class="btn btn-primary btn-block btn-flat">Login</button> -->
                             <asp:button id="btnLogin" runat="server" class="btn btn-primary btn-block btn-flat"  OnClick="btnLogin_Click"
                                    text="Login" validationgroup="loginGroup"  />
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
        <script src="plugins/jquery/jquery.min.js"></script>
        <script src="plugins/bootstrap/js/bootstrap.min.js"></script>
       
       
    </form>
</body>
</html>
