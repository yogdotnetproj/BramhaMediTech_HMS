<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="FamilyPlanningForm.aspx.cs" Inherits="FamilyPlanningForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Family Planning</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Family Planning</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
          <!--  <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
                
                      
                 
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
               
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="txtHeight"  runat="server" Text="HCG:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtHCG" CssClass="form-control"  placeholder="HCG" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="txtBMI"   runat="server" Text="Leukocytes:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtLeukocytes" CssClass="form-control"  placeholder="Leukocytes" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="TextBox2"   runat="server" Text="Nitrite:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtNitrite" CssClass="form-control" placeholder="Nitrite" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                    <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label15"  runat="server" Text="Protein:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtProtein" CssClass="form-control" placeholder="Protein" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label16"   runat="server" Text="Glucose:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtGlucose" CssClass="form-control" placeholder="Glucose" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label17"   runat="server" Text="Blood:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBlood" CssClass="form-control" placeholder="Nitrite" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label18"  runat="server" Text="PH:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtPH" CssClass="form-control" placeholder="PH" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label19"   runat="server" Text="Specific Gravity:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtSpecificGravity" CssClass="form-control" placeholder="Specific Gravity" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label20"   runat="server" Text="Ketone:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtKetone" CssClass="form-control" placeholder="Ketone" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label21"  runat="server" Text="Urobilinogen:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtUrobilinogen" CssClass="form-control" placeholder="Urobilinogen" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label22"   runat="server" Text="Biliruben:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBiliruben" CssClass="form-control" placeholder="Biliruben" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                       
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtComment" CssClass="form-control" placeholder="Comment" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lbldsmoke"   runat="server" Text="Do u Smoke?"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rblsmoking" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtSmokeRemark" CssClass="form-control" placeholder="Smoke Remark" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="LblsmQu"   runat="server" Text="DateQuite(if applicable)"></asp:Label>
                                    </div>
                                </div>

                        <div class="col-lg-3  text-left">
                                        <div class="form-group">
                                           <%-- <label for="txtStart">Start Date:</label>--%>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" runat="server" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label1"   runat="server" Font-Bold="true" Text="Husband:"></asp:Label>
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkfatherachild" Text="Fathered a Child" runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkfathernevachild" Text="Has never Fathered a Child" runat="server" />

                                    </div>
                                </div>
                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label2"   runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="ChkOccuption" Text="Occuption" runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtHusremark" Text="" placeholder="Occuption" CssClass="form-control" runat="server" />

                                    </div>
                                </div>
                        
                        </div>
                     </div>
                   <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label5"   runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkTabacouse" Text="Tabacco Use" runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txttabaccouse" Text="" placeholder="Tabacco use" CssClass="form-control" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkdruguse" Text="Drug Use" runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtdrugyse" Text="" placeholder="Drug Use" CssClass="form-control" runat="server" />

                                    </div>
                                </div>
                        
                        </div>
                     </div>

                    <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label7"   runat="server" Font-Bold="true" Text="Menstrual Cycles"></asp:Label>
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-8 text-left">
                                    <div class="form-group">
                                       
                                         

                                    </div>
                                </div>
                         
                        
                        </div>
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkRegular" Text="Regular" runat="server" />
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtregular" Text="" CssClass="form-control" placeholder="Regular" runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="lbldays" Text="Days"  runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="ChkIrregular" Text="Irregular" runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtIrregular" CssClass="form-control" Text="" placeholder="Irregular"  runat="server" />

                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="lblirrdays" Text="Days"  runat="server" />

                                    </div>
                                </div>
                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkCoitalFrequency" Text="Coital Frequency" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-8 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtCoitalFrequency" CssClass="form-control" placeholder="Coital Frequency" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkDysmenorrhea" Text="Dysmenorrhea" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-8 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtDysmenorrhea" CssClass="form-control" placeholder="Dysmenorrhea" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="ChkPelvicPain" Text="Pelvic Pain" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-8 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtPelvicPain" CssClass="form-control" placeholder="Pelvic Pain" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblprevwor" Text="Previous Workup:" Font-Bold="true" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="ChkHSGResult" Text="HSG Result" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtHSgresult" CssClass="form-control" placeholder="HSG Result" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                    <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label8" Text=""  runat="server" />
                                       
                                    </div>
                                </div>                       
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chksemenanalysis" Text="Semen Analysis" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtSemenAnalysis" CssClass="form-control" placeholder="Semen Analysis" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" Text="Previous Assisstance:" Font-Bold="true" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkClomid" Text="Clomid" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtClomid" CssClass="form-control" placeholder="Clomid" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label10" Text="" runat="server" />
                                       
                                    </div>
                                </div>                       
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkGnRHAgonists" Text="GnRH Agonists" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtGnRHAgonists" CssClass="form-control" placeholder="GnRH Agonists" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" Text="" runat="server" />
                                       
                                    </div>
                                </div>                       
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="ChkIUI" Text="IUI" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtIUI" CssClass="form-control" placeholder="IUI " runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label12" Text="" runat="server" />
                                       
                                    </div>
                                </div>                       
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkIVF" Text="IVF" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtIVF" CssClass="form-control" placeholder="IVF " runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label13" Text="" runat="server" />
                                       
                                    </div>
                                </div>                       
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkHysteroscopy" Text="Hysteroscopy" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtHysteroscopy" CssClass="form-control" placeholder="Hysteroscopy " runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label14" Text="" runat="server" />
                                       
                                    </div>
                                </div>                       
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkLaparoscopy" Text="Laparoscopy" runat="server" />

                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtLaparoscopy" CssClass="form-control" placeholder="Laparoscopy " runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>


                
                 
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" />
                                         <asp:Button ID="BtnBirthRegister" runat="server" class="btn btn-primary btnSearch" Text="+" />
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>
            </div>
            
          
        </div>

    </section>
    <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="CheifPanel" TargetControlID="BtnBirthRegister"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="CheifPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Family Planning  :
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="FPId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="DouSmoke" HeaderText="DouSmoke "  />
                                        
                                        <asp:BoundField DataField="MenstrualCyclesRegular" HeaderText="Cycles Regular"  />
                                         <asp:BoundField DataField="MenstrualCyclesIrregular" HeaderText="Cycles Irregular"  />
                                       
                                         <asp:BoundField DataField="PelvicPain" HeaderText="Pelvic Pain "  />
                                         <asp:BoundField DataField="Dysmenorrhea" HeaderText="Dysmenorrhea"  />
                                          <asp:BoundField DataField="CoitalFrequency" HeaderText="Coital Frequency"  />
                                          
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  />
                                       <%-- <asp:BoundField DataField="chiefcomplaints" ItemStyle-Width="80%" HeaderText="Complaints"  />--%>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM1" runat="server" Text="Close" />
            </asp:Panel>
</asp:Content>


