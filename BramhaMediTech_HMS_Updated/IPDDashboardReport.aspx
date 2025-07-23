<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IPDDashboardReport.aspx.cs" Inherits="IPDDashboardReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <section class="content-header d-flex">
                <h1>IPD Dashboard Report</h1>
                <ol class="breadcrumb">
                       
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">IPD Dashboard Report</li>
                    </ol>
            </section>
    <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                
                                         <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                             <asp:Button ID="btnfrontsheetreport" Width="250px" runat="server" Text="Front Sheet" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="1" class="btn btn-primary"  OnClick="btnfrontsheetreport_Click"  />

                                                            </div>
                                             </div>
                                                <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                              <asp:Button ID="btnVitalSheet" Width="250px" runat="server" Text="Vital Sheet" 
                                             CausesValidation="False" TabIndex="2" class="btn btn-success" OnClick="btnVitalSheet_Click"    />

                                                            </div>
                                                    </div>
                                                 <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                              <asp:Button ID="btnIntake" Width="250px" runat="server" Text="Intake Output Sheet" 
                                             CausesValidation="False" TabIndex="3" class="btn btn-warning" OnClick="btnIntake_Click"     />

                                                            </div>
                                                    </div>
                                                 <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                              <asp:Button ID="btnNurseNote" Width="250px" runat="server" Text="Nurse Note" 
                                             CausesValidation="False" TabIndex="4" class="btn btn-danger" OnClick="btnNurseNote_Click"     />

                                                            </div>
                                                    </div>
                                                </div>
                        </div>
                         <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                
                                         <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                             <asp:Button ID="btndrNote" runat="server" Width="250px" Text="Doctor Notes" 
                                             CausesValidation="False" TabIndex="5" class="btn btn-danger" OnClick="btndrNote_Click"    />

                                                            </div>
                                             </div>
                                                <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                              <asp:Button ID="btnOtNoteReport" Width="250px" runat="server" Text="OT Note" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="6" class="btn btn-primary" OnClick="btnOtNoteReport_Click"  />
                                                            </div>
                                                    </div>
                                                <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                              <asp:Button ID="btnInvestigation" Width="250px" runat="server" Text="Investigation"
                                             CausesValidation="False" TabIndex="7" class="btn btn-success" OnClick="btnInvestigation_Click"   />
                                                            </div>
                                                    </div>
                                                 <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                              <asp:Button ID="btnTreatment" Width="250px" runat="server" Text="Treatment"
                                             CausesValidation="False" TabIndex="8" class="btn btn-warning" OnClick="btnTreatment_Click"   />
                                                            </div>
                                                    </div>

                                                </div>
                             </div>

                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                
                                         <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                             <asp:Button ID="btndischargesummary" Width="250px" runat="server" Text="Discharge Summary" 
                                             CausesValidation="False" TabIndex="9" class="btn btn-success" OnClick="btndischargesummary_Click"    />

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

