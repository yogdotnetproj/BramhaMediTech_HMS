<%@ Page Title="OT Template" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OT_Template_Link.aspx.cs" Inherits="OT_Template_Link" %>

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
           <section class="content-header d-flex">
                    <h1>OT Template Link</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">OT Template Link</li>
                    </ol>
                </section>

            <section class="content">
                <div class="box" runat="server">
                    
                      <div class="box-body">
                        <%-- <div class="row">--%>
                             <div class="panel panel-info" >
    
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
                            
                           <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                           Operation Name
                                          
                                           </div>
                                     <div class="col-sm-4" >
                                         <asp:TextBox ID="txtOperationName" runat="server" CssClass="form-control"  placeholder="Enter Operation Name" ></asp:TextBox>

                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                       CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionSetCount="10" 
                                                TargetControlID="txtOperationName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                         </div>
                                     <div class="col-sm-2" >
                                          Code
                                          
                                           </div>
                                     <div class="col-sm-3" >
                                             <asp:TextBox ID="txtdepartment" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Code" ></asp:TextBox>
                                              
                                         </div>
                                    
                                     </div>
                               </div>
                            <div class="col-lg-12 mt-2">
                                 <div class="row">
                                      
                                       <div class="col-sm-2" >
                                           Operation Type
                                          
                                           </div>
                                      <div class="col-sm-4" >
                                           <asp:TextBox ID="txtOperstionType" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Operation Type"
                                               AutoPostBack="false"  onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                          
                                           </div>
                                     <div class="col-sm-2" >
                                           Operation Speciality
                                          
                                           </div>
                                      <div class="col-sm-4" >
                                          <asp:TextBox ID="txtOperationSpeciality" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Operation Speciality"
                                               AutoPostBack="True"  onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                              <%-- <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDepartment"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                       CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionSetCount="10" 
                                                TargetControlID="txtOperationSpeciality"
                                                ID="AutoCompleteExtender2"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>--%>
                                          
                                           </div>

                                     </div>
                                </div>
                          <div class="col-lg-12 mt-3">
                                 <div class="row">
                                      
                                       <div class="col-lg-12" >
                                           <div runat="server" id="Div1" style="height:400px; width:100%; overflow:scroll"    >                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvOTTemplate" runat="server" AutoGenerateColumns="False"
                                                class="table table-responsive table-lg table-bordered" Width="100%" 
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                AllowPaging="True" BackColor="White" 
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="310" ShowHeaderWhenEmpty="True"
                                                OnPageIndexChanging="GvOTTemplate_PageIndexChanging">
                                                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                                <Columns>
                                       
                                                    <asp:BoundField DataField="ReferalFormatName" HeaderText="Template Name"  />
                                                       <asp:TemplateField HeaderText="select Template">
                                                          <ItemTemplate>
                                                              <asp:CheckBox runat="server" ID="ChkselectTemplate"  />
                                                          </ItemTemplate>
                                                      </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Default ">
                                                          <ItemTemplate>
                                                              <asp:CheckBox runat="server" ID="ChkDefaultTemplate"  />
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
                             <div class="row mt-3 mb-3" >
                                    <div class="col-lg-12 text-center" >
                                        <asp:Button ID="btnSave"  CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click"  OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Text="Clear" OnClick="btnClear_Click" />
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
</asp:Content>

