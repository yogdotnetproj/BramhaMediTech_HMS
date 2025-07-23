<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IpdDischargeSummary.aspx.cs" Inherits="IpdDischargeSummary" %>


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
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
          
          
             
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>IPD Discharge Summary</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">IPD Discharge Summary</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <!--<div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                 <asp:Label ID="lblMessage" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                               
                            </div>
                        </div>
                    </div>-->
            
                    <div class="box-body">
                     <div class="col-lg-12" runat="server" visible="false">
                                                <div class="row"> 
                                <div class="col-sm-1">

                                                    <div class="form-Inline form-check"> 
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
                         <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label1" runat="server" Text="Procedure Date:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control pull-right" placeholder="Enter Procedure Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                 <i class="fa fa-calendar"></i>
                                                            </span>
                                                 </div>
                                        
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label2" runat="server" Text="Procedure:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtProcedure"  CssClass="form-control" TextMode="MultiLine" runat="server"  placeholder="Procedure"></asp:TextBox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label3" runat="server" Text="Prov Diagnosis:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtProvDiagnosis"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Prov Diagnosis"></asp:TextBox>
                                        </div>
                                    </div>
                            </div>
                      </div>
                         <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label4" runat="server"  Text="Complaints:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtComplaints"  CssClass="form-control" TextMode="MultiLine"  runat="server" placeholder="Enter Complaints"></asp:TextBox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label5" runat="server" Text="Case summary:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtCaseSummary"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Case summary"></asp:TextBox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label6" runat="server" Text="Final Diagnosis:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtFinaldiagnosis"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Final Diagnosis"></asp:TextBox>
                                        </div>
                                    </div>
                            </div>
                             </div>
                         <div class="col-lg-12 mt-3">
                           <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label7" runat="server" Text="Surgeon:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtSurgan"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Surgeon details"></asp:TextBox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label8" runat="server" Text="OT Note:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:TextBox id="txtotNote"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="OT Note"></asp:TextBox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label9" runat="server" Text="Anesthesia:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtAnesthesia"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Anesthesia"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                             </div>
                         <div class="col-lg-12 mt-3">
                         <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label10" runat="server" Text="Anesthetist:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtAnesthetist"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Anesthetist details"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label11" runat="server" Text="On Admission Details :" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtonAdmissiondetails"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="On Admission Details"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label12" runat="server" Text="Treatment given:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txttreatmentgiven"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Treatment given"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
      </div>
                         <div class="col-lg-12 mt-3">
                         <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label13" runat="server" Text="Condition on Discharge:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtConondischarge"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Condition on Discharge"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label14" runat="server" Text="Reason for Discharge :" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtreasonfordischarge"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Reason for Discharge"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-sm-1 p-0">
                                    <div class="form-group">
                                         <asp:label id="Label15" runat="server" Text="Operation Note:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtOperationnote"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Operation Note"></asp:textbox>
                                        </div>
                                    </div>
                            </div>
                             </div>
                         <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label16" runat="server" Text="Next Follow Up:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                          <asp:textbox id="txtnextfollowup"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Enter Next Follow Up"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:textbox id="txtQty"   runat="server" Visible="false" CssClass="form-control"  placeholder="Qty"></asp:textbox>
                                        </div>
                                    </div>
                            <div class="col-sm-3">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtDrugName"  runat="server" AutoCompleteType="None"
                                                AutoPostBack="false" TabIndex="1" CssClass="form-control" placeholder="Search Drug Name">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender
                                                MinimumPrefixLength="1"
                                                ServiceMethod="GetDrugsName"
                                                CompletionInterval="100"
                                                EnableCaching="false"
                                                CompletionSetCount="10"
                                                TargetControlID="txtDrugName"
                                                ID="AutoCompleteExtender3"
                                                runat="server">
                                            </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                                <div class="col-sm-1">
                                    <div class="form-group">
                                        <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="false"
                                                class="form-control" 
                                                TabIndex="2" Height="30px">
                                                <asp:ListItem>1-1-1</asp:ListItem>
                                                <asp:ListItem>1-0-1</asp:ListItem>
                                                <asp:ListItem>0-1-1</asp:ListItem>
                                                 <asp:ListItem>1-1-0</asp:ListItem>
                                                <asp:ListItem>1-0-0</asp:ListItem>
                                                <asp:ListItem>0-1-0</asp:ListItem>
                                                <asp:ListItem>0-0-1</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                            <div class="col-sm-1">
                                    <div class="form-group">
                                        <asp:textbox id="txtdays" runat="server" CssClass="form-control" placeholder="Days"></asp:textbox>
                                        </div>
                                    </div>
                            
                            <div class="col-sm-1">
                                    <div class="form-group">
                                        <asp:Button ID="btnOK" runat="server" Text="OK"     
                                         class="btn btn-primary" OnClick="btnOK_Click"  />
                                        </div>
                                    </div>
                          
                            </div>
                       </div>
                         <div class="col-lg-12 mt-3">
                         <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label19" runat="server" Text="Treatment Advice:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-11">
                                    <div class="form-group">
                                            <asp:textbox id="txtTreatmentadvice"  CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="Treatment Advice"></asp:textbox>
                                        </div>
                                    </div>
                            
                          
                            </div>
                             </div>
                         <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div class="col-sm-1">
                                    <div class="form-group">
                                         <asp:label id="Label18" runat="server"  Text="General Remark:" ></asp:label>
                                        </div>
                                    </div>
                                <div class="col-sm-11">
                                    <div class="form-group">
                                          <asp:textbox id="txtGeneralRemark" TextMode="MultiLine"  CssClass="form-control" runat="server" placeholder="Enter General Remark"></asp:textbox>
                                        </div>
                                    </div>
                            
                          
                            </div>
                             </div>
      
                        
                                        
                                       
                                          <div class="col-lg-12 mt-3 text-center">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-success"  OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary"  />
                                               <asp:Button ID="btnrefund" runat="server" Text="Refund" Visible="false"    OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary"  />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-warning" Width="80px" />
                                           
                                       <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" OnClick="btnReport_Click" />

                                    <%--<asp:Button ID="btnSaveandBill" runat="server" Text="Save & Bill" OnClientClick="return Validate1();"
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" 
                                        onclick="btnSaveandBill_Click"   />--%><%-- onclientclick="target = '_blank';" />--%>
                                         
                                             
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

