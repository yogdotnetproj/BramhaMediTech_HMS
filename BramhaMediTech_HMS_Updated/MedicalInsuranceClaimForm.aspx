<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="MedicalInsuranceClaimForm.aspx.cs" Inherits="MedicalInsuranceClaimForm" %>
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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Medical Insurance Claim Form</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Medical Insurance Claim Form</li>
                    </ol>
    </section>
     <section class="content">
        <div id="Div1" class="box" runat="server">
            <!--<div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
                
                 
                  
                 
                <div class="col-lg-12 mt-3">
                    <div class="row">
                       
<asp:Label id="lblmsg" style="text-align: center" ForeColor="Red" runat="server"  Font-Bold="true"> </asp:Label>

                    </div>

                </div>

                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                      Name of  Insurance Company
                                        </div>
                             </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtInsuranceCompany" CssClass="form-control"  runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Date of Consultation
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtConsultationdate" runat="server" CssClass="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"> <i class="fa fa-calendar"></i></span>
                                            </div>
                                    </div>
                                </div>

                    </div>

                </div>
                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lbldsmoke"   runat="server" Text="Name of Employer"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtnameofemployer" CssClass="form-control"   runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label3"   runat="server" Text="Name of Employee"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtEmployeeName" CssClass="form-control"  placeholder="" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-2 p-0">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="LblsmQu"   runat="server" Text="Certificate No"></asp:Label>
                                    </div>
                                </div>

                        <div class="col-lg-2  text-left">
                                        <div class="form-group">
                                          <asp:TextBox ID="txtCertificate" CssClass="form-control"  placeholder="" runat="server" Text=""></asp:TextBox>
 
                                            
                                        </div>
                                    </div>
                        </div>
                     </div>

                   <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label4"   runat="server" Text="Name of Patient"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtpatientname" CssClass="form-control"  runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label6"   runat="server" Text="Age of  Patient"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtageofpatient" CssClass="form-control"  placeholder="" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-2 p-0">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label15"   runat="server" Text="ID of Patients"></asp:Label>
                                    </div>
                                </div>

                        <div class="col-lg-2  text-left">
                                        <div class="form-group">
                                          <asp:TextBox ID="txtIdOfPatients" CssClass="form-control"  placeholder="" runat="server" Text=""></asp:TextBox>
 
                                            
                                        </div>
                                    </div>
                        </div>
                     </div>

                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label16"   runat="server" Text="Relationship of Patient to Employee"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtrelationofPatients" CssClass="form-control"  runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label17"   runat="server" Text="Hospital Patient ID"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtHospitalID" CssClass="form-control"  placeholder="" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                     
                        </div>
                     </div>


                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label1"   runat="server" Text="When did symptoms of this ailment first appear or accident occur? :"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtSymptoms" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>
                   <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label18"   runat="server" Text="Did your injury or sickness arise out of your employment?:"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtinjury" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>

                    <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label19"   runat="server" Text="Nature of illness or condition"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtnatureofillness" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>

                        <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label20"   runat="server" Text="Is patient covered under any other medical insurance plan "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtispatintCovered" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>

                      <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label21"   runat="server" Text="If condition is due to pregnancy, what is the approximatedate of commencement of pregnancy "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtPregnancycondition" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>

                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label22"   runat="server" Text="Have the patient ever had same or similar condition "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtsimilarCondition" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>

                    <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label23"   runat="server" Text="I certify that the foregoing answers are true and correct to the best of my knowledge and hereby authorize all doctors or other persons who treated me and the St Joseph Mercy Hospital to furnish full information regarding this claim to the above named Insurance Company."></asp:Label>
                                    </div>
                                </div>
                       
                        </div>
                     </div>
                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label24"   runat="server" Text="I hereby authorize payment directly to the Hospital to satisfy my indebtedness or that of my dependents for the treatment and/services supplied.  I understand that I am financially responsible for charges not covered by the Medical Insurance Policy"></asp:Label>
                                    </div>
                                </div>
                       
                        </div>
                     </div>
                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label2"   runat="server" Text="Signature of Employee/Patient"></asp:Label>
                                    </div>
                                </div>
                       
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtsignature"  CssClass="form-control"   runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label5"   runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                        </div>
                     </div>
                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label7"   runat="server" Text="Diagnosis of Doctor "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtDiagnosisofDoctor" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label8"   runat="server" Text="Test Prescribed "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txttestPrescribed" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label9"   runat="server" Text="Medication Prescribed "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtMedicationPrescribed" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        
                        </div>
                     </div>

                 <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label10"   runat="server" Text="Name of Doctor "></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtnameofdr" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>    
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label11"   runat="server" Text="Signature of Doctor"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:TextBox ID="txtsignatureofdoctor" CssClass="form-control"  TextMode="MultiLine" placeholder="" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>  
                        </div>
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Report" class="btn btn-warning" OnClick="btnReset_Click" />
                                         
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

