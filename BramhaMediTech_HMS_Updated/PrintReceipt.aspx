<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PrintReceipt.aspx.cs" Inherits="PrintReceipt" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:Button ID="btnCasePaper" runat="server" Text="Case Paper"   UseSubmitBehavior="false" onclientclick="target = '_blank';" 
                                        TabIndex="15" CssClass="btn btn-primary" OnClick="btnCasePaper_Click"  />
</asp:Content>

