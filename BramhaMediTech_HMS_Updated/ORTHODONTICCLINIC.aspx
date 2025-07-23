<%@ Page Title="" Language="C#" MasterPageFile="~/Dental_Master.master" AutoEventWireup="true" CodeFile="ORTHODONTICCLINIC.aspx.cs" Inherits="ORTHODONTICCLINIC" %>
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <Triggers>
            <asp:PostBackTrigger ControlID="btnreportHistory" />   
         <asp:PostBackTrigger ControlID="btnDiagnossaveReport" />  
         <asp:PostBackTrigger ControlID="btntreatmentPrint" />   
         
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>ORTHODONTIC CLINIC</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">ORTHODONTIC CLINIC</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">    
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Refer By</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       <asp:TextBox ID="txtreferby" placeholder="Enter refer by" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Ortho No</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtOrthoNo" placeholder="Enter Ortho No" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                        </div>
                     </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                          <asp:Button ID="btnhistory" runat="server" Text="History" class="btn btn-success" OnClick="btnhistory_Click" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                          <asp:Button ID="btnIntraralExamination" runat="server" Text="Intraoral Examination" class="btn btn-primary" OnClick="btnIntraralExamination_Click" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                          <asp:Button ID="btnInvistigation" runat="server" Text="Investigation Details" class="btn btn-secondary" OnClick="btnInvistigation_Click"  />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left" >
                                    <div class="form-group">
                                          <asp:Button ID="btnDiagnisis_Treatment" runat="server" Text="Diagnosis and Treatment " class="btn btn-warning" OnClick="btnDiagnisis_Treatment_Click" />
                                        </div>
                            </div>
                           <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                          <asp:Button ID="btnTreatmentdetails" runat="server" Text="Orthodontic Treatment" class="btn btn-danger" OnClick="btnTreatmentdetails_Click" />
                                        </div>
                            </div>
                        </div>
                                </div>
                         <div class="messagealert" id="alert_container">
            </div>
                         <div class="col-lg-12 mt-2" id="historyTem" runat="server" >
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <strong>History Details</strong>
                            </div>
                        </div>
                                  </div>
                    <div class="row">
                            <div class="col-lg-12  mt-2 text-left">
                                 <div class="row">
                      <div class="col-lg-9  text-left">
                          
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                      <strong> Cheif Complaints</strong> 
                                        </div>
                            </div>
                        </div>
                                </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtChiefcomplaints" placeholder="Enter Chief Complaints" Height="100px" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Medication
                                        </div>
                              </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtMedication" placeholder="Enter Medication" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Past Dental History
                                        </div>
                              </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtPastDentalHistory" placeholder="Enter Past Detail History" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Family History
                                        </div>
                              </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtFamilyHistory" placeholder="Enter  Family History" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                          
                          
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Habits
                                        </div>
                              </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtHabits" placeholder="Enter Habits" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                         
                          </div>
                                       <div class="col-lg-3  text-left">
                                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                    <strong>  Medical History</strong> 
                                        </div>
                            </div>
                        </div>
                                </div>

                                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkHypertension" Text="Hypertension"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkDiabetes" Text="Diabetes"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkAnaemia" Text="Anaemia"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkKidneyDisease" Text="Kidney Disease"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="chkAsthama" Text="Asthama"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="chkJaundice" Text="Jaundice"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkAllergy" Text="Allergy"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkBleedingdisorder" Text="Bleeding Disorder"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:CheckBox runat="server" ID ="ChkPregnant" Text="Pregnant"  />
                                        </div>
                            </div>
                        </div>
                                </div>
                                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                 <strong>Other</strong>
                                        </div>
                            </div>
                        </div>
                                </div>
                                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                  <asp:TextBox ID="txtOther" placeholder="Enter Other" Height="130px" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                          </div>
                                     </div>
                                  <div class="col-lg-12-mt-2 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsaveHistory" runat="server" Text="Save" class="btn btn-success" OnClick="btnsaveHistory_Click"  />
                                       
                                        <asp:Button ID="btnreportHistory" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreportHistory_Click" />
                                        </div>
                                      </div>
                                </div>
                        </div>
                             </div>


                           <div class="col-lg-12 mt-2" id="IntrarorExm" visible="false" runat="server" >
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <strong>Intraoral Examination</strong>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-4 text-center">
                             <div class="form-group">
                           <asp:FileUpload runat="server" ID="BrowseImage"  />
                                 </div>
                            </div>
                          <div class="col-lg-8 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txtIntraoralExamination" placeholder="" Height="200px" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsavetIntraoral" runat="server" Text="Save" class="btn btn-success" OnClick="btnsavetIntraoral_Click"   />
                                       
                                        <asp:Button ID="btnsavetIntraoralReport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnsavetIntraoralReport_Click"  />
                                        </div>
                                      </div>

                               </div>


                           <div class="col-lg-12 mt-2" id="DiagNostTreatment" visible="false" runat="server" >
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <strong>Diagnosis and Treatment</strong>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                          <strong>Treatment Advised</strong>
                                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                                   <asp:DropDownList ID="ddlTreatmentAdvise"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="PEA-MBT">PEA-MBT</asp:ListItem>
                                            <asp:ListItem Value="PEA-ROTH">PEA-ROTH</asp:ListItem>
                                         
                                           
                                        </asp:DropDownList>
                                 </div>
                            </div>
                        </div>
                                      </div>
                                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:DropDownList ID="ddlTreatmentAdvise1"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="0.018">0.018</asp:ListItem>
                                            <asp:ListItem Value="0.022">0.022</asp:ListItem>
                                         
                                           
                                        </asp:DropDownList>
                                 </div>
                            </div>
                        </div>
                                      </div>
                                 </div>
                            </div>
                        
                        
                        <div class="col-lg-4 text-left">
                             <div class="form-group">
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkFunctionalRemoval" Text="Functional Removal" />
                                 </div>
                            </div>
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtfunctionremoval" CssClass="form-control" />
                                 </div>
                            </div>
                        </div>
                                      </div>
                                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkFunctionalFixed" Text="Functional Fixed" />
                                 </div>
                            </div>
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtFunctionalFixed" CssClass="form-control" />
                                 </div>
                            </div>
                        </div>
                                      </div>
                                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkOrthopedic" Text="Orthopedic" />
                                 </div>
                            </div>
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtOrthopedic" CssClass="form-control" />
                                 </div>
                            </div>
                        </div>
                                      </div>
                                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkExpansion" Text="Expansion" />
                                 </div>
                            </div>
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                <asp:TextBox runat="server" ID="txtExpansion" CssClass="form-control" />
                                 </div>
                            </div>
                        </div>
                                      </div>
                                 </div>
                            </div>
                          <div class="col-lg-4 text-center">
                            <div class="form-group">
                                 <strong>Retention Protocol |-</strong>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                Upper
                                 </div>
                            </div>
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                               <asp:DropDownList ID="ddlUpper"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Clear">Clear</asp:ListItem>
                                            <asp:ListItem Value="Beggs">Beggs</asp:ListItem>
                                            <asp:ListItem Value="Fixed Lingual">Fixed Lingual</asp:ListItem>
                                            <asp:ListItem Value="Hawleys">Hawley's</asp:ListItem>
                                        </asp:DropDownList>
                                 </div>
                            </div>
                        </div>
                                      </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                                Lower
                                 </div>
                            </div>
                        <div class="col-lg-6 text-left">
                             <div class="form-group">
                               <asp:DropDownList ID="ddlLower"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Clear">Clear</asp:ListItem>
                                            <asp:ListItem Value="Beggs">Beggs</asp:ListItem>
                                            <asp:ListItem Value="Fixed Lingual">Fixed Lingual</asp:ListItem>
                                            <asp:ListItem Value="Hawleys">Hawley's</asp:ListItem>
                                        </asp:DropDownList>
                                 </div>
                            </div>
                        </div>
                                      </div>
                                </div>
                            </div>
                        </div>
                                  </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                          Diagnosis
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txttreatmentDiagnosis" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                          Appliance
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txtAppliance" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                         Extractions
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txtExtractions" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div> 
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                         Envelope of Discrepancy
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txtEnvelope" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                          Approximate Treatment Time
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txtApproximatetretime" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnDiagnossave" runat="server" Text="Save" class="btn btn-success" OnClick="btnDiagnossave_Click"    />
                                       
                                        <asp:Button ID="btnDiagnossaveReport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnDiagnossaveReport_Click"  />
                                        </div>
                                      </div>

                               </div>


                          <div class="col-lg-12 mt-2" id="TreatmentDet" visible="false" runat="server" >
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <strong>Orthodontic Treatment </strong>
                            </div>
                        </div>
                    </div>
                              <div class="col-lg-12 mt-2">
                                   <div class="row">
                        <div class="col-lg-3 text-center">
                            <strong>Total Treatment Amount </strong>
                            </div>
                                        <div class="col-lg-2 text-center">
                                             <asp:TextBox ID="txtTreatmentAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                                                  <asp:gridview ID="GvHairLaser" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

                <asp:TextBox ID="txtTreatmentDate" CssClass="form-control" Text='<%# Eval("TreatmentDate") %>' runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="Treatment Progress" >

            <ItemTemplate>

                <asp:TextBox ID="txtTreatmentProgress" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Payment" >

            <ItemTemplate>

                <asp:TextBox ID="txtPayment" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Remark" >

            <ItemTemplate>

                <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
                  <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />

            </FooterTemplate>
        </asp:TemplateField>

             
           

        </Columns>

