<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="ReferToAdmission.aspx.cs" Inherits="ReferToAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1> Refer To Admission</h1>
<ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Refer To Admission</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <%--<div class="row">--%>
                            
                             <div class="col-lg-12"  >
                        <div class="row">
                             <div class="col-lg-3 text-left"  >
                                 <div class="form-group"> 
                                     <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal">
                                         <asp:ListItem Selected="True">Refer To Admission</asp:ListItem>
                                           <asp:ListItem>ER Procedure</asp:ListItem>
                                     </asp:RadioButtonList>
                                   </div>
                                 </div>
                            <div class="col-lg-2 text-right"  >
                                 <div class="form-group"> 
                                     Doctor Name
                                     </div>
                                </div>
                             <div class="col-lg-3 text-left"  >
                                 <div class="form-group">

                                      <asp:TextBox ID="txtConsDoctorName1" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter refer Doctor"
                                                  onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtConsDoctorName1"
                                                ID="AutoCompleteExtender4"
                                                    CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList"
                                                 CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                 </div>
                            </div>
                                 </div>
                                  </div>

                         <div class="col-lg-12 mt-2"  >
                        <div class="row">
                             <div class="col-lg-12 text-left"  >
                                 <div class="form-group"> 
                                     <asp:TextBox ID="txtDrNote" runat="server" TextMode="MultiLine"   CssClass="form-control" placeholder="Enter Refer admission Notes"
                                              Height="300px"    ></asp:TextBox>
                                     </div>
                                 </div>
                            </div>
                             </div>
                         <div class="col-lg-12 mt-2"  >
                        <div class="row">
                             <div class="col-lg-12 text-center"  >
                                 <div class="form-group"> 
                                   <asp:Button ID="btnsave"  runat="server" Text="Save"  class="btn btn-success" OnClick="btnsave_Click" />
                                     </div>
                                 </div>
                            </div>
                             </div>
                                    <div class="col-lg-12 mt-3" >
                                        
                               
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="ReferId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OPDNO" HeaderText="OPD NO" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="ReferType" HeaderText="Refer Type" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="ReferBy" HeaderText="Refer By" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="ReferTo" HeaderText="Refer To" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="ReferNote" HeaderText="Refer Note" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="ReferOn" HeaderText="Refer On" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        
                                                       
                                                       
                                                        
                                                  
                                                         </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
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
                            
                              <%--  </div>--%>
                            </div>

                      
                    </div>
             
            </section>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        function OpenReport() {
            window.open("Reports.aspx");
        }
               </script>
    
</asp:Content>
