<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="RadiologyBillPayment.aspx.cs" Inherits="RadiologyBillPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <%-- <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>--%>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Radiology Bill Details</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Radiology Bill Details</li>
                    </ol>
                </section>
            <section class="content">    
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">    
                                     <div class="col-sm-2">
                                                             <div class="form-group">                                                                 
                                                             <label for="txtFrom" >From Date:</label> 
                                                             </div>
                                                         </div>   
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                             <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                 </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1 p-0">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                      <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtTo" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                 </div>
                                                     

                                                     </div>
                                                 </div>

                                     <div class="col-sm-2 text-right">
                                    <div class="form-group"> 
                                        <label class="control-label" >
                                                    Patient Name
                                                  </label> 
                                     
                                    </div>
                                 </div>
                                <div class="col-sm-3 text-left">
                                    <div class="form-group">                                        
                                      <asp:TextBox ID="txtPatientName" runat="server" AutoPostBack="True" CssClass="form-control" ontextchanged="txtPatientName_TextChanged" TabIndex="1"  Font-Bold="True" Font-Size="Larger" ></asp:TextBox>
                                        <%--<asp:autocompletextender  ServiceMethod="SearchPatient" MinimumPrefixLength="1"  EnableCaching="false" CompletionSetCount="1" 
                                        CompletionInterval="5" ID="AutoCompleteExtender2" TargetControlID="txtPatientName" runat="server"></asp:autocompletextender>
                                        --%> 
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                    </div>
                                </div>
                                        
                                        
                                    
                             
                               <div class="col-lg-12 mt-3">
                                    <div class ="row">
                                   <div class="col-sm-2">
                                                        <div class="form-group">
                                                        <label for="txtMobileNo">Mobile No:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:TextBox ID="txtMobileNo" runat="server"  TabIndex="2" CssClass="form-control" />                                                      
                                                </div>                                                    
                                    </div>
                                        <div class="col-sm-6">
                                       <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbStatus" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                                             <asp:ListItem  Value="0">Paid</asp:ListItem>
                                                             <asp:ListItem  Value="1">Balance</asp:ListItem>                                                                                                                    
                                                             <asp:ListItem  Value="2">All</asp:ListItem>
                                                             </asp:RadioButtonList>  
                                                        </div>
                                            </div>
                                        </div>
                               </div>
                                        
                                        
                                     </div>
                                     </div>

                                         <div class="box-footer mt-3">
                                    <div class="row">
                                        <div class="col-sm-12 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" CssClass="btn btn-primary"
                                            Text="Search" />
                                       <%-- <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-primary" 
                                            OnClick="Print_Click" onclientclick="target = '_blank';" Text="Print" />
                                       --%> 
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" CssClass="btn btn-primary" 
                                            Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvDailyCash" runat="server" AllowPaging="True" datakeynames="PatRegId"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                 class="table table-responsive table-sm table-bordered" Width="100%"
                                 HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                                 EmptyDataText="No Records to Display" 
                                 onrowdatabound="gvDailyCash_RowDataBound" ShowFooter="True" 
                                 ShowHeaderWhenEmpty="True" 
                                 onpageindexchanging="gvDailyCash_PageIndexChanging" PageSize="20" OnRowEditing="gvDailyCash_RowEditing">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns>
                                     <asp:CommandField ButtonType="Button"  FooterStyle-ForeColor="Black"  EditText="Edit" ShowEditButton="True">

<FooterStyle ForeColor="Black"></FooterStyle>

                                <ItemStyle Width="50px" />
                                <ControlStyle Width="50px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="BillPrint" Visible="false">
                            <ItemTemplate>                                
                               
                            <asp:DropDownList ID="ddlReceipt" AutoPostBack="true"  runat="server" CssClass="form-control form-select"
                                    onselectedindexchanged="ddlReceipt_SelectedIndexChanged" onclientclick="target = '_blank';"></asp:DropDownList>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                            <asp:BoundField DataField="BalanceAmt" HeaderText="Status"></asp:BoundField>
                                     <asp:BoundField DataField="EntryDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                      />
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" 
                                     />
                                    <asp:BoundField DataField="FirstName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                                    <%--<asp:BoundField DataField="BillNo" HeaderText="Bill No">
                                    
                                     </asp:BoundField>--%>
                                     
                                     
                                    
                                     <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount">                                  
                                     </asp:BoundField>
                                    <asp:BoundField DataField="InsuranceAmount" HeaderText="Insurance Amt"/>
                                 <asp:BoundField DataField="DiscountAmt" HeaderText="Discount"/>
                                   
                                    <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Received"/>
                                     
                                    <asp:BoundField DataField="FinalBalance" HeaderText="Balance"/>
                                      <asp:BoundField DataField="LabPtype" HeaderText="Type"/>
                                  <asp:TemplateField HeaderText="Pay Receive">
                                 <ItemTemplate>
                                     <asp:CheckBox ID="ChkFinalSettelement"   runat="server" AutoPostBack="true" Checked='<%# Eval("RadioPayReceive") %>' OnCheckedChanged="ChkFinalSettelement_CheckedChanged"></asp:CheckBox>                                    
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Receive Amt">
                                 <ItemTemplate>
                                     <asp:Button ID="btnAddBill" runat="server" Text="Rec Amt" OnClick="btnAddBill_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Final Bill" >
                                 <ItemTemplate>
                                     <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                     <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnBillNo" runat="server" Value='<%#Eval("BillNo") %>' />
                                              <asp:HiddenField ID="hdnLabPtype" runat="server" Value='<%#Eval("LabPtype") %>' />
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnLabNo" runat="server" Value='<%#Eval("LabNo") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                              <asp:HiddenField ID="HdnBillPaymentId" runat="server" Value='<%#Eval("BillPaymentId") %>' />
                                             <asp:HiddenField ID="HdnReceiptNo" runat="server" Value='<%#Eval("ReceiptNo") %>' />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                                 <%--<FooterStyle BackColor="#006699" ForeColor="White" />--%>
                                 <FooterStyle  ForeColor="black" />
                                 <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                
                                 <RowStyle ForeColor="#000066" />
                                 <PagerStyle CssClass="pagination" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                 <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                 <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                 <SortedDescendingHeaderStyle BackColor="#00547E" />
                                     
                             </asp:GridView>
                                
                            </div>                                                                       
                                        

                                
                            </div>
                                </div>
               <%-- <div class="box" runat="server" id="List">
                                        
                               
                                         
                                     </div>--%>

                                 
                 
                        </section>
         </ContentTemplate>
    </asp:UpdatePanel>
     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script>
</asp:Content>

