 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="IPDDesk_OLD.aspx.cs" Inherits="IPDDesk_OLD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>IPD DESK  </title>
        <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
        <link rel="stylesheet" href="plugins/bootstrap/css/bootstrap.min.css">
        <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css">
        <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
        <link rel="stylesheet" href="plugins/theme/css/theme.min.css">
        <link rel="stylesheet" href="plugins/theme/css/skins/_all-skins.min.css">
        <link rel="stylesheet" href="css/style.css">

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
			font-family: 'Source Sans Pro';
			font-weight: 100;
		}

		.light{
			font-family: 'Source Sans Pro';
			font-weight: 300;
		}

		.regular{
			font-family: 'Source Sans Pro';
			font-weight: 400;
		}

		.semibold{
			font-family: 'Source Sans Pro';
			font-weight: 600;	
		}

		.bold{
			font-family: 'Source Sans Pro';
			font-weight: 700;	
		}

		.black{
			font-family: 'Source Sans Pro';
			font-weight: 900;		
		}
	</style>
    <style>

     
        .treeview a {
                font-size: 16px;
        }
        #TrMenu {
            line-height:30px;
        }
        #TrMenu div tr:hover {
                background-color: #028469;
        }
        #TrMenu div table tbody tr:nth-child(2) td:nth-child(3) {
        width:100%;
       
        }
        #TrMenu table tbody tr td:nth-child(2) {
                padding-left: 20px;
        }
         #TrMenu div table tbody tr td:nth-child(2) {
                padding-left: 0px;
        }
         .skin-black .sidebar a {
    color: #ffffff;
}
        .form-control {
         
            height: 29px !important;
            padding: 0px 7px !important;
            font-size: 13px;
        }
        .content-header > .breadcrumb {
            top: 5px !important;
                padding: 5px 5px;
        }
        .content-header {
  padding: 8px 15px 7px 16px !important;
}
        .skin-black .content-header {
    margin: 0px 15px;
        }
        .content {
            padding: 5px;
        }
        .box-header {
            padding: 0px;
        }
        .table > tbody > tr > th {
        padding:5px !important;
        }
        .navbar-nav > li > a {
            top: 0px !important;
            left: 0px !important;
        }
        .skin-black .main-header .navbar .nav>li>a {
    color: #fff !important;
    font-size: 21px !important;
    border:none !important;
}
        .content-header > .breadcrumb > li > a {
            color: #fff !important;
        }
        .skin-black .main-header .navbar .nav > li > a:hover {
            background: #1e6792 !important;
        }
        .table th {
            background-color: #367fa9 !important;
        }
        .skin-black .sidebar a {
    color: #ffffff !important;
}
        a[href="#TrMenu_SkipLink"] {
    display:none !important;
}
        
       .content table tr:nth-child(odd){
           background-color:#eee !important;
}
        .content table tr:nth-child(even) {
            background-color: #fff;
        }
        .content table tr:hover {
            background-color:#e2e2e2 !important;
        }
    </style>

 
    </head>
