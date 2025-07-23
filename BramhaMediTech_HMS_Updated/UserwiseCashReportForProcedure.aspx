<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="UserwiseCashReportForProcedure.aspx.cs" Inherits="UserwiseCashReportForProcedure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
              <asp:PostBackTrigger ControlID="btnprintService" />
             <asp:PostBackTrigger ControlID="btnReset" />
              <asp:PostBackTrigger ControlID="btnExcelService" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Userwise Procedure Cash Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Userwise Procedure Cash Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-1 pr-0">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2 text-left">
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
                                                   
                                     <div class="col-sm-1 p-0">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2 text-left">
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
                                                        <asp:ListItem>OPD</asp:ListItem>
                                                        <asp:ListItem>EMERGENCY</asp:ListItem>
                                                        <asp:ListItem>EEG OPD</asp:ListItem>
                                                        <asp:ListItem>AMBULANCE</asp:ListItem>
                                                        <asp:ListItem Value="OPHTHAL">OPHTHAL</asp:ListItem>
                                                         <asp:ListItem>HOSPITAL</asp:ListItem>
                                                         <asp:ListItem>Consultation</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>                                                    
                                    </div>
                                        
                                        
                                    
                                         
                                 <div class="col-lg-12 mt-3" >
                                     <div class="row">
                                     <div class="col-sm-1 pr-0">
                                                        <div class="form-group">
                                                        <label for="ddlUser">UserName:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select" />                                                      
                                                </div>                                                    
                                    </div>
                                           <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlBank" runat="server"  TabIndex="2" CssClass="form-control form-select" />                                                      
                                                </div>                                                    
                                    </div>
                             <div class="col-sm-7">
                                     <div class="form-group">
                                                            <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                                             </asp:RadioButtonList>                                                
                      
                                                        
                                                        
                                        </div>
                                         </div>
                             </div>   
                             </div>
                               </div>
                                        
                                        
                                     </div>
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center ">
                                          
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary" 
                                            OnClick="Print_Click"  Text="Print" />
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" CssClass="btn btn-warning" 
                                            Text="Print Excel" />
                                            <asp:Button ID="btnprintService" runat="server" CausesValidation="False" CssClass="btn btn-success" 
                                             Text="Print service wise" OnClick="btnprintService_Click" />

                                              <asp:Button ID="btnExcelService" runat="server"  CssClass="btn btn-warning" 
                                            Text="Excel Service Wise" OnClick="btnExcelService_Click" />
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



