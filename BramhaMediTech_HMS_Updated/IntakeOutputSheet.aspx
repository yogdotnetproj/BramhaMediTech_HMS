<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="IntakeOutputSheet.aspx.cs" Inherits="IntakeOutputSheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: white;
            width: auto;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no .modalPopup .cancel {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup .cancel {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style>
    
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
     <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript">

    function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
    }
        </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Intake Output Chart</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Intake Output Chart</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
           
             <div class="box-body">
                    
        <div class="col-lg-12">
            <div class="row">
                
                    <div class="form-group">
                        <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                    </div>
                
            </div>
        </div>
               
            <div class="col-lg-12 mt-3">
                             <div class="row"> 
                                   <div class="col-sm-3 text-left" >
                                                    <div class="form-group">  
                                                                                       
                                                             
                                                     <%--  <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>--%>
                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txttimestart" runat="server" CssClass="form-control"  placeholder="Enter Time Start"    
                                                             AutoPostBack="True"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                  <i class="fa fa-calendar"></i>
                                                                 </span>                                                     
                         
                                                        </div>
                                                    
                                                    </div>
                                                </div>
                                   <div class="col-sm-2 text-left" >
                                                    <div class="form-group">  
                                                                                
                                                        <asp:TextBox ID="txtTime" runat="server"  CssClass="form-control" 
                                                       Font-Bold="True"></asp:TextBox>  
                                                        </div>
                                       </div>   
                                 </div>
                </div> 
            <div class="col-lg-12 mt-3">
            <div class="row">
            <div class="col-sm-6">                                            
            <div class="panel panel-info">
            <div class="panel-heading">Intake</div>
            <div class="panel-body">
                            
            <div class="col-sm-12">
            <div class="form-group">
            <div class="row">
                    <div class="col-sm-6 form-group">
                    <label for="txtOralIntake"><b>Oral Intake</b></label>
                        <div class="row">
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlOralType"  runat="server" CssClass="form-control form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlOralType_SelectedIndexChanged" >
                               <%-- <asp:ListItem Value="0">SelectType</asp:ListItem>--%>                                
                                <asp:ListItem>Liquid</asp:ListItem>
                                <asp:ListItem>Solid</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                            <asp:TextBox ID="txtOralIntake" runat="server" Text="0" onkeypress="return isNumberKey(event,this)"   CssClass="form-control" 
                                ></asp:TextBox>
                                    </div>
                            <div class="col-sm-3 p-0" >
                            <asp:DropDownList ID="ddlUnitOral" AutoPostBack="true" runat="server" CssClass="form-control form-select" >
                                <asp:ListItem Value="0">Sel.Unit</asp:ListItem>
                                <asp:ListItem>ML</asp:ListItem>
                                <asp:ListItem>Gram</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                        </div>
                    </div>
                    <div class="col-sm-6 form-group">
                    <label for="txtIV"><b>Intravenous Intake</b></label>
                        <div class="row">
                            <div class="col-sm-6">
                    <asp:TextBox ID="txtIV" runat="server" Text="0" onkeypress="return isNumberKey(event,this)"  CssClass="form-control" ></asp:TextBox>
                                </div>
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlIUnit" runat="server" CssClass="form-control form-select" >
                                                                            
                                <asp:ListItem Selected="True">ML</asp:ListItem>
                                                                             
                            </asp:DropDownList>
                                </div>
                            </div>
                    </div>  
            </div>
            </div>
                                                          
            </div>
                                  
            <div class="col-lg-12 mt-3">
            <div class="form-group">
            <div class="row">
                    <div class="col-sm-6 form-group">
                    <label for="txtOralIntake"><b>Other Intake</b></label>
                        <div class="row">
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlotherType" runat="server" AutoPostBack="true" CssClass="form-control form-select" OnSelectedIndexChanged="ddlotherType_SelectedIndexChanged" >
                               <%-- <asp:ListItem Value="0">SelectType</asp:ListItem>--%>
                               
                                <asp:ListItem>Liquid</asp:ListItem>
                                 <asp:ListItem>Solid</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                            <asp:TextBox ID="txtOtherIntake" onkeypress="return isNumberKey(event,this)"  Text="0" runat="server"  CssClass="form-control" 
                                AutoPostBack="True" ></asp:TextBox>
                                    </div>
                            <div class="col-sm-3 p-0">
                            <asp:DropDownList ID="ddlOtherUnit" AutoPostBack="true" runat="server" class="form-control form-select" >
                                <%--<asp:ListItem Value="0">Sel.Unit</asp:ListItem>--%>
                                <asp:ListItem>ML</asp:ListItem>
                                <asp:ListItem>Gram</asp:ListItem>
                            </asp:DropDownList>
                                </div>
                        </div>
                    </div>

                    <div class="col-sm-6 form-group">
                        <label for="txtBloodIntake"><b>Blood Intake</b></label>
                        <div class="row">
                            <div class="col-sm-6">
            <asp:TextBox ID="txtBloodIntake" runat="server" Text="0" onkeypress="return isNumberKey(event,this)"  CssClass="form-control"></asp:TextBox>
            </div>
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlBloodUnit" runat="server" CssClass="form-control form-select" >
                                                                            
                                <asp:ListItem Selected="True">ML</asp:ListItem>
                                                                             
                            </asp:DropDownList>
                                </div>
                            </div>

            </div>
                </div>
            </div>
            </div>

            <div class="col-sm-12 mt-3">
            <div class="form-group">
            <div class="row">
                <div class="col-sm-6 form-group">
                    <label for="txtRemark"><b>Remark</b></label>
                        <div class="row">
                            <div class="col-sm-12">
                                <textarea  rows="2" id="txtRemark"  class="form-control" runat="server" ></textarea>
                                </div>
                            </div>
                    </div>
                <div class="col-sm-6 form-group">
                    <label for="txtRTF">NG Feed</label>
                            <div class="row">
                                <div class="col-sm-6">
            <asp:TextBox ID="txtRTF" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
            </div>
                                <div class="col-sm-6">
                                <asp:DropDownList ID="DropDownList2"  runat="server" CssClass="form-control form-select" >
                                                                            
                                    <asp:ListItem Selected="True">ML</asp:ListItem>
                                                                             
                                </asp:DropDownList>
                                </div>
                            </div>
                    </div>

                                                                
                </div>
            </div>
            </div>
                                                
                                           
                                                
            </div>
            </div>
                                           
            </div> 
            <div class="col-sm-6">
                                        
            <div class="panel panel-info">
            <div class="panel-heading">Output
                                                     
            </div>
            <div class="panel-body" >
                <div class="col-sm-12 form-group">
                    <div class="form-group">
            <div class="row" >
                    <div class="col-sm-6 form-group">
                        <label for="txtVomit"><b>Vomit Output</b></label>
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtVomit" Text="0" runat="server" onkeypress="return isNumberKey(event,this)"  CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlvomit" runat="server" CssClass="form-control form-select" >                                                                            
                                    <asp:ListItem Selected="True">ML</asp:ListItem>                                                                             
                            </asp:DropDownList>
                        </div>
                        </div>

            </div>

            <div class="col-sm-6 form-group">
            <label for="txtIV"><b>Urine OutPut</b></label>
                    <div class="row">
                            <div class="col-sm-6">
                            <asp:TextBox ID="txtUrine" runat="server" Text="0" onkeypress="return isNumberKey(event,this)"  CssClass="form-control"></asp:TextBox>
                        </div>  
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlUrine" runat="server" CssClass="form-control form-select" >
                                <asp:ListItem Selected="True">ML</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>

                                                          
            </div>
            <div class="row mt-3">
            <div class="col-sm-6 form-group">
                        <label for="txtOtherOP"><b>Other Output</b></label>
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtOtherOP" runat="server" Text="0" onkeypress="return isNumberKey(event,this)"  CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlOtherOP" runat="server" CssClass="form-control form-select" >                                                                            
                                    <asp:ListItem Selected="True">ML</asp:ListItem>                                                                             
                            </asp:DropDownList>
                        </div>
                        </div>

            </div>

            <div class="col-sm-6 form-group" runat="server" visible="false">
            <label for="txtRTA"><b>R.T.A</b></label>
                    <div class="row">
                            <div class="col-sm-6">
                            <asp:TextBox ID="txtRTA" runat="server" Text="0" onkeypress="return isNumberKey(event,this)"  CssClass="form-control" ></asp:TextBox>
                        </div>  
                            <div class="col-sm-6">
                            <asp:DropDownList ID="ddlRTA" runat="server" CssClass="form-control form-select" >
                                <asp:ListItem Selected="True">ML</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
            </div>


            </div>
                                               
            <div class="row mt-3"> 
            <div class="col-sm-6 form-group>
            <label for="txtRTF">Bowel</label>
            <asp:DropDownList ID="ddlbowel" runat="server" CssClass="form-control form-select" >
            <asp:ListItem Value="0">Select</asp:ListItem>
            <asp:ListItem>YES</asp:ListItem>
            <asp:ListItem>NO</asp:ListItem>
            </asp:DropDownList>
            </div>
            </div>

                                                          

                                                
            </div>
            </div> 
                                       
            </div>
            </div>

            </div>
                         
            </div>
            
          
            </div>
<div class="col-lg-12 mt-3 text-center">
<div class="form-group">
<asp:Button ID="btnsave" runat="server" Text="Save"  UseSubmitBehavior="false" OnClientClick="this.disabled='true';this.Value='Please Wait...';" class="btn btn-success" OnClick="btnsave_Click" />
<asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" />
      <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-primary btnSearch" OnClick="btnReport_Click"  />                                       
                  
                                       
</div>
</div>

<div class="col-lg-12 mt-3">
<div class="row">
<%--<div runat="server" id="UploadedFiles" style="height:450px; width:1200px; overflow:scroll"    > --%>  
<%--<div class="table-responsive" style="width: 100%">--%>
<div   class="table-wrapper" style="width: 100%">
<asp:GridView ID="gvIntakeOP" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
  class="table table-bordered"   HeaderStyle-CssClass="FixedHeader" Width="100%" DataKeyNames="IOId"
HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"  CellPadding="3" OnRowDeleting="gvIntakeOP_RowDeleting"
AllowPaging="True" BackColor="White" OnRowCommand="gvIntakeOP_RowCommand" OnRowEditing="gvIntakeOP_RowEditing"
BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="500" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvIntakeOP_PageIndexChanging" OnRowDataBound="gvIntakeOP_RowDataBound">
<Columns>

<asp:ButtonField CommandName="Edit" Text="Edit" Visible="false" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
<asp:BoundField DataField="DateInput" HeaderText="Date" />
    <asp:BoundField DataField="TimeInput" HeaderText="Time" />
    <asp:BoundField DataField="CreatedBy" HeaderText="Enter by" />
    <asp:BoundField DataField="OralIntakeQty1"  HeaderText="OralIntake" />
<asp:BoundField DataField="IVIntake1" HeaderText="IV Intake" ItemStyle-Width="150" />
<asp:BoundField DataField="BloodIntake1" HeaderText="BloodIntake" ItemStyle-Width="50" />
<asp:BoundField DataField="OtherIntake1" HeaderText="OtherIntake" />
<asp:BoundField DataField="RTF1" HeaderText="NG Feed" />
<asp:BoundField DataField="VomitOutPut1" HeaderText="Vomit O/P" />
<asp:BoundField DataField="UrineOutPut1" HeaderText="Urine O/P" />
<asp:BoundField DataField="RTA1" Visible="false" HeaderText="RTA" />
<asp:BoundField DataField="OtherOutput1" HeaderText="Other O/P" />
<asp:BoundField DataField="OralIntakeQty" visible="false" HeaderText="OralIntake" />
<asp:BoundField DataField="IVIntake" visible="false" HeaderText="IV Intake" ItemStyle-Width="150" />
<asp:BoundField DataField="BloodIntake" visible="false" HeaderText="BloodIntake" ItemStyle-Width="50" />
<asp:BoundField DataField="OtherIntake" visible="false" HeaderText="OtherIntake" />
<asp:BoundField DataField="RTF" visible="false" HeaderText="RTF" />
<asp:BoundField DataField="VomitOutPut" visible="false" HeaderText="Vomit O/P" />
<asp:BoundField DataField="UrineOutPut" visible="false" HeaderText="Urine O/P" />
<asp:BoundField DataField="RTA" visible="false" HeaderText="RTA" />
<asp:BoundField DataField="OtherOutput"  visible="false" HeaderText="Other O/P" />
<asp:BoundField DataField="Bowel" HeaderText="Bowel" />
    <asp:BoundField DataField="Remark" HeaderText="Remark" />

<asp:BoundField DataField="TypeOfOralIntake" Visible="false" HeaderText="TypeOfOralIntake" />
<asp:BoundField DataField="OtherIntakeType" Visible="false" HeaderText="OtherIntakeType" />
     <asp:BoundField DataField="UpdatedOn" Visible="false" HeaderText="Updated On" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="UpdatedBy" Visible="false" HeaderText="Updated by" />
<asp:ButtonField CommandName="Delete" Text="Delete" Visible="false" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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

<%--</div>--%>
</div>
</div>
</div>
<div class="col-lg-12 mt-3">
                        
<div class="form-group">
<div class="row">
        <div class="col-sm-2">
        <label for="txtLiquidInput"><b>Liquid Input</b></label>
            </div>
                    <div class="col-sm-2">
                <asp:TextBox ID="txtLiquidInput" runat="server" Text="0" ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                        </div>
                <div class="col-sm-2">
                <label for="txtLiquidOutPut"><b>Liquid Output</b></label>
                    </div>
        <div class="col-sm-2">
                <asp:TextBox ID="txtLiquidOutPut" runat="server" Text="0" ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                        </div>
        <div class="col-sm-2">
                <label for="txtbalance"><b>Balance</b></label>
                    </div>
        <div class="col-sm-2">
                <asp:TextBox ID="txtbalance" runat="server" Text="0" ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                        </div>
            </div>
        <div class="row mt-3">

        <div class="col-sm-2">
        <label for="txtSolidIP"><b>solid Input</b></label>
            </div>
                    <div class="col-sm-2">
                <asp:TextBox ID="txtSolidIP" runat="server" Text="0" ReadOnly="true" CssClass="form-control"  ></asp:TextBox>
                        </div>
                <div class="col-sm-2">
                <label for="txtSolidOP"><b>Solid Output</b></label>
                    </div>
            <div class="col-sm-2">
                <asp:TextBox ID="txtSolidOP" runat="server" Text="0" ReadOnly="true" CssClass="form-control"  ></asp:TextBox>
                        </div>
            <div class="col-sm-2">
                <label for="txtSolidbalance"><b>Balance</b></label>
                    </div>
        <div class="col-sm-2">
                <asp:TextBox ID="txtSolidbalance" runat="server" Text="0" ReadOnly="true" CssClass="form-control" ></asp:TextBox>
                        </div>
            </div>
                                                                   
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
</asp:Content>



