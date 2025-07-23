<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EditLabPatientRegistration.aspx.cs" Inherits="EditLabPatientRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Src="UserControls/ucPatientInfo.ascx" TagName="ucPatientInfo" TagPrefix="uc1" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
                    <h1>Edit Lab Registration</h1>
                    <ol class="breadcrumb">
                       
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Edit Lab Registration</li>
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
                                        <div class="col-lg-12" runat="server" visible="false"> 
                                            <div class="row">

                                                <div class="col-lg-1 col-lg-offset-2 text-center" style="width:680px">

                                                    <div class="form-Inline" font-bold="True"> 
                                                         <asp:RadioButtonList ID="rdbgroup" runat="server"  BackColor="#66ccff" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbgroup_SelectedIndexChanged" Font-Bold="True" Font-Size="Medium" Width="659px" >
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
                                        
                                                <div class="col-lg-12"> 
                                            <div class="row">
                                                  <div class="col-lg-1 text-left" style="width:140px">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientCategoryName" style="text-align:left">Sponser Category</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                         <div class="col-lg-3 text-left" style="width:290px">
                                                        <div class="form-group"> 
                                                           <asp:DropDownList ID="ddlPatientCategoryName" runat="server" AutoPostBack="True" TabIndex="1" CssClass="form-control"
                                                                OnSelectedIndexChanged="ddlPatientCategoryName_SelectedIndexChanged"
                                                            Width="280px" >
                                                         </asp:DropDownList>                    
                                                                       
                                                       </div>
                                                    </div>
                                               <div class="col-lg-1 text-left" style="width:170px">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientSubCategoryName" style="text-align:left">Sponser SubCategory</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                         <div class="col-lg-3 text-left" style="width:300px">
                                                    <div class="form-group">
                                        
                                                         <asp:DropDownList ID="ddlPatientSubCategoryName" runat="server" AutoPostBack="True" TabIndex="2" CssClass="form-control"
                                                          OnSelectedIndexChanged="ddlPatientSubCategoryName_SelectedIndexChanged" Width="280px" >
                                                         </asp:DropDownList>                    
                                                       
                                                    </div>
                                                </div> 
                                            </div>
                                        </div>
                                        <div class="col-lg-12" > 
                                            <div class="row">  
                                                <div class="col-lg-1 text-left" style="width:140px">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName" style="text-align:left">Patient Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                            <div class="col-lg-1 text-left" style="width:100px">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlTitleName" runat="server" CssClass="form-control pull-left" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlTitleName_SelectedIndexChanged" Width="95px" TabIndex="1">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>                       
                                                <div class="col-lg-8 text-left" style="width:740px"  >
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter Patient Name(*)"
                                                Width="740px" AutoPostBack="True" ontextchanged="txtPatientName_TextChanged" Font-Bold="True" Font-Size="Medium"  ></asp:TextBox>
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
                                                 <div class="col-lg-12" > 
                                            <div class="row">  
                                                <div class="col-lg-1 text-left" style="width:140px">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate" style="text-align:left">Birth Date</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                                <div class="col-lg-3  text-left" style="width:220px">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                    
                                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server"   TabIndex="4" 
                                                             Width="162px" Height="30px" AutoPostBack="True" OnTextChanged="txtBirthDate_TextChanged" BorderStyle="Outset"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                </span>                                                     
                        
                                                        </div>
                                                       
                                                        </div>
                                                    </div>
                                                                                         
                                                        <div class="col-lg-1 text-left" style="width:60px">
                                                        <div class="form-group"> 
                                                            <label for="txtAge" style="text-align:left">Age</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>     
                                                                                                       
                                                           <div class="col-lg-1 text-left" style="width:75px">
                                                           <div class="form-group"> 
                                                                                                                     
                                                       
                                                                <asp:TextBox ID="txtAge" runat="server" TabIndex="5" class="form-control" placeholder="Age" 
                                                                Width="75px" ontextchanged="txtAge_TextChanged"  onkeyPress="return numeric_only(event);" AutoPostBack="True"></asp:TextBox>
                                                            
                                                           </div>
                                                         </div>     
                                                                                                                                                   
                                                           <div class="col-lg-1 text-left" style="width:100px">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        class="form-control" 
                                                                        TabIndex="6" Width="90px" 
                                                                        onselectedindexchanged="ddlAge_SelectedIndexChanged">
                                                                        <asp:ListItem>Year</asp:ListItem>
                                                                        <asp:ListItem>Month</asp:ListItem>
                                                                        <asp:ListItem>Day</asp:ListItem>
                                                                    </asp:DropDownList>
                                                           </div>
                                                           
                                                         
                                                        </div>
                                                <div class="col-lg-2 text-left" style="width:120px">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" class="form-control"
                                                        OnSelectedIndexChanged="ddlGender_SelectedIndexChanged" Width="110px" 
                                                        TabIndex="6" Enabled="true">
                                                        </asp:DropDownList>
                                                    </div>
                                               </div>
                                                 <div class="col-lg-1 text-left" style="width:90px">
                                                        <div class="form-group"> 
                                                            <label for="txtMobileNo" style="text-align:left">Mobile No</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>    
                                                <div class="col-lg-2 text-left" style="width:120px">
                                                    <div class="form-group">
                                                       
                                                            <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Enter Mobile No." 
                                                             onkeyPress="return numeric_only(event);" TabIndex="7" 
                                                            Width="195px"></asp:TextBox>
                                                        </div>
                                                    </div>
                                 </div>
                                            </div> 
                                          <div class="col-lg-12"> 
                                            <div class="row">
                                             
                                                  <div class="col-lg-1 text-left" style="width:140px">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientAddress" style="text-align:left">Address</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                <div id="Div2" class="col-lg-2  text-left" runat="server"  style="width:740px">
                                                    <div class="form-group">
                                                      <asp:TextBox ID="txtPatientAddress" runat="server" class="form-control"   placeholder="Enter Patient Address"
                                            TabIndex="8"  Width="740px" AutoPostBack="True" OnTextChanged="txtPatientAddress_TextChanged"></asp:TextBox>
                                                    </div>
                                                   </div> 
                                                <div id="refdr" visible="false" runat="server">
                                                 <div class="col-lg-1 text-left" style="width:90px">
                                                        <div class="form-group"> 
                                                            <label for="txtDoctorName" style="text-align:left">Ref.Doctor</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-2 text-left" style="width:220px">
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
                                                 <div class="col-lg-1 text-left" style="width:150px">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientComplaint" style="text-align:left">Patient Complaints</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-2 text-left" style="width:300px">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtPatientComplaint" runat="server" class="form-control"   placeholder="Enter Patient Complaint"
                                            TabIndex="19"  Width="290px"></asp:TextBox>
                                                     </div>

                                                 </div> 
                                                 <div id="Div3" class="col-lg-2 text-left" runat="server" visible="false" style="width:200px">
                                                    <div class="form-group">
                                                           
                                                        <asp:TextBox ID="txtReferanceDrText" runat="server" class="form-control"    placeholder="Enter Ref. Dr. Text"
                                                     Width="190px" TabIndex="18"></asp:TextBox>
                
              
                                                     </div>
                                                 </div> 
                                               </div>    
                                                </div>
                                            </div>   
                                         <div class="col-lg-12"> 
                                            <div class="row">
                                                 <div class="col-lg-2 text-left" style="width:140px">
                                                        <div class="form-group"> 
                                                            <label for="ggfdgfd" style="text-align:left">Ref By</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-lg-4 text-left">
                                                    <div class="form-group">     
                                                        
                                                         <asp:TextBox ID="txtRefBy" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Ref By(*)"
                                               AutoPostBack="True" TabIndex="10"  onkeyPress="return alpha_only(event);" OnTextChanged="txtRefBy_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchReferBy"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtRefBy"
                                                ID="AutoCompleteExtender7"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>
                                                 <div class="col-lg-2 text-left" style="width:140px" runat="server" >
                                                        <div class="form-group"> 
                                                            <label for="hhdg" style="text-align:left">Consultant</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-lg-4 text-left"  style="width:250px" runat="server" >
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" Width="190px" Visible="false" AutoPostBack="True" class="form-control"
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
                                                </div>
                                             </div>
                                                   
                                         
                                       
                                        <div class="col-lg-12" runat="server" visible="false" >                                 
                                     <label>Group Name</label>
                                            <div class="row" runat ="server" visible="false">
                                                <div class="col-lg-4 text-left" style="width:450px"">
                                                    <div class="form-group">  
                                                        
                                                         <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" class="form-control"
                                                         OnSelectedIndexChanged="ddlBillGroup_SelectedIndexChanged" Width="440px" height="30px" 
                                                         TabIndex="12">
                                                        </asp:DropDownList>  
                                                        </div>
                                                    </div>
                                                </div>
                                    <div class="row">
                                       
                                               <%-- <div class="col-lg-2 text-left" style="width:250px"">
                                                    <div class="form-group">                                                              
                                                        <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" class="form-control"
                                                         OnSelectedIndexChanged="ddlBillGroup_SelectedIndexChanged" Width="240px" height="30px" 
                                                         TabIndex="10">
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                                    </div>--%>
                                                
                                         <div id="Div4" class="col-lg-1 text-left" style="width:155px" runat="server" visible="false" >
                                                    <div class="form-group">   
                                                        <label for="ggfdgfd" style="text-align:right">Add Test: </label>  
                                                        </div>
                                             </div>
                                                <div class="col-lg-4 text-left" style="width:450px" runat="server" visible="false">
                                                    <div class="form-group">  
                                                                                         
                                    <asp:TextBox ID="txtService" runat="server" TabIndex="13" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Test Name(*)"
                                                Width="440px" AutoPostBack="True"   onkeyPress="return alpha_only(event);" OnTextChanged="txtService_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
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
                                        

                                              <div class="col-lg-2 text-left" style="width:210px" runat="server" visible="false">
                                                    <div class="form-group">     
                                                        <asp:DropDownList ID="ddlConsDoctorName" runat="server"
                                                         class="form-control" Width="240px" Visible="false" AutoPostBack="true"   TabIndex="140" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  TabIndex="14" CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                                Width="200px" AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>


                                                <div class="col-lg-2 text-left" style="width:120px" runat="server" visible="false">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtCharges" runat="server"  onkeyPress="return numeric_only(event);"
                                                        class="form-control" AutoPostBack="true" placeholder=" Charges" TabIndex="15" Width="110px" OnTextChanged="txtCharges_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>  
                                        <div class="col-lg-1 text-left" style="width:80px">
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtQty" runat="server" Visible="false" Enabled="false" onkeyPress="return numeric_only(event);" AutoPostBack="true"
                                                        class="form-control" placeholder="Enter Qty" TQabIndex="16" Width="70px" OnTextChanged="txtQty_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div> 
                                        <div class="col-lg-2 text-left" style="width:120px" >
                                                    <div class="form-group">  
                                                        <asp:TextBox ID="txtTotalCharges" Visible="false"  runat="server" readonly="true" onkeyPress="return numeric_only(event);"
                                                        class="form-control"  TabIndex="130" Width="110px" Font-Bold="True" Font-Size="Medium"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>              

                                                <div class="col-lg-1 text-right">
                                            <asp:Button ID="btnAdd" runat="server" Visible="false"  CssClass="btn btn-primary" OnClick="btnAdd_Click" TabIndex="17" OnClientClick="return Validate();"
                                            Text="Add" />
                                        </div>
                                    
                                    </div>
                                  </div> 
                                        <div class="col-lg-12">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%" >
                                <asp:GridView ID="gvBill" DataKeyNames="ProcedureServiceId" runat="server" AutoGenerateColumns="False" 
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="170"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
  <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>                                
                                    <asp:CommandField ButtonType="Image"  Visible="false" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                               <asp:BoundField DataField="ServiceNAme" HeaderText="Test Name"  >  
                                   
                                    <ItemStyle Width="150px" Font-Bold="True" Font-Size="Medium" /></asp:BoundField>
                                
                                                            
                              
                                <asp:BoundField DataField="BillServiceCharges" HeaderText="Total Charge"  >  
                                   
                                <ItemStyle Width="50px" Font-Bold="True" Font-Size="Medium" HorizontalAlign="center" /></asp:BoundField>

                                                     
                               
                                 <asp:BoundField DataField="ProcedureServiceId" HeaderText="Service Id" Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HdnMTcode" runat="server" Value='<%#Eval("MTCode") %>' />
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                              
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
                                        <div class="col-lg-12" runat="server" visible="false">                                            
                                            <div class="row"> 
                                                    
                                                              <div class="col-lg-1 text-left" style="width:110px">
                                                                   <label> Payment By: </label>
                                                              </div>
                                                    
                                                    <div class="col-lg-1 text-left" style="width:380px">

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>

                                                <%-- <div class="col-lg-1 text-left" style="width:120px" >
                                             <div class ="row">
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="PaymentInsurance" Text="Is Insurance" runat="server" AutoPostBack="true" OnCheckedChanged="PaymentInsurance_CheckedChanged"></asp:CheckBox></label>
                                            </div>
                                            </div>--%>
                                        <div id="InsuranceDetails" runat="server">  
                                                       
                                                       <div class="col-lg-1 text-left" style="width:120px">
                                                           <div class="form-group">  
                                                        <label>InsuranceAmt: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:100px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtInsuranceAmt" runat="server"  class="form-control"  height="30px"  AutoPostBack="True"
                                                     Width="90px" TabIndex="80" OnTextChanged="txtInsuranceAmt_TextChanged1"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-lg-1 text-left" style="width:130px">
                                                    <div class="form-group">                                                      
                                                        

                      <asp:RadioButtonList ID="rdblInsuranceAmt" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdblInsuranceAmt_SelectedIndexChanged" >
                          <asp:ListItem Selected="True" Value="0">Amt</asp:ListItem>
                          <asp:ListItem Value="1">Per(%)</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                     </div>    
                                                        
                                                      <%-- <div class="col-lg-2 text-left" style="width:120px">
                                                           <div class="form-group">  
                                                        <label  style="width:110px" >InsuranceComp: </label>
                                                               </div>
                                                        </div>
                                                       
                                                           <div class="col-lg-2 text-left" style="width:190px">
                                                           <div class="form-group">  
                                                             <asp:DropDownList ID="ddlInsuranceCompName" runat="server" CssClass="form-control" AutoPostBack="true" Width="190px" ></asp:DropDownList>
                                                                   
                                                        
                                                               </div>
                                                        </div>--%>
                                                       
                                                            
                                                        </div>
                                                              
                                                 </div>
                                              </div>                                               
                                        <div id="PaymentDetails" runat="server" visible="false">
                                                
                                                       <div class="col-lg-12">
                                                           <div class="form-group"> 
                                                       <div class="col-lg-1 text-left"  style="width:130px">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"  height="30px"   placeholder="Card/Cheque No."
                                                     Width="120px" TabIndex="81"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:160px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbankName" runat="server"  class="form-control"  height="30px"   placeholder="Bank Name"
                                                     Width="150px" TabIndex="82"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" runat="server" id="ChequeDate" style="width:160px">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                            
                                                          <asp:TextBox ID="txtchequedate" runat="server" height="30px" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                  </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                               </div>
                                                           </div>
                                                       
                                                       </div>
                                        <div class="col-lg-12" runat="server" visible="false">                                            
                                                   <div class="row"> 
                                                       
                                                       <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> Total Amount: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:210px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtTotalAmt" runat="server" readonly="true" class="form-control"  height="30px"   placeholder="Total Amount"
                                                     Width="200px" TabIndex="83"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                               
                                                       
                                                
                                                     <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> Discount: </label>
                                                               </div>
                                                        </div>
                                                         <div class="col-lg-1 text-left" style="width:140px">
                                                    <div class="form-group"> 
                                                        
                                                        <input id="rdbdiscAmt" type="radio" name="rdbDisc" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>
                <input id="rdbdiscPer" type="radio" runat="server" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
                                                         
                                                        </div>
                                                     </div>
                                                       <div class="col-lg-1 text-left" style="width:150px">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtDiscount" runat="server"  class="form-control"  height="30px"   placeholder="Discount"
                                                     Width="140px" TabIndex="84" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged" onkeyPress="return numeric_only(event);"></asp:TextBox>
                       
                                                        </div>
                                                           </div>
                                                         
                                                        </div>
                                                        </div>
                                        <div class="col-lg-12" runat="server" visible="false">     
                                                     <div class="row">
                                                       
                                                          <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                                <label>Net Amount : </label>
                                                               </div>
                                                        </div>
                                                          <div class="col-lg-1 text-left" style="width:210px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtAmount" runat="server" readonly="true" class="form-control"   placeholder="Amount" onkeyPress="return numeric_only(event);"
                                                       Width ="200px" TabIndex="85" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                                               </div>
                                                        </div>

                                                          <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> Disc Reason : </label>
                                                               </div>
                                                        </div>
                                                          <div class="col-lg-1 text-left" style="width:280px">
                                                           <div class="form-group">  
                                                       
                                                               <asp:DropDownList ID="ddlDiscReason" runat="server" AutoPostBack="True" height="30px" 
                                                     Width="280px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                               
                                                       </div>
                                           </div>
                                        <div class="col-lg-12" runat="server" visible="false">    
                                                    <div class="row">
                                                      
                                                       <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> Paid : </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:210px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtPaid" runat="server"  class="form-control"  height="30px"   placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="86" OnTextChanged="txtPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> Disc Given By: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:280px">
                                                           <div class="form-group">  
                                                       
                                                               <asp:DropDownList ID="ddlDiscountGivenBy" runat="server" AutoPostBack="True" height="30px" 
                                                     Width="280px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                              
                                                       </div>
                                            </div>
                                        <div class="col-lg-12" runat="server" visible="false">  
                                                    <div class="row">
                                                       
                                                       <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> Balance : </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:210px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbalance" runat="server"  class="form-control"     placeholder="Balance" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="87"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:130px">
                                                           <div class="form-group">  
                                                        <label> BalanceReason: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:280px">
                                                           <div class="form-group">  
                                                                               
                                                       
                                                               <asp:DropDownList ID="ddlBalreason" runat="server" AutoPostBack="True"  
                                                     Width="280px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                               
                                                       </div>
                                            </div>
                                       
                                          <div class="col-lg-12 text-center" runat="server" visible="false">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save & Bill"  OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" Width="120px" class="btn btn-primary"  />
                                               <asp:Button ID="btnCaseReport" runat="server" Text="Case Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" OnClick="btnCaseReport_Click" Visible="False"/>

                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="80px" />
                                   <%-- <asp:Button ID="btnSaveandBill" runat="server" Text="Save & Bill" OnClientClick="return Validate1();"
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" 
                                        onclick="btnSaveandBill_Click"   />
                                             <asp:Button ID="btnCaseReport" runat="server" Text="Case Report" OnClientClick="target = '_blank';"
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" OnClick="btnCaseReport_Click"/>

                                    <asp:Button ID="btnConsultation" runat="server" Text="Consultation" onclientclick="target = '_blank';"
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" onclick="btnConsultation_Click" />
                                        <asp:Button ID="btnRdlcReport" runat="server" Text="RDLC Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" 
                                        onclick="btnRdlcReport_Click" onclientclick="target = '_blank';" />   --%>  
                                    
                                             
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

    <script language="javascript" type="text/javascript">
        function ValidateDelete() {
            var Check = confirm('Are you sure you want to Cancel this test ?')
            if (Check == true) {
                return true;
            }
            else {
                return false;
            }
        }

 </script> 
</asp:Content>


