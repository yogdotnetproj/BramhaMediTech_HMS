<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DoctorWiseCashReport.aspx.cs" Inherits="DoctorWiseCashReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
              <asp:PostBackTrigger ControlID="btnPrintExcel" />
             
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Doctorwise Daily Cash Report</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Doctorwise Daily Cash Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                     <div class="row">
                                         
                                          
                                     <div class="col-sm-2 text-left">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2 text-left">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                 <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1 text-right">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2 text-left">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                 <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                     
                                        
                                    <div class="col-sm-2 text-left">
                                                        <div class="form-group">
                                                        <label for="ddlConsDoctorName">Dr Name:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-3">
                                                <div class="form-group">
                                                    <asp:DropDownList ID="ddlConsDoctorName" runat="server"
                                                         CssClass="form-control form-select" Visible="false" AutoPostBack="true"   TabIndex="14" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                       
                                                         <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtConsDoctorName"
                                                ID="AutoCompleteExtender4"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>                                               
                                                </div>                                                    
                                    </div>
                                         
                                </div>
                             
                               
                                        
                                        
                                    
                                     

                                         
                                    <div class="row mt-3">
                                        <div class="col-sm-2">
                                                          <div class="form-group">
                                                          <label for="ddlBillService">Bill Services:</label>                                                                                
                                        </div>
                                    </div>
                                                    <div class="col-sm-4 text-left">
                                    <div class="form-group">                                     
                                              <asp:DropDownList ID="ddlBillService" runat="server" AutoPostBack="true" CssClass="form-control form-select"
                                                 TabIndex="2" OnSelectedIndexChanged="ddlBillService_SelectedIndexChanged"></asp:DropDownList>
                                   </div>
                                                         </div>
                                        <div class="col-sm-5 text-center">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" CssClass="btn btn-primary"
                                            Text="Search" />
                                            &nbsp;<asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-success" 
                                            OnClick="Print_Click" onclientclick="target = '_blank';" Text="Print" />
                                             &nbsp;<asp:Button ID="btnPrintExcel" runat="server" CausesValidation="False" CssClass="btn btn-warning" 
                                            onclientclick="target = '_blank';" Text="Print Excel" OnClick="btnPrintExcel_Click" />
                                        
                                            &nbsp;<asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" CssClass="btn btn-primary" 
                                            Text="Reset" />
                                        </div>
                                   
                                </div>
                <div class="box-footer mt-3">
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
                                    <%--<asp:BoundField DataField="BillNo" HeaderText="Bill No">                                    
                                     </asp:BoundField>--%>
                                    <asp:BoundField DataField="EntryDate" HeaderText="Bill Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                     
                                     <asp:BoundField DataField="PatRegId" HeaderText="Reg No" />
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">                                     
                                     </asp:BoundField>
                                   
                                     <asp:BoundField DataField="PageType" HeaderText="Age">                                     
                                     </asp:BoundField>
                                      <asp:BoundField DataField="OpdNo" HeaderText="OPD No">                                     
                                     </asp:BoundField>
                                     <asp:BoundField DataField="FileNumber" HeaderText="File Number">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="EmpName" HeaderText="Doctor Name">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="ServiceName" HeaderText="Service Name">                                     
                                     </asp:BoundField>

                                    <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount">                                     
                                     </asp:BoundField>
                                     <asp:BoundField DataField="FollowUpDate" HeaderText="Follow UpDate">                                     
                                     </asp:BoundField>
                                    
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

                                      </div>
                             </div>
               <%-- <div class="box" runat="server" id="List">
                                        
                               
                                         
                                     </div>--%>

                                 
                 
                        </section>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



