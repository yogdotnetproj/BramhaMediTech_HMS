<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="InitialMst.aspx.cs" Inherits="InitialMst" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>--%>
        <ContentTemplate>
             <section class="content-header d-flex">
                    <h1>Initial</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                         <li class="breadcrumb-item active">Initial</li>
                    </ol>

              </section>
             <section class="content">
                            <div class="box" runat="server" id="List" >

                               <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                   <span class="red pull-right">Fields marked with * are compulsory</span> 
                               </div>                                
                               <div class="box-body">
                                    <div class="row mb-3">
                                      <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtTitleName">Initial:</label>                                                                                
                                        </div>
                                    </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                     
                                                
                                            <asp:TextBox ID="txtTitleName" runat="server" placeholder="Enter Title(*)" CssClass="form-control"  AutoPostBack="True"
                                             OnTextChanged="txtTitleName_TextChanged" TabIndex="1"></asp:TextBox>
                                               
                   
                                                 </div>
                                        </div>
                                        </div>

                                   <div class="row mb-3">
                                      
                                                 <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="ddlGender">Gender:</label>                                                                                
                                        </div>
                                    </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                
                                               
                                                <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" CssClass="form-control form-select" 
                                                  onselectedindexchanged="ddlGender_SelectedIndexChanged"> </asp:DropDownList>
                        
                                            </div>
                                        </div>
                                    </div>

                                   <div class="row mb-3">
                                                <div class="col-sm-2">
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="IsDefault" Text="Default" runat="server" CssClass="form-check p-0"></asp:CheckBox>
                                           
                                            </div>
                                                
                                                 <div class="col-sm-4 text-center">
                                    
                                                     <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  
                                                     Text="Save" onclick="btnSave_Click"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"   CausesValidation="False" 
                                                      onclick="btnReset_Click" Text="Reset" />
                                           
                                                </div>
                                    </div>

                                   <div class="row mb-3">
                                         
                                           
                                                <div class="table-responsive" style="width:100%">             

                            <asp:GridView ID="gvTitle" runat="server" AllowPaging="True" class="table table-responsive table-sm table-bordered" Width="100%"  
                            HeaderStyle-ForeColor="Black"  AutoGenerateColumns="False" 
                            AlternatingRowStyle-BackColor="White" DataKeyNames="TitleId" 
                            EmptyDataText="No Records to Display" 
                            OnPageIndexChanging="gvTitle_PageIndexChanging" 
                            OnRowDeleting="gvTitle_RowDeleting" OnRowEditing="gvTitle_RowEditing" 
                            PageSize="5" ShowHeaderWhenEmpty="True" TabIndex="4">
                            <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="TitleId" HeaderText="Title Id" Visible="False" />
                                <asp:BoundField DataField="Title" HeaderText="Title" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="GenderName" HeaderText="Gender" />
                                <asp:BoundField DataField="IsDefault" HeaderText="IsDefault" />
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

            </section>
            </ContentTemplate>
        </asp:UpdatePanel>


</asp:Content>

