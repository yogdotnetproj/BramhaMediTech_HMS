<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="Nurse_PostCharges.aspx.cs" Inherits="Nurse_PostCharges" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
   .custom 
   {
       width: 50%;
   }
</style> 
    <script type="text/javascript">
     function numeric_only(e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (event)
            keycode = event.keyCode;
        else if (e)
            keycode = e.which;
        else
            return true;
        if ((keycode == 45) || (keycode == 46) || (keycode >= 48 && keycode <= 57)) {
            return true;
        }
        else {
            return false;
        }
        return true;
    }

    function alpha_only(e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (event)
            keycode = event.keyCode;
        else if (e)
            keycode = e.which;
        else
            return true;
        if ((keycode == 32) || (keycode >= 65 && keycode <= 90) || (keycode >= 97 && keycode <= 122)) {
            return true;
        }
        else {
            return false;
        }
        return true;
    }

    function AlphaNumeric(e) {
        var keycode;
        if (window.event)
            keycode = window.event.keyCode;
        else if (event)
            keycode = event.keyCode;
        else if (e)
            keycode = e.which;
        else
            return true;
        if ((keycode == 32) || (keycode == 38 || keycode == 45) || (keycode >= 47 && keycode <= 57) || (keycode >= 65 && keycode <= 90) || (keycode >= 97 && keycode <= 122)) {
            return true;
        }
        else {
            return false;
        }
        return true;
    }
    
    function Validate() {
      

        if (document.getElementById("MainContent_txtsurgen").value == "") {
              alert("Please Enter Surgeon");
              return false;
          }
        if (document.getElementById("MainContent_txtDISEASE").value == "") {
              alert("Please Enter Disease");
              return false;
          }
        if (document.getElementById("MainContent_txtoperation").value == "") {
              alert("Please Enter Operation Name");
              return false;
          }
          

      }
        

        </script>
    <script type="text/javascript" src="Scripts/jquery-3.1.1.js"></script>
<script type="text/javascript" src="select2-master/select2.js"></script>
<link href="css/select2.css" rel="stylesheet" />
     <script type="text/javascript">
         $(document).ready(function () {
             $("#ddlBillServices").select2({
                 placeholder: "Select an option",
                 allowClear: true
             });
         });
 </script>
