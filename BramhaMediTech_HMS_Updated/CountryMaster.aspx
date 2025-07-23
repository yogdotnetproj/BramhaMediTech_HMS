<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="CountryMaster.aspx.cs" Inherits="CountryMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtCountryName").value == "") {
                alert("Please Enter Country Name");
                return false;
            }

            if (document.getElementById("MainContent_txtCountryCode").value == "") {

                alert("Please Enter Code!");
                return false;

            }
        }
        </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
        <ContentTemplate>
      <section class="content-header d-flex">
                    <h1>Country Master</h1>
                    <ol class="breadcrumb">
                        <%--<li><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                        <li><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>
                     --%>   <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Country Master</li>
                    </ol>
                </section>
      <section class="content">
                            <div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMsg" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>                                     
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row mb-3">
                                     <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtCountryName">Country Name:</label>                                                                                
                                        </div>
                                    </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">       
                                              <asp:TextBox ID="txtCountryName" placeholder="Enter Country Name(*)" CssClass="form-control" height="30px" runat="server" TabIndex="1"></asp:TextBox>
                                               </div>
                                        </div>
                                    </div>

                                    <div class="row mb-3">    
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <label for="txtCountryCode">Country Code:</label>                                                                                
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">              
                                             
                                                 <asp:TextBox ID="txtCountryCode" runat="server" placeholder="Enter Country Code(*)" Class="form-control" height="30px" TabIndex="2"></asp:TextBox>
                                          
                                            </div>
                                        </div>
                                        <div class="col-sm-4 text-Center">
                                    
                                             <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  OnClientClick="return Validate(); " 
                                              Text="Save" onclick="btnSave_Click"/>                                    
                                     
                                             <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"   CausesValidation="False" 
                                             onclick="btnReset_Click" Text="Reset"/>

                                            <asp:Button ID="btnPrint" runat="server" CausesValidation="False" Visible="false" CssClass="btn btn-primary"  
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" />
    
                                        </div>
                                         
                                     </div>                                    
                                    
                                    <div class="row mb-3">
                                <div class="col-lg-12" > 
                                        <div class="table-responsive" style="width:100%">                                                
                          
                            
                            <asp:GridView ID="GvCountry" runat="server" AutoGenerateColumns="False" OnRowDeleting="GvCountry_RowDeleting"
                              class="table table-responsive table-sm table-bordered" Width="100%"  
                             AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"
                            OnRowEditing="GvCountry_RowEditing" DataKeyNames="CountryId" BackColor="White"
                            BorderWidth="1px" CellPadding="3" AllowPaging="True"
                            PageSize="5" OnPageIndexChanging="GvCountry_PageIndexChanging" TabIndex="5" EmptyDataText="No Records to Display"
                            ShowHeaderWhenEmpty="True" Style="margin-right: 0px" >
                            <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                
                                <asp:BoundField DataField="CountryId" HeaderText="CountryId" Visible="False" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                                <asp:BoundField DataField="IsActive" HeaderText="IsActive" Visible="False" />
                                <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" Visible="False" />
                                <asp:BoundField DataField="CreatedOn" HeaderText="CreatedDateTime" Visible="False" />
                                <asp:BoundField DataField="UpdatedBy" HeaderText="UpdatedBy" Visible="False" />
                                <asp:BoundField DataField="UpdatedOn" HeaderText="UpdatedDateTime" Visible="False" />
                                
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                            OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                            CommandName="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
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
                                </div>
                               
                            </div>
                        
                        </section>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

