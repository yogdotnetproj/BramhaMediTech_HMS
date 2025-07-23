<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="AddUsertype.aspx.cs" Inherits="AddUsertype" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Add User Type</h1>
                   
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                           
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>

                        <div class="box-body">
                            <div class="row mb-3">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                      
                                        
                                       
                <asp:TextBox ID="txtuserType" runat="server" placeholder="Enter User Type(*)" CssClass="form-control" TabIndex="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuserType"
                    Display="Dynamic" ErrorMessage="This Field is required." ForeColor="Red"  SetFocusOnError="True"
                    ValidationGroup="form" Width="152px" Font-Bold="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-3 text-center">
                                    <div class="form-group pt25">
                                        
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" TabIndex="3" Text="Save" ValidationGroup="form" />
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" TabIndex="2" Text="Reset" />
                                        
                                       
                                    </div>
                                </div>

                                 <div class="col-sm-3 text-center">
                                    <div class="form-group pt25">
                                     <asp:Label ID="Label2" runat="server" Font-Bold="true"  ForeColor="Red" Style="position: relative" Text="Label" ></asp:Label>
                                    </div>
                                    </div>

                            </div>
                        </div>
                    <div class="box-body">

                     <div class="table-responsive" style="width:100%">
                <asp:GridView ID="GV_UserType" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" DataKeyNames="ROLLID"
                    Width="592px" OnPageIndexChanging="GV_UserType_PageIndexChanging" OnRowEditing="GV_UserType_RowEditing"
                    AllowPaging="True" PageSize="15" OnRowDeleting="GV_UserType_RowDeleting"   HeaderStyle-ForeColor="Black"
  AlternatingRowStyle-BackColor="White"   >
                      <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                    <Columns>
                        <asp:BoundField DataField="ROLENAME" HeaderText="User Type" />
                        <asp:CommandField HeaderText="Edit " ShowEditButton="True" EditImageUrl="~/Images0/edit.gif"
                            ButtonType="Image" />
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


