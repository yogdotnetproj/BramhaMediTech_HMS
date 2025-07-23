<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMaster.master" AutoEventWireup="true" CodeFile="Gynology_Antenatal.aspx.cs" Inherits="Gynology_Antenatal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
       <asp:HiddenField ID="hfPatientId" runat="server" />
     <asp:HiddenField ID="hfDoctorId" runat="server" />
     <asp:HiddenField ID="hrConsDoctorId" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
         <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
         <ContentTemplate>
     <section class="content-header d-flex">
        <h1> ANTENATAL CARD </h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active"> ANTENATAL CARD</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
           <!-- <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
              
                 
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
                 
                 <div class="row">
                     <div class="col-lg-2  text-left">
                         
               <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 pl-0">
                                    <div class="form-group">
                           <asp:Button ID="btnAddTemplate"  Text="+ Template" runat="server"  class="btn btn-success" OnClick="btnAddTemplate_Click" />
                                        </div>
                             </div> 
                        <div class="col-lg-4 ">
                                    <div class="form-group">
                           <asp:Button ID="btnDelTemplate"  Text="Delete" class="btn btn-danger"  runat="server" OnClick="btnDelTemplate_Click" />
                              </div>
                            </div>
                        </div>
                    </div> 
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 pl-0">
                                    <div class="form-group">
                           <asp:Button ID="btnCaseSheet"  Text="+ Case Sheet" runat="server"  class="btn btn-primary" OnClick="btnCaseSheet_Click"  />
                                        </div>
                             </div> 
                        <div class="col-lg-4 ">
                                    <div class="form-group">
                           <asp:Button ID="btnCaseSheetDel"  Text="Delete" class="btn btn-warning"  runat="server" OnClick="btnCaseSheetDel_Click" />
                              </div>
                            </div>
                        </div>
                    </div> 
                           
                             <div class="col-lg-12 mt-2 border border-2">
                    <div class="row">
                         
           
                        
                             <ul class="metismenu template-sidemenu" >
                                 <span class="nav-label"><strong> Case Sheet</strong></span>
                   <%-- <li>
                        <a class="active" href="Home.aspx"><i class="sidebar-item-icon fa fa-th-large"></i>
                            <span class="nav-label">Case Sheet</span>
                        </a>
                    </li>--%>
                    <asp:PlaceHolder ID="SlidBarHolder" runat="server"></asp:PlaceHolder>
                </ul>   
                        </div>     
                      </div>    
                      </div>
                      <div class="col-lg-8 mt-2">
                        <div class="panel-heading">
                                  ANTINATAL CARD |  
                     </div>


                       <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Gravida
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       <asp:TextBox ID="txtGravida" CssClass="form-control"  runat="server" placeholder="Gravida" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Para
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       <asp:TextBox ID="txtPara" CssClass="form-control"  runat="server" placeholder="Para" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                       LMP
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtLMP" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        
                                    </div>
                                </div>
                          
                    </div>

                </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Due Date
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdueDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Risk Factors
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                       <asp:TextBox ID="txtRiskFactor" CssClass="form-control"  runat="server" placeholder="  Risk Factors" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        </div>
                      </div>

                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Allergies
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAllergies" CssClass="form-control"  runat="server" placeholder="Enter Allergies" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Ethinicity
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlEthinicity"  CssClass="form-control form-select"  runat="server" >
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                         
                        </div>
                      </div>
                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       Significant Family History
                                        
                                    </div>
                                </div>
                        <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtSignificantFamilyHis" CssClass="form-control"  runat="server" placeholder="Enter Significant Family History" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       Level of Education
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlLevelOfEdu"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Primary">Primary</asp:ListItem>
                                            <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                                          <asp:ListItem Value="Tertiary">Tertiary</asp:ListItem>
                                            <asp:ListItem Value="Not Applicable">Not Applicable</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                         
                        </div>
                      </div>
                  <div class="panel-heading mt-3">
                                 Investigations |    
                     </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      HB
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtHB" CssClass="form-control"  runat="server" placeholder="Enter HB" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      Grp/Rh
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtgrp" CssClass="form-control"  runat="server" placeholder="Enter Grp/Rh" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     RBS
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtRBS" CssClass="form-control"  runat="server" placeholder="Enter RBS" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     RPR
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlRPR"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Reactive">Reactive</asp:ListItem>
                                            <asp:ListItem Value="Non Reactive">Non Reactive</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        </div>
                      </div>
                 
                        <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     HIV 1
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:DropDownList ID="ddlHiv1"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                          <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     HIV 2
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlHiv2"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                          <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                    HBsAg
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlHBsAg"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Primary">Primary</asp:ListItem>
                                            <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     Sickling
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlSickling"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                             <asp:ListItem Value="Reactive">Reactive</asp:ListItem>
                                            <asp:ListItem Value="Non Reactive">Non Reactive</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                        </div>
                      </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      1 hr after 50 gms of Glucose
                                        
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txthrafterGlu" CssClass="form-control"  runat="server" placeholder="Enter 1 hr after 50 gms of Glucose" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                    OGTT
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       <asp:TextBox ID="txtOGTT" CssClass="form-control"  runat="server" placeholder="Enter OGTT" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                    Hep C
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:DropDownList ID="ddlHepC"  CssClass="form-control form-select"  runat="server" >
                                           <asp:ListItem Value=""></asp:ListItem>
                                             <asp:ListItem Value="Positive">Positive</asp:ListItem>
                                            <asp:ListItem Value="Negative">Negative</asp:ListItem>
                                          <asp:ListItem Value="Not Done">Not Done</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                       
                        </div>
                      </div>
                 <div class="panel-heading mt-3">
                                 1 st Ultrasound | 
                     </div>
                   <div class="col-lg-12 mt-2">
                    <div class="row">
                 <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                       Date
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtultraDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        
                                    </div>
                                </div>
                 <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                       Finding
                                        
                                    </div>
                                </div>
                 <div class="col-lg-7 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtUltraFinding" CssClass="form-control"  TextMode="MultiLine" runat="server" placeholder="Enter Ultrasound Finding" ></asp:TextBox>
                                        </div>
                     </div>
                        </div>
                       </div>
                  <div class="panel-heading mt-3">
                                 Subsequent Ultrasounds | 
                     </div>
                   <div class="col-lg-12 mt-2">
                    <div class="row">
                 <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                       Date
                                        
                                    </div>
                                </div>
                          
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtsubDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        
                                    </div>
                                </div>
                 <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                       Finding
                                        
                                    </div>
                                </div>
                 <div class="col-lg-7 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtSubUltraFinding" CssClass="form-control" TextMode="MultiLine"  runat="server" placeholder="Enter Subsequent Ultrasounds Finding" ></asp:TextBox>
                                        </div>
                     </div>
                        </div>
                       </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                 <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btnClinicalDet" Text="Clinical Details" CssClass="btn btn-primary" OnClick="btnClinicalDet_Click" />
                                        </div>
                     </div>
                         <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btnInvistigation" Text="Investigations" CssClass="btn btn-success" OnClick="btnInvistigation_Click" />
                                        </div>
                     </div>
                        <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btnOtherdet" Text="Others" CssClass="btn btn-warning" OnClick="btnOtherdet_Click" />
                                        </div>
                     </div>
                        <div class="col-lg-2 text-center">
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btnNeoEntry" Text="Neo-Entry" CssClass="btn btn-primary" OnClick="btnNeoEntry_Click" />
                                        </div>
                     </div>
                        </div>
                      </div>
                  <div class="col-lg-12 mt-2" runat="server" id="NeoEntry" visible="false">
                      <div class="col-lg-12 mt-2">
                    <div class="row">
                 <div class="col-lg-2 text-left">
                      <div class="form-group">
                     Delivery Date
                          </div>
                     </div>
                         <div class="col-lg-2 text-center">
                              <div class="form-group">
                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdeleiveryDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                  </div>
                     </div>
                         <div class="col-lg-2 text-center">
                              <div class="form-group">
                   Mode Of Delivery
                                  </div>
                     </div>
                        <div class="col-lg-3 text-center">
                            <div class="form-group">
                        <asp:TextBox ID="txtModeOfDelivery" CssClass="form-control"  runat="server" placeholder="Enter Mode Of Delivery" ></asp:TextBox>
                        </div>
                            </div>
                      </div>
                          </div>

                       <div class="col-lg-12 mt-2">
                    <div class="row">
                 <div class="col-lg-2 text-left">
                      <div class="form-group">
                     Birth Weight of Baby
                          </div>
                     </div>
                         <div class="col-lg-2 text-center">
                      <div class="form-group">
                           <asp:TextBox ID="txtbabyweight" CssClass="form-control"  runat="server" placeholder="Weight" ></asp:TextBox>

                          </div>
                             </div>
                           <div class="col-lg-2 text-left">
                      <div class="form-group">
                       <strong>(Kg)</strong>   
                          </div>
                               </div>
                        </div>
                           </div>
                      </div>
                 <%----//==============================================================================--%>
              
               <div class="col-lg-12 mt-2" runat="server" id="Investigation" visible="false">
                     
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                 <asp:gridview ID="GVFOL_LICULAR" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Investigation Date" >

            <ItemTemplate>

               
                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtInvDate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

      
        <asp:TemplateField HeaderText="Investigation Details">

            <ItemTemplate>

                 <asp:TextBox ID="txtInVDetails" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>
                        </div>
                           </div>   
                   </div>

                           <div class="col-lg-12 mt-2" runat="server" id="ClincDet" visible="false">
                     
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                 <asp:gridview ID="GVClinicalDetails" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Clinical Date" >

            <ItemTemplate>
                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtClinDate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Right" />
             <HeaderStyle Width="150px" HorizontalAlign="Right" />
        </asp:TemplateField>

      
        <asp:TemplateField HeaderText="Clinical Details">

            <ItemTemplate>

                 <asp:TextBox ID="txtClinDetails" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAddC" runat="server" Text="Add New Row" OnClick="ButtonAddC_Click" />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>
                        </div>
                           </div>   
                   </div>

                            <div class="col-lg-12 mt-2" runat="server" id="OthDetails" visible="false">
                     
                       <div class="col-lg-12 mt-2">
                    <div class="row"> 
                        <div class="table-responsive" style="width: 1400px;height:200px">
                 <asp:gridview ID="GVOthDetails" runat="server" ShowFooter="true" Width="1500px" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

               
                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtOthDate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
            </ItemTemplate>
            <ItemStyle Width="550px" HorizontalAlign="Right" />
             <HeaderStyle Width="550px" HorizontalAlign="Right" />
             <HeaderStyle HorizontalAlign="Right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="P.O.G" >
            <ItemTemplate>
                <asp:TextBox ID="txtPOG" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>        
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />   
        </asp:TemplateField>

             <asp:TemplateField HeaderText="S.F.H" >
            <ItemTemplate>
                <asp:TextBox ID="txtSFH" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>     
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />      
        </asp:TemplateField>

             <asp:TemplateField HeaderText="P.P/LIE" >
            <ItemTemplate>
                <asp:TextBox ID="txtPPLIE" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>    
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />       
        </asp:TemplateField>

             <asp:TemplateField HeaderText="FetalHeartBeat/Min" >
            <ItemTemplate>
                <asp:TextBox ID="txtFetalHeartBeat" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>         
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />  
        </asp:TemplateField>

             <asp:TemplateField HeaderText="B.P" >
            <ItemTemplate>
                <asp:TextBox ID="txtBP" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>      
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />   
                  <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAddoth" runat="server" Text="Add New Row" OnClick="ButtonAddoth_Click" />

            </FooterTemplate>  
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Urin Chem" >
            <ItemTemplate>
                <asp:TextBox ID="txtUrinChem" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate> 
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />          
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Weight LBS" >
            <ItemTemplate>
                <asp:TextBox ID="txtWeightLBS" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate> 
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />          
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Investigations" >
            <ItemTemplate>
                <asp:TextBox ID="txtInvestigations" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>    
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />       
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Medications" >
            <ItemTemplate>
                <asp:TextBox ID="txtMedications" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>       
                 <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" />    
        </asp:TemplateField>

      
        <asp:TemplateField HeaderText="Advice">

            <ItemTemplate>

                 <asp:TextBox ID="txtAdvice" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>

            <ItemStyle Width="350px" HorizontalAlign="Right" />
             <HeaderStyle Width="350px" HorizontalAlign="Right" /> 

        </asp:TemplateField>

        </Columns>

