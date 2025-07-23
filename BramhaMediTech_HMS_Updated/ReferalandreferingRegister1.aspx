<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="ReferalandreferingRegister1.aspx.cs" Inherits="ReferalandreferingRegister1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>

        <ContentTemplate>
             
            <section class="content-header d-flex">
                    <h1>Referal and refering Register Report</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Referal and refering Register Report</li>
                    </ol>
                </section>
      <section class="content">
                      <div class="box" runat="server" id="show">
                             <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                             <div class="box-body">
                                    
                                            <div class="row">
                                                <div class="col-lg-12 mt-3"> 
                                    <div class="row">                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">From Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div>
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtToDate">To Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div> 
                                         <div class="col-sm-2">
                                            <div class="form-group">
                                                <asp:RadioButtonList runat="server" ID="rblReferType" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="0">Consultant</asp:ListItem>
                                                    <asp:ListItem Value="1">Refering</asp:ListItem>
                                                </asp:RadioButtonList>
                                                </div>
                                             </div>
                                               
                                       <div class="col-sm-2">                                    
                                              <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success"   OnClick="btnSearch_Click" Text="Search"/>
                                           <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning"   OnClick="btnPrint_Click" Text="Print" />
                                             
                                        </div>
 
                                            
                                      
                                    </div>
                                                </div>

                                                <div class="col-lg-12 mt-3"> 
                                    <div class="row">                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">Consultant Dr:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                                    <div class="form-group">
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
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">Refering Dr:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                                <asp:TextBox ID="txtReferingdr" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtReferingdr_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchReferingdr"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                       CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtReferingdr"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
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

     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script>
</asp:Content>