</asp:gridview>

                                 </div>
                            </div>
                         
                        </div>
                                  </div>
                             

                              
                              <div class="col-lg-12 mt-2">
                                   <div class="row">
                        <div class="col-lg-2 text-center">
                            <strong>Balance Amount </strong>
                            </div>
                                        <div class="col-lg-2 text-center">
                                             <asp:TextBox ID="txtBalanceAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                        </div>
                                  </div>
                               <div class="col-lg-12 mt-2 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btntreatmentdeta" runat="server" Text="Save" class="btn btn-success" OnClick="btntreatmentdeta_Click"   />
                                       
                                        <asp:Button ID="btntreatmentPrint" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btntreatmentPrint_Click"  />
                                        </div>
                                      </div>

                               </div>

                          <div class="col-lg-12 mt-2" id="Investigat" visible="false" runat="server" >
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-center">
                            <strong>Investigation </strong>
                            </div>
                        </div>
                    </div>
                              <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-center">
                           <div class="col-lg-12 mt-2">
                               <strong>RADIOGRAPHS</strong>
                               </div>
                             </div>
                        <div class="col-lg-3 text-left">
                               <strong>PRE Treatment</strong>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkLateralCephalogram" Text="Lateral Cephalogram" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkFrontal" Text="Frontal  Cephalogram" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkOPG" Text="OPG" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkIOPA" Text="IOPA" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkSLOB" Text="SLOB" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkOCCLUSAL" Text="OCCLUSAL" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            </div>
                        <div class="col-lg-3 text-left">
                            <strong>MID TREATMENT</strong>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkMIDLateral" Text="Lateral Cephalogram" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkMIDFrontal" Text="Frontal  Cephalogram" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkMIDOPG" Text="OPG" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkMIDIOPA" Text="IOPA" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkMIDSLOB" Text="SLOB" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkMIDOCCLUSAL" Text="OCCLUSAL" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             </div>
                        <div class="col-lg-3 text-left">
                            <strong>POST TREATMENT</strong>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPostLateral" Text="Lateral Cephalogram" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPostFrontal" Text="Frontal  Cephalogram" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPostOPG" Text="OPG" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPostIOPA" Text="IOPA" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPostSLOB" Text="SLOB" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkPostOCCLUSAL" Text="OCCLUSAL" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                             </div>

                         <div class="col-lg-1 text-center">
                               <strong>Comments</strong>
                           <div class="col-lg-12 mt-2">
                             <div class="form-group">
                                  <asp:TextBox ID="txtInvComments" placeholder="" Height="220px"  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                 </div>
                               </div>
                             </div>
                        
                        </div>
                    </div>
                             

                                   <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-center">
                           <div class="col-lg-12 mt-2">
                               <strong>MODELS</strong>
                               </div>
                             </div>
                        <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtModelPreTreatment" placeholder=""   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                         <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtModelMIDTreatment" placeholder=""   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtModelPostTreatment" placeholder=""   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        <div class="col-lg-1 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtModealsComments" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        </div>
                                       </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-center">
                           <div class="col-lg-12 mt-2">
                               <strong>PHOTOGRAPHS</strong>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkEXTRAORAL" Text="EXTRAORAL" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="ChkINTRAORAL" Text="INTRAORAL" />
                                 </div>
                            </div>
                       
                        </div>
                                      </div>
                               </div>
                             </div>
                        <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtPHOTOGRAPHSPre" placeholder="" height="85px"  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                         <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtPHOTOGRAPHSMid" placeholder=""  height="85px"   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtPHOTOGRAPHSPost" placeholder=""   height="85px"  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        <div class="col-lg-1 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtPHOTOGRAPHSComments" placeholder=""  height="85px"  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        </div>
                                       </div>

                                <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-center">
                           <div class="col-lg-12 mt-2">
                               <strong>Others</strong>
                               </div>
                             </div>
                        <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtOthersPre" placeholder=""   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                         <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtOthersMid" placeholder=""   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        <div class="col-lg-3 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtOthersPost" placeholder=""   CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        <div class="col-lg-1 text-center">
                           <div class="col-lg-12 mt-2">
                               <asp:TextBox ID="txtOtherscomments" placeholder=""  CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                               </div>
                             </div>
                        </div>
                                       </div>

                              
                               <div class="col-lg-12 mt-2 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsaveinvestigation" runat="server" Text="Save" class="btn btn-success" OnClick="btnsaveinvestigation_Click"   />
                                       
                                        <asp:Button ID="btnprintinvestigation" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnprintinvestigation_Click"  />
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
             </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

