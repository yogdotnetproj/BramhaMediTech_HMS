<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Hospital.master" CodeFile="Adduser.aspx.cs" Inherits="Adduser" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                            <!-- Content Header (Page header) -->
                <section class="content-header d-flex">
                    <h1>Add User</h1>
                   
                </section>
                <!-- Main content -->
                <section class="content">
                    <div class="box pt-3" runat="server" id="List" >
                      
                      <!--  <div class="box-header with-border">
                            <asp:Label ID="lblMsg" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                         
                        </div>-->
                        <div id="Div1" class="box-body" runat="server" >
                            <div class="row mb-3">   
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        
                                       
                                         <asp:TextBox id="txtusername" runat="server" CssClass="form-control"  placeholder="User Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        
                                          <asp:Button ID="btnList" runat="server" Text="Search" CssClass="btn btn-primary" 
                                            onclick="btnList_Click"   />
                                          <asp:Button ID="btnAddnew" runat="server" CssClass="btn btn-primary" 
                                            Text="Add New" onclick="btnAddnew_Click"  />
                                          
                                    </div>
                                </div>
                             </div>
                        </div>

                        <div class="box-body">
                            <div class="table-responsive" style="width:100%">
<asp:GridView  id="userlist" runat="server" 
        Width="100%" OnSelectedIndexChanged="ItemList_SelectedIndexChanged" class="table table-responsive table-sm table-bordered" DataKeyNames="CUId" Font-Underline="False" OnRowDataBound="userlist_RowDataBound" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" OnPageIndexChanging="userlist_PageIndexChanging" OnRowDeleting="userlist_RowDeleting">
<PagerSettings Visible="true"></PagerSettings>
     <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
<Columns>
<asp:CommandField SelectImageUrl="~/Images0/edit.gif" SelectText="Edit" ButtonType="Image" ShowSelectButton="True" HeaderText="Edit">
<ItemStyle ForeColor="RoyalBlue"></ItemStyle>
</asp:CommandField>
<asp:BoundField DataField="USERNAME" SortExpression="USERNAME" HeaderText="User Name"></asp:BoundField>

<asp:BoundField DataField="dept" SortExpression="dept" HeaderText="Dept"></asp:BoundField>
<asp:BoundField DataField="UserType" SortExpression="UserType" HeaderText="User Type"></asp:BoundField>
<asp:TemplateField HeaderText="Lab Name">
<ItemTemplate>
<asp:Label ID="Labname" runat="server" Text="" />
                              
                        
</ItemTemplate>
</asp:TemplateField>
  <asp:TemplateField HeaderText="Delete">
      <ItemTemplate>
                           <%-- <ItemTemplate>
                                <asp:Button ID="btndelete" CommandName="Delete"   ImageUrl="~/Images0/delete.gif"  runat="server"  ForeColor="Blue" Text="Delete" />                            
                            </ItemTemplate> --%>
      
       <asp:ImageButton ID="btndelete" runat="server" CommandName="Delete" 
       ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" CausesValidation="false"
       ToolTip="Click here to Delete this record" />
      </ItemTemplate>                           
 </asp:TemplateField>

<asp:TemplateField>
<ItemTemplate>
 <asp:HiddenField ID="hdnuid" runat="server" Value='<%#Eval("CUid") %>' />                        
</ItemTemplate>
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
</asp:GridView>&nbsp;&nbsp;
                    </div>
                        </div>
                       
                    </div>
                 <!--   ======================== -->
                  

                </section>
                <!-- /.content -->



            </ContentTemplate>
            </asp:UpdatePanel>

    </asp:Content>