<%@ Page Title="" Language="C#" MasterPageFile="~/OT_mainMaster.master" AutoEventWireup="true" CodeFile="Caesarean_Section.aspx.cs" Inherits="Caesarean_Section" %>

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
                    <h1>Caesarean Section</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Caesarean Section</li>
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
                                                <label for="txtFirstName"><strong>Date Time</strong></label> 
                                                </div>
                                              </div>   
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtDate" runat="server"   CssClass="form-control" TabIndex="7" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                </div>
                                    </div>
                                 <div class="col-sm-1" >
                                            <div class="form-group">
                                                <label for="txtFirstName"><strong>NPO </strong></label> 
                                                </div>
                                              </div> 
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlNPO"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="Till Further Order">Till Further Order</asp:ListItem>
                                            <asp:ListItem Value="NPO For Six hours">NPO For Six hours</asp:ListItem>
                                         
                                        </asp:DropDownList>
                                                </div>
                                              </div> 


                                </div>
                      </div>

                 <div class="col-lg-12 mt-3">
                            <div class="row">  
                                <div class="col-sm-2" >
                                            <div class="form-group">

                                                </div></div>
                                 <div class="col-sm-10" >
                                            <div class="form-group">
                                                <asp:TextBox ID="txtdetails" CssClass="form-control" TextMode="MultiLine" Height="100px"  runat="server" placeholder="" ></asp:TextBox>
                                      
                                                </div>
                                     </div>
                                </div>
                     </div>

                 <div class="col-lg-12 mt-3">
                            <div class="row">
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                <strong>Medication:</strong>
                                                </div>
                                    </div>  
                                 <div class="col-sm-10" >
                                            <div class="form-group">
                                                <asp:TextBox ID="txtMedication" CssClass="form-control" TextMode="MultiLine" Height="100px"  runat="server" placeholder="" ></asp:TextBox>
                                      
                                                </div>
                                     </div>
                                </div>
                     </div>

                  <div class="col-lg-12 mt-3">
                            <div class="row">
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                <strong>Sugar Monitoring:</strong>
                                                </div>
                                    </div>  
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                 <asp:DropDownList ID="ddlSugarMonotoring"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="YES">YES</asp:ListItem>
                                            <asp:ListItem Value="NO">NO</asp:ListItem>
                                         
                                        </asp:DropDownList>
                                                </div>
                                     </div>
                                <div class="col-sm-3 text-center" >
                                            <div class="form-group">
                                                <strong>Sliding Scale Insulin:</strong>
                                                </div>
                                    </div>  
                                 <div class="col-sm-2" >
                                            <div class="form-group">
                                                 <asp:DropDownList ID="ddlSliding"  CssClass="form-control form-select"  runat="server" >
                                          <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="YES">YES</asp:ListItem>
                                            <asp:ListItem Value="NO">NO</asp:ListItem>
                                         
                                        </asp:DropDownList>
                                                </div>
                                     </div>
                                </div>
                     </div>

                   <div class="col-lg-12 mt-3">
                            <div class="row">
                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                <strong>Note:</strong>
                                                </div>
                                    </div>  
                                 <div class="col-sm-10" >
                                            <div class="form-group">
                                                <asp:TextBox ID="txtNote" CssClass="form-control" TextMode="MultiLine" Height="100px"  runat="server" placeholder="" ></asp:TextBox>
                                      
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

