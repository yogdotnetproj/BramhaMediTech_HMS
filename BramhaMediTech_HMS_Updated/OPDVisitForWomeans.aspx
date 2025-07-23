<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalTemp.master" AutoEventWireup="true" CodeFile="OPDVisitForWomeans.aspx.cs" Inherits="OPDVisitForWomeans" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
       <Triggers>
             <asp:PostBackTrigger ControlID="btnReset" />
         </Triggers>
         <ContentTemplate>
             --%>

             <section class="content-header d-flex">
                    <h1>OPD visits for Womeans</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OPD visits for Womeans</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2" >
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-3">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <input id="txtFrom" class="form-control"  type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-2">
                                                             <div class="form-group">
                                                               <label for="txtTo" >To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-3" >
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <input id="txtTo" class="form-control"  type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>

                                        
                                     </div>
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-primary"
                                            Text="Search" />
                                       <%-- <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-primary" 
                                            OnClick="Print_Click" onclientclick="target = '_blank';" Text="Print" />
                                       --%> 
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" class="btn btn-primary" 
                                            Text="Report" />
                                        </div>
                                    </div>
                                </div>
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvDailyCash" runat="server" AllowPaging="True" datakeynames="PatRegId"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                 class="table table-responsive table-sm table-bordered" Width="100%"
                                 HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                                 EmptyDataText="No Records to Display" 
                                 onrowdatabound="gvDailyCash_RowDataBound" ShowFooter="True" 
                                 ShowHeaderWhenEmpty="True" 
                                 onpageindexchanging="gvDailyCash_PageIndexChanging" PageSize="20" OnRowEditing="gvDailyCash_RowEditing">
                                 
                                     <AlternatingRowStyle BackColor="White" />
                                 
                                <Columns>
                                     
                         
                            
                                     <asp:BoundField DataField="EntryDate" HeaderText="Date"  
                                      />
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" 
                                     />
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                      <asp:BoundField DataField="PatientAge" HeaderText="Age">
                                    
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                                  
                                    <asp:BoundField DataField="DeptName" HeaderText="Dept Name">
                                    
                                     </asp:BoundField>
                                     
                                     
                                    
                                    
                                   <%-- <asp:BoundField DataField="CreatedBy" HeaderText="User Name"/>
                                     <asp:BoundField DataField="DiscType" HeaderText="DiscRemark" />
                                     --%>
                            
                                     <asp:TemplateField>
                                         <ItemTemplate>
                                           
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnOpdNo" runat="server" Value='<%#Eval("OpdNo") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                         </ItemTemplate>
                                     </asp:TemplateField>
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
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
     <script language="javascript" type="text/javascript">
         function OpenReport() {

             window.open("Reports.aspx");
         }
               </script>
</asp:Content>



