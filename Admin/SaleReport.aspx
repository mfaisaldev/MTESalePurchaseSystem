﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleReport.aspx.cs" Inherits="Admin.SaleReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="cache-control" content="no-cache">
    <meta http-equiv="expires" content="Thu, 19 Nov 1900 08:52:00 GMT">
    <title>Stocks</title>
    <link rel="shortcut icon" href="Content/images/icons/favicon.ico">
    <link rel="apple-touch-icon" href="Content/images/icons/favicon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="Content/images/icons/favicon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="Content/images/icons/favicon-114x114.png">
    <!--Loading bootstrap css-->
    <link type="text/css" rel="stylesheet"
        href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,700">
    <link type="text/css" rel="stylesheet" href="http://fonts.googleapis.com/css?family=Oswald:400,700,300">
    <link type="text/css" rel="stylesheet"
        href="Content/vendors/jquery-ui-1.10.4.custom/css/ui-lightness/jquery-ui-1.10.4.custom.min.css">
    <link type="text/css" rel="stylesheet" href="Content/vendors/font-awesome/css/font-awesome.min.css">
    <link type="text/css" rel="stylesheet" href="Content/vendors/bootstrap/css/bootstrap.min.css">
    <!--LOADING STYLESHEET FOR PAGE-->
    <link type="text/css" rel="stylesheet" href="Content/vendors/jplist/html/css/jplist-custom.css">
    <!--Loading style vendors-->
    <link type="text/css" rel="stylesheet" href="Content/vendors/lightbox/css/lightbox.css">
    <!--Loading style vendors-->
    <link type="text/css" rel="stylesheet" href="Content/vendors/DataTables/media/css/jquery.dataTables.css">
    <link type="text/css" rel="stylesheet"
        href="Content/vendors/DataTables/extensions/TableTools/css/dataTables.tableTools.min.css">
    <link type="text/css" rel="stylesheet" href="Content/vendors/DataTables/media/css/dataTables.bootstrap.css">
    <!--Loading style vendors-->
    <link type="text/css" rel="stylesheet" href="Content/vendors/animate.css/animate.css">
    <link type="text/css" rel="stylesheet" href="Content/vendors/jquery-pace/pace.css">
    <link type="text/css" rel="stylesheet" href="Content/vendors/iCheck/skins/all.css">
    <link type="text/css" rel="stylesheet" href="Content/vendors/bootstrap-daterangepicker/daterangepicker-bs3.css">
    <!--Loading style-->
    <link type="text/css" rel="stylesheet" href="Content/css/themes/style1/orange-blue.css" class="default-style">
    <link type="text/css" rel="stylesheet" href="Content/css/themes/style1/orange-blue.css" id="theme-change"
        class="style-change color-change">
    <link type="text/css" rel="stylesheet" href="Content/css/style-responsive.css">
    <link rel="shortcut icon" href="Content/images/icons/favicon.ico">
    <link rel="apple-touch-icon" href="Content/images/icons/favicon.png">
    <style>
        table, th, td {
   border: 1px solid #0095E7;
}
        .auto-style1 {
            width: 90%;
        }
    </style>
