<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="Insurance_Receipt.aspx.cs" Inherits="Insurance_Receipt" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Maincontent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
       <Triggers>
             <asp:PostBackTrigger ControlID="btnSearch" />
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>
         <ContentTemplate>
             

             <section class="content-header d-flex">
                    <h1>Insurance Receipt</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Insurance Receipt</li>
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
                                                                 
                                                             <label for="txtFrom">From Date</label> 
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

                                                   
                                     <div class="col-sm-1 p-0">
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

                                    
                             
                                        
                                        
                                    <div class="col-sm-4">
                                                <div class="form-group">
                                                     <asp:TextBox runat="server" ID="txtInsuranceid" placeholder=" Insurance Company" CssClass="form-control pull-right" AutoPostBack="true"  OnTextChanged="txtInsuranceid_TextChanged"></asp:TextBox>
                                          <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchInsurance"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                              CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtInsuranceid"
                                                ID="AutoCompleteExtender2"
                                                runat="server">
                                                   </asp:AutoCompleteExtender> 
                                                   
                                                </div>                                                    
                                    </div>
                             </div>

                                         
                                     </div>

                                         <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center ">
                                          <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" CssClass="btn btn-danger"
                                            Text="Search" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-success" 
                                            OnClick="Print_Click" Text="Print" />
                                        
                                        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" class="btn btn-primary" 
                                            Text="Reset" />
                                        </div>
                                    </div>
                                </div>
                                     <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                 <asp:GridView ID="gvDailyCash" runat="server" AllowPaging="True" datakeynames="ReceiptNo"
                                 AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                 BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                 class="table table-responsive table-sm table-bordered" Width="100%"
                                 HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"    
                                 EmptyDataText="No Records to Display" 
                                 onrowdatabound="gvDailyCash_RowDataBound" ShowFooter="True" 
                                 ShowHeaderWhenEmpty="True" 
                                 onpageindexchanging="gvDailyCash_PageIndexChanging" PageSize="20"  OnSelectedIndexChanged="gvDailyCash_SelectedIndexChanged">
                                 
                                      <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                                 
                                <Columns>
                                    
                         
                          
                            <asp:BoundField DataField="PatientInsuType" HeaderText="Insurance Type"></asp:BoundField>
                                   
                                     <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" 
                                     />
                                    <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode" 
                                     />
                                      <asp:BoundField DataField="PaymentDate" HeaderText="PaymentDate" DataFormatString="{0:dd/MM/yyyy}"  />
                                    <asp:BoundField DataField="DebitAmount" HeaderText="Amount" 
                                     />
                                    <asp:BoundField DataField="CreatedBy" HeaderText="Receive By">
                                     
                                     </asp:BoundField>
                                    
                                      <asp:TemplateField HeaderText="Receipt">
                                 <ItemTemplate>
                                     <asp:Button ID="btnPrint" runat="server" Text="Receipt" OnClick="btnPrint_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                                   
                                    <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnSponser" runat="server" Value='<%#Eval("Sponser") %>' />
                                           
                                             
                                         </ItemTemplate>
                                     </asp:TemplateField>
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
               <%-- <div class="box" runat="server" id="List">
                                        
                               
                                         
                                     </div>--%>

                                 
                 
                        </section>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script language="javascript" type="text/javascript">
         function OpenReport() {
             window.open("Reports.aspx");
         }
               </script>
</asp:Content>

