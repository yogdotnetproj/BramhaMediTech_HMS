<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="MRCPatientLedger.aspx.cs" Inherits="MRCPatientLedger" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
            <asp:PostBackTrigger ControlID="btnExcel" />
         </Triggers>

        <ContentTemplate>
             
            <section class="content-header d-flex">
                    <h1>MRC Patient Ledger</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">MRC Patient Ledger</li>
                    </ol>
                </section>
      <section class="content">
                      <div class="box" runat="server" id="show">
                             <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                             <div class="box-body">
                                    <div class="row">                                
                                        <div class="col-sm-1">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">Year:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                
                                               <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="false" 
                                                                        CssClass="form-control form-select" >
                                                                        <asp:ListItem>2022</asp:ListItem>
                                                                        <asp:ListItem>2023</asp:ListItem>
                                                                        <asp:ListItem>2024</asp:ListItem>
                                                                        <asp:ListItem>2025</asp:ListItem>
                                                                       <asp:ListItem>2026</asp:ListItem>
                                                                       <asp:ListItem>2027</asp:ListItem>
                                                                       <asp:ListItem>2028</asp:ListItem>
                                                                       <asp:ListItem>2029</asp:ListItem>
                                                                    </asp:DropDownList>
                                            </div>
                                          
                                        </div>
                                       
                                        
                                               
                                       <div class="col-sm-4">                                    
                                              <asp:Button ID="btnSearch" runat="server" Visible="false" CssClass="btn btn-success"   OnClick="btnSearch_Click" Text="Search"/>
                                           <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-warning"   OnClick="btnPrint_Click" Text="Print" />
                                              <asp:Button ID="btnExcel" runat="server" CssClass="btn btn-success"   Text="Excel" OnClick="btnExcel_Click" />

                                        </div>
 
                                            
                                      
                                    </div>
                                </div>
                             
                                    
                                        
                                   
                      
                             <div class="box-body" runat="server" visible="false">
                                   <div class="table-responsive" style="width:100%">          
                     
                                    <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="PatientInfoId"
                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"                                    
                                    CellPadding="3" AllowPaging="True" BackColor="White"
                                     BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    OnPageIndexChanging="gvPatientInfo_PageIndexChanging" PageSize="10" ShowHeaderWhenEmpty="True"
                                    TabIndex="27">
                            
                                        <Columns>             
                                
                                
                                <asp:BoundField DataField="PatRegId" HeaderText="PRN No." 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" 
                                ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                </asp:BoundField>


                                <asp:BoundField DataField="PolicyNo" HeaderText="PolicyNo" Visible="False" />
                                <asp:BoundField DataField="PatientAddress" HeaderText="Address" 
                                    ItemStyle-HorizontalAlign="Left" >
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                           <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" 
                                     ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>   
                                 <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" 
                                     ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="CreatedBy" HeaderText="Enter By" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="ParentMergNo" HeaderText="Merge To" /> 
                                             <asp:BoundField DataField="MergeBy" HeaderText="Merge By" />          
                                             <asp:BoundField DataField="MergeOn" HeaderText="Merge On" />                                
                               
                               
                                           
                               
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
      </section>
             <script language="javascript" type="text/javascript">
                 function OpenReport() {
                     window.open("Reports.aspx");
                 }
               </script>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>


