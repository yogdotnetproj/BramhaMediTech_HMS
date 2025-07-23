<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="Nurse_ShiftReport.aspx.cs" Inherits="Nurse_ShiftReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: white;
            width: auto;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no .modalPopup .cancel {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup .cancel {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>
     <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript">

        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Nurse Shift Report</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Nurse Shift Report</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
             <div class="box-body">
                
                      


                <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>               
                <div class="col-lg-12" runat="server" >
                                 <div class="row"> 
                                     <strong>Situation</strong>
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                      Current / Main Complaints:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-10 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtCurrent" runat="server"  class="form-control" TextMode="MultiLine" ></asp:TextBox>  
                                                            </div>
                                           </div>   
                                     </div>
                    </div> 
                  <div id="Div2" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                    
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                     Admission/Working Diagnosis:   
                                                        </div>
                                                    </div>
                                       <div class="col-lg-10 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtAdmDiagnosis" runat="server"  class="form-control" TextMode="MultiLine" ></asp:TextBox>  
                                                            </div>
                                           </div>   
                                     </div>
                    </div> 
                  <div id="Div3" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                    
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                     Vital Signs:   
                                                        </div>
                                                    </div>
                                     <div class="col-lg-1 text-right" >
                                                        <div class="form-group"> 
                                                            T
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtTem" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            C
                                                            </div>
                                         </div>  
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            P
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtPulse" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            bmp
                                                            </div>
                                         </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            R
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtR" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            bmp
                                                            </div>
                                         </div> 
                                     </div>

                        <div class="row mt-2">                                    
                                       
                                     <div class="col-lg-3 text-right" >
                                                        <div class="form-group"> 
                                                            BP
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtBP" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            mm/Hg
                                                            </div>
                                         </div>  
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            SPO2
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtspo2" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            %
                                                            </div>
                                         </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            RA/O2@
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtrao" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            L/min
                                                            </div>
                                         </div>
                            
                                     </div>
                      <div class="row mt-2">                                    
                                       <div class="col-lg-3 text-right" >
                                                        <div class="form-group"> 
                                                            LOC/GCS
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtLoC" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            /15
                                                            </div>
                                         </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            RBS
                                                            </div>
                                         </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtRBS" runat="server"  class="form-control"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                            mm/dl
                                                            </div>
                                         </div>
                           <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                           Diet:
                                                            </div>
                                         </div>
                           <div class="col-lg-3 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtDiet" runat="server"  class="form-control" TextMode="MultiLine"  ></asp:TextBox>  
                                                            </div>
                                           </div> 
                          </div>
                    </div> 


                  <div id="Div4" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     <strong>Background</strong>
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                      Code Status:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-2 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="chkFullCode" runat="server"   Text="Full Code" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-2 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkConfort" runat="server"   Text="Comfort Measures" ></asp:CheckBox>  
                                                            </div>
                                           </div>  
                                      <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkDNR" runat="server"   Text="DNR" ></asp:CheckBox>  
                                                            </div>
                                           </div>  
                                     </div>
                    </div>

                  <div id="Div5" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Past Medical History:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkDm" runat="server"   Text="DM" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkHTN" runat="server"   Text="Htn" ></asp:CheckBox>  
                                                            </div>
                                           </div>  
                                      <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkCancer" runat="server"   Text="Cancer" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                      <div class="col-lg-7 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtpastmedicalHistory" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>

                   <div id="Div6" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Allergies:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-10 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtAllergies" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>
                   <div id="Div7" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Past Surgery History:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       
                                      <div class="col-lg-10 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtPastsurgeryHistory" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>

                   <div id="Div8" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Family History:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkDMF" runat="server"   Text="DM" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                     <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="CHKHTNF" runat="server"   Text="HTN" ></asp:CheckBox>  
                                                            </div>
                                           </div>  
                                      <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkCancerF" runat="server"   Text="Cancer" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                      <div class="col-lg-7 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtFamilyHistory" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>

                   <div id="Div9" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Social History:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkSmoker" runat="server"   Text="Smoker" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                      <div class="col-lg-2 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtSmoker" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkAlcohol" runat="server"   Text="Alcohol" ></asp:CheckBox>  
                                                            </div>
                                           </div>  
                                      <div class="col-lg-2 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtAlcohol" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                      <div class="col-lg-1 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:CheckBox ID="ChkDruguse" runat="server"   Text="Druguse" ></asp:CheckBox>  
                                                            </div>
                                           </div> 
                                      <div class="col-lg-3 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtdrugUSe" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>

                    <div id="Div10" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Other:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-10 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtOther" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>

                    <div id="Div11" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Medications:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-10 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtMedications" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>

                  <div id="Div12" class="col-lg-12 mt-2" runat="server" >
                      <strong>Assessment</strong>
                                 <div class="row"> 
                                     
                                       <div class="col-lg-4" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     IV site(Heplock/fluids/drips/when to change IV site):
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-8 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtIVSite" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>

                       <div class="row mt-2"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Drains Catheters:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-10 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtDrainsCatheters" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>

                      <div class="row mt-2"> 
                                     
                                       <div class="col-lg-4" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                    Procedures done in the last 24 hours(include any known results):
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-8 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtProceduresdone" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                        <div class="row mt-2"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                   Abnormal Assessments:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-10 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtAbnormalAssessment" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                       <div class="row mt-2"> 
                                     
                                       <div class="col-lg-2" >
                                                        <div class="form-group">       
                                                   Current Pain Score:      
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-1 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtPainscore" class="form-control" ></asp:TextBox>
                                                            </div>
                                          </div> 
                           
                                      <div class="col-lg-1 text-left" >
                                                        <div class="form-group">
                                                            /10
                                                            </div>
                                          </div>
                           
                                       <div class="col-lg-1" >
                                                        <div class="form-group">       
                                                   Intervention:      
                                                        </div>
                                                    </div>
                           
                                      <div class="col-lg-7 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtIntervention" class="form-control" TextMode="MultiLine" ></asp:TextBox>
                                                            </div>
                                          </div>

                                     </div>

                       <div class="row mt-2"> 
                                     
                                       <div class="col-lg-5" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                   Safety  Needs(fall risk/skin risk/wounds/dressings ,etc):
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-7 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtSafety" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                    </div>


                 <div id="Div13" class="col-lg-12 mt-2" runat="server" >
                      <strong>Recommendation</strong>
                                 <div class="row"> 
                                     
                                       <div class="col-lg-4" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                    Needed changes in the plan of care?(diet,activity,medication,consult) :
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-8 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtneededchanges" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                     <div class="row mt-2"> 
                                     
                                       <div class="col-lg-4" >
                                                        <div class="form-group">                                                                                         
                                                             
                                                    What are you concerned about? :     
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-8 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtConcerned" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                         <div class="row mt-2"> 
                                     
                                       <div class="col-lg-4" >
                                                        <div class="form-group">                                                                                         
                                                             
                                                   Pending Labs/X-rays,etc :     
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-8 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtPendingLab" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                      <div class="row mt-2"> 
                                     
                                       <div class="col-lg-4" >
                                                        <div class="form-group">                                                                                         
                                                             
                                                 What the next shift needs to be aware of :     
                                                    
                                                        </div>
                                                    </div>
                                        
                                      <div class="col-lg-8 text-left" >
                                                        <div class="form-group">
                                                            <asp:TextBox runat="server" ID="txtnextshiftaware" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                          </div> 
                                     </div>
                     </div>
                 

                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server"  Text="Save"  UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" class="btn btn-success btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Visible="false" Text="Report" class="btn btn-warning btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
                <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:450px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="ShiftId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging" OnRowCommand="gvDailyNurseNote_RowCommand">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" Visible="false" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                <asp:BoundField DataField="CreatedOn" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="CurrentComplaint" HeaderText="Current Complaint" />
                                    <asp:BoundField DataField="AdmissionDiagnosis"  HeaderText="Admission Diagnosis" />
                                    <asp:BoundField DataField="CreatedBy"  HeaderText="CreatedBy" />
                                     <asp:ButtonField CommandName="Report" Text="Report" HeaderText="Report" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                <asp:ButtonField CommandName="Delete" Text="Delete" Visible="false" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
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
                     
            
</section>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>


