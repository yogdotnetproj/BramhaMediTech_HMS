<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="ReceiveInsurancePayment.aspx.cs" Inherits="ReceiveInsurancePayment" %>


    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">

        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnreport" />
             <asp:PostBackTrigger ControlID="btnSave" />
             
         </Triggers>
         <ContentTemplate>
   
            <section class="content-header d-flex">
                <h1>Generate Invoice</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Generate Invoice</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                     <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" CssClass="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                           
                            </div>
                    <div class="box-body">
                        <div class="row">
                              <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranceid">Insurance Company</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
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
                             
                              <div class="col-sm-3">
                                                                                 
                                                                                                      
                                                        <asp:CheckBox ID="ChkReceipt" Text=" Prev.Receipts"  runat="server" AutoPostBack="true" OnCheckedChanged="ChkReceipt_CheckedChanged" CssClass="form-check" ></asp:CheckBox>
                                            
                                                                 </div>
                              <div class="col-sm-2">
                                                        <asp:DropDownList ID="ddlreceipts" runat="server" AutoPostBack="True" CssClass="form-control form-select">                                                      
                                                        </asp:DropDownList>  
                                                    </div>
                                                 <div class="col-sm-1">
                                                 <asp:Button ID="btnreport" runat="server"  OnClick="btnreport_Click" 
                                        Text=" Print" ToolTip="Print" class="btn btn-primary" />
                                                     </div>
                                    
                                                </div>
                                   <div class="col-lg-12 mt-3" runat="server" id="PInV">
                                             <div id="Div2" class="col-lg-12 mt-3" runat="server" >
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%;height:900px">
                                                 <asp:GridView ID="GVPAtientInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="InvoiceDetailId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" 
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="5550" ShowHeaderWhenEmpty="True" OnRowDataBound="GVPAtientInvoice_RowDataBound" >
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        <asp:ButtonField CommandName="Edit" Text="Edit" HeaderText="Edit" Visible="false" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>
                                                      <asp:ButtonField CommandName="Report" Text="Report" HeaderText="Report" Visible="false" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>
                                                        <asp:BoundField DataField="Patregid" HeaderText="Reg No" />
                                                         <asp:BoundField DataField="FirstName" HeaderText="Pat Name" />
                                                       
                                                          
                                                         <asp:BoundField DataField="InsuranceAmount" HeaderText="Insurance Amt" />
                                                        
                                                        <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                         
                                                      
                                                      <asp:TemplateField HeaderText="Gen Invoice">
                                                          <ItemTemplate>
                                                               <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                                                                   <ContentTemplate>
                                                                      
                                                              <asp:CheckBox runat="server" ID="ChkGenInv" AutoPostBack="false" Checked="false"  />
                                                          </ContentTemplate>
                                                               </asp:UpdatePanel>
                                                                   
                                                                        </ItemTemplate>
                                                      </asp:TemplateField>
                                                        
                                                         <asp:TemplateField HeaderText="Rec Amt">
                                                          <ItemTemplate>
                                                              <asp:UpdatePanel ID="UpdatePanel16" runat="server" >
                                                                   <ContentTemplate>
                                                              <asp:TextBox runat="server" ID="txtrecamt" Width="150px" AutoPostBack="false"  />
                                                          </ContentTemplate>
                                                               </asp:UpdatePanel>
                                                                        </ItemTemplate>
                                                      </asp:TemplateField>
                                                       
                                                       <asp:TemplateField>
                                                    <ItemTemplate>
    
                                                        <asp:HiddenField ID="hdnInsuranceamt" runat="server" Value='<%#Eval("InsuranceAmount") %>' /> 
                                                         <asp:HiddenField ID="HdnIpdNo" runat="server" Value='<%#Eval("IPDNo") %>' /> 
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
                                                                        
                                            <div class="row mt-3"> 
                                                    
                                                             
                                                    
                                                    <div class="col-sm-5">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" autoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                           <asp:ListItem Selected="True" Value="Cheque">Cheque</asp:ListItem>
                                                             <asp:ListItem Value="Card">Card</asp:ListItem>
                                                               <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                               <asp:ListItem Value="Bank">Bank Transfer</asp:ListItem>
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>
                                                 
                                                          <div class="col-sm-3">
                                                                   <div class="form-group"> 
                                                                  <asp:Label runat="server" Font-Bold="true" ForeColor="Red" ID="LblInsTotAmt"></asp:Label>
                                                                       </div>
                                                                  </div>
                                                    <div class="col-sm-3">
                                                                   <div class="form-group"> 
                                                                  <asp:Label runat="server" Font-Bold="true" ForeColor="Green" ID="lblRecAmt"></asp:Label>
                                                                       </div>
                                                                  </div>
                                                 <div class="col-sm-1">
                                                     <div class="form-group"> 
                                                           <asp:Button ID="btnCalc" runat="server" CausesValidation="False" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" class="btn btn-warning" 
                                             Text="Calc" OnClick="btnCalc_Click"   />
                                                         </div>
                                                     </div>     
                                                 </div>
                                              
                                                                                               
                                                  <div id="PaymentDetails" runat="server">
                                                
                                                       <div class="row mt-3">
                                                           
                                                       <div class="col-sm-2">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  CssClass="form-control"  placeholder="DD/Cheque No."
                                                     TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtBankName" runat="server"  CssClass="form-control"  placeholder="Bank Name"
                                                      TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                             <asp:TextBox id="txtchequedate" class="form-control"  type="text" runat="server" autopostback="true" placeholder="dd/mm/yyyy" /> 

                                                        
                                                         <%-- <asp:TextBox ID="txtchequedate" runat="server" height="30px" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>--%>
                                                    <span class="input-group-addon">
                                                         <i class="fa fa-calendar"></i>
                                                    </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                               

                                                           </div>
                                                      </div>
                                                      <div class="col-lg-12 mt-3">                                            
                                            <div class="row"> 
                                                    
                                                <div class="col-sm-2 pr-0">
                                                    <div class="form-group">
                                                         <label>Total Insurance Amount</label>
                                                        </div>
                                                    </div>
                                                 <div class="col-sm-3">
                                                    <div class="form-group">
                                                         <asp:TextBox id="txtInsuranceAmount" runat="server" CssClass="form-control" ReadOnly="true"  AutoPostBack="True"></asp:TextBox> 
                                                    </div>
                                                     </div>
                                                
                                                    
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label>Amount Paid</label>
                                                        </div>
                                                    </div>
                                                 <div class="col-sm-3">
                                                    <div class="form-group">
                                                         <asp:TextBox id="txtPaid" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Amount Paid" ></asp:TextBox> 
                                                     </div>
                                                     </div>
                                                </div>
                                                          </div>
                                                      <div class="col-lg-12 mt-3">                                            
                                                           <div class="row"> 
                                                                 <div class="col-sm-2">
                                                                <div class="form-group">
                                                                     <label>Balance</label>
                                                                    </div>
                                                                </div>
                                                                 <div class="col-sm-3">
                                                                <div class="form-group">
                                                             <asp:TextBox id="txtBalance" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Balance"></asp:TextBox> 
                                                                       
                                                                        </div>
                                                    
                                                            </div>
                                                           
                                                    
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                          <label>Amount Given</label>
                                                        </div>
                                                    </div>
                                                 <div class="col-sm-3">
                                                    <div class="form-group">
                                                       <asp:TextBox id="txtAmtGiven" runat="server" CssClass="form-control" Text="0" placeholder=""></asp:TextBox> 
                                                    </div>
                                                     </div>
                                                </div>
                                                          </div>
                                                      <div class="col-lg-12 mt-3 text-center">
                                        <div class="form-group">
                                            
                                           
                                            <%--<asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" class="btn btn-primary btnSearch" />
                                           --%>     
                                                <asp:Button ID="btnSave" runat="server" CausesValidation="False" class="btn btn-primary" 
                                             Text="Save" OnClick="btnSave_Click"  />
                                         <asp:Label ID="Label1" CssClass="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                        </div>
                                            
                                    </div>
                    </div>
                                                </div>
                                                          
                        </div>
                    </div>
               
                </section>
             </ContentTemplate>
        </asp:UpdatePanel>
      <script language="javascript" type="text/javascript">
          function OpenReport() {
              window.open("Reports.aspx");
          }

   </script>
    <script language="javascript" type="text/javascript">
        function Validate() {
            //alert("R");
            var radio = document.getElementsByName("RdbPayment"); //Client ID of the RadioButtonList1                          

            for (var i = 0; i < radio.length; i++) {

                if (radio[i].checked) { // Checked property to check radio Button check or not

                    // alert("Radio button having value " + radio[i].value + " was checked."); // Show the checked value

                    return true;

                }
                alert("Not checked any Payment mode");
                return false;
            }

        }

   </script>
  
</asp:Content>

