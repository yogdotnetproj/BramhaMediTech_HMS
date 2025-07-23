<%@ Page Title="Treatment" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmTreatment.aspx.cs" Inherits="frmTreatment" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <h1>Treatment</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                            <asp:HiddenField ID="txtTreatId" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-2">
                                <label for="txtPatientRegId">Patient Reg Id</label>
                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtPatientRegId" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label for="txtOpd">Opd</label>
                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtOpd" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label for="txtIpd">Ipd</label>
                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtIpd" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label for="txtBranchId">Branch Id</label>
                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtBranchId" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label for="txtFollowUp">Follow up date</label>
                                <asp:TextBox ReadOnly="true" class="form-control" ID="txtFollowUp" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender PopupButtonID="txtFollowUp" CssClass="AjaxCalendar" 
                                    Format="dd/MM/yyyy" TargetControlID="txtFollowUp" ID="CalendarExtender3" runat="server"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-4">
                                <label for="txtDrugName">Drug Name <span style="color: red">*</span></label>
                                <asp:TextBox class="form-control" ID="txtDrugName" runat="server"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender EnableCaching="true" MinimumPrefixLength="3" CompletionSetCount="5"
                                    FirstRowSelected="true" ServiceMethod="GetDrugsName" CompletionInterval="100"
                                      CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"  TargetControlID="txtDrugName" ID="AutoCompleteExtender1" runat="server">
                                </ajaxToolkit:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ControlToValidate="txtDrugName" ID="RequiredFieldValidator1" runat="server"
                                    ForeColor="Red" ErrorMessage="Please enter drug name"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-2">
                                <label for="drpfrequency">Frequency <span style="color: red">*</span></label>
                                <asp:DropDownList ID="drpfrequency" AutoPostBack="True"
                                    class="form-control" runat="server"
                                    OnSelectedIndexChanged="drpfrequency_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drpfrequency" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <label for="txtDays">Days <span style="color: red">*</span></label>
                                <asp:TextBox Text="0" OnTextChanged="txtDays_TextChanged" AutoPostBack="true" class="form-control" ID="txtDays" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                    ControlToValidate="txtDays" runat="server"
                                    ErrorMessage="Only Numbers"
                                    ValidationExpression="\d+">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ControlToValidate="txtDays" ID="RequiredFieldValidator3" runat="server"
                                    ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <label for="txtStart">Start date <span style="color: red">*</span></label>
                                <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" OnTextChanged="txtStart_TextChanged" ID="txtStart" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender PopupButtonID="txtStart" CssClass="AjaxCalendar" Format="dd/MM/yyyy" TargetControlID="txtStart" ID="CalendarExtender1" runat="server"></ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ControlToValidate="txtStart" ID="RequiredFieldValidator4" runat="server"
                                    ForeColor="Red" ErrorMessage="select"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <label for="txtEnd">End date <span style="color: red">*</span></label>
                                <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged" ID="txtEnd" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender PopupButtonID="txtEnd" CssClass="AjaxCalendar" Format="dd/MM/yyyy" TargetControlID="txtEnd" ID="CalendarExtender2" runat="server"></ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ControlToValidate="txtEnd" ID="RequiredFieldValidator5" runat="server"
                                    ForeColor="Red" ErrorMessage="select"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-8">
                                <label for="txtNote">Note</label>
                                <asp:TextBox class="form-control" TextMode="MultiLine" Rows="2" ID="txtNote" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" CausesValidation="true" class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card-body table-responsive">
                                <asp:GridView ID="gdvTreatment" OnPreRender="gdvTreatment_PreRender" CssClass="table table-bordered table-condensed" runat="server" Width="100%"
                                    AllowPaging="True" PageSize="5" AutoGenerateColumns="false" DataKeyNames="TransId"
                                    GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                    OnPageIndexChanging="gdvTreatment_PageIndexChanging"
                                    OnRowEditing="gdvTreatment_RowEditing"
                                    OnRowCancelingEdit="gdvTreatment_RowCancelingEdit"
                                    OnRowDeleting="gdvTreatment_RowDeleting"
                                    OnRowDataBound="gdvTreatment_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Edit" runat="server" CausesValidation="false" CssClass="btn btn-sm btn-primary" Text="Edit"
                                                    CommandName="Edit" ToolTip="Click here to Edit the record" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TransId" Visible="false">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="TransId" Text='<%#Eval("TransId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TreatmentId" Visible="false">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="TreatmentId" Text='<%#Eval("TreatmentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="DrugName" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="DrugName" Text='<%#Eval("DrugName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="FrequencyType" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="FrequencyType" Text='<%#Eval("FrequencyType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Days" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="Days" Text='<%#Eval("Days") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="StartDate" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="StartDate" Text='<%#Eval("StartDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="EndDate" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="EndDate" Text='<%#Eval("EndDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Note" Visible="true">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="Note" Text='<%#Eval("Note") %>'></asp:Label>
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

    <script src="Scripts/jquery-3.0.0.js"></script>

</asp:Content>

