<%@ Page Title="" Language="C#" MasterPageFile="~/DermatologyMaster.master" AutoEventWireup="true" CodeFile="DermatologyOutPatient.aspx.cs" Inherits="DermatologyOutPatient" %>
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
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Dermatology Out Patient</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Dermatology Out Patient</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">    
                          <div class="col-lg-12 mt-2" id="Antagonist" runat="server" >
                    <div class="row">
                            <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                         Blood Pressure
                                        </div>
                                </div>
                        <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtBloodPressure"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        mmHg
                                        </div>
                                </div>
                          <div class="col-lg-1 text-center">
                                    <div class="form-group">
                                        Pulse
                                        </div>
                                </div>
                        <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtpulse"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        bpm
                                        </div>
                                </div>
                         <div class="col-lg-1 text-center">
                                    <div class="form-group">
                                         Temperature
                                        </div>
                                </div>
                         <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtTemperature"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                        </div>
                
                     </div>

                         <div class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                      <strong> Complaints</strong>  
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <strong>   Area</strong>  
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       <strong>    Medical History</strong>  
                                        </div>
                                </div>

                        </div>
                             </div>
                           <div  class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                    
                                         <div class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkItechking" Text="Itech" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                          <div  class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkRash" Text="Rash" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                          <div  class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkPigmentation" Text="Pigmentation" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div   class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkAcne" Text="Acne" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div   class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkScar" Text="Scar" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkHirsutism" Text="Hirsutism" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkHairLoss" Text="Hair Loss" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div id="Div2"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkExcessHairGrowth" Text="Excess Hair Growth" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                 
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                         <div id="Div3"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkFace" Text="Face" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div id="Div4"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkBody" Text="Body" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div id="Div5"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkExtremities" Text="Extremities" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                      <div id="Div6"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkDM" Text="DM" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div id="Div7"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkHTN" Text="HTN" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div id="Div8"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkSmoker" Text="Smoker" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div id="Div9"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkAlcoholic" Text="Alcoholic" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div id="Div10"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        Other
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div id="Div11"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                           <asp:TextBox ID="txtOther"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        </div>
                                </div>

                        </div>
                             </div>

                         
                         <div id="Div12" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong> Examination Findings </strong>  
                                        </div>
                                </div>
                         <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                       <asp:TextBox ID="txtExaminationFinding" TextMode="MultiLine"   CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         

                        </div>
                             </div>
                           <div id="Div13" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                      <strong> Treatment(Medications)</strong>  
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <strong>   Other</strong>  
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       <strong>    Laser</strong>  
                                        </div>
                                </div>

                        </div>
                             </div>
                           <div id="Div14"  class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                    
                                         <div id="Div15" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkTablets" Text="Tablets" />
                                        </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkOintment" Text="Ointment" />
                                        </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkSoap" Text="Soap" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                            <div id="Div16" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkCapsules" Text="Capsules" />
                                        </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkLotion" Text="Lotion" />
                                        </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkSunscreen" Text="Sunscreen" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                        <div id="Div17" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkCream" Text="Cream" />
                                        </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkShampoo" Text="Shampoo" />
                                        </div>
                                </div>
                        
                        </div>
                                             </div>
                                       
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                         <div id="Div23"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtOther1" TextMode="MultiLine" Height="115px"  CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                       
                                        </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                      <div id="Div26"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkHairLaser" Text="Hair Laser" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div id="Div27"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkCo2Laser" Text="CO2 Laser" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                         <div id="Div28"    class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="ChkInfiniTouch" Text="INFINI Touch" />
                                        </div>
                                </div>
                        </div>
                                             </div>
                                       
                                        </div>
                                </div>

                        </div>
                             </div>


                          <div id="Div18" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong> Treatment/ Medication </strong>  
                                        </div>
                                </div>
                        
                         <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                       <asp:TextBox ID="txtTreatmentMedication" TextMode="MultiLine"   CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         

                        </div>
                             </div>
                         <div id="Div19" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong> Peel </strong>  
                                        </div>
                                </div>
                         <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                       <asp:TextBox ID="txtPeel" TextMode="MultiLine"   CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         

                        </div>
                             </div>
                          <div id="Div20" class="col-lg-12 mt-2"  runat="server" >
                    <div class="row">
                            <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <strong> Intra Leison Steroid: </strong>  
                                        </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <asp:CheckBox runat="server" ID="chkTriamcinolone" Text="Triamcinolone" />
                                        </div>
                                </div>
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                      <strong> Other</strong>  
                                        </div>
                                </div>
                         <div class="col-lg-7 text-left">
                                    <div class="form-group">
                                       <asp:TextBox ID="txtOtherIntraLeisonSteroid" TextMode="MultiLine"   CssClass="form-control"   runat="server" />
                                        </div>
                                </div>
                         

                        </div>
                             </div>
                          <div class="messagealert" id="alert_container">
            </div>
                          <div class="col-lg-12 mt-2" id="Div1" runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                       
                                        <asp:Button ID="btnreport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreport_Click" />
                                        </div>
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

