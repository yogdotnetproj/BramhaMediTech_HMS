<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="IpdBillForPatientServices.aspx.cs" Inherits="IpdBillForPatientServices" %>


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

       

        if (document.getElementById("MainContent_txtBillServices").value == "") {
            alert("Please Enter BillService");
            return false;
        }
        if (document.getElementById("MainContent_txtQty").value == "") {
            alert("Please Enter Qty");
            return false;
        }
        if (document.getElementById("MainContent_txtCharges").value == "") {
            alert("Please Enter Charges");
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
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="oooT">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
            <asp:PostBackTrigger ControlID="btnSummary" />
             <asp:PostBackTrigger ControlID="btnDisk" />
             <asp:PostBackTrigger ControlID="BtnDischarge" />
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>IPD Bill</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">IPD Bill</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                               
                                      <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" >Patient Information:  
                                           <asp:Label  ID="lblMessage"  Font-Bold="true" ForeColor="White"  runat="server" Text=""></asp:Label> </div>
                                 <asp:Label ID="lblMessage1" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                               
                            </div>
                        </div>
                    </div>
                    <div class="box-header with-border">
                       
                            <div class="col-lg-12 text-left">
                                
                                 <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPrnNo" runat="server" Font-Bold="true" Text="Reg ID:" ></asp:Label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblPat" runat="server" Font-Bold="true" Text="Pat Name:"></asp:Label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label ID="lblI"  runat="server" Font-Bold="true" Text="IPD NO:"></asp:Label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblBio" runat="server" Font-Bold="true" Text="Bill NO:"></asp:Label>
                                        <asp:Label ID="lblBillNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="hhhd" runat="server" Font-Bold="true" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                         
                            <div class="col-lg-12 text-left mt-3">
                                <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server" Font-Bold="true" Text="Pat Cate"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server" Font-Bold="true" Text="Adm Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div3" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Font-Bold="true" Text="DR Name :"></asp:Label>
                                        <asp:Label ID="lbldrname" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="lblBi" runat="server" Font-Bold="true" Text="Room Type:" ></asp:label>
                                        <asp:Label ID="LblRoomType" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server" Font-Bold="true" Text="Bed Name:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>

                        
                            <div class="col-lg-12 mt-3">
                                 <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server" Font-Bold="true" Text="Diagnosis:"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server" Font-Bold="true" Text="Procedure:"> </asp:Label>
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                 <div id="Div4" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="Label5"   runat="server" Font-Bold="true" Text="Sponsor :"></asp:Label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:label id="Label7" runat="server" Font-Bold="true" Text="Sponsor1:" ></asp:label>
                                        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:label id="Label9" runat="server" Font-Bold="true" Text="Visit No:"></asp:label>
                                        <asp:Label ID="lblvisitno" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                         <div style="height:2px; background:#B24592;"> </div>
                    </div>
                    <div class="box-body">
                     <div class="col-lg-12">
                                                <div class="row"> 
                                <div class="col-lg-12 text-left" >

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server"  RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlag_SelectedIndexChanged" >
                                                            <asp:ListItem Value="All">All</asp:ListItem>
                                                              <asp:ListItem Value="Consultation">Consultation</asp:ListItem>
                                                             <asp:ListItem Value="P">Pathology</asp:ListItem>
                                                             <asp:ListItem Value="R">Radiology</asp:ListItem>
                                                             <asp:ListItem Value="M">Medical LAB</asp:ListItem>
                                                             <asp:ListItem Value="Room" Selected="True">Room</asp:ListItem>
                                                             <asp:ListItem Value="Drugs" >Drugs</asp:ListItem>
                                                             <asp:ListItem Value="Other">Other</asp:ListItem>
                                                              <asp:ListItem Value="Package">Package</asp:ListItem>

                                                            
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                    </div>
                                    </div>

                      
      
                                          <div class="col-lg-12 mt-3">                                 
                                     
                                    <div class="row">
                                        <div class="col-lg-12 text-left">
                                                    <div class="form-group">  
                                                         <label for="ddlBillServices3" title="" >Bill Service</label>                                                            
                                                        <asp:DropDownList ID="ddlBillServices" Visible="false" runat="server" AutoPostBack="True" CssClass="custom form-select"
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
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%> <%--CompletionListElementID="Div6"--%>
                                                   </asp:AutoCompleteExtender>
                                                        </div>
                                                    </div>
                                        </div>
                                              </div>
                                         
                                        <div class="col-lg-12 mt-3">                                 
                                    
                                    <div class="row">
                                       
                                              <%--  <div class="col-lg-2 text-left" style="width:250px"">
                                                    <div class="form-group">                                                              
                                                        <asp:DropDownList ID="ddlBillGroup" runat="server" AutoPostBack="True" class="form-control"
                                                         OnSelectedIndexChanged="ddlBillGroup_SelectedIndexChanged" Width="240px" height="30px" 
                                                         TabIndex="10">
                                                        </asp:DropDownList>                    
                                                       
                                                        </div>
                                                    </div>--%>
                                                 

                                                <div class="col-lg-3 text-left">
                                                    <div class="form-group">  
                                                                <label for="txtdescription" title="">Description</label>                           
                                                         <textarea  runat="server" id="txtdescription" cols="20"  rows="1" class="form-control"></textarea>        
                                                       
                    
                                                    
                                                    </div>
                                                </div>
                                        <div class="col-lg-2 text-left" runat="server" visible="false">                                            
                                            <div class="form-group"> 
                                                <label for="ddlRoomTypeName" title="" style="text-align: left">Room Type</label>
                                                 <asp:DropDownList ID="ddlRoomTypeName" runat="server" Class="form-control"
                                                    OnSelectedIndexChanged="ddlRoomTypeName_SelectedIndexChanged" 
                                                    AutoPostBack="True" TabIndex="2">
                                                </asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                      
                                              <div class="col-lg-2 text-left" runat="server" id="Doctor">
                                                    <div class="form-group">  
                                                         <label for="ddlConsDoctorName" title="">Consultant Dr.</label>          
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
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                </div>


                                                <div class="col-lg-2 text-left">
                                                    <div class="form-group">  
                                                         <label for="txtCharges" title="">Charges</label> 
                                                        <asp:TextBox ID="txtCharges" runat="server" onkeyPress="return numeric_only(event);"
                                                        class="form-control" AutoPostBack="true" placeholder=" Charges" TabIndex="13" OnTextChanged="txtCharges_TextChanged"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>  
                                          <div class="col-lg-2 text-left">
                                                    <div class="form-group"> 
                                                         <label for="txtQty" title="">Qty</label>  
                                                        <asp:TextBox ID="txtQty" runat="server" onkeyPress="return numeric_only(event);" AutoPostBack="true"
                                                        class="form-control" Text="1" placeholder=" Qty" TQabIndex="13" OnTextChanged="txtQty_TextChanged"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div> 

                                        <div class="col-lg-2 text-left">
                                                    <div class="form-group"> 
                                                         <label for="txtTotalCharges" title="">Amount</label>  
                                                        <asp:TextBox ID="txtTotalCharges" runat="server" Enabled="false" onkeyPress="return numeric_only(event);"
                                                        CssClass="form-control"  TabIndex="13"></asp:TextBox>                    
                                                        
                                                        </div>
                                                    </div>              

                                                <div class="col-sm-1">
                                                    <div class="form-group"> 
                                                       
                                                       
                                                        
                                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary mt-4"  OnClick="btnAdd_Click" OnClientClick="return Validate();" TabIndex="14" Text="Add" />
                                                       
                                                       
                                                        
                                                      
                                                       
                                                       
                                                        </div>
                                        </div>
                                    
                                    </div>
                                  </div> 


                        <div class="col-lg-12 mt-3">                                 
                                    
                                    <div class="row">
                                        <div class="col-lg-8 text-left">
                                                    <div class="form-group">  
                                                                                                                    
                                                                    
                                                       <asp:TextBox ID="txtserchservicename" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="search Service Name(*)"
                                                 AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtBillServices_TextChanged" ></asp:TextBox>
                                              

                                                       
                                                        </div>
                                                    </div>
                                         <div class="col-lg-4 text-left">
                                                    <div class="form-group">  
                                                         <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-warning"  TabIndex="14" Text="Search" OnClick="btnsearch_Click" />
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
                                ShowFooter="True" onselectedindexchanged="gvBill_SelectedIndexChanged" OnRowEditing="gvBill_RowEditing" PageSize="5000" OnRowCommand="gvBill_RowCommand">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
                            <Columns>
                                 <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                  <asp:BoundField DataField="CreatedOn" ControlStyle-Font-Bold="true" ItemStyle-Font-Bold="true" HeaderText="Entry Date"  DataFormatString="{0:dd/MM/yyyy}" > 
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
                              <asp:BoundField DataField="OT" HeaderText="Type" ItemStyle-Font-Bold="true" > 
                                   
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>
                                    <asp:BoundField DataField="InFant" HeaderText="InFant" ItemStyle-Font-Bold="true" > 
                                   
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>

                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                  <asp:BoundField DataField="CreatedBy" HeaderText="Created By" ItemStyle-Font-Bold="true" >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>
                                  
                                <asp:ButtonField CommandName="Infant" Text="Infant" HeaderText="Infant" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                       </asp:ButtonField>
                                <asp:TemplateField>
    <ItemTemplate>
   
        <asp:HiddenField ID="HdnOT" runat="server" Value='<%#Eval("OT") %>' /> 
        <asp:HiddenField ID="HdnInFant" runat="server" Value='<%#Eval("InFant") %>' /> 
        </ItemTemplate>
                                    <ItemStyle Width="10px" HorizontalAlign="Center" />
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

                        
                                          <div class="box-body">      
                                
                                                  <div class="col-lg-12 mt-3">
                                                                                                            
                                                 
                                                         <div class="form-group">
                                                             <div class="row"> 
                                                              <div class="col-lg-2">
                                                        <div class="form-group">
                                                            <label for="lblBillServiceCharges">Bill Amount:</label>  
                                                            </div>
                                                    </div>
                                                  <div class="col-lg-1 text-left">
                                                        <div class="form-group">                                                                
                                                            <span> <asp:Label ID="lblBillServiceCharges" runat="server" Font-Bold="True"></asp:Label></span>
                                                        </div>                                                                            
                                                 </div>                                                
                                                  <div class="col-lg-2">
                                                         <div class="form-group">
                                                              <label for="lblAdvanceAmt">Advance Amount:</label>
                                                             </div>
                                                      </div>                                        
                                                  <div class="col-lg-1 text-left ">
                                                <div class="form-group">
                                                <span><asp:Label ID="lblAdvanceAmt" Font-Bold="true" runat="server"></asp:Label></span>
                                            </div> 
                                          </div>
                                                         <div class="col-lg-1 text-left">
                                                        <div  class="form-group">
                                                                 <label >Discount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-1 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblDiscAmt" runat="server" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>
                                                          <div class="col-lg-2 text-left">
                                                        <div  class="form-group">
                                                                 <label >Insurance Amount</label>
                                                            </div>
                                                      </div>                                                                         
                                                          <div class="col-lg-2 text-left">
                                                                                    <div class="form-group">
                                                                                      <span> <asp:Label ID="lblInsurance" runat="server" Text="" Font-Bold="true">
                                                                                     </asp:Label></span></div>
                                                                                </div>

                                                         </div>
                                                     </div>
                                              </div>
                                                
                                                 


                                        <div class="col-lg-12 mt-3" runat="server" visible="false">                                            
                                            <div class="row"> 
                                                    
                                                              <div class="col-lg-2">
                                                                   <label> Payment By: </label>
                                                              </div>
                                                    
                                                    <div class="col-lg-6">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>

                                                 <div class="col-lg-3">
                                             <div class ="row">
                                                    <label class="radio-inline form-check">                                           
                                                        <asp:CheckBox ID="PaymentInsurance" Text="Is Insurance" runat="server" AutoPostBack="true" OnCheckedChanged="PaymentInsurance_CheckedChanged"></asp:CheckBox></label>
                                            </div>
                                            </div>
                                        <div id="InsuranceDetails" runat="server">  
                                                       
                                                       <div class="col-lg-2">
                                                           <div class="form-group">  
                                                        <label>InsuranceAmt: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtInsuranceAmt" runat="server"  class="form-control"  AutoPostBack="True"
                                                     TabIndex="8" OnTextChanged="txtInsuranceAmt_TextChanged1"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                           <div class="col-lg-2">
                                                    <div class="form-group form-check">                                                      
                                                        

                      <asp:RadioButtonList ID="rdblInsuranceAmt" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdblInsuranceAmt_SelectedIndexChanged" >
                          <asp:ListItem Selected="True" Value="0">Amt</asp:ListItem>
                          <asp:ListItem Value="1">Per(%)</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                     </div>    
                                                        
                                                       <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                        <label >InsuranceComp: </label>
                                                               </div>
                                                        </div>
                                                       
                                                           <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                             <asp:DropDownList ID="ddlInsuranceCompName" runat="server" CssClass="form-control form-select" AutoPostBack="true" Width="190px" ></asp:DropDownList>
                                                                   
                                                        
                                                               </div>
                                                        </div>
                                                       
                                                            
                                                        </div>
                                                              
                                                 </div>
                                              </div>       
                        
                                                        
                                        <div id="PaymentDetails" runat="server">
                                                
                                                       <div class="col-lg-12">
                                                           <div class="form-group"> 
                                                               <div class="row">
                                                       <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"  placeholder="Card/Cheque No."
                                                      TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2 text-left">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtbankName" runat="server"  class="form-control"  placeholder="Bank Name" TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2 text-left" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                            
                                                          <asp:TextBox ID="txtchequedate" runat="server" placeholder="Cheque Date"  CssClass ="form-control pull-right" BackColor="White" TabIndex="2"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                  </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                              </div>
                                                                    </div>
                                                           </div>
                                                       
                                                       </div>
                         <div class="col-lg-12 mt-3">                                            
                                                   <div class="row"> 
                                                       <table width="100%" cellpadding="1" cellspacing="1" class="table stable-responsive">

<tr>
    <td>
           <label> Total Amt: </label>
    </td>
    <td  >
         <asp:TextBox ID="txtTotalAmt" Width="150px" runat="server" Text="0" Enabled="false" class="form-control" placeholder="Total Amount"
                                                    TabIndex="8"></asp:TextBox>
    </td>
   
    <td  >
        <table width="200px">
            <tr>
                 <td>
        <label> Disc: </label>
    </td>
                <td> <input id="rdbdiscAmt" type="radio" name="rdbDisc" title="Amt" runat="server" value="Amt"/>
                <label for="rdbdiscAmt">Amt</label>

                </td>
                <td>
 <input id="rdbdiscPer" type="radio" runat="server"  title="Per" name="rdbDisc" value="Per" />
                  <label for="rdbdiscPer">Per(%)</label>
                </td>
            </tr>
        </table>
 
               
    </td>
    
    <td>
 <asp:Button ID="btnDisk" runat="server" class="btn btn-primary" ToolTip="Add Discount" Text="(+)" OnClick="btnDisk_Click"></asp:Button>
    </td>
    <td>
  <asp:TextBox ID="txtDiscount" runat="server" Text="0"  class="form-control"  placeholder="Discount"
                                                     Width="140px" TabIndex="8" AutoPostBack="false" OnTextChanged="txtDiscount_TextChanged" onkeyPress="return numeric_only(event);"></asp:TextBox>


    </td>
  
</tr>
                                                           </table>
                                                        <table width="100%" cellpadding="1" cellspacing="1" class="table stable-responsive">
                                                           <tr>
                                                               <td>
                                                                    <label>Net Amt : </label>
                                                               </td>
                                                               <td>
                                                                   <asp:TextBox ID="txtAmount" runat="server" Width="150px" Text="0" Enabled="false" class="form-control"   placeholder="Amount" onkeyPress="return numeric_only(event);"
                                                       TabIndex="8" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                                               </td>
                                                               <td>
                                                                     <label> Disc Reason : </label>
                                                               </td>
                                                               <td>
                                                                   <asp:DropDownList ID="ddlDiscReason" Width="150px" runat="server" AutoPostBack="True" CssClass="form-control form-select">
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

                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                   <label>  Rec Amt: </label>
                                                               </td>
                                                               <td>
 <asp:TextBox ID="txtAmountReceived" Width="150px" runat="server" ReadOnly="true"  class="form-control" Text="0"  placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                      TabIndex="8" ></asp:TextBox>
                                                               </td>
                                                               <td>
                                                                       <label> Disc Given By: </label>
                                                               </td>
                                                               <td>

                                                               <asp:DropDownList ID="ddlDiscountGivenBy" runat="server" Width="150px" AutoPostBack="True" height="30px" 
                                                    CssClass="form-control form-select">
                                                    </asp:DropDownList>
                                                               </td>
                                                           </tr>
                                                           <tr>
                                                               <td>
                                                         <label> Insurance Amt : </label>
                                                               </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAwardAmt" runat="server" ReadOnly="true" Width="150px"  class="form-control" Text="0" onkeyPress="return numeric_only(event);"
                                                      TabIndex="8" ></asp:TextBox>
                                                               </td>
                                                                <td>
                                            <label> Bal/Ref Reason: </label>
                                                               </td>
                                                                <td>
 <asp:DropDownList ID="ddlBalreason" runat="server" AutoPostBack="True" Width="150px" height="30px"  CssClass="form-control form-select" >
                                                    </asp:DropDownList>
                                                               </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                    <label> Disc Given : </label>
                                                               </td>
                                                                 <td>
 <asp:TextBox ID="txtdiscgiven" runat="server" ReadOnly="true"  class="form-control" Text="0"  height="30px"    onkeyPress="return numeric_only(event);"
                                                     TabIndex="8"  AutoPostBack="True"></asp:TextBox>
                                                               </td>
                                                                 <td colspan="2">
                                                                      <asp:CheckBox ID="chkDeposite" Text="Transfer From Deposit" ForeColor="Red" runat="server" AutoPostBack="true" ></asp:CheckBox>
                                                              <asp:Label ID="lblDepositAmt" ForeColor="Red" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                                      </td>

                                                           </tr>
                                                           <tr>
                                                               <td>
                                                                    <label> Balance : </label>
                                                               </td>
                                                                 <td>
 <asp:TextBox ID="txtPaid" runat="server" Enabled="false" Visible="false"  class="form-control" Text="0"  height="30px"  Width="150px"  placeholder="Paid Amount" onkeyPress="return numeric_only(event);"
                                                      TabIndex="8" OnTextChanged="txtPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                               <asp:TextBox ID="txtbalance" runat="server" text="0" class="form-control" ReadOnly="true"     placeholder="Balance" onkeyPress="return numeric_only(event);"
                                                   TabIndex="8"></asp:TextBox>
                                                                      </td>
                                                                 <td colspan="2">
                                                                     <asp:CheckBox ID="chkFinalDischarge" Text="Final Discharge" ForeColor="Blue" runat="server" AutoPostBack="true" Font-Size="Medium" OnCheckedChanged="chkFinalDischarge_CheckedChanged" ></asp:CheckBox>
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
                                        
                                       
                                          <div class="col-lg-12 text-center">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save" Visible="false"  OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary"  />
                                               <asp:Button ID="btnrefund" runat="server" Text="Refund" Visible="false"    OnClientClick="return Validate1();"
                                        TabIndex="15" Width="80px" class="btn btn-primary" OnClick="btnrefund_Click"  />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="80px" />
                                            <asp:Button ID="BtnDischarge" runat="server" Text="Discharge" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Visible="false" Width="100px" OnClick="BtnDischarge_Click"   />
                                       <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-warning" Width="100px"   OnClick="btnReport_Click" />
                                       <asp:Button ID="btnSummary" runat="server" Text="Summary" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-success" Width="100px"   OnClick="btnSummary_Click" />

                                   
                                         
                                             
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
              
</asp:Content>

