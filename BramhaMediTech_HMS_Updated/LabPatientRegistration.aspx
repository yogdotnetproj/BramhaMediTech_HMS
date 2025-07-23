<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="LabPatientRegistration.aspx.cs" Inherits="LabPatientRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="UserControls/ucPatientInfo.ascx" TagName="ucPatientInfo" TagPrefix="uc1" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <style type="text/css">
      input.larger {
        width: 80px;
        height: 80px;
      }
    </style>
    <style type="text/css">
  .BigCheckBox input {width:20px; height:20px;}
</style>
    <script type = "text/javascript">
    function Validate() {
       
        if (document.getElementById("MainContent_ddlPatientCategoryName").value == "0") {
            alert("Please Select Patient Category!");
            return false;
        }
        if (document.getElementById("MainContent_ddlPatientSubCategoryName").value == "0") {
            alert("Please Select Patient SubCategory!");
            return false;
        }

        if (document.getElementById("MainContent_txtCharges").value == "") {
            // alert("T");
            //var BAmt = (parseFloat(document.getElementById("lbltotalpayment").value) + parseFloat(document.getElementById("txthstamount").value))
            //// alert(BAmt);
            //if (document.getElementById("txtpaidamount").value > BAmt + 1) {
            //    alert("Paid amount should not greater than bill amount");
            //    document.getElementById("txtpaidamount").focus();
            alert("Enter charges");
            return false;
        }

        //if (document.getElementById("MainContent_ddlService").value == "0") {

        //    alert("Please Select Service!");
        //    return false;

        //}
        //if (document.getElementById("MainContent_ddlConsDoctorName").value == "0") {

        //    alert("Please Select Consultant Doctor!");
        //    return false;

        //}
        //if (document.getElementById("MainContent_ddlBillGroup").value == "0") {
        //    //If the "Please Select" option is selected display error.
        //    alert("Please Select Bill Group!");
        //    return false;

       // }



        
        
        if (document.getElementById("MainContent_txtPatientName").value == "") {
            alert("Please Enter Patient Name!");
            return false;

        }
        if (document.getElementById("MainContent_txtService").value == "") {
            alert("Please select Test Name!");
            return false;

        }

        //if (document.getElementById("MainContent_txtAge").value == "") {
        //    alert("Please Enter Age!");
        //    return false;

        //}
        //if (document.getElementById("MainContent_txtMobileNo").value == "") {
        //    alert("Please Enter Mobile No");
        //    return false;
        //}
        


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
           
             <asp:PostBackTrigger ControlID="btnCaseReport" />
            <asp:PostBackTrigger ControlID="btnsave" />
             
        </Triggers>
        <ContentTemplate>
        

            <section class="content-header d-flex">
                    <h1>Lab Registration</h1>
                    <ol class="breadcrumb">
                       
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Lab Registration</li>
                    </ol>
                </section>
            <section class="content">
               
                 <div class="box" runat="server" id="Show">

                    
                 <!--    <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          <asp:Label ID="lblVisitingNo" class="red pull-center"  runat="server" Font-Bold="True" ForeColor="#0066FF" Font-Size="Medium" Width="500px" ></asp:Label>
                          
                                </div>-->
                    
                               <div class="box-body">
                                    <div class="row"> 
                                        <div id="Div5" class="col-lg-12 mt-3" runat="server" > 
                                            <div class="row">
                                                <div class="col-sm-3 text-center">
                                                        <div class="form-group"> 
                                                            <asp:Label ID="lblChargeNo" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="Blue" ></asp:Label>
                                                            </div>
                                                    </div>
                                                <div class="col-sm-7 text-center">

                                                    <div class="form-Inline form-check" font-bold="True">
                                                        <asp:RadioButtonList ID="RBLLabType" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True"  Font-Bold="True" Font-Size="Medium" OnSelectedIndexChanged="RBLLabType_SelectedIndexChanged" >
                                                             <asp:ListItem Value="P" >Pathology</asp:ListItem>
                                                             <asp:ListItem Value="R">Radiology</asp:ListItem>                                                            
                                                             <asp:ListItem Value="M">Medical Lab</asp:ListItem>
                                                             <asp:ListItem Value="C">Other Studies</asp:ListItem>
                                                         
                                                             </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                 <div class="col-sm-2 text-center">
                                                        <div class="form-group"> 
                                                          <asp:CheckBox ID="ChkAfterhrs" CssClass="BigCheckBox" ForeColor="Red" Font-Bold="true" runat="server"  Text="&nbsp;&nbsp;   After Hrs" />
                                                            
                                                            </div>
                                                     </div>
                                                </div>
                                            </div>
                                        <div class="col-lg-12 mt-3" runat="server" visible="false"> 
                                            <div class="row">

                                                <div class="col-sm-2 text-center">

                                                    <div class="form-Inline form-check" font-bold="True"> 
                                                         <asp:RadioButtonList ID="rdbgroup" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbgroup_SelectedIndexChanged" Font-Bold="True" Font-Size="Medium" Width="659px" >
                                                             <asp:ListItem>OPD</asp:ListItem>
                                                             <asp:ListItem>EMERGENCY</asp:ListItem>
                                                             <asp:ListItem Value="EEG OPD">EEG OPD</asp:ListItem>
                                                             <asp:ListItem>AMBULANCE</asp:ListItem>
                                                             <asp:ListItem>OPHTHAL</asp:ListItem>
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>
                                                 </div>
                                                     </div>
                                        
                                                <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <%-- <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientCategoryName">Sponser Category</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>--%>
                                         <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                           <asp:DropDownList ID="ddlPatientCategoryName" Visible="false" runat="server"  AutoPostBack="True" TabIndex="1" CssClass="form-control form-select"
                                                                OnSelectedIndexChanged="ddlPatientCategoryName_SelectedIndexChanged">
                                                         </asp:DropDownList>                    
                                                                <asp:RadioButtonList ID="rblPatcate" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True"  ForeColor="Red" Font-Bold="True" Font-Size="Medium" OnSelectedIndexChanged="rblPatcate_SelectedIndexChanged" >
                                                             <asp:ListItem Selected="True" Value="1" >Paying</asp:ListItem>
                                                             <asp:ListItem Value="2">Insurance</asp:ListItem>                                                            
                                                             <asp:ListItem Value="3">Charge</asp:ListItem>
                                                         
                                                             </asp:RadioButtonList>      
                                                       </div>
                                                    </div>
                                            
                                         <div class="col-sm-5 text-left">
                                                    <div class="form-group">
                                        
                                                        <asp:DropDownList ID="ddlPatientSubCategoryName" runat="server" Visible="false"  AutoPostBack="True" TabIndex="2" CssClass="form-control form-select"
                                                          OnSelectedIndexChanged="ddlPatientSubCategoryName_SelectedIndexChanged">
                                                         </asp:DropDownList>    
                                                        
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
                                                        <asp:DropDownList ID="ddlChargeSubCategory" runat="server" AutoPostBack="True"  Visible="false" CssClass="form-control form-select" 
                                                            OnSelectedIndexChanged="ddlChargeSubCategory_SelectedIndexChanged">
                                                         </asp:DropDownList> 
                                                        
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
                                                <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Patient Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                            <div class="col-sm-2 text-left" runat="server" visible="false">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlTitleName" runat="server" CssClass="form-control form-select pull-left" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlTitleName_SelectedIndexChanged" TabIndex="1">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>                       
                                                <div class="col-sm-10 text-left">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged" Font-Bold="True" Font-Size="Medium"  ></asp:TextBox>
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
                                               
                                                </div>
                                            </div>
                                                 <div class="col-lg-12 mt-3"> 
                                            <div class="row">  
                                                <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Birth Date</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                                <div class="col-sm-3 text-left">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                    
                                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server"  CssClass="form-control" TabIndex="4" 
                                                             AutoPostBack="True" OnTextChanged="txtBirthDate_TextChanged"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                     
                        
                                                        </div>
                                                       
                                                        </div>
                                                    </div>
                                                                                         
                                                        <div class="col-sm-1 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtAge">Age</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>     
                                                                                                       
                                                           <div class="col-sm-1 text-left">
                                                           <div class="form-group"> 
                                                                                                                     
                                                       
                                                                <asp:TextBox ID="txtAge" runat="server" TabIndex="5" CssClass="form-control" placeholder="Age" 
                                                               ontextchanged="txtAge_TextChanged"  onkeyPress="return numeric_only(event);" AutoPostBack="True"></asp:TextBox>
                                                            
                                                           </div>
                                                         </div>     
                                                                                                                                                   
                                                           <div class="col-sm-2 text-left">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        CssClass="form-control form-select" 
                                                                        TabIndex="6" onselectedindexchanged="ddlAge_SelectedIndexChanged">
                                                                        <asp:ListItem>Year</asp:ListItem>
                                                                        <asp:ListItem>Month</asp:ListItem>
                                                                        <asp:ListItem>Day</asp:ListItem>
                                                                    </asp:DropDownList>
                                                           </div>
                                                           
                                                         
                                                        </div>
                                                <div class="col-sm-2 text-left">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                        OnSelectedIndexChanged="ddlGender_SelectedIndexChanged" 
                                                        TabIndex="6" Enabled="true">
                                                        </asp:DropDownList>
                                                    </div>
                                               </div>
                                                </div>
                                                     </div>

                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">  
                                                 <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtMobileNo">Mobile No</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>    
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">
                                                       
                                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Enter Mobile No." 
                                                             onkeyPress="return numeric_only(event);" TabIndex="7" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                 <div class="col-sm-2 text-right">
                                                    <div class="form-group">
                                                       
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                <div class="col-sm-1 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientAddress">Address</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                <div id="Div2" class="col-sm-5  text-left" runat="server">
                                                    <div class="form-group">
                                                      <asp:TextBox ID="txtPatientAddress" runat="server" CssClass="form-control"   placeholder="Enter Patient Address"
                                            TabIndex="8"  AutoPostBack="false" OnTextChanged="txtPatientAddress_TextChanged"></asp:TextBox>
                                                    </div>
                                                   </div> 
                                 </div>
                                            </div> 
                                          
                                             
                                                  
                                                <div id="refdr" visible="false" runat="server">
                                                    <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtDoctorName">Ref.Doctor</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                 <div class="col-sm-2 text-left">
                                                    <div class="form-group">
                                                           
                                                        <div id="Div1" style="width:100px;height:100px; overflow:auto; background-color: #0000FF;" ></div>
                                         <asp:TextBox ID="txtDoctorName" CssClass="form-control" TabIndex="9" Placeholder="Enter Reference Doctor"   runat="server" AutoCompleteType="None" AutoPostBack="True"
                                         Width="205px" ontextchanged="txtDoctorName_TextChanged"  ></asp:TextBox>

                                     <asp:AutoCompleteExtender 
                                                    MinimumPrefixLength="1"
                                                    CompletionListElementID="Div1" 
                                                      ServiceMethod="SearchReferalDoctor"
                                                    ServicePath="~/AutoCompleteService.asmx"
                                                    CompletionInterval="100"
                                                    EnableCaching="true" 
                                                    CompletionSetCount="10" 
                                                    TargetControlID="txtDoctorName"
                                                    ID="AutoCompleteExtender2"
                                                    runat="server"
                                                    FirstRowSelected="false" 
                                          CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                    OnClientItemSelected = "ClientItemSelected1"
                                                    DelimiterCharacters=";, :"
                                                    ShowOnlyCurrentWordInCompletionListItem="true">
                                            </asp:AutoCompleteExtender>

                                                     </div>
                                                 </div>  
                                                 <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientComplaint">Patient Complaints</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                 <div class="col-sm-2 text-left">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtPatientComplaint" runat="server" CssClass="form-control"   placeholder="Enter Patient Complaint"
                                            TabIndex="19" ></asp:TextBox>
                                                     </div>

                                                 </div> 
                                                 <div id="Div3" class="col-sm-2 text-left" runat="server" visible="false">
                                                    <div class="form-group">
                                                           
                                                        <asp:TextBox ID="txtReferanceDrText" runat="server" CssClass="form-control"    placeholder="Enter Ref. Dr"
                                                      TabIndex="18"></asp:TextBox>
                
              
                                                     </div>
                                                 </div> 
                                                </div>
                                            </div>
                                               </div>    
                                                   
                                         <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="ggfdgfd">Ref By</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-sm-4 text-left">
                                                    <div class="form-group">     
                                                        
                                                         <asp:TextBox ID="txtRefBy" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Ref By(*)"
                                               AutoPostBack="True" TabIndex="10"  onkeyPress="return alpha_only(event);" OnTextChanged="txtRefBy_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchReferBy"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtRefBy"
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                ID="AutoCompleteExtender7"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>
                                                 <div class="col-sm-1 text-left" runat="server" >
                                                        <div class="form-group"> 
                                                            <label for="hhdg">Consultant</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-sm-3 text-left" runat="server" >
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" Visible="false" AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="180" Font-Bold="True" Font-Size="Large">
                                                            </asp:DropDownList>                   
                                                         <asp:TextBox ID="txtdepartment" runat="server" Visible="false" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Department Name(*)"
                                                AutoPostBack="True" TabIndex="11"  onkeyPress="return alpha_only(event);" OnTextChanged="txtdepartment_TextChanged" ></asp:TextBox>
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
                                                ID="AutoCompleteExtender6"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                                 <asp:TextBox ID="txtConsDoctorName_New" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Consultant By(*)"
                                               AutoPostBack="True" TabIndex="10"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_New_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtConsDoctorName_New"
                                                ID="AutoCompleteExtender5"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div> 
                                                     <div class="col-sm-2 text-left">
                                                    <div class="form-group">
                                                       
                                                            <asp:TextBox ID="txtLetterNo" runat="server" class="form-control" placeholder="Enter Letter No." 
                                                             ></asp:TextBox>
                                                        </div>
                                                    </div> 
                                                </div>
                                             </div>
                                                   
                                          <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="ggfdgfd">Ref phy</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                   <div class="col-sm-2 text-left">
                                                    <div class="form-group">     
                                                        
                                                         <asp:TextBox ID="txtRefPhy" runat="server" AutoCompleteType="None"  AutoPostBack="true" OnTextChanged="txtRefPhy_TextChanged" CssClass="form-control" placeholder="Enter Ref phy"
                                              TabIndex="10"  onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchReferBy"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtRefPhy"
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                ID="AutoCompleteExtender8"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>
                                                 <div class="col-sm-1 text-left">
                                                        <div class="form-group"> 
                                                            <label for="ggfdgfd">Main Dr</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">     
                                                        
                                                           <asp:DropDownList ID="DdlMainDoctor" runat="server" CssClass="form-control form-select" ></asp:DropDownList>
                                              
                                                    </div>
                                                </div>
                                                <div class="col-sm-2 text-left">
                                                    <div class="form-group">     
                                                        
                                                           <asp:DropDownList ID="ddlCenterName" runat="server" CssClass="form-control form-select" ></asp:DropDownList>
                                              
                                                    </div>
                                                </div>
                                                   <div class="col-sm-3 text-left">
                                                    <div class="form-group">     
                                                        
                                                         <asp:TextBox ID="txtotherrefDocror" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Other Ref Doctor"
                                              TabIndex="10"  onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                              
                                                    </div>
                                                </div>
                                                </div>
                                              </div>
                                       
                                        <div class="col-lg-12 mt-3" runat="server" visible="false" >  
                                             <div class="row">                               
                                     <label>Group Name</label>
                                            <div class="row" runat ="server" visible="false">
                                                <div class="col-sm-4 text-left">
                                                    <div class="form-group">  
                                                        
                                                         <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                         OnSelectedIndexChanged="ddlBillGroup_SelectedIndexChanged" TabIndex="12">
                                                        </asp:DropDownList>  
                                                        </div>
                                                    </div>
                                                </div>
                                                 </div>
                                               </div>
                                    <div class="row mt-3">
                                       
                                              
                                                
                                         <div id="Div4" class="col-sm-2 text-left" runat="server" >
                                                    <div class="form-group">   
                                                        <label for="ggfdgfd">Add Test: </label>  
                                                        </div>
                                             </div>
                                                <div class="col-sm-6 text-left">
                                                    <div class="form-group">  
                                                                                         
                                    <asp:TextBox ID="txtService" runat="server" TabIndex="13" AutoCompleteType="None" BackColor="#99CCFF" Font-Bold="True" Font-Size="Larger"  CssClass="form-control" placeholder="Enter Test Name(*)"
                                               AutoPostBack="True"   onkeyPress="return alpha_only(event);" OnTextChanged="txtService_TextChanged" ></asp:TextBox>
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                       <%-- <div style="display: none; overflow: scroll; width: 348px; height: 320px; font-size:15pt;" id="div">
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender9" runat="server"
                                                                CompletionListElementID="div" ServiceMethod="SearchService"  BehaviorID="TTTTT"  TargetControlID="txtService"
                                                                MinimumPrefixLength="1">
                                                            </cc1:AutoCompleteExtender>--%>
                                                    
                                                    </div>
                                                </div>
                                        

                                              <div class="col-sm-2 text-left"  runat="server" visible="false">
                                                    <div class="form-group">     
                                                        <asp:DropDownList ID="ddlConsDoctorName" runat="server"
                                                         CssClass="form-control form-select" Visible="false" AutoPostBack="true"   TabIndex="140" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  TabIndex="14" CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                           
                                                            </div>
                                                           <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtConsDoctorName"
                                                ID="AutoCompleteExtender4"
                                                                 CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                        
                                                    </div>
                                               


                                                <div class="col-sm-1 text-left">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtCharges" runat="server"  onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control" AutoPostBack="true" placeholder=" Charges" TabIndex="15" OnTextChanged="txtCharges_TextChanged" Font-Bold="True"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>  
                                      <!--  <div class="col-sm-2 text-left">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtQty" runat="server" Visible="false" Enabled="false" onkeyPress="return numeric_only(event);" AutoPostBack="true"
                                                        CssClass="form-control" placeholder="Enter Qty" TQabIndex="16" OnTextChanged="txtQty_TextChanged" Font-Bold="True"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div> -->
                                        <div class="col-sm-1 text-left">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtTotalCharges"  runat="server" readonly="true" onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control"  TabIndex="130" Font-Bold="True"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>              

                                                <div class="col-sm-1">
                                            <asp:Button ID="btnAdd" runat="server"  CssClass="btn btn-primary" OnClick="btnAdd_Click" TabIndex="17" OnClientClick="return Validate();"
                                            Text="Add" />
                                        </div>
                                    
                                  </div>
                                  </div> 
                                     <div class="messagealert" id="alert_container">
                                             
            </div>   
                                        <div class="col-lg-12 mt-3">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%" >
                                             <div style=" overflow: scroll; width: 100%; height: 300px; text-align: left"
                                                                                id="Div6">
                                <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" 
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="170"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing" PageSize="1000">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>                                
                                    <asp:CommandField ButtonType="Image"  EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                               <asp:BoundField DataField="Service" HeaderText="Test Name"  >  
                                   
                                    <ItemStyle Width="150px" Font-Bold="True" Font-Size="Medium" /></asp:BoundField>
                                 <asp:BoundField DataField="Empname" Visible="false" HeaderText="Consultant Dr"  > 
                                   
                                    <ItemStyle Width="120px" Font-Bold="True" Font-Size="Medium" />
                                    </asp:BoundField>
                                 <asp:BoundField DataField="SingleBillServiceCharges" Visible="false" HeaderText="Charges"  >  
                                    
                                <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" HorizontalAlign="center" /></asp:BoundField>
                              
                                <asp:BoundField DataField="Qty" Visible="false" HeaderText="Qty"  >
                                    
                                    <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" /> </asp:BoundField>
                              
                                <asp:BoundField DataField="Charge" HeaderText="Total Charge"  >  
                                   
                                <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" HorizontalAlign="center" /></asp:BoundField>

                                  <asp:BoundField DataField="DrId" HeaderText="Consultant Dr Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>                            
                               
                                 <asp:BoundField DataField="BillServiceId" HeaderText="Service Id" Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HdnMTcode" runat="server" Value='<%#Eval("MTCode") %>' />
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                             <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="center" />                                     
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
                                                               
                                       </div>
                                  <div runat="server" id="KKK">
                                        <div class="col-lg-12 mt-3">                                            
                                            <div class="row"> 
                                                    
                                                           
                                                    
                                                    <div class="col-sm-6 text-left">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>

                                                 <div class="col-sm-1 text-left">
                                                                   <label> Report </label>
                                                              </div>

                                                 <div class="col-sm-5 text-left">

                                                    <div class="form-Inline form-check"> 
                                                         
                                                        <asp:CheckBoxList id="RblRepType" Font-Bold="true" ForeColor="Red" RepeatDirection="Horizontal"  runat="server">
                                                            <asp:ListItem Selected="True" Value="Print">Print</asp:ListItem>
                                                             <asp:ListItem Value="Email">Email</asp:ListItem>
                                                             <asp:ListItem Value="WhatApp">WhatApp</asp:ListItem>
                                                        </asp:CheckBoxList>                                           
                      
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
                                                         <div class="col-sm-2 text-left">
                                                    <div class="form-group"> 
                                                      <asp:Label ID="LblValMsg" CssClass="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>

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
                                                                               
                                                        <asp:DropDownList ID="txtbankName" runat="server"  CssClass="form-control"    placeholder="Bank Name"  ></asp:DropDownList>

                                                               </div>
                                                        </div>
                                                       <div class="col-sm-2 text-left" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                            
                                                          <asp:TextBox ID="txtchequedate" runat="server" placeholder="Cheque Date" AutoPostBack="true" CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>
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
                                                        
                                                        <input id="rdbdiscAmt" type="radio" name="rdbDisc" disabled="disabled" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>
                <input id="rdbdiscPer" type="radio" runat="server" disabled="disabled" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
                                                         
                                                        </div>
                                                     </div>
                                                       <div class="col-sm-2 text-left">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtDiscount" runat="server"  Enabled="false"  CssClass="form-control" placeholder="Discount"
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
                                                       
                                                               <asp:DropDownList ID="ddlDiscReason" runat="server"  AutoPostBack="True" CssClass="form-control form-select" OnSelectedIndexChanged="ddlDiscReason_SelectedIndexChanged" >
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
                                                        <label> Staff Name: </label>
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
                                                                               
                                                        <asp:TextBox ID="txtbalance" runat="server"  CssClass="form-control" Enabled="false"    placeholder="Balance" onkeyPress="return numeric_only(event);"
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
                                     <div class="col-lg-12 mt-3">  
                                                    <div class="row">
                                                            <div class="col-sm-2 text-center">
                                                           <div class="form-group"> 
                                                                 <asp:CheckBox ID="ChkPayforCash" CssClass="BigCheckBox" AutoPostBack="true" ForeColor="Red" Font-Bold="true" runat="server"  Text="&nbsp;Pay at Cashier" OnCheckedChanged="ChkPayforCash_CheckedChanged" />

                                                               </div>
                                                                 </div>
                                          <div class="col-sm-10 text-center">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save & Bill"  OnClick="btnSave_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';"
                                        TabIndex="15" class="btn btn-success"  />
                                               <asp:Button ID="btnCaseReport" runat="server" Text="Case Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" OnClick="btnCaseReport_Click" Visible="False"/>

                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="80px" />
                                  </div>
                                                        </div>
                                    
                                             
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


