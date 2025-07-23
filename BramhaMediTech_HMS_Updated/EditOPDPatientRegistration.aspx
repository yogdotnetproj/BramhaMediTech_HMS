<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EditOPDPatientRegistration.aspx.cs" Inherits="EditOPDPatientRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Src="UserControls/ucPatientInfo.ascx" TagName="ucPatientInfo" TagPrefix="uc1" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type = "text/javascript">
    function Validate() {
        //  alert("R");
        // alert(document.getElementById("Rbldisctype").value);
        if (document.getElementById("MainContent_ddlPatientCategoryName").value == "0") {
            alert("Please Select Patient Category!");
            return false;
        }
        if (document.getElementById("MainContent_ddlPatientSubCategoryName").value == "0") {
            alert("Please Select Patient SubCategory!");
            return false;
        }

        //if (document.getElementById("MainContent_txtCharges").value == "") {
           
        //    alert("Enter charges");
        //    return false;
        //}

        //if (document.getElementById("MainContent_ddlService").value == "0") {

        //    alert("Please Select Service!");
        //    return false;

        //}
        
        //if (document.getElementById("MainContent_ddlBillGroup").value == "0") {
        //    //If the "Please Select" option is selected display error.
        //    alert("Please Select Bill Group!");
        //    return false;

        //}

        if (document.getElementById("MainContent_ddlTitleName").value == "0") {
            alert("Select Initial");
            return false;
        }
        if (document.getElementById("MainContent_txtPatientName").value == "") {
            alert("Please Enter Patient Name!");
            return false;

        }
        //alert("djf");
        
        
        if (document.getElementById("MainContent_txtRegistrationDate").value == "") {
            alert("Please Enter Registration Date!");
            return false;
        }
        if (document.getElementById("MainContent_ddlRegistrationType").value == "0") {
            alert("Please Select Registration Type!");
            return false;
        }
        if (document.getElementById("MainContent_ddlShift").value == "0") {
            alert("Please Select Shift!");
            return false;
        }
        
        if (document.getElementById("MainContent_txtAge").value == "") {
            alert("Please Enter Age!");
            return false;

        }
       


        //if (document.getElementById("MainContent_txtDiscount").value != "")
        //{

        //    if (document.getElementById("MainContent_ddlDiscReason").value == "0") {
        //        alert("Please Select the Reason for Discount!");
        //        return false;
        //    }
        //    if (document.getElementById("MainContent_ddlDiscReason").value == "0") {
        //        alert("Please Select the Discount given By!");
        //        return false;
        //    }

        //}

    }

    function Validate1() {
        //alert(document.getElementById("MainContent_RdbPayment").value);
        //if (document.getElementById("MainContent_RdbPayment").value == "") {
        //    alert("Please Select Payment Type!");
        //    return false;
        //}

        //if (document.getElementById("MainContent_txtAmount").value < document.getElementById("MainContent_txtPaid").value) {
        //    alert(document.getElementById("MainContent_txtAmount").value);
        //    alert(document.getElementById("MainContent_txtPaid").value);
        //    alert("Paid amount should not be greater than total amount!");
        //    return false;
        //}
        if (document.getElementById("MainContent_txtPatientName").value == "") {
            alert("Please Select Patient Name!");
            return false;
        }
        if (document.getElementById("MainContent_ddlConsDoctorName").value == "0") {

            alert("Please Select Consultant Doctor!");
            return false;

        }
        if (document.getElementById("MainContent_ddlDepartment").value == "0") {

            alert("Please Select Department!");
            return false;

        }
        
        if (document.getElementById("MainContent_txtBirthDate").value == "") {
            alert("Please Enter Birth date");
            return false;
        }
        if (document.getElementById("MainContent_ddlGender").value == "0") {
            alert("Select Gender");
            return false;
        }
        if (document.getElementById("MainContent_txtMobileNo").value == "") {
            alert("Please Enter Mobile No");
            return false;
        }
        if (document.getElementById("MainContent_txtPatientAddress").value == "") {
            alert("Please Enter Patient Address!");
            return false;
        }

        //if (document.getElementById("MainContent_rdbdiscAmt").value == "Amt") {

        //    if (document.getElementById("MainContent_txtTotalAmt").value < document.getElementById("MainContent_txtDiscount").value) {

        //        alert("Discount amount should not be greater than Bill amount!");
        //        return false;
        //    }
        //}

        //if (document.getElementById("MainContent_rdbdiscPer").value == "Per") {

        //    if (document.getElementById("MainContent_txtDiscount").value > 100) {

        //        alert("Discount Percentage should not be greater than 100%");
        //        return false;
        //    }
        //}
    }

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

    function ClientItemSelected(sender, e) {
        $get("<%=hfPatientId.ClientID %>").value = e.get_value();
    }
    function ClientItemSelected1(sender, e) {

        $get("<%=hfDoctorId.ClientID %>").value = e.get_value();
       }
       function ClientItemSelected2(sender, e) {

           $get("<%=hrConsDoctorId.ClientID %>").value = e.get_value();
       }
    </script>
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
    
    
    <asp:HiddenField ID="hfPatientId" runat="server" />
     <asp:HiddenField ID="hfDoctorId" runat="server" />
     <asp:HiddenField ID="hrConsDoctorId" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveandBill" />
             <asp:PostBackTrigger ControlID="btnCaseReport" />
             <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
        <ContentTemplate>
         

            <section class="content-header d-flex">
                    <h1>OPD Registration</h1>
                    <ol class="breadcrumb">
                       
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">OPD Registration</li>
                    </ol>
                </section>
            <section class="content">
               
                 <div class="box" runat="server" id="Show">

                    
                     <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                     <asp:Label ID="lblVisitingNo" class="red pull-right"  runat="server" Font-Bold="True" ForeColor="#0066FF" Font-Size="Medium" Width="259px" ></asp:Label>
                          
                                </div>
                    
                               <div class="box-body">
                                    <div class="row"> 
                                        
                                        <div class="col-sm-2 text-left" runat="server" visible="false" >
                                                        <div class="form-group">
                                                            <label for="ddlPatientCategoryName">Vaccination Status</label>  
                                                            </div>

                                        </div>
                                        <div class="col-sm-10 text-left" runat="server" visible="false" >
                                                        <div class="form-group form-check">
                                                            <asp:RadioButtonList runat="server" ID="RblVaccineType" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True">No Vaccinated</asp:ListItem>
                                                                
                                                                <asp:ListItem>Partially Vaccinated</asp:ListItem>
                                                                <asp:ListItem Value="Fully Vaccinated">Fully Vaccinated</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </div>
                                            </div>
                                         <div class="col-lg-12 mt-3" runat="server" visible="false"> 
                                            <div class="row">
                                                 <%-- <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientCategoryName">Sponser Category</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>--%>
                                         <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                                             
                                                                <asp:RadioButtonList ID="rblPatcate" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True"  ForeColor="Red" Font-Bold="True" Font-Size="Medium" OnSelectedIndexChanged="rblPatcate_SelectedIndexChanged" >
                                                             <asp:ListItem Selected="True" Value="1" >Paying</asp:ListItem>
                                                             <asp:ListItem Value="2">Insurance</asp:ListItem>                                                            
                                                             <asp:ListItem Value="3">Charge</asp:ListItem>
                                                         
                                                             </asp:RadioButtonList>      
                                                       </div>
                                                    </div>
                                            
                                         <div class="col-sm-5 text-left">
                                                    <div class="form-group">  
                                                             <asp:TextBox ID="ddlPatientSubCategoryName1" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter  Insurance(*)"
                                                AutoPostBack="True" ontextchanged="ddlPatientSubCategoryName1_TextChanged" Font-Bold="True" Font-Size="Medium"  ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchSubCategory"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="ddlPatientSubCategoryName1"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>          
                                                       
                                                    </div>
                                                </div> 
                                                <div class="col-sm-4 text-left">
                                                    <div class="form-group">
                                                       
                                                        
                                                        <asp:TextBox ID="ddlChargeSubCategory1" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter  Company(*)"
                                                AutoPostBack="True" ontextchanged="ddlChargeSubCategory1_TextChanged" Font-Bold="True" Font-Size="Medium"  ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchChargeSubCategory"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="ddlChargeSubCategory1"
                                                ID="AutoCompleteExtender10"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>    
                                                        </div>
                                                    </div>
                                            </div>
                                        </div>
                                       
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row"> 
                                                 <div class="col-sm-1 text-left pr-0" runat="server" visible="false">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlTitleName" runat="server" CssClass="form-control form-select pull-left" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlTitleName_SelectedIndexChanged" TabIndex="6">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>             
                                                                          
                                                <div class="col-sm-5 text-left">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" TabIndex="7" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                                 
                                                <div class="col-sm-2 text-left pr-0">
                                                    <div class="form-group">
                                                        <div class="input-group date" data-provide="datepicker"  data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server"  placeholder="Birth Date"  class="form-control" TabIndex="8" 
                                                             AutoPostBack="True" OnTextChanged="txtBirthDate_TextChanged" ></asp:TextBox>
                                                             
                                                                  <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>                                                  
                        
                                                        </div>
                                                            
                                                        </div>
                                                    </div>
                                                
                                                <div class="col-sm-2  text-left pr-0">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                    
                                                       <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Enter Mobile No." 
                                                             onkeyPress="return numeric_only(event);" TabIndex="9" ></asp:TextBox>
                                                       
                                                        </div>
                                                    </div>
                                                                                         
                                                            
                                                                                                       
                                                           <div class="col-sm-1 text-left">
                                                           <div class="form-group">                                                                                                                      
                                                       
                                                                <asp:TextBox ID="txtAge" runat="server" TabIndex="10" CssClass="form-control" placeholder="Age" 
                                                                ontextchanged="txtAge_TextChanged"  onkeyPress="return numeric_only(event);" AutoPostBack="True"></asp:TextBox>
                                                            
                                                           </div>
                                                         </div>     
                                                                                                                                                   
                                                           <div class="col-sm-2 text-left">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        CssClass="form-control form-select" 
                                                                        TabIndex="11" onselectedindexchanged="ddlAge_SelectedIndexChanged">
                                                                        <asp:ListItem>Years</asp:ListItem>
                                                                        <asp:ListItem>Months</asp:ListItem>
                                                                        <asp:ListItem>Days</asp:ListItem>
                                                                    </asp:DropDownList>
                                                           </div>
                                                           
                                                         
                                                        </div>

                                               

                                                            



                                       
                                 </div>
                                            </div> 
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                               
                                                  <div class="col-sm-2 text-left">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                        OnSelectedIndexChanged="ddlGender_SelectedIndexChanged" TabIndex="12" Enabled="true">
                                                        </asp:DropDownList>
                                                    </div>
                                               </div>
                                                <div id="Div2" class="col-sm-6  text-left" runat="server">
                                                    <div class="form-group">
                                                       <asp:TextBox ID="txtPatientAddress" runat="server" CssClass="form-control"   placeholder="Enter Patient Address"
                                            TabIndex="13"></asp:TextBox>
                                                    </div>
                                                   </div>  
                                                
                                     
                                                

                                                <div class="col-sm-4 text-left">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtPatientComplaint" runat="server" CssClass="form-control"   placeholder="Enter Patient Complaint"
                                            TabIndex="15"></asp:TextBox>
                                                     </div>

                                                 </div>
                                                

                                                <div class="col-sm-3 text-left" runat="server" visible="false">
                                                    <div class="form-group">
                                                           
                                                        <asp:TextBox ID="txtReferanceDrText" runat="server" CssClass="form-control"    placeholder="Enter Ref. Dr. Text"
                                                    TabIndex="16"></asp:TextBox>
                
              
                                                     </div>
                                                 </div>      
                                                </div>
                                            </div>                
                                        
                                         <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                  
                                                <%--  <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                           <asp:DropDownList ID="ddlPatientCategoryName" runat="server" AutoPostBack="True" TabIndex="2" CssClass="form-control form-select"
                                                                OnSelectedIndexChanged="ddlPatientCategoryName_SelectedIndexChanged">
                                                         </asp:DropDownList>                    
                                                                       
                                                       </div>
                                                    </div>
                                               
                                                 <div class="col-sm-2 text-left">
                                                    <div class="form-group">                                        
                                                         <asp:DropDownList ID="ddlPatientSubCategoryName" runat="server" AutoPostBack="True" TabIndex="3" CssClass="form-control form-select"
                                                          OnSelectedIndexChanged="ddlPatientSubCategoryName_SelectedIndexChanged">
                                                         </asp:DropDownList> 
                                                    </div>
                                                </div> --%>
                                                
                                                   <div class="col-sm-4 text-left">
                                                    <div class="form-group">     
                                                        <asp:DropDownList ID="ddlConsDoctorName" runat="server"
                                                          CssClass="form-control form-select"  AutoPostBack="true" Visible="false"  TabIndex="14" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                         <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                               AutoPostBack="True" TabIndex="4"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtConsDoctorName"
                                                ID="AutoCompleteExtender4"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 text-left">
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" Visible="false" AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="18" Font-Bold="True" Font-Size="Large">
                                                            </asp:DropDownList>                   
                                                         <asp:TextBox ID="txtdepartment" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Department Name(*)"
                                                AutoPostBack="True" TabIndex="5"  onkeyPress="return alpha_only(event);" OnTextChanged="txtdepartment_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDepartment"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtdepartment"
                                                ID="AutoCompleteExtender5"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div> 
                                                   <div class="col-sm-4 text-left">
                                                    <div class="form-group">
                                                           
                                                        <div id="Div1" style="width:100px;height:100px; overflow:auto; background-color: #0000FF;" ></div>
                                         <asp:TextBox ID="txtDoctorName" CssClass="form-control" Placeholder="Enter Reference Doctor"  TabIndex="14"  runat="server" AutoCompleteType="None" AutoPostBack="True"
                                          ontextchanged="txtDoctorName_TextChanged"  ></asp:TextBox>

                                     <asp:AutoCompleteExtender 
                                                    MinimumPrefixLength="1"
                                                    CompletionListElementID="Div1" 
                                                      ServiceMethod="SearchReferalDoctor"
                                                    ServicePath="~/AutoCompleteService.asmx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true" 
                                                    CompletionSetCount="10" 
                                           CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                    TargetControlID="txtDoctorName"
                                                    ID="AutoCompleteExtender2"
                                                    runat="server"
                                                    FirstRowSelected="false" 
                                                    OnClientItemSelected = "ClientItemSelected1"
                                                    DelimiterCharacters=";, :"
                                                    ShowOnlyCurrentWordInCompletionListItem="true">
                                            </asp:AutoCompleteExtender>

                                                     </div>
                                                 </div>  
                                             </div>
                                        </div> 

                                        <div class="col-lg-12 mt-3" runat="server" visible="false"> 
                                            <div class="row">
                                               <%-- <div class="col-sm-2 text-left" style="width:200px">
                                                        <div class="form-group">  
                                                                                                                    
                                                            <asp:TextBox ID="txtKinName" runat="server" CssClass="form-control" height="30px" placeholder="Enter Kin Name"  Width="190px" onkeyPress="return AlphaNumeric(event);"
                                                        TabIndex="5"></asp:TextBox>
                
                                                       </div>
                                                    </div>                        
          
                                                <div class="col-sm-2 text-left" style="width:200px">
                                                    <div class="form-group">
                                                         
                                                        <asp:TextBox ID="txtKinRelation" runat="server"  CssClass="form-control" height="30px"  placeholder="Enter Kin Relation(*)" Width="190px" onkeyPress="return AlphaNumeric(event);"
                                                         TabIndex="6"></asp:TextBox>
                                                    </div>
                                                </div>--%>
                                                <div class="col-sm-4 text-left">
                                                     <div class="form-group">  
                                                             <asp:FileUpload ID="FileUpload1" runat="server"/>  
                                                     </div>     
                                                </div>                                                                          
                                            <div class="col-sm-2 text-left">
                                                     <div class="form-group">      
                                                         <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                                                          CssClass="btn btn-info" onclick="btnUpload_Click"  TabIndex="17" Text="Upload" />
                                                          </div>   
                                                </div>  
 <div class="col-sm-4 text-left">
   <div class="form-group">   
       <div runat="server" id="UploadedFiles" style="height:100px; width:600px; overflow:scroll"    >                                          
 <div class="table-responsive" style="width:100%" >

