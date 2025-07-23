<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="CreateChargeNumber.aspx.cs" Inherits="CreateChargeNumber" %>


  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
     <script type="text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtInsuranceid").value == "") {
                 alert("Please Select Company ");
                 return false;
             }
         }
        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnreport" />
         </Triggers>
         <ContentTemplate>
   
            <section class="content-header d-flex">
                <h1>Create Charge Number</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Create Charge Number</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                     <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                           
                            </div>
                    <div class="box-body">
                                       <div class="panel panel-info" >
      <div class="panel-heading" style="font-size:medium;font-weight:bold"">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Font-Bold="true" ForeColor="aqua"  runat="server" Text=""></asp:Label> </div>
      <div class="panel-body">
    
                            <div class="col-lg-12">
                                <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="lblPatientName"><b>Name:</b></label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title=""><b>PRN:</b></label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label for="lblAge" title=""><b>Age:</b></label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title=""><b>Mobile No:</b></label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                     
                                    </div>
                            </div>
                       
                              <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="lblAddress" title=""><b>Address:</b></label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                  </div>
           </div>
                            </div>  
                        <div class="row">
                            

                             <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     
                                    
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranced">Insurance Company</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-3">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox runat="server" ID="txtInsuranceid" Font-Bold="True" Font-Size="Medium" placeholder=" Insurance Company" CssClass="form-control pull-right" AutoPostBack="true"  OnTextChanged="txtInsuranceid_TextChanged"></asp:TextBox>
                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchInsurance"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtInsuranceid"
                                                ID="AutoCompleteExtender2"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                               <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsura"> Company Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-3">
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
                        
                              <div class="col-sm-2">
                                            <asp:Button ID="btnreport" runat="server"  OnClick="btnreport_Click"   OnClientClick="return Validate();"
                                        Text=" Charge Number" ToolTip="Print" CssClass="btn btn-primary" />
                                       
                                        </div>
                            

                                       
                               
                                    
                               
                            </div>

                        </div>
                        </div>

                         <div class="row">
                            

                             <div class="col-lg-12 mt-3 text-center" >
                                         <div class="row">
                                             
                                              <div class="col-sm-12 text-center ">
                                                    <div class="form-group">  
                                             <asp:TextBox runat="server" class="form-control" ID="txtcompdes" ForeColor="Red" Font-Bold="true" TextMode="MultiLine"  cols="6" rows="6" style="width:100%;"> </asp:TextBox>
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


<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .form-group {
        }
    </style>
</asp:Content>



