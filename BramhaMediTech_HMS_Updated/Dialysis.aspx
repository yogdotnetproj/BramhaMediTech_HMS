<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="Dialysis.aspx.cs" Inherits="Dialysis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
     <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript">

        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
            </Triggers>
         <ContentTemplate>
     <section class="content-header d-flex">
        <h1>Dialysis</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Dialysis</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
             <div class="box-body">
                
                      


                <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>     
                   <div class="col-lg-12 text-left" runat="server" id="listt1" visible="false">
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
                                <div id="Div7" class="col-lg-2 text-left" runat="server" visible="false">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left" id="Div8" runat="server" >
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
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
                             
                       
                            <div class="col-lg-12 text-left" runat="server" id="listt2" visible="false">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="" style="text-align: left">Consultant:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left" >
                                    <div class="form-group">
                                        <label for="lblDept" title="" style="text-align: left">Dept:</label>
                                        <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="col-lg-2 text-left"  >
                                    <div class="form-group">
                                        <label for="lblToken" title="" style="text-align: left">Token No:</label>
                                        <asp:Label ID="lblToken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                               
                                 <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblVisitingNo"   title="" style="text-align: left">Visit No:</label>
                                        <asp:Label ID="lblVisitingNo" runat="server" Text=" "></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
                         <div style="height:2px; background:#B24592;"> </div>
                    </div>          
             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Date</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtDate" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Type</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       <asp:DropDownList ID="ddlType"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           <asp:ListItem Value="Haemodialysis">Haemodialysis</asp:ListItem>
                                         <asp:ListItem Value="Isolated UF">Isolated UF</asp:ListItem>
                                            <asp:ListItem Value="Sequential UF">Sequential UF</asp:ListItem>
                                            <asp:ListItem Value="Haemofiltration">Haemofiltration</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                              </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Technician</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtTechnician" placeholder="" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                        </div>
                     </div>
                 <div class="col-lg-12 mt-2">
                     <strong>Indication:</strong>
                    <div class="row">
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkPulmonary" Text="Pulmonary Oedema" />
                                 </div>
                            </div>
                         <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkHypercalcemia" Text="Hypercalcemia" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkFluidOverload" Text="Fluid Overload" />
                                 </div>
                            </div>
                        <div class="col-lg-3 text-left">
                             <div class="form-group">
                                 <asp:CheckBox runat="server" ID="ChkEncephalopathy" Text="Encephalopathy" />
                                 </div>
                            </div>
                        </div>

                 </div>
                   <div class="col-lg-12 mt-2">
                   
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Access
                                 </div>
                            </div>
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:DropDownList ID="ddlAccess"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           <asp:ListItem Value="AVF">AVF</asp:ListItem>
                                         <asp:ListItem Value="DLIC">DLIC</asp:ListItem>
                                            <asp:ListItem Value="DLFC">DLFC</asp:ListItem>
                                            <asp:ListItem Value="DLSC">DLSC</asp:ListItem>
                                        </asp:DropDownList>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Dialyzer
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtDialyzer" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Reused
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:DropDownList ID="ddlReused"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           <asp:ListItem Value="No">No</asp:ListItem>
                                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                 </div>
                            </div>
                        </div>

                 </div>
                   <div class="col-lg-12 mt-2">
                   
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Duration
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtduration" placeholder="" CssClass="form-control"   runat="server" />
                                 
                                 </div>
                            </div>
                        
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                 Hrs.
                                 </div>
                             </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Heparin Dosage
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtHeparinDosage" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Blood Flow:(ml/hr)
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtBloodFlow" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        </div>

                 </div>

                   <div class="col-lg-12 mt-2">
                   
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 UF Removal
                                 </div>
                            </div>
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtUfRemoval" placeholder="" CssClass="form-control"   runat="server" />
                                 
                                 </div>
                            </div>
                        
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Weight PRE HD(Kgs)
                                 </div>
                             </div>
                       
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtweightPerHD" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 Post HD:(Kgs)
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtPostHD" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        </div>

                 </div>
                    <div class="col-lg-12 mt-2">
                   
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Time Started
                                 </div>
                            </div>
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtTimeStarted" placeholder="" CssClass="form-control"   runat="server" />
                                 
                                 </div>
                            </div>
                        
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Time Ended
                                 </div>
                             </div>
                       
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtTimeEnded" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Priming Fluid
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtPrimingFluid" placeholder="" CssClass="form-control"   runat="server" />
                                 </div>
                            </div>
                        </div>

                 </div>

                      <div class="col-lg-12 mt-2">
                   
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                Dialysate Flow(ml)
                                 </div>
                            </div>
                         <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <asp:TextBox ID="txtDialysateFlow" placeholder="" CssClass="form-control"   runat="server" />
                                 
                                 </div>
                            </div>
                        
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                               <asp:CheckBox runat="server" ID="chkBleeding" Text="Bleeding" />
                                 </div>
                             </div>
                       
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkHypotension" Text="Hypotension" />
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                              <asp:CheckBox runat="server" ID="ChkHypertension" Text="Hypertension" />
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkCramps" Text="Cramps" />
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                                   <asp:CheckBox runat="server" ID="ChkOther" Text="Others" />
                                 </div>
                            </div>
                        </div>

                 </div>


                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                                                  <asp:gridview ID="GvHairLaser" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Time" >

            <ItemTemplate>

                <asp:TextBox ID="txtTime" Text='<%# Eval("DialysisTime") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="BP" >

            <ItemTemplate>

                <asp:TextBox ID="txtBP" Text='<%# Eval("BP") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="PR" >

            <ItemTemplate>

                <asp:TextBox ID="txtPR" Text='<%# Eval("PR") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="TMP" >
            <ItemTemplate>
                <asp:TextBox ID="txtTMP" Text='<%# Eval("TMP") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="VP" >
            <ItemTemplate>
                <asp:TextBox ID="txtVP" Text='<%# Eval("VP") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Temperature" >
            <ItemTemplate>
                <asp:TextBox ID="txtTemperature" Text='<%# Eval("Temperature") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Medication" >
            <ItemTemplate>
                <asp:TextBox ID="txtMedication" Text='<%# Eval("Medication") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Remark" >
            <ItemTemplate>
                <asp:TextBox ID="txtRemark" Text='<%# Eval("Remark") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
           

             
           

        </Columns>

