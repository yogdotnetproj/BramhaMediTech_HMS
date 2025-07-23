<%@ Page Title="OT Template" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="Surgen_Notes.aspx.cs" Inherits="Surgen_Notes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <h1>General EMR</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        CKEDITOR.replace('Editor1', {
            height: 10000,
            // Remove the WebSpellChecker plugin.
            removePlugins: 'wsc',
            // Configure SCAYT to load on editor startup.
            scayt_autoStartup: true,
            // Limit the number of suggestions available in the context menu.
            scayt_maxSuggestions: 3
        });
	</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script src="ckeditor/ckeditor.js"></script>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
           <section class="content-header d-flex">
                    <h1>Surgeon Notes</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Surgeon Notes</li>
                    </ol>
                </section>

            <section class="content">
                <div class="box" runat="server">
                    
                      <div class="box-body">
                        <%-- <div class="row">--%>
                             <div class="panel panel-info" >
    
     
                            </div>   
                            
                            <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-1" >
                                             <div class="form-group">
                                           Note Date
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtNoteDate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                     <div class="col-sm-1" >
                                             <div class="form-group">
                                           Date of Operation
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdateofOperation" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                      <div class="col-sm-1" >
                                             <div class="form-group">
                                          Schedule
                                          </div>
                                           </div>
                                     <div class="col-sm-1">
                                        <div class="form-group">
                                                <asp:TextBox ID="txtschedule" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                
                                            </div>
                                    </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                          Operative Procedure
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                                <asp:TextBox ID="txtOperativeProcedure" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                
                                            </div>
                                    </div>

                                     </div>
                                </div>

                           <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                          Pre Operative Diagnosis
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtPreOperativeDiagnosis" placeholder="Pre Operative Diagnosis" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                        Anaesthetist
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtAnaesthetist" placeholder="Anaesthetist" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                        Duration of Surgery
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtdurationofsurgery" placeholder=" Duration of Surgery" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     </div>
                               </div>

                             <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                          Post Operative Diagnosis
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtPostOperativeDiagnosis" placeholder="Post Operative Diagnosis" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                        Anaesthetist
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtAnaesthetist2" placeholder="Anaesthetist" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                      Tourniquet Time
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtTourniquetTime" placeholder="Tourniquet Time" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     </div>
                               </div>
                           <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                          Swab/Pack/Instrument Count
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtSwabPAck" placeholder=" Swab/Pack/Instrument Count" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                        Surgeon
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtSurgeon" placeholder="Surgeon" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                     Inflate
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtInflate" placeholder="Inflate" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     </div>
                               </div>

                             <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                          Material/Specimen Forwarded for Pathology
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtSpecimen" placeholder=" Specimen Forwarded for Pathology" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                        Scrub Nurse
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtScrubNurse" placeholder="Scrub Nurse" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                     Deflate
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtDeflate" placeholder="Deflate" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     </div>
                               </div>

                            <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                          Operation Finding
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtOperationFinding" placeholder=" Operation Finding" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                      Blood Loss in ml
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtbloodloss" placeholder="lood Loss in ml" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                     Drains
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:DropDownList ID="ddlDrains"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                              <asp:ListItem Value="No">No</asp:ListItem>
                                         
                                        </asp:DropDownList>
                                            </div>
                                         </div>
                                     </div>
                               </div>

                            <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                             <div class="form-group">
                                         Fluid Used Amount
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox runat="server" ID="txtFluidUsedAmount" placeholder="Fluid Used Amount" CssClass="form-control pull-right" ></asp:TextBox>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                     Lavage Done
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:DropDownList ID="ddlLavageDone"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                           <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                              <asp:ListItem Value="No">No</asp:ListItem>
                                         
                                        </asp:DropDownList>
                                            </div>
                                         </div>
                                     <div class="col-sm-2" >
                                             <div class="form-group">
                                     Template
                                          </div>
                                           </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                             <asp:TextBox ID="txtTemplateName" runat="server" CssClass="form-control"  placeholder="Enter Template Name" ></asp:TextBox>

                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchTemplate"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                       CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionSetCount="10" 
                                                TargetControlID="txtTemplateName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                         </div>
                                     </div>
                               </div>

                           <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-12" >
                                             <div class="form-group">
                                                 <asp:TextBox ID="Editor1" runat="server"  TextMode="MultiLine"></asp:TextBox>
<script type="text/javascript" lang="javascript">  CKEDITOR.replace('<%=Editor1.ClientID%>');</script> 
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
      <script>
          CKEDITOR.replace('Editor1', {
              height: 13000,
              // Remove the WebSpellChecker plugin.
              removePlugins: 'wsc',
              // Configure SCAYT to load on editor startup.
              scayt_autoStartup: true,
              // Limit the number of suggestions available in the context menu.
              scayt_maxSuggestions: 3
          });
	</script>
</asp:Content>

