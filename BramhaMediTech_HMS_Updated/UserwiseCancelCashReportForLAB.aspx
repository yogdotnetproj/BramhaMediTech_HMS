<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="UserwiseCancelCashReportForLAB.aspx.cs" Inherits="UserwiseCancelCashReportForLAB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>
         <ContentTemplate>
             --%>

             <section class="content-header d-flex">
                    <h1>Userwise LAB Cancel Report</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Userwise LAB Cancel Report</li>
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
                                          <div class="col-sm-1 p-0">
                                                        <div class="form-group">
                                                        <label for="ddlBillGroup">Bill Group:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlBillGroup" runat="server"  TabIndex="2" CssClass="form-control form-select">                                                      
                                                        <asp:ListItem Value="0">Select Group</asp:ListItem>
                                                        <asp:ListItem Value="P">Pathology</asp:ListItem>
                                                        <asp:ListItem Value="R">Radiology</asp:ListItem>
                                                        <asp:ListItem Value="M">Medical LAB</asp:ListItem>
                                                         <asp:ListItem  Value="C">Cardiology</asp:ListItem>
                                                        
                                                    </asp:DropDownList>
                                                </div>                                                    
                                    </div>
                                        
                                        
                                    
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:DropDownList ID="ddlUser" runat="server"  TabIndex="2" CssClass="form-control form-select" />                                                      
                                                </div>                                                    
                                    </div>
                             </div>
                                      <div class="row mt-3">   
                                 <div class="col-sm-8 text-center" >
                                     <div class="form-group">
                                                       
                                      <div class="form-Inline form-check"> 
                                           <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"  >
                                       </asp:RadioButtonList>                                                
                      
                                                        
                                                        
                                        </div>
                                         </div>
                               </div>
                                         <div class="col-sm-4">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" class="btn btn-primary btnSearch" />
                                               
                                       
                                        </div>
                                            </div>
                                    </div>
                                        
                                        
                                     </div>
                                     </div>
                             <div class="row">
                                    <div class="col-lg-12 mt-3">
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
                                                        
                                                        <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
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
                                                           <asp:BoundField DataField="ReceivedAmount" HeaderText="Received Amt" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="PatientInsuType"  HeaderText="Sponsor " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="CancelBy"  HeaderText="Cancel By " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                           <asp:BoundField DataField="CancelOn"  HeaderText="Cancel On " ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />

                                                         </asp:BoundField>
                                                        
                                                         <asp:ButtonField CommandName="Print" Text="Print"  ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnBillNo" runat="server" Value='<%#Eval("BillNo") %>' />
                                             <asp:HiddenField ID="HdnFId" runat="server" Value='<%#Eval("FId") %>' />
                                             <asp:HiddenField ID="HdnLabNo" runat="server" Value='<%#Eval("LabNo") %>' />
                                             <asp:HiddenField ID="HdnBranchId" runat="server" Value='<%#Eval("BranchId") %>' />
                                              <asp:HiddenField ID="HdnPatRegId" runat="server" Value='<%#Eval("PatRegId") %>' />
                                              <%--<asp:HiddenField ID="HdnLabPType" runat="server" Value='<%#Eval("LabPType") %>' />--%>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                                       
                                                         
                                                       
                                                         
                                                        
                                                       
                                                       
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
                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 mt-3 text-center ">
                                          
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-primary" 
                                            OnClick="Print_Click"  Text="Print" />
                                               
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" class="btn btn-primary" 
                                            Text="Reset" />
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



