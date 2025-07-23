<%@ Page Title="" Language="C#" MasterPageFile="~/Opthalmology.master" AutoEventWireup="true" CodeFile="New_Opthalmology_Clinic.aspx.cs" Inherits="New_Opthalmology_Clinic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
          
          

        </Triggers>
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                    <h1>Doctor Assessment</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Doctor Assessment</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">  
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Date</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEntryDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                                                             
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Doctor</strong>
                                        
                                    </div>
                                </div>
                                      <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                   <asp:TextBox ID="txtdrname"  placeholder="Enter DrName" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>  
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Diagnosis</strong>
                                        
                                    </div>
                                </div>      
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                   <asp:TextBox ID="txtDiagnosis" placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>   
                        </div>
                     </div>

                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Chief Complaints:</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Past History(Medical/Ocular/Surgical/Refractive)</strong></br>
                                        [DM,HTN,CAD,Asthma,SSD,Lipid,Glauc,Thyroid,Immune,Pregnancy]
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                         
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                   <asp:TextBox ID="txtchiefComplaints" TextMode="MultiLine" placeholder="Enter ChiefComplaints" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     
                                       <asp:TextBox ID="txtOcularHistory" TextMode="MultiLine" placeholder="Enter Past History" CssClass="form-control"   runat="server" /> 
                                    </div>
                                </div>
                                                
                        </div>
                     </div>
                         
                         
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Clinical Note</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Current Medications</strong>
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtClinicalNote" TextMode="MultiLine" placeholder="Enter Clinical Note" CssClass="form-control"   runat="server" /> 
                                        
                                    </div>
                                </div> 
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txttreatmentHistory" placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                     
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">

                                        </div>
                            </div>
                        </div>
                             </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Allergy </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         

                           
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                      
                                         <asp:TextBox ID="txtAllergys" TextMode="MultiLine" placeholder="Enter Allergy" CssClass="form-control"   runat="server" /> 
                                        </div>
                            </div>
                            
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                        
                                        </div>
                            </div>
                        </div>
                              </div>
                          
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                      <strong>  OPTOMETRIC EVALUATION</strong>
                                        </div>
                            </div>
                        </div>
                              </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                 <table runat="server" style="width:100%">
                                     <tr >
                                         <td>
                                             Visual Acuity
                                         </td>
                                          <td colspan="2">
                                              Distance Vision
                                         </td>
                                          <td colspan="2">
                                              Near Vision
                                         </td>
                                     </tr>
                                     <tr >
                                         <td>
                                             
                                         </td>
                                          <td style="text-align: center;">
                                              OD
                                         </td>
                                          <td style="text-align: center;">
                                              OS
                                         </td>
                                          <td style="text-align: center;">
                                              OD
                                         </td>
                                          <td style="text-align: center;">
                                              OS
                                         </td>
                                     </tr>
                                      <tr >
                                         <td>
                                            Unaided 
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtUnaidedODD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtUnaidedOSD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtUnaidedODN" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtUnaidedOSN" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                     </tr>
                                      <tr >
                                         <td>
                                            Pinhole 
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtPinholeODD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtPinholeOSD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                              
                                         </td>
                                          <td>
                                              
                                         </td>
                                     </tr>
                                      <tr >
                                         <td>
                                            With Spectacles 
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtSpectaclesODD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtSpectaclesOSD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                              <asp:TextBox ID="txtSpectaclesODN" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                              <asp:TextBox ID="txtSpectaclesOSN" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                     </tr>
                                     <tr >
                                         <td>
                                           IOP
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtIOPODD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtIOPOSD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td colspan="2" style="text-align: center;">
                                              <strong>NPC</strong>
                                         </td>
                                         
                                     </tr>
                                      <tr >
                                         <td>
                                           Pachymetry
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtPachymetryODD" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td>
                                               <asp:TextBox ID="txtPachymetryODS" placeholder=""  CssClass="form-control"   runat="server" />
                                         </td>
                                          <td colspan="2" >
                                             <asp:TextBox ID="txtNPC" placeholder=""  CssClass="form-control"   runat="server" />

                                         </td>
                                         
                                     </tr>
                                 </table>
                            </div>
                         <div class="col-lg-6 text-left">
                                  <table id="Table1" runat="server" style="width:100%">
                                     <tr >
                                         <td  colspan="7">
                                             Keratometry
                                         </td>
                                         
                                     </tr>
                                       <tr >
                                         <td  colspan="4">
                                             RIGHT EYE (OD)
                                         </td>
                                         <td  colspan="3">
                                             LEFT EYE (OS)
                                         </td>
                                     </tr>
                                       <tr >
                                           <td></td>
                                           <td style="text-align: center;">mm</td>
                                           <td style="text-align: center;">D</td>
                                           <td style="text-align: center;">Deg</td>
                                          <td style="text-align: center;">mm</td>
                                           <td style="text-align: center;">D</td>
                                           <td style="text-align: center;">Deg</td>
                                           </tr>
                                       <tr >
                                           <td>R1</td>
                                           <td> <asp:TextBox ID="txtR1R" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR1DR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR1DegR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                          <td><asp:TextBox ID="txtR1L" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR1DL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR1DegL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           </tr>
                                       <tr >
                                           <td>R2</td>
                                           <td> <asp:TextBox ID="txtR2mmR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR2DR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR2DegR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                          <td><asp:TextBox ID="txtR2L" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR2DL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtR2DegL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           </tr>
                                       <tr >
                                           <td>AVG</td>
                                           <td> <asp:TextBox ID="txtAVGmmR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtAVGDR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtAVGDegR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                          <td><asp:TextBox ID="txtAVGmmL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtAVGDL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtAVGDegL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           </tr>
                                       <tr >
                                           <td>CYL</td>
                                           <td> <asp:TextBox ID="txtCYLMMR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtCYLDR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtCYLDegR" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                          <td><asp:TextBox ID="txtCYLmmL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtCYLDL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td><asp:TextBox ID="txtCYLDegL" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           </tr>
                                       <tr >
                                           <td colspan="4" style="text-align: right;">PD</td>
                                           <td> <asp:TextBox ID="txtPD" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           <td style="text-align: center;">N</td>
                                           <td ><asp:TextBox ID="txtN" placeholder=""  CssClass="form-control"   runat="server" /></td>
                                           
                                           </tr>
                                      </table>
                            </div>
                        </div>
                              </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6  text-left">
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Colour Vision(Ishihara) </strong>
                                        
                                    </div>
                                </div>
                        
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        OD
                                        </div>
                              </div>

                           
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                      
                                         <asp:TextBox ID="txtcolorOD"  CssClass="form-control"   runat="server" /> 
                                        </div>
                            </div>
                             <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        OS
                                        </div>
                              </div>

                           
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                      
                                         <asp:TextBox ID="txtcolorOS"  CssClass="form-control"   runat="server" /> 
                                        </div>
                            </div>
                       
                        </div>
                              </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Cover-Uncover Test </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                             </div>
                           
                        <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                      
                                         <asp:TextBox ID="txtcoveruncover"  CssClass="form-control"   runat="server" /> 
                                        </div>
                            </div>
                            

                           
                       
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                        
                                        </div>
                            </div>
                        </div>
                              </div>

                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                        </div>
                             </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                        </div>
                             </div>
                        </div>
                             </div>
                             </div>
                        <div class="col-lg-6  text-left">
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">

                                        <table id="Table2" runat="server" style="width:100%">
                                    
                                       <tr >
                                           <td style="text-align: center;" >
                                             BIOMETRY
                                         </td>
                                         <td style="text-align: center;" >
                                             OD
                                         </td>
                                         <td style="text-align: center;" >
                                             OS
                                         </td>
                                     </tr>
                                       <tr >
                                           <td>Axial Length</td>
                                           <td > <asp:TextBox ID="txtAxialLengthOD"  CssClass="form-control"   runat="server" /> </td>
                                           <td > <asp:TextBox ID="txtAxialLengthOS"  CssClass="form-control"   runat="server" /> </td>
                                          
                                           </tr>
                                             <tr >
                                           <td>A Constant</td>
                                           <td > <asp:TextBox ID="txtAConstantOD"  CssClass="form-control"   runat="server" /> </td>
                                           <td > <asp:TextBox ID="txtAConstantOS"  CssClass="form-control"   runat="server" /> </td>
                                          
                                           </tr>
                                             <tr >
                                           <td>IOL Power</td>
                                           <td > <asp:TextBox ID="txtiolPowerOD"  CssClass="form-control"   runat="server" /> </td>
                                           <td > <asp:TextBox ID="txtiolPowerOS"  CssClass="form-control"   runat="server" /> </td>
                                          
                                           </tr>
                                             <tr >
                                           <td>Predictive Refr</td>
                                           <td > <asp:TextBox ID="txtPredictiveOD"  CssClass="form-control"   runat="server" /> </td>
                                           <td > <asp:TextBox ID="txtPredictiveOS"  CssClass="form-control"   runat="server" /> </td>
                                          
                                           </tr>
                                        </table>
                                        </div>
                             </div>
                        </div>
                            </div>
                        </div>
                              </div>

                              </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                      <strong> RIGHT EYE(OD) </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group">
                                       
                                      <strong> LEFT EYE(OS) </strong>
                                        
                                    </div>
                                </div>
                        </div>
                             </div>

                           <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                      <strong> 1.Current Spactacles Prescription </strong>
                                        
                                    </div>
                                </div>
                       
                        </div>
                             </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtSPHRightCSP"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             CYL
                                    <div class="form-group">
                                       <asp:TextBox ID="txtCYLRightCSP"  CssClass="form-control"   runat="server" />
                                     
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             AXIS
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAXISRightCSP"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                        
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                         <asp:TextBox ID="txtSPHLeftCSP"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                            CYL
                                    <div class="form-group">
                                         <asp:TextBox ID="txtCYLLeftCSP"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">AXIS
                                    <div class="form-group">
                                         <asp:TextBox ID="txtAXISLeftCSP"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             ADD
                                    <div class="form-group">
                                         <asp:TextBox ID="txtAddCSP"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>

                        </div>
                             </div>


                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                      <strong> 2.Autorefraction </strong>
                                        
                                    </div>
                                </div>
                       
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtSPHRightAuto"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             CYL
                                    <div class="form-group">
                                       <asp:TextBox ID="txtCYLRightAuto"  CssClass="form-control"   runat="server" />
                                     
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             AXIS
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAXISRightAuto"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                        
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                         <asp:TextBox ID="txtSPHLeftAuto"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                            CYL
                                    <div class="form-group">
                                         <asp:TextBox ID="txtCYLLeftAuto"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">AXIS
                                    <div class="form-group">
                                         <asp:TextBox ID="txtAXISLeftAuto"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             
                                    <div class="form-group">
                                         
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>

                        </div>
                             </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                       
                                      <strong> 3.Mainfest Refraction (Final Prescription) </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong>  NEAR VA</strong>
                                        </div>
                            </div>
                       
                        </div>
                             </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtSPHMRRight"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             CYL
                                    <div class="form-group">
                                       <asp:TextBox ID="txtCYLMRRight"  CssClass="form-control"   runat="server" />
                                     
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             AXIS
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAXISMRRight"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                            VA
                                    <div class="form-group">
                                         <asp:TextBox ID="txtVAMRRight"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                         <asp:TextBox ID="txtSPHMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                            CYL
                                    <div class="form-group">
                                         <asp:TextBox ID="txtCYLMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">AXIS
                                    <div class="form-group">
                                         <asp:TextBox ID="txtAXISMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             VA
                                    <div class="form-group">
                                         <asp:TextBox ID="txtVAMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">ADD
                                    <div class="form-group">
                                        <asp:TextBox ID="txtAddMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">OD
                                    <div class="form-group">
                                        <asp:TextBox ID="txtODMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">OS
                                    <div class="form-group">
                                          <asp:TextBox ID="txtOSMRLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>

                        </div>
                             </div>


                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                      <strong> 4.Cyclo Refraction(Dilated) </strong>
                                        
                                    </div>
                                </div>
                       
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtSPHCRDRight"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             CYL
                                    <div class="form-group">
                                       <asp:TextBox ID="txtCYLCRDRight"  CssClass="form-control"   runat="server" />
                                     
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                             AXIS
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAXISCRDRight"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                        
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             SPH
                                    <div class="form-group">
                                         <asp:TextBox ID="txtSPHCRDLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                            CYL
                                    <div class="form-group">
                                         <asp:TextBox ID="txtCYLCRDLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">AXIS
                                    <div class="form-group">
                                         <asp:TextBox ID="txtAXISCRDLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             ADD
                                    <div class="form-group">
                                          <asp:TextBox ID="txtADDCRDLeft"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                             Medication Used
                                    <div class="form-group">
                                        <asp:TextBox ID="txtMedicationused"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         

                        </div>
                             </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Retinoscopy </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-8 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtRetinoscopy"  CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                       
                        </div>
                             </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                       
                                      <strong> OPHTHALMIC EXAMINATION: </strong>
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <strong> RIGHT EYE(OD) </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                        </div>
                            </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <strong> LEFT EYE(OD) </strong>
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtADNEXARight" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                     ADNEXA</br>
                                        Orbit,Lids,Lacrimal,EOM
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtADNEXALeft" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>
                             </div>

                            <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtANTERIORSEGMENTRight" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                     ANTERIOR SEGMENT</br>
                                        Conjunctiva,Cornea,AC Iris,Pupil,Lens
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtANTERIORSEGMENTLeft" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>
                             </div>

                           <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtPOSTERIORSegmentRight" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-center">
                                    <div class="form-group">
                                       
                                     POSTERIOR SEGMENT</br>
                                        Vitreous,Optic Disc,Retina,Macula Dilated
                                        
                                        
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-center">
                                    <div class="form-group">
                                        </br>
                                      
                                        <asp:RadioButtonList runat="server" ID="rblPosterior" RepeatDirection="Horizontal" >
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem  Selected="True" Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                            </div>
                        <div class="col-lg-4 text-center">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtPOSTERIORSegmentLeft" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>
                             </div>


                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-center">
                             DIAGNOSIS
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtOphthalmicDiagnosis" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-center">
                             MANAGEMENT
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtOphthalmicMANAGEMENT" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>
                              </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-center">
                             INVESTIGATIONS
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtOphthalmicINVESTIGATIONS" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-center">
                             PROCEDURES
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtOphthalmicPROCEDURES" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>
                              </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                         <strong>Upload File</strong>
                                        </div>
                              </div>
                         <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                              
                                                 <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="9"  
                                            Width="200px" />
                                      
                                                </div>
                                              </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                          <asp:TextBox ID="txtfileNAme" placeholder="File Name" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                         <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                                                          CssClass="btn btn-info" onclick="btnUpload_Click"   Text="Upload" />
                                        </div>
                             </div>
                         <div class="col-sm-6 text-left">
   <div class="form-group">   
       <div runat="server" id="UploadedFiles" style="height:150px;  overflow:scroll"    >                                          
 <div class="table-responsive" style="width:100%" >

