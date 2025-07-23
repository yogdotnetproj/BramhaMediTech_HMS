<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="AddMedicalRecord.aspx.cs" Inherits="AddMedicalRecord" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<%--<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
                </Triggers>
        <ContentTemplate>--%>
           
     <section class="content-header d-flex">
                    <h1>Add Medical Record</h1>
                   
                </section>
       <section class="content">
                <div id="Div1" class="box" runat="server">
                         <div class="box-header with-border">
                       
                            <div class="col-lg-12 text-left" runat="server" id="F1">
                                
                                 <div class="row">
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPrnNo" runat="server" Font-Bold="true" Text="Reg ID:" ></asp:Label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPat" runat="server" Font-Bold="true" Text="Patient Name:"></asp:Label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server" Font-Bold="true" Text="Gender:"> </asp:Label>
                                        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                             
                            </div>
                        </div>

                                

                         
                            <div class="col-lg-12 text-left mt-3" runat="server" id="F2">
                                <div class="row">
                              <div id="Div2" class="col-lg-4 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label ID="lblI"  runat="server" Font-Bold="true" Text="MobileNo:"></asp:Label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-5 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true" Text="Address:"> </asp:Label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server" Font-Bold="true" Text="Birth Date:"></asp:Label>
                                        <asp:Label ID="lblBirthDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>

                        
                           
                    </div>
                    <div class="messagealert" id="alert_container">
            </div>
                    <div class="box-body">
                         <div class="col-lg-12 mt-3">
                                            <div class="row">    
                                                 <div class="col-sm-5 text-right">
                                            <div class="form-group">
                                                 <label for="ddlGender" ><strong>Patient Type</strong></label>  
                                                </div>
                                                     </div>     
                                                <div class="col-sm-5 text-left">
                                            <div class="form-group">
                                               <asp:RadioButtonList ID="RblPatType" runat="server" RepeatDirection="Horizontal" >
                                                   <asp:ListItem Selected="True" Value="IPD">IPD</asp:ListItem>
                                                   <asp:ListItem Value="OPD">OPD</asp:ListItem>
                                                </asp:RadioButtonList>
                                                </div>
                                              </div>
                                                </div>
                             </div>
                            <div class="col-lg-12 mt-3">
                                            <div class="row">         
                                         <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                                <label for="ddlGender">Admission Date</label>  
                                                </div>
                                              </div>
                                               <div class="col-sm-2">                                                    
                                                    <div class="form-group">
                                                                                                                              
                                                         <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtAdmissionDate" AutoPostBack="true" runat="server"   Class="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>

                                                       
                                                    </div>
                                               </div>
                                                   
                                                
                                               
                                                 
                                                  <div class="col-sm-2">
                                                    <div class="form-group">
                                                        <label for="txtMobileNo">Discharge Date:</label>   
                                               </div>
                                                      </div>

                                               

                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                           
                                                             <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtDischargeDate" AutoPostBack="true" runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                        </div>
                                                    </div> 
                                               
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Dr Name:</label> 
                                                        </div>
                                                    </div>
                                                                                                
                                                <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                                                                                      
                                                          <asp:TextBox ID="txtdrname" runat="server" placeholder="Enter Dr Name"  CssClass="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                                                                  
                        
                                                       
                                                 
                                                </div>                          
                                            </div>
                                                </div>
                                        </div>

                        <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Diagnosis:</label> 
                                                        </div>
                                                    </div>
                                <div class="col-sm-10">
                                                    <div class="form-group"> 
                                                         <asp:TextBox ID="txtDiagnostics" TextMode="MultiLine" placeholder="Enter Diagnosis"  runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                        </div>
                                    </div>
                                </div>
                            </div>

                                 
                         <div class="col-lg-12 mt-3">
                                            <div class="row"> 
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Document Number:</label> 
                                                        </div>
                                                    </div>
                                                                                                
                                                <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                                                                                      
                                                          <asp:TextBox ID="txtdocumentNumber" runat="server" placeholder="Enter Document Number"  CssClass="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                                                                  
                        
                                                       
                                                 
                                                </div>                          
                                            </div>
                                                <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                                <label for="ddlGender">Upload Document</label>  
                                                </div>
                                              </div>
                                                <div class="col-sm-3 text-left">
                                            <div class="form-group">
                                                 <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="9"  
                                            Width="200px" />
                                       
                                                </div>
                                              </div>
                                                 <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                                <asp:Button ID="btnUpload" runat="server" class="btn btn-primary" CausesValidation="False" 
                                            Text="Upload" OnClick="btnUpload_Click" />
                                                </div>
                                              </div>

                                                </div>
                             </div>

                         <div class="col-lg-12 mt-3">
                                            <div class="row"> 
                                                <div class="col-sm-12">
                                                      <div class="table-responsive" style="width:100%">             

                            <asp:GridView ID="gvAddMEdicalRecord" runat="server" AllowPaging="True" class="table table-responsive table-sm table-bordered" Width="100%"  
                            HeaderStyle-ForeColor="Black" DataKeyNames="MedicalId"  AutoGenerateColumns="False" 
                         
                            EmptyDataText="No Records to Display" 
                            OnPageIndexChanging="gvAddMEdicalRecord_PageIndexChanging" 
                            OnRowDeleting="gvAddMEdicalRecord_RowDeleting" OnRowEditing="gvAddMEdicalRecord_RowEditing" 
                            PageSize="25" ShowHeaderWhenEmpty="True" TabIndex="4">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>
                                <asp:CommandField ButtonType="Image" Visible="false" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                            
                                <asp:BoundField DataField="Patregid" HeaderText="Patregid" 
                                    ItemStyle-HorizontalAlign="Left">
                               
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="PatientType" HeaderText="Patient Type" />
                                <asp:BoundField DataField="AdmissionDate" HeaderText="Admission Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />

                                <asp:BoundField DataField="DischargeDate" HeaderText="Discharge Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                <asp:BoundField DataField="DrName" HeaderText="Dr Name" />

                                 <asp:BoundField DataField="DocumentNumber" HeaderText="Document Number" />
                                <asp:BoundField DataField="Diagnostics" HeaderText="Diagnosis" />
                                
                                <asp:TemplateField HeaderText="ViewPres" >
                            <ItemTemplate>
<asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View Pres</asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pagination" BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
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
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>

