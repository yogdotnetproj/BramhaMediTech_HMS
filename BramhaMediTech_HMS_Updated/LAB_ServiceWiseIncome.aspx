<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="LAB_ServiceWiseIncome.aspx.cs" Inherits="LAB_ServiceWiseIncome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >--%>
        <%-- <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
              <asp:PostBackTrigger ControlID="btnradiologyprint" />
             <asp:PostBackTrigger ControlID="btncharge" />
              <asp:PostBackTrigger ControlID="btnprintexcel" />
              <asp:PostBackTrigger ControlID="btnsummaryreportExcel" />
         </Triggers>--%>
        <%-- <ContentTemplate>--%>
             

             <section class="content-header d-flex">
                    <h1>LAB ServiceWise Income Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">LAB ServiceWise Income Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" CssClass="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-1 pr-0">
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
                                          <div class="col-sm-1">
                                                             <div class="form-group">
<asp:DropDownList ID="ddlTimeFrom" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                                                 </div>
                                             </div>
                                                   
                                     <div class="col-sm-1">
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
                                          <div class="col-sm-1">
                                                             <div class="form-group">
<asp:DropDownList ID="ddlTimeTo" runat="server" CssClass="form-control form-select"></asp:DropDownList>
                                                                 </div>
                                             </div>
                                         
                                 
                                          <div class="col-sm-1 p-0">
                                                        <div class="form-group">
                                                      <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-warning"
                                            Text="Search" />                                                                                                                                                                                        
                                                        </div>
                                                    </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlBillGroup" Visible="false" runat="server"  TabIndex="2" CssClass="form-control form-select">                                                      
                                                        <asp:ListItem Value="0">Select Group</asp:ListItem>
                                                        <asp:ListItem Value="P">Pathology</asp:ListItem>
                                                        <asp:ListItem Value="R">Radiology</asp:ListItem>
                                                        <asp:ListItem Value="M">Medical LAB</asp:ListItem>
                                                         <asp:ListItem  Value="C">Cardiology</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>                                                    
                                    </div>
                                        </div>
                                       <div class="col-lg-12 mt-3" runat="server" >
                                    <div class ="row">
                                        <div class="col-sm-4" >
                                            <div class="form-group">
                                           <div class="form-Inline form-check text-center " > 
                                                         <asp:RadioButtonList ID="RdbServices" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RdbServices_SelectedIndexChanged"   >
                                                             <asp:ListItem  Value="OPD" Selected="True">OPD</asp:ListItem>
                                                             <asp:ListItem  Value="IPD">IPD</asp:ListItem>
                                                             <asp:ListItem  Value="Diagnostics">Diagnostics</asp:ListItem>                                                           
                                                              <asp:ListItem  Value="Pharmacy">Pharmacy</asp:ListItem>
                                                             </asp:RadioButtonList>  
                                                        </div>
                                        </div>
                                           </div>
                                        <div id="Div2" class="col-lg-2 " runat="server" >
                                    <div class ="row">
                                        <asp:DropDownList runat="server" ID="GroupTyp" CssClass="form-control pull-left form-select">
                                            <%--<asp:ListItem Value="All"> All</asp:ListItem>
                                            <asp:ListItem Value="EMERGENCY"> EMERGENCY</asp:ListItem>
                                            <asp:ListItem Value="Procedures Fees">Procedures Fees</asp:ListItem>
                                            <asp:ListItem Value="Consultation">Consultations</asp:ListItem>
                                            <asp:ListItem Value="Operating Theatre">Operating Theatre</asp:ListItem>
                                            <asp:ListItem Value="Emergency Room">Emergency Room</asp:ListItem>
                                            <asp:ListItem Value="Doctor Fees">Doctor Fees</asp:ListItem>
                                            <asp:ListItem Value="Daily Rate">Daily Rate</asp:ListItem>
                                            <asp:ListItem Value="Hospital">Hospital</asp:ListItem>
                                            <asp:ListItem Value="Lab Procedures">Lab Procedures</asp:ListItem>
                                             <asp:ListItem Value="OutPatient">OutPatient Pharmacy</asp:ListItem>
                                             <asp:ListItem Value="InPatient">InPatient Pharmacy</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        </div>
                                           </div>
                                         <div id="Div3" class="col-lg-1 " runat="server" >
                                    <div class ="row">
                                         <asp:Button ID="btnAllPrint" runat="server" class="btn btn-success"
                                            Text="Print" OnClick="btnAllPrint_Click" /> 
                                      
                                        </div>
                                             </div>
                                         <div id="Div4" class="col-lg-1 " runat="server" >
                                    <div class ="row">
                                          <asp:Button ID="brnAllPrintExcel" runat="server" class="btn btn-warning"
                                            Text="Print Excel" OnClick="brnAllPrintExcel_Click" /> 
                                        </div>
                                             </div>
                                     </div>
                                           </div>
                                       
                                     </div>
                              <div class="col-lg-12 mt-3" runat="server" id="Diag" >
                                    <div class ="row">
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvGroup" runat="server" AllowPaging="True" DataKeyNames="BillGroup"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display" ShowFooterWhenEmpty="True"  ShowFooter=" True"
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="20" OnRowCommand="gvGroup_RowCommand">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns> 
                                     <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                      <asp:ButtonField CommandName="ReportExcel" Text="Excel" ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                   
                                    
                                    <asp:BoundField DataField="BillGroup" HeaderText="Group Name">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="TotalCharges" HeaderText="Total Charges" DataFormatString="{0:N2}" >
                                     
                                     </asp:BoundField>
                                      
                                     
                                    
                                          
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

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center mt-3">
                                          
                                             <asp:Button ID="btnPrint" runat="server"  CausesValidation="False" class="btn btn-success" 
                                            OnClick="Print_Click"  Text=" Report" />
                                             <asp:Button ID="btnprintexcel" runat="server"  CausesValidation="False" class="btn btn-primary" 
                                            Text=" Report Excel" OnClick="btnprintexcel_Click" />
                                           
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                  </div>
                               <div class="col-lg-12 mt-3" runat="server" id="OPDPr" >
                                    <div class ="row">
                                         <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvGroupOP" runat="server" AllowPaging="True" DataKeyNames="BillGroup"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display" ShowFooterWhenEmpty="True"  ShowFooter=" True"
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="20" OnRowCommand="gvGroupOP_RowCommand">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns> 
                                     <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                    <asp:ButtonField CommandName="ReportExcel" Text="Excel" ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                   
                                    
                                    <asp:BoundField DataField="BillGroup" HeaderText="Group Name">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="TotalCharges" HeaderText="Total Charges" DataFormatString="{0:N2}" >
                                     
                                     </asp:BoundField>
                                      
                                     
                                    
                                          
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
                             <div class="col-lg-12 mt-3">
                                    <div class="row">
                                        <div class="col-sm-12 text-center ">
                                          <asp:Button ID="btnPrintOPD" runat="server"  class="btn btn-success"
                                            Text="Print OP" OnClick="btnPrintOPD_Click" />
                                             <asp:Button ID="btnPrintOPDEX" runat="server"  class="btn btn-warning"
                                            Text="EXCEL OP" OnClick="btnPrintOPDEX_Click"  />
                                       
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                   </div>
                                        
                                      <div class="col-lg-12 mt-3" runat="server" id="IPDPro" >
                                    <div class ="row">
                                                           <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvGroupIPD" runat="server" AllowPaging="True" DataKeyNames="BillGroupId"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display" ShowFooterWhenEmpty="True"  ShowFooter=" True"
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="50" OnRowCommand="gvGroupIPD_RowCommand">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns> 
                                     <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                     <asp:ButtonField CommandName="ExcelReport" Text="Excel"  ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                    <asp:BoundField DataField="BillGroupId" HeaderText="Group Id">                                    
                                     </asp:BoundField>
                                    
                                    
                                    <asp:BoundField DataField="GroupName" HeaderText="Group Name">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="TotalCharges" HeaderText="Total Charges" DataFormatString="{0:N2}" >
                                     
                                     </asp:BoundField>
                                      
                                     
                                    
                                          
                                 </Columns>
                               
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
                                         <div class="col-lg-12 mt-3">
                                    <div class="row">
                                        <div class="col-sm-12 text-center ">
                                          <asp:Button ID="btnIPDPrint" runat="server"  class="btn btn-success"
                                            Text="Print IP" OnClick="btnIPDPrint_Click" />
                                             <asp:Button ID="btnIPDPrintExcel" runat="server"  class="btn btn-warning"
                                            Text="Excel IP" OnClick="btnIPDPrintExcel_Click"  />
                                       
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                          </div>

                             <div class="col-lg-12 mt-3" runat="server" id="Phar" >
                                    <div class ="row">
                                      <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="GVPharmaIn" runat="server" AllowPaging="True" DataKeyNames="BillGroupId"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display" ShowFooterWhenEmpty="True"  ShowFooter=" True"
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="20" OnRowCommand="GVPharmaIn_RowCommand">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns> 
                                     <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                    <asp:ButtonField CommandName="ReportExcel" Text="Excel" ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                   
                                    
                                    <asp:BoundField DataField="BillGroup" HeaderText="Group Name">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="TotalCharges" HeaderText="Total Charges"  >
                                     
                                     </asp:BoundField>
                                      
                                     
                                    
                                          
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
                                         <div class="col-lg-12 mt-3">
                                    <div class="row">
                                        <div class="col-sm-12 text-center ">
                                          <asp:Button ID="btnPrintPharmacy" runat="server"  class="btn btn-success"
                                            Text="Print Pharmacy" OnClick="btnPrintPharmacy_Click" />
                                             <asp:Button ID="btnPrintPharmacyExcel" runat="server"  class="btn btn-warning"
                                            Text="Excel Pharmacy" OnClick="btnPrintPharmacyExcel_Click"   />
                                       
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
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>



