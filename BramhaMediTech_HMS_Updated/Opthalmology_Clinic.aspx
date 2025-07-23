<%@ Page Title="" Language="C#" MasterPageFile="~/Opthalmology.master" AutoEventWireup="true" CodeFile="Opthalmology_Clinic.aspx.cs" Inherits="Opthalmology_Clinic" %>
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
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
          
          

        </Triggers>
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                    <h1>Doctor Assessment</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Doctor Assessment</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">  
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Chief Complaints:</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Ocular History/Past History</strong>
                                        
                                    </div>
                                </div>
                                                 
                        </div>
                     </div>
                         
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                   <asp:TextBox ID="txtchiefComplaints" TextMode="MultiLine" placeholder="Enter ChiefComplaints" CssClass="form-control"   runat="server" />
                                        
                                    </div>
                                </div>
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                     
                                       <asp:TextBox ID="txtOcularHistory" TextMode="MultiLine" placeholder="Enter Ocular History" CssClass="form-control"   runat="server" /> 
                                    </div>
                                </div>
                                                
                        </div>
                     </div>
                         
                         
                         <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Clinical Note</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Allergy</strong>
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                    <asp:TextBox ID="txtPastHistory" TextMode="MultiLine" placeholder="Enter Clinical Note" CssClass="form-control"   runat="server" /> 
                                        
                                    </div>
                                </div> 
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <asp:TextBox ID="txtAllergys" TextMode="MultiLine" placeholder="Enter Allergy" CssClass="form-control"   runat="server" /> 
                                     
                                        
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">

                                        </div>
                            </div>
                        </div>
                             </div>
                                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Treatment History</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Diagnosis</strong>
                                        
                                    </div>
                                </div>
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                         

                           
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txttreatmentHistory" placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                            
                        <div class="col-lg-6 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtDiagnosis" placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        </div>
                              </div>
                          
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkNil" Text="NIL" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkDM" Text="DM" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkHTN" Text="HTN" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkCad" Text="CAD" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkThyroid" Text="Thyroid" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkPregnancy" Text="Pregnancy" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkHIV" Text="HIV" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkHBsAG" Text="HBsAG" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkAsthamaa" Text="Asthama" />
                                        </div>
                            </div>
                        </div>
                              </div>
                           

                           <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Family History</strong>
                                        
                                    </div>
                                </div>
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkHTNF" Text="HTN" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkDMGlaucoma" Text="DM" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkGlaucoma" Text="Glaucoma" />
                                        </div>
                            </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkCongCataract" Text="Cong Cataract" />
                                        </div>
                            </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID ="ChkRP" Text="RP" />
                                        </div>
                            </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                          <asp:TextBox ID="txtRp" placeholder="" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                        </div>
                               </div>

                         <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                         <strong>Dilated</strong>
                                        </div>
                              </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:RadioButtonList runat="server" ID="RblDilated" RepeatDirection="Horizontal">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" >No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                             </div>
                    
                        </div>
                             </div>
                          <div class="col-lg-12 mt-2">
                    <div class="row">
                          <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                         <strong>Upload File</strong>
                                        </div>
                              </div>
                         <div class="col-sm-2 text-left">
                                            <div class="form-group">
                                              
                                                 <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="9"  
                                            Width="200px" />
                                      
                                                </div>
                                              </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                          <asp:TextBox ID="txtfileNAme" placeholder="File Name" TextMode="MultiLine" CssClass="form-control"   runat="server" />
                                        </div>
                            </div>
                         <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                         <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                                                          CssClass="btn btn-info" onclick="btnUpload_Click"   Text="Upload" />
                                        </div>
                             </div>
                         <div class="col-sm-6 text-left">
   <div class="form-group">   
       <div runat="server" id="UploadedFiles" style="height:150px;  overflow:scroll"    >                                          
 <div class="table-responsive" style="width:100%" >

<asp:GridView ID="gvImages" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" DataKeyNames="Path,OPFileId" AutoGenerateColumns="False" OnRowDeleting="gvImages_RowDeleting">
    <Columns>
        <asp:BoundField DataField="OPFileId" HeaderText=" Id" />
        <asp:BoundField DataField="FileName" HeaderText="Name" />
         <asp:BoundField DataField="CreatedOn" HeaderText="Created On" />
      
        <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Imagebutton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                            OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                            CommandName="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:TemplateField>
  <asp:TemplateField HeaderText="FilePath">
<ItemTemplate>
<asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
    </Columns>
</asp:GridView>
     <asp:HyperLink ID="Hyp_viewPres" runat="server" Visible="false" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View File</asp:HyperLink>
<div id="dialog" style="display: none">
</div>
     </div>
           </div>
       </div>
     </div>
                   
                        <%-- <div class="col-sm-3 text-left">
                                            <div class="form-group">
                                                <asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View File</asp:HyperLink>
                                                </div>
                             </div>--%>
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
                                        <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
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
                                         <asp:TemplateField HeaderText="ViewFile" >
                            <ItemTemplate>
<asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View File</asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>
                                     
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
            <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
</asp:Content>