</head>
<body class=" ">
    <div>
        <!--BEGIN BACK TO TOP-->
        <a id="totop" href="#"><i class="fa fa-angle-up"></i></a>
        <div id="header-topbar-option-demo" class="page-header-topbar">
            <nav id="topbar" role="navigation" style="margin-bottom: 0; z-index: 2;"
                class="navbar navbar-default navbar-static-top">
                <div class="navbar-header">
                    <button type="button" data-toggle="collapse" data-target=".sidebar-collapse" class="navbar-toggle">
                        <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                    <a id="logo" href="index.html" class="navbar-brand">
                        <span class="fa fa-rocket"></span><span class="logo-text">ICON</span><span style="display: none" class="logo-text-icon">µ</span>
                    </a>
                </div>
                <div class="topbar-main">
                    <a id="menu-toggle" href="#" class="hidden-xs"><i class="fa fa-bars"></i></a>
                    <ul class="nav navbar navbar-top-links navbar-right mbn">
                        <li class="dropdown topbar-user">
                            <a data-hover="dropdown" href="#" class="dropdown-toggle">
                                <img src="File/GetPicture" height="50" width="50" class="img-responsive img-circle" />Admin</span>&nbsp;<span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu dropdown-user pull-right">
                                <li><a href="Account/Profile"><i class="fa fa-user"></i>My Profile</a></li>
                                <li class="divider"></li>
                                <li><a href="Account/LockScreen"><i class="fa fa-lock"></i>Lock Screen</a></li>
                                <li><a href="Account/LogOff"><i class="fa fa-key"></i>Log Out</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
            <!--BEGIN MODAL CONFIG PORTLET-->
        </div>
        <div id="wrapper">
            <nav id="sidebar" role="navigation" class="navbar-default navbar-static-side">
                <div class="sidebar-collapse menu-scroll">
                    <ul id="side-menu" class="nav">
                        <li class="user-panel">
                            <div class="thumb">
                                <img src="File/GetPicture" height="150" width="150" class="img-circle" />
                            </div>
                            <div class="info">
                                <p>Admin</p>
                                <ul class="list-inline list-unstyled">
                                    <li>
                                        <a href="Account/Profile" data-hover="tooltip" title="Profile">
                                            <i class="fa fa-user"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Account/LogOff" data-hover="tooltip" title="Logout">
                                            <i class="fa fa-sign-out"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="clearfix"></div>
                        </li>
                        <li class="">
                            <a href="Dashboard/Index">
                                <i class="fa fa-tachometer fa-fw">
                                    <div class="icon-bg bg-orange"></div>
                                </i><span class="menu-title">Dashboard</span>
                            </a>
                        </li>
                        <li class="">
                            <a href="#">
                                <i class="fa fa-desktop fa-fw">
                                    <div class="icon-bg bg-pink"></div>
                                </i><span class="menu-title">Catalog</span><span class="fa arrow"></span>
                            </a>
                            <ul class="nav nav-second-level">
                                <li class="">
                                    <a href="Products/Index">
                                        <i class="fa fa-archive"></i><span class="submenu-title">Product</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="MainGroups/Index">
                                        <i class="fa fa-flag-o"></i><span class="submenu-title">Main Group</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="IntermediateGroups/Index">
                                        <i class="fa fa-flag-checkered"></i><span class="submenu-title">Intermediate Group</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="SubGroups/Index">
                                        <i class="fa fa-flag"></i><span class="submenu-title">Sub Group</span>
                                    </a>
                                </li>

                            </ul>
                        </li>
                        <li class="">
                            <a href="#">
                                <i class="fa fa-certificate">
                                    <div class="icon-bg bg-pink"></div>
                                </i><span class="menu-title">Sales</span><span class="fa arrow"></span>
                            </a>
                            <ul class="nav nav-second-level">
                                <li class="">
                                    <a href="Orders/Index">
                                        <i class="fa fa-suitcase"></i><span class="submenu-title">Order</span>
                                    </a>
                                </li>
                                }
                            </ul>
                        </li>
                        <li class="">
                            <a href="#">
                                <i class="fa fa-male">
                                    <div class="icon-bg bg-pink"></div>
                                </i><span class="menu-title">Customer</span><span class="fa arrow"></span>
                            </a>
                            <ul class="nav nav-second-level">
                                <li class="">
                                    <a href="Customers/Index">
                                        <i class="fa fa-group"></i><span class="submenu-title">Customer</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="Customers/CustomerApproval">
                                        <i class="fa fa-thumbs-up"></i><span class="submenu-title">Customer Approval</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="Suppliers/Index">
                                        <i class="fa fa-truck"></i><span class="submenu-title">Supplier</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="Employees/Index">
                                        <i class="fa fa-group"></i><span class="submenu-title">Employee</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="PurchasOrder/Index">
                                        <i class="fa fa-shopping-cart"></i><span class="submenu-title">Purchase Orders</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="">
                            <a href="#">
                                <i class="fa fa-bullhorn">
                                    <div class="icon-bg bg-pink"></div>
                                </i><span class="menu-title">Promotions</span><span class="fa arrow"></span>
                            </a>
                            <ul class="nav nav-second-level">
                                <li class="">
                                    <a href="Offers/Index">
                                        <i class="fa fa-location-arrow"></i><span class="submenu-title">Offers</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="">
                            <a href="#">
                                <i class="fa fa-wrench">
                                    <div class="icon-bg bg-pink"></div>
                                </i><span class="menu-title">Configuration</span><span class="fa arrow"></span>
                            </a>
                            <ul class="nav nav-second-level">
                                <li class="">
                                    <a href="Roles/Index">
                                        <i class="fa fa-gear"></i><span class="submenu-title">Role</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="Roles/MenuAccess">
                                        <i class="fa fa-key"></i><span class="submenu-title">Access Control List</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="Countries/Index">
                                        <i class="fa fa-flag"></i><span class="submenu-title">Country</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="Currencies/Index">
                                        <i class="fa fa-money"></i><span class="submenu-title">Currency</span>
                                    </a>
                                </li>
                               <%-- <li class="">
                                    <a href="EmailTemplates/Index">
                                        <i class="fa fa-envelope-o"></i><span class="submenu-title">Email Template</span>
                                    </a>
                                </li>--%>
                                <li class="">
                                    <a href="Units/Index">
                                        <i class="fa fa-paperclip"></i><span class="submenu-title">Product Unit</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="Active">
                            <a href="#">
                                <i class="fa fa-list-alt">
                                    <div class="icon-bg bg-pink"></div>
                                </i><span class="menu-title">Report</span><span class="fa arrow"></span>
                            </a>
                            <ul class="nav nav-second-level">
                                <li class="Active">
                                    <a href="CustomerSale.aspx">
                                        <i class="fa fa-bar-chart-o"></i><span class="submenu-title">Stock</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="ProductSale.aspx">
                                        <i class="fa fa-money"></i><span class="submenu-title">Product Sale</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="SaleReport.aspx">
                                        <i class="fa fa-pagelines"></i><span class="submenu-title">Stock</span>
                                    </a>
                                </li>
                                <li class="">
                                    <a href="SaleReportPie.aspx">
                                        <i class="fa fa-envelope"></i><span class="submenu-title">Stock Detail</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
            <!--END SIDEBAR MENU-->
            <div id="page-wrapper">
                <!--BEGIN TITLE & BREADCRUMB PAGE-->
                <div id="title-breadcrumb-option-demo" class="page-title-breadcrumb">
                    <div class="page-header pull-left">
                        <ol class="breadcrumb page-breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>&nbsp;<a href="Dashboard/Index">Home</a>&nbsp;&nbsp;
                            </li>
                        </ol>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <!--END TITLE & BREADCRUMB PAGE-->
                <!--BEGIN CONTENT-->
                <div class="page-content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-blue">
                                <div class="panel-heading">Stock</div>
                                <div class="panel-body pan">
