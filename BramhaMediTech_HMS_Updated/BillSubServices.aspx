<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillSubServices.aspx.cs" Inherits="BillSubServices" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

      <script type = "text/javascript">
          function Validate() {

              if (document.getElementById("MainContent_ddlBillService").value == "0") {

                  alert("select Bill Service");
                  return false;
              }

              if (document.getElementById("MainContent_txtBillSubService").value == "") {

                  alert("Please Enter Bill SubService !");
                  return false;

              }


             

          }

       </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Bill Sub Services</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Bill Sub Services</li>
                    </ol>
                </section>
            <section class="content">
                
                            <div class="box" runat="server" id="List" >
                                 <div class="box-header with-border">
                                     <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                     </div>
                                 <div class="box-body">                     
                                    <div class="row">                                
                                         <div class="col-sm-2">
                                              <div class="form-group">
                                                 <label for="ddlBillServiceSearch">Bill Service:</label>                                                                                
                                             </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">

                                                <asp:DropDownList ID="ddlBillServiceSearch" runat="server" class="form-control form-select" 
                                                 AutoPostBack="true" OnSelectedIndexChanged="ddlBillServiceSearch_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                       
                             
                                        <div class="col-sm-3">
                                            <div class="form-group">

                                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-primary"
                                             CausesValidation="false" />
                                                <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-primary " 
                                                Text="Add New" onclick="btnaddnew_Click"/>

                                           </div>

                                        </div>                                         
                                    </div>
                               </div>                               
                                 <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                                                                      
                         
                           <asp:GridView ID="gvBillSubService" runat="server" AutoGenerateColumns="False" DataKeyNames="BillServiceId"
                                OnRowDeleting="gvBillSubService_RowDeleting" OnRowEditing="gvBillSubService_RowEditing"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"                              
                                CellPadding="3" AllowPaging="True" OnPageIndexChanging="gvBillSubService_PageIndexChanging"
                                PageSize="25" ShowHeaderWhenEmpty="True">

                                    <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="BillSubServiceId" HeaderText="Bill Service Id" Visible="False" />
                                <asp:BoundField DataField="ServiceOrder" HeaderText="Order No" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="60px" />                               
                                <asp:BoundField DataField="ServiceDetails" HeaderText="Bill Sub Services" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="120px" />
                                
                               
                               
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Imagebutton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                            OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                            CommandName="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                
                                </div>
                                 <div class="box-body">
                                       
                                              <div class="row">                                                                               
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="ddlBillService">Bill Service:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 ">
                                            <div class="form-group">
                                                                                                    
                                                <asp:DropDownList ID="ddlBillService" runat="server" CssClass="form-control form-select">
                                                </asp:DropDownList>
                                                
          
                                            </div>
                                        </div>
                                                
                                                     <div class="col-lg-12 mt-3">
                                                         <div class="row">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtBillSubService">Bill Sub Service:</label>                                                                                
                                                    </div>
                                            </div>  
                                                 <div class="col-sm-3">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtBillSubService" runat="server" AutoPostBack="True" 
                                                      OnTextChanged="txtBillSubService_TextChanged" CssClass="form-control" Placeholder="Enter Bill Sub Service(*)" >
                                                     </asp:TextBox>
                                                </div>
                                            </div>  
                                                         </div>                                          
                                         
                                            </div> 
                                          
                                                     <div class="col-lg-12 text-left">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" OnClientClick="return Validate();"
                                            />
                                              <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-primary"
                                              CausesValidation="False" />
                                             
                                        </div>
                                              </div>

                                      </div>                                      
                          </div>                               
                               
                            

                 

                        </section>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

