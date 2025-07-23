<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="SearchProcedurePatientList.aspx.cs" Inherits="SearchProcedurePatientList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
            <asp:PostBackTrigger ControlID="btnSummary" />
        </Triggers>
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Patient List Of Procedure</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Patient List Of Procedure</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                             

                                                <div class="col-lg-12 text-center">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="rdbgroup" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                                               <asp:ListItem Selected="True" Value="0" Text="0">All</asp:ListItem>
                                                             <asp:ListItem Value="1" >Consultation</asp:ListItem>
                                                              <asp:ListItem Value="26">HOSPITAL</asp:ListItem>
                                                             <asp:ListItem Value="21">EMERGENCY</asp:ListItem>
                                                             <asp:ListItem Value="12">EEG OPD</asp:ListItem>
                                                             <asp:ListItem Value="24">AMBULANCE</asp:ListItem>
                                                             <asp:ListItem Value="25">OPHTHAL</asp:ListItem>
                                                              <asp:ListItem Value="22">OPD</asp:ListItem>
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>
                            </div>
                                                 
                                     <div class="col-lg-12 mt-3"> 
                                <div class="row">
                                             
                                             <div class="col-sm-2 text-left">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div2" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                 <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                      </div>
                                                    </div> 
                                             
                                            <div class="col-sm-2 text-left">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                 <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                                     <div class="col-sm-3 text-left">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                     <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select"
                                                       
                                                    />                                                      
                                                </div>                                                    
                                    </div>
                                     <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:TextBox ID="txtBillNo" runat="server"  placeholder="Bill No" CssClass="form-control"
                                                       
                                                    />                                                      
                                                </div>                                                    
                                    </div>

                                    <div class="col-sm-1 text-left">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" class="btn btn-danger" />
                                        </div>
                                            </div>
                                    </div>
                                    </div>
                            </div>
                                    
                                    <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="BillNo,PatRegId,ProcedureId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True" OnRowDataBound="gvPatientInfo_RowDataBound">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        <asp:BoundField DataField="AmountPaid" HeaderText="Status" ItemStyle-Width="60" >
                                                             <ItemStyle Width="60px" />
                                                        </asp:BoundField> 
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                          
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="CreatedOn" HeaderText="Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="BillGroup" HeaderText="Bill Group" ItemStyle-Width="150"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="InsuranceAmt" HeaderText="Insurance Amt" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="AmountPaid" HeaderText="Amt Paid" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="BalanceAmt" HeaderText="Balance Amt" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:ButtonField CommandName="Report" Text="Print" HeaderText="Print" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                          <asp:ButtonField CommandName="CasePaper" Text="CasePaper" HeaderText="Case Paper" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                         <asp:ButtonField CommandName="DataForm" Text="DataForm" HeaderText="Data Form" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        
                                                       
                                                    </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
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
                               

                       <%-- </div>--%>
                    </div>
                </div>
            </section>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

       <script language="javascript" type="text/javascript">
           function OpenReport() {
               window.open("Reports.aspx");
           }
               </script>
</asp:Content>


