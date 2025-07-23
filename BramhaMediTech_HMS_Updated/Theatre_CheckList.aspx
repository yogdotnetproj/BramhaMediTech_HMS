<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="Theatre_CheckList.aspx.cs" Inherits="Theatre_CheckList" %>

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
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Theatre CheckList</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Theatre CheckList</li>
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
                                     
                                       <div class="col-lg-1" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     Allergies:
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-11 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                            <asp:TextBox ID="txtAllergies" runat="server"  class="form-control" TextMode="MultiLine" ></asp:TextBox>  
                                                            </div>
                                           </div>   
                                     </div>
                    </div> 
                  <div id="Div2" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row mt-2"> 
                                    
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkSignedConsent" runat="server"   Text="SIGNED CINSENT FORM" ></asp:CheckBox> 
                                                        </div>
                                                    </div>
                                         
                                     </div>
                       <div class="row mt-2"> 
                                    
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkNameLabel" runat="server"   Text="NAME LABELS-Major cases-4,Cases with Sedation-3 and Local cases-1" ></asp:CheckBox> 
                                                        </div>
                                                    </div>
                                         
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkBloodWorksReq" runat="server"   Text="BLOOD WORKS AS REQUESTED" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkIVAccess" runat="server"   Text="*IV Access / IV FLUIDS" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkIVAntibiotic" runat="server"   Text="*IV AntiBiotics" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkPainSuppoistory" runat="server"   Text="Pain Supposotory" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                        <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                           <strong>To BE REMOVED</strong>
                                           </div>
                            </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkDENTURES" runat="server"   Text="DENTURES" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkChHairClip" runat="server"   Text="HAIR CLIPS/PINS" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkJEWELLERY" runat="server"   Text="JEWELLERY" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkUnderwear" runat="server"   Text="*UNDERWEAR" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-6" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkPROSTHESIS" runat="server"   Text="PROSTHESIS" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkSPECTACLES" runat="server"   Text="SPECTACLES" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                         
                                     </div>
                        <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                            Patients should always be accompanied by a Nurse to the Operating Theatre.
                                           </div>
                            </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                         <strong>Chart should have the followings.</strong>
                                           </div>
                            </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkVitals" runat="server"   Text="Vital Signs/Weight/Height" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                       
                                     </div>
                      <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkUrinanalysis" runat="server"   Text="Urin analysis for sugar and albumin.If sugar is positive do a RBS.If this is above normal limits blood sugar is checked and charted 4 hourly," ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                       
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group"> 
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                            also a HB A1C is requested.
                                                            </div>

                                       </div>
                           </div>
                         <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkTreatmentSheet" runat="server"   Text="Treatment Sheet" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                       
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkIVFluid" runat="server"   Text="If patient has IV Fluids an intake / Output Chart is required" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                       
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkXray" runat="server"   Text="*X-ray /ECG/Ultrasound Results" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                       
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-12" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkOrthopaedic" runat="server"   Text="Orthopaedic/Urology Patients-most recent X-ray" ></asp:CheckBox> 
                                                        </div>
                                                    </div>                                       
                                     </div>
                       <div class="row mt-2">                                     
                                       <div class="col-lg-1" >
                                           <strong>Remarks</strong>
                                           </div>
                           <div class="col-lg-11" >
                                            <asp:TextBox ID="txtRemarks" runat="server"  class="form-control" TextMode="MultiLine"  ></asp:TextBox>
                                           </div>
                           </div>
                    </div> 
                 
                 

                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server"  Text="Save" class="btn btn-success btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-warning btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
                <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:450px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="TCheckId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" Visible="false" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                <asp:BoundField DataField="TCheckId" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="Allergies" HeaderText="Allergies" />
                                    <asp:BoundField DataField="SignconsentForm"  HeaderText="SignconsentForm" />
                                    <asp:BoundField DataField="Remarks"  HeaderText="Remarks" />
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


