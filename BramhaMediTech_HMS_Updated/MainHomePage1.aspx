<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalTemp.master" AutoEventWireup="true" CodeFile="MainHomePage1.aspx.cs" Inherits="MainHomePage1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table  width="100%" class="dashboard" cellpadding="2" cellspacing="5">
       
        <tr>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="btnHMS" ImageUrl="~/Images0/hospital.png" ToolTip="HMS" runat="server" OnClick="btnHMS_Click" CssClass="box-blue" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="btnpatho" ImageUrl="~/Images0/Pathology.png" ToolTip="Pathology" runat="server" OnClick="btnpatho_Click" CssClass="box-red" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="btnRadio" ImageUrl="~/Images0/Radiology.png" ToolTip="Radiology" runat="server" OnClick="btnRadio_Click" CssClass="box-dark"/>
            </td>
           
             <td width="120" height="120" align="center">
                <asp:ImageButton ID="btnInven" ImageUrl="~/Images0/inventry.png" ToolTip="Medical Lab" runat="server" OnClick="btnInven_Click" CssClass="box-dark" />
            </td>
        </tr>
        <tr>
            
            <td width="120"  align="center">
              <b>  HMS</b>
                </td>
             <td width="120"  align="center">
                   <b>  Pathology</b>
                </td>
             <td width="120"  align="center">
                   <b>  Radiology</b>
                </td>
             <td width="120"  align="center">
                   <b>  Medical Lab</b>
                </td>
        </tr>
         <tr >
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="btnPharmacy" ImageUrl="~/Images0/Pharma.png" ToolTip="Pharmacy" runat="server" OnClick="btnPharmacy_Click" CssClass="box-darkblue" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="btnQuality" ImageUrl="~/Images0/QC.png" ToolTip="Quality" runat="server" OnClick="btnQuality_Click" CssClass="box-blue" />
            </td>
            <td width="120" height="120" align="center">
                 <asp:ImageButton ID="btnusermgt" ImageUrl="~/Images0/User.png" ToolTip="User Management" runat="server" OnClick="btnusermgt_Click" CssClass="box-yellow"  />
             </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/QC.png" ToolTip="Quality" runat="server" OnClick="btnQuality_Click" CssClass="box-green" />
              </td>
        </tr>
            <tr>
            
            <td width="120"  align="center">
              <b>  Pharmacy</b>
                </td>
             <td width="120"  align="center">
                   <b>  Inventory</b>
                </td>
             <td width="120"  align="center">
                   <b>  User Management</b>
                </td>
             <td width="120" align="center">
                   <b>  </b>
                </td>
        </tr>
        <tr runat="server" visible="false">
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/hospital.png" ToolTip="HMS" runat="server" OnClick="btnHMS_Click" CssClass="box-red" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/Pathology.png" ToolTip="Pathology" runat="server" OnClick="btnpatho_Click" CssClass="box-yellow" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton1" ImageUrl="~/Images0/Pharma.png" ToolTip="Pharmacy" runat="server" OnClick="btnPharmacy_Click" CssClass="box-darkblue" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/Radiology.png" ToolTip="Radiology" runat="server" OnClick="btnRadio_Click" CssClass="box-dark"/>
            </td>
            
        </tr>
        <tr runat="server" visible="false">
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/hospital.png" ToolTip="HMS" runat="server" OnClick="btnHMS_Click" CssClass="box-blue" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/Pathology.png" ToolTip="Pathology" runat="server" OnClick="btnpatho_Click" CssClass="box-red" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/Radiology.png" ToolTip="Radiology" runat="server" OnClick="btnRadio_Click" CssClass="box-dark"/>
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ImageUrl="~/Images0/Pharma.png" ToolTip="Pharmacy" runat="server" OnClick="btnPharmacy_Click" CssClass="box-darkblue" />
            </td>
        </tr>
         <tr runat="server" visible="false">
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton2" ImageUrl="~/Images0/hospital.png" ToolTip="HMS" runat="server" OnClick="btnHMS_Click" CssClass="box-red" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton3" ImageUrl="~/Images0/Pathology.png" ToolTip="Pathology" runat="server" OnClick="btnpatho_Click" CssClass="box-yellow" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton4" ImageUrl="~/Images0/Pharma.png" ToolTip="Pharmacy" runat="server" OnClick="btnPharmacy_Click" CssClass="box-darkblue" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton5" ImageUrl="~/Images0/Radiology.png" ToolTip="Radiology" runat="server" OnClick="btnRadio_Click" CssClass="box-dark"/>
            </td>
            
        </tr>
        <tr runat="server" visible="false">
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton6" ImageUrl="~/Images0/hospital.png" ToolTip="HMS" runat="server" OnClick="btnHMS_Click" CssClass="box-blue" />
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton7" ImageUrl="~/Images0/Pathology.png" ToolTip="Pathology" runat="server" OnClick="btnpatho_Click" CssClass="box-red" />
            </td>
            <td width="120" height="120" align="center">

                <asp:ImageButton ID="ImageButton8" ImageUrl="~/Images0/Radiology.png" ToolTip="Radiology" runat="server" OnClick="btnRadio_Click" CssClass="box-dark"/>
            </td>
            <td width="120" height="120" align="center">
                <asp:ImageButton ID="ImageButton9" ImageUrl="~/Images0/Pharma.png" ToolTip="Pharmacy" runat="server" OnClick="btnPharmacy_Click" CssClass="box-darkblue" />
            </td>
        </tr>
    </table>
</asp:Content>

