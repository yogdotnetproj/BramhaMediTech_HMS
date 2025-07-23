<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="MaternalPatientInfo.aspx.cs" Inherits="MaternalPatientInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />       
        </Triggers>
         <ContentTemplate>
                

     <section class="content-header d-flex">
        <h1>Maternal Patient Info</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Maternal Patient Info</li>
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
                  <div class="col-lg-12 mt-2">
                     <strong>Social History:</strong>
                    <div class="row">
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 Smoking:
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server"  ID="ChkSmokeNever" Text="Never" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkSmokePerDay" Text="1-5 Cigarette Per Day" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkSmokePackPer" Text="1 Pack Per Day" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkSmokePackPer1" Text=">1 Pack Per Day" />
                                 </div>
                            </div>
                        
                        
                       
                        </div>

                      </div>
                       <div class="col-lg-12 mt-2">

                         <div class="row">
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 Alcohol:
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkAlcohol" Text="Never" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkOccasionally" Text="Occasionally" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkHeavyDrinks" Text="Heavy Drinks" />
                                 </div>
                            </div>
                        </div>
                           </div>
                            <div class="col-lg-12 mt-2">
                      
                         <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Recreational Drugs:
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkRecrelDrugs" Text="Never" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkRecreDrugsOccasionally" Text="Occasionally" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkRecreDrugReg" Text="Regular user" />
                                 </div>
                            </div>
                        </div>
                                </div>
                                 <div class="col-lg-12 mt-2">
                      <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Allergise:
                                 </div>
                            </div>
                          <div class="col-lg-10 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtAllergies" TextMode="MultiLine" placeholder="Allergise" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                                     </div>
                                      <div class="col-lg-12 mt-2">
                      <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Food Preferences:
                                 </div>
                            </div>
                          <div class="col-lg-10 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtFoodPreferences" TextMode="MultiLine" placeholder="Food Preferences" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                                          </div>
                                           <div class="col-lg-12 mt-2">
                       <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Chief Complaints:
                                 </div>
                            </div>
                          <div class="col-lg-10 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtChiefComplaints" TextMode="MultiLine" placeholder="Chief Complaints" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                                               </div>
                                                <div class="col-lg-12 mt-2">
                       <div class="row">
                            <div class="col-lg-2 text-left">
                             <div class="form-group">
                               
                                 </div>
                            </div>
                         <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="chklowerAbPain" Text="Lower abdominal pains" />
                                 </div>
                            </div>
                          <div class="col-lg-6 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtlowerAbPain"  placeholder="Lower abdominal pains" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                           </div>

                         <div class="col-lg-12 mt-2">
                      <div class="row">
                            <div class="col-lg-2 text-left">
                             <div class="form-group">
                               
                                 </div>
                            </div>
                         <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkRegulContra" Text="Regular/Irregular Contractions" />
                                 </div>
                            </div>
                          <div class="col-lg-6 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txRegulContra"  placeholder="Regular/Irregular Contractions" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                             </div>
                              <div class="col-lg-12 mt-2">
                        <div class="row">
                            <div class="col-lg-2 text-left">
                             <div class="form-group">
                               
                                 </div>
                            </div>
                         <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkBleedingShow" Text="Bleeding/Show " />
                                 </div>
                            </div>
                          <div class="col-lg-6 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtBleedingShow"  placeholder="Bleeding/Show" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                                  </div>
                                   <div class="col-lg-12 mt-2">
                       <div class="row">
                            <div class="col-lg-2 text-left">
                             <div class="form-group">
                               
                                 </div>
                            </div>
                         <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkHeavybleeding" Text="Heavy bleeding per vagina " />
                                 </div>
                            </div>
                          <div class="col-lg-6 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtHeavybleeding"  placeholder="Heavy bleeding per vagina" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                                       </div>
                                        <div class="col-lg-12 mt-2">
                        <div class="row">
                            <div class="col-lg-2 text-left">
                             <div class="form-group">
                               
                                 </div>
                            </div>
                         <div class="col-lg-4 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkDrainingliquor" Text="Draining liquor" />
                                 </div>
                            </div>
                          <div class="col-lg-6 text-left">
                             <div class="form-group">
                                   <asp:TextBox ID="txtDrainingliquor"  placeholder="Draining liquor" CssClass="form-control"   runat="server" />
                                 </div>
                              </div>
                          </div>
                                            </div>
                                             <div class="col-lg-12 mt-2">

                        <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Examination Finding:
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkHealthylooking" Text="Healthy Looking" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkSicklooking" Text="Sick Looking" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkEdematousslight" Text="Edematous slight" />
                                 </div>
                            </div>
                              <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkEdematoussevere" Text="Edematous severe" />
                                 </div>
                            </div>
                        </div>
