<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="AntenatalServiceMst.aspx.cs" Inherits="AntenatalServiceMst" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtAnteServ").value == "") {
                 alert("Please Enter Service Name");
                 return false;
             }
         }
        </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
                    <asp:PostBackTrigger ControlID="btnPrint" />
                </Triggers>--%>
              <ContentTemplate>
    <section class="content-header d-flex">
                    <h1>Antenatal  Master</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Antenatal Master</li>
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

                                            <div class="row">
                                   <div class="table-responsive" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvAnteServ" runat="server" AutoGenerateColumns="False" DataKeyNames="GyParticularId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10"
                            OnRowDeleting="gvAnteServ_RowDeleting" OnRowEditing="gvAnteServ_RowEditing"
                             OnPageIndexChanging="gvAnteServ_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                            <Columns>
                                
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="GyParticularId" HeaderText="GyParticularId" Visible="False" />
                                <asp:BoundField DataField="Particular" HeaderText="Particular Name"/>   
                                <asp:BoundField DataField="OrderNo" HeaderText="Order No"/>                                               
                                   
                                
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CommandName="Delete"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                                                                
                                        <div class="col-sm-1" style="width:180px">
                                                    <div class="form-group">
                                                         <label for="txtAnteServ" style="text-align:left">Antenatal Particular:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtAnteServ" runat="server" placeholder="Enter Paticular Name(*)" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="row">
                                                 <div class="col-sm-1" style="width:180px">
                                                    <div class="form-group">
                                                         <label for="txtOrderNo" style="text-align:left">Order No:</label>                                                                                
                                                    </div>
                                                 </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtOrderNo" runat="server"  Enabled="false" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>

                                                           
                                        
                                                
                                                <div class="col-sm-4 text-left">                                    
                                                  <asp:Button ID="btnsave" runat="server"  class="btn btn-primary"  
                                                  Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" class="btn btn-primary"   CausesValidation="False" 
                                                    onclick="btnReset_Click" Text="Reset" width="80px" />

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