</asp:gridview>

                                 </div>
                            </div>
                         
                        </div>
                                  </div>
                             
                  <div class="col-lg-12 mt-3">
                <div class="row">
                    <strong>Cleaning Fluid</strong>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                             <asp:CheckBox runat="server" ID="ChkSaline" Text="Saline" />
                            </div>
                        </div>
                     <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       <asp:CheckBox runat="server" ID="ChkFormaline" Text="Formaline H2O2" />
                                        </div>
                              </div>
                    <div class="col-lg-2 text-left">
                        <div class="form-group">
                          <asp:CheckBox runat="server" ID="ChkHyperchloride" Text="Hyperchloride" />
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          Diagnisis
                            </div>
                        </div>
                    <div class="col-lg-6 text-left">
                        <div class="form-group">
                          <asp:TextBox ID="txtDiagnisis" placeholder="" CssClass="form-control" TextMode="MultiLine"   runat="server" />
                            </div>
                        </div>
                    
                    </div>
                      </div>

                   <div class="col-lg-12 mt-2">
                <div class="row">
                    <div class="col-lg-2 text-left">
                        <div class="form-group">
                         <strong> Complication During HD:</strong> 
                            </div>
                        </div>
                     <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtComplication" placeholder="" CssClass="form-control" TextMode="MultiLine"   runat="server" />
                                        </div>
                              </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                         Other Notes
                            </div>
                        </div>
                     <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtOtherNotes" placeholder="" CssClass="form-control"  TextMode="MultiLine"  runat="server" />
                                        </div>
                              </div>
                    </div>
                       </div>

                   <div class="col-lg-12 mt-2">
                <div class="row">
                    <div class="col-lg-2 text-left">
                        <div class="form-group">
                         <strong>Doctor Notes:</strong> 
                            </div>
                        </div>
                     <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtDoctorNotes" placeholder="" CssClass="form-control" TextMode="MultiLine"   runat="server" />
                                        </div>
                              </div>
                    </div>
                       </div>

                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server"  Text="Save" class="btn btn-success btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report"  class="btn btn-warning btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
              
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="OPDNo,IPDNo"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" 
                                    AllowPaging="True" BackColor="White"  
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="30" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing">
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                        <asp:BoundField DataField="Patregid" HeaderText="Reg No"  />
                                        
                                        <asp:BoundField DataField="OPDNo" HeaderText="OPD No"  />
                                         <asp:BoundField DataField="IPDNo" HeaderText="IPD No"  />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  />
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On "  />
                                         
                                     
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


