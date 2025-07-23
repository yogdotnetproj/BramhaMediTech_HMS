<%@ Page Title="OT Template" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="PreOperativeOrder.aspx.cs" Inherits="PreOperativeOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <h1>General EMR</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="ckeditor/ckeditor.js"></script>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
           <section class="content-header d-flex">
                    <h1>Pre Operative Orders</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Pre Operative Orders</li>
                    </ol>
                </section>

            <section class="content">
                <div class="box" runat="server">
                    
                      <div class="box-body">
                        <%-- <div class="row">--%>
                                <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                         Diagnosis
                                          </div>
                                           </div>

                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                           <asp:TextBox runat="server" ID="txtDiagnosis" CssClass="form-control"  placeholder="Enter Diagnosis"  />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                         ECG Obtained
                                          </div>
                                           </div>

                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                            <asp:DropDownList ID="ddlECGObtained"  CssClass="form-control form-select"  runat="server" ></asp:DropDownList>
                                          </div>
                                           </div>
                                     </div>
                                    </div>
                           <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                         Procedure
                                          </div>
                                           </div>

                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                           <asp:TextBox runat="server" ID="txtProcedure" CssClass="form-control"  placeholder="Enter Procedure"  />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                        Pre Anaesthetic Checkup
                                          </div>
                                           </div>

                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                            <asp:DropDownList ID="ddlPreAnaesthetic"  CssClass="form-control form-select"  runat="server" ></asp:DropDownList>
                                          </div>
                                           </div>
                                     </div>
                                    </div>

                           <div class="col-lg-12 mt-2">
                               <strong>Labs:</strong> 
                                 <div class="row">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkMinorSurgeryPanel" Text="&nbsp; Minor Surgery Panel" />
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkMajorSurgeryPanel" Text="&nbsp; Major Surgery Panel" />
                                          </div>
                                           </div>
                                      
                                     </div>
                               <div class="row mt-2">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:CheckBox runat="server" ID="ChkLapCholePanel" Text="&nbsp; Lap Chole Panel" />
                                          </div>
                                           </div>
                                      <div class="col-sm-10" >
                                             <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtLapCholePanel" CssClass="form-control"  placeholder=""  />
                                          </div>
                                           </div>
                                      
                                     </div>
                               <div class="row mt-2">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                        CXR Findings
                                          </div>
                                           </div>
                                      <div class="col-sm-10" >
                                             <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtCXRFindings" CssClass="form-control"  placeholder=""  />
                                          </div>
                                           </div>
                                      
                                     </div>
                               </div>
                           <div class="col-lg-12 mt-2">
                               <strong>Plan:</strong> 
                                 <div class="row">
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                         1.Diet:NPO after
                                          </div>
                                           </div>
                                      <div class="col-sm-1" >
                                             <div class="form-group">
                                        <asp:TextBox runat="server" ID="txtnpoafter" CssClass="form-control"  placeholder=""  />
                                          </div>
                                           </div>
                                      
                                    
                                     </div>
                                <div class="row mt-2">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                           2.Informed Written consent.
                                          </div>
                                           </div>
                                      
                                    
                                     </div>
                                <div class="row mt-2">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                        3. Pre Operative Antibiotic
                                          </div>
                                           </div>
                                      <div class="col-sm-6" >
                                             <div class="form-group">
                                          <asp:TextBox runat="server" ID="txtPreOpratAntibiotic" CssClass="form-control" TextMode="MultiLine"  placeholder=""  />
                                          </div>
                                           </div>
                                     
                                     <div class="col-sm-3" >
                                             <div class="form-group">
                                          before shifting pt to operation theatre
                                          </div>
                                           </div>
                                    
                                     </div>
                                <div class="row mt-2">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                        4. Bowel Prep
                                          </div>
                                           </div>
                                      <div class="col-sm-4" >
                                             <div class="form-group">
                                          <asp:DropDownList ID="ddlBowelPrep"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                               <asp:ListItem Value="Bowl Wash"></asp:ListItem>
                                               <asp:ListItem Value="Laxative"></asp:ListItem>
                                               <asp:ListItem Value="Nothing"></asp:ListItem>
                                               <asp:ListItem Value="Enema"></asp:ListItem>
                                        </asp:DropDownList>
                                          </div>
                                           </div>
                                     
                                     </div>
                               <div class="row mt-2">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                        5. OR Schedule:Pt is tentatively scheduled for
                                          </div>
                                           </div>
                                      <div class="col-sm-1" >
                                             <div class="form-group">
                                        <asp:TextBox runat="server" ID="txttime" CssClass="form-control"  placeholder=""  />
                                          </div>
                                           </div>:
                                    <div class="col-sm-1" >
                                             <div class="form-group">
                                        <asp:TextBox runat="server" ID="txttime1" CssClass="form-control"  placeholder=""  />
                                          </div>
                                           </div>
                                    <div class="col-sm-1" >
                                             <div class="form-group">
                                          <asp:DropDownList ID="ddlAmPm"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                               <asp:ListItem Value="AM"></asp:ListItem>
                                               <asp:ListItem Value="PM"></asp:ListItem>
                                               
                                        </asp:DropDownList>
                                          </div>
                                           </div>
                                       <div class="col-sm-1" >
                                             <div class="form-group">
                                       on date
                                          </div>
                                           </div>
                                    <div class="col-sm-2" >
                                            <div class="form-group">
                                               <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdateofoperation" runat="server"   CssClass="form-control"  
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                </div>
                                              </div> 
                                     </div>

                               <div class="row mt-2">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                        6. Catheterization before surgery
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:DropDownList ID="ddlCatheterization"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                               <asp:ListItem Value="Yes"></asp:ListItem>
                                               <asp:ListItem Value="No"></asp:ListItem>                                               
                                        </asp:DropDownList>
                                          </div>
                                           </div>
                                     
                                     </div>
                                <div class="row mt-2">
                                      <div class="col-sm-3" >
                                             <div class="form-group">
                                        7. Parts Preparation
                                          </div>
                                           </div>
                                      <div class="col-sm-2" >
                                             <div class="form-group">
                                          <asp:DropDownList ID="ddlPartsPreparation"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                               <asp:ListItem Value="Yes"></asp:ListItem>
                                               <asp:ListItem Value="No"></asp:ListItem>                                               
                                        </asp:DropDownList>
                                          </div>
                                           </div>
                                     
                                     </div>
                               </div>
                          <div class="col-lg-12 mt-2">
                              
                                 <div class="row">
                                      <div class="col-sm-6" >
                                             <div class="form-group">
                                           <asp:TextBox runat="server" ID="txtnotes" CssClass="form-control" Height="175px" TextMode="MultiLine"  placeholder="Notes"  />
                                          </div>
                                           </div>
                                      <div class="col-sm-6" >
                                             <div class="form-group">
                                         
                                          </div>
                                           </div>
                                    
                                     </div>
                              </div>

                           
                           
                       
                             <div class="row mt-3 mb-3" >
                                    <div class="col-lg-12 text-center" >
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Text="Report" OnClick="btnClear_Click" />
                                         <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                    </div>
                                </div>

                           
                            
                           <%--  </div>--%>
                             
                            </div>
                  </div>
                   
            </section>


            


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

