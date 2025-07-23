<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="InsuranceCompTransactionLedger.aspx.cs" Inherits="InsuranceCompTransactionLedger" %>


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
                <h1>Transaction Ledger</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Transaction Ledger</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                     <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                    <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                           
                            </div>
                    <div class="box-body">
                        <div class="row">
                            

                             <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="txtStart">From Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off" runat="server" CssClass="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-sm-1">
                                        <div class="form-group">
                                            <label for="txtEnd">To Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" CssClass="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranceid">Insurance Company</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-3">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox runat="server" ID="txtInsuranceid" placeholder=" Insurance Company" CssClass="form-control pull-right" AutoPostBack="true"  OnTextChanged="txtInsuranceid_TextChanged"></asp:TextBox>
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
                                             </div>
                                        </div>
                        
                              <div class="col-lg-12 mt-3 text-center">
                                            <asp:Button ID="btnreport" runat="server"  OnClick="btnreport_Click"   OnClientClick="return Validate();"
                                        Text=" Print" ToolTip="Print" CssClass="btn btn-primary" />
                                       
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


