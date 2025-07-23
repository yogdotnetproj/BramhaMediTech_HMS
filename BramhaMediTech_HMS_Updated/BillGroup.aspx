<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillGroup.aspx.cs" Inherits="BillGroup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtBillGroup").value == "") {

                 alert("Enter Bill Group");
                 return false;
             }

         }

         function numeric_only(e) {
             var keycode;
             if (window.event)
                 keycode = window.event.keyCode;
             else if (event)
                 keycode = event.keyCode;
             else if (e)
                 keycode = e.which;
             else
                 return true;
             if ((keycode == 46) || (keycode >= 48 && keycode <= 57)) {
                 return true;
             }
             else {
                 return false;
             }
             return true;
         }
       </script>
       <script language="javascript" type="text/javascript">
           function ValidateDelete() {
               var Check = confirm('Are you sure you want to delete this Billgroup ?')
               if (Check == true) {
                   return true;
               }
               else {
                   return false;
               }
           }

 </script> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Bill Group</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Bill Group</li>
                    </ol>
                </section>
            <section class="content">
                
                            <div class="box" runat="server" id="List" >
                                 
                                    <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                 <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-warning pull-right" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
                                        </div>
                                    
                             <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                                                                      
                         
                                 <asp:GridView ID="gvBillGroup" runat="server" AutoGenerateColumns="False" DataKeyNames="BillGroupId"
                                OnRowDeleting="gvBillGroup_RowDeleting" OnRowEditing="gvBillGroup_RowEditing"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"                              
                                CellPadding="3" AllowPaging="True" OnPageIndexChanging="gvBillGroup_PageIndexChanging"
                                PageSize="25" ShowHeaderWhenEmpty="True">
                                      <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                    <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="BillGroupId" HeaderText="Bill Group Id" Visible="False" />
                                <asp:BoundField DataField="GroupName" HeaderText="Group Name" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="60px" />                               
                                <asp:BoundField DataField="GroupOrderNo" HeaderText="Group Order" ItemStyle-HorizontalAlign="Left"
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
                                       
                                              <div class="row mb-3">                                                                               
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtBillGroup">Bill Group:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 ">
                                            <div class="form-group">
                                                                                                    
                                                <asp:TextBox ID="txtBillGroup" runat="server" AutoPostBack="True" CssClass="form-control" Placeholder="Enter Bill Group(*)" >
                                                     </asp:TextBox>
                                                
          
                                            </div>
                                        </div>
                                                  </div>
                                                
                                                  
                                                         <div class="row mb-3">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtGroupOrder">Group Type:</label>                                                                                
                                                    </div>
                                            </div>  
                                                 <div class="col-sm-3">
                                                <div class="form-group form-check">
                                                     <asp:RadioButtonList ID="RblGroupType" runat="server" RepeatDirection="Horizontal">
                                                         <asp:ListItem Selected="True" Text="OPD" Value="0">  </asp:ListItem>
                                                          <asp:ListItem Text="IPD" Value="1">  </asp:ListItem>
                                                          <asp:ListItem Text="All" Value="2">  </asp:ListItem>
                                                     </asp:RadioButtonList>
                                                </div>
                                            </div>  
                                                         </div>                                          
                                         

                                                  
                                                         <div class="row mb-3">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtGroupOrder">Daily Service:</label>                                                                                
                                                    </div>
                                            </div>  
                                                 <div class="col-sm-3">
                                                <div class="form-group form-check p-0">
                                                    <asp:CheckBox runat="server" ID="ChkDailyService" />
                                                    
                                                </div>
                                            </div>  
                                                         </div>       

                                                     
                                                         <div class="row mb-3">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtGroupOrder">Group Order:</label>                                                                                
                                                    </div>
                                            </div>  
                                                 <div class="col-sm-3">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtGroupOrder" runat="server" AutoPostBack="True" Class="form-control" onkeyPress="return numeric_only(event);" Placeholder="Enter Group Order" >
                                                     </asp:TextBox>
                                                </div>
                                            </div>  
                                                         </div>                                          
                                         
                                          
                                                     <div class="col-sm-12 text-left">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" OnClientClick="return Validate();"
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

