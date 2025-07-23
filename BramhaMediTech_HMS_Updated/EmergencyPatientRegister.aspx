<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EmergencyPatientRegister.aspx.cs" Inherits="EmergencyPatientRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <asp:PostBackTrigger ControlID="btnReport" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Emergency Patient Register</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="bredcrumb-item active">Emergency Patient Register</li>
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
                                                           <input id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1 p-0">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <input id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>

                                     <div class="col-sm-2">
                                    <div class="form-group"> 
                                        <label CssClass="control-label" >
                                                    Patient Name
                                                  </label> 
                                     
                                    </div>
                                 </div>
                                <div class="col-sm-3">
                                    <div class="form-group">                                        
                                      <asp:TextBox ID="txtPatientName" runat="server" AutoPostBack="True" CssClass="form-control" ontextchanged="txtPatientName_TextChanged" TabIndex="1"  Font-Bold="True" Font-Size="Larger" ></asp:TextBox>
                                        <%--<asp:autocompletextender  ServiceMethod="SearchPatient" MinimumPrefixLength="1"  EnableCaching="false" CompletionSetCount="1" 
                                        CompletionInterval="5" ID="AutoCompleteExtender2" TargetControlID="txtPatientName" runat="server"></asp:autocompletextender>
                                        --%> 
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
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                    </div>
                                </div>
                                        
                                        
                                    
                             
                               <div class="col-lg-12 mt-3">
                                    <div class ="row">
                                        <div class="col-sm-2">
                                                        <div class="form-group">
                                                        <label for="txtMobileNo">Mobile No:</label>                                                                                                                                                                                              
                                                        </div>
                                                    </div>
                                    <div class="col-sm-2">
                                                <div class="form-group">
                                                       
                                                    <asp:TextBox ID="txtMobileNo" runat="server"  TabIndex="2" Class="form-control" />                                                      
                                                </div>                                                    
                                    </div>
                                        <div class="col-sm-2">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">Department:</label> 
                                                             </div>
                                                         </div>     
                                   <div class="col-sm-2">
                                    <div class="form-group">               
                                         <asp:DropDownList ID="ddldeptname" runat="server" CssClass="form-control form-select"></asp:DropDownList></td>
                                    
                                </div>
                                        </div>
                               </div>
                                        
                                        
                                     </div>
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-sm-12 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-primary"
                                            Text="Search" />
                                          <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" class="btn btn-success" 
                                            Text="Reset" />
                                            <asp:Button ID="btnReport" runat="server" onclick="btnReport_Click" class="btn btn-warning"
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
                                 ShowFooter="True" 
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="20" OnPageIndexChanging="gvDailyCash_PageIndexChanging" >
                                 
                                    <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                 
                                <Columns>
                                     
                                   <asp:BoundField DataField="PatRegId" HeaderText="Reg No" 
                                     />
                                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                     
                                     </asp:BoundField>
                                     <asp:BoundField DataField="GenderName" HeaderText="Gender">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="Age" HeaderText="Age">
                                     
                                     </asp:BoundField>
                                     <asp:BoundField DataField="PatientAddress" HeaderText="Address">
                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                    
                                     </asp:BoundField>
                           
                           
                                    <asp:BoundField DataField="EntryDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                      />
                                   <asp:BoundField DataField="chiefcomplaints" HeaderText="Chief Complaints">
                                    
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis">
                                    
                                     </asp:BoundField>
                                 </Columns>
                                 <%--<FooterStyle BackColor="#006699" ForeColor="White" />--%>
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
                 
                        </section>
         </ContentTemplate>
    </asp:UpdatePanel>
     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script>
</asp:Content>