<form id="form1" runat="server">
        <div class="auto-style1">
    <div style="float:left;margin-left:50px;">
       <div style="height:20px;"></div>
         <table  class="style6" >
            <tr>
                <td class="style10" colspan="3" style="text-align:center; background-color:#0095E7; ">
                    <asp:Label ID="lblName27" runat="server" Text="ICON Products Stock Report" 
                         Font-Bold="True" Font-Size="16pt" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    <asp:Label ID="lblName20" runat="server" Text="Products Name" 
                        CssClass="lblPageSubHeading" Font-Bold="True"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lblName26" runat="server" Text="UPC Code " 
                        CssClass="lblPageSubHeading" Font-Bold="True"></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="lblName19" runat="server" Text="Product Stock " 
                        CssClass="lblPageSubHeading" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                         <asp:LinkButton ID="LinkButton7" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" 
                        PostBackUrl="~/ApprovedECNECDashboard.aspx">0,40 KOPPARBERGS PÆRE GLASS A 12 STK</asp:LinkButton>
                </td>
                <td class="style8">
                <asp:Label ID="lblCode0" runat="server" Text=""></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="Label8" runat="server" BackColor="#008000" ForeColor="#008000" Text=" ." 
                        Width="80px"></asp:Label>
                <asp:Label ID="lblResult0" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                         <asp:LinkButton ID="LinkButton5" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" 
                        PostBackUrl="~/RecommendECNECDashboard.aspx">0,33 BREKK IMPORT BX ØL KL D</asp:LinkButton>
                </td>
                <td class="style8">
                <asp:Label ID="lblCode1" runat="server" Text=""></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="Label7" runat="server" BackColor="#0066CC" ForeColor="#BFBFBF" Text=" ." 
                        Width="80px"></asp:Label>
                <asp:Label ID="lblResult1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                         <asp:LinkButton ID="LinkButton3" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" 
                        PostBackUrl="~/ApprovedDashboard.aspx" >Papptrau : 0,25 Mack Cider</asp:LinkButton>
                </td>
                <td class="style8">
                <asp:Label ID="lblCode2" runat="server" Text=""></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="Label3" runat="server" BackColor="#4B008" ForeColor="#418CF0" Text=" ." 
                        Width="80px"></asp:Label>
                <asp:Label ID="lblResult2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                         <asp:LinkButton ID="LinkButton2" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" 
                        PostBackUrl="~/CDWPPendingDashboard.aspx">Etik.B: 1,50 RC Cola</asp:LinkButton>
                </td>
                <td class="style8">
                <asp:Label ID="lblCode3" runat="server" Text=""></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="Label4" runat="server" BackColor="#4B0082" ForeColor="#4B0082" Text="." 
                        Width="80px" Height="17px"></asp:Label>
                <asp:Label ID="lblResult3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">

                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" PostBackUrl="~/WPPendingDashboard.aspx">Pølseklype</asp:LinkButton>
                       
                </td>
                <td class="style8">

                <asp:Label ID="lblCode4" runat="server" Text=""></asp:Label>
                </td>
                <td class="style15">
                    <asp:Label ID="Label5" runat="server" BackColor="#CC0CCC" ForeColor="#E0400A" Text=" ." 
                        Width="80px"></asp:Label>
                <asp:Label ID="lblResult4" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10">
                         <asp:LinkButton ID="LinkButton4" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" 
                        PostBackUrl="~/ReturnDashboard.aspx" >SMIRNOFF BLUEBERRY 0,70</asp:LinkButton>
                </td>
                <td class="style10">
                <asp:Label ID="lblCode5" runat="server" Text=""></asp:Label>
                </td>
                <td class="style11">
                    <asp:Label ID="Label6" runat="server" BackColor="#FF0000" ForeColor="#056492" Text=" ." 
                        Width="80px"></asp:Label>
                <asp:Label ID="lblResult5" runat="server" Text=""></asp:Label>
                </td>
            </tr>
              <tr>
                <td class="style10">
                         <asp:LinkButton ID="LinkButton6" runat="server" CssClass="lblText" 
                        Font-Underline="False" ForeColor="Black" 
                        PostBackUrl="~/PendingPIADashboard.aspx">0,33 CLAUSTHALER 6P</asp:LinkButton>
                </td>
                <td class="style10">
                <asp:Label ID="lblCode6" runat="server" Text=""></asp:Label>
                  </td>
                <td class="style11">
                    <asp:Label ID="Label2" runat="server" BackColor="#8B0000" ForeColor="#1A3B69" Text=" ." 
                        Width="80px"></asp:Label>
                <asp:Label ID="lblResult6" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            </table>
    </div>
        
        <div style="float:right">

         <asp:Chart ID="Chart1" runat="server" Height="500px" Width="600px" 
             BackGradientStyle="LeftRight" Enabled="true" Palette="None" PaletteCustomColors="Green; HotTrack; 0, 192, 0; Indigo; MediumVioletRed; Red; DarkRed" 
             
            >
           
        
            
                    <series>
              
                <asp:Series ChartType="pie" Name="Series1" YValueType="Auto" Color="#336699" 
                            IsValueShownAsLabel="True" LabelForeColor="White" ></asp:Series>
                 <asp:Series ChartType="pie" Name="Series2"  MarkerColor="White" LabelBorderWidth="0">
                </asp:Series>
                 
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
          
        </asp:Chart>
        
    
    </div>

        </div>
    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--END CONTENT-->
            </div>

            <!--BEGIN FOOTER-->
            <div id="footer">
                <div class="copyright">2017 © ICON</div>
            </div>
            <!--END FOOTER-->
            <!--END PAGE WRAPPER-->
        </div>
    </div>



    <script src="Content/js/jquery-1.10.2.min.js"></script>
    <script src="Content/js/jquery-migrate-1.2.1.min.js"></script>
    <script src="Content/js/jquery-ui.js"></script>
    <!--loading bootstrap js-->
    <script src="Content/vendors/bootstrap/js/bootstrap.min.js"></script>
    <script src="Content/vendors/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js"></script>
    <script src="Content/js/html5shiv.js"></script>
    <script src="Content/js/respond.min.js"></script>
    <script src="Content/vendors/metisMenu/jquery.metisMenu.js"></script>
    <script src="Content/vendors/slimScroll/jquery.slimscroll.js"></script>
    <script src="Content/vendors/jquery-cookie/jquery.cookie.js"></script>
    <script src="Content/vendors/iCheck/icheck.min.js"></script>
    <script src="Content/vendors/iCheck/custom.min.js"></script>
    <script src="Content/vendors/jquery-highcharts/highcharts.js"></script>
    <script src="Content/js/jquery.menu.js"></script>
    <script src="Content/vendors/jquery-pace/pace.min.js"></script>
    <script src="Content/vendors/holder/holder.js"></script>
    <script src="Content/vendors/responsive-tabs/responsive-tabs.js"></script>
    <script src="Content/vendors/jquery-news-ticker/jquery.newsTicker.min.js"></script>
    <script src="Content/vendors/moment/moment.js"></script>
    <script src="Content/vendors/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script src="Content/vendors/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!--CORE JAVASCRIPT-->
    <script src="Content/js/main.js"></script>
    <!--LOADING SCRIPTS FOR PAGE-->
    <script src="Content/vendors/DataTables/media/js/jquery.dataTables.js"></script>
    <script src="Content/vendors/DataTables/media/js/dataTables.bootstrap.js"></script>
    <script src="Content/vendors/DataTables/extensions/TableTools/js/dataTables.tableTools.min.js"></script>
    <script src="Content/vendors/mixitup/src/jquery.mixitup.js"></script>
    <script src="Content/vendors/lightbox/js/lightbox.min.js"></script>
    <script src="Content/js/page-gallery.js"></script>
</html>







