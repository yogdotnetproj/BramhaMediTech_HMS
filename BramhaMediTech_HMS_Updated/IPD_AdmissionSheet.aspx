<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="IPD_AdmissionSheet.aspx.cs" Inherits="IPD_AdmissionSheet" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
   .custom 
   {
       width: 50%;
   }
</style> 
    <script type="text/javascript">
     function numeric_only(e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (event)
            keycode = event.keyCode;
        else if (e)
            keycode = e.which;
        else
            return true;
        if ((keycode == 45) || (keycode == 46) || (keycode >= 48 && keycode <= 57)) {
            return true;
        }
        else {
            return false;
        }
        return true;
    }

    function alpha_only(e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (event)
            keycode = event.keyCode;
        else if (e)
            keycode = e.which;
        else
            return true;
        if ((keycode == 32) || (keycode >= 65 && keycode <= 90) || (keycode >= 97 && keycode <= 122)) {
            return true;
        }
        else {
            return false;
        }
        return true;
    }

    function AlphaNumeric(e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (event)
            keycode = event.keyCode;
        else if (e)
            keycode = e.which;
        else
            return true;
        if ((keycode == 32) || (keycode == 38 || keycode == 45) || (keycode >= 47 && keycode <= 57) || (keycode >= 65 && keycode <= 90) || (keycode >= 97 && keycode <= 122)) {
            return true;
        }
        else {
            return false;
        }
        return true;
    }
        </script>
    <script type="text/javascript" src="Scripts/jquery-3.1.1.js"></script>
<script type="text/javascript" src="select2-master/select2.js"></script>
<link href="css/select2.css" rel="stylesheet" />
     <script type="text/javascript">
         $(document).ready(function () {
             $("#ddlBillServices").select2({
                 placeholder: "Select an option",
                 allowClear: true
             });
         });
 </script>
        <style>
    /* Make the header sticky */
    .FixedHeader {
        position: sticky;
        top: 0;
        background-color: #38C8DD;
        z-index: 10; /* Ensure it stays above the grid rows */
    }

    /* Add box-shadow to the header for better visual separation */
    .table th {
        box-shadow: 0 2px 5px rgba(0,0,0,0.1);
    }

    /* Ensure the GridView has enough space for the header to stick */
    .table-wrapper {
        max-height: 500px; /* Set a maximum height for the grid */
        overflow-y: auto;  /* Allow scrolling */
    }
