<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OT_RegisterEstimateTemplate.aspx.cs" Inherits="OT_RegisterEstimateTemplate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1> OT Estimate Template</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OT Estimate Template</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                            
                            
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off"  runat="server" CssClass="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>                                    
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" CssClass="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtsurgan" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Surgan Name"
                                                AutoPostBack="True" ontextchanged="txtsurgan_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtsurgan"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                            <div class="col-sm-3" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtoperation" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Operation Name"
                                                AutoPostBack="True" ontextchanged="txtoperation_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender4"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                    <div class="col-sm-4" Visible="false" runat="server" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                    <div class="col-sm-3 d-none" >
                                        <div class="form-group form-check">
                                            <asp:DropDownList ID="ddlRoomCategory" Visible="false" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="18">
                                                            </asp:DropDownList>                   
                                                        <asp:RadioButtonList ID="RblOTType"  runat="server" Visible="false" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1" Text="General"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="EYE"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                            <asp:Label runat="server" ForeColor="Red" Font-Bold="true" ID="pcount"></asp:Label>
                                            </div>
                                </div>
                                   <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-primary btnSearch" />
                                        </div>
                                            </div>
                                    </div>
                               
                             <div class="row">
                                    <div class="col-lg-12 mt-3">

                                        
                                         <div class="col-sm-3" Visible="false" runat="server" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtanesticia" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Anestia Name"
                                                AutoPostBack="True" ontextchanged="txtanesticia_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAnaesthetist"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtanesticia"
                                                ID="AutoCompleteExtender3"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>

                                        
                                         <div class="col-sm-3" Visible="false" runat="server" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtdieses" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Disease Name"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtdieses_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDisease"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtdieses"
                                                ID="AutoCompleteExtender5"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                        </div>
                                  </div>

                             <div class="row">
                                    <div class="col-lg-12 mt-3 text-center" >
                                         <asp:Button ID="btnReport"  runat="server" Text="Excel" TabIndex="3" ValidationGroup="Date" class="btn btn-primary btnSearch" OnClick="btnReport_Click" />
                                        </div>
                                 </div>
                                    <div class="col-lg-12 mt-3" >
                                        
                               
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" 
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White"  OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True" >
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         <asp:BoundField DataField="SurganName" HeaderText="Surgeon" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="CreatedOn" HeaderText="Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="OperationName" HeaderText="Procedure" ItemStyle-Width="200" >                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>

                                                         <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>

                                                        <asp:BoundField DataField="SurgeonFee" HeaderText="Surgeon Fee" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="AnaesthetistFee" HeaderText="Anaesthetist Fee" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>

                                                        <asp:BoundField DataField="WardCharges" HeaderText="Ward Charges" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="AnaeTimeCharges" HeaderText="Anaesthetist Time Charges" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="TheatreTimeCharges" HeaderText="Theatre Time" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="WardDrugsCharges" HeaderText="Ward Drugs" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>

                                                        <asp:BoundField DataField="TheatreDrugsCharges" HeaderText="Theatre Drugs " ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="InvestigationCharges" HeaderText="Investigations" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="TotalCharges" HeaderText="Total Charges" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        
                                                        <%--<asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="IpdNo" HeaderText="IpdNo" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>--%>
                                                        
                                                       
                                                       
                                                       
                                                        
                                        
                                                        
                                                        
                                                       
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
                            
                                </div>
                            </div>

                       <%-- </div>
                        </div>--%>
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


