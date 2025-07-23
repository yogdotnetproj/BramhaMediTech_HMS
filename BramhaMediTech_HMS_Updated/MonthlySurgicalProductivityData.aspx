<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="MonthlySurgicalProductivityData.aspx.cs" Inherits="MonthlySurgicalProductivityData" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
               <asp:PostBackTrigger ControlID="btnExcel" />
         </Triggers>

        <ContentTemplate>
             
            <section class="content-header d-flex">
                    <h1>Monthly Surgical Productivity Data</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Monthly Surgical Productivity Data</li>
                    </ol>
                </section>
      <section class="content">
                      <div class="box" runat="server" id="show">
                             <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                             <div class="box-body">
                                    <div class="row">   
                                        <div class="col-sm-1">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">Month</label>                                                                                
                                                    </div>
                                         </div>               
                                          <div class="col-sm-2">
                                             <div class="form-Inline form-check">                                                              
                                                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="false" class="form-control">
                                                            <asp:ListItem Value="0">---Select--</asp:ListItem>
                                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                                            <asp:ListItem Value="3">March</asp:ListItem>
                                                            <asp:ListItem Value="4">April</asp:ListItem>
                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                            <asp:ListItem Value="6">Jun</asp:ListItem>

                                                            <asp:ListItem Value="7">July</asp:ListItem>
                                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                                             <asp:ListItem Value="9">Sep</asp:ListItem>
                                                             <asp:ListItem Value="10">Oct</asp:ListItem>
                                                             <asp:ListItem Value="11">Nov</asp:ListItem>
                                                             <asp:ListItem Value="12">Dec</asp:ListItem>
                                                            
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                          
                                        </div>
                                                     
                                        <div class="col-sm-1">
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
                                       
                                        
                                               
                                       <div class="col-sm-4">                                    
                                              <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-success"  OnClick="btnPrint_Click"  Text="Print"/>
                                           <asp:Button ID="btnExcel" runat="server" CssClass="btn btn-warning"   Text="Excel" OnClick="btnExcel_Click" />
                                             
                                        </div>
                                      
 <div class="col-sm-2">  
     <asp:Label runat="server" ID="LblMsg" Font-Bold="false" ForeColor="Red"></asp:Label>
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

