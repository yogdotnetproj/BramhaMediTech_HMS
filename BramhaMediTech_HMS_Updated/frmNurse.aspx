<%@ Page Title="Nurse" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmNurse.aspx.cs" Inherits="frmNurse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
        .cssPager span {
            text-underline-position: below;
            font-size: 20px;
        }

        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <section class="content-header d-flex">
                <h1>Nurse</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Nurse</li>
                    </ol>
            </section>

            <section class="content">
                <div class="box" runat="server">
                    <div class="box-header with-border">
                        <span class="red pull-right">Fields marked with * are compulsory</span>
                        <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="False"></asp:Label>
                        <asp:HiddenField ID="txtSchId" runat="server" />
                    </div>
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text="A"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="txtpatientregid" style="text-align: left">PRN</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblIpd" style="text-align: left">Ipd</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" style="text-align: left">Opd</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblEntryDate" style="text-align: left">EntryDate</label>
                                        <asp:Label ID="lblEntryDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left">Branch Id</label>
                                        <asp:Label ID="lblBranchId" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-md-4">
                                    <label for="doctorNames"><b>Doctors</b></label>
                                    <asp:DropDownList ID="doctorNames" AutoPostBack="true"
                                        class="form-control" runat="server"
                                        OnSelectedIndexChanged="doctorNames_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="doctorNames"
                                        ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please select">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label for="drpTheatre"><b>Operation Theatre</b></label>
                                    <asp:DropDownList ID="drpTheatre" AutoPostBack="true"
                                        class="form-control" runat="server"
                                        OnSelectedIndexChanged="drpTheatre_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drpTheatre"
                                        ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please select">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <label for="txtStartDate">Date:</label>
                                    <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                        <asp:TextBox class="form-control" ID="txtStartDate" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <label for="txtStartTime">Time:</label>
                                    <div class="input-group bootstrap-timepicker timepicker" data-provide="timepicker" data-date-format="HH:mm" data-autoclose="true">
                                        <asp:TextBox class="form-control timepicker" ID="txtStartTime" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-md-2">
                                    <label for="drpDuration"><b>Duration</b></label>
                                    <asp:DropDownList ID="drpDuration" AutoPostBack="true" runat="server" class="form-control">
                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                        <asp:ListItem Text="30 min" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="45 min" Value="45">45 min</asp:ListItem>
                                        <asp:ListItem Text="60 min" Value="60">60 min</asp:ListItem>
                                        <asp:ListItem Text="90 min" Value="90">90 min</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drpDuration"
                                        ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="Please select">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Style="margin-top: 23px;" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnClear" class="btn btn-primary" runat="server" Style="margin-top: 23px;" Text="Clear" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gdvNurse" runat="server" AutoGenerateColumns="False"
                                            class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="NurseId"
                                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                            AllowPaging="True" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                            OnRowCommand="gdvNurse_RowCommand" OnRowDeleting="gdvNurse_RowDeleting" OnRowEditing="gdvNurse_RowEditing"
                                            OnPageIndexChanging="gdvNurse_PageIndexChanging">
                                            <Columns>                                               
                                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />                                           
                                                <asp:BoundField DataField="OperationTheatre" HeaderText="Theatre" Visible="true" />
                                                <asp:BoundField DataField="NDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="NTime" HeaderText="Time" Visible="true" />
                                                <asp:BoundField DataField="Duration" HeaderText="Duration" Visible="true" />
                                                <asp:BoundField DataField="DoctorId" HeaderText="DoctorId" Visible="true" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Images0/delete.gif"
                                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');"
                                                            AlternateText="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

