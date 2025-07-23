<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="SettleInsurance.aspx.cs" Inherits="SettleInsurance" %>

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
                    <h1>Bill Outstanding</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Bill Outstanding</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2 text-left">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <input id="txtFrom" class="form-control"  type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                 <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1 text-right">
                                                             <div class="form-group">
                                                               <label for="txtTo" style="width:90px">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2 text-left">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <input id="txtTo" class="form-control"  type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
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
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                    </div>
                                </div>
                                        
                                        
                                    
                             
                               <div class="col-lg-12 mt-3" >
                                    <div class ="row">
                                   <div class="col-sm-2 text-right">
                                                        <div class="form-group">
                                                        <label for="txtMobileNo">Mobile No:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:TextBox ID="txtMobileNo" runat="server"  TabIndex="2" CssClass="form-control"
                                                        />                                                      
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

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click"  CssClass="btn btn-primary"
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
                                     <asp:CommandField ButtonType="Button" FooterStyle-ForeColor="Black"  EditText="Pay" ShowEditButton="True">

<FooterStyle ForeColor="Black"></FooterStyle>

                                <ItemStyle Width="50px" />
                                <ControlStyle Width="50px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="BillPrint">
                            <ItemTemplate>                                
                               
                            <asp:DropDownList ID="ddlReceipt" AutoPostBack="true"  runat="server" 
                                    onselectedindexchanged="ddlReceipt_SelectedIndexChanged" onclientclick="target = '_blank';"></asp:DropDownList>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Final Bill">
                                 <ItemTemplate>
                                     <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                            <asp:BoundField DataField="BalanceAmt" HeaderText="Status"></asp:BoundField>
                                     <asp:BoundField DataField="EntryDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                      />
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" 
                                     />
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                                    <%--<asp:BoundField DataField="BillNo" HeaderText="Bill No">
                                    
                                     </asp:BoundField>--%>
                                     
                                     
                                    
                                     <asp:BoundField DataField="BillServiceCharges" HeaderText="Bill Amount">                                  
                                     </asp:BoundField>
                                    <asp:BoundField DataField="DiscountAmt" HeaderText="Discount"/>
                                   
                                    <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Received"/>
                                     
                                    <asp:BoundField DataField="BalanceAmt" HeaderText="Balance"/>
                                   <%-- <asp:BoundField DataField="CreatedBy" HeaderText="User Name"/>
                                     <asp:BoundField DataField="DiscType" HeaderText="DiscRemark" />
                                     --%>
                             <asp:TemplateField HeaderText="Add Bill">
                                 <ItemTemplate>
                                     <asp:Button ID="btnAddBill" runat="server" Text="Add Bill" OnClick="btnAddBill_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                     <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnBillNo" runat="server" Value='<%#Eval("BillNo") %>' />
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnOpdNo" runat="server" Value='<%#Eval("OpdNo") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                                 <%--<FooterStyle BackColor="#006699" ForeColor="White" />--%>
                                 <FooterStyle  ForeColor="black" />
                                 <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
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

