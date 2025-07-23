<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="RoomMaster.aspx.cs" Inherits="RoomMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtRoomName").value == "") {
                alert("Please Enter Room Name");
                return false;
            }
            if (document.getElementById("MainContent_ddlRoomTypeName").value == "0") {
                alert("Please Select Room Type");
                return false;
            }
            if (document.getElementById("MainContent_txtTotalBed").value == "") {
                alert("Please Enter Total Bed");
                return false;
            }
            
            if (document.getElementById("MainContent_txtRoomAddress").value == "") {
                alert("Please Enter Room Address");
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
                    <h1>Room Master</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Room Master</li>
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
                                   <div class="table-responsive" style="width:100%">                                                                                     
                       
                              <asp:GridView ID="gvRoomMaster" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomId"
                            OnRowDeleting="gvRoomMaster_RowDeleting" 
                            OnRowEditing="gvRoomMaster_RowEditing" 
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"  
                            CellPadding="3" AllowPaging="True" 
                            onselectedindexchanging="gvRoomMaster_SelectedIndexChanging" PageSize="50" 
                            onpageindexchanging="gvRoomMaster_PageIndexChanging" TabIndex="6" 
                            ShowHeaderWhenEmpty="True">
                                  <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                               
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="RoomId" HeaderText="Room Id" Visible="False" />                          
                                    
                                <asp:BoundField DataField="RType" HeaderText="Room Type" />
                                   <asp:BoundField DataField="RoomName" HeaderText="Room Name" /> 
                                <asp:BoundField DataField="TotalBeds" HeaderText="Total Bed" /> 
                                   <asp:BoundField DataField="RoomAddress" HeaderText="Room Address" />
                                 
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtRoomName">Room Name:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            
                                            <div class="form-group"> 
                                                 <asp:TextBox ID="txtRoomName" runat="server"  AutoPostBack="True"
                                                  OnTextChanged="txtRoomName_TextChanged" placeholder="Enter Room Name(*)" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                                     
                 
                                            </div>
                                          </div>
                                        <div class="col-lg-12 mt-3">
                                            <div class="row">

                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="ddlRoomTypeName">Room Type:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">                                            
                                            <div class="form-group"> 
                                               
                                                 <asp:DropDownList ID="ddlRoomTypeName" runat="server" CssClass="form-control form-select"
                                                    OnSelectedIndexChanged="ddlRoomTypeName_SelectedIndexChanged" 
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                               
                                            </div>
                                          </div>
                                                </div>
                                            </div>
                                         <div class="col-lg-12 mt-3">
                                            <div class="row">

                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtTotalBed">Total Bed:<span style="color:red">*</span></label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtTotalBed" runat="server" 
                                                 TabIndex="3" placeholder="Enter Total Bed (*)" CssClass="form-control"></asp:TextBox>
                                                 
                  
                                            </div>
                                          </div>
                                                </div>
                                             </div>
                                        <div class="col-lg-12 mt-3">
                                            <div class="row">

                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtRoomAddress">Room Location:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtRoomAddress" runat="server" TextMode="MultiLine" 
                                                 TabIndex="3" placeholder="Enter Room Location(*)" CssClass="form-control"></asp:TextBox>
                                                 
                  
                                            </div>
                                          </div>
                           
                                         <div class="col-sm-3">
                                    
                                             <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary" OnClientClick="return Validate();"
                                              Text="Save" onclick="btnSave_Click"/>                                    
                                     
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

