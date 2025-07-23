<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="Showpackage.aspx.cs" Inherits="Showpackage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>

                <!-- Content Header (Page header) -->
                <section class="content-header d-flex">
                    <h1>Show Package</h1>
                    <ol class="breadcrumb">
                   
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Show Package</li>
                    </ol>
                </section>
                <!-- Main content -->
                <section class="content">
                    
                          
                          <!--  <div class="row mb-3">
                                <div class="col-lg-12">
                                <asp:Label ID="Label2" runat="server" Text="."  ></asp:Label>
                                </br>
                                </div>
                                  </div>-->
                                  <div class="box" runat="server" id="List" >
                        <div class="box-header with-border">
                            <div class="row ">
                                <div class="col-lg-12">
                                   
                                    <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-primary pull-right" Text="Add New" 
                        onclick="btnaddnew_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="box-body">
                           
                
                
                      <div class="table-responsive" style="width:100%">
                <asp:GridView ID="GV_ShowPackage" class="table table-responsive table-sm table-bordered" runat="server" AutoGenerateColumns="False" OnRowEditing="GV_ShowPackage_RowEditing"
                    OnRowDataBound="GV_ShowPackage_RowDataBound" PageSize="20" OnPageIndexChanging="GV_ShowPackage_PageIndexChanging"
                    OnRowDeleting="GV_ShowPackage_RowDeleting" 
        HeaderStyle-ForeColor="Black"
  AlternatingRowStyle-BackColor="White"    Width="100%">
                     <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" EditImageUrl="~/Images0/edit.gif"
                            ButtonType="Image" />
                       
                        <asp:BoundField DataField="PackageCode" HeaderText="Package Code" />
                        <asp:BoundField DataField="PackageName" HeaderText="Package Name" />
                       
                        <asp:TemplateField HeaderText="Service Name">
                            <ItemTemplate>
                                <asp:Label ID="lbltestNames" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:BoundField DataField="PackageRateAmount" Visible="false" HeaderText="Package Rate" />
                         <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Images0/delete.gif" />
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
                 <!--   ======================== -->
                  

                </section>
                <!-- /.content -->


           
</asp:Content>

