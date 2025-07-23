<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="ReferToAdmissionPatientList.aspx.cs" Inherits="ReferToAdmissionPatientList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
             <asp:PostBackTrigger ControlID="btnPrint" />
         </Triggers>

        <ContentTemplate>
             
            <section class="content-header d-flex">
                    <h1>Refer To Admission Patient List Report</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">>Refer To Admission Patient List Report</li>
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
                                                         <label for="txtFromDate">From Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div>
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtToDate">To Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div> 
                                        
                                               
                                       <div class="col-sm-4">                                    
                                              <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success"   OnClick="btnSearch_Click" Text="Search"/>
                                           <asp:Button ID="btnPrint" runat="server" Visible="false" CssClass="btn btn-warning"   OnClick="btnPrint_Click" Text="Print" />
                                             
                                        </div>
 
                                            
                                      
                                    </div>
                                </div>
                             
                                    
                                        
                                   
                      
                             <div class="box-body">
                                   <div class="table-responsive" style="width:100%">          
                     
                                    <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="Patregid"
                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"                                    
                                    CellPadding="3" AllowPaging="True" BackColor="White"
                                     BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    OnPageIndexChanging="gvPatientInfo_PageIndexChanging" ShowHeaderWhenEmpty="True"
                                    TabIndex="27" OnRowCommand="gvPatientInfo_RowCommand" OnRowDataBound="gvPatientInfo_RowDataBound">
                            
                                        <AlternatingRowStyle BackColor="White" />
                            
                                        <Columns>             
                                
                                
                                <asp:BoundField DataField="PatRegId" HeaderText="PRN No." 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:BoundField> 
                                             <asp:BoundField DataField="OPDNO" HeaderText="OPD No." 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="FirstName" HeaderText="Patient Name" 
                                ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                </asp:BoundField>


                               
                               
                                           <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" 
                                     ItemStyle-HorizontalAlign="Left" DataFormatString="{0:dd/MM/yyyy}" >
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>   
                                 <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" 
                                     ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="CreatedBy" HeaderText="Refer By" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="CreatedOn" HeaderText="Refer On" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="DrId" HeaderText="DrId" />
                                              <asp:BoundField DataField="AttendingPhysican" HeaderText="Attending Physican" />
                                              <asp:BoundField DataField="WardName" HeaderText="WardName" />
                                             <asp:BoundField DataField="BedName" HeaderText="BedName" />
                                                   <asp:BoundField DataField="PatientAdmit" HeaderText="Patient Admit" 
                                     ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                </asp:BoundField>            
                                 <asp:ButtonField CommandName="Refer" Text="Admit" HeaderText="Admit" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                               
                                            <asp:TemplateField>
                                         <ItemTemplate>
                                             <asp:HiddenField ID="HdnPatientAdmit" runat="server" Value='<%#Eval("PatientAdmit") %>' />

                                             </ItemTemplate>
                                                </asp:TemplateField>
                               
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


