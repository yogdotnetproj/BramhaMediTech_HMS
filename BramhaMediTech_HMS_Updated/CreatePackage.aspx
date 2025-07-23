<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="CreatePackage.aspx.cs" Inherits="CreatePackage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <script type="text/javascript" src="Scripts/jquery-3.1.1.js"></script>
<script type="text/javascript" src="select2-master/select2.js"></script>
    <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
                <!-- Content Header (Page header) -->
                <section class="content-header d-flex">
                    <h1>Package</h1>
                    <ol class="breadcrumb">
                     
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Package</li>
                    </ol>
                </section>
                <!-- Main content -->
                <section class="content">
                    <div class="box">
                        <div class="box-body">
                            <div class="row mb-3">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                      
                                        <asp:DropDownList ID="ddlratelist" CssClass="form-control form-select" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                               
                                 <div class="col-sm-2">
                                    <div class="form-group">
                                      
                                        <asp:DropDownList ID="ddlType" CssClass="form-control form-select" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        
                                        
                                       <asp:TextBox id="txtPackagename" placeholder="Enter Package Name" tabIndex="1" runat="server" class="form-control"></asp:TextBox>
 <asp:RequiredFieldValidator style="POSITION: relative" id="RequiredFieldValidator2" runat="server" ForeColor="Red" Font-Bold="True" ValidationGroup="form"
 ControlToValidate="txtPackagename" Display="Dynamic" ErrorMessage="This is required field."> </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                       
                                      
                                       <asp:TextBox ID="txtPackagecode" placeholder="Enter Package Code" tabIndex="2" runat="server" class="form-control"  MaxLength="4" ontextchanged="txtCode_TextChanged" AutoPostBack="true" > </asp:TextBox>
 <cc1:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtPackagecode"
                    FilterMode="ValidChars" ValidChars="A,B,C,D,E,F,E,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9">
                </cc1:FilteredTextBoxExtender>
  <asp:RequiredFieldValidator  id="RequiredFieldValidator1" runat="server" ForeColor="Red"   Font-Bold="True" ValidationGroup="form" ControlToValidate="txtPackagecode" Display="Dynamic" ErrorMessage="This is required field."></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>

                             <div class="row">
                                <div class="col-sm-8">
                                    <div class="form-group">
                                       
                                      <asp:UpdatePanel id="UpdatePanel5" runat="server" >
 <ContentTemplate>
                                      <asp:TextBox ID="txttests" placeholder="Select Service"  runat="server" class="form-control" tabIndex="3"
                                        AutoPostBack="True" OnTextChanged="txttests_TextChanged"></asp:TextBox><br />
                                    <div style="display: none; overflow: scroll; width: 245px; height: 120px" id="div89">
                                    </div>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                        CompletionListElementID="div89" ServiceMethod="FillTests" TargetControlID="txttests"
                                          CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                        MinimumPrefixLength="1">
                                    </cc1:AutoCompleteExtender>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    </div>
                                </div>
                                
                                    <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtQty" placeholder="Enter Qty" tabIndex="2" runat="server" CssClass="form-control"  MaxLength="4"  > </asp:TextBox>
                                        </div>
                                        </div>
                                    
                                    <table runat="server"  visible="false" >
                                    <tr>
                                    <td style="VERTICAL-ALIGN: top; WIDTH: 8274px">
                                    </td>
                                    <TD style="VERTICAL-ALIGN: top; WIDTH: 274px" align="left" runat="server" visible="false">
                                     <asp:UpdatePanel id="UpdatePanel3" runat="server" >
                                        <ContentTemplate>
                                     <DIV style="BORDER-RIGHT: 2px; BORDER-TOP: 2px; OVERFLOW: scroll;  BORDER-LEFT: 2px; WIDTH: 245px; BORDER-BOTTOM: 2px; HEIGHT: 325px">
                                            <asp:CheckBoxList id="chkselectedtest" runat="server"  tabIndex="4"  Width="444px" >
                                                   </asp:CheckBoxList>
                                             </DIV>
                                     </ContentTemplate>
                            </asp:UpdatePanel>
                                        </TD>
                                    <td></td>
                                    </tr>
                                    
                                    </table>
                                    
                                     
                                     
                                       <div >
                                       <table>
                                    <tr>
                                    <td style="VERTICAL-ALIGN: top; WIDTH: 8274px">
                                    </td>
                                    <TD style="VERTICAL-ALIGN: top; WIDTH: 274px" align="left">
                                       <asp:TextBox ID="txtrateamt"  runat="server" Visible="false" tabIndex="5"></asp:TextBox>
                                       </TD>
                                       </tr>
                                       </table>
                                       </div>
                            </div>
                            <div class="col-lg-12">
                                    <div class="form-group">
                                        
                                
                                     <asp:Button id="btnsave" onclick="Button2_Click"  runat="server"  class="btn btn-primary"  Text="Save" ValidationGroup="form"></asp:Button>
                                      <asp:Button id="btnBack"  onclick="btnBack_Click" class="btn btn-primary" runat="server" Text="Back" ></asp:Button>
                                        </div>
                                        </div>
                        </div>
                        <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                   
                                      <asp:Label id="Label1" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
                                </div> 
                            </div>
                        </div>

                         <div class="box-body">
                           
                
                
                      <div class="table-responsive" style="width:100%">
                <asp:GridView ID="GV_ShowPackage" class="table table-responsive table-sm table-bordered" runat="server" AutoGenerateColumns="False" OnRowEditing="GV_ShowPackage_RowEditing"
                    OnRowDataBound="GV_ShowPackage_RowDataBound" PageSize="500" OnPageIndexChanging="GV_ShowPackage_PageIndexChanging"
                    OnRowDeleting="GV_ShowPackage_RowDeleting" 
        HeaderStyle-ForeColor="Black"
  AlternatingRowStyle-BackColor="White"    Width="100%">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" Visible="false" HeaderText="Edit" EditImageUrl="~/Images0/edit.gif"
                            ButtonType="Image" />
                       
                        <asp:BoundField DataField="PackageCode" HeaderText="Package Code" />
                        <asp:BoundField DataField="PackageName" HeaderText="Package Name" />
                        <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
                        
                           <asp:BoundField DataField="PackageRateAmount" HeaderText="Service Rate" />
                           <asp:BoundField DataField="Qty" HeaderText="Qty" />
                        <asp:BoundField DataField="ServiceId"  HeaderText="ServiceId" />
                        <asp:BoundField DataField="PackageRateAmount" Visible="false" HeaderText="Package Rate" />
                         <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Images0/delete.gif" />
                    </Columns>
                  

                </asp:GridView>
                </div>
                    
                        </div>
                    </div>
                   
                </section>
                <!-- /.content -->
           
</asp:Content>

