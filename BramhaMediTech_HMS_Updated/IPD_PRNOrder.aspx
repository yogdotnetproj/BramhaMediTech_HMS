<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="IPD_PRNOrder.aspx.cs" Inherits="IPD_PRNOrder" %>


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
        <style>
    /* Make the header sticky */
    .FixedHeader {
        position: sticky;
        top: 0;
        background-color: #38C8DD;
        z-index: 10; /* Ensure it stays above the grid rows */
    }

    /* Add box-shadow to the header for better visual separation */
    .table th {
        box-shadow: 0 2px 5px rgba(0,0,0,0.1);
    }

    /* Ensure the GridView has enough space for the header to stick */
    .table-wrapper {
        max-height: 500px; /* Set a maximum height for the grid */
        overflow-y: auto;  /* Allow scrolling */
    }
</style>
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <asp:UpdatePanel runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
          
          
             
          
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>PRN ORDERS</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">PRN ORDERS</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                  
                    <div class="box-body">
           
                           <div class="col-lg-12 mt-3 " >
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                     <strong>PRN ORDERS</strong> 
                                       
                                        </div>
                                </div>
                            </div>
                            </div>
                         <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                         <asp:gridview ID="GvHairLaser" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Medication" >

            <ItemTemplate>
                 <asp:Label ID="lblorder" Text="Order"  runat="server"></asp:Label>
                
                <asp:TextBox ID="txtMedication" Text='<%# Eval("Medication") %>' TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="200px" HorizontalAlign="Center" />
             <HeaderStyle Width="200px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
<asp:Label ID="lblorder1" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign1" Text='<%# Eval("DoseSign1") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
                <asp:Label ID="lblorder2" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign2" Text='<%# Eval("DoseSign2") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
              <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
                <asp:Label ID="lblorder3" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign3" Text='<%# Eval("DoseSign3") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
                <asp:Label ID="lblorder4" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign4" Text='<%# Eval("DoseSign4") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
                <asp:Label ID="lblorder5" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign5" Text='<%# Eval("DoseSign5") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
                <asp:Label ID="lblorder6" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign6" Text='<%# Eval("DoseSign6") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="DateTime/DoseSig" >

            <ItemTemplate>
                <asp:Label ID="lblorder7" Text=" &nbsp;  "  runat="server"></asp:Label>
                <asp:TextBox ID="txtDoseSign7" Text='<%# Eval("DoseSign7") %>' CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
                  <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />

            </FooterTemplate>
        </asp:TemplateField>

             
           

        </Columns>

</asp:gridview>
                                        </div>
                                </div>
                        
                             </div>
                     
                       
      
                        
                                        
                                       
                                          <div class="col-lg-12 text-center">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save"   OnClick="btnSave_Click"  OnClientClick="return Validate1();"
                                        TabIndex="15" class="btn btn-success"  />
                                               
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary"/>
                                           
                                       <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Visible="false" OnClick="btnReport_Click" />

                             
                                         
                                             
                                        </div>    
                                        <div class="col-lg-12 mt-3" runat="server" visible="false">
                    <div class="row">
                         <div   class="table-wrapper" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-bordered"   HeaderStyle-CssClass="FixedHeader" Width="100%" DataKeyNames="Id"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                   <asp:BoundField DataField="CreatedOn" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="CreatedBy" HeaderText="Enter by" />
                                    <asp:BoundField DataField="IPD_Height" HeaderText="Height" />
                                    <asp:BoundField DataField="IPD_weight"  HeaderText="Weight" />
                                     <asp:BoundField DataField="IPD_BP" HeaderText="BP" />
                                    <asp:BoundField DataField="BpType"  HeaderText="Bp Type" />
                                     <asp:BoundField DataField="IPD_Temp"  HeaderText="Temp" />
                                     <asp:BoundField DataField="IPD_Resp"  HeaderText="Resp" />
                                     <asp:BoundField DataField="IPD_pulse" HeaderText="Pulse"  />
                                    <asp:BoundField DataField="IPD_ProvDiagnosis"  HeaderText="Allergies" />
                                     <asp:BoundField DataField="IPD_FinalDiagnosis"  HeaderText="Diagnosis" />
                                 <%--   <asp:BoundField DataField="IPD_History"  HeaderText="History" />--%>
                                    
                                    
                                  
                                <asp:ButtonField CommandName="Delete" Visible="false" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
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
                                              
                    
                </section>
            <script language="javascript" type="text/javascript">
                function OpenReport() {
                    window.open("Reports.aspx");
                }
               </script>
                    </ContentTemplate>
        </asp:UpdatePanel>
              
</asp:Content>

