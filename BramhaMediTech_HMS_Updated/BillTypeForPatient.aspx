<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillTypeForPatient.aspx.cs" Inherits="BillTypeForPatient" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <script type = "text/javascript">
          function Validate() {

              if (document.getElementById("MainContent_txtBillType").value == "") {

                  alert("Enter Bill Type");
                  return false;
              }

          }

          
       </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Patient Bill Type</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      <li class="breadcrumb-item active">Patient Bill Type</li>
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
                         
                                 <asp:GridView ID="gvBillType" runat="server" AutoGenerateColumns="False" DataKeyNames="BillTypeId"
                                OnRowDeleting="gvBillType_RowDeleting" OnRowEditing="gvBillType_RowEditing"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"                              
                                CellPadding="3" AllowPaging="True" OnPageIndexChanging="gvBillType_PageIndexChanging"
                                PageSize="25" ShowHeaderWhenEmpty="True">

                                    <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="BillTypeId" HeaderText="Bill Type Id" Visible="False" />
                                <asp:BoundField DataField="BillType" HeaderText="Bill Type" ItemStyle-HorizontalAlign="Left"
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                
                                </div>
                                 <div class="box-body">
                                       
                                              <div class="row">                                                                               
                                                     <div class="col-sm-2">
                                                          <div class="form-group">
                                                                 <label for="txtBillGroup">Bill Type:</label>                                                                                
                                                          </div>
                                                     </div>
                                                     <div class="col-sm-3">
                                                        <div class="form-group">
                                                                                                    
                                                            <asp:TextBox ID="txtBillType" runat="server" AutoPostBack="True" CssClass="form-control" Placeholder="Enter Bill Group(*)" >
                                                             </asp:TextBox>                                               
          
                                                         </div>
                                                    </div>
                                                
                                                      <div class="row">
                                          
                                                     <div class="col-sm-6 text-Center">
                                    
                                              <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" OnClientClick="return Validate();"
                                              />
                                              <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-primary"
                                              CausesValidation="False" />

                                                     </div>
                                             
                                                  </div>
                                              </div>

                                      </div>                                      
                          </div>                               
                               
                            

                 

                        </section>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

