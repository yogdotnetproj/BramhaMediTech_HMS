<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IpdAdvancePayment.aspx.cs" Inherits="IpdAdvancePayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
         <ContentTemplate>
            
                <section class="content-header d-flex">
                    <h1>Ipd Advance Payment</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Ipd Advance Payment</li>
                    </ol>
                </section>
           
               
                <section class="content">
                    <div class="box">
                                <div class="box-header with-border">
                           
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                </div>
                    
                                 <div class="box-body">
                           
                           
                                <div class="col-lg-12">
                                     <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:   <asp:Label  ID="lblMessage1"  Font-Bold="true" ForeColor="White"  runat="server" Text=""></asp:Label> </div>
                                        <div class="form-group">
                                            <div class="row">
                                        <div class="col-lg-6">
                                             
                                                 <div class="form-group">
                                                     <div class="row">
                                                    <div class="col-lg-2 pr-0">
                                                        <div class="form-group">
                                                            <label for="lblRegNo">Reg No :</label>  
                                                            </div>
                                                    </div>
                                                    <div class="col-lg-2"> 
                                                         <div class="form-group">
                                                             <asp:Label ID="lblRegNo" runat="server"  Font-Bold="True" >
                                                             </asp:Label>
                                                        </div>
                                                </div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <label for="lblPatName">Name :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-6">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblPatName" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                              
                                                  <div class="col-lg-12 mt-3">
                                                      
                                                       <div class="form-group">
                                                    
                                                          <div class="row">
                                                    <div class="col-lg-2 pr-0">
                                                        <div class="form-group">
                                                            <label for="lblIPDNo">IPD No :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-2">
                                                <div class="form-group">
                                                 <asp:Label ID="lblIPDNo" runat="server"  Font-Bold="True">

                                                 </asp:Label>
                                                    </div>
                                                </div>
                                                    <div class="col-lg-4">
                                                                                 
                                                                                                      
                                                        <asp:CheckBox ID="ChkReceipt" Text=" Prev.Receipts"  runat="server" AutoPostBack="true" ></asp:CheckBox>
                                            
                                                                 </div>
                                                    <div class="col-lg-4">
                                                        <asp:DropDownList ID="ddlreceipts" runat="server" AutoPostBack="True" class="form-control form-select">                                                      
                                                        </asp:DropDownList>  
                                                    </div>

                                                       </div>
                                                        </div>
                                                      </div>  
                                                     
                                                  <div class="col-lg-12 mt-3 mb-3">
                                                       
                                                       <div class="form-group">                                                   
                                                        <div class="row">
                                                    <div class="col-lg-3">
                                                        <div class="form-group"> 
                                                            <label for="ddlConsDoctorName" title="" >Consultant Dr.</label> 
                                                            </div>
                                                        </div>
                                                           <div class="col-lg-4">
                                                                <div class="form-group">
                                                                         <asp:DropDownList ID="ddlConsDoctorName" runat="server" class="form-control form-select">
                                                                         </asp:DropDownList>                                                
                                                               </div>
                                                         </div>
                                                             <div class="col-lg-2">
                                                                <div class="form-group">
                                                             <asp:Button ID="btncancelreceipt" runat="server"  
                                        Text="Cancel Receipt"  UseSubmitBehavior="false"  OnClientClick="this.disabled='true';this.Value='Please Wait...';"  ToolTip="Cancel Receipt" class="btn btn-danger" OnClick="btncancelreceipt_Click"  />
                                                                    </div>
                                                                </div>
                                                           </div>
                                                      </div>
                                                            
                                                          </div>
                                                          <div style="height:2px; background:#B24592;"> </div>
                                                                                             
                                         
                                                  
                                                         <div class="col-lg-12">
                                                             <div class="form-group">
                                                     <div class="table-responsive">
                                                             <asp:GridView ID="gvBillTransaction" class="table table-responsive table-sm table-bordered" runat="server" AutoGenerateColumns="False" Width="100%"                                       
                                                              HeaderStyle-ForeColor="Black" ShowHeaderWhenEmpty="true"  AlternatingRowStyle-BackColor="White"   >
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PaymentDate" HeaderText="Transaction Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                       <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No " />
                                                                          <asp:BoundField DataField="DiscountGivenBy" HeaderText="Dr Name " />
                                                                         <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Paid" />
                                                                        <asp:BoundField DataField="ModeOfPaymentName" HeaderText="Mode Of Payment" />
                                            
                                                                        <asp:BoundField DataField="CreatedBy" HeaderText="Transcation User" />
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
                                    

                                        <div class="col-lg-6">
                                            
                                             <div class="form-group">
                                                 <div class="row">
                                                  <div class="col-lg-4">
                                                        <div class="form-group">
                                                            <label for="lblBillServiceCharges">Bill Amount:</label>  
                                                            </div>
                                                    </div>
                                                  <div class="col-lg-2">
                                                        <div class="form-group">                                                                
                                                            <span> <asp:Label ID="lblBillServiceCharges" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></span>
                                                        </div>                                                                            
                                                 </div>                                                
                                                  <div class="col-lg-4">
                                                         <div class="form-group">
                                                              <label for="lblAdvanceAmt">Advance Amount:</label>
                                                             </div>
                                                      </div>                                        
                                                  <div class="col-lg-2">
                                                <div class="form-group">
                                                <span><asp:Label ID="lblAdvanceAmt" Font-Bold="true" ForeColor="Green" runat="server"></asp:Label></span>
                                            </div> 
                                          </div>
                                
                                                  <div class="col-lg-12 mt-3">
                                                     
                                                         <div class="form-group">
                                                             <div class="row">
                                                         <div class="col-lg-4">
                                                        <div  class="form-group">
                                                                 <label >Discount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblDiscAmt" runat="server" ForeColor="Blue" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>
                                                          <div class="col-lg-4 text-left">
                                                        <div  class="form-group">
                                                                 <label >Insurance Amount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblInsurance"   runat="server" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>
                                                                 </div>
                                                             <div class="row mt-3">
                                                                  <div class="col-lg-4 text-left">
                                                        <div  class="form-group">
                                                                 <label >Balance</label>
                                                            </div>
                                                      </div>                                                                         
                                                         <div class="col-lg-2 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblBalance" runat="server" ForeColor="Red" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>

                                                         </div>
                                                     </div>
                                              </div>
                                                
                                                 <div class="col-lg-12 mt-3">
                                                                                                          
                                                 
                                                         <div class="form-group">
                                            <div class="row">   
                                                        
                                                            
                                                              <div class="col-lg-10 text-left">
                                                        <div  class="form-group">
                                                                  <asp:Label ID="LblSurgeryDepAmt" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                            </div>
                                                      </div>

                                                         </div>
                                                     </div>
                                              </div>

                                                  <div class="col-lg-12">                                            
                                            <div class="row"> 
                                                    
                                                             <div class="col-lg-12">
                                                                   <label> <b>Pay By :</b> </label>
                                                              
                                                      </div>
                                                    <div class="col-lg-12">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" autoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>
                                                 
                                                            
                                                 </div>
                                              </div> 
                                                                                               
                                                  <div id="PaymentDetails" runat="server">
                                                
                                                       <div class="col-lg-12 mt-3">
                                                           <div class="form-group">
                                                                <div class="row">  
                                                       <div class="col-lg-4">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"   placeholder="Card/Cheque No."
                                                     TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-4">
                                                           <div class="form-group">  
                                                                               
                                                  <asp:DropDownList ID="txtbankName" runat="server"  CssClass="form-control"    placeholder="Bank Name"  ></asp:DropDownList>

                                                               </div>
                                                        </div>
                                                       <div class="col-lg-4" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                             <asp:TextBox id="txtchequedate" class="form-control"  type="text" runat="server" autopostback="true" placeholder="dd/mm/yyyy" /> 
                                                        
                                                       <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                  </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                                    </div>
                                                               </div>
                                                           </div>
                                                       
                                                       </div>

                                                 

                                                
                                                  <div class="col-lg-12 mt-3">                                            
                                            <div class="row"> 
                                                    

                                                 <div class="col-lg-6">
                                                    <div class="form-group">
                                                             <label>Amount Given</label>
                                                                 <div class="row">
                                                                         <div class="col-lg-12"> 
                                                                            <asp:TextBox id="txtAmtPaid" runat="server" class="form-control" placeholder="Amount Paid"  OnTextChanged="txtAmtPaid_TextChanged" AutoPostBack="True"></asp:TextBox> 
                                                                        </div>
                                                                     </div>
                                                            </div>
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="chkDeposite" Text="Transfer From Deposite" ForeColor="Red" runat="server" AutoPostBack="true" ></asp:CheckBox></label>
                                                         <asp:Label ID="lblDepositAmt" ForeColor="Red" runat="server" Font-Bold="True" ></asp:Label>
                                           
                                       
                                    
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label>Remark</label>

                                        <div class="row">
                                            <div class="col-lg-12">
                                               
                                                   <textarea  runat="server" id="txtRemark" cols="25"  rows="2"></textarea>        
                                                       
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                                </div>
                                                      </div>
                                                  
                                                 <div class="col-lg-12">                                            
                                            <div class="row"> 
                                                 <asp:Label ID="lblerrormsg"   runat="server" Text="" Font-Bold="true" ForeColor="Red" ></asp:Label>
                            </div>
                                                     </div>
                                                  </div>
                                                 
                                            </div>
                                                 </div>

                                            </div>
                                         </div>
                                         </div>
                                          
                            </div>
                        
                                
                                 <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                  
                                    <asp:Button ID="btnsave"  class="btn btn-success" runat="server"  Text="Save Bill" OnClick="btnsave_Click"  />
                                   
                                    <asp:Button ID="btnreport" runat="server"  OnClick="btnreport_Click" onclientclick="target = '_blank';"
                                        Text=" Print" ToolTip="Print" class="btn btn-primary" />
                                    
                                     <asp:Button ID="btnIPDBill" runat="server"  
                                        Text=" IPD Bill" ToolTip="IPD BILL" class="btn btn-warning" OnClick="btnIPDBill_Click" />
                                    
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
            var radio = document.getElementsByName("RadioButtonList1"); //Client ID of the RadioButtonList1                          

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