<asp:GridView ID="gvImages" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" DataKeyNames="Path,OPFileId" AutoGenerateColumns="False" OnRowDeleting="gvImages_RowDeleting">
    <Columns>
        <asp:BoundField DataField="OPFileId" HeaderText=" Id" />
        <asp:BoundField DataField="FileName" HeaderText="Name" />
         <asp:BoundField DataField="CreatedOn" HeaderText="Created On" />
      
        <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Imagebutton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                            OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                            CommandName="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:TemplateField>
  <asp:TemplateField HeaderText="FilePath">
<ItemTemplate>
<asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>
     <asp:HyperLink ID="Hyp_viewPres" runat="server" Visible="false" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View File</asp:HyperLink>
<div id="dialog" style="display: none">
</div>
     </div>
           </div>
       </div>
     </div>
                   
                        <%-- <div class="col-sm-3 text-left">
                                            <div class="form-group">
                                                <asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View File</asp:HyperLink>
                                                </div>
                             </div>--%>
                        </div>
                              </div>
                         
                         
                          <div class="messagealert" id="alert_container">
            </div>
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                       
                                        <asp:Button ID="btnreport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreport_Click" />
                                        <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="OPDNo"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" 
                                    AllowPaging="True" BackColor="White"  
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="30" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        <asp:BoundField DataField="Patregid" HeaderText="Reg No"  />
                                        
                                        <asp:BoundField DataField="OPDNo" HeaderText="OPDNo"  />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On "  />
                                        <asp:BoundField DataField="ChiefComplaints" HeaderText="Complaints "  />
                                        <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis"  />
                                        <asp:BoundField DataField="ClinicalNote" HeaderText="Clinical Note"  />
                                         <%--<asp:TemplateField HeaderText="ViewFile" >
                            <ItemTemplate>
<asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View File</asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>--%>
                                     
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
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
                     </div>
                     </div>
                   </section>
            <script language="javascript" type="text/javascript">
                function OpenReport() {

                    window.open("Reports.aspx");
                }
               </script>
            <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
</asp:Content>

