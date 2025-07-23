<%@ Page Title="" Language="C#" MasterPageFile="Hospital.master"
    AutoEventWireup="true" CodeFile="ReasonForDiscount.aspx.cs" Inherits="ReasonForDiscount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Maincontent" runat="Server">
   
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtDiscReason").value == "") {

                alert("Enter Discount Reason");
                return false;
            }

        }


       </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Reason For Discount</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Reason For Discount</li>
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
                         
                                 <asp:GridView ID="gvDiscount" runat="server" AutoGenerateColumns="False" DataKeyNames="DiscTypeId"
                                OnRowDeleting="gvDiscount_RowDeleting" OnRowEditing="gvDiscount_RowEditing"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"                              
                                CellPadding="3" AllowPaging="True" OnPageIndexChanging="gvDiscount_PageIndexChanging"
                                PageSize="25" ShowHeaderWhenEmpty="True">
                                      <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                    <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="DiscTypeId" HeaderText="Disc Type Id" Visible="False" />
                                <asp:BoundField DataField="DiscType" HeaderText="Reason For Discount" ItemStyle-HorizontalAlign="Left"
                                    ItemStyle-Width="60px" /> 
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
                                                     <div class="col-sm-3">
                                                          <div class="form-group">
                                                                 <label for="txtDiscReason">Reason For Discount:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3">
                                                        <div class="form-group">
                                                                                                    
                                                            <asp:TextBox ID="txtDiscReason" runat="server" TextMode="MultiLine" AutoPostBack="True" CssClass="form-control" Placeholder="Enter Discount Reason(*)" >
                                                             </asp:TextBox>                                               
          
                                                         </div>
                                                    </div>
                                                </div>
                                                
                                                      <div class="row mb-3">     
                                          <div class="col-sm-3">
                                                          <div class="form-group">
                                                              </div>
                                              </div>
                                                     <div class="col-sm-3 text-Center">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-primary" OnClientClick="return Validate();"/>
                                              <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" class="btn btn-primary" CausesValidation="False" />
                                                         </div>
                                             
                                        </div>
                                              

                                      </div>                                      
                          </div>                               
                               
                            

                 

                        </section>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
