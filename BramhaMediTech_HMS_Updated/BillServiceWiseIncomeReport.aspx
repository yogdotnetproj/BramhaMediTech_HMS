<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillServiceWiseIncomeReport.aspx.cs" Inherits="BillServiceWiseIncomeReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        
         <ContentTemplate>--%>
             

             <section class="content-header  d-flex">
                    <h1>BillserviceWise Income Report</h1>
                     <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">BillserviceWise Income Report</li>
                    </ol>
                </section>
            <section class="content">               
                                        
                
                         <div class="box" runat="server" id="Panel3">

                             <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                   </div>
                            
                              
                                 <div class="box-body">  
                                      <div class="col-lg-12 mt-3">
                                   
                                     <div class="row">
                                         
                                          
                                     <div class="col-lg-2 text-left" >
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom"  >From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-lg-2 text-left">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control"  type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-lg-2 text-right" >
                                                             <div class="form-group">
                                                               <label for="txtTo" >To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-lg-2 text-left" >
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control"  type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                                         </div>
                                          </div>
                                         <div class="col-lg-12 mt-3">
                                             <div class="row">
                                                 <div class="col-lg-2 text-left" >
                                                        <div class="form-group"> 
                                                  <label for="ddlBillGroup" title="" style="text-align: left">Bill Group</label> 
                                                            </div>
                                                     </div>  
                                                   <div class="col-lg-4 text-left" >
                                                    <div class="form-group">                                                              
                                                        <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" class="form-control"
                                                         OnSelectedIndexChanged="ddlBillGroup_SelectedIndexChanged" 
                                                         TabIndex="18">
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                                    </div>                                               

                                                 <div class="col-lg-2 text-left" >
                                                        <div class="form-group"> 
                                                  <label for="txtBillServices" title="" style="text-align: left">Bill Service</label> 
                                                            </div>
                                                     </div>  
                                                 <div class="col-lg-3 text-left" >
                                                        <div class="form-group">                                                          
                                                        <asp:DropDownList ID="ddlBillServices" visible="false" runat="server" AutoPostBack="True" CssClass="custom"
                                                      Width="240px" height="30px" 
                                                         TabIndex="10" >
                                                        </asp:DropDownList> 
                                                             <asp:TextBox ID="txtBillServices" runat="server" AutoCompleteType="None"   CssClass="form-control" placeholder="Enter Service Name(*)"
                                                            AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtBillServices_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender  
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAllService"                                                
                                                CompletionInterval="10"
                                                EnableCaching="false" 
                                                CompletionSetCount="1"
                                                UseContextKey="true"
                                                TargetControlID="txtBillServices"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                            </div>
                                                     </div> 
                                                 </div>
                                             </div>
                                                  <div class="col-lg-12 mt-3">
                                             <div class="row">
                                                   <div class="col-lg-2 text-left" >
                                                        <div class="form-group"> 
                                                                <label style="text-align:left">Doctor Name </label>                                                                                                                                                                                            
                                                         </div>
                                                      </div>
                                                   <div class="col-lg-4 text-left" >
                                                    <div class="form-group">
                                                       
                     <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Select Doctor Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtConsDoctorName"
                                                ID="AutoCompleteExtender4"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                   </div>  
                                                  <div class="col-lg-2 text-left" >
                                                    <div class="form-group">
                                                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" class="btn btn-success"
                                            Text="Search" />
                                                        </div>
                                                      </div>
                                             </div>
                                     </div>
                                         </div>
                             
                                               
                                        
                                        
                                    
                                    

                                        
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvGroup" runat="server" AllowPaging="True" DataKeyNames="BillServiceId"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                               EmptyDataText="No Records to Display" ShowFooterWhenEmpty="True"  ShowFooter=" True"
                                 ShowHeaderWhenEmpty="True" 
                                 PageSize="20" OnRowCommand="gvGroup_RowCommand" OnPageIndexChanging="gvGroup_PageIndexChanging">
                                 
                                    <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                 
                                <Columns> 
                                     <asp:ButtonField CommandName="Report" Text="Report" ControlStyle-CssClass="btn btn-primary" HeaderText="Report" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                    
                                    
                                    
                                    <asp:BoundField DataField="ServiceName" HeaderText="ServiceName">                                     
                                     </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Qty">                                    
                                     </asp:BoundField>
                                    <asp:BoundField DataField="TotalCharges" HeaderText="Total Charges" DataFormatString="{0:N2}" >
                                     
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
             

                                 
                 
                        </section>
             <script language="javascript" type="text/javascript">
                 function OpenReport() {
                     window.open("Reports.aspx");
                 }
               </script>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
