<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IPDRegistration.aspx.cs" Inherits="IPDRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--  <style>
        a img{border: none;}
        ol li{list-style: decimal outside;}
        div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
        div.side-by-side{width: 100%;margin-bottom: 1em;}
        div.side-by-side > div{float: left;width: 50%;}
        div.side-by-side > div > em{margin-bottom: 10px;display: block;}
        .clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
        
    </style>
    <link rel="stylesheet" href="StyleFan/chosen.css" />--%>
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
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPatCard" />
             <asp:PostBackTrigger ControlID="btnpatientband" />
              <asp:PostBackTrigger ControlID="btnChildrenband" />
             <asp:PostBackTrigger ControlID="btnfrontsheetreport" />
             
         </Triggers>
         <ContentTemplate>--%>
             
    <section class="content-header d-flex">
                    <h1>IPD Registration</h1>
                    <ol class="breadcrumb">
                       <%-- <li><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                        <li><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>--%>
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">IPD Registration</li>
                    </ol>
                </section>
            <section class="content">
               
                 <div class="box" runat="server" id="Show">

                    
                     <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          <asp:Label ID="lblVisitingNo" class="red pull-right"  runat="server" Font-Bold="True" ForeColor="#0066FF" Font-Size="Medium" Width="500px" ></asp:Label>
                          
                                </div>
                      <div class="panel panel-info" >
      <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Visible="false" Font-Bold="true" ForeColor="Red"  runat="server" Text=""></asp:Label> </div>
      <div class="panel-body bg-white"  >
    
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name:</label>
                                        <asp:Label ID="lblPatientName" ForeColor="Red" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left" >
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                                        <asp:Label ID="txtpatientregid" Font-Bold="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="col-lg-3 text-left" id="Div8" runat="server" >
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="" style="text-align: left">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </div>
                                </div>
                                      
                                    </div>
                            </div>
                             
                       
                         

           <div class="col-lg-12 text-left" runat="server" id="IpdRmCat">
                                <div class="row">
                                <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server"  Text="Address:"></asp:Label>
                                        <asp:Label ID="lbladdr" runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-7 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server"  Text="Room Info:"> </asp:Label>
                                        <asp:Label ID="lblRoomInfo" runat="server" Font-Bold="true" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                                    
                              
                               
                            </div>
                        </div>
     
     
           </div>
                                       <div style="height:2px; background:#B24592;"> </div>
                            </div> 
                               <div class="box-body" >
                                    <div class="row"> 
                                        <div class="col-lg-12" runat="server" visible="false"> 
                                            <div class="row">
                                                  <div class="col-lg-1">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientCategoryName">Sponser </label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-3">
                                                        <div class="form-group"> 
                                                           <asp:DropDownList ID="ddlPatientCategoryName" runat="server" AutoPostBack="True" TabIndex="2" CssClass="form-control form-select"
                                                                
                                                             OnSelectedIndexChanged="ddlPatientCategoryName_SelectedIndexChanged" >
                                                         </asp:DropDownList>                    
                                                                       
                                                       </div>
                                                    </div>
                                               <div class="col-lg-1">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientSubCategoryName">Sponser </label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                         <div class="col-lg-3">
                                                    <div class="form-group">
                                        
                                                         <asp:DropDownList ID="ddlPatientSubCategoryName" runat="server" AutoPostBack="True" TabIndex="3" CssClass="form-control form-select"
                                                           >
                                                         </asp:DropDownList>                    
                                                       
                                                    </div>
                                                </div> 
                                                <div class="col-lg-1 text-left" style="width:170px" id="sp1" visible="false" runat="server">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientSubCategoryName" style="text-align:center">Sponser2 </label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                         <div class="col-lg-3 text-left" style="width:150px" id="sp2" visible="false" runat="server">
                                                    <div class="form-group">
                                        
                                                         <asp:DropDownList ID="ddlPatientSubCategoryName2" runat="server" AutoPostBack="True" TabIndex="3" CssClass="form-control"
                                                          Width="150px" >
                                                         </asp:DropDownList>                    
                                                       
                                                    </div>
                                                </div> 
                                            </div>
                                        </div>
                                                     <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                
                                         <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                                             
                                                                <asp:RadioButtonList ID="rblPatcate" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True"  ForeColor="Red" Font-Bold="True" Font-Size="Medium" OnSelectedIndexChanged="rblPatcate_SelectedIndexChanged" >
                                                             <asp:ListItem Selected="True" Value="1" >Paying</asp:ListItem>
                                                             <asp:ListItem Value="2">Insurance</asp:ListItem>                                                            
                                                             <asp:ListItem Value="3">Charge</asp:ListItem>
                                                         
                                                             </asp:RadioButtonList>      
                                                       </div>
                                                    </div>
                                            
                                         <div class="col-sm-3 text-left">
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>          
                                                       
                                                    </div>
                                                </div> 
                                                <div class="col-sm-3 text-left">
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>    
                                                        </div>
                                                    </div>
                                                 <div class="col-sm-3 text-left">
                                                    <div class="form-group">
                                                           <asp:TextBox ID="txtInsurance2" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter  Insurance2(*)"
                                                AutoPostBack="True"  Font-Bold="True" Font-Size="Medium" OnTextChanged="txtInsurance2_TextChanged"  ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchSubCategory"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtInsurance2"
                                                ID="AutoCompleteExtender3"
                                                runat="server">
                                                   </asp:AutoCompleteExtender> 
                                                        </div>
                                                     </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 mt-3" runat="server" visible="false"> 
                                            <div class="row"> 
                                                <div class="col-lg-1 pr-0">
                                                        <div class="form-group"> 
                                                            <label for="txtRegNo">Reg No.:</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                       
                                                            <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control" Enabled="false"
                                                             onkeyPress="return numeric_only(event);" TabIndex="13" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                      
                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Patient Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-lg-1">
                                                           
                                            <div class="form-group">  
                                                                                                         
                                                <asp:DropDownList ID="ddlTitleName" runat="server"  CssClass="form-control pull-left form-select" AutoPostBack="True" 
                                                 TabIndex="5">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                                                            
                                                <div class="col-lg-2 text-left">
                                                    <div class="form-group">                 
                                   
                                              
                                             </div>
                                        </div>
                                                </div>
                                            </div>

                                        <div class="col-lg-12 mt-3" runat="server" id="PayType" visible="false"> 
                                            <div class="row"> 
                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Payment Type</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                  <div class="col-lg-4">
                                                        <div class="form-group"> 
                                                            <asp:RadioButtonList runat="server" ID="rblPaymentype" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblPaymentype_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="1">Full Charge Companies</asp:ListItem>
                                                                <asp:ListItem Value="2">Full Charge</asp:ListItem>
                                                                <asp:ListItem Value="3">Part - Payment Insurance</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </div>
                                                      </div>
                                                <div class="col-lg-3" runat="server" id="PartPay" visible="false">
                                                        <div class="form-group"> 
                                                             <asp:TextBox ID="txtpartpayment" runat="server"   class="form-control"  placeholder="Part - Payment Insurance"></asp:TextBox>
                                                          
                                                            </div>
                                                    </div>
                                                </div>
                                            </div>

                                         <div class="col-lg-12 mt-3"> 
                                            <div class="row"> 
                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Patient Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-lg-10 text-left">
                                                    <div class="form-group">                 
                                                          <asp:TextBox ID="txtPatientName" runat="server"  AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                 AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
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
                                                

                                                </div>
                                             </div>
                                               
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                             
                                                            <label for="dsds">Date & Time:</label>                                                                                                                                                                                               
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-2">
                                            <div class="form-group">
                                                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtRegistrationDate" runat="server"   class="form-control" TabIndex="12"  AutoPostBack="True"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                     
                        
                                                        </div>
                                                </div>
                                                     </div>
                                                 <div class="col-lg-2 text-left">
                                                    <div class="form-group">       
                                                         <asp:TextBox ID="txtTime" runat="server"  CssClass="form-control" 
                                                     TabIndex="9"  Font-Bold="True"></asp:TextBox>  
                                                        </div>
                                                     </div>


                                                  <div class="col-lg-2">
                                                    <div class="form-group">                                        
                                <div class="custom-control custom-checkbox">
    <input type="checkbox" class="custom-control-input-orange"  id="ChkUni" runat="server">
    <label class="custom-control-label"  for="UniversalPrecaution">Univ Precausion</label>
