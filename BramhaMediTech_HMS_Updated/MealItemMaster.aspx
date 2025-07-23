<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="MealItemMaster.aspx.cs" Inherits="MealItemMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtItemUnit").value == "") {
                 alert("Please Enter Item Unit");
                 return false;
             }
             if (document.getElementById("MainContent_txtItemUnitCode").value == "") {
                 alert("Please Enter Item UnitCode");
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
                    <h1>Meal Items</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Meal Items</li>
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
                  
                            <asp:GridView ID="gvMealItem" runat="server" AutoGenerateColumns="False" DataKeyNames="FoodItemId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10"
                            OnRowDeleting="gvMealItem_RowDeleting" OnRowEditing="gvMealItem_RowEditing"
                             OnPageIndexChanging="gvMealItem_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                            <Columns>
                                
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="FoodItemId" HeaderText="Item Unit Id" Visible="False" />
                                <asp:BoundField DataField="FoodItemName" HeaderText="Item Name"/>   
                                <asp:BoundField DataField="FoodItemQty" HeaderText="Item Qty"/>
                                <asp:BoundField DataField="Calories" HeaderText="Calories"/> 
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
                                                                                
                                        <div class="col-lg-1" style="width:200px">
                                                    <div class="form-group">
                                                         <label for="txtItem" style="text-align:left">Item Name:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtItem" runat="server" placeholder="Enter Item Name(*)" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="row">
                                                 <div class="col-lg-1" style="width:200px">
                                                    <div class="form-group">
                                                         <label for="txtItemQty" style="text-align:left">Quantity:</label>                                                                                
                                                    </div>
                                                 </div>
                                                 <div class="col-lg-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtItemQty" runat="server"  Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                                <div class="col-lg-3">
                                                <div class="form-group">                                     
                                                     <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True"  Class="form-control"
                                                     TabIndex="2"></asp:DropDownList>
                                                </div>
                                                    </div>
                                                </div>
                                            </div>
                                                

                                             <div class="col-lg-12">
                                            <div class="row">              
                                                <div class="col-lg-1" style="width:200px">
                                                    <div class="form-group">
                                                         <label for="txtItemCalories" style="text-align:left">Calories:</label>                                                                                
                                                    </div>
                                                 </div>
                                                 <div class="col-lg-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtItemCalories" runat="server"  Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                                
                                                <div class="col-lg-4 text-left">                                    
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

