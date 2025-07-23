<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EMR_IPDLab_Test.aspx.cs" Inherits="EMR_IPDLab_Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
       <Triggers>
             <asp:PostBackTrigger ControlID="btnSearch" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>EMR IPD Lab Test</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">EMR IPD Lab Test</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" CssClass="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" AutoPostBack="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control"  type="text" runat="server" AutoPostBack="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>

                                    
                                <div class="col-sm-3">
                                    <div class="form-group">                                        
                                      <asp:TextBox ID="txtPatientName" runat="server" AutoPostBack="True" placeholder="Enter Patient Name" CssClass="form-control" ontextchanged="txtPatientName_TextChanged" TabIndex="1" ></asp:TextBox>
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
                                        
                                        
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:TextBox ID="txtMobileNo" runat="server" placeholder="Enter Mobile No"  TabIndex="2" CssClass="form-control" />                                                      
                                                </div>                                                    
                                    </div>
                                         </div>
                                     <div class="row mt-3">
                             
                               <div class="col-sm-7" runat="server"  >
                                   
                                   
                                       <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbStatus" runat="server"  RepeatDirection="Horizontal" AutoPostBack="false"  >
                                                             <asp:ListItem  Value="P">Pathology</asp:ListItem>
                                                             <asp:ListItem  Value="R">Radiology</asp:ListItem>                                                                                                                    
                                                             <asp:ListItem  Value="M">Medical LAB</asp:ListItem>
                                                              <asp:ListItem  Value="C">Cardiology</asp:ListItem>
                                                             <asp:ListItem  Value="O" Selected="True">All</asp:ListItem>
                                                             </asp:RadioButtonList>  
                                                        </div>
                                       
                               </div>
                                         <div class="col-sm-1">
                                                             <div class="form-group">
                                                               
                                                             <label for="txtFrom"> Status:</label> 
                                                             </div>
                                                         </div>       
                                        <div id="Div2" class="col-sm-4" runat="server"  >
                                    <div class ="row">
                                   
                                       <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RblTestStatue" runat="server"  RepeatDirection="Horizontal" AutoPostBack="false"  >
                                                            
                                                             <asp:ListItem  Value="A">All</asp:ListItem>                                                                                                                    
                                                             <asp:ListItem  Value="C">Completed</asp:ListItem>
                                                             <asp:ListItem  Value="P" Selected="True">Pending</asp:ListItem>
                                                             </asp:RadioButtonList>  
                                                        </div>
                                        </div>
                               </div>
                                         <div class="col-sm-1">
                                                             <div class="form-group">
                                                                 <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-warning"
                                            Text="Search" />
                                       
                                        <asp:Button ID="btnReset" runat="server" Visible="false" onclick="btnReset_Click" class="btn btn-primary" 
                                            Text="Reset" />
                                                                 </div>
                                             </div>
                                         <div class="col-sm-4" runat="server" visible="false">
                                                <div class="form-group">
                                                       
                                                    <asp:TextBox ID="txtbillNo" runat="server" placeholder="Enter Bill No"  TabIndex="2" CssClass="form-control"/>                                                      
                                                </div>                                                    
                                    </div> 
                                         <div class="col-sm-4" runat="server" visible="false">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select-" />                                                      
                                                </div>                                                    
                                    </div>
                                     </div>
                                     </div>

                                       <%--  <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 mt-3 text-center ">
                                          
                                        </div>
                                    </div>
                                </div>--%>
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
                                 onpageindexchanging="gvDailyCash_PageIndexChanging" PageSize="20" OnRowDeleting="gvDailyCash_RowDeleting" OnRowEditing="gvDailyCash_RowEditing">
                                 
                                      <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                 
                                <Columns>
                                     <asp:CommandField ButtonType="Button" Visible="false" FooterStyle-ForeColor="Black"  EditText="Pay" ShowEditButton="True">

<FooterStyle ForeColor="Black"></FooterStyle>

                                <ItemStyle Width="50px" />
                                <ControlStyle Width="50px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="BillPrint" Visible="false">
                            <ItemTemplate>                                
                               
                            <asp:DropDownList ID="ddlReceipt" AutoPostBack="true"  runat="server" 
                                    onselectedindexchanged="ddlReceipt_SelectedIndexChanged" onclientclick="target = '_blank';"></asp:DropDownList>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                          
                            <asp:BoundField DataField="CancelBill" HeaderText="Status"></asp:BoundField>
                                     <asp:BoundField DataField="EntryDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                      />
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" 
                                     />
                                    <asp:BoundField DataField="LabNo" HeaderText="Lab No" 
                                     />
                                   
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                                    <%--<asp:BoundField DataField="BillNo" HeaderText="Bill No">
                                    
                                     </asp:BoundField>--%>
                                     
                                     
                                           <asp:BoundField DataField="CreatedBy" HeaderText="User Name"/>
                                     <asp:BoundField DataField="LabPType" HeaderText="P Type"/>
                                      <asp:BoundField DataField="ClinicalHistory" HeaderText="Clinical History"/>
                                    <asp:BoundField DataField="WardName" HeaderText="Room Type"/>
                                     <%--<asp:BoundField DataField="BillServiceCharges" HeaderText="Bill Amount">                                  
                                     </asp:BoundField>
                                    <asp:BoundField DataField="DiscountAmt" HeaderText="Discount"/>
                                   <asp:BoundField DataField="InsuranceAmount" HeaderText="Insurance Amount "/>
                                    <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Received"/>
                                     
                                    <asp:BoundField DataField="BalanceAmt" HeaderText="Balance"/>--%>
                              
                                      <asp:TemplateField HeaderText="Report">
                                 <ItemTemplate>
                                     <asp:Button ID="btnPrint" runat="server" Text="Report" OnClick="btnPrint_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                   <%-- <asp:BoundField DataField="CreatedBy" HeaderText="User Name"/>
                                     <asp:BoundField DataField="DiscType" HeaderText="DiscRemark" />
                                     --%>
                                     <asp:TemplateField HeaderText="Case Paper" Visible="false">
                                 <ItemTemplate>
                                     <asp:Button ID="btncasepaper" runat="server" Text="Case Paper" OnClick="btncasepaper_Click"   />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Add Bill"  >
                                 <ItemTemplate>
                                     <asp:Button ID="btnAddBill" runat="server" Text="Add Bill" OnClick="btnAddBill_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                     <asp:TemplateField >
                                    <ItemTemplate>
                                      
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                       <asp:BoundField DataField="VerbalBy" HeaderText="Verbal Order">
                                    
                                     </asp:BoundField>
                                     <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnCancelBill" runat="server" Value='<%#Eval("CancelBill") %>' />
                                             <asp:HiddenField ID="HdnBillNo" runat="server" Value='<%#Eval("BillNo") %>' />
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnLabNo" runat="server" Value='<%#Eval("LabNo") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                              <asp:HiddenField ID="HdnPatRegId" runat="server" Value='<%#Eval("PatRegId") %>' />
                                              <asp:HiddenField ID="HdnLabPType" runat="server" Value='<%#Eval("LabPType") %>' />
                                             
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                                 <%--<FooterStyle BackColor="#006699" ForeColor="White" />--%>
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

