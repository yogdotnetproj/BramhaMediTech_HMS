<%@ Page Title="" Language="C#" MasterPageFile="~/EMRMaster.master" AutoEventWireup="true" CodeFile="IPDEMRDashboard.aspx.cs" Inherits="IPDEMRDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="ckeditor/ckeditor.js"></script>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
           <%-- <section class="content-header">
                <h1>Dashboard</h1>
            </section>--%>

            <section class="content pt-4">
                <div id="Div1" class="box" runat="server">
                    
                     <%-- <div class="box-body">--%>
                        <%-- <div class="row">--%>
                             <div class="panel panel-info" >
      
      <div class="panel-body">
    <%--<div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Font-Bold="true" ForeColor="Red"  runat="server" Text=""></asp:Label> </div>
                <div class="panel-body bg-white"  >       
        
                       
                            <div class="col-lg-12 mt-3 text-left">
                               <div class="row">  

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPrnNo" runat="server" Font-Bold="true" Text="Reg ID:" ></asp:Label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPat" runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label ID="lblI"  runat="server" Font-Bold="true" Text="IPD NO:"></asp:Label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblBio" runat="server" Font-Bold="true" Text="Dept Name:"></asp:Label>
                                        <asp:Label ID="lblBillNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="hhhd" runat="server" Font-Bold="true" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="col-lg-12 mt-3 text-left">
                                 <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server" Font-Bold="true" Text="Sponsor:"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true" Text="Admission Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div3" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Font-Bold="true" ForeColor="Black" Text="DR Name:"></asp:Label>
                                        <asp:Label ID="lbldrname" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="lblBi" runat="server" Font-Bold="true" ForeColor="Black" Text="Room Type:" ></asp:label>
                                        <asp:Label ID="LblRoomType" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server" Font-Bold="true" ForeColor="Black" Text="Bed Name:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                        <div class="col-lg-12 mt-3 text-left">
                                  <div class="row">
                                      <div class="col-lg-5 text-left" >
                                    <div class="form-group">
                                       
                                         <asp:label id="Label2" runat="server" Font-Bold="true" ForeColor="Black" Text="Address:"></asp:label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                      <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        
                                           <asp:label id="Label4" runat="server" Font-Bold="true" ForeColor="Black" Text="Relative:"></asp:label>
                                        <asp:Label ID="lblKin" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:label id="Label1" runat="server" Font-Bold="true" ForeColor="Black" Text="Contact:"></asp:label>
                                        <asp:Label ID="lblConct" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                                     <div id="Div4" class="col-lg-3 text-left" runat="server" >
                                    <div class="form-group">
                                      
                                        <asp:label id="Label3" runat="server" Font-Bold="true" ForeColor="Black" Text="Relation:"></asp:label>
                                        <asp:Label ID="lblRelation" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                 </div>


                    </div>--%>
            <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Visible="false" Font-Bold="true" ForeColor="Red"  runat="server" Text=""></asp:Label> </div>
                <div class="panel-body bg-white px-3">
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left"><strong> Name:</strong></label>
                                        <asp:Label ID="lblPatientName" ForeColor="Red" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-3 text-left" >
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left"><strong>PRN: </strong></label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div id="Div7" class="col-lg-2 text-left" runat="server" visible="false">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="" style="text-align: left"><strong>IPD No:</strong></label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left" id="Div8" runat="server" >
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left"><strong>OPD No:</strong></label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="" style="text-align: left"><strong>Mobile No:</strong></label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                      <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblVisitingNo"   title="" style="text-align: left"><strong>Visit No:</strong></label>
                                        <asp:Label ID="lblVisitingNo" runat="server" Text=" "></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
                             
                       
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="" style="text-align: left"><strong>Consultant:</strong></label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left" >
                                    <div class="form-group">
                                        <label for="lblDept" title="" style="text-align: left"><strong>Dept:</strong></label>
                                        <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="" style="text-align: left"><strong>Age:</strong></label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="col-lg-2 text-left"  >
                                    <div class="form-group">
                                        <label for="lblToken" title="" style="text-align: left"><strong>Token No:</strong></label>
                                        <asp:Label ID="lblToken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                               
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left"><strong>DOB:</strong></label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>

           <div class="col-lg-12 text-left" runat="server" id="IpdRmCat">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server" Font-Bold="true"  Text="Sponsor:"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true"  Text="Adm.Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                                     <div id="Div3" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Font-Bold="true" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server"  Font-Bold="true" Text="Bed number:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
     
            <div class="col-lg-12 mt-2 text-left">
                                  <div class="row">
                                      <div class="col-lg-6 text-left" >
                                    <div class="form-group">
                                        <label for="lblAddress" title="" style="text-align: left"><strong>Address:</strong> </label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                      <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server"  Font-Bold="true" Text="Relative:"></asp:Label>
                                        <asp:Label ID="lblKin" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server"  Font-Bold="true" Text="Contact:"> </asp:Label>
                                        <asp:Label ID="lblConct" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                                     <div id="Div2" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="Label5"   runat="server" Font-Bold="true" Text="Relation:"></asp:Label>
                                        <asp:Label ID="lblRelation" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                 </div>
           </div>
         
           </div>
                                  <div class="col-lg-12 mt-3">
                            <div class="row">   
                                <div class="col-lg-12 text-center" > 
                                    </div>
                                </div>
                                      </div>
                                 <div style="height:4px; background:#B24592;"> </div>
                            </div>  


                         <%-- </div>--%>
                       <div class="col-lg-12 mt-3">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnAdmisionSheet" ImageUrl="~/EmrDasImage/EMR_icons/AdmissionSheet.jpg" OnClick="btnAdmisionSheet_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnvital" ImageUrl="~/EmrDasImage/EMR_icons/vital-signs.jpg" OnClick="btnvital_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnintakeoutput" ImageUrl="~/EmrDasImage/EMR_icons/Intake_Output_Chart.jpg" OnClick="btnintakeoutput_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btninvestigation" ImageUrl="~/EmrDasImage/EMR_icons/Investigation_Report.jpg" OnClick="btninvestigation_Click" />
                                                </div>
                                    </div>
                                <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                <asp:ImageButton runat="server" Width="100px" Height="70px"  ID="btnordersheet" ImageUrl="~/EmrDasImage/EMR_icons/Order_Sheet.jpg" OnClick="btnordersheet_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="byndrnote" ImageUrl="~/EmrDasImage/EMR_icons/Doctor_Notes.jpg" OnClick="byndrnote_Click" />
                                                </div>
                                    </div>

                                </div>
                           </div>


                      <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >   
                                     <label for="lblMobileNo" title="" style="text-align: left">Admission Sheet</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Vital-Signs</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Intake Output Chart</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Investigation Report</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Order Sheet</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Clinical Pharmacist Notes</label>
                                    </div>
                                </div>
                          </div>
                     <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-12 text-left" > 
                                    <label for="lblMobileNo" title="" style="text-align: left">.</label>
                                    </div>
                                </div>
                         </div>
                      <div class="col-lg-12">
                            <div class="row">   
                                
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnmar" ImageUrl="~/EmrDasImage/EMR_icons/MAR.jpg" OnClick="btnmar_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnnursenote" ImageUrl="~/EmrDasImage/EMR_icons/Nurses_Notes.jpg" OnClick="btnnursenote_Click" />
                                                </div>
                                    </div>

                                <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnsurgeryform" ImageUrl="~/EmrDasImage/EMR_icons/Surgery_Form.jpg" OnClick="btnsurgeryform_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btndrnote" ImageUrl="~/EmrDasImage/EMR_icons/Doctor_Notes.jpg" OnClick="btndrnote_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btndischargemedication" ImageUrl="~/EmrDasImage/EMR_icons/Discharge_Medication.jpg" OnClick="btndischargemedication_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btndischargesummary" ImageUrl="~/EmrDasImage/EMR_icons/Doctor_Notes.jpg" OnClick="btndischargesummary_Click" />
                                                </div>
                                    </div>
                                </div>
                           </div>
                     <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >   
                                     <label for="lblMobileNo" title="" style="text-align: left">MAR</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Nurses Notes</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Surgery Form</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Doctor Notes</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title=""  style="text-align: left "  >Discharge Medication</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Discharge Summary</label>
                                    </div>
                                </div>
                          </div>
                     <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-12 text-left" > 
                                    <label for="lblMobileNo" title="" style="text-align: left">.</label>
                                    </div>
                                </div>
                         </div>
                      <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                            <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnMaternity" ImageUrl="~/EmrDasImage/EMR_icons/Maternity.jpg" OnClick="btnMaternity_Click"   />
                                                     </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnIPDVisitrecord" ImageUrl="~/EmrDasImage/EMR_icons/IPD_Visit_Record.jpg" OnClick="btnIPDVisitrecord_Click"  />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnPostCharges" ImageUrl="~/EmrDasImage/EMR_icons/Post_Charges.jpg"  OnClick="btnPostCharges_Click" />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnIpdFile" ImageUrl="~/EmrDasImage/EMR_icons/Dialysis.jpg" OnClick="btnIpdFile_Click"  />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                <asp:ImageButton runat="server" Width="100px" Height="70px"  ID="btnNurseOrder" ImageUrl="~/EmrDasImage/EMR_icons/Nurse_Order.jpg" OnClick="btnNurseOrder_Click"  />
                                                </div>
                                    </div>
                                <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                <asp:ImageButton runat="server" Width="100px" Height="70px"  ID="btnNICUChart" ImageUrl="~/EmrDasImage/EMR_icons/NICUChart.jpg" OnClick="btnNICUChart_Click"  />
                                                </div>
                                    </div>
                                <%--<div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                <asp:ImageButton runat="server" Width="100px" Height="70px"  ID="ImageButton5" ImageUrl="~/EmrDasImage/OrderSheet.jpg"  />
                                                </div>
                                    </div>
                                 <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                                  <asp:ImageButton runat="server" Width="100px" Height="70px" ID="ImageButton6" ImageUrl="~/EmrDasImage/DoctorNote.jpg"  />
                                                </div>
                                    </div>--%>

                                </div>
                           </div>
                     <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >   
                                    
                                     <label for="lblMobileNo" title="" style="text-align: left">Maternity</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">IPD Visit Record</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Post Charges</label>
                                    </div>
                                 <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Dialysis </label>
                                    </div>
                                <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Nurse Order </label>
                                    </div>
                                <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">NICU Chart</label>
                                    </div>
                                <%--  <div class="col-lg-2 text-center" >   
                                      <label for="lblMobileNo" title="" style="text-align: left">Patient Referal</label>
                                    </div>--%>
                                </div>
                          </div>
                     <div class="col-lg-12">
                            <div class="row">   
                                <div class="col-lg-12 text-left" > 
                                    <label for="lblMobileNo" title="" style="text-align: left">.</label>
                                    </div>
                                </div>
                         </div>
                      <div class="col-lg-12" runat="server" id="opV">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >                                                           
                                            <div class="form-group"> 
                                               
                                                <asp:ImageButton runat="server" Width="100px" Height="70px" ID="btnopdvisitrecord" ImageUrl="~/EmrDasImage/EMR_icons/OPD_Visit_Record_1.jpg" OnClick="btnopdvisitrecord_Click"  />
                                                </div>
                                    </div>
                                </div>
                          </div>
                        <div class="col-lg-12" runat="server" id="opV1">
                            <div class="row">   
                                <div class="col-lg-2 text-center" >   
 <label for="lblMobileNo" title="" style="text-align: left">OPD Visit Record</label>
                                    </div>
                                </div>
                            </div>
                    <div class="col-lg-12">
                            <div class="row">   
                                


                                </div>
                           </div>

                    </div>
                </section>

</asp:Content>

