<%@ Page Title="" Language="C#" MasterPageFile="~/Opthalmology.master" AutoEventWireup="true" CodeFile="FaceExamination.aspx.cs" Inherits="FaceExamination" %>
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
            <%--  <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnEditImage" />
          <asp:PostBackTrigger ControlID="btnCard" />--%>
          

        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Face Examination</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Face Examination</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">  

                            <div class="row">
                      <div class="col-lg-4  text-left">
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Vision</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OD</strong>
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  OS</strong>
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                           <div id="Div1" class="col-lg-12 mt-2" runat="server" >
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  UN Aided</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtunaidedOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtunaidedOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                           <div id="Div2" class="col-lg-12 mt-2" runat="server" >
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  With Pinhole</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtwithpinholeOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtwithpinholeOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                           <div id="Div3" class="col-lg-12 mt-2" runat="server" >
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Aided</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtAidedOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAidedOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Ocular Motity</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtOcularOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtOcularOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                          <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Lids and Adenexa </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtLidsandAdenexaOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtLidsandAdenexaOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Nasolacrinal Apparants </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtNasolacrinalOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtNasolacrinalOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Syringing </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtSyringingOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtSyringingOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                            <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Cenjunctiva </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtCenjunctivaOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtCenjunctivaOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Cornea </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtCorneaOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtCorneaOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                            <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Iris </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtIrisOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtIrisOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                             <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Pupil </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtPupilOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtPupilOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Lens </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtLensOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtLensOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Vitreous </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtVitreousOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtVitreousOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                             <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Optis Disc </strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                     <asp:TextBox ID="txtOptisDiscOD"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtOptisDiscOS"  placeholder="" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">                                       
                                      <strong>  COR </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtCOROD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                      <asp:TextBox ID="txtCOROS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">                                       
                                      <strong>  FUNDUS </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtFUNDUSOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                      <asp:TextBox ID="txtFUNDUSOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                          <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">                                       
                                      <strong>  VESSELS </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtVESSELSOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                      <asp:TextBox ID="txtVESSELSOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                             <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">                                       
                                      <strong>  MACULA </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtMACULAOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                      <asp:TextBox ID="txtMACULAOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>

                           <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">                                       
                                      <strong>  PERIPHERY
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtPERIPHERYOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group">                                       
                                      <asp:TextBox ID="txtPERIPHERYOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                         
                          </div>
                                <div class="col-lg-8" runat="server" visible="false">
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
                                     

                                    </div>


                                 <div id="Div4" class="col-lg-12 mt-2" runat="server" >
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Anterior Segment
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtAnteriorSegmentOD" TextMode="MultiLine" placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtAnteriorSegmentOS" TextMode="MultiLine" placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                <div id="Div5" class="col-lg-12 mt-2" runat="server" >
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Posterior Segment
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtPosteriorSegmentOD" TextMode="MultiLine" placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtPosteriorSegmentOS" TextMode="MultiLine" placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                 <div id="Div6" class="col-lg-12 mt-2" runat="server" >
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Other Notes
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtOtherNotesOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtOtherNotesOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                 <div class="col-lg-12 mt-2" runat="server" visible="false">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Diagnosis
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtdiagnosis" TextMode="MultiLine" placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         
                                                 
                        </div>
                     </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Plan
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtPlan"  placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         
                                                 
                        </div>
                     </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Discussion
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtDiscussion" TextMode="MultiLine"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         
                                                 
                        </div>
                     </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Treatment
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtTreatment" TextMode="MultiLine" placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         
                                                 
                        </div>
                     </div>

                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Gonioscopy
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtGonioscopyOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtGonioscopyOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Panchynetery
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtPanchyneteryOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtPanchyneteryOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  IOP Correction
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtIOPCorrectionOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtIOPCorrectionOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Topography
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtTopographyOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtTopographyOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  IOL Master
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtIOLMasterOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtIOLMasterOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Keratonetery
                                      </strong>                                        
                                    </div>
                                </div>
                        </div>
                                    </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  K1
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtKINAXOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtKINAXOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        </div>
                                    </div>

                                   <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  K2
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtKININOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtKININOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        </div>
                                    </div>

                                     <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  AXIL Length
                                      </strong>                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtAXILLengthOD"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtAXILLengthOS"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        </div>
                                    </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  A constant 
                                      </strong>                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtacinstant"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtacinstant1"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        </div>
                                     </div>
                                <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong>  Lens Typte 
                                      </strong>                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtLensTypte"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtLensTypte1"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                        </div>
                                     </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                      <strong> IOL Power 
                                      </strong>                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtIOLPower"  placeholder="" CssClass="form-control"   runat="server" />                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">                                       
                                     <asp:TextBox ID="txtIOLPower1"  placeholder="" CssClass="form-control"   runat="server" />                                        
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
                     </div>
                   </section>

            </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

