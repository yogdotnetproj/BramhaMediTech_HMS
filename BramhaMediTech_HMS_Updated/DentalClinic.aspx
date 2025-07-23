<%@ Page Title="" Language="C#" MasterPageFile="~/Dental_Master.master" AutoEventWireup="true" CodeFile="DentalClinic.aspx.cs" Inherits="DentalClinic" %>
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
                    <h1>Dental Clinic</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Dental Clinic</li>
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
                                       
                                      <strong>  Date</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
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
                         <div class="col-lg-2 text-left" >
                                    <div class="form-group">
                                          <asp:Button ID="btnDiagnisis_Treatment" runat="server" Text="Diagnosis and Treatment " class="btn btn-warning" OnClick="btnDiagnisis_Treatment_Click" />
                                        </div>
                            </div>
                           <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                          <asp:Button ID="btnTreatmentdetails" runat="server" Text="Treatment Details " class="btn btn-danger" OnClick="btnTreatmentdetails_Click" />
                                        </div>
                            </div>
                        </div>
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
                                        Allergy
                                        </div>
                              </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtAllergy" placeholder="Enter Allergy" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                            </div>
                        </div>
                                </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Pregnancy
                                        </div>
                              </div>
                        <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtPregnancy" placeholder="Enter Pregnancy" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
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
                                 <strong>Other</strong>
                                        </div>
                            </div>
                        </div>
                                </div>
                                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12-mt-2 text-left">
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
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                          <strong>Diagnosis</strong>
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txtDiagnosis" placeholder="" Height="200px" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                </div>
                            </div>
                        </div>
                                  </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                          <strong>Treatment Advised</strong>
                                 </div>
                            </div>
                          <div class="col-lg-10 text-center">
                            <div class="form-group">
                                  <asp:TextBox ID="txttreatmentadvised" placeholder="" Height="200px" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
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
                            <strong>Treatment Details</strong>
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

       <asp:TemplateField HeaderText="Treatment Done" >

            <ItemTemplate>

                <asp:TextBox ID="txtTreatmentDone" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Next Appoin" >

            <ItemTemplate>

                <asp:TextBox ID="txtNextAppoin" CssClass="form-control" runat="server"></asp:TextBox>

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
                             
                               <div class="col-lg-12 mt-2 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btntreatmentdeta" runat="server" Text="Save" class="btn btn-success" OnClick="btntreatmentdeta_Click"   />
                                       
                                        <asp:Button ID="btntreatmentPrint" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btntreatmentPrint_Click"  />
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

