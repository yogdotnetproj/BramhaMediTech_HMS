<%@ Page Title="Patients" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="ListPatients.aspx.cs" Inherits="ListPatients" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>EMR Patient Lists</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">EMR Patient Lists</li>
                    </ol>
            </section>
            <section class="content">
                <div class="box" runat="server">
                    <div class="box-body">
                        <div class="row mb-3">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                           <%-- <label for="txtStart">Start Date:</label>--%>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                 <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                            </div>
                                        </div>
                                    </div>
                                   
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <%--<label for="txtEnd">End Date:</label>--%>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off"  runat="server" class="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                            </div>
                                            <%-- <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Date" ForeColor="Red" runat="server"
                                                ControlToValidate="txtStart" ControlToCompare="txtEnd" Operator="LessThanEqual" Type="Date"
                                                ErrorMessage="Start date must be less than End date."></asp:CompareValidator>--%>
                                        </div>
                                    </div>
                                                                
                                      <div class="col-sm-3">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="false" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient1"                                                
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
                                    
                                    <div class="col-sm-3 text-left">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtOpdNo" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Reg No."
                                                 ></asp:TextBox>
                                               
                                             </div>
                                        </div>
                                    
                                
                         </div>

                                <div class="row mb-3">
                                     
                                                   <div class="col-sm-3">
                                                    <div class="form-group">     
                                                        <asp:DropDownList ID="ddlConsDoctorName" runat="server"
                                                         CssClass="form-control form-select"  AutoPostBack="true"   TabIndex="14" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                    
                                                <div class="col-sm-3">
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlDepartment" runat="server"  AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="18">
                                                            </asp:DropDownList>                   
                                                        
                                                    </div>
                                                </div> 
                                      <div class="col-sm-2">
                                                            <div class="form-group form-check">            
                                                                <asp:RadioButtonList id="PType"  runat="server" RepeatDirection="Horizontal" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="PType_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">OPD</asp:ListItem>
                                                                    <asp:ListItem>IPD</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                </div>
                                          </div>

                                    <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" class="btn btn-success" />
                                        </div>
                                            </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblMsg" Font-Bold="true" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                                <div class="row" id="GVOP" runat="server">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="table-responsive patientListDataTable" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="RegId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True" OnRowDataBound="gvPatientInfo_RowDataBound">
                                                    
                                                       <Columns>  
                                                        <asp:ButtonField CommandName="Select" Text="Select" HeaderText="Select" ItemStyle-Width="50" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" />
                                                                                               
                                                        <asp:BoundField DataField="RegId" HeaderText="Reg Id" ItemStyle-Width="50" Visible="True" />
                                                        <asp:BoundField DataField="OpdNo" HeaderText="OpdNo" ItemStyle-Width="50" />
                                                        <asp:BoundField DataField="TokenNo" HeaderText="TokenNo" />
                                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                                        <asp:BoundField DataField="DrName" HeaderText="Dr.Name" />
                                                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                                          <asp:BoundField DataField="VisitingNo" HeaderText="Visiting No" />
                                                        <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                                           <asp:BoundField DataField="IsPatientChecked"  HeaderText="Triage Status"   />
                                                           <asp:TemplateField HeaderText="Refer Dr" Visible="false">
                                                            <ItemTemplate>
                                                               
                                                                <asp:TextBox ID="txtConsDoctorName1" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter refer dr"
                                                Width="150px"   onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtConsDoctorName1"
                                                ID="AutoCompleteExtender4"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Handover Patient">
                                                            <ItemTemplate>
                                                               
                                                                <asp:TextBox ID="txtConsDoctorName2" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Handover another Dr"
                                                Width="150px"   onkeyPress="return alpha_only(event);" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtConsDoctorName2"
                                                ID="AutoCompleteExtender5"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:ButtonField CommandName="Refer" Text="Action" HeaderText="Action" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                            <asp:ButtonField CommandName="OPDRep" Text="Report" HeaderText="Report" ControlStyle-CssClass="btn btn-danger" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                            <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnIVisitingNo" runat="server" Value='<%#Eval("VisitingNo") %>' />
                                             <asp:HiddenField ID="hdnIsPatientChecked" runat="server" Value='<%#Eval("IsPatientChecked") %>' />
                                              <asp:HiddenField ID="hdnTriageCriteria" runat="server" Value='<%#Eval("TriageCriteria") %>' />
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
                                          <div class="row" runat="server" id="GVIP" >
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="GVIPD" runat="server" AutoGenerateColumns="False" DataKeyNames="IpdId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="GVIPD_RowCommand" OnPageIndexChanging="GVIPD_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         <asp:ButtonField CommandName="Select" Text="Select" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="IpdNo" HeaderText="IpdNo" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="Empname" HeaderText="Dr.Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="DateOfAdmission" HeaderText="Admission Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                         <asp:BoundField DataField="CreatedBy" HeaderText="User Name" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:ButtonField CommandName="Report" Text="Report" Visible="false" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                         <asp:ButtonField CommandName="Summary" Text="Summary" Visible="false" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>


                                                           <asp:ButtonField CommandName="Discharge" Text="Disc summary" Visible="false" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                       <%-- <asp:HyperLinkField Text="Get" DataNavigateUrlFields="RegId,OpdNo,Name,EntryDate"
                                                            DataNavigateUrlFormatString="frmTreatment.aspx?id={0}&opd={1}&Name={2}&EntryDate={3}" />--%>
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
     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>

    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Label ID="lblMsg" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-md-2 col-md-offset-2">
                                <label for="txtFromDate">From date: </label>
                                <asp:TextBox class="form-control" ID="txtFromDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender PopupButtonID="txtFromDate" CssClass="AjaxCalendar"
                                    Format="dd/MM/yyyy" TargetControlID="txtFromDate" ID="CalendarExtendertxtFromDate" runat="server">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-md-2">
                                <label for="txtToDate">To date: </label>
                                <asp:TextBox class="form-control" ID="txtToDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender PopupButtonID="txtToDate" CssClass="AjaxCalendar"
                                    Format="dd/MM/yyyy" TargetControlID="txtToDate" ID="CalendarExtendertxtToDate" runat="server">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnSearch" CausesValidation="true" class="btn btn-primary btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

