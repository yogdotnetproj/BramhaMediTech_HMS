<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="IVFluidChart.aspx.cs" Inherits="IVFluidChart" %>

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
     <section class="content-header d-flex">
        <h1>IV fluid chart</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">IV fluid chart</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
             <div class="box-body">
                <div class="row">
                    
                    <div class="col-lg-12 text-left">
                    <div class="col-lg-4 text-left">
                    <div class="form-group">
                    <label for="lblPatientName" style="text-align: left">Name:</label>
                    <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                    </div>
                    </div>

                    <div class="col-lg-2 text-left">
                    <div class="form-group">
                    <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                    <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                    </div>
                    </div>
                    <div class="col-lg-2 text-left">
                    <div class="form-group">
                    <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                    <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                    </div>
                    </div>
                    <div class="col-lg-2 text-left">
                    <div class="form-group">
                    <label for="lblOpd" title="" style="text-align: left">OPD No:</label>
                    <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                    </div>
                    </div>

                              
                    <div class="col-lg-2 text-left">
                    <div class="form-group">
                    <label for="lblBranchId" title="" style="text-align: left">Mobile No:</label>
                    <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                    </div>
                    </div>
                    </div>
                    </div>
                <div class="row">
                <div class="col-lg-12 text-left">
                <div class="col-lg-4 text-left">
                <div class="form-group">
                <label for="lbldName" title="" style="text-align: left">Dr Name:</label>
                <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                </div>
                </div>

                <div class="col-lg-2 text-left">
                <div class="form-group">
                <label for="lblPrnNo" title="" style="text-align: left">Age:</label>
                <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                </div>
                </div>
                <div class="col-lg-3 text-left">
                <div class="form-group">
                                       
                <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=" Vitals Taken:"></asp:Label>
                <asp:Label ID="lblvtaken" runat="server" Text=""></asp:Label>
                </div>
                </div>
                <div class="col-lg-2 text-left">
                        <div class="form-group">
                        <label for="lblIpd"   title="  " style="text-align: left"></label>
                        <label for="lblOpd" title="" style="text-align: left"></label>
                                        
                        </div>
                </div>

                               
                <div class="col-lg-1 text-left">
                <div class="form-group">
                <label for="lblBranchId" style="text-align: left"></label>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                </div>
                </div>
                </div>
                </div>
                <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>               
                <div class="col-lg-12">
                                 <div class="row"> 
                                       <div class="col-lg-3 text-left"  style="width:200px">
                                                        <div class="form-group">  
                                                                                       
                                                 <label for="txttimestart">Date</label>            
                                                         <%--  <input type="text" value="9/23/2009" style="width: 100px;" readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>--%>
                      <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                              <asp:TextBox ID="txttimestart" runat="server" class="form-control"  placeholder="Enter Time Start"    
                                                                 Width="140px" AutoPostBack="True"></asp:TextBox>
                                                             
                                                                    <span class="input-group-addon">
                                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                                    </span>                                                     
                         
                                                            </div>
                                                    
                                                        </div>
                                                    </div>
                                       <div class="col-lg-3 text-left"  style="width:140px">
                                                        <div class="form-group">  
                                                            <label for="txtTime">Start Time</label>                        
                                                            <asp:TextBox ID="txtTime" runat="server"  class="form-control" 
                                                           Font-Bold="True"  Width="120px" Font-Size="Large"></asp:TextBox>  
                                                            </div>
                                           </div>   
                                     <div class="col-lg-3 text-left" style="width:200px" >
                                                        <div class="form-group">  
                                                              <label for="txtTime">End Time</label>                       
                                                            <asp:TextBox ID="txtEndTime" runat="server"  class="form-control" 
                                                           Font-Bold="True"  Width="120px" Font-Size="Large"></asp:TextBox>  
                                                            </div>
                                           </div>   
                                     </div>
                    </div> 
                <div class="col-lg-12">
                    <div class="row">
             <div class="col-lg-3 form-group" style="width:350px">
            <label for="txtIVFluid">IV Fluid</label>
           <%-- <asp:DropDownList ID="ddlIvfluid" runat="server" class="form-control" >
            
            </asp:DropDownList>--%>
                 <asp:TextBox ID="txtIVFluid" runat="server" class="form-control" 
                                  Font-Bold="True"  Width="340px" Font-Size="Large"></asp:TextBox>  
            </div>
                <div class="col-lg-3 form-group" style="width:350px">
            <label for="txtDrug">Drug</label>
           <%-- <asp:DropDownList ID="ddlDrug" runat="server" class="form-control" >            
            </asp:DropDownList>--%>
                    <asp:TextBox ID="txtDrug" runat="server"  class="form-control" 
                                  Font-Bold="True"  Width="340px" Font-Size="Large"></asp:TextBox>  
            </div>
                
                <div class="col-lg-3 form-group" style="width:300px">
                    <label for="txtNurse"><b>Nurse</b></label>
                        <div class="row">
                            <div class="col-lg-1"style="width:300px">
                                 <asp:TextBox ID="txtNurse" runat="server" ReadOnly="true"  class="form-control" 
                                  Font-Bold="True"  Width="290px" Font-Size="Large"></asp:TextBox>  
                            </div>
                       </div>
                </div>
                    </div>            
                </div>
                <div class="col-lg-12 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-primary btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:150px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="IVChartId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                   <asp:BoundField DataField="DateInput" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TimeInput" HeaderText="Time" />
                                    <asp:BoundField DataField="IvFluidName"  HeaderText="Iv Fluid" />
                                    <asp:BoundField DataField="DrugName"  HeaderText="Drug" />
                                    
                                <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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

                                                          
</div>
            </div>
                     
            
</section>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>

