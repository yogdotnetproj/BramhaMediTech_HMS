<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="ReferToIPDAdmission.aspx.cs" Inherits="ReferToIPDAdmission" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>Refer To IPD Admission List</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Refer To IPD Admission List</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                            
                            <div class="col-lg-12" >
                                <div class="row">
                                      <div class="col-sm-2 text-left">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Patient Name/RegNo</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                      <div class="col-sm-2 text-left">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                  
                                   
                                    
                                               <div class="col-sm-2 text-left" runat="server" visible="false">
                                                        <div class="form-group"> 
                                                            <label for="ddlRoomCategory">Room Category:</label>                                                                                                                                                                                              
                                                         </div>
                                               </div>
                                                <div class="col-sm-2 text-left" runat="server" visible="false">
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlRoomCategory" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="18">
                                                            </asp:DropDownList>                   
                                                        
                                                    </div>
                                                </div> 

                                    <div class="col-sm-4 text-left">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-success btnSearch" />
                                        </div>
                                            </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="Patregid"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                                    <Columns>  
                                                         
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id"  Visible="True" >
                                                         
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OPDNO" HeaderText="OPD NO"  >
                                                        
                                                        
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name"  >
                                                        
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="ReferBy" HeaderText="Refer By"  >
                                                       
                                                       
                                                         </asp:BoundField>
                                                       <asp:BoundField DataField="ReferTo" HeaderText="Refer To"  >
                                                         
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="ReferOn" HeaderText="Refer On"  DataFormatString="{0:dd/MM/yyyy}" >
                                                         
                                                         </asp:BoundField>
                                                      
                                                        <asp:ButtonField CommandName="Select" Text="Admit"  ControlStyle-CssClass="btn btn-danger" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-danger" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                 <asp:HiddenField ID="hdnReferDrId" runat="server" Value='<%#Eval("ReferDrId") %>' /> 
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                     
                                                    </Columns>
                                                   <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                              
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
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

    
</asp:Content>

