<%@ Page Title="General EMR" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientReferalNoteFormat.aspx.cs" Inherits="PatientReferalNoteFormat" %>

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
          

            <section class="content">
                <div class="box" runat="server">
                    
                      <div class="box-body">
                        <%-- <div class="row">--%>
                             <div class="panel panel-info" >
      <div class="panel-heading" style="font-size:medium;font-weight:bold"">Patient Referal Note Format</div>
      <div class="panel-body"  style="background-color:aliceblue;height:100px" runat="server" visible="false">
    
                            <div class="col-lg-12" runat="server" visible="false">
                                <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="lblPatientName">Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="">PRN:</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2" runat="server" visible="false">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblOpd" title="">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                     <div class="col-lg-3">
                                    <div class="form-group">
                                        <label for="lblAddress" title="">Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
                       
                            <div class="col-lg-12 text-left" runat="server" visible="false">
                                <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <label for="lbldName" title="">Dr Name:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblDept" title="">Dept:</label>
                                        <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblVisitingNo"   title="">Visit No:</label>
                                        <asp:Label ID="lblVisitingNo" runat="server" Text=" "></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblToken" title="">Token No:</label>
                                        <asp:Label ID="lblToken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                               
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label for="lblBranchId"></label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
           </div>
                            </div>   
                            
                           <div class="col-lg-12">
                                 <div class="row">
                                      
                                       <div class="col-sm-3" >
                                           Format Name
                                          
                                           </div>
                                     <div class="col-sm-9" >
                                         <asp:TextBox ID="txtformatname" runat="server" CssClass="form-control" ></asp:TextBox>
                                         </div>
                                     </div>
                               </div>
                           <div class="col-lg-12">
                                 <div class="row">
                                      
                                       <div class="col-lg-12" >
                                            <br />
                                           </div>
                                     </div>
                               </div>
                          <div class="col-lg-12">
                                 <div class="row">
                                      
                                       <div class="col-lg-12" >
                                           <asp:TextBox ID="Editor1" runat="server" Height="2000px" TextMode="MultiLine"></asp:TextBox>
<script type="text/javascript" lang="javascript">  CKEDITOR.replace('<%=Editor1.ClientID%>');</script> 
                                           </div>
                                     </div>
                              </div>
                             <div class="row mt-3 mb-3" >
                                    <div class="col-lg-12 text-center" >
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                         <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                    </div>
                                </div>

                            <div class="row" >
                                    <div class="col-lg-12 text-left" >
                                          <div class="form-group">  
                                    
                                                 <div runat="server" id="Div1" style="height:400px; width:950px; overflow:scroll"    >                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvNoteIngrid" runat="server" AutoGenerateColumns="False"
                                                class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="ForId"
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                AllowPaging="True" BackColor="White" 
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="310" ShowHeaderWhenEmpty="True"
                                                OnPageIndexChanging="GvNoteIngrid_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                       
                                                    <asp:BoundField DataField="ReferalFormatName" HeaderText="Format Name"  />
                                                    
                                                     <asp:BoundField DataField="ReferalFormat" HeaderText="Referal Format" HtmlEncode="False"  />
                                                    <asp:BoundField DataField="Createdby"  HeaderText="Format By"  />
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

