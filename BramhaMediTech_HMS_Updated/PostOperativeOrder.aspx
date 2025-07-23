<%@ Page Title="OT Template" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="PostOperativeOrder.aspx.cs" Inherits="PostOperativeOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <h1>General EMR</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="ckeditor/ckeditor.js"></script>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
           <section class="content-header d-flex">
                    <h1>Post Operative Orders</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Post Operative Orders</li>
                    </ol>
                </section>

            <section class="content">
                <div class="box" runat="server">
                    
                      <div class="box-body">
                        <%-- <div class="row">--%>
                                <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkNasal" Text="&nbsp;  Nasal O2" />
                                          </div>
                                           </div>
                                     </div>
                                    </div>

                           <div class="col-lg-12 mt-2">
                               <strong>Diet:</strong> 
                                 <div class="row">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkNBM" Text="&nbsp; NBM" />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkSipsofwater" Text="&nbsp; Sips of Water" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkClearliquid" Text="&nbsp; Clear liquids 30ml/hour" />
                                          </div>
                                           </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkFreeliquids" Text="&nbsp; Free liquids" />
                                          </div>
                                           </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkSemisoliddiet" Text="&nbsp; Semisolid Diet" />
                                          </div>
                                           </div>
                                     </div>
                               </div>
                           <div class="col-lg-12 mt-2">
                               <strong>Monitoring:</strong> 
                                 <div class="row">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkTemperature" Text="&nbsp; Temperature" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkPulse" Text="&nbsp; Pulse" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkRespiration" Text="&nbsp; Respiration" />
                                          </div>
                                           </div>
                                     <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkBloodPressure" Text="&nbsp; Blood Pressure" />
                                          </div>
                                           </div>
                                    
                                     </div>
                                <div class="row">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkSaO2" Text="&nbsp; SaO2" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkInput" Text="&nbsp; Input" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkUrineOutput" Text="&nbsp; Urine Output" />
                                          </div>
                                           </div>
                                     <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkRyleTubeOutput" Text="&nbsp; Ryle's Tube Output" />
                                          </div>
                                           </div>
                                    
                                     </div>
                                <div class="row">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkDrainOutput" Text="&nbsp; Drain Output" />
                                          </div>
                                           </div>
                                      <div class="col-sm-6" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox2" Text="&nbsp; Abdominal Girth Measurement 2 Hourly" />
                                          </div>
                                           </div>
                                     
                                     <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox4" Text="&nbsp; Colostomy Output" />
                                          </div>
                                           </div>
                                    
                                     </div>
                               </div>
                          <div class="col-lg-12 mt-2">
                               <strong>Intravenous Fluids:</strong> 
                                 <div class="row">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkNS" Text="&nbsp; NS" />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkDNS" Text="&nbsp; DNS" />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkRL" Text="&nbsp; RL" />
                                          </div>
                                           </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="Chk5Dext" Text="&nbsp; 5% Dext" />
                                          </div>
                                           </div>
                                    <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="Chkmlperhours" Text="&nbsp; ml/per hours" />
                                          </div>
                                           </div>
                                     </div>
                              </div>

                           <div class="col-lg-12 mt-2">
                               <strong>Antibiotics:inj:</strong> 
                                 <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         1. <asp:CheckBox runat="server" ID="ChkInjCeftriaxone" Text="&nbsp; Inj.Ceftriaxone 1gm IV 12 hourly" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkInjmeropenam" Text="&nbsp; Inj meropenam 1gm IV 8 hourly " />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkinjCefuroxime" Text="&nbsp; Inj. Cefuroxime 1.5g IV 12 hourly" />
                                          </div>
                                           </div>
                                     
                                     </div>
                                <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                          &nbsp;&nbsp; &nbsp;<asp:CheckBox runat="server" ID="CheckBox6" Text="&nbsp; Inj.Amoxycillin + Clavulanate Acid 1.2g IV 12hourly" />
                                          </div>
                                           </div>
                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox7" Text="&nbsp; Inj cefoperazone + salbactum 2gm IV 12 hourly" />
                                          </div>
                                           </div>
                                     
                                     
                                     </div>
                                  <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         2. <asp:CheckBox runat="server" ID="CheckBox1" Text="&nbsp; Inj.Amikacin 500 IV 12 hourly" />
                                          </div>
                                           </div>
                                      <div class="col-sm-6" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox3" Text="&nbsp; Inj Ciprofloxacin 200 mg IV 12 hourly " />
                                          </div>
                                           </div>
                                     </div>
                                 <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         3. <asp:CheckBox runat="server" ID="CheckBox5" Text="&nbsp;Inj Flagyl 100ml IV 8 hourly" />
                                          </div>
                                           </div>
                                      <div class="col-sm-6" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox8" Text="&nbsp; Inj Gentamycin 80 mg IV 12 hourly " />
                                          </div>
                                           </div>
                                     </div>
                               <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         4. <asp:CheckBox runat="server" ID="CheckBox9" Text="&nbsp;Inj Levofloxacin 750mg IV OD /" />
                                          </div>
                                           </div>
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox10" Text="&nbsp; Inj Linezolid 600 mg IV 12 hourly / " />
                                          </div>
                                           </div>
                                   <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox11" Text="&nbsp; Inj Ofloxacin / " />
                                          </div>
                                           </div>
                                     </div>
                              </div>

                           <div class="col-lg-12 mt-2">
                               <strong>Analgesics:</strong> 
                                 <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         <asp:CheckBox runat="server" ID="CheckBox12" Text="&nbsp; Inj.Voveran 1 amp IM 8 hourly" />
                                          </div>
                                           </div>
                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox13" Text="&nbsp; Inj Tramadol 100mg IV slowly 8 hourly " />
                                          </div>
                                           </div>
                                     
                                     </div>
                                <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         <asp:CheckBox runat="server" ID="CheckBox14" Text="&nbsp; Inj.Buscopan 1 amp IV 8 hourly" />
                                          </div>
                                           </div>
                                      
                                     
                                     </div>
                               </div>
                           <div class="col-lg-12 mt-2">
                              
                                 <div class="row">
                                      <div class="col-sm-5" >
                                           <asp:CheckBox runat="server" ID="CheckBox18" Text="&nbsp; Inj.Pantoprazole 40 mg IV OD" />
                                          </div>
                                     </div>
                               </div>
                            <div class="col-lg-12 mt-2">
                               <strong>W/F:</strong> 
                                 <div class="row">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                         <asp:CheckBox runat="server" ID="CheckBox15" Text="&nbsp; Vomiting" />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox16" Text="&nbsp; Pain " />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox19" Text="&nbsp; Soakage " />
                                          </div>
                                           </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox20" Text="&nbsp; Fever " />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox21" Text="&nbsp; Tachycardia " />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="CheckBox22" Text="&nbsp; Hypotension " />
                                          </div>
                                           </div>
                                     </div>
                                <div class="row">
                                      <div class="col-sm-5" >
                                             <div class="form-group">
                                         <asp:CheckBox runat="server" ID="CheckBox17" Text="&nbsp; Inj.Buscopan 1 amp IV 8 hourly" />
                                          </div>
                                           </div>
                                      
                                     
                                     </div>
                               </div>
                            <div class="col-lg-12 mt-2">
                               <strong>Inform SOS:</strong> 
                                 <div class="row">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                         <asp:CheckBox runat="server" ID="CheckBox23" Text="&nbsp; Other Info" />
                                          </div>
                                           </div>
                                      <div class="col-sm-10" >
                                             <div class="form-group">
                                          <asp:TextBox runat="server" ID="txtotherinfo" CssClass="form-control" TextMode="MultiLine"  />
                                          </div>
                                           </div>
                                    
                                     </div>
                               
                               </div>
                           
                       
                             <div class="row mt-3 mb-3" >
                                    <div class="col-lg-12 text-center" >
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Text="Report" OnClick="btnClear_Click" />
                                         <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                    </div>
                                </div>

                           
                            
                           <%--  </div>--%>
                             
                            </div>
                  </div>
                   
            </section>


            


        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>


    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
     <script src="plugins/Emergency.js"></script>
        <script>
            $(document).ready(function () {
                var speed = 500;
                function effectFadeIn(classname) {
                    $("." + classname).fadeOut(speed).fadeIn(speed, effectFadeOut(classname))
                }
                function effectFadeOut(classname) {
                    $("." + classname).fadeIn(speed).fadeOut(speed, effectFadeIn(classname))
                }
                //Calling fuction on pageload
                $(document).ready(function () {
                    effectFadeIn('flashingTextcss');
                });
            });
  </script>
     
</asp:Content>