</div>
                                                        </div>
                                                    </div>
<div class="col-lg-2">
                                                    <div class="form-group">   
                                <div class="custom-control custom-checkbox">
    <input type="checkbox" class="custom-control-input-orange"  id="ChkEmergency" runat="server">
    <label class="custom-control-label" for="ChkEmergency">Emergency</label>
</div>
                                                        </div>



                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">   
                                <div class="custom-control custom-checkbox">
    <asp:CheckBox type="checkbox" class="custom-control-input-orange" Text="Infant" AutoPostBack="true"  id="ChkInfant" runat="server" OnCheckedChanged="ChkInfant_CheckedChanged"/>
   
</div>
                                                        </div>



                                                </div>
                                            </div>
                                            <div class="col-lg-12 mt-3" runat="server" id="Infanta1" visible="false"> 
                                            <div class="row">
                                                <div class="col-lg-2 ">
                                                        <div class="form-group"> 
                                                                <label for="ddlConsultantDoc" >Infanta's DOB</label>                                                                                                                                                                                            
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group">
                                                                                                                    
                                                          <asp:TextBox ID="txtInfantaDOB" runat="server"   class="form-control" TabIndex="12" ></asp:TextBox>
                                                             
                                                                 
                                                        </div>
                                                     </div>
                                                 <div class="col-lg-2 ">
                                                        <div class="form-group"> 
                                                                <label for="ddlConsultantDoc" >Infanta's Sex</label>                                                                                                                                                                                            
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group">
                                                         <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="false" CssClass="form-control form-select"
                                                        
                                                        TabIndex="5" Enabled="true">
                                                        </asp:DropDownList>
                                                        </div>
                                                     </div>
                                                </div>
                                                </div>
                                            <div class="col-lg-12 mt-3" runat="server" id="Infanta2" visible="false"> 
                                            <div class="row">
                                                <div class="col-lg-2 ">
                                                        <div class="form-group"> 
                                                                <label for="ddlConsultantDoc" >Infanta's Race</label>                                                                                                                                                                                            
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="ddlRace" TabIndex="9" runat="server" 
                                                         CssClass="form-control form-select">  
                                                                   
                                                        </asp:DropDownList>
                                                        </div>
                                                     </div>
                                                 <div class="col-lg-2 ">
                                                        <div class="form-group"> 
                                                                <label for="ddlConsultantDoc" >Mother Admit Date</label>                                                                                                                                                                                            
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" ID="LblMsgAdmitDate" Font-Bold="true" Font-Italic="true" ForeColor="Red"></asp:Label>
                                                        </div>
                                                     </div>
                                                </div>
                                                </div>
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                               
                                                 <div class="col-lg-2 ">
                                                        <div class="form-group"> 
                                                                <label for="ddlConsultantDoc" >Consultant</label>                                                                                                                                                                                            
                                                         </div>
                                                      </div>
                                                  <div class="col-lg-4">
                                                    <div class="form-group">
                                                       <asp:DropDownList ID="ddlConsultantDoc" runat="server" Visible="false"  CssClass="form-control form-select"  
                                                         TabIndex="4">                                                            
                                                        </asp:DropDownList>
                     <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged"></asp:TextBox>
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
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                               <label for="ddlDepartment">Department:</label>                                                                                                                                                                                         
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                     <div class="form-group">
                                                          <asp:DropDownList ID="ddlDepartment" Visible="false" runat="server" AutoPostBack="True"  
                                                     CssClass="form-control form-select"   TabIndex="3" >
                                                    
                                                </asp:DropDownList>
                    
                                               <asp:TextBox ID="txtdepartment" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Department Name(*)"
                                               AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtdepartment_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDepartment"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                       CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionSetCount="10" 
                                                TargetControlID="txtdepartment"
                                                ID="AutoCompleteExtender5"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                      </div>
                                                    </div> 
                                                
                                               
                                                 
                                                                                    
                                       </div></div>
                                           <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            
                                                            <label for="ddlSecDoc">Secondary Doctor</label>                                                                                                                                                                                                
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group" >
                                                           
                                                          <asp:DropDownList ID="ddlSecDoc" Visible="false" runat="server" CssClass="form-control form-select" 
                                                         TabIndex="4">                                                            
                                                        </asp:DropDownList>  

                                                         <asp:TextBox ID="txtsecondaryDr" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Secondary Dr"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtsecondaryDr_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchSecondaryDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                       CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtsecondaryDr"
                                                ID="AutoCompleteExtender6"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                     </div>
                                                 </div>  

                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                                    <label for="ddlRefDoctor">Ref.Doctor</label>                                                                                                                                                                                    
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group">
                                                      <asp:DropDownList ID="ddlRefDoctor"  CssClass="form-control form-select" runat="server"  
                                                         TabIndex="4">                                                            
                                                        </asp:DropDownList> 
                                                      
                                                     </div>
                                                 </div>  
                                            </div>
                                            </div>

                                         <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            
                                                            <label for="ddlSecDoc" style="text-align:left">Surgery Type</label>                                                                                                                                                                                                
                                                         </div>
                                                      </div>
                                                 <div class="col-lg-4">
                                                    <div class="form-group" >
                                                           <asp:UpdatePanel ID="ASASA" runat="server">

                                                               <ContentTemplate>
                                                                     <asp:DropDownList ID="ddlSurgeryType" runat="server"  AutoPostBack="true" CssClass="form-control form-select" OnSelectedIndexChanged="ddlSurgeryType_SelectedIndexChanged"  >                                                            
                                                        </asp:DropDownList> 
                                                               </ContentTemplate>
                                                           </asp:UpdatePanel>
                                                         
                                                     </div>
                                                 </div>  
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            
                                                            <label for="ddlSecDoc" style="text-align:left">Letter Number</label>                                                                                                                                                                                                
                                                         </div>
                                                      </div>
                                                <div class="col-lg-4">
    <div class="form-group">   
        <asp:TextBox ID="txtletterNumber" placeholder="Enter Letter Number" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
    </div>
                                               
    </div>

                                                 
                                                 
                                            </div>
                                            </div>

                                    
                                            
                                     
                                        
                                         <div class="col-lg-12 mt-3"> 
                                            <div class="row">   
                                                  <div class="col-lg-12">
                                                        <div class="form-group"> 
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                                                               <ContentTemplate>
                                                                   <asp:Label runat="server" ID="lblsurgeryType" ForeColor="Red" Font-Size="Large" Font-Bold="true"></asp:Label>    
                                                                      </ContentTemplate>
                                                           </asp:UpdatePanel>                                                                                                                                                                             
                                                         </div>
                                                      </div>
                                                </div>
                                             </div>

                                            
                                         <div class="col-lg-12 mt-3"> 
                                            <div class="row">     
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactPerson1">Contact Person 1</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtContactPerson1" runat="server" CssClass="form-control" 
                                            TabIndex="9"></asp:TextBox>
                                                     </div>

                                                 </div>

                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactPerson2">Contact Person 2</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtContactPerson2" runat="server" CssClass="form-control" 
                                            TabIndex="9" ></asp:TextBox>
                                                     </div>

                                                 </div>
                                                

                                                
                                                </div>
                                            </div> 
                                           
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="ddlrealation1">Relation</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">                                                         
                                                         <asp:DropDownList ID="ddlrealation1" runat="server" CssClass="form-control form-select"  
                                                         TabIndex="4">
                                                            
                                                        </asp:DropDownList>
                   
                                                           
                                                    </div>
                                                    </div>

                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="ddlrealation2" style="text-align:left">Relation</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                <div class="col-lg-4">
                                                    <div class="form-group">                                                         
                                                         <asp:DropDownList ID="ddlrealation2" runat="server" CssClass="form-control form-select" 
                                                         TabIndex="4">
                                                            
                                                        </asp:DropDownList>
                   
                                                           
                                                    </div>
                                                    </div>
                                                </div>
                                            </div>

                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">     
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactNo1">Contact No 1</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtContactNo1" runat="server" CssClass="form-control" 
                                            TabIndex="9" ></asp:TextBox>
                                                     </div>

                                                 </div>

                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactNo2">Contact No 2</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtContactNo2" runat="server" CssClass="form-control" 
                                            TabIndex="9" ></asp:TextBox>
                                                     </div>

                                                 </div>
                                                

                                                
                                                </div>
                                            </div> 

                                          <div class="col-lg-12 mt-3"> 
                                            <div class="row">     
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactPerson1">Address</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtaddress1" TextMode="MultiLine" runat="server" CssClass="form-control" ></asp:TextBox>
                                                     </div>

                                                 </div>

                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactPerson2">Address1</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtaddress2" TextMode="MultiLine" runat="server" CssClass="form-control" ></asp:TextBox>
                                                     </div>

                                                 </div>
                                                

                                                
                                                </div>
                                            </div> 
                                          <div class="col-lg-12 mt-3"> 
                                            <div class="row">     
                                                 <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactNo1" style="text-align:left">Diagnosis</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtsponsor" runat="server" class="form-control" AutoPostBack="True"
                                            TabIndex="9"  OnTextChanged="txtsponsor_TextChanged"></asp:TextBox>
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDisease"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtsponsor"
                                                ID="AutoCompleteExtender8"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    
                                                     </div>

                                                 </div>

                                                <div class="col-lg-2">
                                                        <div class="form-group"> 
                                                            <label for="txtContactNo2">Procedure</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>

                                                <div class="col-lg-4">
                                                    <div class="form-group">
                                                         
                                                         <asp:TextBox ID="txtProcedure" runat="server" AutoCompleteType="None" AutoPostBack="True" CssClass="form-control" 
                                             OnTextChanged="txtProcedure_TextChanged"></asp:TextBox>
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtProcedure"
                                                ID="AutoCompleteExtender2"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                     </div>

                                                 </div>
                                                

                                                
                                                </div>
                                            </div> 

                                             </div>
                                              <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                         
                                                <div class="col-lg-2">
                                                     <div class="form-group">  
                                                             <asp:FileUpload ID="FileUpload1" runat="server" Width="249px" />  
                                                     </div>     
                                                </div>                                                                          
                                            <div class="col-lg-1">
                                                     <div class="form-group">      
                                                         <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                                                          CssClass="btn btn-info" onclick="btnUpload_Click"  TabIndex="17" Text="Upload" />
                                                          </div>   
                                                </div>  
 <div class="col-lg-4">
   <div class="form-group">   
       <div runat="server" id="UploadedFiles" style="overflow:scroll"    >                                          
 <div class="table-responsive" style="width:100%" >

