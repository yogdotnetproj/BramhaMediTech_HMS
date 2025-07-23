<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" enableEventValidation="true" CodeFile="GenerateInvoiceForOPD_Insu.aspx.cs" Inherits="GenerateInvoiceForOPD_Insu" %>



    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
     <script type="text/javascript">

        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnreport" /> 
             <asp:PostBackTrigger ControlID="btngenerate" />
             <asp:PostBackTrigger ControlID="btnSearch" />

             <asp:PostBackTrigger ControlID="btnExcel" />
             <asp:PostBackTrigger ControlID="btnreportAll" />
             


         </Triggers>
         <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Generate Invoice For OPD</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Generate Invoice For OPD</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                     <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                           
                            </div>
                    <div class="box-body">
                        <div class="row">
                             <div class="col-lg-12">
                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlag_SelectedIndexChanged" >
                                                           <asp:ListItem Selected="true" Value="Patient Search">Patient Search</asp:ListItem>  
                                                              <asp:ListItem Value="Search">Search</asp:ListItem>       
                                                              <%-- <asp:ListItem  Value="Generate">Generate Invoice</asp:ListItem>--%>
                                                                 
                                                                                                                  
                                                         </asp:RadioButtonList>                                              
                      
                                                        </div>
                                    </div>

                             <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="txtStart">From Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-sm-1">
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
                                              <div class="col-sm-2">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtchargeNumber" placeholder=" Charge Number" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                                  </div>
                                              <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="txtPatientName" placeholder="Patient Name " CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                                  </div>
                                             </div>
                                 </div>
                                   
                                    <div class="col-lg-12 mt-3">
                                         <div class="row">
                                                  <%--<div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranceid">Insurance Company</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> --%>                            
                                                  <div class="col-sm-3">
                                                    <div class="form-group">                 
                                   
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                     

                                    <div class="col-sm-5">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" CssClass="btn btn-primary btnSearch" />
                                                
                                                <asp:Button ID="btnRePort"  runat="server" Text="Report" TabIndex="3" CssClass="btn btn-success btnSearch" OnClick="btnRePort_Click" />
                                                <asp:Button ID="btnExcel"  runat="server" Text="Excel" TabIndex="3" CssClass="btn btn-primary btnSearch" OnClick="btnExcel_Click" />

                                       <asp:Button ID="btnreportAll"  runat="server" Text="Report All" TabIndex="3"  CssClass="btn btn-warning" OnClick="btnreportAll_Click"  />

                                        </div>
                                            </div>
                                    </div>
                                                <div class="col-sm-2">
                                        <div class="form-group">
                                            <asp:RadioButtonList ID="RblInvComp" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="0">Pen.</asp:ListItem>
                                                <asp:ListItem  Value="1">Comp</asp:ListItem>
                                            </asp:RadioButtonList>
                                            </div>
                            </div>
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                           <asp:CheckBox ID="ChkAll" Text=" All Check"  runat="server" AutoPostBack="true"  CssClass="form-check" OnCheckedChanged="ChkAll_CheckedChanged" ></asp:CheckBox>
                                                                                                                                                                                            
                                                         </div>
                                                      </div> 
                                </div>
                                        </div>
                            

                                         <div class="col-lg-12 mt-3" runat="server" id="PInV">
                                             <div class="col-lg-12 mt-3" runat="server" >
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%;height:900px">
                                                
                                                 <asp:GridView ID="GVPAtientInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="ID,ChargeNo,InsuranceCompId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="GVPAtientInvoice_RowCommand" OnPageIndexChanging="GVPAtientInvoice_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="5550" ShowHeaderWhenEmpty="True" OnRowDataBound="GVPAtientInvoice_RowDataBound">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        <asp:ButtonField CommandName="Edit" Text="Edit" HeaderText="Edit" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>
                                                      
                                                         <asp:ButtonField CommandName="ReportPDf" Text="PDF" HeaderText="Report" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>

                                                      <asp:ButtonField CommandName="Report" Text="USD" HeaderText="USD" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>

                                                        <asp:ButtonField CommandName="ReportWord" Text="Word" HeaderText="Report" ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>
                                                        
                                                        <asp:BoundField DataField="Patregid" HeaderText="Reg No" />
                                                         <asp:BoundField DataField="FirstName" HeaderText="Pat Name" />
                                                        <asp:BoundField DataField="ChargeNo" HeaderText="Charge No" />
                                                          <asp:BoundField DataField="PatientInsuType" HeaderText="Insurance Name" />
                                                         <asp:BoundField DataField="Insuranceamt" HeaderText="Insurance Amt" />
                                                        
                                                        <asp:BoundField DataField="Createdon" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                         
                                                        <asp:BoundField DataField="GenerateInvoice" HeaderText="Status"  />
                                                      <asp:TemplateField HeaderText="Gen Invoice">
                                                          <ItemTemplate>
                                                              <asp:CheckBox runat="server" ID="ChkGenInv"  />
                                                          </ItemTemplate>
                                                      </asp:TemplateField>
                                                        
                                                        
                                                       
                                                       <asp:TemplateField>
                                                    <ItemTemplate>
    
                                                        <asp:HiddenField ID="hdnGenerateInvoice" runat="server" Value='<%#Eval("GenerateInvoice") %>' /> 
                                                        <asp:HiddenField ID="hdnChargeYear" runat="server" Value='<%#Eval("ChargeYear") %>' /> 
                                                         <asp:HiddenField ID="hdnChargeMonth" runat="server" Value='<%#Eval("ChargeMonth") %>' /> 

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
                                              <div  class="col-lg-12 mt-3" runat="server" >
                                        <div class="row">
                                            <div class="col-sm-12 text-center">
                                        <div class="form-group">
                                            <asp:Button ID="btngenerate" runat="server" CausesValidation="False" CssClass="btn btn-success" 
                                             Text="Generate Invoice" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" OnClick="btngenerate_Click" />
                                            </div></div>
                                            </div>
                                                  </div>
                                         </div>
                               
                                    <div class="col-lg-12 mt-3" runat="server" id="GInV">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="InvoiceNo,InsuranceCompId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                      <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>
                                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="PatientInsuType" HeaderText="Insurance Name" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="BillAmount" HeaderText="Insurance Amount" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="FromDate" HeaderText="FromDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="100" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="ToDate"  HeaderText="ToDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="100" >
                                                       
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                        
                                                        
                                                       
                                                       
                                                       
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
                 
            </section>
             <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
            <script language="javascript" type="text/javascript">
                function OpenReport() {
                    window.open("Reports.aspx");
                }
               </script>
        

    
</asp:Content>

