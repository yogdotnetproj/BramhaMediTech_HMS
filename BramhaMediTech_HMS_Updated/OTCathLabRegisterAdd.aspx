<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OTCathLabRegisterAdd.aspx.cs" Inherits="OTCathLabRegisterAdd" %>


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
<%--    <script src="Scripts/1.3.2.min.js"  type="text/javascript"/>
   <script src="Scripts/1.7.1.custom.js" type="text/javascript"/>--%>
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
            <asp:PostBackTrigger ControlID="btnSummary" />
             <asp:PostBackTrigger ControlID="btnDisk" />
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>CatLab Register</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">CatLab Register</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                 <asp:Label ID="lblMessage" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                               
                            </div>
                        </div>
                    </div>
                                <div class="box-header with-border">
                       <div class="panel panel-info">
      <div class="panel-heading" style="font-size:medium;font-weight:bold"">Patient Information</div>
      <div class="panel-body" >
    

                        
                            <div class="col-lg-12 text-left">
                                <div class="row">

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPrnNo" runat="server" Font-Bold="true" Text="Reg ID:" ></asp:Label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPat" runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label ID="lblI"  runat="server" Font-Bold="true" Text="IPD NO:"></asp:Label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblBio" runat="server" Font-Bold="true" Text="Bill NO:"></asp:Label>
                                        <asp:Label ID="lblBillNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="hhhd" runat="server" Font-Bold="true" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="col-lg-12 mt-2">
                                <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server" Font-Bold="true" Text="Patient Category:"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true" Text="Admission Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div3" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Font-Bold="true" Text="DR Name :"></asp:Label>
                                        <asp:Label ID="lbldrname" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="lblBi" runat="server" Font-Bold="true" Text="Room Type:" ></asp:label>
                                        <asp:Label ID="LblRoomType" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server" Font-Bold="true" Text="Bed Name:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                       
                            <div class="col-lg-12 mt-2">
                                 <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server" Font-Bold="true" Text="Diagnosis:"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server" Font-Bold="true" Text="Procedure:"> </asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div4" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="Label5"   runat="server" Font-Bold="true" Text="Sponsor :"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="Label7" runat="server" Font-Bold="true" Text="Sponsor1:" ></asp:label>
                                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="Label9" runat="server" Font-Bold="true" Text="Visit No:"></asp:label>
                                        <asp:Label ID="lblvisitno" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
          </div>
                            </div>
                    </div>
                    <div class="box-body">
                         <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                       
                                                           
                                                        <asp:TextBox ID="txtsurgen" runat="server"  CssClass="form-control" placeholder="Enter Surgeon" AutoPostBack="True" OnTextChanged="txtsurgen_TextChanged"></asp:TextBox>     
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                              CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtsurgen"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                         
                                                        <asp:TextBox ID="txtAnaesthetist" runat="server"  CssClass="form-control" AutoPostBack="true" placeholder="Enter Anaesthetist" OnTextChanged="txtAnaesthetist_TextChanged"></asp:TextBox>      
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAnaesthetist"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                               CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtAnaesthetist"
                                                ID="AutoCompleteExtender3"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                          
                                                            <asp:TextBox ID="txt1stAsst" runat="server" AutoPostBack="true"  CssClass="form-control" placeholder="Enter 1ST Asst" OnTextChanged="txt1stAsst_TextChanged"></asp:TextBox>      
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                              CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txt1stAsst"
                                                ID="AutoCompleteExtender5"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                       
                    
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txt2stAsst" runat="server" AutoPostBack="true"  CssClass="form-control" placeholder="Enter 2ST Asst" OnTextChanged="txt2stAsst_TextChanged"></asp:TextBox>        
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                              CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txt2stAsst"
                                                ID="AutoCompleteExtender6"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                
                               </div>
                             </div>
                         <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                 
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                     
                                                         <asp:TextBox ID="txtSTERINURSE" runat="server"  CssClass="form-control" placeholder="Enter STERI NURSE" AutoPostBack="True" OnTextChanged="txtSTERINURSE_TextChanged"></asp:TextBox>        
                                                       
                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search1stAsst"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtSTERINURSE"
                                                ID="AutoCompleteExtender7"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                        
                                                         <asp:TextBox ID="txtDISEASE" runat="server"  CssClass="form-control" placeholder="Enter DISEASE" AutoPostBack="True" OnTextChanged="txtDISEASE_TextChanged"></asp:TextBox>        
                                                       
                                      <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDisease"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                            CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtDISEASE"
                                                ID="AutoCompleteExtender8"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    
                                                    </div>
                                                </div>
                                 <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                  
                                                         <asp:TextBox ID="txtoperation" runat="server"  CssClass="form-control" placeholder="Enter OPERATION" AutoPostBack="True" OnTextChanged="txtoperation_TextChanged"></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                               CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                 <div class="col-lg-2 text-left" >
                                                    <div class="form-group">  
                                                                                       
                                                             
                                                     <%--  <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>--%>
                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txttimestart" runat="server" class="form-control"  placeholder="Enter Time Start"    
                                                             AutoPostBack="True"></asp:TextBox>
                                                             
                                                                <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                </span>                                                     
                         
                                                        </div>
                                                    
                                                    </div>
                                                </div>
                                   <div class="col-lg-1 text-left" >
                                                    <div class="form-group">  
                                                                                
                                                        <asp:TextBox ID="txtTime" runat="server"  class="form-control" 
                                                       Font-Bold="True" Font-Size="Large"></asp:TextBox>  
                                                        </div>
                                       </div>
                                 </div>
                             </div>

                     
                          <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                 
                                  <div class="col-lg-2 text-left" >
                                                    <div class="form-group">  
                                                                                       
                                                         
                                                       
                      <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtDateEnd"   runat="server" class="form-control"  placeholder="Enter Time End"    
                                                             AutoPostBack="True"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                   <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                         
                                                        </div>
                                                    
                                                    </div>
                                                </div>
                                    <div class="col-lg-1 text-left" >
                                                    <div class="form-group">  
                                                        
                                                        <asp:TextBox ID="txttimeEnd" runat="server"  class="form-control" 
                                                       Font-Bold="True"  Font-Size="Large" AutoPostBack="True" OnTextChanged="txttimeEnd_TextChanged"></asp:TextBox>  
                                                        </div>
                                        </div>
                                    <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                                         
                                                         <asp:TextBox ID="txtTTime" runat="server"   CssClass="form-control" placeholder="Enter Anaest Time Hrs/Min."></asp:TextBox>        
                                                       
                    
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-lg-5 text-left" >
                                                    <div class="form-group">  
                                                                                    
                                                         <asp:TextBox ID="txtremark" runat="server"  CssClass="form-control" placeholder="Enter Remark"></asp:TextBox>        
                                                       
                    
                                                    
                                                    </div>
                                                </div>
                                  <div class="col-lg-1 text-left" >
                                                    <div class="form-group">  
                                                          <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary"  Text="Register" OnClick="btnRegister_Click" />
                                                        </div>
                                      </div>
                                 </div>
                              </div>
                     <div class="col-lg-12" runat="server" visible="false">
                                                <div class="row"> 
                                <div class="col-lg-1 text-left" style="width:600px">

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" Width="400px" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlag_SelectedIndexChanged" >
                                                            <asp:ListItem Value="All">All</asp:ListItem>
                                                              <asp:ListItem Value="Consultation">Consultation</asp:ListItem>
                                                             <asp:ListItem Value="Lab">Lab</asp:ListItem>
                                                             <asp:ListItem Value="Room" >Room</asp:ListItem>
                                                             <asp:ListItem Value="Drugs" >Drugs</asp:ListItem>
                                                             <asp:ListItem Value="Other" Selected="True">Other</asp:ListItem>
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                    </div>
                                    </div>

                      
      
                                          <div class="col-lg-12" >                                 
                                     <label> Add Details:</label>
                                                <div class="col-lg-12">
                                                <div class="row"> 
                                <div class="col-lg-12 text-left" >

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlagNew" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="Blue"  RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlagNew_SelectedIndexChanged" >
                                                            
                                                             <asp:ListItem Selected="True" Value="Other">Service</asp:ListItem>
                                                              <asp:ListItem Value="Package">Package</asp:ListItem>
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                    </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 text-left" >
                                                    <div class="form-group">  
                                                         <label for="ddlBillServices3" title="" style="text-align: left">Bill Service</label>                                                            
                                                        <asp:DropDownList ID="ddlBillServices" Visible="false" runat="server" AutoPostBack="True" CssClass="custom"
                                                     
                                                         TabIndex="10" OnSelectedIndexChanged="ddlBillServices_SelectedIndexChanged">
                                                        </asp:DropDownList>                    
                                                       <asp:TextBox ID="txtBillServices" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Service Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtBillServices_TextChanged" ></asp:TextBox>
                                            
                                                         <asp:AutoCompleteExtender  
                                                MinimumPrefixLength="3"  
                                                ServiceMethod="SearchAllService"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtBillServices"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%> <%--CompletionListElementID="Div6"--%>
                                                   </asp:AutoCompleteExtender>
                                                        </div>
                                                    </div>
                                        </div>
                                              </div>
                                         
                                        <div class="col-lg-12" >                                 
                                    
                                    <div class="row">
                                       
                                              
                                                 

                                                <div class="col-lg-3 text-left" >
                                                    <div class="form-group">  
                                                                <label for="txtdescription" title="" style="text-align: left">Description</label>                           
                                                         <textarea  runat="server" class="form-control" id="txtdescription" cols="1"  rows="1"></textarea>        
                                                       
                    
                                                    
                                                    </div>
                                                </div>
                                        <div class="col-lg-2 text-left" runat="server" visible="false">                                            
                                            <div class="form-group"> 
                                                <label for="ddlRoomTypeName" title="" style="text-align: left">Room Type</label>
                                                 <asp:DropDownList ID="ddlRoomTypeName" runat="server" Class="form-control"
                                                    OnSelectedIndexChanged="ddlRoomTypeName_SelectedIndexChanged" 
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                      
                                              <div class="col-lg-3 text-left"  runat="server" id="Doctor">
                                                    <div class="form-group">  
                                                         <label for="ddlConsDoctorName" title="" style="text-align: left">Consultant Dr.</label>          
                                                        <asp:DropDownList ID="ddlConsDoctorName" runat="server" Visible="false"
                                                         class="form-control" Width="200px" AutoPostBack="true"   TabIndex="14" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
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
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>


                                                <div class="col-lg-2 text-left" >
                                                    <div class="form-group">  
                                                         <label for="txtCharges" title="" style="text-align: left">Charges</label> 
                                                        <asp:TextBox ID="txtCharges" runat="server" onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control" placeholder=" Charges" TabIndex="13" ></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>  
                                          <div class="col-lg-1 text-left" >
                                                    <div class="form-group"> 
                                                         <label for="txtQty" title="" style="text-align: left">Qty</label>  
                                                        <asp:TextBox ID="txtQty" runat="server" onkeyPress="return numeric_only(event);" AutoPostBack="true"
                                                        CssClass="form-control" placeholder=" Qty" TQabIndex="13"  OnTextChanged="txtQty_TextChanged"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div> 

                                        <div class="col-lg-2 text-left" >
                                                    <div class="form-group"> 
                                                         <label for="txtTotalCharges" title="" style="text-align: left">Amount</label>  
                                                        <asp:TextBox ID="txtTotalCharges" runat="server" Enabled="false" onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control"  TabIndex="13" ></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>              

                                                <div class="col-lg-1 text-right" >
                                                    <div class="form-group"> 
                                                         <label for="txtTotalCharges" title="" style="text-align: left">Add.</label>  
                                                         </br>
                                                         <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" OnClientClick="return Validate();" TabIndex="14" Text="Add" />
                                                      
                                                       
                                                       
                                                        </div>
                                        </div>
                                    
                                    </div>
                                  </div> 
                                        <div class="col-lg-12">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%"  >
                                            <div style=" overflow: scroll; width: 100%; height: 450px; text-align: left"
                                                                                id="Div5">
                                             
                                <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" DataKeyNames="IpdBillServiceDetailId"
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="17"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing" PageSize="5000">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
                            <Columns>
                                 <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                  <asp:BoundField DataField="CreatedOn" ControlStyle-Font-Bold="true" ItemStyle-Font-Bold="true" HeaderText="Entry Date"  DataFormatString="{0:dd/MM/yyyy}" > 
                                <ItemStyle Width="30px" /></asp:BoundField>
                                <asp:BoundField DataField="Service" HeaderText="Service" ItemStyle-Font-Bold="true"  > 
                                <ItemStyle Width="300px" /></asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description"  ItemStyle-Font-Bold="true" > 
                                <ItemStyle Width="200px" /></asp:BoundField>
                                    <asp:BoundField DataField="Empname" HeaderText="Consultant Dr" ItemStyle-Font-Bold="true" > 
                                <ItemStyle Width="120px" /></asp:BoundField>
                                    <%--<asp:BoundField DataField="BillGroup" HeaderText="BillGroup"  > <ItemStyle Width="150px" /></asp:BoundField>--%>
                               
                               
                                <asp:BoundField DataField="BillServiceCharges" HeaderText="Charges" ItemStyle-Font-Bold="true" >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>
                                 <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Font-Bold="true" ><ItemStyle Width="30px" /> </asp:BoundField>
                                <asp:BoundField DataField="TotalCharges" HeaderText="Total Charge" ItemStyle-Font-Bold="true" >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>

                                <asp:BoundField DataField="IpdBillServiceDetailId" HeaderText="Bill Service DetailId" Visible="False"> <ItemStyle Width="70px" /></asp:BoundField>
                                <asp:BoundField DataField="DrId" HeaderText="Consultant Dr Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>                            
                               <%-- <asp:BoundField DataField="BillGroupId" HeaderText="Bill Group Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>--%>
                                 <asp:BoundField DataField="BillServiceId" HeaderText="Service Id" Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
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

                        
                                                 
                                
                                                  <div class="col-lg-12" runat="server" visible="false">
                                                     <div class="row">                                                        
                                                 
                                                         <div class="form-group">
                                                              <div class="col-lg-1 text-left" style="width:150px" >
                                                        <div class="form-group">
                                                            <label for="lblBillServiceCharges" style="text-align:left">Bill Amount:</label>  
                                                            </div>
                                                    </div>
                                                  <div class="col-lg-1 text-left">
                                                        <div class="form-group">                                                                
                                                            <span> <asp:Label ID="lblBillServiceCharges" runat="server" Font-Bold="True" ForeColor="Blue" Width="102px" Font-Size="Large"></asp:Label></span>
                                                        </div>                                                                            
                                                 </div>                                                
                                                  <div class="col-lg-1 text-left" style="width:150px">
                                                         <div class="form-group">
                                                              <label for="lblAdvanceAmt" style="text-align:left">Advance Amount:</label>
                                                             </div>
                                                      </div>                                        
                                                  <div class="col-lg-1 text-left ">
                                                <div class="form-group">
                                                <span><asp:Label ID="lblAdvanceAmt" ForeColor="Green" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label></span>
                                            </div> 
                                          </div>
                                                         <div class="col-lg-1 text-left" style="width:150px" >
                                                        <div  class="form-group">
                                                                 <label >Discount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-1 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblDiscAmt" runat="server" Text="" Font-Bold="true" ForeColor="Blue" Font-Size="Large" Width="120px">
                                                                                     </asp:Label></span></div>
                                                                                </div>
                                                          <div class="col-lg-2 text-left" style="width:150px">
                                                        <div  class="form-group">
                                                                 <label >Insurance Amount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblInsurance" runat="server" Text="" Font-Bold="true" ForeColor="Blue" Font-Size="Large" Width="120px">
                                                                                     </asp:Label></span></div>
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

                                                 <div class="col-lg-1 text-left" style="width:120px" >
                                             <div class ="row">
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="PaymentInsurance" Text="Is Insurance" runat="server" AutoPostBack="true" OnCheckedChanged="PaymentInsurance_CheckedChanged"></asp:CheckBox></label>
                                            </div>
                                            </div>
                                        <div id="InsuranceDetails" runat="server">  
                                                       
                                                       <div class="col-lg-1 text-left" style="width:120px">
                                                           <div class="form-group">  
                                                        <label>InsuranceAmt: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:100px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtInsuranceAmt" runat="server"  class="form-control"  height="30px"  AutoPostBack="True"
                                                     Width="90px" TabIndex="8" OnTextChanged="txtInsuranceAmt_TextChanged1"></asp:TextBox>
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
                                                        
                                                       <div class="col-lg-2 text-left" style="width:120px">
                                                           <div class="form-group">  
                                                        <label  style="width:110px" >InsuranceComp: </label>
                                                               </div>
                                                        </div>
                                                       
                                                           <div class="col-lg-2 text-left" style="width:190px">
                                                           <div class="form-group">  
                                                             <asp:DropDownList ID="ddlInsuranceCompName" runat="server" CssClass="form-control" AutoPostBack="true" Width="190px" ></asp:DropDownList>
                                                                   
                                                        
                                                               </div>
                                                        </div>
                                                       
                                                            
                                                        </div>
                                                              
                                                 </div>
                                              </div>       
                        
                                                        
                                        <div id="PaymentDetails" runat="server" visible="false">
                                                
                                                       <div class="col-lg-12">
                                                           <div class="form-group"> 
                                                       <div class="col-lg-1 text-left"  style="width:130px">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"  height="30px"   placeholder="Card/Cheque No."
                                                     Width="120px" TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:160px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbankName" runat="server"  class="form-control"  height="30px"   placeholder="Bank Name"
                                                     Width="150px" TabIndex="8"></asp:TextBox>
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
                                                       <table width="100%" cellpadding="1" cellspacing="1">

