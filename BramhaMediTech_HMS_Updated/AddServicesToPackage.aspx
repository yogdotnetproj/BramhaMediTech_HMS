<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="AddServicesToPackage.aspx.cs" Inherits="AddServicesToPackage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_ddlBillService").value == "0") {
                 alert("Please Select Bill Service");
                 return false;
             }

             if (document.getElementById("MainContent_ddlBillSubService").value == "0") {

                 alert("Please Select Bill Sub Service!");
                 return false;

             }
         }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Add Services To Package</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Add Services To Package</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>

                        <div class="box-body">
                            <div class="row">
                                 <div class="col-sm-1" style="width:150px">
                                                    <div class="form-group">
                                                         <label for="txtPackName" style="text-align:left">Package Name:</label>                                                                                
                                                    </div>
                                            </div>  
                                            <div class="col-sm-3 text-left" style="width:300px">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtPackName" runat="server"   AutoPostBack="True" Enabled="false"
                                                       Class="form-control" Placeholder="Enter Package Name(*)" >
                                                     </asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1 text-left" style="width:100px">
                                                        <div class="form-group">                                                              
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input"  disabled="disabled" id="chkOpd" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkOpd">OPD</label>
                                                            </div>
                                                        </div>
                                                </div>
                                            <div class="col-sm-1" style="width:100px">
                                                        <div class="form-group">                                                                           
                                                            <div class="form-check">
                                                                <input type="checkbox" class="form-check-input"  id="chkIpd" disabled="disabled" autopostback="true" runat="server" oncheckedchanged="chkIpd_CheckedChanged"  />
                                                                <label class="form-check-label" for="chkIpd">IPD</label>
                                                            </div>                                                              
                   
                                                        </div>
                                                </div>
                                            <div class="col-sm-12">
                                                <div class="row">                                                                               
                                                     <div class="col-sm-1" style="width:150px">
                                                          <div class="form-group">
                                                                 <label for="txtPackDetails" style="text-align:left">Package Details:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 text-left" style="width:300px">
                                                             <div class="form-group">                                                                                                    
                                                                    <asp:TextBox ID="txtPackDetails" Width="250px" runat="server" AutoPostBack="True"  Enabled="false"
                                                                    Class="form-control" Placeholder="Enter Package Details" >
                                                                    </asp:TextBox>
                                                             </div>
                                                     </div>
                                                    <div class="col-sm-1" style="width:150px">
                                                          <div class="form-group">
                                                                 <label for="txtPackAmount" style="text-align:left">Package Amount:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3 text-left" style="width:300px">
                                                             <div class="form-group">                                                                                                    
                                                                    <asp:TextBox ID="txtPackAmount" runat="server" Width="250px" AutoPostBack="True" Enabled="false"
                                                                    Class="form-control" Placeholder="Enter Package Amount" >
                                                                    </asp:TextBox>
                                                             </div>
                                                     </div>
                                                </div>
                                            </div> 
                                            <div class="col-sm-12">
                                                <div class="row">                                            
                                                   <div class="col-sm-1" style="width:150px">
                                                          <div class="form-group">
                                                                 <label for="txtFromDate" style="text-align:left">Valid From :</label>                                                                                
                                                          </div>
                                                   </div>
                                                   <div class="col-sm-3 text-left" style="width:300px" >
                                                        <div class="form-group">
                                                          <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                            <asp:TextBox ID="txtFromDate" runat="server" Width="230px"  class="form-control" TabIndex="12" Height="30px" Enabled="false"
                                                             AutoPostBack="True"></asp:TextBox>                                                             
                                                                 <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                </span>                  
                                                        </div>                                          
                                                     </div>  
                                                  </div> 
                                                     <div class="col-sm-1" style="width:150px">
                                                          <div class="form-group">
                                                                 <label for="txtToDate" style="text-align:left">Valid To :</label>                                                                                
                                                          </div>
                                                   </div>
                                                   <div class="col-sm-3 text-left" style="width:300px">
                                                        <div class="form-group">
                                                          <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                            <asp:TextBox ID="txtToDate" runat="server"  Width="230px"   class="form-control" TabIndex="12" Height="30px" Enabled="false"
                                                             AutoPostBack="True"></asp:TextBox>                                                             
                                                                 <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                </span>                  
                                                        </div>                                          
                                                     </div>  
                                                  </div>     
                                                 </div>
                                                </div>
                                <div class="col-sm-12" > 
                                            <div class="row">

                                <div class="col-sm-1" style="width:150px">
                                    <div class="form-group">
                                         <label for="ddlBillService" style="text-align:left">Bill Service:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left" style="width:300px">
                                    <div class="form-group">                                     
                                              <asp:DropDownList ID="ddlBillService" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlBillService_SelectedIndexChanged"  Width="250px" Class="form-control"
                                                 TabIndex="2"></asp:DropDownList>
                                   </div>
                                </div>
                                                </div>
                                    </div>
                                <div class="col-sm-12" > 
                                            <div class="row">
                               <div class="col-sm-1" style="width:150px">
                                    <div class="form-group">
                                         <label for="ddlBillSubService" style="text-align:left">Bill Sub Service:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left" style="width:300px">
                                    <div class="form-group"> 
                                         <asp:DropDownList ID="ddlBillSubService" runat="server" AutoPostBack="True"
                                                 Class="form-control" TabIndex="2"  Width="250px"></asp:DropDownList>
                                   </div>
                                </div>
                                                </div>
                                    </div>
                                                

                              <div class="col-sm-12" > 
                                            <div class="row">                  
                               <div class="col-sm-1" style="width:150px">
                                    <div class="form-group">
                                         <label for="txtQty" style="text-align:left">Qty:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left" style="width:300px">
                                    <div class="form-group"> 
                                         <asp:TextBox ID="txtQty" runat="server"  Width="250px" AutoPostBack="True" 
                                                       Class="form-control" Placeholder="Enter Quantity(*)" />
                                   </div>
                                </div>  
                                                </div>
                                  </div> 
                                                  
                    <div class="col-sm-12" > 
                                            <div class="row">                  
                               <div class="col-sm-1" style="width:150px">
                                    <div class="form-group">
                                         <label for="txtAmount" style="text-align:left">Amount:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left" style="width:300px">
                                    <div class="form-group"> 
                                         <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="True"  Width="250px"
                                                       Class="form-control" Placeholder="Enter Amount(*)" />
                                   </div>
                                </div>   
                                <div class="col-sm-4 text-left">
                                    <div class="form-group">
                                        
                                        <asp:Button ID="btnsave" runat="server" class="btn btn-primary"  TabIndex="3" Text="Add" OnClientClick="return Validate();" OnClick="btnsave_Click"  />
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-warning"  TabIndex="2" Text="Reset" OnClick="btnReset_Click" />
                                        <asp:Button ID="btnBack" runat="server" class="btn btn-info"  TabIndex="2" Text="Close" OnClick="btnBack_Click" />
                                       
                                       
                                    </div>
                                </div>
                                                </div>
               </div>
                                 <div class="col-sm-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvBillService" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="592px" OnPageIndexChanging="gvBillService_PageIndexChanging" 
                    DataKeyNames="HPackInfoId" AllowPaging="True" PageSize="15" OnRowDeleting="gvBillService_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                
                                <asp:BoundField DataField="ServiceName" HeaderText="Bill Service" 
                                    Visible="False" />
                                <asp:BoundField DataField="ServiceDetails" HeaderText="Bill Sub Service" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Qty" HeaderText="Qty" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
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
                    </div>
                  
                </section>
        </ContentTemplate>
        </asp:UpdatePanel>


</asp:Content>