</style>
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
          
          
             
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>On Admission Sheet Details</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">On Admission Sheet Details</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                  
                    <div class="box-body">
                     <div class="col-lg-12" runat="server" visible="false">
                                                <div class="row"> 
                                <div class="col-lg-1 text-left" >

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                                            <asp:ListItem Value="All">All</asp:ListItem>
                                                              <asp:ListItem Value="Consultation">Consultation</asp:ListItem>
                                                             <asp:ListItem Value="Lab">Lab</asp:ListItem>
                                                             <asp:ListItem Value="Room" Selected="True">Room</asp:ListItem>
                                                             <asp:ListItem Value="Drugs" >Drugs</asp:ListItem>
                                                             <asp:ListItem Value="Other">Other</asp:ListItem>
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                    </div>
                                    </div>
                           <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-10">
                                    <div class="form-group">
                                         <asp:label id="Label16" runat="server"  Text="Does the patients have any cultural or religious needs that should be addressed?(Does the patient have any food preferences?):" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="rblCulture" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                               </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label17" runat="server"  Text="Describe" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-7">
                                    <div class="form-group">
                                       <asp:textbox id="txtdescribe" TextMode="MultiLine"  CssClass="form-control" runat="server"   placeholder="Describe"></asp:textbox>
                                        
                                        </div>
                                    </div>
                            </div>
                              </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                             <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label9" runat="server" Font-Bold="true" Text="Height(cm):" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtheight" runat="server" CssClass="form-control"   placeholder="Enter Height(cm)"></asp:textbox>
                                        </div>
                                    </div>
                             <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label12" runat="server" Font-Bold="true" Text="weight(kg):" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtweight"  runat="server" CssClass="form-control"  placeholder="Enter weight(kg)"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                             </div>
                          <div class="col-lg-12 mt-3 " >
                                Vital Signs:
                        <div class="row" style="padding-bottom: 5px">
                          
                                <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label11" runat="server" Font-Bold="true" Text="BP(mmHg):" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtBP" runat="server" CssClass="form-control" placeholder="BP(mmHg)"></asp:textbox>
                                        </div>
                                    </div>
                             <div class="col-lg-6">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="rblBpType" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Lying</asp:ListItem>
                                            <asp:ListItem Value="2">Sitting</asp:ListItem>
                                            <asp:ListItem Value="3">Standing</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                              </div>
                         <div class="col-lg-12 mt-3 " >
                         <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label10" runat="server" Font-Bold="true" Text="pulse/min:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtpulse" runat="server" CssClass="form-control"   placeholder="Enter pulse/min"></asp:textbox>
                                        </div>
                                    </div>
                              <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label8" runat="server" Font-Bold="true" Text=" Resp./min:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtResp"  runat="server" CssClass="form-control"   placeholder="Resp./min"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label7" runat="server" Font-Bold="true" Text="Temp:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtTemp" runat="server" CssClass="form-control"   placeholder="Enter Temp"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                            </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-4">
                                    <div class="form-group">
                                         <asp:label id="Label18" runat="server" Font-Bold="true" Text="Last PO Intake(What did the Patient Eat?):" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-4">
                                    <div class="form-group">
                                       <asp:textbox id="txtlastpoIntake" TextMode="MultiLine"  CssClass="form-control" runat="server"   placeholder="Last PO Intake"></asp:textbox>
                                        
                                        </div>
                                    </div>
                            </div>
                             </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label19" runat="server"  Text="Date of last PO Intake:" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtlastpodateintake" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label21" runat="server"  Text="Time of last PO Intake:" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:TextBox id="txtlasttimepointak"   CssClass="form-control" runat="server"   placeholder="Time of last PO Intake"></asp:TextBox>
                                      
                                        </div>
                                    </div>
                            </div>
                              </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label20" runat="server"  Text="Last Voided Urine:" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtlastvoidedurinedate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label22" runat="server"  Text="Time Last Voided Urine:" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:TextBox id="txtlastvoidedurinetime"   CssClass="form-control" runat="server"   placeholder="Time of Last Voided Urine"></asp:TextBox>
                                      
                                        </div>
                                    </div>
                            </div>
                              </div>
                             <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label23" runat="server"  Text="Last Bowel Movement :" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtlastbowelmovementdate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label24" runat="server"  Text="Time Last Bowel Movement:" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:TextBox id="txtlastbowelmovementtime"   CssClass="form-control" runat="server"   placeholder="Time of Last Bowel Movement"></asp:TextBox>
                                      
                                        </div>
                                    </div>
                            </div>
                              </div>

                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label25" runat="server"  Text="Vision :" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-10">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="RblVision" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Blind</asp:ListItem>
                                            <asp:ListItem Value="3">Use Glasses/contacts</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                              </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label26" runat="server"  Text="Hearing :" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-10">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="rblHearing" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Deaf</asp:ListItem>
                                            <asp:ListItem Value="3">Use Hearing Aid</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                              </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label27" runat="server"  Text="Speech :" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-10">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="RblSpeech" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Unable to speak</asp:ListItem>
                                            <asp:ListItem Value="3">Impaired(Slurred Speech,Aphasic etc)</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                              </div>
                              <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label28" runat="server"  Text="Ambulation :" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-10">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="rblAmbulation" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Bed Bound</asp:ListItem>
                                            <asp:ListItem Value="3">Use cane/Walker</asp:ListItem>
                                            <asp:ListItem Value="4">Wheelcheer</asp:ListItem>
                                             <asp:ListItem Value="5">Crutches</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                              </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-6">
                                    <div class="form-group">
                                         <asp:label id="Label29" runat="server"  Text="Do you have any money,jewellery or other valuables to declare for safe keeping" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="rbldeclaration" RepeatDirection="Horizontal">
                                            <asp:ListItem  Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            </div>
                               </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-12">
                                    <div class="form-group">
                                         <asp:label id="Label30" runat="server" Font-Bold="true"  Text=" Management will not be responsible for loss of money or other valuable not declared at the time of admission and not place in our safe keeping." ></asp:label>
                                        </div>
                                    </div>
                            
                            </div>
                               </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label31" runat="server"   Text="Patient /Relative Name" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-4">
                                    <div class="form-group">
                                         <asp:textbox id="txtrelativename"  CssClass="form-control" runat="server"   placeholder="Patient /Relative Name"></asp:textbox>
                                      
                                        </div>
                                </div>
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label32" runat="server"   Text="Date" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-2">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtrelativedate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                      
                                        </div>
                                </div>
                            </div>
                               </div>
                               <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label33" runat="server"   Text="Witness Name" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-4">
                                    <div class="form-group">
                                         <asp:textbox id="txtwitnessname"  CssClass="form-control" runat="server"   placeholder="Witness Name"></asp:textbox>
                                      
                                        </div>
                                </div>
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label34" runat="server"   Text="Date" ></asp:label>
                                        </div>
                                    </div>
                            <div class="col-lg-2">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtwitnessdate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                      
                                        </div>
                                </div>
                            </div>
                               </div>
                        <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                     <strong>  NURSE ASSESSMENT</strong> 
                                        </div>
                                </div>
                            </div>
                            </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label35" runat="server" Font-Bold="true" Text="Cheif Complaints(In Patient's own words )" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-10">
                                    <div class="form-group">
                                       <asp:textbox id="txtComplaints" TextMode="MultiLine"  CssClass="form-control" runat="server"   placeholder="Complaints"></asp:textbox>
                                        
                                        </div>
                                    </div>
                            </div>
                             </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label36" runat="server" Font-Bold="true" Text="Doctor's Diagnosis" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-10">
                                    <div class="form-group">
                                      <asp:textbox id="txtFinalDiagnosis" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Diagnosis"></asp:textbox>
  
                                        </div>
                                    </div>
                            </div>
                             </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label37" runat="server" Font-Bold="true" Text="Allergies(To food or medication)" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-10">
                                    <div class="form-group">
                                        <asp:textbox id="txtProvDiagnosis" TextMode="MultiLine"  runat="server" CssClass="form-control" placeholder="Enter Allergies"></asp:textbox>
                                      
                                        </div>
                                    </div>
                            </div>
                             </div>
                        <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                      
                                         <asp:label id="Label38" runat="server" Font-Bold="true" Text="Patient status" ></asp:label>
                                        </div>
                                </div>
                             <div class="col-lg-1">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="ChkAwake" Text="Awake"/>
                                        </div>
                                 </div>
                             <div class="col-lg-1">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="ChkAlert" Text="Alert"/>
                                        </div>
                                 </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="ChkOriented" Text="Oriented"/>
                                        </div>
                                 </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="ChkLethargic" Text="Lethargic"/>
                                        </div>
                                 </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="ChkDisoriented" Text="Disoriented"/>
                                        </div>
                                 </div>
                             <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="ChkComatose" Text="Comatose"/>
                                        </div>
                                 </div>
                            </div>
                            </div>
                           <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                     <strong> Medications (PRIOR TO ADMISSION)</strong> 
                                        </div>
                                </div>
                            </div>
                            </div>
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                         <asp:gridview ID="GvHairLaser" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Name" >

            <ItemTemplate>

                
                <asp:TextBox ID="txtName" Text='<%# Eval("Name") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="Dose" >

            <ItemTemplate>

                <asp:TextBox ID="txtDose" Text='<%# Eval("Dose") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Frequency" >

            <ItemTemplate>

                <asp:TextBox ID="txtFrequency" Text='<%# Eval("Frequency") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Time Of Last Dose" >

            <ItemTemplate>

                <asp:TextBox ID="txttimeoflastdose" Text='<%# Eval("LastDose") %>' CssClass="form-control" runat="server"></asp:TextBox>

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
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-12">
                                    <div class="form-group">
                                         <asp:label id="Label39" runat="server" Font-Bold="true" Text="Social History:(Does the patients drink alcohol,smoke cigarettes,uses,crack,cocaine,marijuana etc.  ):-" ></asp:label>
                                        </div>
                                    </div>
                            </div>
                             </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-12">
                                    <div class="form-group">
                                            <asp:textbox id="txtonAdmission" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Social History"></asp:textbox>
      
                                        </div>
                                </div>
                            </div>
                              </div>
                        <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label40" runat="server" Font-Bold="true" Text="Past Medical History:" ></asp:label>
                                        </div>
                                    </div>
                               
                            <div class="col-lg-10">
                                    <div class="form-group">
                                         <asp:textbox id="txtHistory" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter History"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                            </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label41" runat="server" Font-Bold="true" Text="Past Surgical History:" ></asp:label>
                                        </div>
                                    </div>
                               
                            <div class="col-lg-10">
                                    <div class="form-group">
                                         <asp:textbox id="txtsurgicalHistory" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Surgical History"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                            </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label42" runat="server" Font-Bold="true" Text="Signification Family History:" ></asp:label>
                                        </div>
                                    </div>
                               
                            <div class="col-lg-10">
                                    <div class="form-group">
                                         <asp:textbox id="txtFamilyHistory" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Signification Family History"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                            </div>
                          <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-6">
                                    <div class="form-group">
                                         <asp:label id="Label43" runat="server" Font-Bold="true" Text="WOUNDS OR DECUBITUS ULCERS:(Specify type of wound e.g.surgical wound,accidental wound etc.):-" ></asp:label>
                                        </div>
                                    </div>
                              <div class="col-lg-6">
                                    <div class="form-group">
                                         <asp:textbox id="txtWound" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter WOUNDS OR DECUBITUS ULCERS"></asp:textbox>
                                        </div>
                                    </div>
                            </div>

                            </div>
                         <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-6">
                                    <div class="form-group">
                                         <asp:label id="Label44" runat="server" Font-Bold="true" Text="size and location of wound or ulcer.Describle wound or ulcer:(type of drainage,odor and colours etc.):-" ></asp:label>
                                        </div>
                                    </div>
                              <div class="col-lg-6">
                                    <div class="form-group">
                                       <asp:textbox id="txtwouldsize" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter size and location of wound or ulcer"></asp:textbox>
                                     </div>
                                    </div>
                            </div>

                            </div>
                             </div>
                        <div class="col-lg-12 mt-3 " runat="server" visible="false" >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label1" runat="server" Font-Bold="true" Text="Complaints:" ></asp:label>
                                        </div>
                                    </div>
                               
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label2" runat="server" Font-Bold="true" Text="On Admission Details:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                         
                                        </div>
                                    </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label3" runat="server" Font-Bold="true" Text="Case Summery:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtcasesummary" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Case Summery"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                      </div>
                        <div class="col-lg-12 mt-3 " runat="server" visible="false"  >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label4" runat="server" Font-Bold="true" Text="Allergies:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          </div>
                                    </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label5" runat="server" Font-Bold="true" Text=" Diagnosis:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                         
                                                                                </div>
                                    </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label6" runat="server" Font-Bold="true" Text="History:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                         
                                        </div>
                                    </div>
                            </div>
                            </div>
                       
                       
      
                        <div class="col-lg-12 mt-3 " runat="server" visible="false"  >
                         <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label13" runat="server" Font-Bold="true" Text="Albumin:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtAlbumin" TextMode="MultiLine" CssClass="form-control" runat="server"  placeholder="Enter Albumin"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label14" runat="server" Font-Bold="true" Text="sugar :" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtsugar" TextMode="MultiLine" CssClass="form-control" runat="server"  placeholder="Enter sugar Details"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-lg-1">
                                    <div class="form-group">
                                         <asp:label id="Label15" runat="server" Font-Bold="true" Text="Blood:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtBlood" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter Blood Details"></asp:textbox>
                                        </div>
                                    </div>
                            </div>

                            </div>
                       
      
                        
                                        
                                       
                                          <div class="col-lg-12 text-center">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save"   OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" class="btn btn-success"  />
                                               
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary"/>
                                           
                                       <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Visible="false" OnClick="btnReport_Click" />

                             
                                         
                                             
                                        </div>    
                                        <div class="col-lg-12 mt-3">
                    <div class="row">
                         <div   class="table-wrapper" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-bordered"   HeaderStyle-CssClass="FixedHeader" Width="100%" DataKeyNames="Id"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                   <asp:BoundField DataField="CreatedOn" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="CreatedBy" HeaderText="Enter by" />
                                    <asp:BoundField DataField="IPD_Height" HeaderText="Height" />
                                    <asp:BoundField DataField="IPD_weight"  HeaderText="Weight" />
                                     <asp:BoundField DataField="IPD_BP" HeaderText="BP" />
                                    <asp:BoundField DataField="BpType"  HeaderText="Bp Type" />
                                     <asp:BoundField DataField="IPD_Temp"  HeaderText="Temp" />
                                     <asp:BoundField DataField="IPD_Resp"  HeaderText="Resp" />
                                     <asp:BoundField DataField="IPD_pulse" HeaderText="Pulse"  />
                                    <asp:BoundField DataField="IPD_ProvDiagnosis"  HeaderText="Allergies" />
                                     <asp:BoundField DataField="IPD_FinalDiagnosis"  HeaderText="Diagnosis" />
                                 <%--   <asp:BoundField DataField="IPD_History"  HeaderText="History" />--%>
                                    
                                    
                                  
                                <asp:ButtonField CommandName="Delete" Visible="false" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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

