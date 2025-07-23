<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Hospital.master" CodeFile="OpdPaybillOutstanding.aspx.cs" Inherits="OpdPaybillOutstanding" %>

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
                    <h1>OutStanding Bill Payment</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OutStanding Bill Payment</li>
                    </ol>
                </section>
           
               
                <section class="content">
                    <div class="box">
                         <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                </div>
                    
                        <div class="box-body">
                           
                           
                                
                                    
                                        <div class="form-group">
                                             <div class="row">
                                        <div class="col-lg-6">
                                             
                                                 <div class="form-group">
                                                     <div class="row">
                                                    <div class="col-lg-3 text-left"  >
                                                        <div class="form-group">
                                                            <label for="lblRegNo" style="text-align:left">Reg No :</label>  
                                                            </div>
                                                    </div>
                                                    <div class="col-lg-2 text-left"> 
                                                         <div class="form-group">
                                                             <asp:Label ID="lblRegNo" runat="server"  Font-Bold="True" Width="100px" Font-Size="Medium" ForeColor="#3333CC">
                                                             </asp:Label>
                                                        </div>
                                                </div>
                                                    <div class="col-lg-3 text-left"  >
                                                        <div class="form-group">
                                                            <label for="lblPatName" style="text-align:left">Name :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-4 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblPatName" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC"></asp:Label>
                                               </div>
                                            </div>
                                               
                                                  <div class="col-lg-12 mt-2">
                                                      
                                                       <div class="form-group">
                                                     <div class="row">
                                                        
                                                    <div class="col-lg-3 text-left">
                                                        <div class="form-group">
                                                            <label for="lblage" style="text-align:left">Age :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-2 text-left" >
                                                <div class="form-group">
                                                 <asp:Label ID="lblage" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC">

                                                 </asp:Label>
                                                    </div>
                                                </div>
                                                    <div class="col-lg-3 text-left">
                                                        <div class="form-group">
                                                            <label for="lblgender" style="text-align:left">Gender :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-4 text-left">
                                                <div class="form-group">
                                                <asp:Label ID="lblgender" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC"></asp:Label></div>
                                             </div>
                                                        </div>
                                                        </div>
                                                      </div>                                                 
                                                  
                                                  <div class="col-lg-12 mt-2">
                                                     <div class="form-group">
                                                          <div class="row">
                                                       <div class="col-lg-3 text-left" >
                                                        <div class="form-group">
                                                            <label for="lblMobileno" style="text-align:left">MobileNo :</label>  
                                                            </div>
                                                          </div>
                                                       <div class="col-lg-2 text-left"> 
                                                <div class="form-group">
                                               <asp:Label ID="lblMobileno" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC">

                                               </asp:Label>
                                                    </div>
                                                </div>
                                                          <div class="col-lg-3 text-left" >
                                                        <div class="form-group">
                                                            <label for="lblConDoc" style="text-align:left">Cons.Dr :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-4 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblConDoc" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC"></asp:Label>
                                               </div>
                                            </div>
                                                       
                                                      </div>
                                                      </div>
                                                         
                                                     </div>
                                                     
                                                  <div class="col-lg-12 mt-2">
                                                     
                                                    <div class="form-group">
                                                        <div class="row">
                                                       <div class="col-lg-3 text-left">
                                                        <div class="form-group">
                                                            <label for="lblBillNo" style="text-align:left">Bill No :</label>  
                                                            </div>
                                                          </div>
                                                       <div class="col-lg-2 text-left"> 
                                                <div class="form-group">
                                               <asp:Label ID="lblBillNo" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC">

                                               </asp:Label>
                                                    </div>
                                                </div>
                                                        <div class="col-lg-3 text-left">
                                                        <div class="form-group">
                                                            <label for="txtBillDate" style="text-align:left">Bill Date:</label>  
                                                            </div>
                                                          </div>
                                                       <div class="col-lg-4 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="txtBillDate" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="#3333CC"></asp:Label>
                                               </div>
                                            </div>
                                                   
                                                      </div>
                                                         </div>
                                                             </div>
                                                    <div class="row">
                                                         <div class="col-lg-6">
                                                             <div class="form-group">
                                                     <div class="table-responsive" style="width:550px">
                                                             <asp:GridView ID="gvBillTransaction" class="table table-responsive table-sm table-bordered" runat="server" AutoGenerateColumns="False" Width="100%"                                       
                                                              HeaderStyle-ForeColor="Black" ShowHeaderWhenEmpty="true"  AlternatingRowStyle-BackColor="White"   >
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PaymentDate" HeaderText="Transaction Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                        <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Paid" />
                                                                        <asp:BoundField DataField="ModeOfPaymentName" HeaderText="Mode Of Payment" />
                                            
                                                                        <asp:BoundField DataField="CreatedBy" HeaderText="Transcation User" />
                                                                    </Columns>
                                                             </asp:GridView>
                                                      </div>

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
                                                                 <label>Bill Amount</label>
                                                                         <div class="row">
                                                                                <div class="col-lg-2">
                                                                                      <span> <asp:Label ID="lblBillServiceCharges" runat="server" Font-Bold="True" ForeColor="Blue" Width="102px" Font-Size="X-Large"></asp:Label></span>
                                                                                </div>
                                                                             </div>
                                                        </div>
                                                 </div>
                                                 <div class="col-lg-4" >
                                                        <div  class="form-group">
                                                                 <label >Discount Amount</label>
                                                                         <div class="row">
                                                                                <div class="col-lg-2">
                                                                                      <span> <asp:Label ID="lblDiscAmt" runat="server" Text="" Font-Bold="true" ForeColor="Blue" Font-Size="X-Large" Width="120px">
                                                                                     </asp:Label></span>
                                                                                </div>
                                                                             </div>
                                                        </div>
                                                 </div>
                                                  <div class="col-lg-4">
                                    <div class="form-group">
                                        <label><asp:Label ID="lblAdvance" runat="server" Text="Advance Amount Paid:">
                        </asp:Label></label>
                                        <div class="row">
                                            <div class="col-lg-3 ">
                                                <span><asp:Label ID="lblAdvanceAmt" ForeColor="Green" Font-Bold="true" Font-Size="X-Large" runat="server"></asp:Label></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                                
                                                  <div class="col-lg-12">                                                     
                                                    <div class="form-group">
                                                          <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label>Discount Type *</label>
                                        
                                            <div class="row">
                                               
                                                     <div class="col-lg-12 text-left">
                                                          <div class="form-group">                 
                                                   <%-- <asp:RadioButtonList id="RadioButtonList2" runat="server" Width="150px"  
                                                            AutoPostBack="True" RepeatDirection="Horizontal" 
                                                         OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
                                                            <asp:ListItem >Percent(%)</asp:ListItem>
                                                            <asp:ListItem Selected="True">Amt</asp:ListItem>
                                                            </asp:RadioButtonList> --%>
                                                         <input id="rdbdiscAmt" type="radio" name="rdbDisc" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>
                <input id="rdbdiscPer" type="radio" runat="server" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
                                                              </div>
                                                         
                                                   
                                                </div>
                                                
                                            </div>
                                        </div>
                                    
                                    </div>
                                                         
                                <div class="col-lg-4" >
                                    <div class="form-group">
                                        <label>Discount</label>
                                        <div class="row">
                                            <div class="col-lg-12" >
                                                
                                                <asp:TextBox id="txtDiscnt" runat="server" class="form-control" 
                                                    OnTextChanged="txtDiscnt_TextChanged" AutoPostBack="True" ></asp:TextBox> 

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                                        <div class="col-lg-5 text-left">
                                                           <div class="form-group">  
                                                        <label> Disc Given By: </label>
                                                               <div class="row">
                                            <div class="col-lg-12">
                                                       
                                                               <asp:DropDownList ID="ddlDiscountGivenBy" runat="server" AutoPostBack="True" 
                                                     CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                </div>
                                                                   </div>
                                                               </div>
                                                            </div>
                                                               
                                </div>
                                                 </div>
                                            </div>

                                                  <div class="col-lg-12 mt-3">  
                                                      <div class="col-lg-12 text-left">
                                                                   <label> Payment By : </label>
                                                              </div>                                          
                                            <div class="row"> 
                                                    
                                                              
                                                    
                                                    <div class="col-lg-9 text-left" >

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbPayment"  runat="server" RepeatDirection="Horizontal" autoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>
                                                 <div class="col-lg-3 text-left" >
                                             <div class ="row">
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="PaymentInsurance" Text="Is Insurance" runat="server" AutoPostBack="true" OnCheckedChanged="PaymentInsurance_CheckedChanged"></asp:CheckBox></label>
                                            </div>
                                            </div>
                                                              
                                                 </div>
                                              </div> 
                                                                                               
                                                  <div id="PaymentDetails" runat="server">
                                                <div class="col-lg-12">                                            
                                            <div class="row"> 
                                                -
                                                </div>
                                                      </div> 
                                                       
                                                           <div class="form-group"> 
                                                               <div class="row">
                                                       <div class="col-lg-4 text-left" >
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"  placeholder="Card/Cheque No."
                                                     TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-4 text-left" >
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtBankName" runat="server"  class="form-control"   placeholder="Bank Name"
                                                     TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-4 text-left" runat="server" id="ChequeDate" >
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                             <input id="txtchequedate" class="form-control"  type="text" runat="server" autopostback="true" placeholder="dd/mm/yyyy" /> 
                                                        
                                                         <%-- <asp:TextBox ID="txtchequedate" runat="server" height="30px" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>--%>
                                                    <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                  </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                               </div>
                                                           </div>
                                                       
                                                       </div>

                                                 

                                                 <div class="col-lg-12">                                            
                                            
                                                 
                                        <div id="InsuranceDetails" runat="server">  
                                                 <div class="row">       
                                                       <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                        <label>InsuranceAmt: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2 text-left" >
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtInsuranceAmt" runat="server"  class="form-control"  AutoPostBack="True"
                                                      TabIndex="8" OnTextChanged="txtInsuranceAmt_TextChanged1"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-lg-2 text-left" >
                                                    <div class="form-group">                                                      
                                                        

                      <asp:RadioButtonList ID="rdblInsuranceAmt" runat="server" Width="110px" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdblInsuranceAmt_SelectedIndexChanged" >
                          <asp:ListItem Selected="True" Value="0">Amt</asp:ListItem>
                          <asp:ListItem Value="1">Per(%)</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                     </div>    
                                                        
                                                       <div class="col-lg-3 text-left" >
                                                           <div class="form-group">  
                                                        <label  >InsuranceComp: </label>
                                                               </div>
                                                        </div>
                                                       
                                                           <div class="col-lg-3 text-left">
                                                           <div class="form-group">  
                                                             <asp:DropDownList ID="ddlInsuranceCompName" runat="server" CssClass="form-control form-select" AutoPostBack="true" ></asp:DropDownList>
                                                                   
                                                        
                                                               </div>
                                                        </div>
                                                       
                                                            
                                                        </div>
                                               </div>
                                                     </div>
                                                  <div class="col-lg-12">                                            
                                            <div class="row"> 
                                                    

                                                 <div class="col-lg-6" >
                                    <div class="form-group">
                                        <label> <asp:Label ID="Label24" runat="server" Text="Amount Paid"></asp:Label></label>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                
                                                