<tr>
    <td>
           <label> Total Amount: </label>
    </td>
    <td>
         <asp:TextBox ID="txtTotalAmt" runat="server" Text="0" Enabled="false" class="form-control"  height="30px"   placeholder="Total Amount"
                                                     Width="200px" TabIndex="8"></asp:TextBox>
    </td>
    <td>
        <label> Discount: </label>
    </td>
    <td>
  <input id="rdbdiscAmt" type="radio" name="rdbDisc" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>
                <input id="rdbdiscPer" type="radio" runat="server" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
    </td>
    <td>
 <asp:Button ID="btnDisk" runat="server" class="btn btn-primary" ToolTip="Add Discount" Text="(+)" OnClick="btnDisk_Click"></asp:Button>
    </td>
    <td>
  <asp:TextBox ID="txtDiscount" runat="server" Text="0"  class="form-control"  height="30px"   placeholder="Discount"
                                                     Width="140px" TabIndex="8" AutoPostBack="false" OnTextChanged="txtDiscount_TextChanged" onkeyPress="return numeric_only(event);"></asp:TextBox>


    </td>
</tr>
                                                           <tr>
                                                               <td>
                                                                    <label>Net Amount : </label>
                                                               </td>
                                                               <td>
                                                                   <asp:TextBox ID="txtAmount" runat="server" Text="0" Enabled="false" class="form-control"   placeholder="Amount" onkeyPress="return numeric_only(event);"
                                                       Width ="200px" TabIndex="8" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                                               </td>
                                                               <td>
                                                                     <label> Disc Reason : </label>
                                                               </td>
                                                               <td>
                                                                   <asp:DropDownList ID="ddlDiscReason" runat="server" AutoPostBack="True" height="30px" 
                                                     Width="200px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </td>
                                                               <td colspan="2" rowspan="6">
                                                                   <div style=" overflow: scroll; width: 100%; height: 250px; text-align: left"
                                                                                id="Di6">
                                                                  <asp:GridView ID="gvBillTransaction" class="table table-responsive table-sm table-bordered" runat="server" AutoGenerateColumns="False" Width="100%"                                       
                                                              HeaderStyle-ForeColor="Black" ShowHeaderWhenEmpty="true"  AlternatingRowStyle-BackColor="White"   >
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PaymentDate" HeaderText="Transaction Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                       <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No " />
                                                                          <asp:BoundField DataField="DiscountGivenBy" HeaderText="Dr Name " />
                                                                         <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Paid" />
                                                                        <asp:BoundField DataField="ModeOfPaymentName" HeaderText="Mode Of Payment" />
                                            
                                                                        <asp:BoundField DataField="CreatedBy" HeaderText="Transcation User" />
                                                                    </Columns>
                                                             </asp:GridView>
                                                                       </div>

                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                   <label> Amount Received : </label>
                                                               </td>
                                                               <td>
 <asp:TextBox ID="txtAmountReceived" runat="server" ReadOnly="true"  class="form-control" Text="0"  height="30px"   placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8" ></asp:TextBox>
                                                               </td>
                                                               <td>
                                                                       <label> Disc Given By: </label>
                                                               </td>
                                                               <td>

                                                               <asp:DropDownList ID="ddlDiscountGivenBy" runat="server" AutoPostBack="True" height="30px" 
                                                     Width="200px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </td>
                                                           </tr>
                                                           <tr>
                                                               <td>
                                                         <label> Insurance Amount : </label>
                                                               </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAwardAmt" runat="server" ReadOnly="true"   class="form-control" Text="0"  height="30px"    onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8" ></asp:TextBox>
                                                               </td>
                                                                <td>
                                            <label> BalanceReason: </label>
                                                               </td>
                                                                <td>
 <asp:DropDownList ID="ddlBalreason" runat="server" AutoPostBack="True"  
                                                       Width="200px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                    <label> Disc Given : </label>
                                                               </td>
                                                                 <td>
 <asp:TextBox ID="txtdiscgiven" runat="server" ReadOnly="true"  class="form-control" Text="0"  height="30px"    onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8"  AutoPostBack="True"></asp:TextBox>
                                                               </td>
                                                                 <td colspan="2">
                                                                      <asp:CheckBox ID="chkDeposite" Text="Transfer From Deposit" ForeColor="Red" runat="server" AutoPostBack="true" ></asp:CheckBox></label>
                                                              <asp:Label ID="lblDepositAmt" ForeColor="Red" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                      </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                    <label> Balance : </label>
                                                               </td>
                                                                 <td>
 <asp:TextBox ID="txtPaid" runat="server" Enabled="false" Visible="false"  class="form-control" Text="0"  height="30px"   placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8" OnTextChanged="txtPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                               <asp:TextBox ID="txtbalance" runat="server" text="0" class="form-control" ReadOnly="true"     placeholder="Balance" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8"></asp:TextBox>
                                                                      </td>
                                                                 <td colspan="2">
                                                                     <asp:CheckBox ID="chkFinalDischarge" Text="Final Discharge" ForeColor="Blue" runat="server" AutoPostBack="true" Font-Size="Medium" OnCheckedChanged="chkFinalDischarge_CheckedChanged" ></asp:CheckBox>
                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                     
                                                               </td>
                                                                <td>
  
                                                               </td>
                                                                <td>

                                                               </td>
                                                                <td>

                                                               </td>

                                                           </tr>
                                                       </table>
                                                       </div>
                             </div>
                                        
                                       
                                          <div class="col-lg-12 text-center" runat="server" visible="false">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save" Visible="false"  OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary"  />
                                               <asp:Button ID="btnrefund" runat="server" Text="Refund" Visible="false"    OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary" OnClick="btnrefund_Click"  />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="80px" />
                                              <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px"  onclientclick="target = '_blank';" OnClick="btnReport_Click" />
                                       <asp:Button ID="btnSummary" runat="server" Text="Summary" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px"  onclientclick="target = '_blank';" OnClick="btnSummary_Click" />

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

