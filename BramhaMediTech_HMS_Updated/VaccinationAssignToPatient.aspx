<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="VaccinationAssignToPatient.aspx.cs" Inherits="VaccinationAssignToPatient" %>
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
        <h1>Vaccination Details</h1>
           <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Vaccination Details</li>
                    </ol>
    </section>
     <section class="content">
        <div id="Div1" class="box" runat="server">
           <!-- <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
              

                  <div class="col-lg-12 mt-3" > 
                                            <div class="row">
                                                 <label for="lblBranchId" class="panel-heading" style="text-align: center ;font-size:medium;font-weight:bold"> Vaccination Details:</label>
                                                 <asp:Label id="lblmsg" style="text-align: center" ForeColor="Red" runat="server"  Font-Bold="true"> </asp:Label>
                                                </div>
                      </div>
                  <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvPatientCat" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                     OnPageIndexChanging="gvPatientCat_PageIndexChanging" OnRowEditing="gvPatientCat_RowEditing"
                    DataKeyNames="VaccianId" AllowPaging="True" PageSize="50" OnRowDeleting="gvPatientCat_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                               
                                <asp:BoundField DataField="VaccnationName" HeaderText="Vaccnation Name" 
                                   />
                                <asp:BoundField DataField="FromAge" HeaderText="From Age" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                            <asp:BoundField DataField="ToAge" HeaderText="To Age" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                            <asp:BoundField DataField="AgeType" HeaderText="Age Type" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Delete" runat="server" Text="Assign"   CommandName="Delete" 
                                            
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" EditText="Assign"  Visible="false"
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
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

                <div class="col-lg-12">
                    <div class="row"></div>

                </div>

                  <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="GVVaccinationAssign" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="1000px" OnPageIndexChanging="GVVaccinationAssign_PageIndexChanging" OnRowEditing="GVVaccinationAssign_RowEditing"
                    DataKeyNames="VId" AllowPaging="True" PageSize="50" OnRowDeleting="GVVaccinationAssign_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                <asp:CommandField ButtonType="Image" Visible="false" EditText="Assign" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="VaccnationName" HeaderText="Vaccnation Name" 
                                   />
                            <asp:BoundField DataField="GivenDate" HeaderText="Given Date" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="Given By" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>  
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Delete" runat="server" Text="Delete"    CommandName="Delete" 
                                            
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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
                </div>
                                                </div>
                       
                    </div>

               
            </div>
            
          
        </div>

    </section>
</asp:Content>