</div>
                                                  <div class="col-lg-12 mt-2">

                       <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                               
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:Label runat="server" ID="label1" Text="Height of fundus:" />
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 
                                 <asp:TextBox runat="server" ID="txtheightoffunds"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                            <div class="col-lg-1 text-left">
                             <div class="form-group">
                                  <asp:Label runat="server" Font-Bold="true" ID="label4" Text="cm" />
                                 </div>
                                </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:Label runat="server" ID="label2" Text="Presenting part:" />
                                 </div>
                            </div>
                              <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server"  ID="txtPresentingPart" CssClass="form-control"  Text=" " />
                                 </div>
                            </div>
                           <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:Label runat="server" ID="label3" Text="Fetal heart:" />
                                 </div>
                            </div>
                              <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtFetalheart" CssClass="form-control"  Text=" " />
                                 </div>
                            </div>
                        </div>

                                          </div> 
                                                       <div class="col-lg-12 mt-2">           

                       <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                              <strong>  Vaginal Examination:</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Diagnosis:
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkEstablishedlabor" Text="Established labor" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkNotinlabor" Text="Not in labor" />
                                 </div>
                            </div>
                             
                        </div>
</div>
                                                            <div class="col-lg-12 mt-2">
                        <strong>Obstetric Information:</strong>
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Antenatal Clinic:
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtAntenatalClinic"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  Clinic Card seen:
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:RadioButtonList ID="rblcardSeen" runat="server" RepeatDirection="Horizontal">
                                     <asp:ListItem Value="Yes" >Yes</asp:ListItem>
                                     <asp:ListItem Value="No">No</asp:ListItem>
                                 </asp:RadioButtonList>
                                 </div>
                            </div>
                      
                        
                        
                       
                        </div>

                                                                </div>
                                                                 <div class="col-lg-12 mt-2">
                       <strong> Blood Test:</strong>
                      <div class="row">
                           <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                     <asp:CheckBox runat="server" ID="ChkHb" Text="Hb" />
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtHB"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                    <asp:CheckBox runat="server" ID="ChkBloodsugar" Text="Blood Group" />
                                 </div>
                            </div>
                           <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtBloodSugar"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkVDRL" Text="VDRL" />
                                 </div>
                            </div>
                            <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtVDRL"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                       
                        </div>
</div>
                                                                      <div class="col-lg-12 mt-2">
                        <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkHiv" Text="HIV" />
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHIV"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                              <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkSullivan" Text="O' Sullivan's Test" />
                                 </div>
                            </div> 
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSullivan"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>  
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                    <asp:CheckBox runat="server" ID="ChkHepB" Text="Hep B" />
                                 </div>
                            </div>
                         <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtHepB"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                                       
                        
                        </div>
                                                                          
