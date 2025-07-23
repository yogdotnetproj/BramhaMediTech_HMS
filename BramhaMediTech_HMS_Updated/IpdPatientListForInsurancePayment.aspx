<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IpdPatientListForInsurancePayment.aspx.cs" Inherits="IpdPatientListForInsurancePayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1> IPD Patient List For Insurance Payment</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">IPD Patient List For Insurance Payment</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                            
                            
                                     <div class="col-sm-1">
                                        <div class="form-group">
                                            <label for="txtStart">From Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off"  runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                   <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-sm-1">
                                        <div class="form-group">
                                            <label for="txtEnd">To Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                               <div class="col-sm-1">
                                                        <div class="form-group"> 
                                                            <label for="ddlRoomCategory">Room Category:</label>                                                                                                                                                                                              
                                                         </div>
                                               </div>
                                                <div class="col-sm-2">
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlRoomCategory" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="18">
                                                            </asp:DropDownList>                   
                                                        
                                                    </div>
                                                </div> 
                              <div class="col-sm-3 text-left">
                                                        <div class="form-group"> 
                                                                             
                                                                <asp:RadioButtonList ID="rblPatcate" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True"  ForeColor="Red" Font-Bold="True" Font-Size="Medium" OnSelectedIndexChanged="rblPatcate_SelectedIndexChanged" >
                                                             <asp:ListItem Selected="True" Value="1" >Paying</asp:ListItem>
                                                             <asp:ListItem Value="2">Insurance</asp:ListItem>                                                            
                                                             <asp:ListItem Value="3">Charge</asp:ListItem>
                                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                         
                                                             </asp:RadioButtonList>      
                                                       </div>
                                                    </div>
                                    <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                                  <div class="col-sm-1">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Name/RegNo</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-3">
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
                                                <div class="col-sm-3 text-left">
                                                    <div class="form-group">  
                                                             <asp:TextBox ID="ddlPatientSubCategoryName1" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter  Insurance(*)"
                                                AutoPostBack="True" ontextchanged="ddlPatientSubCategoryName1_TextChanged" Font-Bold="True" Font-Size="Medium"  ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchSubCategory"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                    CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="ddlPatientSubCategoryName1"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>          
                                                       
                                                    </div>
                                                </div> 
                                             <div class="col-sm-1 pr-0">
                                                             <div class="form-group">
<asp:RadioButtonList ID="RblType" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Selected="True" Value="0">Due</asp:ListItem>
    <asp:ListItem Value="1">All</asp:ListItem>
                                                                 </asp:RadioButtonList>
                                                                 </div>
                                             </div>
                                    <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" Visible="false" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-success btnSearch" />
                                        </div>
                                            </div>
                                    </div>
                                              <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnReport"  runat="server" Text="Report" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-warning btnSearch" OnClick="btnReport_Click" />
                                        </div>
                                            </div>
                                    </div>
                                             <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnexcel"  runat="server" Text="Excel" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-danger btnSearch" OnClick="btnexcel_Click"  />
                                        </div>
                                            </div>
                                    </div>
                                </div>
                                <div class="row" runat="server" visible="false">
                                    <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="IpdId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         <asp:ButtonField CommandName="Select" Text="Select" HeaderText="select" Visible="false" ControlStyle-CssClass="btn btn-success" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="IpdNo" HeaderText="IpdNo" ItemStyle-Width="60" >
                                                        
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
                                                         <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:ButtonField CommandName="Report" Text="Report" HeaderText="Report" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                         <asp:ButtonField CommandName="Summary" Text="Summary" HeaderText="Summary" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                       <%-- <asp:HyperLinkField Text="Get" DataNavigateUrlFields="RegId,OpdNo,Name,EntryDate"
                                                            DataNavigateUrlFormatString="frmTreatment.aspx?id={0}&opd={1}&Name={2}&EntryDate={3}" />--%>
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
                </div>
            </section>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

<script language="javascript" type="text/javascript">
    function OpenReport() {
        window.open("Reports.aspx");
    }
               </script> 
</asp:Content>

