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
      <link rel="stylesheet" href="customTheme/css/fontawesome-min.css"/>
        <link rel="stylesheet" href="customTheme/css/customTheme.css"/>
        <link rel="stylesheet" href="customTheme/css/CustomGridstyle25.css"/>
</head>
<body class="fixed-navbar has-animation bluetheme collapsed" id="bodyWrapper">
    <form id="form1" runat="server">
   <%-- <script src="fusioncharts/FusionCharts.js" type="text/javascript"></script>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="regular">
        <div class="wrapper">
      <header class="page-header row">
          <div class="logo-wrapper d-flex align-items-center col-auto">
            <a href="Home.aspx">
              <img class="light-logo img-fluid" src="customTheme/brahmaMedical.png" width="130px" alt="logo">
              <img class="dark-logo img-fluid" src="customTheme/brahmaMedical.png" width="130px" alt="logo"></a><a class="close-btn toggle-sidebar" href="javascript:void(0)">
              <svg class="svg-color" id="toggleMenu">
                <use href="customTheme/svg/iconly-sprite.svg#Category"></use>
              </svg>
            </a>
          </div>
          <div class="page-main-header col">
            <div class="header-left">
              <div class="form-group-header d-lg-block d-none">
                <div class="Typeahead Typeahead--twitterUsers">
                  <div class="u-posRelative d-flex align-items-center"> 
                    <input class="demo-input py-0 Typeahead-input form-control-plaintext w-100" type="text" placeholder="Type to Search..." name="q" title=""><i class="search-bg iconly-Search icli"></i>
                  </div>
                </div>
              </div>
            </div>
            <div class="nav-right">
              <ul class="header-right"> 
                <li class="search d-lg-none d-flex"> <a href="javascript:void(0)">
                  <svg>
                    <use href="customTheme/svg/iconly-sprite.svg#Search"></use>
                  </svg></a>
                </li>
                <li>
                  <a class="dark-mode" href="javascript:void(0)">
                    <svg>
                      <use href="customTheme/svg/iconly-sprite.svg#moondark"></use>
                    </svg></a>
                </li>
                <li class="custom-dropdown">
                    <a href="javascript:void(0)" id="notificationMenu">
                        <svg>
                            <use href="customTheme/svg/iconly-sprite.svg#notification"></use>
                        </svg>
                    </a>
                    <span class="badge rounded-pill badge-primary">4</span>
                    <div class="custom-menu notification-dropdown py-0 overflow-hidden" id="notificationMenuWrapper">
                        <h3 class="title bg-primary-light dropdown-title">Notification <span class="font-primary">View all</span></h3>
                        <ul class="activity-timeline">
                            <li class="d-flex align-items-start">
                              <div class="activity-line"></div>
                              <div class="activity-dot-primary"></div>
                              <div class="flex-grow-1">
                                <h6 class="f-w-600 font-primary">30-04-2024<span>Today</span><span class="circle-dot-primary float-end">
                                    <svg class="circle-color">
                                      <use href="../assets/svg/iconly-sprite.svg#circle"></use>
                                    </svg></span></h6>
                                <h5>Alice Goodwin</h5>
                                <p class="mb-0">Fashion should be fun. It shouldn't be labelled intellectual.</p>
                              </div>
                            </li>
                            <li class="d-flex align-items-start">
                                <div class="activity-dot-secondary"></div>
                                <div class="flex-grow-1">
                                    <h6 class="f-w-600 font-secondary">28-06-2024<span>1 hour ago</span><span class="float-end circle-dot-secondary">
                                      <svg class="circle-color">
                                        <use href="../assets/svg/iconly-sprite.svg#circle"></use>
                                      </svg></span>
                                    </h6>
                                    <h5>Herry Venter</h5>
                                    <p>I am convinced that there can be luxury in simplicity.</p>
                                </div>
                            </li>
                            <li class="d-flex align-items-start">
                                <div class="activity-dot-primary"></div>
                                <div class="flex-grow-1">
                                  <h6 class="f-w-600 font-primary">04-08-2024<span>Today</span><span class="float-end circle-dot-primary">
                                      <svg class="circle-color">
                                        <use href="../assets/svg/iconly-sprite.svg#circle"></use>
                                      </svg></span>
                                  </h6>
                                  <h5>Loain Deo</h5>
                                  <p>I feel that things happen for open new opportunities.</p>
                                </div>
                            </li>
                            <li class="d-flex align-items-start">
                                <div class="activity-dot-secondary"></div>
                                <div class="flex-grow-1">
                                  <h6 class="f-w-600 font-secondary">12-11-2024<span>Yesterday</span><span class="float-end circle-dot-secondary">
                                      <svg class="circle-color">
                                        <use href="../assets/svg/iconly-sprite.svg#circle"></use>
                                      </svg></span>
                                  </h6>
                                  <h5>Fenter Jessy</h5>
                                  <p>Sometimes the simplest things are the most profound.</p>
                                </div>
                            </li>
                        </ul>
                    </div>
                </li>
                <li>
                  <a class="full-screen" href="javascript:void(0)"> 
                    <svg>
                      <use href="customTheme/svg/iconly-sprite.svg#scanfull"></use>
                    </svg>
                  </a>
                </li>
                <li class="profile-nav custom-dropdown">
                  <div class="user-wrap">
                    <div class="user-img"><img src="customTheme/images/DrProfile.jpg" alt="user"></div>
                    <div class="user-content" id="userMenu">
                      <h6>Welcome, <%= Session["username"] %></h6>
                      <p class="mb-0"><%= Session["usertype"] %><i class="fa-solid fa-chevron-down"></i></p>
                    </div>
                  </div>
                  <div class="custom-menu overflow-hidden" id="userMenuWrapper">
                    <ul class="profile-body">
                      <li class="d-flex"> 
                        <svg class="svg-color">
                          <use href="customTheme/svg/iconly-sprite.svg#Profile"></use>
                        </svg><a class="ms-2" href="Home.aspx">Home</a>
                      </li>
                      <li class="d-flex"> 
                        <svg class="svg-color">
                          <use href="customTheme/svg/iconly-sprite.svg#Document"></use>
                        </svg><a class="ms-2" href="#">Change Password</a>
                      </li>
                      <li class="d-flex"> 
                        <svg class="svg-color">
                          <use href="customTheme/svg/iconly-sprite.svg#Login"></use>
                        </svg><a class="ms-2" href="login.aspx">Log Out</a>
                      </li>
                    </ul>
                  </div>
                </li>
              </ul>
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
                 <ul class="subMenuWrapper nav-2-level" id="subMenuWrapper"></ul>
                <ul class="side-menu metismenu">
                    <li>
                        <a class="active" href="HomeTemp.aspx"><i class="sidebar-item-icon fa fa-th-large"></i>
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
                <strong>Copyright &copy; 2017 <a href="#">BramhaMediTech </a>.</strong> All rights reserved.
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
   <script type="text/javascript">
       $(document).ready(function () {


           $('#userMenu').on('click', function () {
               $('#userMenuWrapper').toggleClass('show');
               e.preventDefault();
           });
           $(document).ready(function () {
               if (localStorage.getItem('sidebarMenuToggle') && localStorage.getItem('sidebarMenuToggle') != 'true') {
                   $('#bodyWrapper').toggleClass('collapsed');
               }
           });
           $('#toggleMenu').on('click', function () {
               localStorage.setItem('sidebarMenuToggle', '' + $('#bodyWrapper').hasClass('collapsed'));
               $('#bodyWrapper').toggleClass('collapsed');
               e.preventDefault();
           });
           $(".metismenu > li").on('click', function () {
               // console.log($('.metismenu li.active ul'));
               if ($('.metismenu li.active ul')[0]) {
                   $('#subMenuWrapper').html($('.metismenu li.active ul')[0].innerHTML);
                   if (($('.metismenu li.active ul').closest('li.active').offset().top + $('#subMenuWrapper').height()) > $(window).height()) {
                       $('#subMenuWrapper').css({
                           top: $('.metismenu li.active ul').closest('li.active').offset().top - 25 - $('#subMenuWrapper').height(),
                           left: $('.metismenu li.active ul').closest('li.active').offset().left + 105
                       });
                   } else {
                       $('#subMenuWrapper').css({
                           top: $('.metismenu li.active ul').closest('li.active').offset().top - 75,
                           left: $('.metismenu li.active ul').closest('li.active').offset().left + 105
                       });
                   }
               } else {
                   $('#subMenuWrapper').html('');
                   $('#subMenuWrapper').css({
                       top: 0,
                       left: 0
                   });
               }
               // e.preventDefault();
           });
           $(document).on('click', function (e) {
               if (!$(e.target).closest('#subMenuWrapper').length && !$(e.target).closest('.metismenu li.active').length && !$(e.target).closest('.logo-wrapper').length) {
                   $('#subMenuWrapper').html('');
                   $('#subMenuWrapper').css({
                       top: 0,
                       left: 0
                   });
                   $('.metismenu li.active').removeClass('active');
               }
               if (!$(e.target).closest('#notificationMenu').length) {
                   $('#notificationMenuWrapper').removeClass('show');
               }
               if (!$(e.target).closest('#userMenu').length) {
                   $('#userMenuWrapper').removeClass('show');
               }
           });

       });
   </script>
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
