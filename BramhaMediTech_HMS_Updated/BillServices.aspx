<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillServices.aspx.cs" Inherits="BillServices" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_ddlBillGroupName").value == "0") {

                 alert("select Bill Group");
                 return false;
             }

             if (document.getElementById("MainContent_txtBillService").value == "") {

                 alert("Please Enter Bill Particular !");
                 return false;

             }
             

             if (document.getElementById("MainContent_txtPrintOrderNo").value == "") {
                 alert("Please Enter Print Order No!");
                 return false;
             }

         }

       </script>
      <script language="javascript" type="text/javascript">
          function ValidateDelete() {
              var Check = confirm('Are you sure you want to delete this billservice ?')
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
                    <h1>Bill Services</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Bill Services</li>
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
                                                         <label for="txtBillServiceSearch">Bill Service:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                                                                        
                                               <asp:TextBox ID="txtBillServiceSearch" runat="server" CssClass="form-control" Placeholder="Enter Bill Service" 
                                                 OnTextChanged="txtBillServiceSearch_TextChanged"></asp:TextBox>                      
          
                                            </div>
                                        </div>
                                        <div class="col-sm-1">
                                                    <div class="form-group">
                                                         <label for="ddlBillGroupNameSearch">Group </label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">

                                                <asp:DropDownList ID="ddlBillGroupNameSearch" runat="server" CssClass="form-control form-select" 
                                                 AutoPostBack="true" OnSelectedIndexChanged="ddlBillGroupNameSearch_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">

                                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-warning"
                                             CausesValidation="false" />
                                                <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-primary " 
                                                Text="Add New" onclick="btnaddnew_Click"/>

                                           </div>

                                        </div>                                         
                                    </div>
                               </div>                               
                                 <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                                                                      
                         
                           <asp:GridView ID="gvBillService" runat="server" AutoGenerateColumns="False" DataKeyNames="BillServiceId"
                                OnRowDeleting="gvBillService_RowDeleting" OnRowEditing="gvBillService_RowEditing"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"                              
                                CellPadding="3" AllowPaging="True" OnPageIndexChanging="gvBillService_PageIndexChanging"
                                PageSize="25" ShowHeaderWhenEmpty="True">
                                <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                    <Columns>
                               
                                <asp:BoundField DataField="BillServiceId" HeaderText="Bill Service Id" Visible="False" />
                                <asp:BoundField DataField="ServiceName" HeaderText="Bill Service" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="520px" />
                                <asp:BoundField DataField="GroupName" HeaderText="Bill Group" ItemStyle-Width="520px" />
                               
                                <asp:BoundField DataField="ServiceOrder" HeaderText="Print Order No" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="560px" />
                               
                                <asp:CommandField ButtonType="Image" HeaderText="Edit" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="10px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Delete" >
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
                                                                 <label for="ddlBillGroupName">Bill Group:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 ">
                                            <div class="form-group">
                                                                                                    
                                                <asp:DropDownList ID="ddlBillGroupName" runat="server" CssClass="form-control form-select" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlBillGroupName_SelectedIndexChanged" height="30px">
                                                </asp:DropDownList>
                                                
          
                                            </div>
                                        </div>
                                             <div class="col-sm-2">
                                                        <div class="form-group">                                                                           
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="ChkActive" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkIpd">Active</label>
                                                            </div>                                                              
                   
                                                        </div>
                                                </div>
                                                
                                            </div>

                                                <div class="row mb-3"> 
                                                     
                                            <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtBillService">Bill Service:</label>                                                                                
                                                    </div>
                                            </div>  
                                            <div class="col-sm-3" runat="server" id="BillServiceBox">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtBillService" runat="server" AutoPostBack="True" 
                                                      OnTextChanged="txtBillService_TextChanged" CssClass="form-control" Placeholder="Enter Bill Service(*)" >
                                                     </asp:TextBox>
                                                </div>
                                            </div>
                                                     
                                                    <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="chkOpd">Enable For:</label>                                                                                
                                                    </div>
                                            </div> 
                                            <div class="col-sm-1 text-left">
                                                        <div class="form-group">                                                              
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="chkOpd" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkOpd">OPD</label>
                                                            </div>
                                                        </div>
                                                </div>
                                            <div class="col-sm-1">
                                                        <div class="form-group">                                                                           
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input" id="chkIpd" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkIpd">IPD</label>
                                                            </div>                                                              
                   
                                                        </div>
                                                </div>
                                                      <div class="col-sm-2">
                                                        <div class="form-group">                                                                           
                                                            <div class="form-check">
                                                                 <input type="checkbox" class="form-check-input" id="chkIPDDaily"  runat="server"   />
                                                                <label class="form-check-label" for="chkIpd">IS IPD Daily</label>
                                                                </div>
                                                            </div>
                                                          </div>
                                             </div>
                                            
                                             <div class="row mb-3"  id="RoomType" runat="server">
                                                 
                                                      <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtBillService">Bill Service Room Type:</label>                                                                                
                                                    </div>
                                            </div> 
                                                    <div class="col-sm-3 text-left" >                                            
                                            <div class="form-group"> 
                                               
                                                 <asp:DropDownList ID="ddlRoomTypeName" runat="server" Class="form-control form-select" AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                                  
                                                 </div>
                                            <div class="row mb-3">
                                                                                          
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="ddlUnitOfCharge">Unit Of Charges:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3">
                                                          <div class="form-group"> 
                                                             <asp:DropDownList ID="ddlUnitOfCharge" runat="server" class="form-control form-select"
                                                        height="30px">
                                                                 <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                 <asp:ListItem Selected="True">Day</asp:ListItem>
                                                                 <asp:ListItem >Hour</asp:ListItem>
                                                </asp:DropDownList>                                                                                                                           
                                                         </div>
                                                     </div>                                               
                                                 
                                         </div>     
                                           
                                                <div class="row mb-3">                                            
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtPrintOrderNo">Order No:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3">
                                                          <div class="form-group"> 
                                                            <asp:TextBox ID="txtPrintOrderNo" runat="server" AutoPostBack="True"   Class="form-control" Placeholder="Print Order No(*)"
                                                                 OnTextChanged="txtPrintOrderNo_TextChanged">
                                                            </asp:TextBox>                                                                                                                                 
                                                         </div>
                                                     </div>                                               
                                                 </div>  
                                                                    
                                                 
                                             <div class="row mb-3"> 
                                                 <div class="col-sm-2">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" Width="300px" RepeatDirection="Horizontal" >
                                                             <asp:ListItem Selected="True" Value="DocWise">DocWise</asp:ListItem>
                                                             <asp:ListItem Value="RoomWise">RoomWise</asp:ListItem>
                                                             <asp:ListItem Value="Direct">Direct</asp:ListItem>
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                
                                            
                                        </div>
                                            
                                       
                                        <div class="col-sm-12 text-center">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" OnClientClick="return Validate();"
                                              />
                                              <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" class="btn btn-primary"
                                              CausesValidation="False" />
                                            <asp:Button ID="btnSetCharges" runat="server" Text="Set Charges" class="btn btn-danger" autopostback="true"
                                             OnClick="btnSetCharges_Click" />
                                             
                                        </div>
                                    

                                       
                                    
                               </div>                               
                               
                            </div>

                 

                        </section>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

