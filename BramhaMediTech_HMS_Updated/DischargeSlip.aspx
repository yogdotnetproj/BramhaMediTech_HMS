<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DischargeSlip.aspx.cs" Inherits="DischargeSlip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <style type="text/css">
      input.larger {
        width: 80px;
        height: 80px;
      }
    </style>
    <style type="text/css">
  .BigCheckBox input {width:20px; height:20px;}
</style>
        <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
         <ContentTemplate>
            
                <section class="content-header d-flex">
                    <h1>Discharge Slip</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Discharge Slip</li>
                    </ol>
                </section>
           
               
                <section class="content">
                    <div class="box">
                                <div class="box-header with-border">
                           
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                </div>
                    
                                 <div class="box-body">
                           
                           
                                <div class="col-lg-12">
                                     <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:  

                                     </div>
                                        
                                             <%--<asp:Label ID="lblMessage1"  Font-Bold="true" ForeColor="White"  runat="server" Text=""></asp:Label>--%>
                                            <div class="form-group">
                                                     <div class="row">
                                                    <div class="col-lg-1 ">
                                                        <div class="form-group">
                                                            <label for="lblRegNo">Reg No :</label>  
                                                            </div>
                                                    </div>
                                                    <div class="col-lg-1"> 
                                                         <div class="form-group">
                                                             <asp:Label ID="lblRegNo" runat="server"  Font-Bold="True" >
                                                             </asp:Label>
                                                        </div>
                                                </div>
                                                    <div class="col-lg-1">
                                                        <div class="form-group">
                                                            <label for="lblPatName">Name :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-3 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblPatName" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                                         <div class="col-lg-1">
                                                        <div class="form-group">
                                                            <label for="lblPatName">RoomType :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-2 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblRoomType" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                                         <div class="col-lg-1">
                                                        <div class="form-group">
                                                            <label for="lblPatName">Discharge By :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-2 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblDischargeBy" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                              </div>
                                                             </div>
                                                  <div class="col-lg-12 mt-1">
                                                      
                                                       <div class="form-group">
                                                    
                                                          <div class="row">
                                                    <div class="col-lg-1 pr-0">
                                                        <div class="form-group">
                                                            <label for="lblIPDNo">IPD No :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-1">
                                                <div class="form-group">
                                                 <asp:Label ID="lblIPDNo" runat="server"  Font-Bold="True">

                                                 </asp:Label>
                                                    </div>
                                                </div>
                                                   <div class="col-lg-1">
                                                        <div class="form-group">
                                                            <label for="lblPatName">Dr Name :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-3 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lbldrname" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                                              <div class="col-lg-1">
                                                        <div class="form-group">
                                                            <label for="lblPatName">Admission date  :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-2 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lbladmisiondate" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                                               <div class="col-lg-1">
                                                        <div class="form-group">
                                                            <label for="lblPatName">Discharge date  :</label>  
                                                            </div>
                                                          </div>
                                                               <div class="col-lg-2 text-left">
                                                 <div class="form-group">
                                                 <asp:Label ID="lbldischargedate" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                                       </div>
                                                        </div>
                                                      </div>  
                                                     
                                                 
                                                          <div style="height:2px; background:#B24592;"> </div>
                                                                                           
                                         <div class="col-lg-12 mt-1">                                                      
                                                       <div class="form-group">                                                    
                                                          <div class="row">
                                                    <div class="col-lg-12 text-left">
                                                        <div class="form-group">
                                                            <asp:Label ID="Label1" runat="server"  Font-Bold="True" Font-Underline="true" Text="The Following SERVICES Have Been Rendered To Patient During Hospitalization.(Please Tick)"></asp:Label>
                                                            </div>
                                                        </div>
                                                              </div>
                                                           </div>
                                             </div>
                                                  
                                                   <div class="col-lg-12 mt-2">                                                      
                                                       <div class="form-group">                                                    
                                                          <div class="row">
                                                    <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="chkXray" runat="server" Text="X-Rays" />
                                                            </div>
                                                        </div>
                                                                <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="Chkor" runat="server" Text="O.R" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="Chkdrugs" runat="server" Text="Drugs" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkECG" runat="server" Text="ECG" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="Chkcsr" runat="server" Text="CSR" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkLab" runat="server" Text="LAB" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="Chkroom" runat="server" Text="S\Room" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkRBS" runat="server" Text="RBS" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkOXYGEN" runat="server" Text="OXYGEN" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-2 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkNEBULIZER" runat="server" Text="NEBULIZER" />
                                                            </div>
                                                        </div>
                                                              </div>
                                                           </div>
                                                       </div>     
                   
                                            <div class="col-lg-12 mt-1">                                                      
                                                       <div class="form-group">                                                    
                                                          <div class="row">
                                                    <div class="col-lg-12 text-left">
                                                        <div class="form-group">
                                                            <asp:Label ID="Label2" runat="server"  Font-Bold="True" Font-Underline="true" Text="The Following SERVICES Have Been Rendered To Patient Before Leaving Hospital.(Please Tick)"></asp:Label>
                                                            </div>
                                                        </div>
                                                              </div>
                                                           </div>
                                             </div>
                                     <div class="col-lg-12 mt-2">                                                      
                                                       <div class="form-group">                                                    
                                                          <div class="row">
                                                    <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkxRayB" runat="server" Text="X-Rays" />
                                                            </div>
                                                        </div>
                                                                <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkORB" runat="server" Text="O.R" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkDrugsB" runat="server" Text="Drugs" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkECGB" runat="server" Text="ECG" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkCSRB" runat="server" Text="CSR" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkLABB" runat="server" Text="LAB" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkRoomB" runat="server" Text="S\Room" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkRBSB" runat="server" Text="RBS" />
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkOXYGENB" runat="server" Text="OXYGEN" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-2 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="ChkNEBULIZERB" runat="server" Text="NEBULIZER" />
                                                            </div>
                                                        </div>
                                                              </div>
                                                           </div>
                                                       </div>     
                                                     
                                             <div class="col-lg-12 mt-1">                                                      
                                                       <div class="form-group">                                                    
                                                          <div class="row">
                                                    <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:Label ID="Label3" runat="server"  Font-Bold="True" Font-Underline="true" Text="Remark"></asp:Label>
                                                            </div>
                                                        </div>
                                                              <div class="col-lg-10 text-left">
                                                        <div class="form-group">
                                                <asp:TextBox ID="txtremarks" runat="server" AutoCompleteType="None"  TextMode="MultiLine" CssClass="form-control" placeholder="Enter Remarks"></asp:TextBox>

                                                            </div>
                                                                  </div>
                                                              </div>
                                                           </div>
                                             </div>
                                     <div class="col-lg-12 mt-3">                                                      
                                                       <div class="form-group">                                                    
                                                          <div class="row">
                                                    <div class="col-lg-1 text-left">
                                                        <div class="form-group">
                                                            <asp:Label ID="Label4" runat="server"  Font-Bold="True" Font-Underline="true" Text=""></asp:Label>
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-2 text-left">
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="chkFinanceApprove" CssClass="BigCheckBox" ForeColor="Red" Font-Bold="true" Enabled="false" AutoPostBack="true" runat="server" Text="Finance Approve" OnCheckedChanged="chkFinanceApprove_CheckedChanged" />
                                                            </div>
                                                        </div>
                                                               <div class="col-lg-4 text-left">
                                                        <div class="form-group">
                                                             <asp:Label ID="lblfinance" runat="server"  Font-Bold="True" Font-Underline="true" Text=""></asp:Label>
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
                                  
                                    <asp:Button ID="btnsave"  class="btn btn-success" runat="server"  Text="Save"  OnClick="btnsave_Click"  />
                                   
                                    <asp:Button ID="btnreport" runat="server"  OnClick="btnreport_Click" 
                                        Text=" Print" ToolTip="Print" class="btn btn-primary" />
                                    
                                   
                                    
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
