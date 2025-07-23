<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="ResourceUpload.aspx.cs" Inherits="ResourceUpload" %>
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
                    <h1>Add Resource Record</h1>
                   
                </section>
       <section class="content">
                <div id="Div1" class="box" runat="server">
                         
                    <div class="messagealert" id="alert_container">
            </div>
                    <div class="box-body">
                         <div class="col-lg-12 mt-3">
                                            <div class="row">    
                                                 <div class="col-sm-5 text-right">
                                            <div class="form-group">
                                                 <label for="ddlGender" ><strong> Type</strong></label>  
                                                </div>
                                                     </div>     
                                                <div class="col-sm-5 text-left">
                                            <div class="form-group">
                                               <asp:RadioButtonList ID="RblPatType" runat="server" RepeatDirection="Horizontal" >
                                                   <asp:ListItem Selected="True" Value="Doctor">Doctor</asp:ListItem>
                                                   <asp:ListItem Value="Nurses">Nurses</asp:ListItem>
                                                </asp:RadioButtonList>
                                                </div>
                                              </div>
                                                </div>
                             </div>
                            

                        <div class="col-lg-12 mt-3">
                            <div class="row"> 
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Remarks:</label> 
                                                        </div>
                                                    </div>
                                <div class="col-sm-10">
                                                    <div class="form-group"> 
                                                         <asp:TextBox ID="txtDiagnostics" TextMode="MultiLine" placeholder="Enter Remarks"  runat="server"   CssClass="form-control" 
                                                             ></asp:TextBox>
                                                        </div>
                                    </div>
                                </div>
                            </div>

                                 
                         <div class="col-lg-12 mt-3">
                                            <div class="row"> 
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                <label for="txtPatientAddress">Document Name:</label> 
                                                        </div>
                                                    </div>
                                                                                                
                                                <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                                                                                      
                                                          <asp:TextBox ID="txtdocumentNumber" runat="server" placeholder="Enter Document Name"  CssClass="form-control" 
                                                             ></asp:TextBox>
                                                             
                                                                                                                  
                        
                                                       
                                                 
                                                </div>                          
                                            </div>
                                                <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                                <label for="ddlGender">Upload Resource</label>  
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
                            PageSize="100" ShowHeaderWhenEmpty="True" TabIndex="4">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>
                                <asp:CommandField ButtonType="Image" Visible="false" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                            
                                
                               
                                <asp:BoundField DataField="PatientType" HeaderText="Type" />
                              

                                 <asp:BoundField DataField="DocumentNumber" HeaderText="Document Name" />
                                <asp:BoundField DataField="Diagnostics" HeaderText="Remarks" />
                                 <asp:BoundField DataField="CreatedBy" HeaderText="Uploaded by" />
                                 <asp:BoundField DataField="CreatedOn" HeaderText="Uploaded on" />
                                
                                <asp:TemplateField HeaderText="ViewPres" >
                            <ItemTemplate>
<asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View Resource</asp:HyperLink>
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

