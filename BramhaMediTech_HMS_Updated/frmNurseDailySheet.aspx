<%@ Page Title="Nurse Daily Sheet" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmNurseDailySheet.aspx.cs" Inherits="frmNurseDailySheet" %>

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
                <h1>Nurse Daily Sheet</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Nurse Daily Sheet</li>
                    </ol>
            </section>

            <section class="content">
                <div class="box" runat="server">
                    <div class="box-header with-border">
                        <span class="red pull-right">Fields marked with * are compulsory</span>
                        <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="False"></asp:Label>
                        <asp:HiddenField ID="txtSchId" runat="server" />
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="row">
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
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gdvNurse" runat="server" AutoGenerateColumns="False"
                                            class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Id"
                                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                            AllowPaging="True" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                            OnRowCommand="gdvNurse_RowCommand" OnRowDeleting="gdvNurse_RowDeleting" OnRowEditing="gdvNurse_RowEditing"
                                            OnPageIndexChanging="gdvNurse_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                                <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />
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

