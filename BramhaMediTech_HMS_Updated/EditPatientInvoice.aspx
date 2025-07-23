<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EditPatientInvoice.aspx.cs" Inherits="EditPatientInvoice" %>


  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
         <style type="text/css">
      input.larger {
        width: 80px;
        height: 80px;
      }
    </style>
    <style type="text/css">
  .BigCheckBox input {width:20px; height:20px;}
</style>
     <script type="text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtInsuranceid").value == "") {
                 alert("Please Select Company ");
                 return false;
             }
         }
        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
         <Triggers>
             <%--<asp:PostBackTrigger ControlID="btnreport" />--%>
         </Triggers>
         <ContentTemplate>
   
            <section class="content-header d-flex">
                <h1>Edit Invoice</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Edit Invoice</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    
                    <div class="box-body">
                                       <div class="panel panel-info" >
      <div class="panel-heading" style="font-size:medium;font-weight:bold"">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Font-Bold="true" ForeColor="aqua"  runat="server" Text=""></asp:Label> </div>
      <div class="panel-body">
    
                            <div class="col-lg-12">
                                <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="lblPatientName"><b>Name:</b></label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title=""><b>PRN:</b></label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label for="lblAge" title=""><b>Age:</b></label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title=""><b>Mobile No:</b></label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                     
                                    </div>
                            </div>
                       
                              <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="lblAddress" title=""><b>Address:</b></label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                     <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title=""><b>Company:</b></label>
                                        <asp:Label ID="lblCompany" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                  </div>
           </div>
                            </div>  
                         </div>
                       
                            
                    <div class="row">
                             <div class="col-lg-12 mt-3" >
                                        
 <div class="row">
                                    
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranced">Charge Number:</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-4">
                                                    <div class="form-group">                 
                                   
                                                <asp:Label runat="server" ID="txtchargeNumber" Font-Bold="True" Font-Size="Medium" placeholder=" Charge Number" ></asp:Label>
                                       
                                             </div>
                                        </div>
                                               <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsura"> Generate On</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                  <div class="col-sm-3">
                                                    <div class="form-group"> 
                                                        <asp:Label ID="txtgenerateOn" runat="server" TabIndex="3" AutoCompleteType="None"  
                                            Font-Bold="True" Font-Size="Medium"  ></asp:Label>
                                              
                                             </div>
                                        </div>
     <div class="col-sm-1">
                                                    <div class="form-group"> 
                                                        <asp:CheckBox ID="ChkaddService" CssClass="BigCheckBox" AutoPostBack="true" ForeColor="Red" Font-Bold="true" runat="server"  Text="&nbsp;Add" OnCheckedChanged="ChkaddService_CheckedChanged"  />
                                                        </div>
         </div>
                        
                             
                            
     </div>
           
                        </div>
                        </div>


                     <div class="row">
                             <div class="col-lg-12 mt-3" >                                        
                        <div class="row">
                             <div class="col-sm-3">
                                                    <div class="form-group"> 
                                                        <asp:TextBox ID="txtserviceName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter service Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" Font-Bold="True" Font-Size="Medium" OnTextChanged="txtserviceName_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchService"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtserviceName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>                                                                                                                                                                                           
                                                        </div>
                                 </div>
                              <div class="col-sm-3">
                                                    <div class="form-group"> 
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
                             <div class="col-sm-2">
                                                    <div class="form-group">                                                   
  
                                                          <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtDate" runat="server"   CssClass="form-control" TabIndex="7" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                                 
                                                </div>
                                            </div>
                              <div class="col-sm-2">
                                                    <div class="form-group"> 
                                                                 <asp:TextBox runat="server" CssClass="form-control" placeholder="Enter charges(*)" ID="txtcharges" ></asp:TextBox>  
                                                        </div>
                                  </div>

                              <div class="col-sm-1">
                                                    <div class="form-group"> 
<asp:TextBox runat="server" ID="txtqty" placeholder="qty(*)" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                  </div>
                            <div class="col-sm-1">
                                                    <div class="form-group"> 
