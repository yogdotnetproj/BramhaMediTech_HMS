<%@ Page Title="General EMR" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="PatientReferalNoteCreate.aspx.cs" Inherits="PatientReferalNoteCreate" %>

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
                           
                            
                           <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-lg-3" >
                                           <b>Format Name</b>
                                          
                                           </div>
                                     <div class="col-lg-9" >
                                         <asp:DropDownList ID="ddlformatnote" runat="server" CssClass="form-control form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlformatnote_SelectedIndexChanged" ></asp:DropDownList>
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
                                      
                                       <div class="col-lg-12">
                                           <asp:TextBox ID="Editor1" runat="server" Height="2000px" TextMode="MultiLine"></asp:TextBox>
<script type="text/javascript" lang="javascript">  CKEDITOR.replace('<%=Editor1.ClientID%>');</script> 
                                           </div>
                                     </div>
                              </div>
                             
                                    <div class="col-lg-12 mt-3 text-center">
                                      
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                         <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                                   
                                </div>

                            <div class="row" >
                                    <div class="col-lg-12 mt-3">
                                          <div class="form-group">  
                                    
                                                 <div runat="server" id="Div1" style="height:400px; overflow:scroll">                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvNoteIngrid" runat="server" AutoGenerateColumns="False"
                                                class="table table-responsive table-lg table-bordered" Width="100%" DataKeyNames="Refid"
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                AllowPaging="True" BackColor="White" 
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="310" ShowHeaderWhenEmpty="True"
                                                OnPageIndexChanging="GvNoteIngrid_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                       
                                                    
                                                    
                                                     <asp:BoundField DataField="ReferalNote" HeaderText="Referal Format" HtmlEncode="False"  />
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

