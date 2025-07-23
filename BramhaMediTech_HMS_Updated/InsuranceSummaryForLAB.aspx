<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="InsuranceSummaryForLAB.aspx.cs" Inherits="InsuranceSummaryForLAB" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Insurance LAB Patient Summary</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Insurance LAB Patient Summary</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                            
                            
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="txtStart">From Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off" runat="server" CssClass="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                  <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="txtEnd">To Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                  <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            
                                            <div>
                                           <asp:TextBox runat="server" ID="txtInsuranceid" placeholder=" Insurance Company" CssClass="form-control pull-right" AutoPostBack="true"  OnTextChanged="txtInsuranceid_TextChanged"></asp:TextBox>
                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchInsurance"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtInsuranceid"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                            </div>
                                    </div>
                                    <div class="col-lg-12 mt-3">
                                         <div class="row">
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Patient Name/RegNo</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-3">
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
                                                  <div class="col-sm-1 p-0">
                                                        <div class="form-group"> 
                                                  <label for="ddlBillGroup" title="">Bill Group</label> 
                                                            </div>
                                                     </div>  
                                                  <div class="col-sm-3">
                                                    <div class="form-group">                                                              
                                                        <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                        TabIndex="18">
                                                            <asp:ListItem Value="0">---Select Group--</asp:ListItem>
                                                            <asp:ListItem Value="P">Pathology</asp:ListItem>
                                                            <asp:ListItem Value="R">Radiology</asp:ListItem>
                                                            <asp:ListItem Value="M">Medical LAB</asp:ListItem>
                                                           
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                                    </div>                                               

                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-primary btnSearch" />
                                                <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary" 
                                            OnClick="Print_Click" Text="Print" />
                                       <asp:Button ID="btnexcel" runat="server" CausesValidation="False" CssClass="btn btn-warning" 
                                            Text="Excel" OnClick="btnexcel_Click" />
                                        </div>
                                            </div>
                                    </div>
                                </div>
                                        </div>
                            

                                       
                                <div class="row">
                                    <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="PatRegId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="BillGroup" HeaderText="Bill Group" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="CreatedOn"  HeaderText=" Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                         <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                           <asp:BoundField DataField="InsuranceAmount" HeaderText="Insurance Amt" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="PatientInsuType"  HeaderText="Sponsor " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                           <asp:BoundField DataField="ChargeNumber"  HeaderText="ChargeNumber " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                         <asp:ButtonField CommandName="Print" Text="Print"  ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        
                                                        
                                                         <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnBillNo" runat="server" Value='<%#Eval("BillNo") %>' />
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnLabNo" runat="server" Value='<%#Eval("LabNo") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                              <asp:HiddenField ID="HdnPatRegId" runat="server" Value='<%#Eval("PatRegId") %>' />
                                              <%--<asp:HiddenField ID="HdnLabPType" runat="server" Value='<%#Eval("LabPType") %>' />--%>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                                       
                                                         
                                                        
                                                       
                                                       
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
                                </div>
                            </div>

                        </div>
                        </div>
                    </div>
                </div>
            </section>
            <script language="javascript" type="text/javascript">
                function OpenReport() {
                    window.open("Reports.aspx");
                }
               </script>
      <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

    
</asp:Content>

