<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillGroupWiseIncomeReport.aspx.cs" Inherits="BillGroupWiseIncomeReport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        
         <ContentTemplate>--%>
             
    
             <section class="content-header d-flex">
                    <h1>BillGroupWise Income Report</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">BillGroupWise Income Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" CssClass="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2 pr-0">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-3">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                             
                               <div class="col-lg-12 mt-3">
                                    <div class ="row">
                                    <div class="col-sm-2">
                                                        <div class="form-group">
                                                        <label>Report:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                         <div class="col-sm-8">
                                       <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbServices" runat="server" RepeatDirection="Horizontal"   >
                                                             <asp:ListItem  Value="PatientWise" Selected="True">PatientWise</asp:ListItem>
                                                             <asp:ListItem  Value="ServiceWise">ServiceWise</asp:ListItem>
                                                             <asp:ListItem  Value="DoctorWise" >DoctorWise</asp:ListItem>                                                           
                                                             <asp:ListItem  Value="DoctorWisesingle" >DoctorWise single</asp:ListItem> 
                                                             </asp:RadioButtonList>  
                                                        </div>
                                             </div>
                                       
                                    <div class="col-sm-2">
                                                        <div class="form-group">
                                                             <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-success"
                                            Text="Search" />
                                                            </div>
                                        </div>
                                         </div>
                               </div>
                                        
                                        
                                     </div>
                                     </div>

                                        
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvGroup" runat="server" AllowPaging="True" DataKeyNames="BillGroupId"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display" ShowFooterWhenEmpty="True"  ShowFooter=" True"
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="20" OnRowCommand="gvGroup_RowCommand">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns> 
                                     <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                     <asp:ButtonField CommandName="ExcelReport" Text="Excel" ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
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
                             <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center ">
                                          <asp:Button ID="btnPrint" runat="server" onclick="btnPrint_Click" class="btn btn-success"
                                            Text="Print" />
                                             &nbsp;<asp:Button ID="btnExcel" runat="server"  class="btn btn-warning"
                                            Text="Excel" OnClick="btnExcel_Click" />
                                       
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

