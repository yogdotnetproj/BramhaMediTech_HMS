<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DailyIncomeReport.aspx.cs" Inherits="DailyIncomeReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-fles">
                    <h1>Daily Income Report</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Daily Income Report</li>
                    </ol>
                </section>
            <section class="content">   
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                  <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-2">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                               <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>

                                                                
                               
                                        
                                        
                                     </div>
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-sm-8 text-right">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" CssClass="btn btn-primary"
                                            Text="Search" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary" 
                                            OnClick="Print_Click" onclientclick="target = '_blank';" Text="Print" />
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" CssClass="btn btn-primary" 
                                            Text="Reset" />


                                        </div>
                                         <div class="col-sm-2">
                                                             <div class="form-group">
                                                               <label for="lblTotalBill" style="width:160px; font-size: 20px; color: #000080; font-weight: bold;">Total Bill Count:</label>
                                                             </div>
                                                         </div>
                                         <div class="col-sm-2">
                                                             <div class="form-group">
                                                                <asp:Label ID="lblTotalBills" runat="server"  Font-Bold="True" Width="100px" Font-Size="X-Large" ForeColor="#3333CC"></asp:Label>
                                                             </div>
                                                         </div>
                                    </div>
                                </div>
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvDailyCash" runat="server" AllowPaging="True" 
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display"  OnDataBound="OnDataBound"
                                 onrowdatabound="gvDailyCash_RowDataBound" ShowFooter="True" 
                                 ShowHeaderWhenEmpty="True" 
                                 onpageindexchanging="gvDailyCash_PageIndexChanging" PageSize="20">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns>
                                    <asp:BoundField DataField="BillNo" HeaderText="Bill No">
                                    
                                     </asp:BoundField>
                                     <asp:BoundField DataField="EntryDate" HeaderText="Bill Date" DataFormatString="{0:dd/MM/yyyy}" 
                                      />
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" 
                                     />
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                                    
                                     
                                     
                                    
                                     <asp:BoundField DataField="BillServiceCharges" HeaderText="Bill Amount">                                    
                                     </asp:BoundField>
                                     
                                   
                                   
                                    
                                   <asp:BoundField DataField="CashReceivedAmount" HeaderText="Cash Paid"/>
                                   <asp:BoundField DataField="CardReceivedAmount" HeaderText="Card Paid"/>
                                    <asp:BoundField DataField="ChequeReceivedAmount" HeaderText="Cheque Paid"/>
                                      <asp:BoundField DataField="DiscountAmt" HeaderText="Discount"/>
                                    <asp:BoundField DataField="BalanceAmt" HeaderText="Balance"/>
                                    <%--<asp:BoundField DataField="CreatedBy" HeaderText="User Name"/>
                                     <asp:BoundField DataField="DiscType" HeaderText="DiscRemark" />--%>
                                     
                                 </Columns>
                                 <%--<FooterStyle BackColor="#006699" ForeColor="White" />--%>
                                 <FooterStyle  ForeColor="black" />
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
               <%-- <div class="box" runat="server" id="List">
                                        
                               
                                         
                                     </div>--%>

                                 
                 
                        </section>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

