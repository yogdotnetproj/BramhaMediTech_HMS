<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="AdditionalMonitorSheet.aspx.cs" Inherits="AdditionalMonitorSheet" %>

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
        </script>
<%--    <style type="text/css">
  .FixedHeader {
    
     position: sticky;  
   
 }     
</style> --%>
   


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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Additional Monitor Sheet</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Additional Monitor Sheet</li>
                    </ol>
    </section>
   
        <div id="Div1" class="box" runat="server">
            
          
             <div class="box-body">
                
                    
                   
                <div class="col-lg-12 mt-3">
                <div class="row">
                    
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    
                </div>
            </div>               
                   <div class="col-lg-12 mt-3" runat="server" >
                                 <div class="row" runat="server" visible="false"> 
                                       <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txttimestart" runat="server" CssClass="form-control"  placeholder="Enter Time Start"    
                                                            AutoPostBack="false"></asp:TextBox>
                                                             
                                                                <span class="input-group-addon">
                                                                  <i class="fa fa-calendar"></i>
                                                                 </span>                                                    
                         
                                                        </div> 
                                                            </div>
                                           </div>
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                                <asp:TextBox ID="txtTime" runat="server"  CssClass="form-control" 
                                                       Font-Bold="True" Font-Size="Large"></asp:TextBox>  
                                                            </div>
                                           </div>
                                     
                       </div>
                 <div id="Div2" class="col-lg-12 mt-3" runat="server" >
                                 <div class="row"> 
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"> <strong> Blood Pressure</strong></label>   
                                                            <asp:TextBox runat="server" ID="txtBloodPressure" CssClass="form-control mt-2"  placeholder="EnterBlood Pressure"  />  
                                                            </div>
                                           </div>
                                    
                                     
                                      
                                       <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                                               <label for="txttimestart"><strong>Temp.</strong></label>     
                                                             <asp:TextBox runat="server" ID="txtTemp"     CssClass="form-control mt-2"  placeholder="Enter Temp"  />
                                                            </div>
                                           </div>
                                       <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Pulse</strong></label>     
                                                             <asp:TextBox runat="server" ID="txtPulse"     CssClass="form-control mt-2"  placeholder="Enter Pulse"  />
                                                            </div>
                                           </div>
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Resp.Rate</strong></label>     
                                                            <asp:TextBox runat="server" ID="txtRespRate" CssClass="form-control mt-2" onkeyPress="return numeric_only(event);"   placeholder="Enter Resp.Rate"  />
                                                            </div>
                                           </div>
                                     
                                       <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>SPO2</strong></label>   
                                                             <asp:TextBox runat="server" ID="txtspo2" CssClass="form-control mt-2"  placeholder="Enter SPo2"  />  
                                                            </div>
                                           </div>
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Blood Sugar</strong></label>     
                                                            <asp:TextBox runat="server" ID="txtBloodSugar" CssClass="form-control mt-2"  placeholder="Enter Blood Sugar"  />
                                                            </div>
                                           </div>       
                                     </div>
                     </div>
                                                            <div id="Div3" class="col-lg-12 mt-3" runat="server" >
                                 <div class="row">
                                       <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Urinary Output</strong></label>     
                                                            <asp:TextBox runat="server" ID="txtUrinaryoutput" CssClass="form-control mt-2"  placeholder="Enter Urinary Output"  />
                                                            </div>
                                           </div>
                                     <div class="col-sm-2 text-left pr-0">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>FHR(bpm)</strong></label>     
                                                             <asp:TextBox runat="server" ID="txtFHR" CssClass="form-control mt-2"  placeholder="FHR(bpm)"  />
                                                            </div>
                                           </div>
                                     
                                      
                                       <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>MISC</strong></label>
                                                            <asp:TextBox runat="server" ID="txtMISC" class="form-control mt-2"  placeholder="MISC"  />     
                                                            </div>
                                           </div>
                                     
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Contractions</strong></label>    
                                                            <asp:TextBox runat="server" ID="txtContractions" CssClass="form-control mt-2"  placeholder="Contractions"  /> 
                                                            </div>
                                           </div>
                                      <div class="col-sm-4 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Name & Position(RN,RM,SN,NA)</strong></label>    
                                                            <asp:TextBox runat="server" ID="txtnameposi" CssClass="form-control mt-2"  placeholder="RN,RM,SN,NA"  /> 
                                                            </div>
                                           </div>
                                    
                                     </div>
                       </div>
                   <div id="Div6" class="col-lg-12 mt-3" runat="server" >
                                 <div class="row"> 
                                      <div class="col-sm-1 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart"><strong>Remark</strong></label>     
                                                            </div>
                                           </div>
                                     <div class="col-sm-11 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txtRemark" CssClass="form-control" placeholder="Enter Remark" rows="5"  />
                                                            </div>
                                           </div>
                                     </div>
                       </div>

                
                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" Visible="false" CssClass="btn btn-primary btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
                <div class="col-lg-12 mt-3">
                    <div class="row">
                      <%--  <div runat="server" id="UploadedFiles" style="height:450px; width:1200px; overflow:auto"  >   --%>
                             <div   class="table-wrapper" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-bordered"   HeaderStyle-CssClass="FixedHeader" Width="100%" DataKeyNames="VId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="500" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging" OnRowDataBound="gvDailyNurseNote_RowDataBound">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Visible="false" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                   <asp:BoundField DataField="DateInput" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TimeInput" HeaderText="Time" />
                                    <asp:BoundField DataField="CreatedBy" HeaderText="Enter by" />
                                    <asp:BoundField DataField="BloodPRessure" HeaderText="BloodPressure" />
                                     <asp:BoundField DataField="Temp" HeaderText="Temp" />
                                    <asp:BoundField DataField="Pulse" HeaderText="Pulse" />
                                    <asp:BoundField DataField="RespRate" HeaderText="RespRate" />
                                    <asp:BoundField DataField="Spo2"  HeaderText="Spo2" />
                                    <asp:BoundField DataField="BloodSugar"  HeaderText="BloodSugar" />
                                    <asp:BoundField DataField="UrinaryOutput"  HeaderText="UrinaryOutput" />
                                    <asp:BoundField DataField="FHR"  HeaderText="FHR" />
                                    <asp:BoundField DataField="MISC"  HeaderText="MISC" />
                                    <asp:BoundField DataField="Contractions"  HeaderText="Contractions" />
                                    <asp:BoundField DataField="NamePosition"  HeaderText="NamePosition" />
                                     <asp:BoundField DataField="VitalRemark"  HeaderText="Remark" />
                                     <asp:BoundField DataField="UpdatedBy" Visible="false"  HeaderText="Updated by" />
                                     <asp:BoundField DataField="UpdatedOn" Visible="false" HeaderText="Updated On"  DataFormatString="{0:dd/MM/yyyy hh:mm tt}"  />
                                     
                                    
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
                             </div>
                        <%--</div>--%>
                    </div>
                </div>

                                                          
</div>
            </div>
            </div>
                     
            

    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
 
</asp:Content>

