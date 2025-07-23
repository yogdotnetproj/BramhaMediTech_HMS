<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="MealTimingsMst.aspx.cs" Inherits="MealTimingsMst" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtMealTime").value == "") {
                alert("Please Enter Meal Time");
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
                    <h1>Meal Timings</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Meal Timings</li>
                    </ol>
                </section>

    
      <section class="content">
                            <div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                              
                                            <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-primary pull-right" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
                                </div>
                                <div class="box-body">

                                            <div class="row">
                                   <div class="table-responsive" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvMealTime" runat="server" AutoGenerateColumns="False" DataKeyNames="MealTimeId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10"
                            OnRowDeleting="gvMealTime_RowDeleting" OnRowEditing="gvMealTime_RowEditing"
                             OnPageIndexChanging="gvMealTime_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                            <Columns>
                                
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="MealTimeId" HeaderText="MealTimeId" Visible="False" />
                                <asp:BoundField DataField="MealTime" HeaderText="Meal Time"/>   
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                                                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtMealTime">Meal Time:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtMealTime" runat="server" placeholder="Enter Meal Time(*)" CssClass="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-12 mt-3">
                                            <div class="row">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtOrderNo">Order No:</label>                                                                                
                                                    </div>
                                                 </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtOrderNo" runat="server"  CssClass="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>

                                                           
                                        
                                                
                                                <div class="col-sm-4 text-left">                                    
                                                  <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  
                                                  Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"   CausesValidation="False" 
                                                    onclick="btnReset_Click" Text="Reset" />

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

