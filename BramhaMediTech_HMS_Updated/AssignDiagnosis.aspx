<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="AssignDiagnosis.aspx.cs" Inherits="AssignDiagnosis" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content-header d-flex">
        <h1>Diagnosis</h1>
           <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Diagnosis Details</li>
                    </ol>
    </section>
     <section class="content">
        <div id="Div1" class="box" runat="server">
            <!--<div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
                
                    

                  <div class="col-sm-12 mt-3" > 
                                            <div class="row">
                                                 <label for="lblBranchId" class="panel-heading" style="text-align: center; font-size:medium;font-weight:bold"> Assign Diagnosis:</label>
                                                 <asp:Label id="lblmsg" style="text-align: center" ForeColor="Red" runat="server"  Font-Bold="true"> </asp:Label>
                                                </div>
                      </div>
                   <div class="col-sm-12 mt-3" > 
                                            <div class="row">
                                                <div class="col-sm-2 text-left">
                                        <div class="form-group">
                                            <label for="txtDrugName">Search Diagnosis<span style="color: red">*</span></label>
                                        </div>
                                                    </div>
                                                 <div class="col-sm-6 text-left">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtDiagnosis" runat="server" AutoCompleteType="None"
                                                AutoPostBack="false" TabIndex="1" CssClass="form-control" placeholder="Search Diagnosis Name">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender
                                                MinimumPrefixLength="1"
                                                ServiceMethod="SearchDiagnosis"
                                                CompletionInterval="100"
                                                EnableCaching="false"
                                                CompletionSetCount="10"
                                                  CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtDiagnosis"
                                                ID="AutoCompleteExtender3"
                                                runat="server">
                                            </asp:AutoCompleteExtender>
                                            <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="txtDiagnosis" ID="RequiredFieldValidator11"
                                                runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                                <div class="col-sm-2 text-left">
                                        <div class="form-group">

                                            <asp:Button ID="btnsave" class="btn btn-primary btnSearch" runat="server" Text="Add" OnClick="btnsave_Click" />
                                            </div>
                                                    </div>
                                                </div>
                      </div>
                  <div class="col-sm-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvAssignDiagnosis" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="1000px" OnPageIndexChanging="gvAssignDiagnosis_PageIndexChanging" OnRowEditing="gvAssignDiagnosis_RowEditing"
                    DataKeyNames="Diagid" AllowPaging="True" PageSize="50" OnRowDeleting="gvAssignDiagnosis_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                               <asp:CommandField ButtonType="Image" Visible="false" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="DiagnosisName" HeaderText="Diagnosis Name"  />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete"  runat="server" ImageUrl="~/Images0/delete.gif"  CommandName="Delete" 
                                            
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                           
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                           <PagerStyle CssClass="pagination" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
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

                <div class="col-sm-12">
                    <div class="row"></div>

                </div>

                  <div class="col-sm-12" > 
                                            
                       
                    </div>

               
            </div>
            
          
        </div>

    </section>
</asp:Content>
