<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Hospital.master" CodeFile="Addroleright.aspx.cs" Inherits="Addroleright" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
                <section class="content-header d-flex">
                    <h1>Role Right</h1>
                    
                </section>
                <!-- Main content -->
                <section class="content">
                    <div class="box pt-3">
                        <div class="box-body">
                            <div class="row mb-3">
                               
                               
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>Module Name</label>
                                    </div>
                                </div>
                                 <div class="col-sm-3">
                                    <div class="form-group">
                                       <asp:DropDownList ID="ddlModuleName" runat="server" AutoPostBack="true" CssClass="form-control form-select" OnSelectedIndexChanged="ddlModuleName_SelectedIndexChanged">
                                           <asp:ListItem>-select-</asp:ListItem>
                                           <asp:ListItem>HMS</asp:ListItem>
                                           <asp:ListItem>Pathology</asp:ListItem>
                                           <asp:ListItem>Radiology</asp:ListItem>
                                           <asp:ListItem>PHARMACY</asp:ListItem>
                                           <asp:ListItem>Inventory</asp:ListItem>
                    </asp:DropDownList>
                                    </div>
                                </div>
                               </div>
                            <div class="row mb-3">
                               
                               
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <label>User Type</label>
                                    </div>
                                </div>
                                 <div class="col-sm-3">
                                    <div class="form-group">
                                       <asp:DropDownList ID="ddlUsertype" runat="server" CssClass="form-control form-select"
        AutoPostBack="True" onselectedindexchanged="ddlUsertype_SelectedIndexChanged">
                    </asp:DropDownList>
                                    </div>
                                </div>
                               </div>

                            <div class="row mb-3">
                                <div class="col-sm-12">
                                    <div class="form-group form-check p-0">
                                        <label>All</label>
                                       <asp:CheckBox ID="chkall" runat="server" AutoPostBack="false" 
                                            oncheckedchanged="chkall_CheckedChanged"></asp:CheckBox>
                                    </div>
                                </div>
                                <div  >
                                    <table>
                                    <tr>
                                    <td style="VERTICAL-ALIGN: top;  align="left">
                                     <div class="form-check" style="overflow: scroll; width: 548px; height: 520px" id="div">
                                   
<asp:TreeView ID="TR_RoleRight"  runat="server"   ExpandDepth="1"   
                onselectednodechanged="TR_RoleRight_SelectedNodeChanged" ShowCheckBoxes="Leaf" BackColor="White" >
                <HoverNodeStyle Font-Underline="true" />
                <NodeStyle Font-Names ="Tahoma" ForeColor="Black"   HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" >
                </NodeStyle>
                <ParentNodeStyle Font-Bold="true" />
                <SelectedNodeStyle BackColor="#A1DCF2" ForeColor="#3AC0F2"  Font-Underline="false" HorizontalPadding="0px" 
                VerticalPadding="0px" />
                
                </asp:TreeView>
                 </div>
                                    </td>
                                    <TD style="VERTICAL-ALIGN: top; WIDTH: 274px" align="Right">
                                    
                            </TD>
                                    <td></td>
                                    </tr>
                                    
                                    </table>
                                    
                                     
                                      </div>

                                <div class="row mt-3">
                                <div class="col-sm-12 text-center">
                                   
                                
                                   
                                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary" onclick="btnsave_Click" />                       
                                             </div> 
                            </div>
                                      
                            </div>
                        </div>
                       
                    </div>
                    <div class="box">
                          <div class="table-responsive" style="width:100%">
                 <asp:GridView ID="GV_userrollright" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" DataKeyNames="Rightid"
                    Width="700px" OnPageIndexChanging="GV_userrollright_PageIndexChanging" 
                    AllowPaging="True" PageSize="30"    HeaderStyle-ForeColor="Black"
  AlternatingRowStyle-BackColor="White" onrowdeleting="GV_userrollright_RowDeleting"   >
                    <Columns>
                        <asp:BoundField DataField="ROLENAME" HeaderText="User Type" />
                         <asp:BoundField DataField="MenuName" HeaderText="Menu Name" />
                         <asp:BoundField DataField="FormName" HeaderText="Form Name" />
                         <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btndelete" CommandName="Delete" runat="server" ForeColor="Blue" Text="Delete" />                            
                            </ItemTemplate>                            
                            </asp:TemplateField>
                    </Columns>
                   

                </asp:GridView>
    
                </div>
                    </div>
                </section>
                <!-- /.content -->

           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </asp:Content>
