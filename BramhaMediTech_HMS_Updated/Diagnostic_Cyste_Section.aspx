<%@ Page Title="" Language="C#" MasterPageFile="~/OT_mainMaster.master" AutoEventWireup="true" CodeFile="Diagnostic_Cyste_Section.aspx.cs" Inherits="Diagnostic_Cyste_Section" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert p-2 in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(1000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 500);//5000=5 seconds
        }
    </script>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>


     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />       
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Diagnostic Hystero Laparoscopy</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Diagnostic Hystero Laparoscopy</li>
                    </ol>                
                </section>
             <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                                    <div class="row">    
                  <div class="col-lg-12 mt-3">
                            <div class="row">  
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Note Time</strong></label> 
                                                </div>
                                              </div>   
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtNoteDate" runat="server"   CssClass="form-control" TabIndex="7" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                </div>
                                    </div>
                                
                                 <div class="col-sm-3 text-center" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Schedule </strong></label> 
                                                </div>
                                              </div> 
                                <div class="col-sm-3" >
                                            <div class="form-group">
                                               <asp:TextBox ID="txtschedule" CssClass="form-control"  runat="server" placeholder="" ></asp:TextBox>
                                      
                                                </div>
                                              </div> 
                                </div>
                      </div>

                                        <div class="col-lg-12 mt-3">
                            <div class="row">
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Date Of Operation </strong></label> 
                                                </div>
                                              </div> 
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                               <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdateofoperation" runat="server"   CssClass="form-control" TabIndex="7" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                </div>
                                              </div> 
                                 <div class="col-sm-3 text-center" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Operative Procedure </strong></label> 
                                                </div>
                                              </div> 
                                <div class="col-sm-3 " >
                                            <div class="form-group">
                                               <asp:TextBox ID="txtoperativeProcedure" CssClass="form-control"  runat="server" placeholder="" ></asp:TextBox>
                                      
                                                </div>
                                              </div> 
                                </div>
                                            </div>
                                        <div class="col-lg-12 mt-2">
                            <div class="row">
                                         <div style="height:2px; background:#B24592;"> </div>
                                </div>
                                            </div>
                 <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Pre-Operative Diagnosis</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtpreOperativeDiagnosis" CssClass="form-control"  runat="server" placeholder="Enter Pre-Operative Diagnosis" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Anaesthetist</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtAnaesthetist" CssClass="form-control"  runat="server" placeholder="Enter Anaesthetist" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Duration of Surgery</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtdurationofsurgery" CssClass="form-control"  runat="server" placeholder="Enter Duration of Surgery" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Post Operative Diagnosis</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtpostoperativediagnosis" CssClass="form-control"  runat="server" placeholder="Enter Post Operative Diagnosis" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                          <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Post Operative Anaesthetist</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtpostoperativeAnaesthetist" CssClass="form-control"  runat="server" placeholder="Enter Post Operative Anaesthetist" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Tourniquet Time</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtTourniquetTime" CssClass="form-control"  runat="server" placeholder="Enter Tourniquet Time" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>
                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Swab/Pack/Instrument Count</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtswabcount" CssClass="form-control"  runat="server" placeholder="Enter Swab/Pack/Instrument Count" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Surgeon</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtSurgeon" CssClass="form-control"  runat="server" placeholder="Enter Surgeon" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Inflate</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtInflate" CssClass="form-control"  runat="server" placeholder="Enter Inflate" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Material/Specimen Forwarded for Pathology</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtmaterialforwarded" CssClass="form-control"  runat="server" placeholder="Enter Material/Specimen Forwarded for Pathology" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>
                                            <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Scrub Nurse</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtScrubNurse" CssClass="form-control"  runat="server" placeholder="Enter Scrub Nurse" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Deflate</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtDeflate" CssClass="form-control"  runat="server" placeholder="Enter Deflate" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Operation Findings</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtoperationFinding" CssClass="form-control"  runat="server" placeholder="Enter Operation Findings" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Blood Loss in ml</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtbloodloss" CssClass="form-control"  runat="server" placeholder="Enter Blood Loss in ml" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Drains</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:DropDownList ID="ddlDrains"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           
                                         
                                        </asp:DropDownList>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                        
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       
                                      </div>
                                </div>
                             
                                </div>
                     </div>
