<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPatientInfo.ascx.cs"
    Inherits="UserControls_ucPatientInfo" %>
<style type="text/css">
    .style1
    {
        height: 24px;
    }
</style>
<table width="90%">
    <tr>
        <td>
        </td>
        <td>
            Name
        </td>
        <td>
            :
        </td>
        <td>
            <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
        </td>
        <td>
        </td>
        <td>
            PRN No
        </td>
        <td>
            :
        </td>
        <td>
            <asp:Label ID="lblPrnNo" runat="server" Text=""></asp:Label>
        </td>
        <td>
        </td>
        <td>
            Entry Date</td>
        <td>
            :</td>
        <td>
            <asp:Label ID="lblEntryDate" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td rowspan="2">
            Address
        </td>
        <td rowspan="2">
            :
        </td>
        <td rowspan="2">
            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
        </td>
        <td class="style1">
        </td>
        <td>
            Category
        </td>
        <td>
            :
        </td>
        <td>
            <asp:Label ID="lblPatientCategory" runat="server" Text=""></asp:Label>
        </td>
        <td>
        </td>
        <td>
            Blood Group
        </td>
        <td>
            :</td>
        <td>
            <asp:Label ID="lblBloodGroup" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            Sub Category
        </td>
        <td>
            :
        </td>
        <td>
            <asp:Label ID="lblPatientSubCategory" runat="server" Text=""></asp:Label>
        </td>
        <td>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
