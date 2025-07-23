<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="StaticialReport.aspx.cs" Inherits="StaticialReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtPatientCat").value == "") {
                 alert("Please Enter Patient Category");
                 return false;
             }
         }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Report</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                       <!-- <div class="box-header with-border">
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>-->

                        <div class="box-body">
                            <div class="row">
                               
                                <div class="col">
                                    <div class="form-group">    
                                     <asp:Button ID="BtnTotalPAtientCount" runat="server"  CssClass="btn btn-primary w-100"  Text="Total OPD All Patient " OnClick="BtnTotalPAtientCount_Click" />
                                   </div>
                                </div>
                               
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btntotalwomenPat" runat="server"  CssClass="btn btn-primary w-100"  Text="Total Womeans Patient " OnClick="btntotalwomenPat_Click" />
                                   </div>
                                </div>
                              
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btntotalchild" runat="server"  CssClass="btn btn-primary w-100"  Text="Total Chlidren Patient " OnClick="btntotalchild_Click" />
                                   </div>
                                </div >
                                
                               <div class="col">
                                    <div class="form-group"> 
                                       
                <asp:Button ID="btntotal0to9" runat="server"  CssClass="btn btn-primary w-100"  Text="Total Chlidren Patient(0 to 9 Years) " OnClick="btntotal0to9_Click" />
                                   </div>
                                </div>

                                
                            </div>
                            <div class="row mt-3">
                               
                                
                               <div class="col">
                                    <div class="form-group">    
                                     <asp:Button ID="btnbelow6day" runat="server"  CssClass="btn btn-primary w-100"  Text="Below 6 Day Patient " OnClick="btnbelow6day_Click"  />
                                   </div>
                                </div>

                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnmalechildren" runat="server"  CssClass="btn btn-primary w-100 w-100"  Text="Total Male Children " OnClick="btnmalechildren_Click"   />
                                   </div>
                                </div>
                              
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnTotalFemailchildren" runat="server"  CssClass="btn btn-primary w-100"  Text="Total Femal Chlidren  " OnClick="btnTotalFemailchildren_Click"  />
                                   </div>
                                </div >
                                
                               <div class="col">
                                    <div class="form-group"> 
                                       
                <asp:Button ID="btnAllVital" runat="server"  CssClass="btn btn-primary w-100"  Text="All Patient Vital Report" OnClick="btnAllVital_Click" />
                                   </div>
                                </div>
                            </div>
                            <div class="row mt-3">
                               
                                <div class="col">
                                    <div class="form-group">    
                                     <asp:Button ID="btnMalariaPatient" runat="server"  CssClass="btn btn-primary w-100"  Text="Malaria Patient" OnClick="btnMalariaPatient_Click"   />
                                   </div>
                                </div>
                               
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnAncVisit" runat="server"  CssClass="btn btn-primary w-100"  Text="ANC Visit Patient " OnClick="btnAncVisit_Click"    />
                                   </div>
                                </div>
                              
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnaltrasoundscan" runat="server"  CssClass="btn btn-primary w-100"  Text="Altrasound Scan" OnClick="btnaltrasoundscan_Click"   />
                                   </div>
                                </div >
                                
                               <div class="col">
                                    <div class="form-group">                                        
                <asp:Button ID="btnNeonatal" runat="server"  CssClass="btn btn-primary w-100"  Text="Neonatal tetanus prophylaxis" OnClick="btnNeonatal_Click" />
                                   </div>
                                </div 
                            </div>
                            <div class="row mt-3">
                               <div class="col">
                                    <div class="form-group">    
                                     <asp:Button ID="btnMalariaprophylaxis" runat="server"  CssClass="btn btn-primary w-100"  Text="Malaria Prophylaxis" OnClick="btnMalariaprophylaxis_Click"   />
                                   </div>
                                </div>
                                <div class="col">
                                    <div class="form-group"> 
                                        <asp:Button ID="btnSyphilis" runat="server"  CssClass="btn btn-primary w-100"  Text="Syphilis infection" OnClick="btnSyphilis_Click"    />
                                       
                                        </div>
                                    </div>
                                 <div class="col">
                                    <div class="form-group"> 
                                        
                                         <asp:Button ID="btnhivCount" runat="server"  CssClass="btn btn-primary w-100"  Text="Total Hiv Test Count" OnClick="btnhivCount_Click"   />
                                        </div>
                                    </div>
                                 <div class="col">
                                    <div class="form-group"> 
                                        <asp:Button ID="btnhivpositivecount" runat="server"  CssClass="btn btn-primary w-100"  Text="HIV Positive Count" OnClick="btnhivpositivecount_Click"    />
                                        </div>
                                    </div>
                                </div>
                              <div class="row mt-3">                               
                                <div class="col">
                                    <div class="form-group">    
                         <asp:Button ID="btnIntermittentpreventive" runat="server"  CssClass="btn btn-primary w-100"  Text="Intermittent Preventive Treatment Count" OnClick="btnIntermittentpreventive_Click"     />
                                       
                                   </div>
                                </div>
                               
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnnumberofdeliveres" runat="server"  CssClass="btn btn-primary w-100"  Text="Number of deliveries Count" OnClick="btnnumberofdeliveres_Click"     />
                                   </div>
                                </div>
                              
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnnormaldelivery" runat="server"  CssClass="btn btn-primary w-100"  Text="Normal Delivery" OnClick="btnnormaldelivery_Click"   />
                                   </div>
                                </div >
                                
                               <div class="col">
                                    <div class="form-group">
                                        
                <asp:Button ID="btnCaesarean" runat="server"  CssClass="btn btn-primary w-100"  Text="Caesarean" OnClick="btnCaesarean_Click" />
                                   </div>
                                </div >
                            </div>

                             <div class="row mt-3">
                               
                                <div class="col">
                                    <div class="form-group">    
                                     <asp:Button ID="btnPostnatalvisit" runat="server"  CssClass="btn btn-primary w-100"  Text="Postnatal Clinic Visit"   />
                                   </div>
                                </div>
                               
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btncontraceptive" runat="server"  CssClass="btn btn-primary w-100"  Text="Contraceptive" OnClick="btncontraceptive_Click"    />
                                   </div>
                                </div>
                              
                                <div class="col">
                                    <div class="form-group">                                     
                                
                                       <asp:Button ID="btnImmunization" runat="server"  CssClass="btn btn-primary w-100"  Text="Immunization" OnClick="btnImmunization_Click"   />
                                   </div>
                                </div >
                                
                               <div class="col">
                                    <div class="form-group"> 
                                       <asp:Button ID="btnMaterinalDeath" runat="server"  CssClass="btn btn-primary w-100"  Text="Maternal and Perinatal Deaths Reviews " OnClick="btnMaterinalDeath_Click" />
                                       <%-- EmONC Count--%>
                                   </div>
                                </div >
                            </div>
                        </div>
                    </div>
                  
                </section>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
