<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OTBookingReport.aspx.cs" Inherits="OTBookingReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>

        <ContentTemplate>
             
            <section class="content-header d-flex">
                    <h1>Patient OT Booking Report</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Patient OT Booking Report</li>
                    </ol>
                </section>
      <section class="content">
                      <div class="box" runat="server" id="show">
                             <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                             <div class="box-body">
                                    <div class="row">                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">From Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div>
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtToDate">To Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div> 
                                        
                                               
                                       <div class="col-sm-4">                                    
                                              <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success"   OnClick="btnSearch_Click" Text="Search"/>
                                           <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning"   OnClick="btnPrint_Click" Text="Print" />
                                             
                                        </div>
 
                                            
                                      
                                    </div>
                                </div>
                             
                                    
                                        
                                   
                      
                             <div class="box-body">
                                   <div class="table-responsive" style="width:100%">          
                     
                                    <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="BookId"
                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"                                    
                                    CellPadding="3" AllowPaging="True" BackColor="White"
                                     BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    OnPageIndexChanging="gvPatientInfo_PageIndexChanging" PageSize="10" ShowHeaderWhenEmpty="True"
                                    TabIndex="27">
                            
                                        <Columns>             
                                 <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                       
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="PatAgeType" HeaderText="Age Type" ItemStyle-Width="50" >
                                                       
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" ItemStyle-Width="50" >
                                                       
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OperationName" HeaderText="Operation Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="SurganName" HeaderText="Surgan Name" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="CreatedOn" HeaderText="OT Reg Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                             <asp:BoundField DataField="ScheduleSurgeryDate" HeaderText="Schedule Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                        
                                                        <asp:BoundField DataField="EstimatedCost" HeaderText="EstimatedCost" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="NonRefDeposit" HeaderText="NonRef Deposit" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>                               
                               
                               
                                           
                               
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
      </section>
             <script language="javascript" type="text/javascript">
                 function OpenReport() {
                     window.open("Reports.aspx");
                 }
               </script>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>


