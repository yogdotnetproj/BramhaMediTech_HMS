<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmPathologyInves.aspx.cs" Inherits="frmPathologyInves" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <style>
        .list-group-item {
            user-select: none;
        }

        .list-group input[type="checkbox"] {
            display: none;
            border: double;
        }

            .list-group input[type="checkbox"] + label {
                cursor: pointer;
                border: 1px solid rgba(0,0,0,.125);
                position: relative;
                display: block;
                padding: 10px;
                background-color: #fff;
                text-align: center;
                border-radius: 6px;
                height: 80px;
                width: 150px;
                margin: 10px;
                background: aliceblue;
                font-size: 10px;
            }

                .list-group input[type="checkbox"] + label:before {
                    content: "\2713";
                    color: transparent;
                    font-weight: bold;
                    margin-right: 1em;
                }

            .list-group input[type="checkbox"]:checked + label {
                background-color: #106571;
                color: #FFF;
            }

                .list-group input[type="checkbox"]:checked + label:before {
                    color: inherit;
                }
    </style>

    <style type="text/css">

        .Background

        {

            background-color: Black;

            filter: alpha(opacity=90);

            opacity: 0.8;

        }

        .Popup

        {

            background-color: #FFFFFF;

            border-width: 3px;

            border-style: solid;

            border-color: black;

            padding-top: 10px;

            padding-left: 10px;

            width: 400px;

            height: 350px;

        }

        .lbl

        {

            font-size:16px;

            font-style:italic;

            font-weight:bold;

        }

    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Left side column. contains the logo and sidebar -->

    <!-- Content Wrapper. Contains page content -->

    <!-- Content Header (Page header) -->

    <!-- Main content -->



    <div style="padding: 0px; padding-top: 0px;">
        <!--MySection Test Registration-->
        <asp:UpdatePanel ID="UpdatePaneLeftBox" runat="server" style="">
            <ContentTemplate>


                <!----------------------------------------------------->
                <div class="container" style="width: 100%; padding: 0px; margin-top: 0px; padding: 0px; border-radius: 0px; padding-top: 0px;">
                    <div class="panel panel-default">

                        <div class="panel-body">

                            <div class="container">
                                <div class="form-group">
                                    <!--FirstPanel-------------------------------------------------------------------->
                                    <div class="row">
                                        <div class="col-md-12">

                                            <div class="container" style="width: 100%; padding: 0px; margin: 0px;">
                                                <div class="panel panel-default" style="margin-right: 30px;">
                                                    <div class="panel-body">
                                                        <div class="form-group">

                                                            <%-- Row1 ------------------- --%>
                                                            <div class="row" style="padding-bottom: 8px">
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtCenter" TabIndex="1" runat="server" class="form-control" placeholder="Select Center" Height="30px" OnTextChanged="ddlCenter_SelectedIndexChanged"
                                                                                AutoPostBack="True"></asp:TextBox><div style="display: none; overflow: scroll; width: 300px; height: 100px"
                                                                                    id="Div2">
                                                                                </div>
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                                                                                MinimumPrefixLength="1" TargetControlID="txtCenter" ServiceMethod="GetCenter"
                                                                                  CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                                                CompletionListElementID="Div2">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtSearchCardNo" TabIndex="2" runat="server" class="form-control"
                                                                                placeholder="Search Card No" Height="30px"
                                                                                AutoPostBack="True" OnTextChanged="txtSearchCardNo_TextChanged"></asp:TextBox>
                                                                            <div style="display: none; overflow: scroll; width: 350px; height: 100px; text-align: right"
                                                                                id="Div3">
                                                                            </div>
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                                                                CompletionListElementID="Div3" ServiceMethod="GetCardInfo" TargetControlID="txtSearchCardNo"
                                                                                  CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                                                MinimumPrefixLength="1">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <!--  <input type="text" class="form-control" id="" placeholder="Enter Doctor Name">-->
                                                                    <asp:TextBox ID="txtDoctorName" placeholder="Ref Doctor" Height="30px" TabIndex="10" runat="server" class="form-control"
                                                                        OnTextChanged="txtDoctorName_TextChanged"></asp:TextBox>
                                                                    <div style="display: none; overflow: scroll; width: 227px; height: 100px; text-align: right"
                                                                        id="Divdoc">
                                                                    </div>
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                                                        CompletionListElementID="Divdoc" ServiceMethod="FillDoctor" TargetControlID="txtDoctorName"
                                                                          CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                                        MinimumPrefixLength="1">
                                                                    </cc1:AutoCompleteExtender>
                                                                </div>
                                                            </div>

                                                            <%-- Row2 ------------------- --%>
                                                            <div class="row" style="padding-bottom: 8px">
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="cmbInitial" TabIndex="3" Height="30px" runat="server" class="form-control"
                                                                                OnSelectedIndexChanged="cmbInitial_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                            <asp:HiddenField ID="hdnstatus" runat="server" Value="0" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtFname" runat="server" placeholder="Enter Name" Height="30px" TabIndex="4" class="form-control"
                                                                                AutoPostBack="True" OnTextChanged="txtFname_TextChanged"></asp:TextBox>

                                                                            <div style="display: none; overflow: scroll; width: 350px; height: 100px; text-align: right"
                                                                                id="Div1">
                                                                            </div>
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
                                                                                CompletionListElementID="Div1" ServiceMethod="GetPatientInfo" TargetControlID="txtFname"
                                                                                  CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                                                MinimumPrefixLength="1">
                                                                            </cc1:AutoCompleteExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFname"
                                                                                Display="Dynamic" ErrorMessage="This field is required" SetFocusOnError="True"
                                                                                ValidationGroup="ValidateForm">
                                                                            </asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlsex" runat="server" Height="30px" TabIndex="5" class="form-control">
                                                                                <asp:ListItem>Gender</asp:ListItem>
                                                                                <asp:ListItem>Male</asp:ListItem>
                                                                                <asp:ListItem>Female</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtAge" runat="server" onkeypress="return NumberOnly()" placeholder="Age" class="form-control" Height="30px" AutoPostBack="True" OnTextChanged="txtAge_TextChanged" TabIndex="6" MaxLength="3">
                                                                            </asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="cmdYMD" runat="server" Height="30px" TabIndex="7" class="form-control">

                                                                                <asp:ListItem>Year</asp:ListItem>
                                                                                <asp:ListItem>Month</asp:ListItem>
                                                                                <asp:ListItem>Day</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                                                <asp:TextBox ID="txtBirthdate" placeholder="Enter DOB" runat="server"
                                                                                    Height="30px" class="form-control"
                                                                                    TabIndex="8" MaxLength="15" AutoPostBack="True"
                                                                                    OnTextChanged="txtBirthdate_TextChanged"></asp:TextBox>
                                                                                <span class="input-group-addon">
                                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                                </span>
                                                                            </div>
                                                                            

                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txttelno" placeholder="Enter Mobile" MaxLength="13"
                                                                                runat="server" Height="30px" class="form-control"
                                                                                TabIndex="10" AutoPostBack="True" OnTextChanged="txttelno_TextChanged"></asp:TextBox>

                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>

                                                            <%-- Row3 ------------------- --%>
                                                            <div class="row" style="padding-bottom: 8px">

                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtemail" placeholder="Enter Email" runat="server"
                                                                                Height="30px" TabIndex="11" class="form-control" AutoPostBack="True"
                                                                                OnTextChanged="txtemail_TextChanged"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txt_address" runat="server" placeholder="Enter address" TabIndex="12" Height="30px" TextMode="MultiLine" class="form-control">
                                                                            </asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txt_remark" placeholder="Other Dr" TabIndex="13" Height="30px" runat="server" class="form-control">
                                                                            </asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtpatcardno" placeholder="Patient Card No" TabIndex="14" class="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtcardexpdate" placeholder="Card Exp" TabIndex="15" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtcardexpdate_TextChanged"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <%-- Row4 ------------------- --%>
                                                            <div class="row" runat="server" id="RowWillHide" style="padding-bottom: 0px">
                                                                <div id="D1" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtWeight" placeholder="Enter Weight" TabIndex="16" runat="server" Height="30px" class="form-control"
                                                                                MaxLength="15"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="D2" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtHeight" placeholder="Enter Height" TabIndex="17" runat="server" Height="30px" class="form-control">     </asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="D6" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                        <ContentTemplate>

                                                                            <asp:TextBox ID="txtDieses" placeholder="Enter Disease" TabIndex="18" runat="server" TextMode="MultiLine" Height="45px" class="form-control"
                                                                                MaxLength="550"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="D7" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtSymptoms" placeholder="Enter Symptoms" TabIndex="19" runat="server" TextMode="MultiLine" Height="45px" class="form-control"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <%-- Row5 ------------------- --%>
                                                            <div class="row" style="padding-bottom: 0px">
                                                                <div id="D4" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtTherapy" runat="server" TabIndex="20" placeholder="Enter Therapy" Height="30px" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="D5" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtFSTime" placeholder="Enter FSTime" TabIndex="21" runat="server" Height="30px" class="form-control">

                                                                            </asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="D3" visible="false" runat="server" class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtLastPeriod" runat="server" TabIndex="22" placeholder="Enter LastPeriod" Height="30px" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="Div8" runat="server" visible="false" class="col-md-3">
                                                                    <asp:TextBox ID="txt_clinicalhistory" placeholder="Enter clinical history" runat="server" Height="50px" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <%-- Row6 ------------------- --%>
                                                            <div class="row" style="padding-bottom: 0px; display: none">
                                                                <div class="col-md-3">
                                                                    <asp:CheckBox ID="chkIsBH" runat="server" Text="BTH" />
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:RadioButtonList ID="ReportBy" runat="server"
                                                                        RepeatDirection="Horizontal">
                                                                        <asp:ListItem Selected="True" Value="0">Print</asp:ListItem>
                                                                        <asp:ListItem Value="1">Email</asp:ListItem>
                                                                        <asp:ListItem Value="2">Both</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                                <div id="Div4" runat="server" class="col-md-1" style="display: none">
                                                                    <asp:TextBox ID="txtstate" placeholder="Enter State" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div id="Div5" runat="server" class="col-md-1" style="display: none">
                                                                    <asp:TextBox ID="txtDistrict" runat="server" placeholder="Enter District" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div id="Div6" runat="server" class="col-md-1" style="display: none">
                                                                    <asp:TextBox ID="txtcity" placeholder="Enter city/Village" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div id="Div7" runat="server" class="col-md-1">
                                                                    <asp:TextBox ID="txtpanno" placeholder="Enter Pan No" runat="server" Height="50px" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <!-------------------------------------------------------------------------->
                                    <!--Second Panel----------------------------------------->
                                    <div class="row">
                                        <!--Left Box Tests----------------------------------------->
                                        <div class="col-md-6">

                                            <div class="panel panel-default" style="margin-right: 30px; height: 350px">
                                                <div class="panel-body">
                                                    <div class="row" style="padding-bottom: 8px">
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="txttests" placeholder="Add Test" runat="server" TabIndex="23" class="form-control"
                                                                AutoPostBack="True" OnTextChanged="txttests_TextChanged"></asp:TextBox>
                                                            <div style="display: none; overflow: scroll; width: 348px; height: 120px" id="div">
                                                            </div>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                                CompletionListElementID="div" ServiceMethod="FillTests" TargetControlID="txttests"
                                                                  CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                                MinimumPrefixLength="1">
                                                            </cc1:AutoCompleteExtender>
                                                        </div>
                                                        <div class="col-md-3" style="padding-left: 0px; padding-right: 0px; margin-top: 5px">

                                                            <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#largeShoes">
                                                                Quick Add
                                                            </button>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group text-package">
                                                                    <div class="table-responsive" style="width: 100%; margin-bottom: 10px; max-height: 250px; vertical-align: top; overflow: scroll;">
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdTests" runat="server" class="table table-responsive table-sm table-bordered" HeaderStyle-ForeColor="Black"
                                                                                    AlternatingRowStyle-BackColor="White"
                                                                                    Width="100%" PageSize="50" OnRowDataBound="grdTests_RowDataBound" OnRowDeleting="grdTests_RowDeleting"
                                                                                    DataKeyNames="MTCode" CellPadding="4" AutoGenerateDeleteButton="True"
                                                                                    AutoGenerateColumns="False">
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="MTCode" HeaderText=" Code"></asp:BoundField>
                                                                                        <asp:BoundField DataField="Maintestname" HeaderText="Test"></asp:BoundField>
                                                                                       <asp:BoundField DataField="Type" HeaderText="Test/Package"></asp:BoundField>
                                                                                        <asp:BoundField DataField="Amount" HeaderText="Charges"></asp:BoundField>

                                                                                        <asp:TemplateField HeaderText="Disc">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtTestprofdiscount" Width="40px" AutoPostBack="true" Enabled="false" runat="server"
                                                                                                    OnTextChanged="txtTestprofdiscount_TextChanged"></asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Barcode" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtBarcode" Width="90px" AutoPostBack="false" Visible="false" runat="server">
                                                                                                </asp:TextBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>


                                                                                    <HeaderStyle ForeColor="Black" />


                                                                                </asp:GridView>


                                                                                <asp:Label Style="position: relative" ID="lblAmtText" runat="server" Visible="False">Total Amount = </asp:Label>&nbsp;
                                    <asp:Label Style="position: relative" ID="lblTotTestAmt" runat="server" Visible="False">0</asp:Label>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--Right Box Charges ----------------------------------------->

                                        <div class="col-md-6" runat="server" visible="false">
                                            <div class="panel panel-default" style="margin-right: 30px; height: 400px">
                                                <div class="panel-body">
                                                    <!--Maindiv-->
                                                    <div class="form-group">

                                                        <!--Row1-->
                                                        <div class="row" style="padding-bottom: 10px">
                                                            <div class="col-md-3">
                                                                Payment Type
                                                            </div>
                                                            <div class="col-md-9" style="margin-top: -4px">
                                                                <asp:RadioButtonList ID="rblPaymenttype" runat="server"
                                                                    RepeatDirection="Horizontal" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="rblPaymenttype_SelectedIndexChanged" TabIndex="24">
                                                                    <asp:ListItem>Cash</asp:ListItem>
                                                                     <asp:ListItem>Cheque</asp:ListItem>
                                                                     <asp:ListItem>Card</asp:ListItem>
                                                                    <asp:ListItem>Online</asp:ListItem>
                                                                   
                                                                    
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-bottom: 10px" id="CCheq" runat="server" visible="false">
                                                            
                                                            <div class="col-md-3" style="margin-top: -4px">
                                                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                                                        <ContentTemplate>
                                                                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                                                <asp:TextBox ID="txtchequedate" AutoPostBack="true" placeholder="Enter Date" runat="server"
                                                                                    Height="30px" Width="100px" class="form-control"
                                                                                    MaxLength="15"
                                                                                   ></asp:TextBox>
                                                                                <span class="input-group-addon">
                                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                                </span>
                                                                            </div>
                                                                            </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                </div>
                                                           <div class="col-md-3" style="margin-top: -4px">
                                                               <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                                                        <ContentTemplate>
                                                                 
                                                                            </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                               </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                  <asp:TextBox ID="txtchequenumber" class="form-control" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                <asp:TextBox ID="txtbankname" class="form-control" placeholder="Bank Name" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        <div class="row" style="padding-bottom: 10px" id="CCard" runat="server" visible="false">
                                                            
                                                            <div class="col-md-3" style="margin-top: -4px">
                                                                 <asp:TextBox ID="txtcardnumber"  class="form-control" MaxLength="4" placeholder="Card " runat="server"></asp:TextBox>
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                 <asp:TextBox ID="txtCardtransactionID"  class="form-control" MaxLength="20" Width="200px" placeholder="Transactuon ID" runat="server"></asp:TextBox>
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                </div>
                                                            </div>  
                                                        <div class="row" style="padding-bottom: 10px" id="COnline" runat="server" visible="false">
                                                            <div class="col-md-3" style="margin-top: -4px">
                                                                 <asp:TextBox ID="txtonlineType"  class="form-control" MaxLength="40" placeholder="Type " runat="server"></asp:TextBox>
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                 <asp:TextBox ID="txtonlinetransid"  class="form-control" Width="200px" MaxLength="20" placeholder="Transactuon ID" runat="server"></asp:TextBox>
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                </div>
                                                             <div class="col-md-3" style="margin-top: -4px">
                                                                </div>
                                                            </div>  
                                                            </div>

                                                        <!--Row2-->
                                                        <div class="row" style="padding-bottom: 10px">
                                                            <div class="col-md-3">
                                                                <p class="label-form">Total Amount</p>
                                                            </div>
                                                            <div class="col-md-9">
                                                                <asp:UpdatePanel ID="tp" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="lbltotalpayment" runat="server" Width="100%" Text=" " Style="display: inline-block; width: 100%; font-size: large; color: green;"></asp:Label>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <!--Row3-->
                                                        <div class="row" style="padding-bottom: 10px">
                                                            <div class="col-md-3">
                                                                <asp:Label ID="lbloot" runat="server" class="form-control" Text=" Other Charge" Enabled="False"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtotherAmt" class="form-control" Height="30px" runat="server"  Text="0" onkeyup="GetPaidAmount1()" OnTextChanged="txtotherAmt_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                               
                                                            </div>

                                                            <div class="col-md-5">
                                                                <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="otherchargeRemark" class="form-control"
                                                                            placeholder="Other charges Remark" runat="server" AutoPostBack="True"
                                                                            OnTextChanged="otherchargeRemark_TextChanged"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <!--Row4-->
                                                        <div class="row" style="padding-bottom: 10px">
                                                            <div class="col-md-3">
                                                                <p class="label-form">Disc Type</p>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:UpdatePanel ID="M" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:RadioButtonList ID="Rbldisctype" Enabled="false" TabIndex="25" class="form-control" runat="server"
                                                                            RepeatDirection="Horizontal" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="Rbldisctype_SelectedIndexChanged">
                                                                            <asp:ListItem Selected="True" Value="Amt">Amt</asp:ListItem>
                                                                           <%-- <asp:ListItem  Value="Per">Per%</asp:ListItem>--%>
                                                                        </asp:RadioButtonList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </div>
                                                            <div class="col-md-2">
                                                                <label style="width: 500px;">Disc Amt* </label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txthstamount" class="form-control" Visible="false" Enabled="False" Width="50px" runat="server"></asp:TextBox>
                                                                  <asp:TextBox ID="txtDisamount" runat="server" TabIndex="26" placeholder="Discount" Height="30px" class="form-control" Text="0" AutoPostBack="True"
                                                                            OnTextChanged="txtDisamount_TextChanged"></asp:TextBox>
                                                                           </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <!--Row5-->
                                                       
                                                          <!--RowAAAAAAAAAAAAAAAAAAAAAAAAAAAA-->

                                                           <div class="row" >
                                                                <div class="col-md-6">
        <asp:UpdatePanel ID="UpdatePanel26" runat="server" style="">
            <ContentTemplate>
                <asp:RadioButtonList ID="RblDiscgiven" Visible="false" runat="server"
                    RepeatDirection="Horizontal" AutoPostBack="True"
                    TabIndex="12" OnSelectedIndexChanged="RblDiscgiven_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1" Text="Lab"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Dr"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Both"></asp:ListItem>
                </asp:RadioButtonList>
            </ContentTemplate>
        </asp:UpdatePanel>
                                                                    </div>
                                                                <div class="col-md-3">
        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtDisLabgiven" Visible="false" class="form-control" placeholder="Dis Lab"
                    runat="server" AutoPostBack="True" OnTextChanged="txtDisLabgiven_TextChanged"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
                                                                    </div>
                                                                <div class="col-md-3">
        <asp:UpdatePanel ID="UpdatePanel27" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtDisdrgiven" Visible="false" class="form-control" placeholder="Dis Dr"
                    runat="server" AutoPostBack="True" OnTextChanged="txtDisdrgiven_TextChanged"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
                                                                    </div>
    </div>
                                                        <div class="row" >
                                                            <div class="col-md-3">
                                                                
                                                                 <asp:Label ID="Label1" runat="server" Width="100%" Text="Net Amount " Style="display: inline-block; width: 100%; font-size: large; color: orange; font:bold; "></asp:Label>
                                                            </div>
                                                            <div class="col-md-9">
                                                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Label ID="LblNetAmt" runat="server" Width="100%" Text=" " Style="display: inline-block; width: 100%; font-size: large; color: green;"></asp:Label>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            </div>
                                                         <div class="row" style="padding-bottom: 10px">
                                                            
                                                            <div class="col-md-3">
                                                                <p class="label-form">Paid Amt *</p>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:UpdatePanel ID="pa" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtpaidamount" class="form-control" TabIndex="27" runat="server" onkeyup="GetPaidAmount1()" OnTextChanged="txtpaidamount_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <p class="label-form"></p>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                       
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                         <!--RowAAAAAAAAAAAAAAAAAAAAAAAAAAAA-->
                                                        <!--Row6-->
                                                        <div class="row" style="padding-bottom: 10px">
                                                            <div class="col-md-3">
                                                                <p class="label-form">Balance  *</p>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtBalance" class="form-control" Width="100%" placeholder="Balance" Enabled="False" runat="server"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <p class="label-form">Remark  *</p>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtdiscountremark" class="form-control" Width="100%" placeholder="Remark" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <!--Row7-->
                                                        <hr />
                                                        <div class="row" style="padding-bottom: 10px">

                                                            <div style="font-weight: bold; margin-left: 15px;">
                                                                <asp:Label ID="LblbrowsePres" Text="Upload Prescription:" runat="server"></asp:Label>
                                                            </div>

                                                            <br />
                                                            <div class="col-md-6">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                             <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                                    <ContentTemplate>
                                                                           <asp:FileUpload ID="FUBrowsePresc" runat="server"></asp:FileUpload>
                                                                            <asp:Label ID="LblFilename" Text="" Font-Bold="true" runat="server"></asp:Label>
                                                                        
                                                                         </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnupload" runat="server" Visible="true" Textclass="btn btn-primary" 
                                                                                Text="Upload" OnClick="btnupload_Click" class="btn-blue"></asp:Button>
                                                                            
                                                                        </td>

                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div class="col-md-3" style="margin-left: 30px">
                                                                <label class="cKsTLYE">
                                                                    Emergency<asp:CheckBox ID="ChkEmergency" runat="server" CssClass="custom-control-input" />
                                                                    <span class="checkmark"></span>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <!--Row8-->
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="form-group">
                                                                    <table id="Table1" width="100%" runat="server">

                                                                        <tr id="CCheq9" runat="server" visible="false">
                                                                            <td>
                                                                                <label>Cheque Date *</label>
                                                                            </td>
                                                                            <td>
                                                                                <label>Cheque No *</label>
                                                                            </td>
                                                                            <td>
                                                                                <label>Bank Name *</label>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr id="CCheq1" runat="server" visible="false">
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            0
                                                                                        </td>
                                                                                        <td>
                                                                                            
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                              
                                                                            </td>
                                                                            <td>
                                                                                
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr id="CCard1" runat="server" visible="false">
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Button ID="btnresultentry" class="btn btn-blue" runat="server"
                                                                                    Text="Result " OnClick="btnresultentry_Click" Visible="False"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" align="center">
                                                                               <asp:Label ID="Label10" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:RadioButtonList ID="rblretecate" Visible="false" Height="30px" runat="server"
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="0">General</asp:ListItem>
                                                    <asp:ListItem Value="1">Viber</asp:ListItem>
                                                    <asp:ListItem Value="2">Whatsapp</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RadioButtonList ID="RadioButtonList1" Visible="false" Height="30px" runat="server"
                                                    RepeatDirection="Horizontal" Style="display: none">
                                                    <asp:ListItem Selected="True" Value="0">General</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <div class="rounded_corners" style="width: 100%; height: 1px; vertical-align: top; overflow: scroll; visibility: hidden">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdPackage" runat="server" HeaderStyle-ForeColor="Black"
                                                                    AlternatingRowStyle-BackColor="White" Width="100%"
                                                                    PageSize="50" OnRowDataBound="grdPackage_RowDataBound" AutoGenerateDeleteButton="false"
                                                                    AutoGenerateColumns="False" DataKeyNames="STCODE" OnRowDeleting="grdPackage_RowDeleting">
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="SampleType" HeaderText="SampleType"></asp:BoundField>
                                                                        <asp:BoundField DataField="STCODE" HeaderText="Test Codes"></asp:BoundField>
                                                                        <asp:BoundField DataField="TestName" HeaderText="Test Names"></asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Barcode No">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtbarcodeid" runat="server"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtbarcodeid"
                                                                                    FilterMode="ValidChars" ValidChars="A,B,C,D,E,F,E,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                                <asp:Label ID="lblError" runat="server" SkinID="errmsg"></asp:Label>
                                                                                <asp:Label ID="lblRequiredField" runat="server" Visible="false" SkinID="errmsg"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Testcharges" Visible="false" HeaderText="Testcharges"></asp:BoundField>

                                                                        <asp:TemplateField HeaderText="Disc" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtTestdiscount" Width="50px" runat="server" AutoPostBack="True"
                                                                                    OnTextChanged="txtTestdiscount_TextChanged"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>


                                                                    <HeaderStyle ForeColor="Black" />


                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button ID="btnadd" OnClick="btnadd_Click" TabIndex="30" class="btn btn-info" runat="server" Text="Clear"></asp:Button>
                                                <asp:UpdatePanel ID="UpdatePanel23" runat="server" style="display: inline;">
                                                    <ContentTemplate>
                                                        
                                                        <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                                                        <asp:Button ID="btnSubmit"   TabIndex="28"  OnClick="btnSubmit_Click" class="btbtnbarcodeEntry_Clickn btn-info" runat="server" Text="Save" OnClientClick="return Validate();"></asp:Button>
                                                   
                                                <asp:Button ID="BtnReceipt" TabIndex="29" class="btn btn-info" Visible="false"  runat="server" Text="Save &amp; Bill" OnClick="BtnReceipt_Click"></asp:Button>
                                                 </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:Button ID="btnbarcodeEntry" runat="server"  TabIndex="31"  Visible="false"  Enabled="false" Text="Dept Barcode" class="btn btn-light" OnClick="btnbarcodeEntry_Click"></asp:Button>

                                                <asp:Button ID="btnpatientcard" class="btn btn-dark"  TabIndex="32"  Visible="false" Enabled="false"  runat="server" Text="Card" OnClick="btnpatientcard_Click"></asp:Button>

                                                <asp:Button ID="btnbprint" runat="server" Enabled="false"  Visible="false" TabIndex="33"  Text="Sample Barcode" class="btn btn-success" OnClick="btnbprint_Click"></asp:Button>
                                                


                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!--Hidden Panel X-->

    <table style="display: none">
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td colspan="12"></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2"></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td id="CCard9" colspan="2" runat="server" visible="false"></td>
        </tr>
        <tr>
            <td></td>
            <td id="Td1" runat="server"></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr id="Tr1" runat="server" visible="false">
            <td></td>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td colspan="2" runat="server" id="Dg"></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr id="disrema" runat="server">
            <td></td>
            <td colspan="3"></td>
        </tr>
    </table>
    <!------------------------------------------------------------------------------------------------------------------------------------>
    <%--Poopup ================================================================ --%>

    <!-- Modal Fullscreen -->

    <!-- The modal -->
    <div class="modal" id="largeShoes" tabindex="-1" role="dialog" aria-labelledby="modalLabelLarge" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 90%;">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="modalLabelLarge">Tests</h4>
                </div>

                <div class="modal-body">
                    <div class="list-group">
                        <asp:CheckBoxList ID="Chkmaintestshort" type="checkbox" CssClass=".list-group-item" name="CheckBoxInputName" runat="server" RepeatColumns="7" Width="100%" AutoPostBack="false" OnSelectedIndexChanged="Chkmaintestshort_SelectedIndexChanged">
                        </asp:CheckBoxList>

                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                    </div>
                </div>
                 <div class="modal-footer">
          <!--<button type="button" class="btn btn-primary btn-lg" data-dismiss="modal">ADD</button>-->
                      <asp:Button ID="btnquickaddT"  class="btn btn-primary btn-lg"  runat="server" Text="ADD" OnClick="btnquickaddT_Click"></asp:Button>

        </div>

            </div>
        </div>
    </div>

   


    <!--  ===================================================================================================================================================================-->
    
     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script> 
     <asp:UpdatePanel ID="UpdatePanel32" runat="server">          
        <Triggers>
         
              <asp:PostBackTrigger ControlID="BtnReceipt" />
              <asp:PostBackTrigger ControlID="btnbprint" />
             <asp:PostBackTrigger ControlID="btnpatientcard" />
            <asp:PostBackTrigger ControlID="btnbarcodeEntry" />
              <asp:PostBackTrigger ControlID="btnupload" />
             
            
            
        </Triggers>
          </asp:UpdatePanel>
   
    <script type="text/javascript">
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else
                event.returnValue = false;
        }
    </script>
</asp:Content>

