<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="All_InsuranceSummary.aspx.cs" Inherits="All_InsuranceSummary" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
               <asp:PostBackTrigger ControlID="btnExcel" />
         </Triggers>
        <ContentTemplate>
            <section class="content-header">
                <h1>Insurance Patient Summary.</h1>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                            
                            
                                     <div class="col-sm-2" >
                                        <div class="form-group">
                                            <label for="txtStart">From Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2  text-left" >
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off" runat="server" CssClass="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                  <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-sm-1  text-left" >
                                        <div class="form-group">
                                            <label for="txtEnd">To Date:</label>
                                            </div>
                                        </div>
                                     <div class="col-sm-2  text-left" >
                                        <div class="form-group">
                                           
                                             <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                  <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-4 text-left" >
                                        <div class="form-group">
                                            
                                            <div>
                                           <asp:TextBox runat="server" ID="txtInsuranceid" placeholder=" Insurance Company" class="form-control pull-right" AutoPostBack="true"  OnTextChanged="txtInsuranceid_TextChanged"></asp:TextBox>
                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchInsurance"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtInsuranceid"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                            </div>
                                    </div>
                                    <div class="col-sm-12 mt-3" >
                                         <div class="row">
                                                  <div class="col-sm-2 text-left" >
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName" style="text-align:left"> Name/RegNo</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-2 text-left"   >
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter  Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                                  <div class="col-sm-2 text-left" >
                                                        <div class="form-group"> 
                                                  <label for="ddlBillGroup" title="" style="text-align: left">Bill Group</label> 
                                                            </div>
                                                     </div>  
                                                  <div class="col-sm-4 text-left" >
                                                   <div class="form-Inline form-check">                                                              
                                                        <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" class="form-control">
                                                            <asp:ListItem Value="0">---Select Group--</asp:ListItem>
                                                            <asp:ListItem>EMERGENCY</asp:ListItem>
                                                            <asp:ListItem>OPD</asp:ListItem>
                                                            <asp:ListItem>EEG OPD</asp:ListItem>
                                                            <asp:ListItem Value="OPHTHAL">OPHTHAL</asp:ListItem>
                                                            <asp:ListItem>AMBULANCE</asp:ListItem>
                                                            <asp:ListItem>HOSPITAL</asp:ListItem>

                                                            <asp:ListItem>Radiology</asp:ListItem>
                                                            <asp:ListItem>Pathology</asp:ListItem>
                                                            <asp:ListItem>MedicalLab</asp:ListItem>
                                                            <asp:ListItem>Pharmacy</asp:ListItem>
                                                             <asp:ListItem>Consultation</asp:ListItem>
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                                    </div>                                               

                                    <div class="col-sm-2 text-left">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" Visible="false" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" class="btn btn-success" />
                                                &nbsp;<asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-success" 
                                            OnClick="Print_Click" Text="Print" />

                                                &nbsp;<asp:Button ID="btnExcel" runat="server" CausesValidation="False" class="btn btn-warning" 
                                            Text="Excel" OnClick="btnExcel_Click" />
                                       
                                        </div>
                                            </div>
                                    </div>
                                </div>
                                        </div>
                            

                                       
                                <div class="row" runat="server" visible="false">
                                    <div class="col-sm-12">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="PatRegId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="BillGroup" HeaderText="Bill Group" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="CreatedOn" Visible="false" HeaderText="Admission Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                         <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                           <asp:BoundField DataField="InsuranceAmt" HeaderText="Insurance Amt" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="PatientInsuType"  HeaderText="Sponsor " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="Details"  HeaderText="Details " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                       
                                                        
                                                        
                                                       
                                                         
                                                        
                                                       
                                                       
                                                               </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
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
            <script language="javascript" type="text/javascript">
                function OpenReport() {
                    window.open("Reports.aspx");
                }
               </script>
        </ContentTemplate>
    </asp:UpdatePanel>

    
</asp:Content>

