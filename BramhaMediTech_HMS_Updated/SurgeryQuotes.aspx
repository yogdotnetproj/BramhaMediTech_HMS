<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="SurgeryQuotes.aspx.cs" Inherits="SurgeryQuotes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Surgery Quotes </h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Surgery Quotes</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <%--<div class="row">--%>
                              <div class="row">
                              <div class="col-sm-3">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off" runat="server" CssClass="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                  <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                        </div>
                                    </div>                                    
                              <div class="col-sm-3">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off"  runat="server" CssClass="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                               <div class="col-sm-4" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                          </div>
                           
                            
                                    <div class="row mt-3">

                                        <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtsurgan" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Surgan Name"
                                                AutoPostBack="True" ontextchanged="txtsurgan_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtsurgan"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                      
                                        <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtoperation" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Operation Name"
                                                AutoPostBack="True" ontextchanged="txtoperation_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender4"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                         <div class="col-sm-2">
                                        <div class="form-group">
                                            
                                            
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" class="btn btn-primary btnSearch" />
                                        
                                            </div>
                                    </div>
                               
                                        
                                        </div>
                                 
                                  
                                    <div class="col-lg-12 mt-3" >
                                        
                               
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="SurgEstimationId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="CreatedOn" HeaderText="Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OperationName" HeaderText="Operation Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                         <asp:BoundField DataField="SurgeonName" HeaderText="Surgan Name" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        
                                                         <asp:TemplateField   >
                                 <ItemTemplate>
                                     <asp:Button ID="btnNotes" runat="server" Text="Select"  OnClientClick="target='_blank';"  OnClick="btnNotes_Click" />
                                 </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                             </asp:TemplateField>
                                                          <asp:TemplateField   >
                                 <ItemTemplate>
                                     <asp:Button ID="btnQuotation" runat="server" Text="Quotation"   OnClick="btnQuotation_Click" />
                                 </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
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