<div class="col-lg-12 mt-2" id="longprotocol3" runat="server">

                    <div class="row">
                        <div class="panel-heading">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <strong>DIAGNOSTIC HYSTERO-LAPAROSCOPY</strong>
                                        </div>
                                </div>
                        </div>

                    </div>
                           </div>

                                        <div class="row">
                                             <div class="col-lg-4  text-left">
                                                 <strong>Hysteroscopy |-</strong>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="ChkHysteroscopy" Text="Hysteroscopy Normal" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-6" >
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlHysteroscopy"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                                     <asp:ListItem Value="">Bilateral Ostia Seen</asp:ListItem>
                                                     <asp:ListItem Value="">Single Ostium Seen</asp:ListItem>
                                                    <asp:ListItem Value="">Neither Ostium Seen</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>

                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="ChkAdhesions" Text="Adhesions" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                  <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chksubmucous" Text="Submucous Fibroids" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="ChkIntervation" Text="Any Intervation" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:TextBox ID="txtcomments" CssClass="form-control" TextMode="MultiLine" Height="70px"  runat="server" placeholder="Comments" ></asp:TextBox>
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>

                                                 </div>

                                             <div class="col-lg-4  text-left">
                                                 <strong>Laparoscopy |-</strong>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkPelvicAnatomy" Text="Pelvic Anatomy Normal" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkFibroids" Text="Fibroids" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>

                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-6" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkTubePatent" Text="Tube Patent" />
                                                </div>
                                    </div>
                                         <div class="col-sm-6" >
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlTubePlates"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                                     <asp:ListItem Value="Both">Both</asp:ListItem>
                                                     <asp:ListItem Value="Left">Left</asp:ListItem>
                                                     <asp:ListItem Value="Right">Right</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                    </div>

                                                      </div>
                                                     </div>
                                                  <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="ChkTubalAnatomyNormal" Text="Tubal Anatomy Normal" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                 
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                .
                                                </div>
                                    </div>
                                                          </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:TextBox ID="txtLaparoscopy" CssClass="form-control" TextMode="MultiLine" Height="70px"  runat="server" placeholder="Comments" ></asp:TextBox>
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>

                                                 </div>
                                             
                                            <div class="col-lg-4  text-left">
                                                 <strong>Ovaries |-</strong>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkOvariesNormal" Text="Ovaries Normal" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkPCO" Text="PCO" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>

                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkCyst" Text="Cyst" />
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>
                                                  <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-6" >
                                            <div class="form-group">
                                                <asp:CheckBox runat="server" ID="chkDrilling" Text="Drilling" />
                                                </div>
                                    </div>
                                         <div class="col-sm-6" >
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlDrilling"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                                     <asp:ListItem Value="Both">Both</asp:ListItem>
                                                     <asp:ListItem Value="Left">Left</asp:ListItem>
                                                     <asp:ListItem Value="Right">Right</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                    </div>

                                                      </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                 <asp:CheckBox runat="server" ID="chkEndometriosis" Text="Endometriosis" />
                                                </div>
                                    </div>
                                                          </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                                <asp:TextBox ID="txtOvariescomments" CssClass="form-control" TextMode="MultiLine" Height="70px"  runat="server" placeholder="Comments" ></asp:TextBox>
                                                </div>
                                    </div>
                                        

                                                      </div>
                                                     </div>

                                                 </div>
                                            </div>
                

                  
                   <div class="messagealert" id="alert_container">
            </div>
                                        </div>
                     </div>
                     </div>
                 <div class="col-lg-12 mt-3">
                 <div class="row">                
                    <div class="col-lg-12 mt-3 text-center">
                         <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnSave_Click" 
                                        TabIndex="12" Width="80px" CssClass="btn btn-success"   CausesValidation="False"   UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" />
                                      <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary"   CausesValidation="False"   UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" OnClick="btnPrint_Click" />               
                        </div>
                     </div>
                     </div>
                 </section>
             <script language="javascript" type="text/javascript">
                 function OpenReport() {

                     window.open("Reports.aspx");
                 }
               </script>
            </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

