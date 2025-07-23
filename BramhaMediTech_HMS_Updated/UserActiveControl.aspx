<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" Culture="auto" UICulture="auto" Theme="SampleSiteTheme" CodeFile="UserActiveControl.aspx.cs" Inherits="UserActiveControl" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="Maincontent" runat="Server">
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js" type="text/javascript"></script>--%>
    <asp:ScriptManager ID="ScriptManager" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
        </Triggers>--%>
        <ContentTemplate>
    
              <section class="content-header d-flex">
                    <h1>User Active</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">User Active</li>
                    </ol>
                </section>
        <section class="content">
                    <div class="box" runat="server" id="List" >
                          <div class="box-body">
                        <div class="row">
                             
                             <div class="col-lg-4" >
                                    <div class="form-group"> 
                                        <asp:RadioButtonList ID="RblType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                            <asp:ListItem Value="0" >De Active</asp:ListItem>
                                        </asp:RadioButtonList>
                                        </div>
                                 </div>
                            <div class="col-lg-2" >
                                    <div class="form-group"> 

                                        <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-primary btnSearch"  Text="Show" OnClick="btnsearch_Click" />

                                        </div>
                                 </div>
                                  </div>
                         <div class="row">
                             <div class="col-lg-6" >
                                    <div class="form-group">
                                        <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                                        </div>
                                 </div>
                             </div>
                        <div class="box-body">
                           <div class="table-responsive" style="width:100%">  
                             

                            <asp:GridView ID="gvPurchaseList"  DataKeyNames="CUId" runat="server" AutoGenerateColumns="False" 
                            ShowHeaderWhenEmpty="True" EmptyDataText="No Records to Display" AllowPaging="True"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                            class="table table-responsive table-sm table-bordered" Width="100%"
                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" OnPageIndexChanging="gvPurchaseList_PageIndexChanging1" OnRowDataBound="gvPurchaseList_RowDataBound" >                      
              
                                <AlternatingRowStyle BackColor="White" />
              
                        <Columns>
                             <asp:BoundField DataField="ISActive" HeaderText="Status" />
                              <asp:BoundField DataField="username" HeaderText="User Name" />
                             <asp:BoundField DataField="usertype" HeaderText="User Type" />
                             <asp:BoundField DataField="Name" HeaderText="Name" />
                             <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                            
                             <asp:BoundField DataField="ModuleName" HeaderText="Module Name" />
                              
                            <asp:TemplateField HeaderText="Active/De-Active" >
                                 <ItemTemplate>
                                     <asp:CheckBox ID="ChkFinalApproval" runat="server" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action" >
                                 <ItemTemplate>
                                        <asp:HiddenField ID="HdnReceiveToPharma" runat="server" Value='<%#Eval("ISActive") %>' /> 
                                     <asp:Button ID="btnDetails" runat="server" Text="Active" class="btn btn-primary" OnClick="btnDetails_Click" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                          
                            
                             </Columns>
                               <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                    <RowStyle ForeColor="#000066" />
                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>




                        

                       
                    </div>


         

                        <div class="box-header with-border">
                            <div class="row ">
                                <div class="col-lg-12">
                                   
                                   
                                    
                                </div>
                            </div>
                        </div>
                        
                    </div>
                              </div>
                 </div>
                   
<%--<div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                           Invoice Details</h4>
                    </div>
                    <div class="modal-body">
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Text="Pay" OnClick="btnSave_Click" CssClass="btn btn-info" />
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
        

                        </div>--%>

                </section>
         
              
                  </ContentTemplate>
        </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
     </asp:Content>

