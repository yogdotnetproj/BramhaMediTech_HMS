<%@ Page Title="Surgery CheckList Details" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmCheckListDetails.aspx.cs" Inherits="frmCheckListDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <h1>Surgery CheckList Details</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <section class="content-header d-flex">
                <h1>Surgery Checklist Master</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Surgery Checklist Master</li>
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
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <label for="txtMrd"><b>Mrd No</b><span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtMrd" OnTextChanged="txtMrd_TextChanged" AutoPostBack="true" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtMrd" ErrorMessage="Please enter MRD no"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2">
                                                <label for="txtIpd"><b>IPD</b><span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtIpd" OnTextChanged="txtIpd_TextChanged" AutoPostBack="true" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtIpd" ErrorMessage="Please enter IPD no"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2">
                                                <label for="txtRoomType"><b>Room Type</b></label>
                                                <asp:TextBox ID="txtRoomType" class="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="col-md-1">
                                                <label for="txtBedNo"><b>Bed No</b></label>
                                                <asp:TextBox ID="txtBedNo" class="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3">
                                                <label for="txtPatientName"><b>Patient Name</b><span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtPatientName" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtPatientName" ErrorMessage="Please enter patient name"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-2">
                                                <label for="txtDateOfAdmission"><b>Date of Admission</b><span style="color: red">*</span></label>
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                    <asp:TextBox ID="txtDateOfAdmission" autocomplete="off" runat="server" class="form-control pull-right"></asp:TextBox>
                                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                </div>
                                               <%-- <asp:TextBox ID="txtDateOfAdmission" class="form-control" runat="server"></asp:TextBox>--%>
                                              <%--  <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDateOfAdmission" Format="dd-MM-yyyy" runat="server"></ajaxToolkit:CalendarExtender>--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="txtDateOfAdmission" ErrorMessage="Select a valid date"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-3 form-group">
                                                <label for="txtDoctorIncharge"><b>Doctor Incharge</b><span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtDoctorIncharge" class="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtDoctorIncharge" ErrorMessage="Please enter Doctor name"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-md-3">
                                                <label for="txtDiagnosis"><b>Diagnosis</b></label>
                                                <asp:TextBox ID="txtDiagnosis" class="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3">
                                                <label for="checkListType"><b>CheckList Type</b></label>
                                                <asp:DropDownList ID="drpCheckListType" AutoPostBack="True"
                                                    DataTextField="checkListType" DataValueField="checkListId" class="form-control" runat="server"
                                                    OnSelectedIndexChanged="drpCheckListType_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="checkListTranId"
                                                CssClass="table table-bordered table-condensed" AllowPaging="True" PageSize="5"
                                                GridLines="Both" ItemStyle-HorizontalAlign="center"
                                                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                <Columns>
                                                    <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="Id" />
                                                    <asp:BoundField ReadOnly="true" DataField="checkListTranId" HeaderText="checkListTranId" Visible="false" />
                                                    <asp:BoundField ReadOnly="true" DataField="checkListTranName" HeaderText="CheckList Trans Name" />
                                                    <asp:BoundField ReadOnly="true" DataField="checkListType" HeaderText="CheckList Type" />
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Eval("remarks") %>'
                                                                CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                            <asp:GridView ID="gdvCheckListType" Visible="false" CssClass="table table-bordered table-condensed" runat="server"
                                                AllowPaging="True" PageSize="5" AutoGenerateColumns="false" DataKeyNames="checkListTranId"
                                                GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                                OnPageIndexChanging="gdvCheckListDetails_PageIndexChanging"
                                                OnRowDataBound="gdvCheckListType_RowDataBound"
                                                OnRowCommand="gdvCheckListType_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                                    <asp:BoundField DataField="checkListTranId" HeaderText="checkListTranId" Visible="false" />
                                                    <asp:BoundField DataField="checkListTranName" HeaderText="CheckList Trans Name" />
                                                    <asp:BoundField DataField="checkListType" HeaderText="CheckList Type" />

                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRemarks" AutoPostBack="false" runat="server" Text='<%# Eval("remarks") %>'
                                                                CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Add" runat="server" CssClass="btn btn-sm btn-primary" Text="Add"
                                                                CommandName="Add" ToolTip="Click here to Add the record" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-success" Visible="false" OnClick="btnAdd_Click" />
                                                <asp:Button ID="btnUpdate" Text="Update" class="btn btn-success" runat="server" />
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-primary" OnClick="btnClear_Click" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success" OnClick="btnSave_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="table-responsive">
                                                <asp:GridView ID="gdvCheckListDetails" CssClass="table table-bordered table-condensed" runat="server" Width="100%"
                                                    AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                                                    GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                                    OnPageIndexChanging="gdvCheckListDetails_PageIndexChanging"
                                                    OnRowDataBound="gdvCheckListDetails_RowDataBound"
                                                    OnRowUpdating="gdvCheckListDetails_RowUpdating"
                                                    OnRowEditing="gdvCheckListDetails_RowEditing"
                                                    OnRowCancelingEdit="gdvCheckListDetails_RowCancelingEdit"
                                                    OnRowDeleting="gdvCheckListDetails_RowDeleting">

                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-sm btn-primary" Text="Edit"
                                                                    CommandName="Edit" ToolTip="Click here to Edit the record" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CheckList Details Id" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="checkListDetailsTranId" Text='<%#Eval("checkListDetailsTranId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IPD" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="Ipd" Text='<%#Eval("Ipd") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CheckList Desc" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="checkListDesc" Text='<%#Eval("checkListDesc") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CheckList Type" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="checkListType" Text='<%#Eval("checkListType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CheckList Details Id" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="checkListDetailsId" Text='<%#Eval("checkListDetailsId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Remarks" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="Remarks" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Date" Visible="true">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="checkDate" Text='<%#Eval("checkDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Delete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="Delete"
                                                                    OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                                                    <FooterStyle CssClass="DataGridFixedHeader" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <%-- <div class="card">
                <div class="card-body">--%>
            <%--<div class="row">
                        <div class="col-lg-12">
                            <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="False"></asp:Label>
                            <asp:HiddenField ID="txtSchId" runat="server" />
                        </div>
                    </div>--%>

            <%-- <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-md-2">
                                    <label for="txtMrd"><b>Mrd No</b><span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtMrd" OnTextChanged="txtMrd_TextChanged" AutoPostBack="true" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtMrd" ErrorMessage="Please enter MRD no"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2">
                                    <label for="txtIpd"><b>IPD</b><span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtIpd" OnTextChanged="txtIpd_TextChanged" AutoPostBack="true" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtIpd" ErrorMessage="Please enter IPD no"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2">
                                    <label for="txtRoomType"><b>Room Type</b></label>
                                    <asp:TextBox ID="txtRoomType" class="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-1">
                                    <label for="txtBedNo"><b>Bed No</b></label>
                                    <asp:TextBox ID="txtBedNo" class="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <label for="txtPatientName"><b>Patient Name</b><span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtPatientName" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtPatientName" ErrorMessage="Please enter patient name"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2">
                                    <label for="txtDateOfAdmission"><b>Date of Admission</b><span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtDateOfAdmission" class="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDateOfAdmission" Format="dd-MM-yyyy" runat="server"></ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="txtDateOfAdmission" ErrorMessage="Select a valid date"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label for="txtDoctorIncharge"><b>Doctor Incharge</b><span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtDoctorIncharge" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtDoctorIncharge" ErrorMessage="Please enter Doctor name"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-3">
                                    <label for="txtDiagnosis"><b>Diagnosis</b></label>
                                    <asp:TextBox ID="txtDiagnosis" class="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <label for="checkListType"><b>CheckList Type</b></label>
                                    <asp:DropDownList ID="drpCheckListType" AutoPostBack="True"
                                        DataTextField="checkListType" DataValueField="checkListId" class="form-control" runat="server"
                                        OnSelectedIndexChanged="drpCheckListType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="checkListTranId"
                                    CssClass="table table-bordered table-condensed" AllowPaging="True" PageSize="5"
                                    GridLines="Both" ItemStyle-HorizontalAlign="center"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                    <Columns>
                                        <asp:BoundField ReadOnly="true" DataField="Id" HeaderText="Id" />
                                        <asp:BoundField ReadOnly="true" DataField="checkListTranId" HeaderText="checkListTranId" Visible="false" />
                                        <asp:BoundField ReadOnly="true" DataField="checkListTranName" HeaderText="CheckList Trans Name" />
                                        <asp:BoundField ReadOnly="true" DataField="checkListType" HeaderText="CheckList Type" />
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Eval("remarks") %>'
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                
                                    </Columns>
                                </asp:GridView>

                                <asp:GridView ID="gdvCheckListType" Visible="false" CssClass="table table-bordered table-condensed" runat="server"
                                    AllowPaging="True" PageSize="5" AutoGenerateColumns="false" DataKeyNames="checkListTranId"
                                    GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                    OnPageIndexChanging="gdvCheckListDetails_PageIndexChanging"
                                    OnRowDataBound="gdvCheckListType_RowDataBound"
                                    OnRowCommand="gdvCheckListType_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" />
                                        <asp:BoundField DataField="checkListTranId" HeaderText="checkListTranId" Visible="false" />
                                        <asp:BoundField DataField="checkListTranName" HeaderText="CheckList Trans Name" />
                                        <asp:BoundField DataField="checkListType" HeaderText="CheckList Type" />

                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemarks" AutoPostBack="false" runat="server" Text='<%# Eval("remarks") %>'
                                                    CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Add" runat="server" CssClass="btn btn-sm btn-primary" Text="Add"
                                                    CommandName="Add" ToolTip="Click here to Add the record" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-success" Visible="false" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnUpdate" Text="Update" class="btn btn-success" runat="server" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-primary" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="gdvCheckListDetails" CssClass="table table-bordered table-condensed" runat="server" Width="100%"
                                        AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                                        GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                        OnPageIndexChanging="gdvCheckListDetails_PageIndexChanging"
                                        OnRowDataBound="gdvCheckListDetails_RowDataBound"
                                        OnRowUpdating="gdvCheckListDetails_RowUpdating"
                                        OnRowEditing="gdvCheckListDetails_RowEditing"
                                        OnRowCancelingEdit="gdvCheckListDetails_RowCancelingEdit"
                                        OnRowDeleting="gdvCheckListDetails_RowDeleting">

                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-sm btn-primary" Text="Edit"
                                                        CommandName="Edit" ToolTip="Click here to Edit the record" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CheckList Details Id" Visible="false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="checkListDetailsTranId" Text='<%#Eval("checkListDetailsTranId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="IPD" Visible="true">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="Ipd" Text='<%#Eval("Ipd") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CheckList Desc" Visible="true">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="checkListDesc" Text='<%#Eval("checkListDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CheckList Type" Visible="true">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="checkListType" Text='<%#Eval("checkListType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CheckList Details Id" Visible="false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="checkListDetailsId" Text='<%#Eval("checkListDetailsId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remarks" Visible="true">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="Remarks" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date" Visible="true">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="checkDate" Text='<%#Eval("checkDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Delete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="Delete"
                                                        OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                                        <FooterStyle CssClass="DataGridFixedHeader" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>--%>
            <%-- </div>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="Scripts/jquery-3.0.0.js"></script>

    <script>
        //$(document).ready(function () {
        //    alert('loaded');
        //    $('[id$=btnAdd]').attr('disabled',true);
        //    $('[id$=btnUpdate]').attr('disabled', true);
        //     $('[id$=btnClear]').attr('disabled', true);

        //    $('[id$=drpCheckListType]').change(function () {
        //        if (parseInt($('[id$=drpCheckListType]').val()) > 0) {
        //            alert('alert');
        //        }
        //    });
        //});
    </script>
</asp:Content>