<asp:GridView ID="gvImages" runat="server"  class="table table-responsive table-sm table-bordered" DataKeyNames="Path,FileId" AutoGenerateColumns="False" OnRowDeleting="gvImages_RowDeleting">
    <Columns>
        <asp:BoundField DataField="FileId" HeaderText="Image Id" />
        <asp:BoundField DataField="FileName" HeaderText="Name" />
       <%-- <asp:ImageField DataImageUrlField="Path" HeaderText="Image" >
            <ControlStyle Height="50px" Width="50px" />
        </asp:ImageField>--%>
       <%-- <asp:TemplateField HeaderText="Preview Image">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("Path")%>'
                Width="100px" Height="100px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
        </ItemTemplate>
    </asp:TemplateField>--%>
        <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Imagebutton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                            OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                            CommandName="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:TemplateField>
  <asp:TemplateField HeaderText="FilePath">
<ItemTemplate>
<asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>
<div id="dialog" style="display: none">
</div>
     </div>
           </div>
       </div>
     </div>
                                                
                                                

                                         </div>
                                        </div> 
                                        <div id="billdetails" runat="server" visible="false">
                                        <div class="col-lg-12 mt-3" visible="false" >                                 
                                     <label> Add Details:</label>
                                        
                                    <div class="row" runat="server" >
                                       
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">                                                              
                                                        <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                         OnSelectedIndexChanged="ddlBillGroup_SelectedIndexChanged" 
                                                         TabIndex="18">
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                                    </div>                                               

                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">  
                                                                                         
                                    <asp:TextBox ID="txtService" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Service Name(*)"
                                                AutoPostBack="True"   onkeyPress="return alpha_only(event);" OnTextChanged="txtService_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchService"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtService"
                                                ID="AutoCompleteExtender3"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                       
                                                    
                                                    </div>
                                                </div>
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtQty" runat="server" onkeyPress="return numeric_only(event);" AutoPostBack="true"
                                                        CssClass="form-control" placeholder="Enter Qty" TQabIndex="19" OnTextChanged="txtQty_TextChanged"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div> 
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtCharges" runat="server" onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control" placeholder="Enter Charges" TabIndex="20"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>  
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtTotalCharges" runat="server" Enabled="false" onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control"  TabIndex="21"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>              

                                                <div class="col-sm-2 text-right">
                                            <asp:Button ID="btnAdd" runat="server"  CssClass="btn btn-primary" OnClick="btnAdd_Click" TabIndex="14" OnClientClick="return Validate();"
                                            Text="Add" />
                                        </div>
                                    
                                    </div>
                                  </div> 

                                        </div> 
                                        
                                        <div class="col-lg-12 mt-3" runat="server" visible="false">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%" >
                                <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" DataKeyNames="BillServiceDetailId"
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="17"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
                                    <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                                
                                    <asp:BoundField DataField="Empname" HeaderText="Consultant Dr"  > 
                                <ItemStyle Width="120px" /></asp:BoundField>
                                    <asp:BoundField DataField="BillGroup" HeaderText="BillGroup"  > <ItemStyle Width="150px" /></asp:BoundField>
                               <asp:BoundField DataField="Service" HeaderText="Service"  >  <ItemStyle Width="150px" /></asp:BoundField>
                                <asp:BoundField DataField="Qty" HeaderText="Qty" Visible="false"  ><ItemStyle Width="50px" /> </asp:BoundField>
                                <asp:BoundField DataField="SingleBillServiceCharges" HeaderText="Charges"  >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>
                                <asp:BoundField DataField="Charge" Visible="false" HeaderText="Total Charge"  >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>

                                <asp:BoundField DataField="BillServiceDetailId" HeaderText="Bill Service DetailId" Visible="False"> <ItemStyle Width="70px" /></asp:BoundField>
                                <asp:BoundField DataField="DrId" HeaderText="Consultant Dr Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>                            
                                <asp:BoundField DataField="BillGroupId" HeaderText="Bill Group Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                                 <asp:BoundField DataField="BillServiceId" HeaderText="Service Id" Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
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
                                         <div class="messagealert" id="alert_container">
                                             
            </div> 
                                            <div runat="server" id="KKK"  visible="false">
                                        <div class="col-lg-12 mt-3">                                            
                                            <div class="row"> 
                                                    
                                                           
                                                    
                                                    <div class="col-sm-6 text-left">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>

                                                 
                                                <%-- <div class="col-sm-1 text-left" style="width:120px" >
                                             <div class ="row">
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="PaymentInsurance" Text="Is Insurance" runat="server" AutoPostBack="true" OnCheckedChanged="PaymentInsurance_CheckedChanged"></asp:CheckBox></label>
                                            </div>
                                            </div>--%>
                                        <div id="InsuranceDetails" runat="server">  
                                                       <div class="col-lg-12 mt-3">
                                                           <div class="row"> 
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label>InsuranceAmt </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtInsuranceAmt" runat="server"  CssClass="form-control"   AutoPostBack="True"
                                                    OnTextChanged="txtInsuranceAmt_TextChanged1"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-sm-2 text-left">
                                                    <div class="form-group">                                                      
                                                        

                      <asp:RadioButtonList ID="rdblInsuranceAmt" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdblInsuranceAmt_SelectedIndexChanged" >
                          <asp:ListItem  Value="0">Amt</asp:ListItem>
                          <asp:ListItem Selected="True" Value="1">Per(%)</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                     </div>    
                                                        
                                                     
                                                       
                                                            
                                                        </div>
                                                              
                                                 </div>
                                            </div>
                                                </div>
                                              </div>                                               
                                           <div id="PaymentDetails" runat="server">
                                                
                                                       <div class="col-lg-12 mt-3">
                                                           <div class="row"> 
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  CssClass="form-control"  placeholder="Card/Cheque No."
                                                     TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbankName" runat="server"  CssClass="form-control" placeholder="Bank Name"
                                                     TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2 text-left" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                            
                                                          <asp:TextBox ID="txtchequedate" runat="server" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                               </div>
                                                           </div>
                                                       
                                                       </div>
                                      <div class="row">
                                          <div class="col-lg-9">
                                              
                                        <div class="col-lg-12 mt-3">                                            
                                                   <div class="row"> 
                                                       
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label> Total Amount: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtTotalAmt" runat="server" readonly="true" CssClass="form-control"  placeholder="Total Amount"
                                                     TabIndex="83"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                               
                                                       
                                                
                                                     <div class="col-sm-1 text-left">
                                                           <div class="form-group">  
                                                        <label> Discount: </label>
                                                               </div>
                                                        </div>
                                                         <div class="col-sm-3 text-right">
                                                    <div class="form-group"> 
                                                        
                                                        <input id="rdbdiscAmt" type="radio" name="rdbDisc" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>
                <input id="rdbdiscPer" type="radio" runat="server" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
                                                         
                                                        </div>
                                                     </div>
                                                       <div class="col-sm-2 text-left">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtDiscount" runat="server"  CssClass="form-control" placeholder="Discount"
                                                      AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged" onkeyPress="return numeric_only(event);"></asp:TextBox>
                       
                                                        </div>
                                                           </div>
                                                         
                                                        </div>
                                                        </div>
                                        <div class="col-lg-12 mt-3">     
                                                     <div class="row">
                                                       
                                                          <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                                <label>Net Amount : </label>
                                                               </div>
                                                        </div>
                                                          <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtAmount" runat="server" readonly="true" CssClass="form-control"   placeholder="Amount" onkeyPress="return numeric_only(event);"
                                                      TabIndex="85" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                                               </div>
                                                        </div>

                                                          <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label> Disc Reason : </label>
                                                               </div>
                                                        </div>
                                                          <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                       
                                                               <asp:DropDownList ID="ddlDiscReason" runat="server" AutoPostBack="True" CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                               
                                                       </div>
                                           </div>
                                        <div class="col-lg-12 mt-3">    
                                                    <div class="row">
                                                      
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label> Paid : </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtPaid" runat="server"  CssClass="form-control"  placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                     TabIndex="86" OnTextChanged="txtPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label> Disc Given By: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                       
                                                               <asp:DropDownList ID="ddlDiscountGivenBy" runat="server" AutoPostBack="True" CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                              
                                                       </div>
                                            </div>
                                        <div class="col-lg-12 mt-3">  
                                                    <div class="row">
                                                       
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label> Balance : </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbalance" runat="server"  CssClass="form-control"     placeholder="Balance" onkeyPress="return numeric_only(event);"
                                                     TabIndex="87"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2 text-left">
                                                           <div class="form-group">  
                                                        <label> BalanceReason: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-sm-4 text-left">
                                                           <div class="form-group">  
                                                                               
                                                       
                                                               <asp:DropDownList ID="ddlBalreason" runat="server" AutoPostBack="True" CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                               
                                                       </div>
                                            </div>
                                          </div>
                                          <div class="col-lg-3">
                                             
                                              <asp:TextBox runat="server" class="form-control" ID="txtcompdes" ForeColor="Red" Font-Bold="true" TextMode="MultiLine"  cols="5" rows="8" style="width:100%;"> </asp:TextBox>
                                          </div>
                                      </div>
                                       </div>
                                       
                                          <div class="col-lg-12 text-center mt-3">
                                              <asp:Label ID="lblvalidate" CssClass="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save"  OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" CssClass="btn btn-primary"  />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" CssClass="btn btn-primary" />
                                    <asp:Button ID="btnSaveandBill" runat="server" Visible="false" Text="Save & Bill" OnClientClick="return Validate1();"
                                        CausesValidation="False" TabIndex="16" CssClass="btn btn-primary"  
                                        onclick="btnSaveandBill_Click"   /><%-- onclientclick="target = '_blank';" />--%>
                                             <asp:Button ID="btnCaseReport" runat="server" Text="Case Report" OnClientClick="target = '_blank';"
                                        CausesValidation="False" TabIndex="16" CssClass="btn btn-primary"  OnClick="btnCaseReport_Click"/>

                                    <asp:Button ID="btnConsultation" runat="server" Text="Consultation" onclientclick="target = '_blank';"
                                        CausesValidation="False" TabIndex="16" CssClass="btn btn-primary"  onclick="btnConsultation_Click" />
                                        <asp:Button ID="btnRdlcReport" runat="server" Text="RDLC Report" 
                                        CausesValidation="False" TabIndex="16" CssClass="btn btn-primary" Visible="false"
                                        onclick="btnRdlcReport_Click"  />     
                                    
                                             
                                        </div>    
                                              
                                          </div>                                          
                                           
                                           

                                
                           
                               </div>
                         
                 
                            
                             
                                        
                      </div>

                
                    
                
                        </section>
       

    </ContentTemplate>
    </asp:UpdatePanel>
       
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>

</asp:Content>

