<%@ Page Title="" Language="C#" MasterPageFile="~/Opthalmology.master" AutoEventWireup="true" CodeFile="RefractiveWorkup.aspx.cs" Inherits="RefractiveWorkup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <script type="text/javascript">
          function ShowMessage(message, messagetype) {
              var cssclass;
              switch (messagetype) {
                  case 'Success':
                      cssclass = 'alert-success'
                      break;
                  case 'Error':
                      cssclass = 'alert-danger'
                      break;
                  case 'Warning':
                      cssclass = 'alert-warning'
                      break;
                  default:
                      cssclass = 'alert-info'
              }
              $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert p-2 in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

              setTimeout(function () {
                  $("#alert_div").fadeTo(1000, 500).slideUp(500, function () {
                      $("#alert_div").remove();
                  });
              }, 500);//5000=5 seconds
          }
    </script>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
         <asp:PostBackTrigger ControlID="btnPrescription" />
            <%--  <asp:PostBackTrigger ControlID="btnEditImage" />
          <asp:PostBackTrigger ControlID="btnCard" />--%>
          

        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Refractive Workup</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Refractive Workup</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">  

                            <div class="row">
                      <div class="col-lg-6  text-left">
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  1. AR</strong>
                                        
                                    </div>
                                </div>
                       
                                                 
                        </div>
                     </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Date</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEntryDate" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
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
                        <table id="T1" runat="server" width="100%">
                            <tr>
                                <td>
                                     <strong>  OD(RE)</strong>
                                </td>
                                <td>
                                     <strong>  SPH</strong>
                                </td>
                                <td>
                                     <strong>  CYL</strong>
                                </td>
                                <td>
                                     <strong>  AXIS</strong>
                                </td>
                                <td>
                                     <strong>  OS(LE)</strong>
                                </td>
                                 
                                <td>
                                     <strong>  SPH</strong>
                                </td>
                                <td>
                                     <strong>  CYL</strong>
                                </td>
                                <td>
                                     <strong>  AXIS</strong>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                     <strong>  For Distinct</strong>
                                </td>
                                <td>
                                     <asp:TextBox ID="txtsphARR"  placeholder="" CssClass="form-control"   runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCylArR"  placeholder="" CssClass="form-control"   runat="server" />
                                </td>
                                <td>
                                      <asp:TextBox ID="txtAxisARR"  placeholder="" CssClass="form-control"   runat="server" />
                                </td>
                                <td>
                                     <strong>  </strong>
                                </td>
                                 
                                <td>
                                    <asp:TextBox ID="txtsphARL"  placeholder="" CssClass="form-control"   runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCylArL"  placeholder="" CssClass="form-control"   runat="server" />
                                </td>
                                <td>
                                        <asp:TextBox ID="txtAxisARL"  placeholder="" CssClass="form-control"   runat="server" />
                                </td>
                            </tr>
                        </table>
                       

                        </div>
                              </div>

                           

                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Remark</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtRemarks"  placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  mm</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  D</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Deg</strong>
                                        
                                    </div>
                                </div>

                        </div>
                                 </div>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  R1</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtmm1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtD1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtdeg1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>

                        </div>
                                 </div>
                            <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  R2</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtmm2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtd2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtdeg2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>

                        </div>
                                 </div>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AVG</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtmm3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtd3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtdeg3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>

                        </div>
                                 </div>
                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtmm4"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtd4"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtdeg4"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>

                        </div>
                                 </div>


                             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  PD</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtPD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-center">
                                    <div class="form-group">
                                       
                                    <strong>  N</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtN"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>

                        </div>
                                 </div>


                          </div>
                                <div class="col-lg-6">
                                     <div class="col-lg-12 mt-2">
                    <div class="row">
                        
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Vision</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Distinct</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Near</strong>
                                        
                                    </div>
                                </div>
                        </div>
                                         </div>
                                      <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD</strong>
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OS</strong>
                                        
                                    </div>
                                </div>
                        </div>

                                             <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> UnAdded </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      
                                          <asp:TextBox ID="txtunaddesOD"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtUnaddesOd1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtUnaddedOd2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtUnaddedOd3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>

                                           <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> WithGlass </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      
                                          <asp:TextBox ID="txtWithGlass"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtWithGlass1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtWithGlass2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtWithGlass3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>

                                           <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> With Pinhole </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      
                                          <asp:TextBox ID="txtWithPinhole"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtWithPinhole1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtWithPinhole2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtWithPinhole3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>

                                           <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Best Correct </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      
                                          <asp:TextBox ID="txtBestCorrect"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtBestCorrect1"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtBestCorrect2"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtBestCorrect3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        </div>

                                           <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Notes </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                       
                                      
                                          <asp:TextBox ID="txtNotes"  placeholder="" CssClass="form-control" TextMode="MultiLine"   runat="server" />
                                    </div>
                                </div>
                         
                        </div>
                                          <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> IOP </strong>
                                        
                                    </div>
                                </div>
                                               <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        Instrument
                                        </div></div>
                         <div class="col-lg-8 text-left">
                                    <div class="form-group">
                                       
                                      
                                          <asp:TextBox ID="txtInstrument"  placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         
                        </div>

                                          <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  </strong>
                                        
                                    </div>
                                </div>
                                               <div class="col-lg-10 text-left">
                                    <div class="form-group">
                                        <table id="T2" runat="server" Width="100%">
                                            <tr>

                                                <td runat="server" visible="false">
                                                    Re Min
                                                </td>
                                                <td runat="server" visible="false">
                                                    Le Min
                                                </td>
                                                <td>
                                                    Antiglucin Medication
                                                </td>
                                            </tr>
                                             <tr>

                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtReMin1"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtLeMin1"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                                <td rowspan="4">
                                                    <asp:TextBox ID="txtMedication"  placeholder="" Height="130px" TextMode="MultiLine"  CssClass="form-control"   runat="server" />
                                                </td>
                                            </tr>
                                             <tr>

                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtReMin2"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtLeMin2"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                            </tr>
                                              <tr>

                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtReMin3"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtLeMin3"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                            </tr>
                                             <tr>

                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtReMin4"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                                <td runat="server" visible="false">
                                                   <asp:TextBox ID="txtLeMin4"  placeholder="" CssClass="form-control"   runat="server" />
                                                </td>
                                            </tr>

                                        </table>
                                        </div>
                                                   </div>
                                              </div>


                                         </div>

                                    </div>
                                </div>


                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  2.Undialeted AR</strong>
                                        
                                    </div>
                                </div>
                       
                                                 
                        </div>
                     </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD(RE)</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPH</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  VA</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Add</strong>
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OS(LE)</strong>
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPH</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  VA</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Add</strong>
                                        
                                    </div>
                                </div>    
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong> For Distinct</strong>
                                        
                                    </div>
                                </div>
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtSPHR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                    
                                         <asp:TextBox ID="txtCYLR"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtAXISR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtVAR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                           <asp:TextBox ID="txtAddR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>   
                        
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                        
                                    </div>
                                </div> 
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtSPHL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtCYLL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtAXISL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtVAL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAddL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div> 
                        </div>
                     </div>

                         <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  3.Dialeted AR</strong>
                                        
                                    </div>
                                </div>
                       
                                                 
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Medication Used</strong>
                                        
                                    </div>
                                </div>

                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtMedicationUsed"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Retnoscopy Working</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtRetnoscopyWorking"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                         
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  </strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  </strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPI</strong>
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                      
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Right</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtspl3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtcyl3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtaxis3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <strong>Left</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtspiL3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtcylL3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtAxisL3"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Retine</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtsplRet"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtcylret"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtaxixret"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <strong>Retine</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtsplretL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtcylretL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtaxisretlL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          
                        </div>
                     </div>



                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  4.Final Prescription</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Button  runat="server" ID="btnPrescription"  class="btn btn-warning" Text="Print" OnClick="btnPrescription_Click" />
                                        </div>
                           </div>
                                                 
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD(RE)</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPH</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  VA</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Add</strong>
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OS(LE)</strong>
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPH</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  VA</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Add</strong>
                                        
                                    </div>
                                </div>    
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong> For Distinct</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtSPHPR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                    
                                         <asp:TextBox ID="txtCYLPR"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtAXISPR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                          <asp:TextBox ID="txtVAPR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                           <asp:TextBox ID="txtAddPR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>  
                        
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtSPHPL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtCYLPL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtAXISPL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtVAPL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtaddPL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                              
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  5.Old Prescription</strong>
                                        
                                    </div>
                                </div>
                       
                                                 
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD(RE)</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPH</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  CYL</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OS(LE)</strong>
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  SPH</strong>
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong> CYL</strong>
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  AXIS</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  ADD</strong>
                                        
                                    </div>
                                </div>
                        
                        </div>
                     </div>
                         
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <strong> For Distinct</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtSPHOL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtCYLOL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         <asp:TextBox ID="txtAXISOL"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      
                                         
                                        
                                    </div>
                                </div>
                       <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtSPHOLR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                            
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtCYLOLR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div> 
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                     
                                         <asp:TextBox ID="txtAxisOR"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                    
                                         <asp:TextBox ID="txtAddOR"  placeholder="" CssClass="form-control"   runat="server" />
                                    </div>
                                </div>
                         
                     
                         
                        </div>
                     </div>
                         <div class="messagealert" id="alert_container">
            </div>
                       <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                       
                                        <asp:Button ID="btnreport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreport_Click" />
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="OPDNo"
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
                                        
                                        <asp:BoundField DataField="OPDNo" HeaderText="OPDNo"  />
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

