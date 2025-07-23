<%@ Page Title="" Language="C#" MasterPageFile="~/OT_mainMaster.master" AutoEventWireup="true" CodeFile="VAGINALHYSTERECTOMYFORPROLAPSE.aspx.cs" Inherits="VAGINALHYSTERECTOMYFORPROLAPSE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>VAGINAL HYSTERECTOMY FOR PROLAPSE</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">VAGINAL HYSTERECTOMY FOR PROLAPSE</li>
                    </ol>                
                </section>
             <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                                    <div class="row">    
                  <div class="col-lg-12 mt-3">
                            <div class="row">  
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Note Time</strong></label> 
                                                </div>
                                              </div>   
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtNoteDate" runat="server"   CssClass="form-control" TabIndex="7" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                </div>
                                    </div>
                                
                                 <div class="col-sm-3 text-center" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Schedule </strong></label> 
                                                </div>
                                              </div> 
                                <div class="col-sm-3" >
                                            <div class="form-group">
                                               <asp:TextBox ID="txtschedule" CssClass="form-control"  runat="server" placeholder="" ></asp:TextBox>
                                      
                                                </div>
                                              </div> 
                                </div>
                      </div>

                                        <div class="col-lg-12 mt-3">
                            <div class="row">
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Date Of Operation </strong></label> 
                                                </div>
                                              </div> 
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                               <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtdateofoperation" runat="server"   CssClass="form-control" TabIndex="7" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                </div>
                                              </div> 
                                 <div class="col-sm-3 text-center" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>Operative Procedure </strong></label> 
                                                </div>
                                              </div> 
                                <div class="col-sm-3 " >
                                            <div class="form-group">
                                               <asp:TextBox ID="txtoperativeProcedure" CssClass="form-control"  runat="server" placeholder="" ></asp:TextBox>
                                      
                                                </div>
                                              </div> 
                                </div>
                                            </div>
                                        <div class="col-lg-12 mt-2">
                            <div class="row">
                                         <div style="height:2px; background:#B24592;"> </div>
                                </div>
                                            </div>
                 <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Pre-Operative Diagnosis</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtpreOperativeDiagnosis" CssClass="form-control"  runat="server" placeholder="Enter Pre-Operative Diagnosis" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Anaesthetist</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtAnaesthetist" CssClass="form-control"  runat="server" placeholder="Enter Anaesthetist" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Duration of Surgery</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtdurationofsurgery" CssClass="form-control"  runat="server" placeholder="Enter Duration of Surgery" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Post Operative Diagnosis</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtpostoperativediagnosis" CssClass="form-control"  runat="server" placeholder="Enter Post Operative Diagnosis" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                          <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Post Operative Anaesthetist</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtpostoperativeAnaesthetist" CssClass="form-control"  runat="server" placeholder="Enter Post Operative Anaesthetist" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Tourniquet Time</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtTourniquetTime" CssClass="form-control"  runat="server" placeholder="Enter Tourniquet Time" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>
                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Swab/Pack/Instrument Count</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtswabcount" CssClass="form-control"  runat="server" placeholder="Enter Swab/Pack/Instrument Count" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Surgeon</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtSurgeon" CssClass="form-control"  runat="server" placeholder="Enter Surgeon" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Inflate</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtInflate" CssClass="form-control"  runat="server" placeholder="Enter Inflate" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Material/Specimen Forwarded for Pathology</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtmaterialforwarded" CssClass="form-control"  runat="server" placeholder="Enter Material/Specimen Forwarded for Pathology" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>
                                            <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Scrub Nurse</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtScrubNurse" CssClass="form-control"  runat="server" placeholder="Enter Scrub Nurse" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Deflate</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtDeflate" CssClass="form-control"  runat="server" placeholder="Enter Deflate" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Operation Findings</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:TextBox ID="txtoperationFinding" CssClass="form-control"  runat="server" placeholder="Enter Operation Findings" ></asp:TextBox>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong>Blood Loss in ml</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       <asp:TextBox ID="txtbloodloss" CssClass="form-control"  runat="server" placeholder="Enter Blood Loss in ml" ></asp:TextBox>
                                      </div>
                                </div>
                             
                                </div>
                     </div>

                                         <div class="col-lg-12 mt-2">
                            <div class="row">  
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                         <strong> Drains</strong>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                          <asp:DropDownList ID="ddlDrains"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                         <asp:ListItem Value="No">No</asp:ListItem>
                                        </asp:DropDownList>
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">
                                        
                                      </div>
                                </div>
                                <div class="col-sm-3" >
                                     <div class="form-group">

                                       
                                      </div>
                                </div>
                             
                                </div>
                     </div>