</div>
                 <div class="col-lg-12 mt-2">
                        <div class="row">
                             <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkSicklingTest" Text="Sickling Test" />
                                 </div>
                            </div>
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 <asp:TextBox runat="server" ID="txtSicklingTest"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                            </div>
                     </div>
                                                                           <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 LMP
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                   
                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtLMP" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   EDD
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtEDD"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                               Gestational age
                                 </div>
                            </div>                    
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtGestationalTest"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        </div>
</div>
 <div class="col-lg-12 mt-2">
                     
                       <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 1st ANC Visit:
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:CheckBox runat="server" ID="ChkAncbef14" Text="Before 14 Wks" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkAncbef20" Text="14 to 20  Wks" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkAncaft20" Text="After 20  Wks" />
                                 </div>
                            </div>                                       
                        
                        </div>
     </div>
      <div class="col-lg-12 mt-2">
                        <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                Ultrasound:
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:CheckBox runat="server" ID="ChkUltrabef14" Text="Before 14 Wks" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkUltraft14" Text="14 to 20  Wks" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkUltraaft20" Text="After 20  Wks" />
                                 </div>
                            </div>                                       
                        
                        </div>
          </div>
           <div class="col-lg-12 mt-2">

                        <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 Parity
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtParity"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   Number of Abortion
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtnumberofAbortion"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                               Number of miscarriages
                                 </div>
                            </div>                    
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtnumberofmiscarriages"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        </div>
               </div>
                <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                 Number of children alive
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtnumberofchild"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   Previous Pregancies
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtPreviousPre"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                    </div>
                     <div class="col-lg-12 mt-2">

                      <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                               Date/Year
                                 </div>
                                 </div>
                        <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                                   Gestational age
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                   Type of Delivery
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 Alive/Dead
                                 </div>
                            </div>                        
                        </div>
                         </div>
                          <div class="col-lg-12 mt-2">
                       <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                           
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdate1" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                                 </div>
                        <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txtGestationalage1"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txttypeodDeliv1"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtalive1"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                              </div>
                               <div class="col-lg-12 mt-2">
                       <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                          
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdate2" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                                 </div>
                        <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txtGestationalage2"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txttypeodDeliv2"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtalive2"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                                   </div>
                                    <div class="col-lg-12 mt-2">
                       <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                           
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdate3" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                                 </div>
                        <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txtGestationalage3"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txttypeodDeliv3"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtalive3"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                                        </div>
                                         <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                            
                                   <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdate4" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                 </div>
                                 </div>
                        <div class="col-lg-3 text-left">                          
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txtGestationalage4"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                  
                                 <asp:TextBox runat="server" ID="txttypeodDeliv4"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                               <asp:TextBox runat="server" ID="txtalive4"  CssClass="form-control" Text=" "></asp:TextBox>
                                 </div>
                            </div>                        
                        </div>
                                             </div>
                                              <div class="col-lg-12 mt-2">


                         <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                Past Medical History:
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:CheckBox runat="server" ID="ChkPMHHypertension" Text="Hypertension" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHDiabetes" Text="Diabetes" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="CHKPMHSickle" Text="Sickle Cell Disease" />
                                 </div>
                            </div>  
                             <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHAsthma" Text="Asthma" />
                                 </div>
                            </div>
                              <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHThyroid" Text="Thyroid disease" />
                                 </div>
                            </div>                                       
                        
                        </div>
                                                  </div>
                                                   <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                               
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:CheckBox runat="server" ID="ChkPMHEpilepsy" Text="Epilepsy" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHHepatitis" Text="Hepatitis" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHKidneyDisease" Text="Kidney Disease" />
                                 </div>
                            </div>  
                             <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHHiv" Text="HIV" />
                                 </div>
                            </div>
                              <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkPMHOther" Text="Other" />
                                 </div>
                            </div>                                       
                        
                        </div>
</div>
                                                        <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                Family History:
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:CheckBox runat="server" ID="ChkFHHypertension" Text="Hypertension" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHDiabetes" Text="Diabetes" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="CHKFHSickle" Text="Sickle Cell Disease" />
                                 </div>
                            </div>  
                             <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHAsthma" Text="Asthma" />
                                 </div>
                            </div>
                              <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHThyroid" Text="Thyroid disease" />
                                 </div>
                            </div>                                       
                        
                        </div>

                                                   </div>         
                                                             <div class="col-lg-12 mt-2">
                       <div class="row">
                             <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                               
                                 </div>
                                 </div>
                        <div class="col-lg-2 text-left">                          
                             <div class="form-group">
                                  <asp:CheckBox runat="server" ID="ChkFHEpilepsy" Text="Epilepsy" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHHepatitis" Text="Hepatitis" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHKidneyDisease" Text="Kidney Disease" />
                                 </div>
                            </div>  
                             <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHHiv" Text="HIV" />
                                 </div>
                            </div>
                              <div class="col-lg-2 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkFHOther" Text="Other" />
                                 </div>
                            </div>                                       
                        
                        </div>
                 </div>
                  
                  <div class="col-lg-12 mt-2">

                       <div class="row">
                             <div class="col-lg-12 text-center">                          
                             <div class="form-group">
                                 <asp:Button ID="btnSave" runat="server" Text="Save"  class="btn btn-success" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-warning" OnClick="btnReport_Click" />
                                 </div>
                                 </div>
                           </div>
                      </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="InfoId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" 
                                    AllowPaging="True" BackColor="White"  
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="30" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image"  EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        <asp:BoundField DataField="Allergise" HeaderText="Allergise"  />
                                        
                                        <asp:BoundField DataField="FoodPreferences" HeaderText="FoodPreferences"  />
                                        <asp:BoundField DataField="ChiefComplaints" HeaderText="ChiefComplaints"  />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On " DataFormatString="{0:dd/MM/yyyy}"  />
                                         
                                     
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
                   </section>

             <script language="javascript" type="text/javascript">
                 function OpenReport() {

                     window.open("Reports.aspx");
                 }
               </script>
             </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