<%--    <script src="Scripts/1.3.2.min.js"  type="text/javascript"/>
   <script src="Scripts/1.7.1.custom.js" type="text/javascript"/>--%>
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
            <asp:PostBackTrigger ControlID="btnSummary" />
             <asp:PostBackTrigger ControlID="btnDisk" />
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>Nurse Post Charges</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Nurse Post Charges</li>
                    </ol>
            </section>
           
            <section class="content">
                <div id="Div1" class="box" runat="server">
                  <!--  <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                 <asp:Label ID="lblMessage" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                               
                            </div>
                        </div>
                    </div>-->
                     <div class="box-body">
                        
                   
                   
                       
                        
                        <div class="panel panel-info mt-3">
      <div class="panel-heading" style="font-size:medium;font-weight:bold" >Add Service Details</div>
      <div class="panel-body">
        <div class="col-lg-12" runat="server" visible="false">
                                                <div class="row mt-2"> 
                                <div class="col-lg-4 text-left">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" Font-Bold="true" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlag_SelectedIndexChanged" >
                                                            
                                                             <asp:ListItem Selected="True" Value="Other">Other</asp:ListItem>
                                                              <asp:ListItem Value="Package">Package</asp:ListItem>
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                    </div>
                                    </div>
                                          <div class="col-lg-12 mt-2" >                                 
                                    
                                   
                                        
                                                    <div class="form-group">  
                                                         <div class="row">
                                                        <div class="col-lg-2 text-left">
                                                         <label for="ddlBillServices3" title="">Bill Service</label>   
                                                         </div>     
                                                            <div class="col-lg-6 text-left">                                                
                                                        <asp:DropDownList ID="ddlBillServices" Visible="false" runat="server" AutoPostBack="True" CssClass="custom"
                                                     
                                                         TabIndex="10" OnSelectedIndexChanged="ddlBillServices_SelectedIndexChanged">
                                                        </asp:DropDownList>                    
                                                       <asp:TextBox ID="txtBillServices" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Service Name(*)"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtBillServices_TextChanged" ></asp:TextBox>
                                             
                                                         <asp:AutoCompleteExtender  
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAllService"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtBillServices"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                                                </div>
                                                        </div>
                                                   
                                        </div>
                                              </div>
                                         
                                        <div class="col-lg-12 mt-3" >                                 
                                    
                                             <div class="row">
                                                  <div class="col-lg-4 text-left">
                                                    <div class="form-group">  
                                                                <label for="txtdescription" title="">Description</label>  
                                                        </div>
                                                      </div>
                                                  <div class="col-lg-3 text-left" runat="server" id="Div6">
                                                    <div class="form-group">  
                                                         <label for="ddlConsDoctorName" title="">Consultant Dr.</label> 
                                                        </div>
                                                      </div>
                                                 <div class="col-lg-2 text-left">
                                                    <div class="form-group">  
                                                         <label for="txtCharges" title="" style="text-align: left">Charges</label> 
                                                        </div>
                                                     </div>
                                                  <div class="col-lg-1 text-left">
                                                    <div class="form-group"> 
                                                         <label for="txtQty" title="" style="text-align: left">Qty</label> 
                                                        </div>
                                                      </div>
                                                  <div class="col-lg-1 text-left">
                                                    <div class="form-group"> 
                                                         <label for="txtTotalCharges" title="" style="text-align: left">Amount</label>  
                                                        </div>
                                                      </div>
                                                  <div class="col-lg-1 text-right">
                                                    <div class="form-group"> 
                                                         <label for="txtTotalCharges" title="" style="text-align: left">Add.</label> 
                                                        </div>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-lg-12 mt-3" >   
                                    <div class="row">
                                       
                                             
                                                 

                                                <div class="col-lg-4 text-left">
                                                    <div class="form-group">  
                                                                                     
                                                         <textarea  runat="server"  id="txtdescription" cols="40"  rows="1"></textarea>        
                                                       
                    
                                                    
                                                    </div>
                                                </div>
                                        <div class="col-lg-2 text-left" runat="server" visible="false">                                            
                                            <div class="form-group"> 
                                                <label for="ddlRoomTypeName" title="">Room Type</label>
                                                 <asp:DropDownList ID="ddlRoomTypeName" runat="server" Class="form-control"
                                                    OnSelectedIndexChanged="ddlRoomTypeName_SelectedIndexChanged" 
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                      
                                              <div class="col-lg-3 text-left" runat="server" id="Doctor">
                                                    <div class="form-group">  
                                                                   
                                                        <asp:DropDownList ID="ddlConsDoctorName" runat="server" Visible="false"
                                                         class="form-control form-select" AutoPostBack="true"   TabIndex="14" OnSelectedIndexChanged="ddlConsDoctorName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Doctor Name(*)"
                                                 AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtConsDoctorName_TextChanged"></asp:TextBox>
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


                                                <div class="col-lg-2 text-left">
                                                    <div class="form-group">  
                                                         
                                                        <asp:TextBox ID="txtCharges" runat="server" onkeyPress="return numeric_only(event);"
                                                        class="form-control" placeholder=" Charges" AutoPostBack="true"  OnTextChanged="txtQty_TextChanged" TabIndex="13"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>  
                                          <div class="col-lg-1 text-left">
                                                    <div class="form-group"> 
                                                        
                                                        <asp:TextBox ID="txtQty" runat="server" onkeyPress="return numeric_only(event);" AutoPostBack="true"
                                                        class="form-control" placeholder=" Qty" TQabIndex="13" OnTextChanged="txtQty_TextChanged"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div> 

                                        <div class="col-lg-1 text-left">
                                                    <div class="form-group"> 
                                                        
                                                        <asp:TextBox ID="txtTotalCharges" runat="server" readonly="true" onkeyPress="return numeric_only(event);"
                                                        class="form-control"  TabIndex="13"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>              

                                                <div class="col-lg-1 text-right">
                                                    <div class="form-group"> 
                                                        
                                                        
                                                         <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" OnClientClick="return Validate();" TabIndex="14" Text="Add" />
                                                         
                                                         
                                                       
                                                       
                                                        </div>
                                        </div>
                                    
                                    </div>
                                  </div> 

         
                           

                                        <div class="col-lg-12 mt-3">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%"  >
                                            <div style=" overflow: scroll; width: 100%; height: 450px; text-align: left"
                                                                                id="Div5">
                                             
                                <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" DataKeyNames="IpdBillServiceDetailId"
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="17"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display" onrowdatabound="gvBill_RowDataBound" 
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing" PageSize="5000">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
                            <Columns>
                                 <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                  <asp:BoundField DataField="CreatedOn" ControlStyle-Font-Bold="true" ItemStyle-Font-Bold="true" HeaderText="Entry Date"  DataFormatString="{0:dd/MM/yyyy hh:mm tt}" > 
                                <ItemStyle Width="30px" /></asp:BoundField>
                                <asp:BoundField DataField="Service" HeaderText="Service" ItemStyle-Font-Bold="true"  > 
                                <ItemStyle Width="300px" /></asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description"  ItemStyle-Font-Bold="true" > 
                                <ItemStyle Width="200px" /></asp:BoundField>
                                    <asp:BoundField DataField="Empname" HeaderText="Consultant Dr" ItemStyle-Font-Bold="true" > 
                                <ItemStyle Width="120px" /></asp:BoundField>
                                    <%--<asp:BoundField DataField="BillGroup" HeaderText="BillGroup"  > <ItemStyle Width="150px" /></asp:BoundField>--%>
                               
                               
                                <asp:BoundField DataField="BillServiceCharges" HeaderText="Charges" ItemStyle-Font-Bold="true" >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>
                                 <asp:BoundField DataField="Qty" HeaderText="Qty" ItemStyle-Font-Bold="true" ><ItemStyle Width="30px" /> </asp:BoundField>
                                <asp:BoundField DataField="TotalCharges" HeaderText="Total Charge" ItemStyle-Font-Bold="true" >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>

                                <asp:BoundField DataField="IpdBillServiceDetailId" HeaderText="Bill Service DetailId" Visible="False"> <ItemStyle Width="70px" /></asp:BoundField>
                                <asp:BoundField DataField="DrId" HeaderText="Consultant Dr Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>                            
                               <%-- <asp:BoundField DataField="BillGroupId" HeaderText="Bill Group Id" 
                                    Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>--%>
                                 <asp:BoundField DataField="BillServiceId" HeaderText="Service Id" Visible="False"  > <ItemStyle Width="70px" /></asp:BoundField>
                                 <asp:BoundField DataField="CreatedBy" HeaderText="Created By"  > <ItemStyle Width="70px" /></asp:BoundField>
                            
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
                                                               
                                       </div>                         
                                           </div>      
                                 </div>
                                                  <div class="col-lg-12" runat="server" visible="false">
                                                     <div class="row">                                                        
                                                 
                                                         <div class="form-group">
                                                              <div class="col-lg-1 text-left" style="width:150px" >
                                                        <div class="form-group">
                                                            <label for="lblBillServiceCharges" style="text-align:left">Bill Amount:</label>  
                                                            </div>
                                                    </div>
                                                  <div class="col-lg-1 text-left">
                                                        <div class="form-group">                                                                
                                                            <span> <asp:Label ID="lblBillServiceCharges" runat="server" Font-Bold="True" Width="102px" Font-Size="Large"></asp:Label></span>
                                                        </div>                                                                            
                                                 </div>                                                
                                                  <div class="col-lg-1 text-left" style="width:150px">
                                                         <div class="form-group">
                                                              <label for="lblAdvanceAmt" style="text-align:left">Advance Amount:</label>
                                                             </div>
                                                      </div>                                        
                                                  <div class="col-lg-1 text-left ">
                                                <div class="form-group">
                                                <span><asp:Label ID="lblAdvanceAmt" ForeColor="Green" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label></span>
                                            </div> 
                                          </div>
                                                         <div class="col-lg-1 text-left" style="width:150px" >
                                                        <div  class="form-group">
                                                                 <label >Discount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-1 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblDiscAmt" runat="server" Text="" Font-Bold="true" Font-Size="Large" Width="120px">
                                                                                     </asp:Label></span></div>
                                                                                </div>
                                                          <div class="col-lg-2 text-left" style="width:150px">
                                                        <div  class="form-group">
                                                                 <label >Insurance Amount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblInsurance" runat="server" Text="" Font-Bold="true" Font-Size="Large" Width="120px">
                                                                                     </asp:Label></span></div>
                                                                                </div>

                                                         </div>
                                                     </div>
                                              </div>
                                                
                                                 


                                        <div class="col-lg-12" runat="server" visible="false">                                            
                                            <div class="row"> 
                                                    
                                                              <div class="col-lg-1 text-left" style="width:110px">
                                                                   <label> Payment By: </label>
                                                              </div>
                                                    
                                                    <div class="col-lg-1 text-left" style="width:380px">

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>

                                                 <div class="col-lg-1 text-left" style="width:120px" >
                                             <div class ="row">
                                                    <label class="radio-inline">                                           
                                                        <asp:CheckBox ID="PaymentInsurance" Text="Is Insurance" runat="server" AutoPostBack="true" OnCheckedChanged="PaymentInsurance_CheckedChanged"></asp:CheckBox></label>
                                            </div>
                                            </div>
                                        <div id="InsuranceDetails" runat="server">  
                                                       
                                                       <div class="col-lg-1 text-left" style="width:120px">
                                                           <div class="form-group">  
                                                        <label>InsuranceAmt: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:100px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtInsuranceAmt" runat="server"  class="form-control"  height="30px"  AutoPostBack="True"
                                                     Width="90px" TabIndex="8" OnTextChanged="txtInsuranceAmt_TextChanged1"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-lg-1 text-left" style="width:130px">
                                                    <div class="form-group">                                                      
                                                        

                      <asp:RadioButtonList ID="rdblInsuranceAmt" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdblInsuranceAmt_SelectedIndexChanged" >
                          <asp:ListItem Selected="True" Value="0">Amt</asp:ListItem>
                          <asp:ListItem Value="1">Per(%)</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                     </div>    
                                                        
                                                       <div class="col-lg-2 text-left" style="width:120px">
                                                           <div class="form-group">  
                                                        <label  style="width:110px" >InsuranceComp: </label>
                                                               </div>
                                                        </div>
                                                       
                                                           <div class="col-lg-2 text-left" style="width:190px">
                                                           <div class="form-group">  
                                                             <asp:DropDownList ID="ddlInsuranceCompName" runat="server" CssClass="form-control" AutoPostBack="true" Width="190px" ></asp:DropDownList>
                                                                   
                                                        
                                                               </div>
                                                        </div>
                                                       
                                                            
                                                        </div>
                                                              
                                                 </div>
                                              </div>       
                        
                                                        
                                        <div id="PaymentDetails" runat="server" visible="false">
                                                
                                                       <div class="col-lg-12">
                                                           <div class="form-group"> 
                                                       <div class="col-lg-1 text-left"  style="width:130px">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"  height="30px"   placeholder="Card/Cheque No."
                                                     Width="120px" TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" style="width:160px">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbankName" runat="server"  class="form-control"  height="30px"   placeholder="Bank Name"
                                                     Width="150px" TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-1 text-left" runat="server" id="ChequeDate" style="width:160px">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                            
                                                          <asp:TextBox ID="txtchequedate" runat="server" height="30px" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" Width="110px" TabIndex="2"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                  </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                               </div>
                                                           </div>
                                                       
                                                       </div>
                                         <div class="col-lg-12" runat="server" visible="false">                                            
                                                   <div class="row"> 
                                                       <table width="100%" cellpadding="1" cellspacing="1">

