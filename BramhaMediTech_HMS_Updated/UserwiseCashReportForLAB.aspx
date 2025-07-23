<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="UserwiseCashReportForLAB.aspx.cs" Inherits="UserwiseCashReportForLAB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
              <asp:PostBackTrigger ControlID="btnradiologyprint" />
             <asp:PostBackTrigger ControlID="btncharge" />
              <asp:PostBackTrigger ControlID="btnprintexcel" />
              <asp:PostBackTrigger ControlID="btnsummaryreportExcel" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Userwise LAB Cash Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Userwise LAB Cash Report</li>
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
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                               <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                      </div>
                                                    </div> 
                                          <div class="col-sm-1">
                                                             <div class="form-group">
<asp:DropDownList ID="ddlTimeFrom" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                                                 </div>
                                             </div>
                                                   
                                     <div class="col-sm-1">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                                          <div class="col-sm-1">
                                                             <div class="form-group">
<asp:DropDownList ID="ddlTimeTo" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                                                 </div>
                                             </div>
                                          <div class="col-sm-1 p-0">
                                                        <div class="form-group">
                                                        <label for="ddlBillGroup">Bill Group:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-3">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlBillGroup" runat="server"  TabIndex="2" CssClass="form-control form-select">                                                      
                                                        <asp:ListItem Value="0">Select Group</asp:ListItem>
                                                        <asp:ListItem Value="P">Pathology</asp:ListItem>
                                                        <asp:ListItem Value="R">Radiology</asp:ListItem>
                                                        <asp:ListItem Value="M">Medical LAB</asp:ListItem>
                                                         <asp:ListItem  Value="C">Cardiology</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>                                                    
                                    </div>
                                        </div>
                                         <div class="row">
                                    
                                     <div class="col-sm-1 p-0 mt-3 text-center">
                                                        <div class="form-group">
                                                        <label for="ddlBillGroup">user:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                              <div class="col-sm-2 mt-3 text-center">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select"/>                                                      
                                                </div>                                                    
                                    </div>
                                        <div class="col-sm-2 mt-3 text-center">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlBank" runat="server"  TabIndex="2" CssClass="form-control form-select" />                                                      
                                                </div>                                                    
                                    </div> 
                                 <div class="col-sm-2 p-0 mt-3 text-center">
                                                        <div class="form-group"> 
                                                            <label for="ggfdgfd">Ref By</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                             <div class="col-sm-4 mt-3 text-center">
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
                                     </div>
                                       <div class="row">

                                            <div class="col-lg-12 mt-3 text-center" >
                                     <div class="form-group">
                                                       
                                                            <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                                             </asp:RadioButtonList>                                                
                      
                                                        
                                                        
                                        </div>
                                         </div>
                               </div>

                                           </div>

                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center mt-3">
                                          
                                             <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-success" 
                                            OnClick="Print_Click"  Text="Cash Report" />
                                             <asp:Button ID="btnprintexcel" runat="server" CausesValidation="False" class="btn btn-primary" 
                                            Text="Cash Report Excel" OnClick="btnprintexcel_Click" />
                                             <asp:Button ID="btncharge" runat="server" CausesValidation="False" class="btn btn-warning" 
                                           OnClick="btncharge_Click" Text="Charge Report" />

                                       
                                        <asp:Button ID="btnradiologyprint" runat="server" CausesValidation="False" class="btn btn-primary" 
                                            Text="Summary Report" OnClick="btnradiologyprint_Click" />
                                        <asp:Button ID="btnsummaryreportExcel" runat="server"  class="btn btn-warning" 
                                            Text="Summary Report Excel" OnClick="btnsummaryreportExcel_Click" />
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



