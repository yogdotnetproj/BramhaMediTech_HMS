<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="CashPayment_Voucher.aspx.cs" Inherits="CashPayment_Voucher" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtDepartmentName").value == "") {
                alert("Please Enter Account Name");
                return false;
            }
            //if (document.getElementById("MainContent_txtdeptcode").value == "") {
            //    alert("Please Enter Department");
            //    return false;
            //}
        }
        </script>
   
     <script type="text/javascript">
         function ShowMessage(message, messagetype) {
             var cssclass;
             switch (messagetype) {
                 case 'Success':
                     cssclass = 'alert-success'
                     break;
                 case 'Error':
                     cssclass = 'alert-danger'
                     break;
                 case 'Warning':
                     cssclass = 'alert-warning'
                     break;
                 default:
                     cssclass = 'alert-info'
             }
             $('#exampleModal').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert p-2 in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

             setTimeout(function () {
                 $("#alert_div").fadeTo(1000, 500).slideUp(500, function () {
                     $("#alert_div").remove();
                 });
             }, 500);//5000=5 seconds
         }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
                    <asp:PostBackTrigger ControlID="btnsave" />
                </Triggers>
              <ContentTemplate>
    <section class="content-header d-flex">
                    <h1>Cash Payment Voucher</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Cash Payment Voucher</li>
                    </ol>
                </section>

    
      <section class="content">
                            <div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
         
                         <!--   ======================== -->
                           
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="col-lg-12-3">
                                         <div class="row mb-3">
                                                                                
                                        <div class="col-lg-2" >
                                                    <div class="form-group">
                                                         <label for="txtDepartmentName" style="text-align:left">Payment Type:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-5">
                                            <div class="form-group">                                                    
                                              
                                             <asp:RadioButtonList ID="rblPaytype" runat="server" RepeatDirection="Horizontal" >
                                                 <asp:ListItem Selected="True" Value="1">Cash</asp:ListItem>
                                                 <asp:ListItem Value="0">Cheque</asp:ListItem>
                                                  <asp:ListItem Value="2">Online</asp:ListItem>
                                                </asp:RadioButtonList>
                                                
                                            </div>
                                        </div>
                                              </div>
                                         <div class="row mb-3">
                                                                                
                                        <div class="col-lg-2" >
                                                    <div class="form-group">
                                                         <label for="txtDepartmentName" style="text-align:left">Voucher Number:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">                                                    
                                              
                                             <asp:TextBox ID="txtvoucherNo" runat="server" placeholder="Enter Voucher No" Class="form-control" ></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                              </div>
                                    <div class="row mb-3">
                                                                                
                                        <div class="col-lg-2" >
                                                    <div class="form-group">
                                                         <label for="txtDepartmentName" style="text-align:left">Pay To:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-5">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtPayTo" runat="server" placeholder="Enter Pay To (*)" Class="form-control" 
                                                    AutoPostBack="true" TabIndex="1" OnTextChanged="txtPayTo_TextChanged"></asp:TextBox>
                                                  <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPayTo"
                                                ID="AutoCompleteExtender4"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                
                                            </div>
                                        </div>
                                              </div>   
                                        <div class="col-lg-12-3">
                                             <div class="row mb-3"> 
                                                  <div class="col-lg-2" >
                                                    <div class="form-group">
                                                         <label for="txtdeptcode" style="text-align:left">Particular:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-5">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtParticular" runat="server" TextMode="MultiLine" placeholder="Enter Particular (*)" Class="form-control" 
                                                    AutoPostBack="false" 
                                                    ></asp:TextBox>

                                                
                                                
                                            </div>
                                        </div>
                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-12-3">
                                             <div class="row mb-3"> 
                                                  <div class="col-lg-2" >
                                                      <div class="form-group">
                                                         <label for="txtdeptcode" style="text-align:left">Account Head:</label>                                                                                
                                                    </div>
                                                      </div>
                                                  <div class="col-lg-5">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtAccountHead" runat="server" placeholder="Enter Account Head (*)" Class="form-control" 
                                                    AutoPostBack="true" OnTextChanged="txtAccountHead_TextChanged" ></asp:TextBox>

                                                 <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Search_AccountHead"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtAccountHead"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                
                                            </div>
                                        </div>
                                                  <div class="col-lg-2">
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtAmount" runat="server" placeholder="Amount " Class="form-control" 
                                                    AutoPostBack="false"  ></asp:TextBox>
                                                </div>
                                                      </div>
                                                 <div class="col-lg-1">
                                            <div class="form-group"> 
                                                 <asp:Button ID="btnAdd" runat="server" class="btn btn-success"   CausesValidation="False" 
                                                   Text="Add" OnClick="btnAdd_Click"  />
                                                </div>
                                                     </div>
                                                 </div>
                                            </div>


                                                <div class="col-lg-12 mt-3">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%" >
                                <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" 
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3"  TabIndex="17"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>                                
                                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                               <asp:BoundField DataField="AccHead" HeaderText="Head"  >  
                                   
                                    <ItemStyle Width="150px" Font-Bold="True" Font-Size="Medium" /></asp:BoundField>
                                 <asp:BoundField DataField="AccCode" HeaderText="Code"  > 
                                   
                                    <ItemStyle Width="120px" Font-Bold="True" Font-Size="Medium" />
                                    </asp:BoundField>
                                 <asp:BoundField DataField="Amount" HeaderText="Amount"  > 
                                   
                                    <ItemStyle Width="120px" Font-Bold="True" Font-Size="Medium" />
                                    </asp:BoundField>
                                

                                  
                            
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                             <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="center" />                                     
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
                                                               
                                       </div> 


                                          <div class="col-lg-12-3">
                                             <div class="row mb-3"> 
                                                  <div class="col-lg-12 text-center" >
                                                      <asp:Button ID="btnsave" runat="server"    class="btn btn-primary"  
                                                 Text="Save" onclick="btnSave_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" class="btn btn-primary"   CausesValidation="False" 
                                                    onclick="btnReset_Click" Text="Reset"  />
                                                      </div>
                                                 </div>
                                              </div>
                                        
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

