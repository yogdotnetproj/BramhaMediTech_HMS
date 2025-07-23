<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patientonlineregistration.aspx.cs" Inherits="Patientonlineregistration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Patient Registration</title>
    <link href="cssmain/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="cssmain/master.css"/>
    <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css"/>
    <link href="cssmain/main.min.css" rel="stylesheet" />
  
    <!-- THEME STYLES-->
    <link rel="stylesheet" href="plugins/theme/css/theme.min.css">
    <link href="cssmain/themify-icons/css/themify-icons.css" rel="stylesheet" />
    
    <!-- PAGE LEVEL STYLES-->
    <link href="plugins/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <script type="text/javascript">
          function UploadFile(fileUpload) {
              if (fileUpload.value != '') {
                  document.getElementById("<%=btnUpload.ClientID %>").click();
             }
         }

     </script>
    <script type = "text/javascript">
        function ClientItemSelected(sender, e) {
            $get("<%=hfPatientId.ClientID %>").value = e.get_value();

        }

        //var hdnField ="0";
        //function gethdnValue() {
        //    alert("gg");
        //    if (document.getElementById("MainContent_ddlCountryName").value != "") {
        //        ShowInformation();

        //    }
        //}
        //$(document).ready(function () {
        //    $('[id*=ddlCountryName]').click(function () {
        //        $('[id*=Information]').collapse('show');
        //    });
        //})

        function Validate1() {



            if (document.getElementById("MainContent_txtFirstName").value == "") {
                alert("Please Enter First Name!");
                return false;

            }
            //if (document.getElementById("MainContent_txtLastName").value == "") {
            //    alert("Please Enter Last Name!");
            //    return false;

            //}
            if (document.getElementById("MainContent_ddlGender").value == "0") {
                alert("Select Gender");
                return false;
            }
            if (document.getElementById("MainContent_txtMobileNo").value == "") {
                alert("Please Enter Mobile No!");
                return false;
            }
            if (document.getElementById("MainContent_txtPatientAddress").value == "") {
                alert("Please Enter Patient Address!");
                return false;
            }
            if (document.getElementById("MainContent_ddlPatientCategoryName").value == "0") {
                alert("Please Select Patient Category!");
                return false;
            }
            if (document.getElementById("MainContent_ddlPatientSubCategoryName").value == "0") {
                alert("Please Select Patient Sub Category!");
                return false;
            }

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

    </script>
    <%-- <script type = "text/javascript">
         $("#txtFirstName").bind('keyup', function (e) {
    if (e.which >= 97 && e.which <= 122) {
        var newKey = e.which - 32;
        // I have tried setting those
        e.keyCode = newKey;
        e.charCode = newKey;
    }

    $("#txtFirstName").val(($("#txtFirstName").val()).toUpperCase());
});
  </script>--%>
    <script src="Scripts/1.3.2.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function capFirst(oTextBox) {
        oTextBox.value = oTextBox.value[0].toUpperCase() + oTextBox.value.substring(1);
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
    
   
  
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
        <ContentTemplate>
          
            
            <section class="content-header d-flex">
                    <h1>Online Patient Registration</h1>
                   

                
                </section>
            <section class="content">                              
                
                 <div class="box" runat="server" id="Show">
                      <asp:UpdatePanel ID="UpdatePaneLeftBox" runat="server" style="">
            <ContentTemplate>
                                <div class="box-header with-border">                           
                                     <asp:Label ID="Label1" runat="server" Text="Marked with * are compulsory" ForeColor="red" Font-Bold="true"> </asp:Label> 
                                     <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                     <asp:Label ID="lblRegNo" class="red pull-center"  runat="server" Text="" Font-Bold="true" Font-Size="Medium" ></asp:Label>
                         
                                </div>
                              
                                <div class="box-body">
                                    <div class="row">                                      
                                        
                                          
                    <div id="Div1" class="col-lg-12" runat="server" visible="false" >
                        <div class="row">
                            <div class="col-sm-10" >
                                <div class="row">
                                    <div class="col-sm-2">
                                           <div class="form-group">
                                               <label for="txtPatientName">Search Patient Name</label>
                                               </div>
                                        </div>
                                       <div class="col-sm-3">
                                           <div class="form-group">
                                             
                                                 <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"
                                                 AutoPostBack="True" Width="230px"  CssClass="form-control" placeholder="Enter Patient Name" ontextchanged="txtPatientName_TextChanged" ></asp:TextBox>
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                       </div>
                                           </div>
                                 
                                    <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtMobileNo">Mobile No:</label>
                                                        </div>
                                        </div>
                                     <div class="col-sm-3">
                                                    <div class="form-group">
                                                                                                                
                                                            <asp:TextBox ID="txtSearchMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile No." 
                                                             onkeyPress="return numeric_only(event);" 
                                                           MaxLength="10" TextMode="SingleLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                       <div class="col-sm-3">
                                           <div class="form-group">
                                                                                                                                                                                                                                   
                                     <asp:Button ID="btnSearch" runat="server" Text="Search"  CssClass="btn btn-primary"  CausesValidation="False" OnClick="btnSearch_Click" />
                    
                                    <asp:Button ID="btnNew" runat="server" Text="New"  CssClass="btn btn-primary"  onclick="btnNew_Click" CausesValidation="False" />
                                            
                                                </div>
                                     </div>  
                                        
                                     
                              </div>
                                                    
                             </div> 
                            <div id="Div2" class="col-sm-2" runat="server" visible="false" >
                                  
                                          <div class="form-group">
                                               <asp:Image ID="imgPatient" runat="server" AlternateText="Image Here" 
                                                BorderStyle="Outset" />
                                            
                                           
                             </div>
                               
                             </div>
                                                
                       </div>
                   </div>  
                            <div id="Div3" class="col-sm-2 text-left" runat="server" visible="false" >
                                                        <div class="form-group">
                                                            <label for="ddlPatientCategoryName">Vaccination Status</label>  
                                                            </div>

                                        </div>
                                        <div id="Div4" class="col-sm-10 text-left" runat="server" visible="false" >
                                                        <div class="form-group form-check">
                                                            <asp:RadioButtonList runat="server" ID="RblVaccineType" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True">No Vaccinated</asp:ListItem>
                                                                
                                                                <asp:ListItem>Partially Vaccinated</asp:ListItem>
                                                                <asp:ListItem Value="Fully Vaccinated">Fully Vaccinated</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </div>
                                            </div>  
                                        
                                         <div class="col-lg-12 mt-3" runat="server" id="ShowUserPas" visible="false">
                            <div class="row">   
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                               
                                                </div>
                                    </div>
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName"> <strong>User Name:</strong></label> 
                                                </div>
                                              </div> 
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                <asp:Label ID="lblUserName" runat="server" ForeColor="Green" Font-Bold="true"> </asp:Label> 
                                                </div>
                                              </div> 
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName"> <strong>Password:</strong></label> 
                                                </div>
                                              </div> 
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                <asp:Label ID="LblPassword" runat="server" ForeColor="Red" Font-Bold="true"> </asp:Label> 
                                                </div>
                                              </div> 
                                
                                </div>
                                             </div>           
                        <div class="col-lg-12 mt-3">
                            <div class="row">                                  
                             
                                                        
                                          
                                          <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName">First Name</label>  <span class="auto-style1"><strong>* </strong></span>    
                                                </div>
                                              </div>                                                                               
                                        <div id="Div5" class="col-sm-1 pr-0" runat="server" visible="false">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlTitleName" runat="server" CssClass="form-control pull-left form-select" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlTitleName_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>                                                       
                                        <div class="col-sm-2" >
                                            <div class="form-group">
                                                
                                                <asp:TextBox ID="txtFirstName" AutoCompleteType="None" runat="server" onChange="javascript:capFirst(this);"  CssClass="form-control" placeholder="Enter First Name(*)"
                                                TabIndex="1" AutoPostBack="false"
                                                ontextchanged="txtFirstName_TextChanged"></asp:TextBox>                    
                                            </div>
                                        </div> 
                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Middle Name:</label>   
                                               </div>
                                                      </div>
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                
                                                <asp:TextBox ID="txtMiddleName" AutoCompleteType="None" runat="server"  CssClass="form-control" placeholder="Enter Middle Name(*)"
                                                TabIndex="2" ></asp:TextBox>                    
                                            </div>
                                        </div> 
                                 <div class="col-sm-1"> 
                                                     <div class="form-group">
                                                          <label for="txtAge">Last Name</label>  <span class="auto-style1"><strong>* </strong></span>   
                                                        </div>
                                                          </div>                                             
                                                           <div class="col-sm-2">
                                                           <div class="form-group"> 
                                                                                                                     
                                                          <asp:TextBox ID="txtLastName" AutoCompleteType="None" runat="server"  CssClass="form-control" placeholder="Enter last Name(*)"
                                                TabIndex="3" ></asp:TextBox>      
                                                                <asp:TextBox ID="txtAge" Visible="false" runat="server" TabIndex="3" CssClass="form-control" placeholder="Age"
                                                                ontextchanged="txtAge_TextChanged" onkeyPress="return numeric_only(event);" AutoPostBack="True" ></asp:TextBox>
                                                            
                                                           </div>
                                                         </div>     
                                                                                                                                                   
                                                           <div class="col-sm-2">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList Visible="false" ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        CssClass="form-control form-select" 
                                                                        onselectedindexchanged="ddlAge_SelectedIndexChanged">
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
                                                <label for="ddlGender">Gender</label>  
                                                </div>
                                              </div>
                                               <div class="col-sm-2">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                        OnSelectedIndexChanged="ddlGender_SelectedIndexChanged"
                                                        TabIndex="4" Enabled="true">
                                                        </asp:DropDownList>
                                                    </div>
                                               </div>
                                                   
                                                
                                               
                                                 
                                                  <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Mobile No:</label>   <span class="auto-style1"><strong>* </strong></span>   
                                               </div>
                                                      </div>

                                               

                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                           
                                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Enter Mobile No." 
                                                             onkeyPress="return numeric_only(event);" TabIndex="5" MaxLength="7"></asp:TextBox>
                                                        </div>
                                                    </div> 
                                                <div id="Div6" class="col-sm-2" runat="server" visible="false">
                                                    <div class="form-group">
                                                 <asp:Button ID="btnEditImage" runat="server" Text="Image" CssClass="btn btn-primary"   CausesValidation="False" OnClick="btnEditImage_Click" />
                                            <asp:Button ID="btnRemoveImage" runat="server" Text="Remove" CssClass="btn btn-primary" CausesValidation="False" OnClick="btnRemoveImage_Click" />
                                  </div>
                                                    </div>
                                                <div class="col-sm-1">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">BirthDate:</label> <span class="auto-style1"><strong>* </strong></span>   
                                                        </div>
                                                    </div>
                                                                                                
                                                <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                          <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server" placeholder="dd / MM / YYYY"   CssClass="form-control" TabIndex="6" 
                                                             AutoPostBack="True" ontextchanged="txtBirthDate_TextChanged"></asp:TextBox>
                                                             
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
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlBloodGroup">Address:</label>     <span class="auto-style1"><strong>* </strong></span>     
                                                        </div>
                                                    </div>

                                                <div  class="col-sm-9">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                 
                                                       <textarea class="form-control w-100"  runat="server" id="txtPatientAddress" onChange="javascript:capFirst(this);" rows="1" tabindex="8" placeholder="Write Address here..."></textarea>
                                                    
                                                     </div>

                                                 </div>
                                                </div>
                                            </div>

                                          <div class="col-lg-12 mt-3"> 
                                            <div class="row"> 
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlBloodGroup">Ethnicity:</label>       
                                                        </div>
                                                    </div>
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                 
                                                        <asp:DropDownList ID="ddlRace" TabIndex="8" runat="server" 
                                                         CssClass="form-control form-select">  
                                                                   
                                                        </asp:DropDownList>
                                                     </div>

                                                 </div>
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlMaritalStatus">Religion:</label>       
                                                        </div>
                                                    </div>
                                                 <div id="Div7"  class="col-sm-2 pr-0" runat="server">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                        
                                                        <asp:DropDownList ID="ddlReligion" TabIndex="9" runat="server"  
                                                         CssClass="form-control form-select">
                                                                  
                                                        </asp:DropDownList>
              
                                                     </div>
                                                 </div>  
                                                 <div  class="col-sm-1">
                                                    <div class="form-group">
                                                         <label for="txtEmail">NIS No:</label>   
                                                        </div>
                                                    </div>                                                                 
                                                <div class="col-sm-2" >
                                                    <div class="form-group">
                                                        
                                                             <asp:TextBox ID="txthealthcardNo" runat="server" TabIndex="10" class="form-control" placeholder="Enter HealthCardNo"  
                                                            ></asp:TextBox>
                                                        </div>
                                                </div>                 
                                                             
                                               
                                                 
                                               </div>
                                         </div>
                               
                                                   <div id="Div8" class="col-lg-12 mt-3" runat="server" visible="false" > 
                                            <div class="row">  
                                                       <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlCountryName">Country Name:</label>
                                                        </div>
                                                           </div>                                
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                        
                                                            <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="form-control"  OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged"
                                                             AutoPostBack="True"  >
                                                            </asp:DropDownList>
                                                        </div>
                                                  </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlStateName">State Name:</label>
                                                        </div>
                                                           </div>
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                                
                                                            <asp:DropDownList ID="ddlStateName" runat="server" CssClass="form-control form-select" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged"
                                                           AutoPostBack="True" >
                                                            </asp:DropDownList>
                                                    </div>
                                                  </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlCityName">City Name:</label>
                                                        </div>
                                                           </div>
                                                 <div class="col-sm-2" >
                                                    <div class="form-group">
                                                                                                               
                                                            <asp:DropDownList ID="ddlCityName" CssClass="form-control form-select" runat="server" AutoPostBack="True" 
                                                             OnSelectedIndexChanged="ddlCityName_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                
                                                
                                            </div>
                                        
                                        </div>
                                          <div class="col-lg-12 mt-3"> 
                                            <div class="row"> 
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlBloodGroup">Blood Group:</label>       
                                                        </div>
                                                    </div>
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                 
                                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" 
                                                         CssClass="form-control" TabIndex="11">  
                                                                    <asp:ListItem></asp:ListItem>                                                         
                                                                    <asp:ListItem>A Positive</asp:ListItem>
                                                                    <asp:ListItem>A Negative</asp:ListItem>
                                                                    <asp:ListItem>B Positive</asp:ListItem>
                                                                    <asp:ListItem>B Negative</asp:ListItem>
                                                                    <asp:ListItem>AB Positive</asp:ListItem>
                                                                    <asp:ListItem>AB Negative</asp:ListItem>
                                                                    <asp:ListItem>O Positive</asp:ListItem>
                                                                    <asp:ListItem>O Negative</asp:ListItem>
                                                        </asp:DropDownList>
                                                     </div>

                                                 </div>
                                                <div  class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="ddlMaritalStatus">Marital Status:</label>       
                                                        </div>
                                                    </div>
                                                 <div id="Div9"  class="col-sm-2" runat="server">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                        
                                                        <asp:DropDownList ID="ddlMaritalStatus" runat="server"  
                                                         CssClass="form-control form-select" TabIndex="12" >
                                                                    <asp:ListItem></asp:ListItem> 
                                                                    <asp:ListItem>Married</asp:ListItem>
                                                                    <asp:ListItem>Unmarried</asp:ListItem>
                                                        </asp:DropDownList>
              
                                                     </div>
                                                 </div>  
                                                 <div  class="col-sm-1">
                                                    <div class="form-group">
                                                         <label for="txtEmail">Email Id:</label>   <span class="auto-style1"><strong>* </strong></span>   
                                                        </div>
                                                    </div>                                                                 
                                                <div class="col-sm-2" >
                                                    <div class="form-group">
                                                        
                                                             <asp:TextBox ID="txtEmail" runat="server" TabIndex="13" CssClass="form-control" placeholder="Enter Email Id"   
                                                            ></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" Font-Bold="true" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                                        </div>
                                                </div>                 
                                                             
                                               
                                                 
                                               </div>
                                         </div>
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                   <label for="txtEmail">Nationality:</label> 
                                                    </div>
                                                 </div>
                                                  <div class="col-sm-2">
                                                    <div class="form-group">
                                                    
                                                         <asp:TextBox ID="txtNationality" runat="server" TabIndex="14" CssClass="form-control" placeholder="Enter Nationality"
                                                            ></asp:TextBox>               

                                                    </div>
                                                  </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                          <label for="txtBirthPlace">BirthPlace:</label>         
                                                        
                 
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                            
                                                        <asp:TextBox ID="txtBirthPlace" runat="server"  TabIndex="15" CssClass="form-control" placeholder="Enter Birth Place"
                                                       ></asp:TextBox>
                 
                                                    </div>
                                                </div>
                                                 <div  class="col-sm-1">
                                                    <div class="form-group">
                                                         <label for="txtEmail">National ID :</label>   
                                                        </div>
                                                    </div>                                                                 
                                                <div class="col-sm-2" >
                                                    <div class="form-group">
                                                        
                                                             <asp:TextBox ID="txtpassportNo" runat="server"  TabIndex="16" CssClass="form-control" placeholder="Enter Passport No"  
                                                           ></asp:TextBox>
                                                        </div>
                                                </div>  
                                              
                                             </div>
                                         </div>
                                         <div class="messagealert" id="alert_container">
            </div>
                                                    <div class="col-lg-12 mt-2" runat="server" visible="false">
                                         <div class="panel-heading" style="font-size:medium;font-weight:bold"">Next To Kin Information: </div>
                                            </div>
                                                <div class="col-lg-12 mt-2" runat="server" visible="false">
                                            <div class="row">     
                                                     <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Next to Kin1:</label>   
                                               </div>
                                                      </div>

                                               

                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                           
                                                             <asp:TextBox ID="txtrelativeName" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                        </div>
                                                    </div>     
                                         <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                                <label for="ddlGender">Relation1</label>  
                                                </div>
                                              </div>
                                               <div class="col-sm-2">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList runat="server" CssClass="form-control form-select" ID="ddlRelation"></asp:DropDownList>

                                                       
                                                    </div>
                                               </div>
                                                   
                                                
                                              

                                                 
                                             
                                               
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Contact No1:</label> 
                                                        </div>
                                                    </div>
                                                                                                
                                                <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                                                                                      
                                                          <asp:TextBox ID="txtContactNo" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                                                                  
                        
                                                       
                                                 
                                                </div>                          
                                            </div>
                                                </div>
                                        </div>

                                         <div class="col-lg-12 mt-3" runat="server" visible="false">
                                            <div class="row">     
                                                     <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Address1:</label>   
                                               </div>
                                                      </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <asp:CheckBox runat="server" ID="ChkISsameAdd" Text="Same Address" AutoPostBack="True" OnCheckedChanged="ChkISsameAdd_CheckedChanged" />
                                                        </div>
                                                    </div>

                                                  <div class="col-sm-8">
                                                    <div class="form-group">
                                                         <asp:TextBox ID="txtAddress1" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                        </div>
                                                      </div>
                                                </div>
                                             </div>
                          <div class="col-lg-12 mt-3" runat="server" visible="false">
                                            <div class="row">       
                                                  <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Next to Kin2:</label>   
                                               </div>
                                                      </div>

                                               

                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                           
                                                             <asp:TextBox ID="txtRelativeName2" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                        </div>
                                                    </div>   
                                         <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                                <label for="ddlGender">Relation2</label>  
                                                </div>
                                              </div>
                                               <div class="col-sm-2">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                        <asp:DropDownList runat="server" CssClass="form-control form-select" ID="ddlrelation2"></asp:DropDownList>

                                                       
                                                    </div>
                                               </div>
                                                   
                                                
                                               
                                                 
                                                
                                               
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Contact No2:</label> 
                                                        </div>
                                                    </div>
                                                                                                
                                                <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                                                                                      
                                                          <asp:TextBox ID="txtcontaxtNo2" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                                                                  
                        
                                                       
                                                 
                                                </div>                          
                                            </div>
                                                </div>
                                        </div>    
                                        
                                          <div class="col-lg-12 mt-3" runat="server" visible="false">
                                            <div class="row">     
                                                     <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Address2:</label>   
                                               </div>
                                                      </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <asp:CheckBox runat="server" ID="chkisSameaddress1" Text="Same Address" AutoPostBack="True" OnCheckedChanged="chkisSameaddress1_CheckedChanged" />
                                                        </div>
                                                    </div>

                                                  <div class="col-sm-8">
                                                    <div class="form-group">
                                                         <asp:TextBox ID="txtaddress2" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                        </div>
                                                      </div>
                                                </div>
                                             </div>             
                                             
                                         <div class="col-lg-12 mt-3" runat="server" visible="false"> 
                                            <div class="row">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                   <label for="txtEmail">Allergy:</label> 
                                                    </div>
                                                 </div>
                                                  <div class="col-sm-4">
                                                    <div class="form-group">
                                                    
                                                         <asp:TextBox ID="txtallergy" runat="server" TextMode="SingleLine" CssClass="form-control" placeholder="Enter Allergy"
                                                            ></asp:TextBox>               

                                                    </div>
                                                  </div>
                                               
                                                
                                                 <div  class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtEmail">Remark:</label>   
                                                        </div>
                                                    </div>                                                                 
                                                <div class="col-sm-4" >
                                                    <div class="form-group">
                                                        
                                                             <asp:TextBox ID="txtComplant" TextMode="SingleLine" runat="server" CssClass="form-control" placeholder="Enter Remark"  
                                                           ></asp:TextBox>
                                                        </div>
                                                </div>  
                                              
                                             </div>
                                         </div>
                                                  
                                           <div class="col-lg-12 mt-3" runat="server" visible="false"> 
                                            <div class="row">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                   <label for="txtEmail">Edit Remark:</label> 
                                                    </div>
                                                 </div>
                                                  <div class="col-sm-5">
                                                    <div class="form-group">
                                                    
                                                         <asp:TextBox ID="txtEditRemark" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Edit Remark"
                                                            ></asp:TextBox>               

                                                    </div>
                                                  </div>
                                                <div class="col-sm-1">
                                                    <div class="form-group">
                                                   <label for="txtEmail">Photo</label> 
                                                    </div>
                                                 </div>
                                                 <div class="col-sm-4">
                                                    <div class="form-group">
                                                  <asp:FileUpload ID="FileUpload1" runat="server"  
                                            Width="200px" />
                                        <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                                            CssClass="btn btn-info" onclick="btnUpload_Click"   
                                            Text="Upload" />

                                                        </div>
                                                     </div>
                                                </div>
                                               </div>    
                                  
                                        
                                   
                                                
                                   </div>
</div>

             
                                
                     <div class="box-footer">
                                    <div class="row">
                                        
                                    
                                                      
                                        <div class="col-lg-12 mt-3 text-center">
                                            
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnSave_Click" 
                                        TabIndex="17" Width="80px" CssClass="btn btn-success"   CausesValidation="False"   UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" />
                                           
                                        
                                        <asp:Button ID="btnBack" runat="server" OnClientClick="window.history.back()" 
                                        Text="Back" Width="80px" class="btn btn-success" CausesValidation="False" />
                                                         
                                             </div>
                                    </div>
                         <div class="row">
                               <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePaneLeftBox" DisplayAfter="500" DynamicLayout ="true">
        <ProgressTemplate>
        <center><img id="Img1" src="~/Images0/Progress-Bar.png" height="100" runat="server" /></center>
        </ProgressTemplate>
        </asp:UpdateProgress>
                             </div>
                                  <div class="row">
               


        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close"  data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                           Upload Image</h4>
                    </div>
                    <div class="modal-body">
                       <%--  <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="9"  
                                            Width="200px" />
                                        <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                                            CssClass="btn btn-info" onclick="btnUpload_Click" Style="display: none"  TabIndex="10" 
                                            Text="Upload" />--%>

                       
                    </div>
                    <div class="modal-footer">
                      
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
            <script type='text/javascript'>
                function openModal() {
                    $('[id*=myModal]').modal('show');
                }

                function ShowInformation() {
                    $('[id*=Information]').collapse('show');
                    // $('[id*=Information]').show();
                }



            </script>
        

                        </div>

                    </div>
                         </div>
                   </ContentTemplate>
                          </asp:UpdatePanel>
                </div>

                                
                                
                               
                            

                            
                      
                           
                        </section>
        </ContentTemplate>
         
    </asp:UpdatePanel>
    </div>
    </form>


    <script src="plugins/jquery/jquery.min.js" type="text/javascript"></script>
        <script src="plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
        <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
        <script>
            $.widget.bridge('uibutton', $.ui.button);
        </script>
        <!-- Bootstrap 3.3.7 -->
        <script src="plugins/bootstrap/js/bootstrap.min.js"></script>
            <script src="Scripts/umd/popper.min.js"></script>
        <!-- datepicker -->
        <script src="plugins/datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
        <script src="plugins/theme/js/theme.min.js"></script>
            <%-- <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">--%>
            <script type="text/javascript">
                $(document).ready(function () {

                    $('#MainContent_datepicker1', "").datepicker({
                        format: "dd/mm/yyyy"
                    }).on('change', function () {
                        $('.datepicker').hide();
                    });
                    $('#MainContent_txtToDate').datepicker({
                        format: "dd/mm/yyyy"
                    }).on('change', function () {
                        $('.datepicker').hide();
                    });

                });
            </script>



     <script src="plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<%--    <script src="assets/vendors/popper.js/dist/umd/popper.min.js" type="text/javascript"></script>--%>
    <script src="jsmain/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="jsmain/metisMenu/dist/metisMenu.min.js" type="text/javascript"></script>   
    <script src="jsmain/app.min.js" type="text/javascript"></script>
</body>
</html>
