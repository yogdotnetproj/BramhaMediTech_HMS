<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="RecordsofMonitor_Oxygen.aspx.cs" Inherits="RecordsofMonitor_Oxygen" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
              <asp:PostBackTrigger ControlID="btnEditImage" />
          <asp:PostBackTrigger ControlID="btnCard" />
          

        </Triggers>--%>
        <ContentTemplate>
     <section class="content-header d-flex">
        <h1>Records of Monitor Oxygen</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Records of Monitor Oxygen</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
             <div class="box-body">
                
                      


                <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>               
                <div class="panel-heading">RECORDS OF MONITOR USED:
                    </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <strong>Date Attached</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <strong>Time Attached</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <strong>Date Detached</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <strong>Time Detached</strong>
                                 </div>
                            </div>
                        </div>
                     </div>
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                
                                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtDateAttached" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtTimeAttached" CssClass="form-control"  runat="server"></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 
                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtDateDetached" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtTimeDetached" CssClass="form-control"  runat="server"></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-1 text-left">
                             <div class="form-group">
                        <asp:Button ID="btnaddMonitor" runat="server"  Text="Add" class="btn btn-success btnSearch" OnClick="btnaddMonitor_Click"  />
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                         <asp:Button ID="btnMonitorrep" runat="server" Text="Report" class="btn btn-warning btnSearch" OnClick="btnMonitorrep_Click"   />  
                                 </div>
                             </div>
                        </div>
                     </div>
                  <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:250px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="MonId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" Visible="false" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                <asp:BoundField DataField="MonAttDate" HeaderText="Date"  DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="MonAttTime" HeaderText="Time" />
                                    <asp:BoundField DataField="AttachedBy"  HeaderText="AttachedBy" />
                                    <asp:BoundField DataField="MonDetDate"  HeaderText="Mon Detect Date"  DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="MonDetTime"  HeaderText="MonDetTime" />
                                     <asp:BoundField DataField="DetectedBy"  HeaderText="DetectedBy" />
                                     
                                <asp:ButtonField CommandName="Delete" Text="Delete" Visible="false" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
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
                </div>
                   <div class="col-lg-12 mt-3">
                  <div class="panel-heading">RECORDS OF OXYGEN USED:
                    </div>
                       </div>

                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <strong>Date Started</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <strong>Time Started</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <strong>LMP</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 <strong>Date Discontinued</strong>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <strong>Time Discontinued</strong>
                                 </div>
                            </div>
                        </div>
                     </div>

                
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 
                                 
                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdateOxy" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtTimeOxystart" CssClass="form-control"  runat="server"></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtLmp" CssClass="form-control"  runat="server"></asp:TextBox>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                 
                                  <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtdateDisOxy" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                 </div>
                            </div>
                        <div class="col-lg-2 text-left">
                             <div class="form-group">
                                  <asp:TextBox ID="txtTimeDisOxy" CssClass="form-control"  runat="server"></asp:TextBox>
                                 </div>
                            </div>
                          <div class="col-lg-1 text-left">
                             <div class="form-group">
                        <asp:Button ID="btnAddOxy" runat="server"  Text="Add" class="btn btn-success btnSearch" OnClick="btnAddOxy_Click"  />
                                 </div>
                            </div>
                         <div class="col-lg-1 text-left">
                             <div class="form-group">
                         <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-warning btnSearch" OnClick="btnReport_Click"  />  
                                 </div>
                             </div>
                        </div>
                     </div>
                    
                      <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="Div2" style="height:250px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="MonId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" Visible="false" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                <asp:BoundField DataField="OxyStartDate" HeaderText="Date"  DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="OxyStartTime" HeaderText="Time" />
                                    <asp:BoundField DataField="LMP"  HeaderText="LMP" />
                                     <asp:BoundField DataField="AttachedBy"  HeaderText="Attached By" />
                                    <asp:BoundField DataField="OxydisDate"  HeaderText="Oxygen discontinued Date"  DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="OxydisTime"  HeaderText="Oxy dis Time" />
                                     <asp:BoundField DataField="DiscontinuedBy"  HeaderText="Discontinued By" />
                                     
                                <asp:ButtonField CommandName="Delete" Text="Delete" Visible="false" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
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
                </div>
                 

                <div class="col-lg-12 mt-3 text-center" runat="server" visible="false">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server"  Text="Save" class="btn btn-success btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                                                            
                  
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


