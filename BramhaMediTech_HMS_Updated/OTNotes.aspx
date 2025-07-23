<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OTNotes.aspx.cs" Inherits="OTNotes" %>

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

        function Validate() {


            if (document.getElementById("MainContent_txtsurgen").value == "") {
                alert("Please Enter Surgeon");
                return false;
            }
            if (document.getElementById("MainContent_txtDISEASE").value == "") {
                alert("Please Enter Disease");
                return false;
            }
            if (document.getElementById("MainContent_txtoperation").value == "") {
                alert("Please Enter Operation Name");
                return false;
            }


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
<%--    <script src="Scripts/1.3.2.min.js"  type="text/javascript"/>
   <script src="Scripts/1.7.1.custom.js" type="text/javascript"/>--%>
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnRegister" />
           <%-- <asp:PostBackTrigger ControlID="btnSummary" />
             <asp:PostBackTrigger ControlID="btnDisk" />--%>
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>OT Notes</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OT Notes</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                 <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="False"></asp:Label>
                               
                            </div>
                        </div>
                    </div>
                     <div class="box-body">
                        <div class="panel panel-info">
      <div class="panel-heading" style="font-size:medium;font-weight:bold"">Patient Information</div>
      <div class="panel-body">
    
          <div class="col-lg-12 text-left">
                        <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label ID="lblPrnNo" runat="server" Font-Bold="true" Text="Reg ID:" ></asp:Label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="lblPat" runat="server" Font-Bold="true" F Text="Patient Name:"></asp:Label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-sm-2" runat="server" >
                                    <div class="form-group">
                                        <asp:Label ID="lblI"  runat="server" Font-Bold="true" Text="IPD NO:"></asp:Label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label ID="lblBio" runat="server" Font-Bold="true" Text="Bill NO:"></asp:Label>
                                        <asp:Label ID="lblBillNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label ID="hhhd" runat="server" Font-Bold="true" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

          <div class="col-lg-12 mt-3">
                        <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server" Font-Bold="true" Text="Patient Category:"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true" Text="Admission Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div3" class="col-sm-2" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Font-Bold="true" Text="DR Name :"></asp:Label>
                                        <asp:Label ID="lbldrname" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:label id="lblBi" runat="server" Font-Bold="true" Text="Room Type:" ></asp:label>
                                        <asp:Label ID="LblRoomType" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server" Font-Bold="true" Text="Bed Name:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>

          <div class="col-lg-12 mt-3">
                        <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server" Font-Bold="true" Text="Diagnosis:"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server" Font-Bold="true" Text="Procedure:"> </asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div4" class="col-sm-2" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="Label5"   runat="server" Font-Bold="true" Text="Sponsor :"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:label id="Label7" runat="server" Font-Bold="true" Text="Sponsor1:" ></asp:label>
                                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:label id="Label9" runat="server" Font-Bold="true" Text="Visit No:"></asp:label>
                                        <asp:Label ID="lblvisitno" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
          </div>
                            </div>
                   
                   
                        <div class="panel panel-info">
      <div class="panel-heading" style="font-size:medium;font-weight:bold"">OT Notes</div>
      <div class="panel-body">

                         <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                  <div class="col-sm-3" >
                                                    <div class="form-group">  
                                                                                       
                                                           
                                                        <asp:TextBox ID="txtsurgen" runat="server" readonly="true" CssClass="form-control" placeholder="Enter Surgeon" AutoPostBack="True" OnTextChanged="txtsurgen_TextChanged"></asp:TextBox>     
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtsurgen"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                   
                                                    </div>
                                                </div>
                                  <div class="col-sm-3" >
                                                    <div class="form-group">  
                                                                                         
                                                        <asp:TextBox ID="txtAnaesthetist" readonly="true" runat="server"  CssClass="form-control" AutoPostBack="true" placeholder="Enter Anaesthetist" OnTextChanged="txtAnaesthetist_TextChanged"></asp:TextBox>      
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAnaesthetist"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtAnaesthetist"
                                                ID="AutoCompleteExtender3"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                  <%--<div class="col-sm-3 text-left" >
                                                    <div class="form-group">  
                                                                                          
                                                            <asp:TextBox ID="txt1stAsst" runat="server" AutoPostBack="true"  CssClass="form-control" placeholder="Enter Anaesthetist Asst" OnTextChanged="txt1stAsst_TextChanged"></asp:TextBox>      
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txt1stAsst"
                                                ID="AutoCompleteExtender5"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                       
                    
                                                    
                                                    </div>
                                                </div>--%>
                                  <div class="col-sm-3" >
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txt2stAsst" runat="server" readonly="true" AutoPostBack="true"  CssClass="form-control" placeholder="Enter Surgeon Asst." OnTextChanged="txt2stAsst_TextChanged"></asp:TextBox>        
                                                       <%-- <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txt2stAsst"
                                                ID="AutoCompleteExtender6"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>--%>
                                                    
                                                    </div>
                                                </div>
                                 <div class="col-sm-3" >
                                                    <div class="form-group">  
                                                                                       
                                                             
                                                     <%--  <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>--%>
                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txttimestart" runat="server" readonly="true" CssClass="form-control"  placeholder="Enter Time Start"    
                                                              AutoPostBack="True"></asp:TextBox>
                                                             
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                        </div>
                                                    
                                                    </div>
                                                </div>
                                
                               </div>
                             </div>
                         <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                 
                                  
                                  <div class="col-sm-3" >
                                                    <div class="form-group">  
                                                                                        
                                                         <asp:TextBox ID="txtDISEASE" runat="server" readonly="true" CssClass="form-control" placeholder="Enter DISEASE" AutoPostBack="True" OnTextChanged="txtDISEASE_TextChanged"></asp:TextBox>        
                                                       
                                      <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDisease"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtDISEASE"
                                                ID="AutoCompleteExtender8"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-sm-3" >
                                                    <div class="form-group">  
                                                                                  
                                                         <asp:TextBox ID="txtoperation" readonly="true" runat="server"  CssClass="form-control" placeholder="Enter OPERATION"  OnTextChanged="txtoperation_TextChanged"></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                 <div class="col-sm-3">
                                        <div class="form-group">  
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control form-select">
                                                <asp:ListItem Value="0">-Select Type-</asp:ListItem>
                                                <asp:ListItem>Elective</asp:ListItem>
                                                <asp:ListItem>Emergency</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                 </div>
                                 <div class="col-sm-3">
                                        <div class="form-group">  
                                            <asp:DropDownList ID="ddlAnaesthesia" runat="server" CssClass="form-control form-select" >
                                            <asp:ListItem Value="0">-Select Anaesthesia-</asp:ListItem>
                                                <asp:ListItem>GA</asp:ListItem>
                                                <asp:ListItem>Local</asp:ListItem>
                                                <asp:ListItem>Spinal</asp:ListItem>
                                                <asp:ListItem>NA</asp:ListItem>
                                                <asp:ListItem>Sedation/Local</asp:ListItem>
                                                <asp:ListItem>Sedation</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                     </div>
                               
                                 </div>
                             </div>
                           <%-- <div class="col-lg-12">
                             <div class="row"> 
                                 
                                
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group"> 
                                                        <asp:TextBox ID="txtswabSecountNurse" runat="server"  CssClass="form-control" placeholder="Enter Secound Swab Nurse" AutoPostBack="True" OnTextChanged="txtswabSecountNurse_TextChanged" ></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtswabSecountNurse"
                                                ID="AutoCompleteExtender11"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                        </div>
                                      </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group"> 
                                                        <asp:TextBox ID="txtInstrumentFirstNurse" runat="server"  CssClass="form-control" placeholder="Enter First Instrument Nurse" AutoPostBack="True" OnTextChanged="txtInstrumentFirstNurse_TextChanged" ></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtInstrumentFirstNurse"
                                                ID="AutoCompleteExtender12"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                        </div>
                                      </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group"> 
                                                        <asp:TextBox ID="txtInstrumentSecoundNurse" runat="server"  CssClass="form-control" placeholder="Enter Secound Instrument Nurse" AutoPostBack="True" OnTextChanged="txtInstrumentSecoundNurse_TextChanged" ></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtInstrumentSecoundNurse"
                                                ID="AutoCompleteExtender13"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                        </div>
                                      </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group"> 
                                                        <asp:TextBox ID="txttrollyNurse" runat="server"  CssClass="form-control" placeholder="Enter Trolly Nurse" AutoPostBack="True" OnTextChanged="txttrollyNurse_TextChanged"  ></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txttrollyNurse"
                                                ID="AutoCompleteExtender14"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                        </div>
                                      </div>
                                 

                                 </div>
                             </div>--%>
                         <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtIncision">Incision:</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-10" >
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txtIncision" runat="server"   CssClass="form-control" placeholder="Enter Incision" ></asp:TextBox>        
                                                      
                                                    
                                                    </div>
                                                </div>
                                 </div>
                             </div>
           <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtProcedure">Procedure:</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-10" >
                                                    <div class="form-group">  
                                                                                    
                                                        <%-- <asp:TextBox ID="txtProcedure" runat="server"   CssClass="form-control" placeholder="Enter Procedure" >style="height:120px;width:290px"</asp:TextBox> --%>       
                                                      <textarea  runat="server" style="width:1000px"  id="txtProcedure"  cols="11" rows="10" placeholder="Enter Procedure" class="w-100"></textarea>
                                                    
                                                    
                                                    </div>
                                                </div>
                                 </div>
                             </div>
           <div class="col-lg-12 mt-3">
                             <div class="row">
                                   <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtSurgeryDone">Surgery Done:</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-10">
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txtSurgeryDone" runat="server" CssClass="form-control" placeholder="Enter Surgery Done" ></asp:TextBox>        
                                                      
                                                    
                                                    </div>
                                                </div>
                                 </div>
                             </div>
          <div class="col-lg-12 mt-3">
                             <div class="row">
                                   <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtAdvert">Advert Events:</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-10" >
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txtAdvert" runat="server"   CssClass="form-control" placeholder="Enter Advert Events" ></asp:TextBox>        
                                                      
                                                    
                                                    </div>
                                                </div>
                                 </div>
                             </div>
          <div class="col-lg-12 mt-3">
                             <div class="row">
                                   <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtBloodLoss">BloodLoss(ml):</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-10">
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txtBloodLoss" runat="server" placeholder="Blood Loss (ml)"   CssClass="form-control"  ></asp:TextBox>        
                                                      
                                                    
                                                    </div>
                                                </div>
                                 </div>
                             </div>
          <div class="col-lg-12 mt-3">
                             <div class="row">
                                   <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtComments">Comments:</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-10">
                                                    <div class="form-group">  
                                                                                    
                                                        <%-- <asp:TextBox ID="txtComments" runat="server"   CssClass="form-control"  ></asp:TextBox>--%>        
                                                       <textarea  runat="server" id="txtComments" class="w-100"  rows="2" placeholder="Enter Comments"></textarea>
                                                    
                                                    
                                                    </div>
                                                </div>
                                 </div>
                             </div>
           <div class="col-lg-12 mt-3">
                             <div class="row">
                                   <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtComments">Browse Image:</label>
                                                        </div>
                                        </div>
                                 <div class="col-sm-6" >
                                                    <div class="form-group">  
                                                                                    
                                                       <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                                    <ContentTemplate>
                                                    <asp:FileUpload ID="FUUploadPhoto" runat="server"></asp:FileUpload>
                                                         <asp:Label ID="LblUploadph" Text="" Font-Bold="true" runat="server"></asp:Label>
                                                                         
                                                                         </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                  <div class="col-sm-6">
                                                    <div class="form-group">  
                                                        <asp:Image ID="Image1show" runat="server"/>
                                                        </div>
                                      </div>
                                 </div>
                             </div>
                          <div class="col-lg-12 text-Center mt-3">
                             <div class="row"> 
                                   
                                                                            <div class="form-group">  
                                                          <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" OnClientClick="return Validate();"  Text="Save&Print" OnClick="btnRegister_Click" />
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
    
              

