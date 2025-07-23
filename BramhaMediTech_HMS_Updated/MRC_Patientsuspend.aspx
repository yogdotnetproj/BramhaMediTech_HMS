<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="MRC_Patientsuspend.aspx.cs" Inherits="MRC_Patientsuspend" %>

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
                    <h1>MRC Patient Status</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">MRC Patient Status</li>
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
                                        <div class="col-lg-12">                                             
                                                 <div class="form-group">
                                                     <div class="row">
                                                    <div class="col-lg-1 pr-0">
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
                                                          <div class="col-lg-1 pr-0">
                                                        <div class="form-group">
                                                            <label for="lblRegNo">IPD No :</label>  
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
                                                            <label for="lblPatName">Name :</label>  
                                                            </div>
                                                          </div>
                                                    <div class="col-lg-6">
                                                 <div class="form-group">
                                                 <asp:Label ID="lblPatName" runat="server"  Font-Bold="True"></asp:Label>
                                               </div>
                                            </div>
                                              
                                                 
                                                     
                                               
                                                         
                                                                                             
                                         
                                                  
                                                       
                   
                                           
                                                        </div>
                                                             </div>
                                             </div>                                        
                                    


                                                 <div style="height:2px; background:#B24592;"> </div>
                                    
                                                <div class="col-lg-12 mt-3">                                             
                                                 <div class="form-group">
                                                     <div class="row">
                                                    <div class="col-lg-2 pr-0">
                                                        <div class="form-group">
                                                           <asp:Label runat="server" ID="lblPatType"></asp:Label>
                                                            </div>
                                                    </div>
                                                           <div class="col-lg-4 pr-0">
                                                        <div class="form-group">
                                                            <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine"  class="form-control"   placeholder="Remark"
                                                     TabIndex="8"></asp:TextBox>
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
                                <div class="col-lg-10 text-center">
                                  
                                    <asp:Button ID="btnsave"  class="btn btn-success" runat="server"  Text="Save Bill" OnClick="btnsave_Click"  />
                                   
                                    <asp:Button ID="btnreport" runat="server" Visible="false"  OnClick="btnreport_Click" onclientclick="target = '_blank';"
                                        Text=" Print" ToolTip="Print" class="btn btn-primary" />
                                    
                                     <asp:Button ID="btnIPDBill" runat="server"  
                                        Text=" IPD Bill" ToolTip="IPD BILL" Visible="false" class="btn btn-warning" OnClick="btnIPDBill_Click" />
                                    
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