<tr>
    <td>
           <label> Total Amount: </label>
    </td>
    <td>
         <asp:TextBox ID="txtTotalAmt" runat="server" Text="0" Enabled="false" class="form-control"  height="30px"   placeholder="Total Amount"
                                                     Width="200px" TabIndex="8"></asp:TextBox>
    </td>
    <td>
        <label> Discount: </label>
    </td>
    <td>
  <input id="rdbdiscAmt" type="radio" name="rdbDisc" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>
                <input id="rdbdiscPer" type="radio" runat="server" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
    </td>
    <td>
 <asp:Button ID="btnDisk" runat="server" class="btn btn-primary" ToolTip="Add Discount" Text="(+)" OnClick="btnDisk_Click"></asp:Button>
    </td>
    <td>
  <asp:TextBox ID="txtDiscount" runat="server" Text="0"  class="form-control"  height="30px"   placeholder="Discount"
                                                     Width="140px" TabIndex="8" AutoPostBack="false" OnTextChanged="txtDiscount_TextChanged" onkeyPress="return numeric_only(event);"></asp:TextBox>


    </td>
</tr>
                                                           <tr>
                                                               <td>
                                                                    <label>Net Amount : </label>
                                                               </td>
                                                               <td>
                                                                   <asp:TextBox ID="txtAmount" runat="server" Text="0" Enabled="false" class="form-control"   placeholder="Amount" onkeyPress="return numeric_only(event);"
                                                       Width ="200px" TabIndex="8" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                                               </td>
                                                               <td>
                                                                     <label> Disc Reason : </label>
                                                               </td>
                                                               <td>
                                                                   <asp:DropDownList ID="ddlDiscReason" runat="server" AutoPostBack="True" height="30px" 
                                                     Width="200px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </td>
                                                               <td colspan="2" rowspan="6">
                                                                   <div style=" overflow: scroll; width: 100%; height: 250px; text-align: left"
                                                                                id="Di6">
                                                                  <asp:GridView ID="gvBillTransaction" class="table table-responsive table-sm table-bordered" runat="server" AutoGenerateColumns="False" Width="100%"                                       
                                                              HeaderStyle-ForeColor="Black" ShowHeaderWhenEmpty="true"  AlternatingRowStyle-BackColor="White"   >
                                                                    <Columns>
                                                                        <asp:BoundField DataField="PaymentDate" HeaderText="Transaction Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                       <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No " />
                                                                          <asp:BoundField DataField="DiscountGivenBy" HeaderText="Dr Name " />
                                                                         <asp:BoundField DataField="ReceivedAmount" HeaderText="Amount Paid" />
                                                                        <asp:BoundField DataField="ModeOfPaymentName" HeaderText="Mode Of Payment" />
                                            
                                                                        <asp:BoundField DataField="CreatedBy" HeaderText="Transcation User" />
                                                                    </Columns>
                                                             </asp:GridView>
                                                                       </div>

                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                   <label> Amount Received : </label>
                                                               </td>
                                                               <td>
 <asp:TextBox ID="txtAmountReceived" runat="server" ReadOnly="true"  class="form-control" Text="0"  height="30px"   placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8" ></asp:TextBox>
                                                               </td>
                                                               <td>
                                                                       <label> Disc Given By: </label>
                                                               </td>
                                                               <td>

                                                               <asp:DropDownList ID="ddlDiscountGivenBy" runat="server" AutoPostBack="True" height="30px" 
                                                     Width="200px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </td>
                                                           </tr>
                                                           <tr>
                                                               <td>
                                                         <label> Insurance Amount : </label>
                                                               </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAwardAmt" runat="server" ReadOnly="true"   class="form-control" Text="0"  height="30px"    onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8" ></asp:TextBox>
                                                               </td>
                                                                <td>
                                            <label> BalanceReason: </label>
                                                               </td>
                                                                <td>
 <asp:DropDownList ID="ddlBalreason" runat="server" AutoPostBack="True"  
                                                       Width="200px"   CssClass="form-control" >
                                                    </asp:DropDownList>
                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                    <label> Disc Given : </label>
                                                               </td>
                                                                 <td>
 <asp:TextBox ID="txtdiscgiven" runat="server" ReadOnly="true"  class="form-control" Text="0"  height="30px"    onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8"  AutoPostBack="True"></asp:TextBox>
                                                               </td>
                                                                 <td colspan="2">
                                                                      <asp:CheckBox ID="chkDeposite" Text="Transfer From Deposit" ForeColor="Red" runat="server" AutoPostBack="true" ></asp:CheckBox></label>
                                                              <asp:Label ID="lblDepositAmt" ForeColor="Red" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                      </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                    <label> Balance : </label>
                                                               </td>
                                                                 <td>
 <asp:TextBox ID="txtPaid" runat="server" Enabled="false" Visible="false"  class="form-control" Text="0"  height="30px"   placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8" OnTextChanged="txtPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                               <asp:TextBox ID="txtbalance" runat="server" text="0" class="form-control" ReadOnly="true"     placeholder="Balance" onkeyPress="return numeric_only(event);"
                                                     Width="200px" TabIndex="8"></asp:TextBox>
                                                                      </td>
                                                                 <td colspan="2">
                                                                     <asp:CheckBox ID="chkFinalDischarge" Text="Final Discharge" runat="server" AutoPostBack="true" Font-Size="Medium" OnCheckedChanged="chkFinalDischarge_CheckedChanged" ></asp:CheckBox>
                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                     
                                                               </td>
                                                                <td>
  
                                                               </td>
                                                                <td>

                                                               </td>
                                                                <td>

                                                               </td>

                                                           </tr>
                                                       </table>
                                                       </div>
                             </div>                                       
                                       
                                          <div class="col-lg-12 text-center" runat="server" visible="false">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                          
                                               <asp:Button ID="btnrefund" runat="server" Text="Refund" Visible="false"    OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary"  />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="80px" />
                                              <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px"  onclientclick="target = '_blank';" OnClick="btnReport_Click" />
                                       <asp:Button ID="btnSummary" runat="server" Text="Summary" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px"  onclientclick="target = '_blank';" OnClick="btnSummary_Click" />

                                    <%--<asp:Button ID="btnSaveandBill" runat="server" Text="Save & Bill" OnClientClick="return Validate1();"
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="100px" 
                                        onclick="btnSaveandBill_Click"   />--%><%-- onclientclick="target = '_blank';" />--%>
                                         
                                             
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
              
</asp:Content>

