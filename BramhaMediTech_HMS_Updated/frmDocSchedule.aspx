<%@ Page Title="Doctor Schedule" Language="C#" MasterPageFile="Hospital.master" AutoEventWireup="true" CodeFile="frmDocSchedule.aspx.cs" Inherits="frmDocSchedule" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <h1>Doctor Schedule</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                            <asp:HiddenField ID="txtDocSchId" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label for="drpDoctor">Category <span style="color: red">*</span></label>
                                        <asp:DropDownList ID="drpDoctor" AutoPostBack="True"
                                            class="form-control" runat="server"
                                            OnSelectedIndexChanged="drpDoctor_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic"
                                            ControlToValidate="drpDoctor" ID="RequiredFieldValidator2"
                                            runat="server" ForeColor="Red" ErrorMessage="Please select">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="txtStart"><b>Start date</b><span style="color:red">*</span></label>
                                    <asp:TextBox ID="txtStart" class="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStart" Format="dd-MM-yyyy" runat="server"></ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="txtStart" ErrorMessage="Select a valid date"></asp:RequiredFieldValidator>
     
                                    </div>

                                    <div class="col-md-6">
                                        <label for="txtEnd"><b>End Date</b><span style="color:red">*</span></label>
                                    <asp:TextBox ID="txtEnd" class="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEnd" Format="dd-MM-yyyy" runat="server"></ajaxToolkit:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtEnd" ErrorMessage="Select a valid date"></asp:RequiredFieldValidator>
     
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4">
                                        <label for="txtStartTime">Start Time <span style="color: red">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtStartTime" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtStartTime" ID="RequiredFieldValidator1" runat="server"
                                            ForeColor="Red" ErrorMessage="Please enter "></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-md-4">
                                        <label for="txtEndTime">End Time <span style="color: red">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtEndTime" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtEndTime" ID="RequiredFieldValidator3" runat="server"
                                            ForeColor="Red" ErrorMessage="Please enter"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-md-4">
                                        <label for="txtSlot">Slot <span style="color: red">*</span></label>
                                        <asp:TextBox class="form-control" ID="txtSlot" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="txtSlot" ID="RequiredFieldValidator6" runat="server"
                                            ForeColor="Red" ErrorMessage="Please enter"></asp:RequiredFieldValidator>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                         <label for="txtNote">Note </label>
                                        <asp:TextBox class="form-control" ID="txtNote" runat="server"></asp:TextBox>
         
                                    </div>

                                    <div class="col-md-4">
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-8">
                                <asp:GridView ID="gdvDoc" CssClass="table table-bordered table-condensed" runat="server" Width="100%"
                                    AllowPaging="True" PageSize="10" AutoGenerateColumns="false" DataKeyNames="TreatmentId"
                                    GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                    OnPageIndexChanging="gdvDoc_PageIndexChanging"
                                    OnRowEditing="gdvDoc_RowEditing"
                                    OnRowCancelingEdit="gdvDoc_RowCancelingEdit"
                                    OnRowDeleting="gdvDoc_RowDeleting"
                                    OnRowDataBound="gdvDoc_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Edit" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-primary" Text="Edit"
                                                    CommandName="Edit" ToolTip="Click here to Edit the record" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TreatmentId" Visible="false">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="TreatmentId" Text='<%#Eval("TreatmentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Patient Reg Id" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="PatientRegId" Text='<%#Eval("PatientRegId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ipd" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="Ipd" Text='<%#Eval("Ipd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opd" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="Opd" Text='<%#Eval("Opd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="FollowUp Date" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="FollowUpDate" Text='<%#Eval("FollowUpDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Branch Id" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="BranchId" Text='<%#Eval("BranchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Created By" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="CreatedBy" Text='<%#Eval("CreatedBy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Created On" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="CreatedOn" Text='<%#Eval("CreatedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton CausesValidation="false" ID="Delete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="Delete"
                                                    OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                                    <FooterStyle CssClass="DataGridFixedHeader" />
                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="cssPager" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

