<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="HealthPackageMaster.aspx.cs" Inherits="HealthPackageMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <script type = "text/javascript">
          function Validate() {

              if (document.getElementById("MainContent_txtPackageName").value == "0") {

                  alert("select Bill Group");
                  return false;
              }

              

          }

       </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Health Package</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Health Package</li>
                    </ol>
                </section>
            <section class="content">
                
                            <div class="box" runat="server" id="List" >
                                 <div class="box-header with-border">
                                     <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                    <asp:Button ID="btnaddnew" runat="server" class="btn btn-primary pull-right" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
    
                                 </div>
                                                            
                                 <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                                                                      
                         
                           <asp:GridView ID="gvHealthPackage" runat="server" AutoGenerateColumns="False" DataKeyNames="HPackId"
                                OnRowDeleting="gvHealthPackage_RowDeleting" OnRowEditing="gvHealthPackage_RowEditing"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"                              
                                CellPadding="3" AllowPaging="True" OnPageIndexChanging="gvHealthPackage_PageIndexChanging"
                                PageSize="25" ShowHeaderWhenEmpty="True">

                                    <AlternatingRowStyle BackColor="White" />

                                    <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="HPackId" HeaderText="HPackId" Visible="False" />
                                <asp:BoundField DataField="HPackName" HeaderText="Package" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="200px" >
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HPackDetails" HeaderText="Package Details" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="200px" >
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="HPackAmount" HeaderText="Pack Amount" ItemStyle-Width="120px" >
                               
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:BoundField>
                               
                                <asp:BoundField DataField="FromDate" HeaderText="Valid From" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="120px" DataFormatString="{0:dd/MM/yyyy}" >
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:BoundField>
                                <asp:BoundField DataField="ToDate" HeaderText="Valid To" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="120px" DataFormatString="{0:dd/MM/yyyy}" >
                               
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:BoundField>
                               
                                <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:Button ID="btnAddService" runat="server" Text="Add/Edit Services" OnClick="btnAddService_Click" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Imagebutton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                            OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                            CommandName="Delete" />
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
                                                         <label for="txtPackName">Package Name:</label>                                                                                
                                                    </div>
                                            </div>  
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtPackName" runat="server" AutoPostBack="True" 
                                                       Class="form-control" Placeholder="Enter Package Name(*)" >
                                                     </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                        <div class="form-group">                                                              
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="chkOpd" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkOpd">OPD</label>
                                                            </div>
                                                        </div>
                                                </div>
                                            <div class="col-sm-2">
                                                        <div class="form-group">                                                                           
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="chkIpd" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkIpd">IPD</label>
                                                            </div>                                                              
                   
                                                        </div>
                                                </div>
                                        </div>
                                            
                                                <div class="row mb-3">                                                                               
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtPackDetails">Package Details:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 ">
                                                             <div class="form-group">                                                                                                    
                                                                    <asp:TextBox ID="txtPackDetails" runat="server" AutoPostBack="True" 
                                                                    CssClass="form-control" Placeholder="Enter Package Details" >
                                                                    </asp:TextBox>
                                                             </div>
                                                     </div>
                                                    <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtPackAmount">Package Amount:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 ">
                                                             <div class="form-group">                                                                                                    
                                                                    <asp:TextBox ID="txtPackAmount" runat="server" AutoPostBack="True" 
                                                                    CssClass="form-control" Placeholder="Enter Package Amount" >
                                                                    </asp:TextBox>
                                                             </div>
                                                     </div>
                                                </div>
                                            
                                            
                                                <div class="row mb-3">                                            
                                                   <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtFromDate">Valid From :</label>                                                                                
                                                          </div>
                                                   </div>
                                                   <div class="col-sm-3">
                                                        <div class="form-group">
                                                          <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TabIndex="12" Height="30px"
                                                             AutoPostBack="True"></asp:TextBox>                                                             
                                                          <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                        </div>                                          
                                                     </div>  
                                                  </div> 
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtToDate">Valid To :</label>                                                                                
                                                          </div>
                                                   </div>
                                                   <div class="col-sm-3">
                                                        <div class="form-group">
                                                          <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                            <asp:TextBox ID="txtToDate" runat="server"   class="form-control" TabIndex="12" Height="30px"
                                                             AutoPostBack="True"></asp:TextBox>                                                             
                                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>                 
                                                        </div>                                          
                                                     </div>  
                                                  </div>     
                                                 </div>
                                                                           
                                                                                              
                                            
                                       
                                        <div class="col-lg-12 text-center">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" OnClientClick="return Validate();"
                                             Width="80px" />
                                              <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-primary" Width="80px"
                                              CausesValidation="False" />
                                             
                                        </div>
                                    

                                       
                                    
                               </div>                               
                               
                            </div>

                 

                        </section>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