<asp:GridView ID="gvImages" runat="server"  class="table table-responsive table-sm table-bordered" DataKeyNames="Path,FileId" AutoGenerateColumns="False" OnRowDeleting="gvImages_RowDeleting">
    <Columns>
        <asp:BoundField DataField="FileId" HeaderText="Image Id" />
        <asp:BoundField DataField="FileName" HeaderText="Name" />
      
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
                                         
                                     
                                         <div class="col-lg-12 text-center mt-3">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnInsurance" runat="server" Text="Insurance" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" OnClick="btnInsurance_Click" />
                                              <asp:Button ID="btnsave" runat="server" Text="Save"  OnClick="btnSave_Click"   OnClientClick="this.disabled=true;" UseSubmitBehavior="false"
                                         TabIndex="15" Width="60px" class="btn btn-success"  />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset"  
                                            CausesValidation="False" TabIndex="16" class="btn btn-warning" OnClick="btnReset_Click" />                                   
                                             <asp:Button ID="btnPatCard" runat="server" Text="Patient Card" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="16" class="btn btn-secondary" OnClick="btnPatCard_Click" />
                                              <asp:Button ID="btnpatientband" runat="server" Text="Patient Band" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="16" class="btn btn-primary"  OnClick="btnpatientband_Click" />
                                               <asp:Button ID="btnChildrenband" runat="server" Text="Ped.Band" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="16" class="btn btn-secondary"  OnClick="btnChildrenband_Click" />
                                            
                                             <asp:Button ID="btnfrontsheetreport" runat="server" Text="Front Sheet" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="16" class="btn btn-primary"  OnClick="btnfrontsheetreport_Click"  />

                                             <asp:Button ID="btnInfant" runat="server" Visible="false" Text="Infant Sheet" OnClientClick="target = '_blank';"
                                             CausesValidation="False" TabIndex="16" class="btn btn-warning" OnClick="btnInfant_Click"  />
                                             
                                          <asp:Button ID="btnIPDBill" runat="server"  
                                        Text="Adv Pay" ToolTip="Adv Pay" class="btn btn-success" OnClick="btnIPDBill_Click" />
                                    
                                             
                                        </div>   
                                              
                                          </div>                                          
                                           
                                           

                                
                           
                               </div>
                         
                 
                            
                             
                                        
                    

                
                    
                
                        </section>
            <%-- </ContentTemplate>--%>
            <%-- </asp:UpdatePanel>--%>
   <%-- <script src="ScriptsFan/jquery.min.js" type="text/javascript"></script>
        <script src="ScriptsFan/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript"> $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>--%>
</asp:Content>

