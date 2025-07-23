<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EmergencyObservationListForNurse.aspx.cs" Inherits="EmergencyObservation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Maincontent" runat="Server">
 <%--   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js" type="text/javascript"></script>--%>
    <asp:ScriptManager ID="ScriptManager" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
        </Triggers>
        <ContentTemplate>
        <section class="content-header d-flex">
                    <h1>OPD Patient Emergency List</h1>
                    <ol class="breadcrumb">
                       <%-- <li><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                        <li><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>
                        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                     --%>   <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">OPD Patient Emergency List</li>
                    </ol>
                </section>
        <section class="content">
                    <div class="box" runat="server" id="List" >
                       <!-- <div class="box-header with-border">
                <span class="red pull-right">Fields marked with * are compulsory</span>
                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                
            </div>-->
                        <div class="box-body">
                            <div class="row">                               
                                
                                 <div class="col-sm-3">
                                    <div class="form-group">
                                        <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <input id="txtFromDate" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                        
                                                    <span class="input-group-addon">
                                                      <i class="fa fa-calendar"></i>
                                                    </span>
                                        </div>
                                        
                                       </div>
                                </div>
                                <div class="col-sm-3" >
                                    <div class="form-group">
                                        <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div1" data-provide="datepicker" >
                                                           <input id="txtToDate" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter To Date" /> 
                                                        
                                                    <span class="input-group-addon">
                                                         <i class="fa fa-calendar"></i>
                                                      </span>
                                                  
                                        
                                        </div>
                                        
                                        
                   
                                       </div>
                                </div>
                                <div class="col-sm-2 text-left" >
                                    <div class="form-group"> 
                                        <asp:TextBox ID="txtSupplier" runat="server" AutoPostBack="True"  CssClass="form-control" placeholder="Enter Patient  Name"  OnTextChanged="txtSupplier_TextChanged"></asp:TextBox>
                                       <%-- <asp:RequiredFieldValidator ID="RFVsupp" ControlToValidate="txtSupplier" ForeColor="Red" runat="server" ErrorMessage="Enter"></asp:RequiredFieldValidator>--%>
                                        
                                         <cc1:AutoCompleteExtender ServiceMethod="GetSupplierList" MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="1" 
                                        CompletionInterval="10"   CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" ID="AutoCompleteExtender1" FirstRowSelected="false" TargetControlID="txtSupplier" runat="server"></cc1:AutoCompleteExtender>
                                          
                                                
                                     </div>
                                </div>
                                <div class="col-sm-2 text-left" >
                                    <div class="form-group">
                                          <asp:TextBox ID="txtPurchaseOrderNo" runat="server" AutoPostBack="True"  placeholder="Enter OPD No." CssClass="form-control" ></asp:TextBox>
                                        </div>
                                    </div>
                                
                                
                                            <div class="col-sm-2">

                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-primary" OnClick="btnSearch_Click" />
                                           <asp:Button ID="btnReport" runat="server" class="btn btn-primary"  Visible="false"
                                             Text ="Report" OnClick="btnReport_Click" onclientclick="target = '_blank';" />
  
                                   
                                        </div>

                                   
                                </div>
                            <div class="row mt-3">  
                                <div class="col-sm-3 text-left" >
                                    <div class="form-group">
                                          <asp:TextBox ID="txtdrname" runat="server" AutoPostBack="True"  placeholder="Enter Dr Name." CssClass="form-control" OnTextChanged="txtdrname_TextChanged" ></asp:TextBox>

                                          <cc1:AutoCompleteExtender ServiceMethod="GetDrNameList" MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="1" 
                                        CompletionInterval="10"   CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" ID="AutoCompleteExtender2" FirstRowSelected="false" TargetControlID="txtdrname" runat="server"></cc1:AutoCompleteExtender>
                                          
                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left" >
                                    <div class="form-group">
                                          <asp:TextBox ID="txtMobileNo" runat="server" AutoPostBack="True"  placeholder="Enter Mobile No." CssClass="form-control" ></asp:TextBox>
                                        </div>
                                    </div>
                                <div class="col-sm-6 text-left" >
                                    <div class="form-group form-check">
                                           <asp:RadioButtonList ID="ddlStatus" runat="server" placeholder="select status" RepeatDirection="Horizontal" 
                                            AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="0" >Pending</asp:ListItem>
    <asp:ListItem Value="1" >Completed</asp:ListItem>
    
    <asp:ListItem Value="2" >All</asp:ListItem>
   
                                        </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            
                        </div>
                       
                        <div class="box-body mt-3">
                           <div class="table-responsive" style="width:100%">  
                             

                            <asp:GridView ID="gvPurchaseList"  DataKeyNames="TreatmentId,Opd,PatientRegId" runat="server" AutoGenerateColumns="False" 
                            ShowHeaderWhenEmpty="True" EmptyDataText="No Records to Display" AllowPaging="True"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                            class="table table-responsive table-sm table-bordered" Width="100%"
                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" OnPageIndexChanging="gvPurchaseList_PageIndexChanging1" OnRowDataBound="gvPurchaseList_RowDataBound" >                      
              
                                <AlternatingRowStyle BackColor="White" />
              
                        <Columns>
                             <asp:TemplateField >
                                 <ItemTemplate>
                                     <asp:Button ID="btnDetails" runat="server" Text="Select" class="btn btn-primary" OnClick="btnDetails_Click" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                            <%--<asp:BoundField DataField="TreatmentId" HeaderText="Status" />--%>
                            <asp:BoundField DataField="TreatmentId" HeaderText="Treatment No" />
                              <asp:BoundField DataField="PatientRegId" HeaderText="Reg No" />
                             <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                             <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                             <asp:BoundField DataField="EntryDate" HeaderText="Given Date" />
                             <asp:BoundField DataField="Opd" HeaderText="Opd No" />
                             <%--<asp:BoundField DataField="ChallanNo" HeaderText="Challan No" />--%>
                             <asp:BoundField DataField="DrName" HeaderText="Dr Name" />
                             
                             <asp:BoundField DataField="PaymentStatus" HeaderText="PaymentStatus" />
                             <asp:TemplateField >
                                 <ItemTemplate>
                                     <asp:Button ID="btnApprove" runat="server" Text="Approve" class="btn btn-primary" OnClick="btnApprove_Click" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:Button ID="btnPrint" runat="server" Text="Prescription" class="btn btn-primary" OnClick="btnPrint_Click"  />
                               <asp:HiddenField ID="HdnReceiveToPharma" runat="server" Value='<%#Eval("ReceiveToPharma") %>' /> 
                                     <asp:HiddenField ID="HdnPaymentStatus" runat="server" Value='<%#Eval("PaymentStatus") %>' /> 
                                     <asp:HiddenField ID="HdnApprove" runat="server" Value='<%#Eval("IsApproveByNurse") %>' />
                                        </ItemTemplate>

                             </asp:TemplateField>
                            
                             </Columns>
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


         

                        <div class="box-header with-border">
                            <div class="row ">
                                <div class="col-sm-12">
                                   
                                   
                                    
                                </div>
                            </div>
                        </div>
                        
                    </div>
                 </div>
                   
<%--<div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                           Invoice Details</h4>
                    </div>
                    <div class="modal-body">
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Text="Pay" OnClick="btnSave_Click" CssClass="btn btn-info" />
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
            <script type='text/javascript'>
                function openModal() {
                    $('[id*=myModal]').modal('show');
                }
            </script>
        

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

