<%@ Page Title="History Master" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmHistoryMaster.aspx.cs" Inherits="frmHistoryMaster" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <h1>History Master</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<style type="text/css">   
              .cssPager span { text-underline-position:below; font-size:20px;} 
                .cssPager td
            {
                  padding-left: 4px;     
                  padding-right: 4px;    
              }   
        </style>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <section class="content-header d-flex">
                <h1>History Master</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">History Master</li>
                    </ol>
            </section>
            <section class="content">
                <div class="box" runat="server">
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                <asp:HiddenField ID="txtNewCatId" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-md-4">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label for="drpCategory">Category <span style="color: red">*</span></label>
                                            <asp:DropDownList ID="drpCategory" AutoPostBack="true"
                                                class="form-control" runat="server"
                                                OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drpCategory" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtNewType">New type <span style="color: red">*</span></label>
                                            <asp:TextBox class="form-control" ID="txtNewType" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNewType" ID="RequiredFieldValidator1" runat="server"
                                                ForeColor="Red" ErrorMessage="Please enter type name"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body table-responsive">
                                        <asp:GridView ID="gdvHistory" OnPreRender="gdvHistory_PreRender" CssClass="table table-bordered table-condensed" runat="server" Width="100%"
                                            AllowPaging="True" PageSize="10" AutoGenerateColumns="false" DataKeyNames="catId"
                                            GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                            OnPageIndexChanging="gdvHistory_PageIndexChanging"
                                            OnRowEditing="gdvHistory_RowEditing"
                                            OnRowCancelingEdit="gdvHistory_RowCancelingEdit"
                                            OnRowDeleting="gdvHistory_RowDeleting"
                                            OnRowDataBound="gdvHistory_RowDataBound">
                                            <Columns>
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-sm btn-primary" Text="Edit"
                                                            CommandName="Edit" ToolTip="Click here to Edit the record" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                </asp:TemplateField>--%>
                                                 <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                                <asp:TemplateField HeaderText="#" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="catId" Text='<%#Eval("catId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Category" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="historyMasterName" Text='<%#Eval("historyMasterName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Name" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="catName" Text='<%#Eval("catName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton CausesValidation="false" ID="Delete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="Delete"
                                                            OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                </asp:TemplateField>--%>
                                                 <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />
                                            </Columns>
                                            <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="DataGridFixedHeader" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="cssPager" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
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
                    </div>
                </div>
            </section>



            <%--<div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">--%>
            <%--<asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                            <asp:HiddenField ID="txtNewCatId" runat="server" />--%>
            <%--     </div>
                    </div>--%>

            <%-- <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-4">
                                <div class="card">
                                    <h3 class="card-header">History Type</h3>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label for="drpCategory">Category <span style="color: red">*</span></label>
                                            <asp:DropDownList ID="drpCategory" AutoPostBack="True"
                                                class="form-control" runat="server"
                                                OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drpCategory" ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtNewType">New type <span style="color: red">*</span></label>
                                            <asp:TextBox class="form-control" ID="txtNewType" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtNewType" ID="RequiredFieldValidator1" runat="server"
                                                ForeColor="Red" ErrorMessage="Please enter type name"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="card">
                                    <h3 class="card-header">Types of history</h3>
                                    <div class="card-body table-responsive">
                                        <asp:GridView ID="gdvHistory" OnPreRender="gdvHistory_PreRender" CssClass="table table-bordered table-condensed" runat="server" Width="100%"
                                            AllowPaging="True" PageSize="10" AutoGenerateColumns="false" DataKeyNames="catId"
                                            GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!"
                                            OnPageIndexChanging="gdvHistory_PageIndexChanging"
                                            OnRowEditing="gdvHistory_RowEditing"
                                            OnRowCancelingEdit="gdvHistory_RowCancelingEdit"
                                            OnRowDeleting="gdvHistory_RowDeleting"
                                            OnRowDataBound="gdvHistory_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Edit" runat="server" CssClass="btn btn-sm btn-primary" Text="Edit"
                                                            CommandName="Edit" ToolTip="Click here to Edit the record" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="#" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="catId" Text='<%#Eval("catId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Category" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="historyMasterName" Text='<%#Eval("historyMasterName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Name" Visible="true">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="catName" Text='<%#Eval("catName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton CausesValidation="false" ID="Delete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="Delete"
                                                            OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="Red" Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="DataGridFixedHeader" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="cssPager" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
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
                    </div>--%>
            <%--  </div>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

