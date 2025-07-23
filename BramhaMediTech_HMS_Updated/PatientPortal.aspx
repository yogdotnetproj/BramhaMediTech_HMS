<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatientPortal.aspx.cs" Inherits="PatientPortal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Portal</title>
      <link href="cssmain/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="cssmain/master.css"/>
    <link rel="stylesheet" href="plugins/font-awesome/css/font-awesome.min.css"/>
    <link href="cssmain/main.min.css" rel="stylesheet" />
  
    <!-- THEME STYLES-->
    <link rel="stylesheet" href="plugins/theme/css/theme.min.css">
    <link href="cssmain/themify-icons/css/themify-icons.css" rel="stylesheet" />
    
    <!-- PAGE LEVEL STYLES-->
    <link href="plugins/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />
   
</head>
<body>
   <%-- <div class="content-wrapper">--%>
            <!-- Main content -->
            <section class="content">
                <div class="row">
                    <section class="col-lg-12 ">
                        <form id="form1" runat="server">
                             <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
    
                             <div class="panel panel-info" >
      <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Visible="false" Font-Bold="true" ForeColor="Red"  runat="server" Text=""></asp:Label> </div>
      <div class="panel-body bg-white"  >
    
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name:</label>
                                        <asp:Label ID="lblPatientName" ForeColor="Red" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-3 text-left" >
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                                        <asp:Label ID="txtpatientregid" ForeColor="Red" Font-Bold="true" Font-Italic="true" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                    <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left">DOB:</label>
                                        <asp:Label ID="Label6" ForeColor="Red" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               

                              
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="" style="text-align: left">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                     
                                    </div>
                            </div>
                             
                       
                            <div class="col-lg-12 text-left">
                                <div class="row">
                               

                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                                

                               
                                 <div class="col-lg-8 text-left" >
                                    <div class="form-group">
                                        <label for="lblAddress" title="" style="text-align: left">Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>

        
           
           </div>
                                       <div style="height:2px; background:#B24592;"> </div>
                            </div> 
                          <div class="col-lg-12 mt-3 text-left">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    
                                    <asp:Button ID="btnpathology" runat="server" Text="Pathology Report" 
                                         class="btn btn-success" OnClick="btnpathology_Click"  />
                                    </div>
                                     <div class="col-lg-3 text-left">
                                    
                                    <asp:Button ID="btnreadiology" runat="server" Text="Radiology Report" 
                                         class="btn btn-warning" OnClick="btnreadiology_Click"  />
                                    </div>
                                    <div class="col-lg-3 text-left">
                                    
                                    <asp:Button ID="btnMedicalLab" runat="server" Text="Medical Lab Report" 
                                         class="btn btn-primary" OnClick="btnMedicalLab_Click"  />
                                    </div>
                                     <div class="col-lg-3 text-left">
                                    
                                    <asp:Button ID="btncardiology" runat="server" Text="Other Studies Report" 
                                         class="btn btn-danger" OnClick="btncardiology_Click"  />
                                    </div>
                                    </div>
                              </div>

                              <div class="col-lg-12 mt-3 text-left">
                                <div class="row">
                                    <div class="col-lg-12 text-left">

                                        </div>
                                    </div>
                                  </div>
                            <div class="col-lg-12 mt-3 text-left">
                                <div class="row">
                                    <div class="col-lg-12 text-left">
                                           <div class="form-group">  
                                        <div class="table-responsive" style="width:100%" >
                                             <div style=" overflow: scroll; width: 100%; height: 400px; text-align: left"
                                                                                id="Div6">
                                                 <asp:GridView ID="GvNoteIngrid" DataKeyNames="LabRegNo" runat="server" AutoGenerateColumns="false"
                                                class="table table-responsive table-lg table-bordered" Width="100%" 
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                BackColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  ShowHeaderWhenEmpty="True" OnDataBound="GvNoteIngrid_DataBound" OnRowDataBound="GvNoteIngrid_RowDataBound" >                                                <Columns>
                                       
                                                          <asp:TemplateField HeaderText="Print">
                                                         <ItemTemplate>
                                                             <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:BoundField DataField="RegDate" ItemStyle-Width="30%" HeaderText="Date"  />
                                              
                                                    <asp:BoundField DataField="DrName" ItemStyle-Width="20%" HeaderText="Doctor"  />
                                                    <asp:BoundField DataField="ServiceName" ItemStyle-Width="60%" HeaderText="Test"  />
                                                    <asp:BoundField DataField="CreatedBy" ItemStyle-Width="60%" HeaderText="Ordered by"  />
                                                      <asp:BoundField DataField="BilledBy" ItemStyle-Width="60%" HeaderText="Billed By"  />
                                                     <asp:BoundField DataField="IPDNo" ItemStyle-Width="60%" HeaderText="PType"  />
                                                    <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="hdnReqType" runat="server" Value='<%#Eval("ReqType") %>' />
                                             <asp:HiddenField ID="HdnIPDNo" runat="server" Value='<%#Eval("IPDNo") %>' />
                                             <asp:HiddenField ID="HdnPatRegId" runat="server" Value='<%#Eval("PatRegId") %>' />
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnPID" runat="server" Value='<%#Eval("PID") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                              <asp:HiddenField ID="HdnLabRegNo" runat="server" Value='<%#Eval("LabRegNo") %>' />
                                              <asp:HiddenField ID="HdnPtype" runat="server" Value='<%#Eval("Ptype") %>' />
                                              <asp:HiddenField ID="HdnClinicalHistory" runat="server" Value='<%#Eval("ClinicalHistory") %>' />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                            
                                                 </div>
                                </div>
                                </div>
                                        </div>
                                    </div>
                                  </div>
                            <script language="javascript" type="text/javascript">
                                function OpenReport() {
                                  
                                    window.open("Reports.aspx");
                                }
               </script>
                        </form>
                    </section>
                </div>
            </section>
            <!-- /.content -->
        <%--</div>--%>
    
    <script src="jsmain/jquery.min.js" type="text/javascript"></script>
        <script src="plugins/jquery-ui/jquery-ui.min.js"></script>
    <script src="assets/vendors/popper.js/dist/umd/popper.min.js" type="text/javascript"></script>
    <script src="jsmain/bootstrap.bundle.min.js" type="text/javascript"></script>
    <script src="jsmain/metisMenu/dist/metisMenu.min.js" type="text/javascript"></script>   
    <script src="jsmain/app.min.js" type="text/javascript"></script>
    
        <script src="plugins/datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
     

</body>
    

</html>
