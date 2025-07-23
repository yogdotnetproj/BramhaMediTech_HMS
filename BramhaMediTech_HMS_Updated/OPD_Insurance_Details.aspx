<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OPD_Insurance_Details.aspx.cs" Inherits="OPD_Insurance_Details" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
       <Triggers>
             <asp:PostBackTrigger ControlID="btnSearch" />
             <asp:PostBackTrigger ControlID="btnPrint" />
            <asp:PostBackTrigger ControlID="btnReset" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>OPD Insurance Details</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OPD Insurance Details</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" CssClass="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-1 pr-0">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">Year</label> 
                                                             </div>
                                                         </div>                             
                                  
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <asp:DropDownList runat="server" CssClass="form-control form-select"  ID="ddlYear">
                                                              <asp:ListItem Value="0" Text="select"></asp:ListItem>
                                                             <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                                              <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                                                              <asp:ListItem Value="2025" Text="2025"></asp:ListItem>
                                                             <asp:ListItem Value="2026" Text="2026"></asp:ListItem>
                                                              <asp:ListItem Value="2027" Text="2027"></asp:ListItem>
                                                            
                                                         </asp:DropDownList>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1 p-0">
                                                             <div class="form-group">
                                                               <label for="txtTo">Month:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                        <asp:DropDownList runat="server" CssClass="form-control form-select"  ID="ddlMonth">
                                                              <asp:ListItem Value="0" Text="select"></asp:ListItem>
                                                             <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                              <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                              <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                              <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                              <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                              <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                              <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                              <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                              <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                              <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                              <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                              <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                         </asp:DropDownList>
                                                     

                                                     </div>
                                                 </div>

                                    
                             
                                        
                                        
                                    <div class="col-sm-4">
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
                                         <div class="col-sm-1 pr-0">
                                                             <div class="form-group">
<asp:RadioButtonList ID="RblType" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Selected="True" Value="0">Due</asp:ListItem>
    <asp:ListItem Value="1">All</asp:ListItem>
                                                                 </asp:RadioButtonList>
                                                                 </div>
                                             </div>
                             </div>

                                         
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" Visible="false" onclick="btnSearch_Click" CssClass="btn btn-danger"
                                            Text="Search" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-success" 
                                            OnClick="Print_Click" Text="Print" />
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" class="btn btn-primary" 
                                            Text="Print Excel" />
                                        </div>
                                    </div>
                                </div>
                                   
                                </div>
               <%-- <div class="box" runat="server" id="List">
                                        
                               
                                         
                                     </div>--%>

                                 
                 
                        </section>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script>
</asp:Content>