<body class="hold-transition skin-black sidebar-mini">
    <form id="form1" runat="server">
    <asp:scriptmanager Id="scriptmanager" runat="server">
    </asp:scriptmanager>
    <div  class="regular">

    <div class="wrapper">
            <header class="main-header">
                <!-- Logo -->
                <a href="dashboard.html" class="logo">
                    <!-- mini logo for sidebar mini 50x50 pixels -->
                   <span class="logo-mini"> <asp:Label ID="LblDCCode" runat="server" Text=" " > </asp:Label> </span>
                    <!-- logo for regular state and mobile devices -->
                   <span class="logo-lg"> <asp:Label ID="LblDCName" runat="server" Text=" " ></asp:Label>  </span>
                </a>
                <!-- Header Navbar: style can be found in header.less -->
                <nav class="navbar navbar-static-top">
                    <!-- Sidebar toggle button-->
                    <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
                        <span class="sr-only">Toggle navigation</span>
                    </a>
                    <div class="navbar-custom-menu">
                        <ul class="nav navbar-nav">
                            <li class="dropdown messages-menu">
                                <a href="home.aspx">
                                    <i class="fa fa-fw fa-home"></i>
                                </a>
                            </li>
                           <%-- <li class="dropdown notifications-menu">
                                <a href="Login.aspx">
                                    <i class="fa fa-fw fa-lock"></i>
                                </a>
                            </li>
                            <li class="dropdown tasks-menu">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-fw fa-users"></i>
                                </a>
                            </li>--%>
                            <li class="dropdown tasks-menu">
                                <a href="Login.aspx">
                                    <i class="fa fa-fw fa-power-off"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </header>
            <!-- Left side column. contains the logo and sidebar -->
            <aside class="main-sidebar">
                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">
                    <!-- Sidebar user panel -->
                    <div class="user-panel">
                        <div class="pull-left image">
                            <img src="images/profile.jpg" class="img-circle" alt="User Image">
                        </div>
                        <div class="pull-left info">
                            <p> <asp:Label ID="LUNAME" runat="server" Text="" ></asp:Label></p>
                            <a href="#"><i class="fa fa-circle text-success"></i> Admin</a>
                        </div>
                    </div>
                    <!-- sidebar menu: : style can be found in sidebar.less -->
                   <ul class="sidebar-menu" data-widget="tree">
                        <li class="treeview">

                         <asp:TreeView ID="TrMenu"  Visible="true" runat="server"  ExpandDepth="1"   
                onselectednodechanged="TrMenu_SelectedNodeChanged"  class="logo-lg" >
                <HoverNodeStyle Font-Underline="false" />
                <NodeStyle Font-Names ="Tahoma" Font-Size="10pt"   HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" >
                </NodeStyle>
                <ParentNodeStyle  />
                <SelectedNodeStyle  Font-Underline="false" HorizontalPadding="0px" 
                VerticalPadding="0px" />
                
                </asp:TreeView>

                           
                           
                        </li>                    
                       
                        
                       
                    </ul>
                </section>
                <!-- /.sidebar -->
            </aside>
            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>IPD Desk</h1>
                    <%--<ol class="breadcrumb">
                    <li><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                    <li><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active">IPD Desk</li>
                    </ol>--%>
                </section>
                <!-- Main content -->
                <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                               <div id="ShiftingDetails" runat="server" visible="false" >
                                   <div class="col-lg-12" >
                                    <div class ="row">
                                       <%--  <div class="col-lg-1 text-left" style="width:80px">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtShiftDate" style="width:70px" > Date:</label> 
                                                             </div>
                                                         </div> 
                                         <div class="col-lg-2 text-left" style="width:170px">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <input id="txtShiftDate" class="form-control" style="width:120px" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                      </div>
                                                    </div>
                                         <div class="col-lg-1 text-left" style="width:80px">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtShiftTime" style="width:70px" > Time:</label> 
                                                             </div>
                                                         </div>  
                                         <div class="col-lg-1 text-left" style="width:100px">
                                            
                                                 <input  type="text" runat="server" autopostback="true" style="width:90px" id="txtShiftTime"  class="form-control timepicker">
                                                   
                                       </div>                                        
                                         <div class="col-lg-1 text-left" style="width:120px">
                                                        <div class="form-group"> 
                                                            <label for="ddlConsultantDoc" style="text-align:left">Cons.Doctor</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                         <div class="col-lg-1 text-left" style="width:200px">
                                                    <div class="form-group">                                                         
                                                         <asp:DropDownList ID="ddlConsultantDoc" runat="server" CssClass="form-control"    Width="190px" 
                                                         TabIndex="4">
                                                            
                                                        </asp:DropDownList>
                   
                                                           
                                                    </div>
                                                    </div>--%>
                                             <div class="col-lg-3 text-left" style="width:190px">
                                                        <div class="form-group"> 
                                                            <label for="txtshiftReason" style="text-align:left">Reason For Shifting</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                <div  class="col-lg-1  text-left"  style="width:400px">
                                                    <div class="form-group">
                                                       <asp:TextBox ID="txtshiftReason" runat="server" class="form-control"   placeholder="Enter Reason"
                                            TabIndex="9"  Width="390px"></asp:TextBox>
                                                    </div>
                                                   </div>
                                          
                                        </div>
                                       </div>

                               </div>      
                                         <div id="Div3" class="col-lg-12" runat="server" >                                       
                                    <div class ="row"> 
                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Admit:" ></asp:Label>
                                                        </div>

                                        </div>
                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Edit Demography:" ></asp:Label>
                                                        </div>

                                        </div>
                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Shift:" ></asp:Label>
                                                        </div>

                                        </div>
                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Discharge:" ></asp:Label>
                                                        </div>

                                        </div>
                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Report:" ></asp:Label>
                                                        </div>

                                        </div>
                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Precurasion:" ></asp:Label>
                                                        </div>

                                        </div>
                                    </div>   
                                             </div>
                                         <div id="Div2" class="col-lg-12" runat="server" >
                                       
                                    <div class ="row">  

                                        <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                         <asp:ImageButton ID="btnAdmit1" runat="server" Width="50px" ImageUrl="~/Images0/Admit.png" ToolTip="Patient Admit"   
                                                               Text="Admit" />
                                                        </div>
                                            </div>
                                         <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:ImageButton ID="btnEdit1" runat="server"  Width="30px" ToolTip="Demography Edit" ImageUrl="~/Images0/Admitted.png" 
                                                               Text="Edit" />
                                                        </div>
                                            </div>
                                         <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        <asp:ImageButton ID="btnShift1" runat="server"  Width="30px" ToolTip="Shift"  ImageUrl="~/Images0/ShiftPatient.jpg"   
                                                               Text="Shift" />
                                                        </div>
                                            </div>
                                         <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                        
                                                              <asp:ImageButton ID="btnDischarge1" runat="server"  Width="30px"   ImageUrl="~/Images0/Discharge.jpg"  
                                                               Text="Discharge"  ToolTip="Discharge"  />
                                                        </div>
                                            </div>
                                         <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                         <asp:ImageButton ID="btnFrontSheet1" runat="server" ToolTip="FrontsheetReport" ImageUrl="~/Images0/FrontReport.png" Width="25px"  
                                                               Text="FrontSheet" />
                                                        </div>
                                            </div>
                                         <div class="col-lg-2 text-left">
                                                    <div class ="form-group">
                                                         <asp:ImageButton ID="btnpanic1"  class="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                                                        </div>
                                            </div>
                                        </div>
                                             </div>
                                          <div id="Div1" class="col-lg-12" runat="server" >
                                       
                                    <div class ="row">  

                                        <div class="col-lg-4 text-left">
                                                    <div class ="form-group">

                                                        <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                 AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>

                                                       
                                                    </div>
                                                        
                                        </div>
                                        <div class="col-lg-4">
                                                    <div class ="form-group">
                                                       
                                                        
                                                         <asp:Button ID="btnSearch" runat="server" Text="Search"  class="btn btn-primary btnSearch" OnClick="btnSearch_Click" />
                                                    </div>
                                                        
                                        </div>
                                        <div class="col-lg-4">
                                                    <div class ="form-group">
                                                        <asp:Label ID="Lmsg" runat="server" ForeColor="Red" Text="" Font-Bold="true" ></asp:Label>
                                                    </div>
                                                        
                                        </div>
                                              </div>
                                              </div>
                                   <div class="col-lg-12" runat="server" visible="false" >
                                       
                                    <div class ="row">  
                                        
                                       
                                               <div class="col-lg-12">
                                                    <div class ="form-group"  style="border:solid;color:orange;background-color:white;width:1200px;height:90px;">
                                   
                                                       
                                                                         
                                                                         <asp:RadioButtonList ID="RdbRoomType" runat="server" ForeColor="Black" Font-Size="Larger" Font-Bold="true"  RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbRoomType_SelectedIndexChanged" RepeatColumns="9"  >
                                                             
                                                                             </asp:RadioButtonList>  
                                                                        
                                                        </div>
                                               </div>
                                        </div>
                                       </div>
                                          <div class="col-lg-12" ">
                                    <div class ="row">                                  
                                      
                                         <asp:DataList ID="RoomsDataList" runat="server"  DataKeyField="RoomId" OnItemDataBound="RoomsDataList_ItemDataBound">

                <ItemTemplate>
                     <div class="box" >
                                    <div class="box-body" >

                                   
                     <div  class="col-lg-12" style="border:solid; color:black; background-color:grey; width:1200px; height:30px" >
                         <div class="row">

                           <div  class="col-lg-1 text-right"  style="width:600px;text-align:right ">
                                                        <div class="form-group">
                                                       <%-- <centerlabel  style="text-align:center" > Room Name:</label> --%>    
                                                            <asp:Label  ID="Label1"  style="text-align:center" Font-Bold="true" Font-Size="Larger" ForeColor="White" runat="server" Text="Room Name:" />                                                                                                                                                                                         
                                                        </div>
                                                    </div>
                             <div class="col-lg-1 text-left" style="width:500px">
                                                <div class="form-group">
                                                     <asp:Label  ID="lblRoomName" ForeColor="White" Font-Bold="true" Font-Size="Larger" runat="server" Text='<%# Eval("RoomName") %>' />
                                                     <asp:Label  ID="lblroomId" runat="server" Visible="false"  Text='<%# Eval("RoomId") %>' />
                               
                                                    </div>
                             </div>
                             </div>
                         </div>
                            <div  class="col-lg-12" style="border:thin;color:orange;width:1200px" >
                         <div class="row"> 
                             <asp:DataList ID="BedDataList" runat="server" Width="1200px"  DataKeyField="BedId"  RepeatColumns="5" RepeatDirection="Horizontal" OnEditCommand="BedDataList_EditCommand" OnItemDataBound="BedDataList_ItemDataBound" OnItemCommand="BedDataList_ItemCommand">
                                 <ItemStyle  Font-Bold="True" BorderColor="#0066FF" BorderStyle="Solid" BorderWidth="1px" />
                                 <ItemTemplate>
                                     <div class="box">
                                         <div class="box-body">
                                             <div class="col-lg-12" style="border:thin;color:black;width:200px;height:75px">
                                                 <div class="row">
                                                     <div class="col-lg-1 text-left" style="width:230px">
                                                         <div class="form-group">
                                                             <asp:Label ID="lblBedName" runat="server" Text='<%# Eval("BedName") %>' />
                                                             <asp:HiddenField ID="hdnPatRegId" runat="server" Value='<%# Eval("PatRegId") %>' />
                                                             <asp:HiddenField ID="hdnIpdNo" runat="server" Value='<%# Eval("IpdNo") %>' /> 
                                                              <asp:HiddenField ID="hdnIpdId" runat="server" Value='<%# Eval("IpdId") %>' />                                                              
                                                             <asp:Label ID="lblIsAdmited" runat="server" Visible="false" Text='<%# Eval("PatStatus") %>' />
                                                              <asp:HiddenField ID="hdn_IsUniversalPrecaution" runat="server" Value='<%# Eval("IsUniversalPrecaution") %>' /> 
                                                                <asp:Label ID="lblRegId" runat="server" Visible="false" Text = '<%# Eval("PatRegId") %>' /> 
                                                              <asp:Label ID="lblPatientName" runat="server" Width="200px" Text='<%# Eval("FullName") %>' />
                                                          
                                                              
                                                              </div>
                                                     </div>
                                                     </div>
                                                
                                                    
                                                     <div class="row">
                                                         <div class="col-lg-1 text-left" style="width:250px" >
                                                            
                                                              <asp:ImageButton ID="btnpanic"  class="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                                                              <asp:ImageButton ID="btnAdmit" runat="server" Width="50px" ImageUrl="~/Images0/Admit.png" ToolTip="Patient Admit" CommandName="Edit"  
                                                               Text="Admit" />
                                                              <asp:ImageButton ID="btnEdit" runat="server"  Width="30px" ToolTip="Demography Edit" ImageUrl="~/Images0/Admitted.png" Visible="false" CommandName="EditInfo"  
                                                               Text="Edit" />
                                                              <asp:ImageButton ID="btnShift" runat="server"  Width="30px" ToolTip="Shift" Visible="false" ImageUrl="~/Images0/ShiftPatient.jpg" CommandName="Shift" OnClientClick = "return confirm('Are you sure you want to Shift this Patient?');"  
                                                               Text="Shift" />
                                                            
                                                              <asp:ImageButton ID="btnDischarge" runat="server"  Width="30px"  Visible="false" ImageUrl="~/Images0/Discharge.jpg" CommandName="Discharge" 
                                                               Text="Discharge" OnClick="btnDischarge_Click" ToolTip="Discharge" OnClientClick = "return confirm('Are you sure you want to Discharge this Patient?');" />
                                                             <asp:ImageButton ID="btnFrontSheet" runat="server" ToolTip="FrontsheetReport" ImageUrl="~/Images0/FrontReport.png" AutoPostBack="true" Width="25px" Visible="false" CommandName="Report"   onclientclick="target = '_blank';"
                                                               Text="FrontSheet" />
                                                            
                                                         </div>
                                                     </div>
                                                
                                             </div>
                                         </div>
                                     </div>
                                 </ItemTemplate>
                             </asp:DataList>
                         </div>
                         </div>
                                                        
                <div  class="col-lg-12" >
                         <div class="row">
                             </div>
                   </div>

                   </div>
                         </div>

                </ItemTemplate>

            </asp:DataList>
                                        </div>
                                              </div>
                                        
                                        
                                     </div>
                                     </div>

                                         
                                     
                                </div>
               
                 
                                 
                 
                        </section>
                <!-- /.content -->
            </div>
            <!-- /.content-wrapper -->
            <footer class="main-footer text-center">
                <strong>Copyright ©2019 Era InfoSoft.  <a href="#">All rights reserved.</a>.</strong> All rights reserved.
            </footer>
        </div>
        </div>
        <!-- ./wrapper -->
        <script src="plugins/jquery/jquery.min.js"></script>
        <script src="plugins/jquery-ui/jquery-ui.min.js"></script>
        <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
        <script>
            $.widget.bridge('uibutton', $.ui.button);
        </script>
        <!-- Bootstrap 3.3.7 -->
        <script src="plugins/bootstrap/js/bootstrap.min.js"></script>
        <!-- datepicker -->
        <script src="plugins/datepicker/js/bootstrap-datepicker.min.js"></script>
        <script src="plugins/theme/js/theme.min.js"></script>
         <asp:hiddenfield id="ValueHiddenField" runat="server" value="" />
   <script src="plugins/Emergency.js"></script>
        <script>
            $(document).ready(function () {
                var speed = 500;
                function effectFadeIn(classname) {
                    $("." + classname).fadeOut(speed).fadeIn(speed, effectFadeOut(classname))
                }
                function effectFadeOut(classname) {
                    $("." + classname).fadeIn(speed).fadeOut(speed, effectFadeIn(classname))
                }
                //Calling fuction on pageload
                $(document).ready(function () {
                    effectFadeIn('flashingTextcss');
                });
            });
  </script>   
    </form>
</body>
</html>
