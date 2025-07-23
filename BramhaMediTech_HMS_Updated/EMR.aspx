<%@ Page Title="General EMR" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="EMR.aspx.cs" Inherits="EMR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="content-header d-flex">
        <h1>General EMR</h1>
        <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">General EMR</li>
                    </ol>
    </section>
    <section class="content">
        <div class="box" runat="server">
            <div class="box-header with-border">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <span class="red pull-right">Fields marked with * are compulsory</span>
                        <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                        <asp:HiddenField ID="txtEmrId" runat="server" />
                    </div>
                </div>
            </div>
            <div class="box-header with-border">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <div class="col-lg-2 text-left">
                            <div class="form-group">
                                <label for="lblPatientName" style="text-align: left">Name</label>
                                <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="col-lg-2 text-left">
                            <div class="form-group">
                                <label for="lblPrnNo" style="text-align: left">PRN</label>
                                <asp:Label ID="txtpatientregid" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-2 text-left">
                            <div class="form-group">
                                <label for="lblIpd" style="text-align: left">Ipd</label>
                                <asp:Label ID="lblIpd" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-2 text-left">
                            <div class="form-group">
                                <label for="lblOpd" style="text-align: left">Opd</label>
                                <asp:Label ID="lblOpd" runat="server" Text=""></asp:Label>
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
                                <asp:Label ID="lblBranchId" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-4">
                        <label for="txtChiefComplaints"><b>Chief Complaints</b></label>
                        <asp:Button ID="btnChief" runat="server" Text="+" />
                        <textarea class="form-control" rows="4" id="txtChiefComplaints"></textarea>
                    </div>
                    <div class="col-md-4">
                        <label for="txtAllergy"><b>Allergies(if any)</b></label>
                        <asp:Button ID="btnAllergy" runat="server" Text="+" />
                        <textarea class="form-control" rows="4" id="txtAllergy"></textarea>
                    </div>
                    <div class="col-md-4">
                        <label for="txtMedicalHistory"><b>Medical History</b></label>
                        <asp:Button ID="btnMedicalHistory" runat="server" Text="+" />
                        <textarea class="form-control" rows="4" id="txtMedicalHistory"></textarea>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label for="divPastHistory"><b>Past History</b></label>
                        <asp:Button ID="btnPastHistory" runat="server" Text="+" />
                        <textarea class="form-control" rows="4" placeholder="Others(if any)" id="txtPastHistory"></textarea>
                    </div>
                    <div class="col-md-4">
                        <label for="divPersonalHistory"><b>Personal History</b></label>
                        <asp:Button ID="btnPersonalHistory" runat="server" Text="+" />
                        <textarea class="form-control" rows="4" placeholder="Others(if any)" id="txtPersonalHistory"></textarea>
                    </div>
                    <div class="col-md-4">
                        <label for="txtFamilyHistory"><b>Family History</b></label>
                        <asp:Button ID="btnFamilyHistory" runat="server" Text="+" />
                        <textarea class="form-control" rows="4" placeholder="Others(if any)" id="txtFamilyHistory"></textarea>
                    </div>
                </div>
            </div>
            <!-- ModalPopupExtender -->
            <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnChief"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                <div style="height: 60px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            Do you like this product?&nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnClose" runat="server" Text="Close" />
            </asp:Panel>
        </div>
    </section>
</asp:Content>

