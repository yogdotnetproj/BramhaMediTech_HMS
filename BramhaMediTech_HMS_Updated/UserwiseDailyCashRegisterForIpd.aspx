<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="UserwiseDailyCashRegisterForIpd.aspx.cs" Inherits="UserwiseDailyCashRegisterForIpd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
             <asp:PostBackTrigger ControlID="btnExcel" />
             
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Userwise Ipd Cash Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Userwise Ipd Cash Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
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
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>

                                        <div class="col-sm-1">
                                                             <div class="form-group">
<asp:DropDownList ID="ddlTimeTo" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                                                 </div>
                                             </div>
                                        
                                    <div class="col-sm-1">
                                                        <div class="form-group">
                                                        <label for="ddlUser">User:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select"/>                                                      
                                                </div>                                                    
                                    </div>
                              <div class="row">
                                          <div class="col-sm-2 mt-3 text-center">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlBank" runat="server"  TabIndex="2" CssClass="form-control form-select" />                                                      
                                                </div>                                                    
                                    </div> 
                                 <div class="col-lg-10 text-center mt-3" >
                                     <div class="form-group form-check">
                                                       
                                      
                                   
                                       
                                                            <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                                             </asp:RadioButtonList>                                                
                      
                                                        
                                                        
                                        </div>
                                         </div>
                               </div>
                                        </div>
                                        
                                     </div>
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center mt-3">
                                          
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-success" 
                                            OnClick="Print_Click"  Text="Print" />
                                             <asp:Button ID="btnExcel" runat="server" CausesValidation="False" CssClass="btn btn-primary" 
                                              Text="Print Excel" OnClick="btnExcel_Click" />
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" CssClass="btn btn-warning" 
                                            Text="Reset" />
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


