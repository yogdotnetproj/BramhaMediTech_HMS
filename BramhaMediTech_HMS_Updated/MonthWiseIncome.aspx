<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="MonthWiseIncome.aspx.cs" Inherits="MonthWiseIncome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >--%>
        <%-- <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
              <asp:PostBackTrigger ControlID="btnradiologyprint" />
             <asp:PostBackTrigger ControlID="btncharge" />
              <asp:PostBackTrigger ControlID="btnprintexcel" />
              <asp:PostBackTrigger ControlID="btnsummaryreportExcel" />
         </Triggers>--%>
        <%-- <ContentTemplate>--%>
             

             <section class="content-header d-flex">
                    <h1> Income Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active"> Income Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" CssClass="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                   
                                        </div>
                                       <div class="col-lg-12 mt-3" runat="server" >
                                    <div class ="row">
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">Year</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                             <div class="form-Inline form-check">                                                              
                                                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" class="form-control">
                                                            <asp:ListItem Value="0">---Select Year--</asp:ListItem>
                                                            <asp:ListItem Value="2023">2023</asp:ListItem>
                                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                                                            <asp:ListItem Value="2025">2025</asp:ListItem>
                                                            <asp:ListItem Value="2026">2026</asp:ListItem>
                                                            <asp:ListItem Value="2027">2027</asp:ListItem>
                                                            <asp:ListItem Value="2028">2028</asp:ListItem>

                                                            <asp:ListItem Value="2029">2029</asp:ListItem>
                                                            <asp:ListItem Value="2030">2030</asp:ListItem>
                                                            
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                          
                                        </div>
                                        <div id="Div2" class="col-lg-2 " runat="server" >
                                    <div class ="row">
                                        <asp:DropDownList runat="server" ID="GroupTyp" CssClass="form-control pull-left form-select">
                                            <%--<asp:ListItem Value="All"> All</asp:ListItem>
                                            <asp:ListItem Value="EMERGENCY"> EMERGENCY</asp:ListItem>
                                            <asp:ListItem Value="Procedures Fees">Procedures Fees</asp:ListItem>
                                            <asp:ListItem Value="Consultation">Consultations</asp:ListItem>
                                            <asp:ListItem Value="Operating Theatre">Operating Theatre</asp:ListItem>
                                            <asp:ListItem Value="Emergency Room">Emergency Room</asp:ListItem>
                                            <asp:ListItem Value="Doctor Fees">Doctor Fees</asp:ListItem>
                                            <asp:ListItem Value="Daily Rate">Daily Rate</asp:ListItem>
                                            <asp:ListItem Value="Hospital">Hospital</asp:ListItem>
                                            <asp:ListItem Value="Lab Procedures">Lab Procedures</asp:ListItem>
                                             <asp:ListItem Value="OutPatient">OutPatient Pharmacy</asp:ListItem>
                                             <asp:ListItem Value="InPatient">InPatient Pharmacy</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        </div>
                                           </div>
                                         <div id="Div3" class="col-lg-1 " runat="server" >
                                    <div class ="row">
                                         <asp:Button ID="btnAllPrint" runat="server" class="btn btn-success"
                                            Text="Print" OnClick="btnAllPrint_Click" /> 
                                      
                                        </div>
                                             </div>
                                         <div id="Div4" class="col-lg-1 " runat="server" >
                                    <div class ="row">
                                          <asp:Button ID="brnAllPrintExcel" runat="server" class="btn btn-warning"
                                            Text="Print Excel" OnClick="brnAllPrintExcel_Click" /> 
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
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>



