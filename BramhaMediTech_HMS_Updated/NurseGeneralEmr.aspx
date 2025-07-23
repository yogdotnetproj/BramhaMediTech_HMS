<%@ Page Title="General EMR" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="NurseGeneralEmr.aspx.cs" Inherits="NurseGeneralEmr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <h1>General EMR</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: white;
            width: auto;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no .modalPopup .cancel {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup .cancel {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Nurse General EMR</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Nurse General EMR</li>
                    </ol>
            </section>

            <section class="content">
                <div class="box" runat="server">
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                 <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                <asp:HiddenField ID="txtTreatId" runat="server" />
                            </div>
                            </div>
                    </div>
                      <div class="box-body">
                        <%-- <div class="row">--%>
                             <div class="panel panel-info" >
      <div class="panel-heading">Patient Information</div>
      <div class="panel-body">
    
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName">Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="">PRN:</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left" runat="server" visible="false">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" title="">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                     <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        <label for="lblAddress" title="">Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
                       
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="">Dr Name:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblDept" title="">Department:</label>
                                        <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblVisitingNo"   title="">Visit No:</label>
                                        <asp:Label ID="lblVisitingNo" runat="server" Text=" "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblToken" title="">Token No:</label>
                                        <asp:Label ID="lblToken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                               
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId"></label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
           </div>
                            </div>   
                             <div class="col-lg-12">
                                 <div class="row">
                                      
                                       <div class="col-lg-12">
                                            <%--<div class="row"> --%>  
                                                 <div class="panel panel-info">
                                                     <div class="panel-heading">Complaints & History</div>
                                                         <div class="panel-body mt-2" >
                                                <div class="row">
                                                <div class="col-sm-3 form-group">
                                                    <label for="txtChiefComplaints"><b>Chief Complaints</b></label>
                                                    <asp:Button ID="btnChief1" runat="server" Text="+" />
                                                     <asp:ImageButton ID="btnChief1_light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                                    <%--<textarea class="form-control" rows="4" id="txtChiefComplaints" runat="server"></textarea>--%>
                                                     <asp:TextBox ID="txtChiefComplaints" runat="server"  AutoCompleteType="None"  CssClass="form-control mt-2" placeholder="Enter Chief Complant"
                                                            AutoPostBack="True"    OnTextChanged="txtChiefComplaints_TextChanged"></asp:TextBox>
                                                           <asp:AutoCompleteExtender 
                                                            MinimumPrefixLength="1"  
                                                            ServiceMethod="SearchComplant"                                                
                                                            CompletionInterval="100"
                                                            EnableCaching="false" 
                                                            CompletionSetCount="10" 
                                                            TargetControlID="txtChiefComplaints"
                                                            ID="AutoCompleteExtender1"
                                                            runat="server">
                                                               </asp:AutoCompleteExtender>
                                                </div>
                                  
                                                <div class="col-sm-2 form-group">
                                                    <label for="txtAllergy"><b>Allergies(if any)</b></label>
                                                    <asp:Button ID="btnAllergy" runat="server" Text="+" />
                                                      <asp:ImageButton ID="btnAllergy_Light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                                                    <textarea class="form-control w-100 mt-2" rows="2"  id="txtAllergy" runat="server"></textarea>
                                                </div>  
                                                <div class="col-sm-4 form-group">
                                                    <label for="txtMedicalHistory"><b>Surgical/Medical History</b></label>
                                                    <asp:Button ID="btnMedical" runat="server" Font-Bold="true"  Text="+" />
                                                    <asp:ImageButton ID="btnEmergency" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                                                    <textarea class="form-control w-100 mt-2" rows="2" id="txtMedicalHistory" runat="server"></textarea>
                                                </div>
                                    
                                           
                                                <div class="col-sm-3 form-group">
                                                    <label for="txtSurgicalHistory"><b>Nurse assessment </b></label>

                                                     <asp:Button ID="btnSurgical" runat="server" Text="+" />
                                                      <asp:ImageButton ID="btnSurgical_light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                       
                                                    <textarea class="form-control w-100 mt-2" rows="2" id="txtSurgicalHistory" runat="server"></textarea>
                                                </div>
                                               
                                              
                                           
                                                <div class="col-sm-2 form-group" runat="server" visible="false">
                                        
                                                    <label for="txtNote"><b>Note</b></label>
                                                    <asp:Button ID="btnNote" runat="server" Text="+" />
                                                    <asp:ImageButton ID="btnNote_Light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                                                     <textarea class="mt-2" runat="server" id="txtNote"  rows="2"></textarea>
                                                      </div> 
                                                  </div>           
                                                
                                           </div>
                                      </div>
                                            <%-- </div>--%>
                                       </div>                                      
    
                                       <div class="col-lg-12 mt-3">
                                         <%--<div class="row"> --%>
                                            <div class="panel panel-info">
                                                 <div class="panel-heading">Vitals
                                                      <asp:Button ID="btnVitals" runat="server" Text="+" />
                                                     <asp:ImageButton ID="btnVitals_light" Visible="false"  class="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>
                    
                                                 </div>
                                                      <div class="panel-body">
                                                          <div class="row">
                                                            <div class="col-sm-4 form-group">
                                                                <div class="row">
                                                            
                                                            <div class="form-group col-sm-4">
                                                                <label for="txtHeight"><b>Ht(cm)</b></label>
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtHeight" />
                                                            </div>
                                                            <div class="form-group col-sm-4">
                                                                <label for="txtWt"><b>Wt(kg)</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtWt" />
                                                            </div>
                                                            
                                                            <div class="form-group col-sm-4">
                                                                <label for="txtPulse"><b>Pulse</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtPulse" />
                                                            </div>
                                                      </div>
                                                     </div>                                    
                                                            <div class="col-sm-4 form-group">                                                  
                                                                <div class="row">
                                                             <div class="form-group col-sm-4">
                                                                <label for="txtBp"><b>BP</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtBp" />
                                                            </div>
                                                            <div class="form-group col-sm-4">
                                                                <label for="txtResp"><b>Resp</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtResp" />
                                                            </div>
                                                                 <div class="form-group col-sm-4">
                                                                <label for="txtSPO2"><b>SPO2</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtSPO2" />
                                                            </div>
                                                           
                                                                </div>
                                                            </div>
                                                          <div  class="col-sm-4 form-group" runat="server">
                                                           <div class="row">                                       
                                                            <div class="form-group col-sm-4">
                                                                <label for="txtChest"><b>Temp</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtChest" />
                                                            </div>
                                                          <div class="form-group col-sm-4">
                                                                <label for="txtAn"><b>RBS</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtAn" />
                                                            </div>
                                                               <div class="form-group col-sm-4">
                                                                <label for="txtPsp"><b>HC</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtPsp" />
                                                            </div>
                                                              </div> 
                                                              </div>
                                                          <div id="Div6" class="col-sm-4 form-group" visible="false" runat="server">
                                                        <div class="row">  
                                                            <div class="form-group col-sm-6">
                                                                <label for="txtPv"><b>P/V</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtPv" />
                                                            </div>
                                                            <div class="form-group col-sm-6">
                                                                <label for="txtPa"><b>PA</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtPa" />
                                                            </div>
                                                                </div>
                                                       </div>
                                                            <div class="col-sm-6 form-group mt-3">
                                                    <label for="txtDiagnosis"><b>Diagnosis</b></label>
                                                     <asp:Button ID="btnDiagno" runat="server" Text="+" />
                                                     <asp:ImageButton ID="btndiagno_light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                                   
                                                    <textarea class="w-100" rows="2" e id="txtDiagnosis" readonly="readonly" runat="server"></textarea>
                                                </div>
                                                           <div class="col-sm-6 form-group mt-3">
                                                    <label for="txtProvisionalDiagnosis"><b>Current Medications</b></label>

                                                     <asp:Button ID="btnProvDiagno" runat="server" Text="+" />
                                                      <asp:ImageButton ID="btnPd_light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                       
                                                    <textarea rows="2" class="w-100" id="txtProvisionalDiagnosis" readonly="readonly" runat="server"></textarea>
                                                </div>
                                                               <div class="col-sm-12 form-group mt-2">
                                                    <label for="txtProvisionalDiagnosis"><b>Nurse Note</b></label>

                                                     
                                                    <textarea rows="2" class="w-100" id="txtNurseNote" runat="server"></textarea>
                                                </div>
                                                                <div class="col-sm-10 form-group mt-2">
                                                    <asp:Label ID="TRTR" runat="server" Font-Bold="true" ForeColor="Red"><b>Triage status</b></asp:Label>

                                                     
                                                   <asp:RadioButtonList ID="ChkTriage"  runat="server" RepeatDirection="Horizontal">
                                                       <asp:ListItem Text="High    " Value="1"></asp:ListItem>
                                                       <asp:ListItem Text="Medium  " Value="2"></asp:ListItem>
                                                       <asp:ListItem Text="Low   " Value="0"></asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please select Triage.<br />"
    ControlToValidate="ChkTriage" runat="server" ForeColor="Red" Display="Dynamic" />
                                                </div>
                                                               <div class="col-sm-2 text-left">
                                                     <div class="form-group">
                                                         <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-warning"
                                            Text="LAB Investigation " />
                                                         </div>
                                                                   </div>
                                                            
                                                            <div class="col-sm-6 form-group mt-3" runat="server" visible="false">
                                                    
                                                    <div class="form-row">
                                                        
                                                        <div class="form-group col-sm-2">
                                                                <label for="txtOrd"><b>Ord</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtOrd" />
                                                            </div>
                                                            <div class="form-group col-sm-2">
                                                                <label for="txtCys"><b>CYS</b></label>
                                                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtCys" />
                                                            </div>
                                                        </div>
                                                               </div>
                                                     </div>
                                                          </div>
                                               </div> 
                                        <%-- </div>--%>
                                     </div>
                                       
                                       <div class="col-lg-12 mt-3">
                                           <div class="panel panel-info">
      <div class="panel-heading">Notes and Files</div>
      <div class="panel-body">
    
                                               <%--<div class="row">--%>
                                                 <div class="col-sm-12 text-left">
                                                       <div class="form-group">   
                                                           <div runat="server" id="UploadedFiles" style="overflow:scroll"    >                                          
                                                                 <div class="table-responsive" style="width:100%" >

                                                                        <asp:GridView ID="gvImages" runat="server" class="table table-responsive table-lg table-bordered" DataKeyNames="Path,FileId" AutoGenerateColumns="False" OnRowDeleting="gvImages_RowDeleting">
                                                                            <Columns>
        
                                                                                <asp:BoundField DataField="FileName" HeaderText="Name" />
      
     
                                                                          <asp:TemplateField HeaderText="FilePath">
                                                                        <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        <div id="dialog" style="display: none">
                                                                        </div>
                                                                 </div>
                                                           </div>
                                                     </div>
                                     
                                                 </div>
                                                 <%--</div>--%>
                                               <%-- <div class="row">--%>
                                                   <div class="col-sm-12 text-left" runat="server" visible="false">
                                              <div class="form-group">  
                                    
                                                 <div runat="server" id="Div1" style="overflow:scroll"    >                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvNoteIngrid" runat="server" AutoGenerateColumns="false"
                                                class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                AllowPaging="True" BackColor="White" 
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                                OnPageIndexChanging="GvNoteIngrid_PageIndexChanging">
                                                <Columns>
                                       
                                                    <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                                    <asp:BoundField DataField="DrName" HeaderText="Doctor"  />
                                                    <asp:BoundField DataField="Note" ItemStyle-Width="80%" HeaderText="Note"  />
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
            <div id="Div2" style="display: none">
            </div>
                 </div>

                                         
                                                 </div>
                                                    <asp:Button ID="btnnotedetails" runat="server" Text="Details" />
                                               </div>
                                 
                                             </div>

                                              <%-- </div>--%>

                                           
                                
                                
                                        </div>
                             
                                               
                                           </div>

                                            <div id="Div3" class="row" runat="server" visible="false">
                                                <div class="col-lg-12 form-group mt-3">
                                                    <label for="divPastHistory"><b>Past History</b></label>
                                                     <asp:Button ID="btnPastHis" runat="server" Text="+" />
                                                     <asp:ImageButton ID="btnPastHis_light" Visible="false"  class="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                                    <div id="divPastHistory">
                                                        <asp:CheckBoxList ID="radioPast" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
                                                 
                                                        </asp:CheckBoxList>
                                                    </div>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPastHistory" />
                                                </div>
                                            </div>
                                            <div id="Div4" class="row" runat="server" visible="false">
                                                <div class="col-lg-12 form-group mt-3">
                                                    <label for="divPersonalHistory"><b>Personal History</b></label>
                                                   <asp:Button ID="btnPersHis" runat="server" Text="+" />
                                                      <asp:ImageButton ID="btnPersHis_light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                                    <div id="divPersonalHistory">
                                                        <asp:CheckBoxList ID="radioPersonal" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"></asp:CheckBoxList>
                                                    </div>
                                                     <asp:TextBox runat="server" CssClass="form-control" ID="txtPersonalHistory" />
                                                   <%-- <input type="text" class="form-control" placeholder="Others(if any)" id="txtPersonalHistory" />--%>
                                                </div>
                                            </div>
                                            <div id="Div5" class="row" runat="server" visible="false">
                                                <div class="col-lg-12 form-group mt-3">
                                                    <label for="divFamilyHistory"><b>Family History</b></label>
                                                     <asp:Button ID="btnFamHis" runat="server" Text="+" />
                                                      <asp:ImageButton ID="btnFamHis_light" Visible="false"  CssClass="flashingTextcss" ImageUrl="~/images/light-311119__340.png" runat="server"></asp:ImageButton>

                                                    <div id="divFamilyHistory">
                                                        <asp:CheckBoxList ID="radioFamily" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server"></asp:CheckBoxList>
                                                    </div>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFamilyHistory" />
                                                   <%-- <input type="text" class="form-control" placeholder="Others(if any)" id="txtFamilyHistory" />--%>
                                                </div>
                                            </div>


                                           </div>
                                 </div>
                                 </div>
                             <div class="row" >
                                    <div class="col-lg-12 text-center mt-3">
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                             <div class="row" style="display:none;">
                            <div class="col-lg-12 mt-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvTempTable" runat="server" AutoGenerateColumns="True"
                                            class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                            AllowPaging="True" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                            OnRowCommand="gvTempTable_RowCommand" OnRowDeleting="gvTempTable_RowDeleting" OnRowEditing="gvTempTable_RowEditing"
                                            OnPageIndexChanging="gvTempTable_PageIndexChanging">
                                            <Columns>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                           <%--  </div>--%>
                             
                            </div>
                  </div>
                   
            </section>


             <asp:ModalPopupExtender ID="MPN" runat="server" PopupControlID="NotePanel" TargetControlID="btnNote"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>
             <asp:ModalPopupExtender ID="MPND" runat="server" PopupControlID="NotePanel" TargetControlID="btnnotedetails"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>
            <asp:Panel ID="NotePanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <div class="header">
                               Note
                            </div>
                            <div class="body">
                                <asp:GridView ID="GVNote" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="GVNote_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="GVNote_RowCommand" OnRowEditing="GVNote_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="GVNote_PageIndexChanging">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                        <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="Note" ItemStyle-Width="80%" HeaderText="Note"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Close" />
            </asp:Panel>

            <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="CheifPanel" TargetControlID="btnChief1"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="CheifPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Chief Complaints
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                        <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="chiefcomplaints" ItemStyle-Width="80%" HeaderText="Complaints"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM1" runat="server" Text="Close" />
            </asp:Panel>

            <asp:ModalPopupExtender ID="mp2" runat="server" PopupControlID="AllergyPanel" TargetControlID="btnAllergy"
                CancelControlID="btnCloseM2" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="AllergyPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM2">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Allergies
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvAllergy" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gdvAllergy_PageIndexChanging">
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                        <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="allergies" ItemStyle-Width="80%" HeaderText="allergies"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM2" runat="server" Text="Close" />
            </asp:Panel>


            <asp:ModalPopupExtender ID="mp4" runat="server" PopupControlID="VitalPanel" TargetControlID="btnVitals"
                CancelControlID="btnCloseM4" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="VitalPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM4">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Vitals
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvVital" runat="server" AutoGenerateColumns="True"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gdvVital_PageIndexChanging">
                                    <Columns>
                                        <%--<asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM4" runat="server" Text="Close" />
            </asp:Panel>

            <asp:ModalPopupExtender ID="mp3" runat="server" PopupControlID="MedicalPanel" TargetControlID="btnMedical"
                CancelControlID="btnCloseM3" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="MedicalPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM3">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Medical History
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvMedical" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gdvMedical_PageIndexChanging">
                                    <Columns>
                                        <%--<asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                        <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="medicalhistory" ItemStyle-Width="80%" HeaderText="Medical history"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM3" runat="server" Text="Close" />
            </asp:Panel>

            <asp:ModalPopupExtender ID="mp5" runat="server" PopupControlID="PastPanel" TargetControlID="btnPastHis"
                CancelControlID="btnCloseM5" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="PastPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM5">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Past History
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvPastHis" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    >
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                          <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="pastHistory" ItemStyle-Width="80%" HeaderText="Past history"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM5" runat="server" Text="Close" />
            </asp:Panel>

            <asp:ModalPopupExtender ID="mp6" runat="server" PopupControlID="PersonalPanel" TargetControlID="btnPersHis"
                CancelControlID="btnCloseM6" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="PersonalPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM6">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Personal History
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvPers" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gdvPers_PageIndexChanging"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    >
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                         <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="personalHistory" ItemStyle-Width="80%" HeaderText="Personal history"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM6" runat="server" Text="Close" />
            </asp:Panel>
            
            <asp:ModalPopupExtender ID="mp7" runat="server" PopupControlID="FamilyPanel" TargetControlID="btnFamHis"
                CancelControlID="btnCloseM7" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="FamilyPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM7">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Family History
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvFam" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId" OnPageIndexChanging="gdvFam_PageIndexChanging"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    >
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                         <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                         <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="familyHistory" ItemStyle-Width="80%" HeaderText="Family history"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM7" runat="server" Text="Close" />
            </asp:Panel>

            <asp:ModalPopupExtender ID="mp8" runat="server" PopupControlID="SurgeryPanel" TargetControlID="btnSurgical"
                CancelControlID="btnCloseM8" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="SurgeryPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM8">
                <div>
                    <asp:UpdatePanel ID="SurgeryPanel33" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Surgery History
                            </div>
                            <div class="body">
                                <asp:GridView ID="gdvSurgery" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId" OnPageIndexChanging="gdvSurgery_PageIndexChanging"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                    >
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                         <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                         <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="surgicalhistory" ItemStyle-Width="80%" HeaderText="Surgical history"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM8" runat="server" Text="Close" />
            </asp:Panel>


     <asp:ModalPopupExtender ID="MPdiagno" runat="server" PopupControlID="Diagnosis" TargetControlID="btnDiagno"
                CancelControlID="btnCloseDia" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>
     <asp:Panel ID="Diagnosis" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseDia">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Diagnosis
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvDiagno" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDiagno_PageIndexChanging"
                                    >
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                          <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="Diagnosis" ItemStyle-Width="80%" HeaderText="Diagnosis"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseDia" runat="server" Text="Close" />
            </asp:Panel>
     <asp:ModalPopupExtender ID="MPPdiagno" runat="server" PopupControlID="ProvisionalDiagno" TargetControlID="btnProvDiagno"
                CancelControlID="btnClosePD" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>
     <asp:Panel ID="ProvisionalDiagno" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnClosePD">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <div class="header">
                               Provisional Diagnosis
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvProvDiagno" runat="server" AutoGenerateColumns="false" 
                                    class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="EmrId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                    AllowPaging="True" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvProvDiagno_PageIndexChanging"
                                    >
                                    <Columns>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="#" ItemStyle-Width="50" Visible="true" />
                                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="Details" HeaderText="Details" Visible="true" />--%>
                                        <asp:BoundField DataField="opd" HeaderText="Opd No"  />
                                         <asp:BoundField DataField="updatedon" HeaderText="Date"  />
                                        <asp:BoundField DataField="ProvisionalDiagnosis" ItemStyle-Width="80%" HeaderText="Provisional Diagnosis"  />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#B24592" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnClosePD" runat="server" Text="Close" />
            </asp:Panel>


        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>


    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-ui.min.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
     <script src="plugins/Emergency.js"></script>
        <script>
            $(document).ready(function () {
                var speed = 500;
                function effectFadeIn(classname) {
                    $("." + classname).fadeOut(speed).fadeIn(speed, effectFadeOut(classname))
                }
                function effectFadeOut(classname) {
                    $("." + classname).fadeIn(speed).fadeOut(speed, effectFadeIn(classname))
                }
                //Calling fuction on pageload
                $(document).ready(function () {
                    effectFadeIn('flashingTextcss');
                });
            });
  </script>
</asp:Content>

