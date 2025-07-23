<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeTemp.aspx.cs" Inherits="HomeTemp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <style>
        paging {
        padding: 0px 6px;
    background-color: #38c8dd;
    color: #fff;
    border: 3px solid #fff;
        }

    </style>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title></title>

    <script src="amcharts/amcharts.js" type="text/javascript"></script>
    <script src="amcharts/serial.js" type="text/javascript"></script>
    <script type="text/javascript" src="amcharts/pie.js"></script>
    <script type="text/javascript" src="amcharts/themes/light.js"></script>
   
   <%-- <script type="text/javascript" src="js/bootstrap-datepicker.js"></script>
    <link href="css/bootstrap-datepicker.css"  rel="stylesheet" />--%>
    <!--<link href="css1/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="css1/bootstrap.min.css" rel="stylesheet" type="text/css" />-->
  <%--  <script src="js0/bootstrap.js" type="text/javascript"></script>
    <script src="js0/bootstrap.min.js" type="text/javascript"></script>--%>


  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
        <!-- GLOBAL MAINLY STYLES-->
    <link href="cssmain/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="cssmain/master.css"/>
    <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css"/>
    <link href="cssmain/main.min.css" rel="stylesheet" />
        <!--<link rel="stylesheet" href="css/style.css"/>-->
        <link href="plugins/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet"  />
        <link rel="stylesheet" href="plugins/theme/css/theme.min.css">
     <link href="cssmain/themify-icons/css/themify-icons.css" rel="stylesheet" />
      <link href="cssmain/glyphicon.css" rel="stylesheet" type="text/css" />
        <%--<link href="App_Themes/Default/GVCss.css" rel="stylesheet" type="text/css" />--%>
       <link href="css/bootstrap-datepicker.css"  rel="stylesheet" />  