</asp:gridview>
                            </div>
                        </div>
                           </div>   
                   </div>

                </div>
                      <div class="col-lg-2 mt-2">
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                       Inj TT.5ML
                                        
                                    </div>
                                </div>
                        </div>
                               </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                       
                                     <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtinjTT" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        
                                    </div>
                                </div>
                        </div>
                               </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                          <asp:TextBox ID="txtnotes" Height="550px" CssClass="form-control"  TextMode="MultiLine" runat="server" placeholder="Enter Notes" ></asp:TextBox>
                          </div>
                                   </div>
                          </div>
                     </div>
                 
                 
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" />
                                        <asp:Button ID="BtnBirthRegister" runat="server" class="btn btn-primary btnSearch" Text="+" />
                                        <asp:Button ID="btnreport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreport_Click" />
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>
            </div>
            
          
        </div>
           
    </section>
     <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="CheifPanel" TargetControlID="BtnBirthRegister"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="CheifPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="header">
                              Antenatal:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Hid"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="PatientAdult" HeaderText="LMP"  />
                                        
                                        <asp:BoundField DataField="MTCTPluse" HeaderText="PRP"  />
                                        <asp:BoundField DataField="Married" HeaderText="Semen Analysis"  />
                                         <asp:BoundField DataField="DiscloseToHubby" HeaderText="Trial Transfer "  />
                                         <asp:BoundField DataField="Divorced" HeaderText="Hysteroscopy Findings "  />
                                          <asp:BoundField DataField="HIVTheraphy" HeaderText="D Lap"  />
                                          <asp:BoundField DataField="NumberofChildren" HeaderText=" Notes"  />
                                         
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  />
                                       <%-- <asp:BoundField DataField="chiefcomplaints" ItemStyle-Width="80%" HeaderText="Complaints"  />--%>
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
                <asp:Button ID="btnCloseM1" runat="server" Text="Close" />
            </asp:Panel>
              <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="AddTemp" TargetControlID="btnAddTemplate"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="AddTemp" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Add Template
                            </div>
                          <div class="col-lg-8 text-left">
                            <div class="form-group" style="width:300px" >
                               <asp:CheckBoxList ID="Chkmaintestshort"   type="checkbox" CssClass="BigCheckBox" Font-Bold="true" Font-Size="Large" Font-Italic="true"  RepeatDirection="Vertical" name="CheckBoxInputName" runat="server"   Width="100%" AutoPostBack="false" OnSelectedIndexChanged="Chkmaintestshort_SelectedIndexChanged">
                        </asp:CheckBoxList>
                            </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btnAddT_Click" class="btn btn-primary" />
            </asp:Panel>

               <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel15" TargetControlID="btnDelTemplate"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel15" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Add Template
                            </div>  
                            <div class="col-lg-8 text-left">
                            <div class="form-group" style="width:300px" >
                              <asp:CheckBoxList ID="ChkDelTemplate"   type="checkbox" CssClass="BigCheckBox" Font-Bold="true" Font-Size="Large" Font-Italic="true"  RepeatDirection="Vertical" name="CheckBoxInputName" runat="server"   Width="100%" AutoPostBack="false" OnSelectedIndexChanged="ChkDelTemplate_SelectedIndexChanged"  >
                        </asp:CheckBoxList>
                            </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 <asp:Button ID="btnDelT" runat="server" Text="Delete Template" OnClick="btnDelT_Click" class="btn btn-danger" />
            </asp:Panel>

              <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel16" TargetControlID="btnCaseSheetDel"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="Panel16" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Add Template
                            </div>  
                            <div class="col-lg-10 text-left">
                            <div class="form-group" style="width:400px" >
                              <asp:CheckBoxList ID="ChkCaseSheet"   type="checkbox" CssClass="BigCheckBox" Font-Bold="true" Font-Size="Large" Font-Italic="true"  RepeatDirection="Vertical" name="CheckBoxInputName" runat="server"   Width="100%" AutoPostBack="false" OnSelectedIndexChanged="ChkCaseSheet_SelectedIndexChanged"  >
                        </asp:CheckBoxList>
                            </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                 <asp:Button ID="btndelcasesheet" runat="server" Text="Delete Case Sheet" OnClick="btnDelT_Click" class="btn btn-danger" />
            </asp:Panel>
             </ContentTemplate>
         </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function OpenReport() {
            window.open("Reports.aspx");
        }
        </script>
</asp:Content>
