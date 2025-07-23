<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="FinancialYearMst.aspx.cs" Inherits="FinancialYearMst" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtFinancialYear").value == "") {
                alert("Please Enter FinancialYear");
                return false;
            }
            if (document.getElementById("MainContent_txtStartDate").value == "") {
                alert("Please Enter Start Date");
                return false;
            }
            if (document.getElementById("MainContent_txtEndDate").value == "") {
                alert("Please Enter End Date");
                return false;
            }
        }
        </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         
              <ContentTemplate>
     <section class="content-header d-flex">
                    <h1>Financial Year</h1>
                   
    </section>
    
     <section class="content">
                    <div class="box" runat="server" id="List" >
                       <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                              
                           <asp:Button ID="btnaddnew" runat="server" class="btn btn-primary pull-right" 
                                        Text="Add New" CausesValidation="false" onclick="btnaddnew_Click"/>
                          
                        </div>
                        <div class="box-body">
                           <div class="table-responsive" style="width:100%">          
                                               
                             <asp:GridView ID="gvFinancialYear" runat="server" AutoGenerateColumns="False" DataKeyNames="FinancialYearId" class="table table-responsive table-sm table-bordered" Width="100%"
                                 OnRowDeleting="gvFinancialYear_RowDeleting" 
                                 OnRowEditing="gvFinancialYear_RowEditing" 
                                 EmptyDataText="No Records To Display" 
                                 onpageindexchanging="gvFinancialYear_PageIndexChanging"
                                 HeaderStyle-ForeColor="Black"
                                 AlternatingRowStyle-BackColor="White"
                                 CellPadding="3" AllowPaging="True" 
                                 PageSize="5" 
                                TabIndex="6" ShowHeaderWhenEmpty="True">                                 

                           <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" ShowCancelButton="False"
                                    ShowEditButton="True"  HeaderText="Edit">
                                    <ItemStyle Width="70px" HorizontalAlign="Center"  />
                                </asp:CommandField>
                                <asp:BoundField DataField="FinancialYearId" HeaderText="Financial Year Id" Visible="False" />
                                <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" ItemStyle-HorizontalAlign="Left">                                   <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                
                                
                                <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CausesValidation="false" CommandName="Delete"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
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
                 <!--   ======================== -->
                   <div class="box" runat="server" id="show">
                        <div class="box-header with-border">                           
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>
                        <div class="box-body">
                            <div class="row mb-3">
                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFinancialYear">Financial Year:</label>                                                                                
                                                    </div>
                                         </div>
                               <div class="col-sm-3">
                                   <div class="form-group">
                                        <asp:TextBox ID="txtFinancialYear" runat="server" CssClass="form-control"  placeholder="Enter Financial year(*)"  AutoPostBack="True"
                                        TabIndex="1"></asp:TextBox>
                                       
                                    </div>
                                </div>
                                </div>
                                            <div class="row mb-3">

                                                                          
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtStartDate">Start Date:</label>                                                                                
                                                    </div>
                                         </div>
                                <div class="col-sm-3">
                                   <div class="form-group">                                        
                                        
                                    <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                             <asp:TextBox  runat="server" CssClass="form-control"  id="txtStartDate" Placeholder="Enter Start date"  />
                                                      <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        
                                    </div>
                                      

                                      </div>
                                  </div>

                                                </div>
                                     

                                
                                            <div class="row mb-3">

                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtEndDate">End Date:</label>                                                                                
                                                    </div>
                                         </div>

                                <div class="col-sm-3">
                                   <div class="form-group">
                                         <div class="input-group date" data-date-format="dd/mm/yyyy" data-autoclose="true" data-provide="datepicker">
                                             
                                              <asp:TextBox  runat="server" class="form-control" id="txtEndDate" Height="30px" Placeholder="Enter End date" />
                                                      <span class="input-group-addon">
                                                 <i class="fa fa-calendar"></i>
                                            </span>
                                            
                  
                                        </div>
                                        
                                   </div>
                                </div>  
                                                </div>
                                                                 
                                
                                
                            
                        </div>
                
                        <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                    
                                     <asp:Button ID="btnSave" runat="server"  class="btn btn-primary"  
                                   Text="Save" onclick="btnSave_Click" TabIndex="4" OnClientClick="return Validate();"/>
                                    
                                     <asp:Button ID="btnReset" runat="server" class="btn btn-primary"  
                                         Text="Reset" onclick="btnReset_Click" CausesValidation="False" TabIndex="5" />                                         
                                         
                                          
                                  
                                </div>
                            </div>
                        </div>
                    </div>

                </section>
                  </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>

