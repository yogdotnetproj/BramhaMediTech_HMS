<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BedMaster.aspx.cs" Inherits="BedMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {             
             
             if (document.getElementById("MainContent_ddlRoomAddress").value == "0") {
                 alert("Please Select Room Location");
                 return false;
             }
             if (document.getElementById("MainContent_ddlRoomName").value == "0") {
                 alert("Please Select Room Name");
                 return false;
             }
             if (document.getElementById("MainContent_txtBedName").value == "") {
                 alert("Please Enter Bed Name ");
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
                    <h1>Bed Master</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Bed Master</li>
                    </ol>
            </section>
          <section class="content">
                            <!--<div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" CssClass="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                           </div>
                                </div>-->
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-primary pull-left" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="ddlRoomAddress">Room Location:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            
                                            <asp:DropDownList ID="ddlRoomAddress" runat="server" CssClass="form-control form-select"
                                                    OnSelectedIndexChanged="ddlRoomAddress_SelectedIndexChanged" 
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                          </div>
                                        <div class="col-sm-12 mt-3">
                                            <div class="row">

                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="ddlRoomName">Room Name:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">                                            
                                            <div class="form-group"> 
                                               
                                                 <asp:DropDownList ID="ddlRoomName" runat="server" CssClass="form-control form-select"
                                                    OnSelectedIndexChanged="ddlRoomName_SelectedIndexChanged" 
                                                    AutoPostBack="True" >
                                                </asp:DropDownList>
                                               
                                            </div>
                                          </div>
                                                </div>
                                            </div>
                                        <div class="col-sm-12 mt-3">
                                            <div class="row">

                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="lblTotalBed">Total Bed:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            
                                            <div class="form-group"> 
                                                <asp:Label ID="lblTotalBed" runat="server"></asp:Label>
                                                 
                  
                                            </div>
                                          </div>
                                          </div>
                                            </div>

                                        <div class="col-sm-12 mt-3">
                                            <div class="row">

                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="lblRoomType">Room Type:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            
                                            <div class="form-group"> 
                                                <asp:Label ID="lblRoomType" runat="server"></asp:Label>                                                
                  
                                            </div>
                                          </div>
                                          </div>
                                            </div>
                                         <div class="col-sm-12 text-center mt-3">
                                             <asp:Button ID="btnsave" runat="server"  class="btn btn-primary" OnClientClick="return Validate();" 
                                              Text="Save" onclick="btnSave_Click"/>                                    
                                     
                                             <asp:Button ID="btnReset" runat="server" class="btn btn-primary"   CausesValidation="False" 
                                             onclick="btnReset_Click" Text="Reset"  />
                                                
                                             
                                        </div>
                                               
                                         </div>
                                   </div>
                           <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                                                                                     
                       
                              <asp:GridView ID="gvBedMaster" runat="server" AutoGenerateColumns="False" DataKeyNames="BedId"
                            OnRowDeleting="gvBedMaster_RowDeleting" 
                            OnRowEditing="gvBedMaster_RowEditing" 
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"  
                            CellPadding="3" AllowPaging="True" PageSize="5"                    
                            onpageindexchanging="gvBedMaster_PageIndexChanging" TabIndex="6" 
                            ShowHeaderWhenEmpty="True" OnRowCancelingEdit="gvBedMaster_RowCancelingEdit" OnRowUpdating="gvBedMaster_RowUpdating">
                                  <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                               <asp:TemplateField>
<EditItemTemplate>
                     <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                   
</EditItemTemplate>
<ItemTemplate>
<asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/Images0/edit.gif" ToolTip="Edit" />
    </ItemTemplate>
                                   </asp:TemplateField>
                               
                                 <asp:TemplateField HeaderText="BedName">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_BedName" runat="server" Text='<%#Eval("BedName") %>'></asp:Label>  
                    </ItemTemplate> 
                        <EditItemTemplate>  
                        <asp:TextBox ID="txt_BedName" runat="server" Text='<%#Eval("BedName") %>'></asp:TextBox>  
                    </EditItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="RoomName">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_RoomName" runat="server" Text='<%#Eval("RoomName") %>'></asp:Label>  
                    </ItemTemplate>  

                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Room Location">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_RoomAddress" runat="server" Text='<%#Eval("RoomAddress") %>'></asp:Label>  
                    </ItemTemplate>  
                    
                </asp:TemplateField>  

                                
                                
                                 
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CommandName="Delete" CausesValidation="false"  />
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

                        </section>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

