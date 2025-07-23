<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmSample.aspx.cs" Inherits="frmSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:HiddenField ID="txtId" Value="0" runat="server" />
        Description :
        <asp:TextBox ID="txtDesc" runat="server" />
        IsComplete :
        <asp:DropDownList ID="drpComplete" runat="server">
            <asp:ListItem Selected="True" Text="--Select--" Value="-1"></asp:ListItem>
            <asp:ListItem Text="Complete" Value="1"></asp:ListItem>
            <asp:ListItem Text="InComplete" Value="2"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" ID="btnSave" Text="Save" />
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
    </div>
    <div>
        <asp:GridView ID="TaskGridView" runat="server"
            AutoGenerateEditButton="True"
            AllowPaging="true"
            OnRowEditing="TaskGridView_RowEditing"
            OnRowCancelingEdit="TaskGridView_RowCancelingEdit"
            OnRowUpdating="TaskGridView_RowUpdating"
            OnPageIndexChanging="TaskGridView_PageIndexChanging">
        </asp:GridView>
    </div>
</asp:Content>