</head>
<body class="fixed-navbar has-animation bluetheme">
    <form id="form1" runat="server">
   <%-- <script src="fusioncharts/FusionCharts.js" type="text/javascript"></script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="regular">
        <div class="wrapper">
         <header class="header">

            <div class="page-brand p-1 align-self-center">
                <a class="link" href="index.html">
                    <span class="brand"> 
                        <span class="brand-tip text-center">HIS Management System</span>
                    </span>
                    <span class="brand-mini">HIS</span>
                </a>
            </div>
            <div class="flex-1 colorTheme">
                <!-- START TOP-LEFT TOOLBAR-->
                <div class="d-flex justify-content-between bd-highlight p-1">
                    <div class="align-self-center"><a class="nav-link sidebar-toggler js-sidebar-toggler"><i class="ti-menu"></i></a></div>
                    <div class="col text-center align-self-center mobile-v">  Hospital Information Management System</div>
                    <div class="p-2">
                         <div class="navbar-custom-menu">
                        <ul class="nav navbar-nav">
                           
                            <li class="dropdown tasks-menu">
                                
                               <%-- <a href="Login.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-fw fa-sign-in"></i>
                                </a>--%>

                                 <a href="Home.aspx">
                                   <%-- <i class="fa fa-fw fa-sign-in"></i>--%>
                                      <i class="fa fa-fw fa-home"></i>
                                </a>


                               
                                 
                            </li>
                              <li>
                                <%--<a href="Login.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-fw fa-power-off"></i>
                                </a>--%>
                                <a  href="ChangePassword.aspx">
                                    <i class="fa fa-fw fa-key"></i>
                                </a>
                            </li>
                            <li>
                                <%--<a href="Login.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-fw fa-power-off"></i>
                                </a>--%>
                                <a href="Login.aspx" >
                                    <i class="fa fa-fw fa-power-off"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    </div>
                </div>
                
            </div>
        </header>
            <!-- Left side column. contains the logo and sidebar -->
          <nav class="page-sidebar" id="sidebar">
            <div id="sidebar-collapse">
                <div class="admin-block d-flex">
                    <div>
                        <img src="images/admin-avatar.png" width="45px" />
                    </div>
                    <div class="admin-info">
                        <div class="font-strong"><asp:Label ID="UsernameLB2" runat="server" Text=""></asp:Label></div><small></small></div>
                </div>
                <ul class="side-menu metismenu">
                    <li>
                        <a class="active" href="Home.aspx"><i class="sidebar-item-icon fa fa-th-large"></i>
                            <span class="nav-label">Dashboard</span>
                        </a>
                    </li>
                    <asp:PlaceHolder ID="SlidBarHolder" runat="server"></asp:PlaceHolder>
                </ul>
            </div>
        </nav>
            <!-- Content Wrapper. Contains page content -->
           <%-- <div class="content-wrapper">
                <!-- Main content -->
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Total number of patients daywise</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                             <div class="col-md-5">
                                 </div>
                            <div class="col-md-3">
                                 <input type="text" class="form-control"  id="txtCenterName" />
                            </div>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="datepicker11" />
                            </div>
                            <div class="col-md-2">
                                <input type="text" class="form-control" id="datepicker1" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="chart">
                                    <div id="chartdiv11" style="width: 100%; height: 400px; background-color: #FFFFFF;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-footer" style="">
                    </div>
                </div>
                <div class="box" hidden="hidden">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Total number of patients daywise</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-9">
                            </div>
                            <div class="col-md-2">
                                <select name="months" class="months1 form-control" id="months2">
                                    <option value="1">January</option>
                                    <option value="2">February</option>
                                    <option value="3">March</option>
                                    <option value="4">April</option>
                                    <option value="5">May</option>
                                    <option value="6">June</option>
                                    <option value="7">July</option>
                                    <option value="8">August</option>
                                    <option value="9">September</option>
                                    <option value="10">October</option>
                                    <option value="11">November</option>
                                    <option value="12">December</option>
                                </select>
                            </div>
                            <div class="col-md-1">
                                <input type="text" class="form-control" id="datepicker2" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="chart">
                                    <div id="chartdiv12" style="width: 100%; height: 400px; background-color: #FFFFFF;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-footer" style="">
                    </div>
                </div>
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Total patients by department</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-9">
                            </div>
                            <div class="col-md-2">
                                <select name="months3" class="months3 form-control" id="months3">
                                    <option value="1">January</option>
                                    <option value="2">February</option>
                                    <option value="3">March</option>
                                    <option value="4">April</option>
                                    <option value="5">May</option>
                                    <option value="6">June</option>
                                    <option value="7">July</option>
                                    <option value="8">August</option>
                                    <option value="9">September</option>
                                    <option value="10">October</option>
                                    <option value="11">November</option>
                                    <option value="12">December</option>
                                </select>
                            </div>
                            <div class="col-md-1">
                                <input type="text" class="form-control" id="datepicker3" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="chart">
                                    <div id="chartdiv13" style="width: 100%; height: 400px; background-color: #FFFFFF;">
                                    </div>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                    <div class="box-footer" style="">
                    </div>
                    <!-- /.box-footer -->
                </div>
                <div class="box col-md-6">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Top 5 Referal Doctors</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-3">
                                <select name="months" class="months4 form-control" id="months4">
                                    <option value="1">January</option>
                                    <option value="2">February</option>
                                    <option value="3">March</option>
                                    <option value="4">April</option>
                                    <option value="5">May</option>
                                    <option value="6">June</option>
                                    <option value="7">July</option>
                                    <option value="8">August</option>
                                    <option value="9">September</option>
                                    <option value="10">October</option>
                                    <option value="11">November</option>
                                    <option value="12">December</option>
                                </select>
                            </div>
                            <div class="col-md-3">
                                <input type="text" class="form-control" id="datepicker4" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="chart">
                                    <div id="chartdiv14" style="width: 100%; height: 400px; background-color: #FFFFFF;">
                                    </div>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                    <div class="box-footer" style="">
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- /.content -->
            </div>--%>
            <!-- /.content-wrapper -->
            <footer class="main-footer text-center">
                <strong>Copyright &copy; 2017 <a href="#">ERA Infotech </a>.</strong> All rights reserved.
            </footer>
        </div>
    </div>
  <%--  <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Page level plugin JavaScript-->
    <script src="vendor/chart.js/Chart.min.js"></script>--%>
    <!-- Custom scripts for all pages-->
  <%--  <script src="js9/sb-admin.min.js"></script>--%>
    <!-- Custom scripts for this page-->
   <%-- <script src="js9/sb-admin-charts.min.js"></script>--%>
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
    <script type="text/javascript">
        //Date picker
        $('#fromdate, #todate').datepicker({
            autoclose: true
        })
    </script>
    <script language="javascript" type="text/javascript">
        function OpenReport() {
            window.open("Reports.aspx");
        }
    </script>
    <script src="js0/bootstrap.js" type="text/javascript"></script>
    <script src="js0/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="js0/5.js" type="text/javascript"></script>
    <script src="js0/6.js" type="text/javascript"></script>
    <script src="js0/7.js" type="text/javascript"></script>
     <link href="css1/13.css" rel="stylesheet" type="text/css" />
      

    <!--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css"
        rel="stylesheet" />
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"
        rel="stylesheet" /> -->
   
    </form>
      <!-- CORE PLUGINS-->
   <%-- <script src="./assets/vendors/jquery/dist/jquery.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/popper.js/dist/umd/popper.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/metisMenu/dist/metisMenu.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <!-- PAGE LEVEL PLUGINS-->
    <script src="./assets/vendors/chart.js/dist/Chart.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/jvectormap/jquery-jvectormap-2.0.3.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/jvectormap/jquery-jvectormap-world-mill-en.js" type="text/javascript"></script>
    <script src="./assets/vendors/jvectormap/jquery-jvectormap-us-aea-en.js" type="text/javascript"></script>
    <!-- CORE SCRIPTS-->
    <script src="./assets/js/app.min.js" type="text/javascript"></script>
    <!-- PAGE LEVEL SCRIPTS-->
    <script src="./assets/js/scripts/dashboard_1_demo.js" type="text/javascript"></script>


      <script src="./assets/vendors/select2/dist/js/select2.full.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/jquery-knob/dist/jquery.knob.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/moment/min/moment.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
    <script src="./assets/vendors/jquery-minicolors/jquery.minicolors.min.js" type="text/javascript"></script>--%>
        <!--Left Sidebar SCRIPTS-->
    <script src="jsmain/metisMenu/dist/metisMenu.min.js" type="text/javascript"></script>
    <script src="jsmain/app.min.js" type="text/javascript"></script>

</body>
</html>