<div class="col-lg-12 mt-2" id="longprotocol3" runat="server">

                    <div class="row">
                        <div class="panel-heading">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <strong>VAGINAL HYSTERECTOMY FOR PROLAPSE</strong>
                                        </div>
                                </div>
                        </div>

                    </div>
                           </div>

                                        <div class="row">
                                             <div class="col-lg-6  text-left">
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-4" >
                                            <div class="form-group">
                                                <strong>Uterine Size</strong>
                                                </div>
                                    </div>
                                                <div class="col-sm-4" >
                                            <div class="form-group">
                                                 <asp:TextBox ID="txtUterineSize" CssClass="form-control"   runat="server" placeholder="" ></asp:TextBox>
                                                </div>

                                                </div>
                                   
                                                         
                                                     </div>
                                             </div>
                                                 
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-4" >
                                            <div class="form-group">
                                               <asp:CheckBox runat="server" ID="chkCystocele" Text="Cystocele" />
                                                </div>
                                    </div>
                                                           <div class="col-sm-4" >
                                            <div class="form-group">
                                                     <asp:DropDownList ID="ddlCystocele"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="Mild">Mild</asp:ListItem>
                                                <asp:ListItem Value="Moderate">Moderate</asp:ListItem>
                                                <asp:ListItem Value="Large">Large</asp:ListItem>
                                                  </asp:DropDownList>     
                                             </div>            
                                       </div>

                                                      </div>
                                                     </div>
                                                <div class="col-lg-12 mt-2">
                                                  
                                                      <div class="row">
                                                         <div class="col-sm-4" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkRectocele" Text="Rectocele" />
                                                </div>
                                    </div>
                                                     <div class="col-sm-4" >
                                            <div class="form-group">
                                                     <asp:DropDownList ID="ddlRectocele"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="Mild">Mild</asp:ListItem>
                                                <asp:ListItem Value="Moderate">Moderate</asp:ListItem>
                                                <asp:ListItem Value="Large">Large</asp:ListItem>
                                                  </asp:DropDownList>     
                                             </div>            
                                       </div>   
                                                      </div>
                                                     </div>

                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                                           <div class="col-sm-4" >
                                            <div class="form-group">
                                             <asp:CheckBox runat="server" ID="chkFibroids" Text="Fibroids" />
                                                </div>
                                    </div>
                                                      </div>
                                                     </div>
                                                  <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                                          <div class="col-sm-4" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkAdhesions" Text="Adhesions" />
                                                </div>
                                    </div>
                                                      </div>
                                                     </div>
                                               
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                                          <div class="col-sm-4" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkOophrectomy" Text="Oophrectomy" />
                                                </div>
                                    </div>
                                                           <div class="col-sm-4" >
                                            <div class="form-group">
                                                     <asp:DropDownList ID="ddlOophrectomy"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="Unilateral">Unilateral</asp:ListItem>
                                                <asp:ListItem Value="Bilateral">Bilateral</asp:ListItem>
                                              
                                                  </asp:DropDownList>     
                                             </div>            
                                       </div>   
                                                      </div>
                                                     </div>
                                                   <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                                          <div class="col-sm-4" >
                                            <div class="form-group">
                                              <strong>Comments</strong>
                                                </div>
                                    </div>
                                                      </div>
                                                     </div>

                                                <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                                          <div class="col-sm-8" >
                                            <div class="form-group">
                                               <asp:TextBox ID="txtcommenta" CssClass="form-control" TextMode="MultiLine" Height="100px"  runat="server" placeholder="" ></asp:TextBox>
                                             
                                                </div>
                                    </div>
                                                      </div>
                                                     </div>

                                                 


                                                 </div>

                                             <div class="col-lg-6  text-left">
                                            

                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-10" >
                                            <div class="form-group">
                                              <strong>  Procedure</strong>   </div>
                                    </div>
                                                         

                                                      </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                      <div class="row">
                                <div class="col-sm-10" >
                                            <div class="form-group">
                                              <asp:TextBox ID="txtProcedure" CssClass="form-control" TextMode="MultiLine" Height="200px"  runat="server" placeholder="" ></asp:TextBox>
                                                </div>
                                    </div>
                                                         

                                                      </div>
                                                     </div>
                                                <div class="col-lg-12 mt-2">
                                                     
                                                      <div class="row">
                                <div class="col-sm-12" >
                                            <div class="form-group">
                                              <strong>Hysterectomy done: </strong>
                                                </div>
                                    </div>
                                                         

                                                      </div>
                                                     </div>
                                                   
                                                 <div class="col-lg-12 mt-2">
                                                     
                                                      <div class="row">
                                <div class="col-sm-6" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkCystoceleRepaired" Text="Cystocele Repaired" />
                                                </div>
                                    </div>
                                                 <div class="col-sm-6" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkSacrospinouspexy" Text="Sacrospinouspexy Done" />
                                                </div>
                                    </div>         

                                                      </div>
                                                     </div>
                                                
                                                 <div class="col-lg-12 mt-2">
                                                     
                                                      <div class="row">
                                <div class="col-sm-6" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkRectoceleRepaired" Text="Rectocele Repaired" />
                                                </div>
                                    </div>
                                                 <div class="col-sm-6" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkPackInserted" Text="Pack Inserted " />
                                                </div>
                                    </div>         

                                                      </div>
                                                     </div>
                                                 <div class="col-lg-12 mt-2">
                                                     
                                                      <div class="row">
                                <div class="col-sm-6" >
                                            <div class="form-group">
                                              <asp:CheckBox runat="server" ID="chkLevatorplastyDone" Text="Levatorplasty Done" />
                                                </div>
                                    </div>
                                                 <div class="col-sm-6" >
                                            <div class="form-group">
                                             
                                                </div>
                                    </div>         

                                                      </div>
                                                     </div>
                                                 </div>
                                              
                                            
                                            </div>
              

                  
                   <div class="messagealert" id="alert_container">
            </div>
                                        </div>
                     </div>
                     </div>
                 <div class="col-lg-12 mt-3">
                 <div class="row">                
                    <div class="col-lg-12 mt-3 text-center">
                         <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnSave_Click" 
                                        TabIndex="12" Width="80px" CssClass="btn btn-success"   CausesValidation="False"   UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" />
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary"   CausesValidation="False"   UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" OnClick="btnPrint_Click" />             
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

