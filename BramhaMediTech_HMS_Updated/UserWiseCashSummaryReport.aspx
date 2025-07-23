<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="UserWiseCashSummaryReport.aspx.cs" Inherits="UserWiseCashSummaryReport" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Daily Cash Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Daily Cash Report</li>
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

                                     <div class="col-sm-2" runat="server" visible="false">
                                    <div class="form-group"> 
                                        <label CssClass="control-label" >
                                                    Patient Name
                                                  </label> 
                                     
                                    </div>
                                 </div>
                                <div class="col-sm-2" runat="server" visible="false">
                                    <div class="form-group">                                        
                                      <asp:TextBox ID="txtPatientName" runat="server" AutoPostBack="True" CssClass="form-control" ontextchanged="txtPatientName_TextChanged" TabIndex="1" ></asp:TextBox>
                                        <%--<asp:autocompletextender  ServiceMethod="SearchPatient" MinimumPrefixLength="1"  EnableCaching="false" CompletionSetCount="1" 
                                        CompletionInterval="5" ID="AutoCompleteExtender2" TargetControlID="txtPatientName" runat="server"></asp:autocompletextender>
                                        --%> 
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
                                        
                                        
                                    <div class="col-sm-2">
                                                        <div class="form-group">
                                                        <label for="ddlUser">UserName:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select"
                                                        OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" />                                                      
                                                </div>                                                    
                                    </div>
                             
                               <div class="col-lg-12 mt-3" >
                                   
                                       <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                                             <asp:ListItem  Value="Cash">Cash</asp:ListItem>
                                                             <asp:ListItem  Value="Cheque">Cheque</asp:ListItem>
                                                             <asp:ListItem  Value="Card">Card</asp:ListItem>                                                            
                                                             <asp:ListItem  Value="All">All</asp:ListItem>
                                                             </asp:RadioButtonList>  
                                                        </div>
                                        
                               </div>
                                        
                                        
                                     </div>
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 mt-3 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-primary"
                                            Text="Search" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-success" 
                                            OnClick="Print_Click" onclientclick="target = '_blank';" Text="Print" />
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" class="btn btn-warning" 
                                            Text="Reset" />
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
                               EmptyDataText="No Records to Display" 
                                 onrowdatabound="gvDailyCash_RowDataBound" ShowFooter="True" 
                                 ShowHeaderWhenEmpty="True" 
                                 onpageindexchanging="gvDailyCash_PageIndexChanging" PageSize="20">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns> 
                                    <asp:BoundField DataField="BillNo" HeaderText="Bill No">                                    
                                     </asp:BoundField>
                                    <asp:BoundField DataField="EntryDate" HeaderText="Bill Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                     
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" />
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                                   
                                   <asp:BoundField DataField="PaymentDate" HeaderText="Transaction Date" DataFormatString="{0:dd/MM/yyyy}" 
                                      />  
                                     
                                    
                                     <asp:BoundField DataField="BillServiceCharges" HeaderText="Bill Amount">
                                    
                                     </asp:BoundField>
                                     
                                   
                                   
                                    
                                    <asp:BoundField DataField="DiscountAmt" HeaderText="Discount"/>
                                   
                                    <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Received"/>
                                     
                                    <asp:BoundField DataField="BalanceAmt" HeaderText="Balance"/>
                                    <asp:BoundField DataField="CreatedBy" HeaderText="User Name"/>
                                     <asp:BoundField DataField="DiscType" HeaderText="DiscRemark" />
                                     
                                 </Columns>
                                 <%--<FooterStyle BackColor="#006699" ForeColor="White" />--%>
                                 <FooterStyle  ForeColor="black" />
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
               <%-- <div class="box" runat="server" id="List">
                                        
                               
                                         
                                     </div>--%>

                                 
                 
                        </section>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

