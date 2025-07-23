<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IpdRefundPayment.aspx.cs" Inherits="IpdRefundPayment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
         <ContentTemplate>
            
                <section class="content-header d-flex">
                    <h1>Ipd Refund Receipt</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Ipd  Refund Receipt</li>
                    </ol>
                </section>
           
               
                <section class="content">
                    <div class="box">
                               <!--  <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                  
                          
                                </div>-->
                        <div class="box-header with-border">
                         <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:   <asp:Label  ID="Label11"  Font-Bold="true" ForeColor="White"  runat="server" Text=""></asp:Label> </div>
                            <div class="col-lg-12 text-left">
                                 <div class="row">

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPrnNo" runat="server" Font-Bold="true" Text="Reg ID:" ></asp:Label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPat" runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label ID="lblI"  runat="server" Font-Bold="true" Text="IPD NO:"></asp:Label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblBio" runat="server" Font-Bold="true" Text="Bill NO:"></asp:Label>
                                        <asp:Label ID="lblBillNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="hhhd" runat="server" Font-Bold="true" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                        
                            <div class="col-lg-12 mt-3">
                                 <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server" Font-Bold="true" Text="Patient Category:"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true" Text="Admission Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div3" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Font-Bold="true" Text="DR Name :"></asp:Label>
                                        <asp:Label ID="lbldrname" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="lblBi" runat="server" Font-Bold="true" Text="Room Type:" ></asp:label>
                                        <asp:Label ID="LblRoomType" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server" Font-Bold="true" Text="Bed Name:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>

                         
                            <div class="col-lg-12 mt-3">
                                <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server" Font-Bold="true" Text="Diagnosis:"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server" Font-Bold="true" Text="Procedure:"> </asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div4" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="Label5"   runat="server" Font-Bold="true" Text="Sponsor :"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="Label7" runat="server" Font-Bold="true" Text="Sponsor1:" ></asp:label>
                                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="Label9" runat="server" Font-Bold="true"  Text=""></asp:label>
                                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                                   
                    </div>
                        <div style="height:2px; background:#B24592;"> </div>
                                 <div class="box-body">
                           
                           
                                <div class="col-lg-12">
                                     <div class="row">
                                        <div class="form-group">
                                        
                                                 <%--   <div class="col-lg-1 text-left" style="width:100px" >
                                                        <div class="form-group">
                                                            <label for="lblRegNo" style="text-align:left">Reg No :</label>  
                                                            </div>
                                                    </div>
                                                    <div class="col-lg-1 text-left" style="width:110px"> 
                                                         <div class="form-group">
                                                             <asp:Label ID="lblRegNo" runat="server"  Font-Bold="True" Width="100px" Font-Size="Medium" ForeColor="#3333CC">
                                                             </asp:Label>
                                                        </div>
                                                </div>
                                                    <div class="col-lg-1 text-left" style="width:100px" >
                                                        <div class="form-group">
                                                            <label for="lblPatName" style="text-align:left">Name :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-1 text-left" style="width:210px">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblPatName" runat="server"  Font-Bold="True" Width="200px" Font-Size="Medium" ForeColor="#3333CC"></asp:Label>
                                               </div>
                                            </div>                                             
                                                        
                                                    <div class="col-lg-1 text-left" style="width:100px" >
                                                        <div class="form-group">
                                                            <label for="lblIPDNo" style="text-align:left">IPD No :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-1 text-left" style="width:110px">
                                                <div class="form-group">
                                                 <asp:Label ID="lblIPDNo" runat="server"  Font-Bold="True" Width="100px" Font-Size="Medium" ForeColor="#3333CC">

                                                 </asp:Label>
                                                    </div>
                                                </div>--%>
                                                   

                                                      
                                                     
                                                                                                
                                         
                                                    
                                                    

                                        <div class="col-lg-12">
                                           
                                             <div class="form-group">
                                                 <div class="row"> 
                                                  <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <label for="lblBillServiceCharges">Bill Amount:</label>  
                                                            </div>
                                                    </div>
                                                  <div class="col-lg-2">
                                                        <div class="form-group">                                                                
                                                            <span> <asp:Label ID="lblBillServiceCharges" runat="server" Font-Bold="True"></asp:Label></span>
                                                        </div>                                                                            
                                                 </div>                                                
                                                  <div class="col-lg-2">
                                                         <div class="form-group">
                                                              <label for="lblAdvanceAmt">Advance Amount:</label>
                                                             </div>
                                                      </div>                                        
                                                  <div class="col-lg-2">
                                                <div class="form-group">
                                                <span><asp:Label ID="lblAdvanceAmt" Font-Bold="true" runat="server"></asp:Label></span>
                                            </div> 
                                          </div>
                                
                                                  <div class="col-lg-12 mt-3">
                                                                                                            
                                                 
                                                         <div class="form-group">
                                                             <div class="row"> 
                                                         <div class="col-lg-2" >
                                                        <div  class="form-group">
                                                                 <label >Discount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblDiscAmt" runat="server" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>
                                                          <div class="col-lg-2">
                                                        <div  class="form-group">
                                                                 <label >Insurance Amount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblInsurance" runat="server" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>

                                                         </div>
                                                     </div>
                                              </div>
                                                
                                                
                                                  <div class="col-lg-12 mt-3">                                            
                                            <div class="row"> 
                                                    
                                                              <div class="col-lg-2">
                                                                   <label> Payment By : </label>
                                                              
                                                    </div>
                                                    <div class="col-lg-6 text-left">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" autoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>
                                                 
                                                             
                                                 </div>
                                              </div> 
                                                                                               
                                                  <div id="PaymentDetails" runat="server">
                                                
                                                       <div class="col-lg-12">
                                                           <div class="form-group">
                                                               <div class="row"> 
                                                       <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  CssClass="form-control" placeholder="Card/Cheque No." TabIndex="8"></asp:TextBox>
                                                </div>
                                                        </div>
                                                       <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtBankName" runat="server"  CssClass="form-control"  placeholder="Bank Name"
                                                     TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2 text-left" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                             <input id="txtchequedate" class="form-control"  type="text" runat="server" autopostback="true" placeholder="dd/mm/yyyy" /> 
                                                        
                                                         <%-- <asp:TextBox ID="txtchequedate" runat="server" height="30px" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>--%>
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

                                                 

                                                
                                                  <div class="col-lg-12">                                            
                                            <div class="row"> 
                                                    

                                                 <div class="col-lg-3">
                                                    <div class="form-group">
                                                             <label>Refund Amount</label>
                                                                 <div class="row">
                                                                         <div class="col-lg-3"> 
                                                                            <asp:TextBox id="txtRefundAmt" runat="server" Enabled="false" class="form-control" Width="200px" placeholder="Amount Paid" Font-Size="X-Large" OnTextChanged="txtAmtPaid_TextChanged" AutoPostBack="True"></asp:TextBox> 
                                                                        </div>
                                                                     </div>
                                                            </div>
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="chkDeposite" Text="Transfer To Deposit" ForeColor="Red" runat="server" AutoPostBack="true" ></asp:CheckBox></label>
                                                         <asp:Label ID="lblDepositAmt" ForeColor="Red" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                           
                                       
                                    
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Remark</label>

                                        <div class="row">
                                            <div class="col-lg-3">
                                               
                                                   <textarea  runat="server" style="height:70px;width:200px" id="txtRemark" cols="1"  rows="1"></textarea>        
                                                       
                                            </div>
                                        </div>
                                    </div>
                                    <asp:CheckBox ID="chkiscancel" Text="Bill Cancel" ForeColor="Blue" Visible="false" runat="server" AutoPostBack="true" OnCheckedChanged="chkiscancel_CheckedChanged" ></asp:CheckBox>
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
                                     <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                   
                                    
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