<asp:Button runat="server" CssClass="btn btn-success" Text="Add" ID="btnAdd" OnClick="btnAdd_Click" />
                                                        </div>
                                </div>

                           </div>
                                 </div>
                         </div>
                     <div class="row">
                            <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                             <div class="col-sm-12">
                                                        <div class="form-group">
                                                              <asp:Label ID="lblAddService" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="Red" ></asp:Label>
                                                            </div>
                                                 </div>
                                             </div>
                                </div>
                         </div>

                    <div class="row">
                            <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                             <div class="col-sm-12">
                                                        <div class="form-group">
                                                <div class="table-responsive" style="width: 100%">
                                                 <asp:GridView ID="GVPAtientInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="ChdetId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="GVPAtientInvoice_RowCommand" OnPageIndexChanging="GVPAtientInvoice_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="150" ShowHeaderWhenEmpty="True" OnRowEditing="GVPAtientInvoice_RowEditing">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                       
                                                        <asp:BoundField DataField="Patregid" HeaderText="Patreg Id" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="Createdon" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="100" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="BillGroupName" HeaderText="Group Name" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                         
                                                         <asp:BoundField DataField="ServiceName" HeaderText="ServiceName" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="Charges" HeaderText="Charges" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                       
                                                      <asp:BoundField DataField="TotalAmt" HeaderText="Total Amt" ItemStyle-Width="60"  >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        
                                                          <asp:TemplateField HeaderText="Cancel" ItemStyle-Width="100px" >
                                                    <ItemTemplate  >
                                                        <asp:ImageButton ID="ImageButton1" CssClass="glyphicon-trash"   
                                                            ImageUrl="~/Images0/delete.gif"  OnClientClick="return ValidateDelete();" CommandName="Edit" runat="server" 
                                                            ImageAlign="Middle" />
                                                    
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
                                                            </div>
                                                 </div>
                                             </div>
                                </div>
                        </div>
                    <div class="row">
                            <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     
                                    
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranced">Bill Amount</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                             <div class="col-sm-3">
                                                        <div class="form-group"> 
                                                            <asp:Label runat="server" ID="lblBillAmount" ></asp:Label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                                <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranced">Insurance Amount</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                             <div class="col-sm-3">
                                                        <div class="form-group"> 
                                                            <asp:Label runat="server" ID="lblInsuanceAmt" ></asp:Label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                             </div>
                                </div>
                        </div>
                       <div class="row">
                            <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     
                                    
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsuranced">Discount Given(%)</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <asp:RadioButtonList runat="server" ID="RblDisType" RepeatDirection="Horizontal"> 
                                                                <asp:ListItem Selected="True" Value="1">Amt</asp:ListItem>
                                                                <asp:ListItem Value="2">Per(%)</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </div>
                                                 </div>
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdiscgiven" AutoPostBack="True" OnTextChanged="txtdiscgiven_TextChanged" ></asp:TextBox>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                                <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtInsurancedD">After Disc Amt</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                             <div class="col-sm-4">
                                                        <div class="form-group"> 
                                                            <asp:TextBox runat="server" Enabled="false"  CssClass="form-control" ID="txtAftDiscAmt" ></asp:TextBox>                                                                                                                                                                                              
                                                         </div>
                                                      </div>   
                                            
                                             </div>
                                </div>
                        </div>
                                           <div class="row">
                            <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     
                                    
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                             <label for="txtInsuranced">Disc Remark</label>  
                                                            </div>
                                                      </div>
                                              <div class="col-sm-10">
                                                        <div class="form-group"> 
                                                            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" ID="txtdiscRemark" ></asp:TextBox>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                             </div>
                                </div>
                       
                        </div>
                     <div class="row">
                            <div class="col-lg-12 mt-3" >
                                         <div class="row">
                                     
                                    
                                            
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                             
                                                            </div>
                                                      </div>
                                              <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <asp:Button runat="server" Text="Update Invoice" CssClass="btn btn-warning" ID="bnSave" OnClick="bnSave_Click" ></asp:Button>                                                                                                                                                                                              
                                                         </div>
                                                      </div>  
                                             <div class="col-sm-8">
                                                        <div class="form-group"> 
                                              <asp:Label ID="lblMessage" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                                            </div></div>
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
        
             </ContentTemplate>
        </asp:UpdatePanel>
     
     <script language="javascript" type="text/javascript">
         function ValidateDelete() {
             var Check = confirm('Are you sure you want to Cancel this service ?')
             if (Check == true) {
                 return true;
             }
             else {
                 return false;
             }
         }

 </script> 
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .form-group {
        }
    </style>
</asp:Content>



