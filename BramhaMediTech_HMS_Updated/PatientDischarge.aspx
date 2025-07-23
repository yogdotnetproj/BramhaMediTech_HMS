<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientDischarge.aspx.cs" Inherits="PatientDischarge" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <section class="content-header d-flex">
                    <h1>Discharge Patients</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Discharge patients</li>
                    </ol>
                </section>
      <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>
                         <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:   <asp:Label  ID="Label1"  Font-Bold="true" ForeColor="White"  runat="server" Text=""></asp:Label> </div>
                        <div class="box-body">
                                  <div class="box-header with-border">
                       
                            <div class="col-lg-12 text-left">
                                 <div class="row">

                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">RegId:</label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Patient Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBillNo" title="" style="text-align: left">Bill No:</label>
                                        <asp:Label ID="lblBillNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                        
                            <div class="col-lg-12 mt-2 text-left">
                                 <div class="row">
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPatCat" title="" style="text-align: left">Patient Category:</label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblAdmissionDate" title="" style="text-align: left">Admission Date:</label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                            </div>
                        </div>
                    </div>
                           <div style="height:2px; background:#B24592;"> </div>
                                  <div class="col-lg-12 mt-3 text-left">
                                        <div class="row">
                                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" title="Discharge Date:" style="text-align: left"><strong> Discharge Date:</strong></label>
                                      <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdischargedate" runat="server" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                    </div>
                                </div>

                               


                                      <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left"><strong>Discharge Time:</strong></label>
                                         <asp:DropDownList ID="DdlDischargeTime" runat="server" Visible="false" Width="100px" AutoPostBack="false" Class="form-control" TabIndex="2">
                                             <asp:ListItem>--Select--</asp:ListItem>
                                             <asp:ListItem>12:00</asp:ListItem>
                                             <asp:ListItem>12:30</asp:ListItem>
                                             <asp:ListItem>01:00</asp:ListItem>
                                             <asp:ListItem>01:30</asp:ListItem>
                                             <asp:ListItem>02:00</asp:ListItem>
                                             <asp:ListItem>03:00</asp:ListItem>
                                             <asp:ListItem>03:30</asp:ListItem>
                                             <asp:ListItem>04:00</asp:ListItem>
                                             <asp:ListItem>04:30</asp:ListItem>
                                             <asp:ListItem>05:00</asp:ListItem>
                                             <asp:ListItem>05:30</asp:ListItem>
                                             <asp:ListItem>06:00</asp:ListItem>
                                             <asp:ListItem>06:30</asp:ListItem>
                                             <asp:ListItem>07:00</asp:ListItem>
                                             <asp:ListItem>07:30</asp:ListItem>
                                             <asp:ListItem>08:00</asp:ListItem>
                                             <asp:ListItem>08:30</asp:ListItem>
                                             <asp:ListItem>09:00</asp:ListItem>
                                             <asp:ListItem>09:30</asp:ListItem>
                                             <asp:ListItem>10:00</asp:ListItem>
                                             <asp:ListItem>10:30</asp:ListItem>
                                             <asp:ListItem>11:00</asp:ListItem>
                                             <asp:ListItem>11:30</asp:ListItem>
                                            
                                         </asp:DropDownList>
                                        <asp:TextBox ID="txtTime" runat="server"  class="form-control" 
                                                     TabIndex="9"  Width="200px" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                                    </div>
                                </div>

                              
                                <div class="col-lg-2 text-right">
                                    <div class="form-group">
                                        <label for="lblBranchId" title="" style="text-align: left"></label>
                                       <asp:DropDownList ID="ddlampm" Visible="false" runat="server" Width="100px" AutoPostBack="false" Class="form-control" TabIndex="2">
                                             <asp:ListItem>--Select--</asp:ListItem>
                                             <asp:ListItem>AM</asp:ListItem>
                                             <asp:ListItem>PM</asp:ListItem>
                                             
                                            
                                         </asp:DropDownList>
                                    </div>
                                </div>


                                
                                    </div>
                                </div>
                                <div class="col-lg-12 mt-3" > 
                                            <div class="row">
                                                 <div class="col-lg-3" >
                                    <div class="form-group">
                                         <label for="txtOpMainCat" style="text-align:left">Reason for Discharge:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group"> 
                                         <asp:DropDownList ID="ddlreasonofdisc" runat="server" AutoPostBack="True" Class="form-control" TabIndex="2">
                                             <asp:ListItem>--select--</asp:ListItem>
                                             <asp:ListItem>Recover</asp:ListItem>
                                             <asp:ListItem>Personal request</asp:ListItem>
                                             <asp:ListItem>Death</asp:ListItem>
                                             <asp:ListItem>Other</asp:ListItem>
                                         </asp:DropDownList>
                                   </div>
                                </div>
                                                
                                    

                                <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                        
                                        <asp:Button ID="btnsave" runat="server" class="btn btn-success"  TabIndex="3" Text="Discharge" OnClick="btnsave_Click"  />
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnReset_Click" />
                                       
                                         <asp:Button ID="btnReport" runat="server"  Text="Report"  
                                        CausesValidation="False" TabIndex="16" class="btn btn-warning" Width="100px"   OnClick="btnReport_Click" />
                                       <asp:Button ID="btnSummary" runat="server" Text="Summary" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px"   OnClick="btnSummary_Click" />

                                       
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
</asp:Content>