<asp:TextBox id="txtAmtPaid" runat="server" class="form-control" placeholder="Amount Paid" Font-Size="X-Large" OnTextChanged="txtAmtPaid_TextChanged" AutoPostBack="True"></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label> <asp:Label ID="Label1" runat="server" Text="Balance"></asp:Label></label>

                                        <div class="row">
                                            <div class="col-lg-12">
                                               
                                                  <asp:TextBox id="txtBalance" runat="server"  Enabled="False"  Font-Size="Large" ></asp:TextBox> 
                                             
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                                </div>
                                                      </div>
                                                  <div class="col-lg-12 mt-2">                                            
                                            <div class="row"> 
                                                    
                                                   <div class="col-lg-6 text-left">
                                                           <div class="form-group">  
                                                        <label> BalanceReason: </label>
                                                     <div class="row">
                                                   <div class="col-lg-12 text-left">
                                                           <div class="form-group">  
                                                                               
                                                       
                                                               <asp:DropDownList ID="ddlBalreason" runat="server" AutoPostBack="True"  
                                                      CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                </div>
                                                      </div>
                                                       </div>

                                                <div class="col-lg-6 text-left">
                                                           <div class="form-group">  
                                                        <label> Discount Reason: </label>
                                                     <div class="row">
                                                   <div class="col-lg-12 text-left" >
                                                           <div class="form-group">  
                                                                               
                                                       
                                                               <asp:DropDownList ID="ddlDiscReason" runat="server" AutoPostBack="True"  
                                                      CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                </div>
                                                      </div>
                                                       </div>
                                                </div>
                                                      </div>
                                                 <div class="col-lg-12 mt-2">                                            
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
                        
                                
                                 <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                  
                                    <asp:Button ID="btnsave"  class="btn btn-primary" runat="server"  Text="Save Bill" OnClick="btnsave_Click"  />
                                   
                                    <asp:Button ID="btnreport" runat="server"  OnClick="btnreport_Click" onclientclick="target = '_blank';"
                                        Text=" Print" ToolTip="Print" class="btn btn-primary" />
                                    
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" 
                                        Text="Duplicate print" class="btn btn-primary" Visible="False" />
                                     <asp:HiddenField ID="hdfielddiscontFlag" runat="server" />
                        <asp:HiddenField ID="hdfielddiscont" runat="server" />
                        <asp:Label id="lblmsg" runat="server" SkinID="errmsg" Width="445px" Visible="False" Text="Amount should not greater than bill amount !!!"></asp:Label>
<asp:Label ID="Label12" runat="server" Text="Label" ForeColor="Green"  Width="445px" Visible="False" SkinID="errmsg"/>
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