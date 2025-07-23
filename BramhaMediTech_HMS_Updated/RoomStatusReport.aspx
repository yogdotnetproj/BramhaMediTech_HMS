<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="RoomStatusReport.aspx.cs" Inherits="RoomStatusReport" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtRoomName").value == "") {
                alert("Please Enter Room Name");
                return false;
            }
            if (document.getElementById("MainContent_ddlRoomTypeName").value == "0") {
                alert("Please Select Room Type");
                return false;
            }
            if (document.getElementById("MainContent_txtTotalBed").value == "") {
                alert("Please Enter Total Bed");
                return false;
            }

            if (document.getElementById("MainContent_txtRoomAddress").value == "") {
                alert("Please Enter Room Address");
                return false;
            }
        }
        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
       <asp:PostBackTrigger ControlID="btnDetailReport" />
       <asp:PostBackTrigger ControlID="btnDetailExcelReport" />
        </Triggers>
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Room Status</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="active breadcrumb-item">Room Status</li>
                    </ol>
            </section>
          <section class="content">
                            
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="ddlRoomTypeName">Room Type:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">                                            
                                            <div class="form-group"> 
                                            
                                                 <asp:DropDownList ID="ddlRoomTypeName" runat="server" CssClass="form-control form-select">
                                                </asp:DropDownList>
                                               
                                            </div>
                                          </div> 
                                        <div class="col-sm-6 text-left">
                                    
                                             <asp:Button ID="btnSearch" runat="server"  CssClass="btn btn-warning"  Text="Search" OnClick="btnSearch_Click" /> 
                                            <asp:Button ID="btnReport" runat="server"  CssClass="btn btn-secondary"  Text="Report" OnClick="btnReport_Click" /> 
                                            <asp:Button ID="btnDetailReport" runat="server"  CssClass="btn btn-primary"  Text="Detailed Report" OnClick="btnDetailReport_Click"  /> 
                                            <asp:Button ID="btnDetailExcelReport" runat="server"  CssClass="btn btn-warning"  Text="Detailed Excel " OnClick="btnDetailExcelReport_Click"  /> 
                                            
                                             
                                        </div>
                                        <div class="col-lg-12 mt-3">
                                            <div class="row">
                                                <div class="table-responsive" style="width:100%">                                                                                     
                       
                              <asp:GridView ID="gvRoomMaster" runat="server" AutoGenerateColumns="False" DataKeyNames="RoomId"
                          
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"  
                            CellPadding="3" AllowPaging="True" 
                            PageSize="10" 
                            onpageindexchanging="gvRoomMaster_PageIndexChanging" 
                            ShowHeaderWhenEmpty="True" OnRowCommand="gvRoomMaster_RowCommand">
                                   <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                               
                                 <asp:ButtonField CommandName="Details" Text="Details" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                <asp:BoundField DataField="RoomAddress" HeaderText="Room Location"/>
                                <asp:BoundField DataField="RType" HeaderText="Room Type" />
                                <asp:BoundField DataField="RoomName" HeaderText="Room Name" /> 
                                <asp:BoundField DataField="TotalBeds" HeaderText="Total Bed" /> 
                                <asp:BoundField DataField="Unoccupied" HeaderText="UnOccupied" /> 
                                <asp:BoundField DataField="Occupied" HeaderText="Occupied" />                                 
                                
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
           
                       
          <div class="modal fade" id="myModal" role="dialog" style="height:600px">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close"  data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                           Bed Allocation Details</h4>
                    </div>
                    <div class="modal-body">
                                                                 
                                            
                        <div runat="server" id="BedDetails" style="height:300px;overflow:scroll">
                        <div class="table-responsive" style="width:100%">  
                             
        <asp:GridView ID="GvBedDetails"  runat="server" AutoGenerateColumns="False" 
                            ShowHeaderWhenEmpty="True" EmptyDataText="No Records to Display" AllowPaging="True"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" >
           <%-- OnPageIndexChanging="GvBedDetails_PageIndexChanging" >--%>                      
              
                                <AlternatingRowStyle BackColor="White" />
              
                        <Columns>
                            
                            
                             <asp:BoundField DataField="BedName" HeaderText="BedName" /> 
                             <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" />                 
                             <asp:BoundField DataField="PatientName" HeaderText="Patient Name"  />                             
                            
                             
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
                    <div class="modal-footer">
                       
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
           <script type='text/javascript'>
         function ConfirmDelete() {
             var x = confirm("Are you sure you want to Approve?");
             if (x)
                 return true;
             else
                 return false;
         }

            </script></div>
        

                       
                        </section>
           
        </ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>

