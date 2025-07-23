<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="OTNotesReport.aspx.cs" Inherits="OTNotesReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1> OT Notes</h1>
<ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OT Notes</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <%--<div class="row">--%>
                            
                            
                                  
                                    <div class="col-lg-12" >
                                        
                               
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="OTId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="IpdNo" HeaderText="IpdNo" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OperationName" HeaderText="Operation Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="CreatedOn" HeaderText="OT Reg Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="DiseaseName" HeaderText="Disease Name" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="SurganName" HeaderText="Surgan Name" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <%--<asp:BoundField DataField="SurganName" HeaderText="Type" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>--%>
                                                       
                                                        <%--<asp:ButtonField CommandName="Notes" Text="Notes" ControlStyle-CssClass="btn btn-primary"  ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>--%>
                                                         <asp:TemplateField   >
                                 <ItemTemplate>
                                     <asp:Button ID="btnNotes" runat="server" Text="Notes"  OnClientClick="target='_blank';" OnClick="btnNotes_Click" />
                                 </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                             </asp:TemplateField>
                                                        
                                                   <asp:TemplateField HeaderStyle-Width="05px">
                                                         <ItemTemplate>
                                                          <asp:HiddenField ID="HdnGeneralOT" runat="server" Value='<%#Eval("GeneralOT") %>' /> 
                                                               </ItemTemplate>

<HeaderStyle Width="5px"></HeaderStyle>
                                                       </asp:TemplateField>
                                                         </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
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
                            
                              <%--  </div>--%>
                            </div>

                      
                    </div>
             
            </section>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        function OpenReport() {
            window.open("Reports.aspx");
        }
               </script>
    
</asp:Content>
