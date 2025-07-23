<%@ Page Title="" Language="C#" MasterPageFile="Hospital.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Masters_ChangePassword"  Culture="auto" UICulture="auto"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="Maincontent" runat="Server">
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
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
      <%--  <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>--%>

        <ContentTemplate>

             <section class="content-header d-flex">
                    <h1>Change Password</h1>
                    <ol class="breadcrumb">
                       <%-- <li><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                        <li><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                      --%> 
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                         <li class="breadcrumb-item active">Change Password</li>
                    </ol>
                </section>
            <section class="content">
                    <div class="box pt-3" runat="server" id="List" >
                      <!-- <div class="box-header with-border">
                            <asp:Label ID="lblMsg" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                        </div>-->
                        <div class="box-body">
                             <div class="messagealert" id="alert_container">
                                             
            </div>   
                            <div class="row mb-3">
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">                                      
                                        <label class="control-label">
                                                     New Password
                                                  </label>
                                    </div>
                                </div>
                                <div class=" col-sm-3 text-left">
                                    <div class="form-group">                                 
                                       <asp:TextBox ID="txtNewPassword" Text="" AutoCompleteType="None" runat="server"
                            TabIndex="1" TextMode="Password" 
                            ontextchanged="txtNewPassword_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                <div class=" col-sm-3 text-left">
                                    <div class="form-group">    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword"
                            ErrorMessage="Enter New Password" ForeColor="#FF3300" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </div>
                                </div> 
                            </div>

                             <div class="row mb-3">
                                <div class="col-sm-12 ">
                                    <div class="row">  
                                      <div class="col-sm-2 text-left">
                                        <div class="form-group">                                      
                                             <label CssClass="control-label">
                                                    Confirm Password
                                                  </label>
                                       </div>
                                   </div>
                                <div class=" col-sm-2 text-left">
                                    <div class="form-group">                                 
                                       <asp:TextBox ID="txtConfirmPassword" Text="" runat="server"
                            TabIndex="1" ontextchanged="txtConfirmPassword_TextChanged" 
                            TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                    <div class=" col-sm-2 text-left" >
                                    <div class="form-group">   
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToCompare="txtConfirmPassword" ControlToValidate="txtNewPassword" 
                            ErrorMessage="Not Match" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                    
                                    </div>
                                </div> 
                                        </div>
                                    </div>
                            </div>

                            <div class="row mb-3">
                                <div class="col-sm-12 ">
                                    <div class="row">  

                                <div class="col-sm-2 text-left">
                                    <div class="form-group">                                      
                                        <label CssClass="control-label">
                                                    Old Password
                                                  </label>
                                    </div>
                                </div>
                                <div class=" col-sm-3 text-left">
                                    <div class="form-group">        
                        <asp:TextBox ID="txtOldPassWord" Text="" runat="server"
                            TabIndex="1" Wrap="False" ontextchanged="txtOldPassWord_TextChanged" 
                            TextMode="Password"></asp:TextBox>
                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOldPassWord"
                            ErrorMessage="Enter Old Password" ForeColor="#FF3300" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                   </div>
                            </div>

                                         </div>
                                    </div>
                            </div>

                            <div class="row mb-3">
                                 <div class="col-sm-12 col-sm-offset-2 ">
                                   

                                                                   
                                         <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Change" OnClick="btnSave_Click"
                            TabIndex="2" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary"  OnClick="btnReset_Click"
                            CausesValidation="False" TabIndex="3" />
                                    
                            
                                     </div>      
                                </div>                     
                        
                       
                    
                            </div>
                        </div>
             
                   


                </section>

            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

