<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IPDDesk.aspx.cs" Inherits="IPDDesk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>IPD DESK  </title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <link href="cssmain/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="cssmain/master.css" />
    <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css" />
    <link href="cssmain/main.min.css" rel="stylesheet" />
    <link href="plugins/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link rel="stylesheet" href="plugins/theme/css/theme.min.css">
    <link href="cssmain/themify-icons/css/themify-icons.css" rel="stylesheet" />
    <link href="cssmain/glyphicon.css" rel="stylesheet" type="text/css" />

    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />

    <link rel="stylesheet" href="customTheme/css/customTheme.css" />
    <link rel="stylesheet" href="customTheme/css/CustomGridstyle25.css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
            <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->

    <!--  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"> -->
    <!--  <style type="text/css">
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
    </style>-->
    <link rel="stylesheet" href="customTheme/css/customTheme.css"/>
    <link rel="stylesheet" href="customTheme/css/CustomGridstyle25.css"/>
</head>
<body class="fixed-navbar has-animation bluetheme" id="bodyWrapper">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptmanager" runat="server">
        </asp:ScriptManager>
        <div class="regular">

            <div class="wrapper">
                <!--header class="header">
                    <div class="page-brand p-1 align-self-center">
                        <a class="link" href="index.html">
                            <span class="brand">
                                <span class="brand-tip text-center">
                                    <asp:Label ID="LblDCName" runat="server" Text=" "></asp:Label>
                                </span>
                            </span>
                            <span class="brand-mini">
                                <asp:Label ID="LblDCCode" runat="server" Text=" "> </asp:Label>
                            </span>
                        </a>
                    </div>

                    < !-- Header Navbar: style can be found in header.less -- >
                    <div class="flex-1 colorTheme">
                        < !-- START TOP-LEFT TOOLBAR-- >
                        <div class="d-flex justify-content-between bd-highlight p-1">
                            <div class="align-self-center"><a class="nav-link sidebar-toggler js-sidebar-toggler"><i class="ti-menu"></i></a></div>
                            <div class="col text-center align-self-center mobile-v">BramhaMediTech Softwares</div>
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
                                            <a href="ChangePassword.aspx">
                                                <i class="fa fa-fw fa-key"></i>
                                            </a>
                                        </li>
                                        <li>
                                            <%--<a href="Login.aspx" class="dropdown-toggle" data-toggle="dropdown">
                                    <i class="fa fa-fw fa-power-off"></i>
                                </a>--%>
                                            <a href="Login.aspx">
                                                <i class="fa fa-fw fa-power-off"></i>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                    </div>
                </header-->
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
                            <div class="user-img"><img src="customTheme/images/profile.png" alt="user"></div>
                            <div class="user-content" id="userMenu">
                                <h6>Ava Davis</h6>
                                <p class="mb-0">Admin<i class="fa-solid fa-chevron-down"></i></p>
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
                                </svg><a class="ms-2" href="ChangePassword.aspx">Change Password</a>
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
                        <div class="admin-block d-flex d-none">
                            <div>
                                <img src="images/admin-avatar.png" width="45px" />
                            </div>
                            <div class="admin-info">
                                <p>
                                    <asp:Label ID="LUNAME" runat="server" Text=""></asp:Label></p>
                                <a href="#"><i class="fa fa-circle text-success"></i>Admin</a>

                            </div>
                        </div>
                        <ul class="side-menu metismenu">
                            <%-- <li>
                        <a class="active" href="Home.aspx"><i class="sidebar-item-icon fa fa-th-large"></i>
                            <span class="nav-label">Dashboard</span>
                        </a>
                    </li>--%>
                            <li class="nav-label">
                                <asp:TreeView ID="TrMenu" Visible="true" runat="server" ExpandDepth="1"
                                    OnSelectedNodeChanged="TrMenu_SelectedNodeChanged">
                                </asp:TreeView>
                            </li>
                        </ul>
                    </div>

                </nav>
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
                            <!--  <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            </div>-->
                            <div class="box-body">
                                <div class="row">
                                    <div id="ShiftingDetails" runat="server" visible="false">
                                        <div class="col-lg-12">
                                            <div class="row">
                                                <div class="col-sm-3 text-left">
                                                    <div class="form-group">
                                                        <label for="txtshiftReason">Reason For Shifting</label>
                                                    </div>
                                                </div>
                                                <div class="col-sm-2  text-left">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtshiftReason" runat="server" class="form-control" placeholder="Enter Reason" TabIndex="9" Width="390px"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="Div3" class="col-lg-12 bg-light p-3" runat="server">
                                        <div class="row">
                                            <div class="col-sm-2">
                                                <div class="card mb-3" style="max-width: 540px;">
                                                    <div class="ipdDeskCards">
                                                        <asp:ImageButton ID="btnAdmit1" runat="server" Width="50" ImageUrl="~/Images0/Admit.png" ToolTip="Patient Admit" Text="Admit" />
                                                        <div class="card-body">
                                                            <h4 class="card-title mt-2"><asp:Label ID="Label2" runat="server" CssClass="h4 bd-brand-logos" Text="Admit:"></asp:Label></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="card mb-3" style="max-width: 540px;">
                                                    <div class="ipdDeskCards">
                                                        <asp:ImageButton ID="btnEdit1" runat="server" Width="30" ToolTip="Demography Edit" ImageUrl="~/Images0/Admitted.png" Text="Edit" style="width: 40px !important; margin: 0 0 0 20px;" />
                                                        <div class="card-body">
                                                            <h4 class="card-title mt-2"><asp:Label ID="Label3" runat="server" CssClass="h4 bd-brand-logos" Text="Demography:"></asp:Label></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="card mb-3" style="max-width: 540px;">
                                                    <div class="ipdDeskCards">
                                                        <asp:ImageButton ID="btnShift1" runat="server" Width="30" ToolTip="Shift" ImageUrl="~/Images0/ShiftPatient.jpg" Text="Shift" style="width: 40px !important; margin: 0 0 0 20px;" />
                                                        <div class="card-body">
                                                            <h4 class="card-title mt-2"><asp:Label ID="Label4" runat="server" CssClass="h4 bd-brand-logos" Text="Shift:"></asp:Label></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="card mb-3" style="max-width: 540px;">
                                                    <div class="ipdDeskCards">
                                                        <asp:ImageButton ID="btnDischarge1" runat="server" Width="30" ImageUrl="~/Images0/Discharge.jpg" Text="Discharge" ToolTip="Discharge" style="width: 40px !important; margin: 0 0 0 20px;" />
                                                        <div class="card-body">
                                                            <h5 class="card-title mt-2"><asp:Label ID="Label5" runat="server" CssClass="h4 bd-brand-logos" Text="Discharge:"></asp:Label></h5>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="card mb-3" style="max-width: 540px;">
                                                    <div class="ipdDeskCards">
                                                        <asp:ImageButton ID="btnFrontSheet1" runat="server" ToolTip="FrontsheetReport" Width="30" ImageUrl="~/Images0/FrontReport.png" Text="FrontSheet" style="width: 30px !important; height: 70px; margin: 0 0 0 20px;" />
                                                        <div class="card-body">
                                                            <h4 class="card-title mt-2"><asp:Label ID="Label6" runat="server" CssClass="h4 bd-brand-logos" Text="Report:"></asp:Label></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="card mb-3" style="max-width: 540px;">
                                                    <div class="ipdDeskCards">
                                                        <asp:ImageButton ID="btnpanic1" class="flashingTextcss" Width="30" ImageUrl="~/images/light-311119__340.png" runat="server" style="width: 30px !important; margin: 0 0 0 20px; height: 70px;"></asp:ImageButton>
                                                        <div class="card-body">
                                                            <h4 class="card-title mt-2"><asp:Label ID="Label7" runat="server" CssClass="h4 bd-brand-logos" Text="Precaution:"></asp:Label></h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="Div1" class="col-lg-12 mt-3" runat="server">
                                        <div class="row">
                                            <div class="col-sm-4 text-left">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None" CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                        AutoPostBack="True" OnTextChanged="txtPatientName_TextChanged" onkeyPress="return alpha_only(event);"></asp:TextBox>
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
                                                        runat="server">
                                                        <%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                    </asp:AutoCompleteExtender>
                                                </div>

                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">


                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary btnSearch" OnClick="btnSearch_Click" />
                                                </div>

                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <asp:Label ID="Lmsg" runat="server" ForeColor="Red" Text="" Font-Bold="true"></asp:Label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 mt-3" runat="server" visible="false">

                                        <div class="row">


                                            <div class="col-lg-12">
                                                <div class="form-group form-check" style="border: solid; color: orange; background-color: white; width: 1200px; height: 90px;">



                                                    <asp:RadioButtonList ID="RdbRoomType" runat="server" ForeColor="Black" Font-Size="Larger" Font-Bold="true" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbRoomType_SelectedIndexChanged" RepeatColumns="9">
                                                    </asp:RadioButtonList>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="form-group">
                                                <div class="table-responsive">
                                                    <asp:DataList ID="RoomsDataList" runat="server" DataKeyField="RoomId" OnItemDataBound="RoomsDataList_ItemDataBound" class="table table-striped" Width="100%">

                                                        <ItemTemplate>
                                                            <div class="box">
                                                                <div class="box-body">


                                                                    <div class="col-lg-12 bg-info text-dark p-2">
                                                                        <div class="row">

                                                                            <div class="col-sm-2 text-right">
                                                                                <div class="form-group">
                                                                                    <%-- <centerlabel  style="text-align:center" > Room Name:</label> --%>
                                                                                    <asp:Label ID="Label1" runat="server" Text="Room Name:" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-sm-2 text-left">
                                                                                <div class="form-group">
                                                                                    <asp:Label ID="lblRoomName" runat="server" Text='<%# Eval("RoomName") %>' />
                                                                                    <asp:Label ID="lblroomId" runat="server" Visible="false" Text='<%# Eval("RoomId") %>' />

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-12 mt-3">
                                                                        <div class="row">
                                                                            <div class="form-group">
                                                                                <div class="table-responsive">
                                                                                    <asp:DataList ID="BedDataList" runat="server" DataKeyField="BedId" RepeatColumns="4" RepeatDirection="Horizontal" OnEditCommand="BedDataList_EditCommand" OnItemDataBound="BedDataList_ItemDataBound" OnItemCommand="BedDataList_ItemCommand" class="table table-striped" Width="100%">
                                                                                        <ItemStyle />
                                                                                        <ItemTemplate>
                                                                                            <div class="box deskCardWrapper">
                                                                                                <div class="box-body">
                                                                                                    <div class="col-sm-12">
                                                                                                        <div class="row">
                                                                                                            <div>
                                                                                                                <div class="form-group">
                                                                                                                    <asp:Label ID="lblBedName" class="bedNameWrapper" runat="server" Text='<%# Eval("BedName") %>' />
                                                                                                                    <asp:HiddenField ID="hdnPatRegId" runat="server" Value='<%# Eval("PatRegId") %>' />
                                                                                                                    <asp:HiddenField ID="hdnIpdNo" runat="server" Value='<%# Eval("IpdNo") %>' />
                                                                                                                    <asp:HiddenField ID="hdnIpdId" runat="server" Value='<%# Eval("IpdId") %>' />
                                                                                                                    <asp:Label ID="lblIsAdmited" runat="server" Visible="false" Text='<%# Eval("PatStatus") %>' />
                                                                                                                    <asp:HiddenField ID="hdn_IsUniversalPrecaution" runat="server" Value='<%# Eval("IsUniversalPrecaution") %>' />
                                                                                                                    <asp:Label ID="lblRegId" runat="server" Visible="false" Text='<%# Eval("PatRegId") %>' />
                                                                                                                    <asp:Label ID="lblPatientName" runat="server" Width="250px" Text='<%# Eval("FullName") %>' />


                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>


                                                                                                        <div class="row mt-3">
                                                                                                            <div class="col-lg-12 text-left">

                                                                                                                <asp:ImageButton ID="btnpanic" class="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                                                                                                                <asp:ImageButton ID="btnAdmit" runat="server" Width="50px" ImageUrl="~/Images0/Admit.png" ToolTip="Patient Admit" CommandName="Edit"
                                                                                                                    Text="Admit" />
                                                                                                                <asp:ImageButton ID="btnEdit" runat="server" Width="30px" ToolTip="Demography Edit" ImageUrl="~/Images0/Admitted.png" Visible="false" CommandName="EditInfo"
                                                                                                                    Text="Edit" />
                                                                                                                <asp:ImageButton ID="btnShift" runat="server" Width="30px" ToolTip="Shift" Visible="false" ImageUrl="~/Images0/ShiftPatient.jpg" CommandName="Shift" OnClientClick="return confirm('Are you sure you want to Shift this Patient?');"
                                                                                                                    Text="Shift" />

                                                                                                                <asp:ImageButton ID="btnDischarge" runat="server" Width="30px" Enabled="false" Visible="false" ImageUrl="~/Images0/Discharge.jpg" CommandName="Discharge"
                                                                                                                    Text="Discharge" OnClick="btnDischarge_Click" ToolTip="Discharge" OnClientClick="return confirm('Are you sure you want to Discharge this Patient?');" />
                                                                                                                <asp:ImageButton ID="btnFrontSheet" runat="server" ToolTip="FrontsheetReport" ImageUrl="~/Images0/FrontReport.png" AutoPostBack="true" Width="25px" Visible="false" CommandName="Report"
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
                            </div>



                        </div>




                    </section>
                    <!-- /.content -->
                </div>
                <!-- /.content-wrapper -->
                <footer class="main-footer text-center">
                    <strong>Copyright ©2019 BramhaMediTech.  <a href="#">All rights reserved.</a>.</strong> All rights reserved.
                </footer>
            </div>
        </div>
        <!-- ./wrapper -->
        <script src="jsmain/jquery.min.js" type="text/javascript"></script>
        <script src="jsmain/bootstrap.bundle.min.js" type="text/javascript"></script>
        <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
        <script>
            $.widget.bridge('uibutton', $.ui.button);
        </script>


        <!-- datepicker -->
        <script src="plugins/datepicker/js/bootstrap-datepicker.min.js"></script>
        <script src="plugins/theme/js/theme.min.js"></script>
        <asp:HiddenField ID="ValueHiddenField" runat="server" Value="" />
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
        <script language="javascript" type="text/javascript">
            function OpenReport() {
                window.open("Reports.aspx");
            }
        </script>
        <script type="text/javascript">
            $('#notificationMenu').on('click', function () {
                $('#notificationMenuWrapper').toggleClass('show');
                e.preventDefault();
            });
            $('#userMenu').on('click', function () {
                $('#userMenuWrapper').toggleClass('show');
                e.preventDefault();
            });
            $('#toggleMenu').on('click', function () {
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
        </script>
        <!--Left Sidebar SCRIPTS-->
        <script src="jsmain/metisMenu/dist/metisMenu.min.js" type="text/javascript"></script>
        <script src="jsmain/app.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
