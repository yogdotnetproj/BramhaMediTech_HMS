<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserManagementMaster.master" CodeFile="NurseAssignToWard.aspx.cs" Inherits="NurseAssignToWard" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <section class="content-header d-flex">
                    <h1>Nurse assign To Ward</h1>
                    <ol class="breadcrumb">
                     <li class="breadcrumb-item"><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                    <li class="breadcrumb-item"><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Nurse assign To Ward</li>
                    </ol>
                </section>
                <!-- Main content -->
                <section class="content">
                    <div class="box">
                        <div class="box-body">
                            <div class="row">
                               
                               <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Nurse</label>
                                       <asp:DropDownList ID="ddlmainmodule" runat="server" class="form-control" Width="300px"
        AutoPostBack="True" OnSelectedIndexChanged="ddlmainmodule_SelectedIndexChanged" >
                    </asp:DropDownList>
                                    </div>
                                </div>
                               
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        </div>
                                    </div>
                               
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>All</label>
                                       <asp:CheckBox ID="chkall" runat="server" AutoPostBack="false" 
                                            oncheckedchanged="chkall_CheckedChanged"></asp:CheckBox>
                                    </div>
                                </div>
                                <div  >
                                    <table>
                                    <tr>
                                    <td style="VERTICAL-ALIGN: top;  align="left">
                                     <div style="overflow: scroll; width: 548px; height: 520px" id="div">
                                  
<asp:TreeView ID="TR_RoleRight"  runat="server"   ExpandDepth="1"   
                onselectednodechanged="TR_RoleRight_SelectedNodeChanged" ShowCheckBoxes="Leaf" BackColor="AliceBlue" >
                <HoverNodeStyle Font-Underline="true" />
                <NodeStyle Font-Names ="Tahoma" Font-Size="8pt" ForeColor="Black"   HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" >
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
                                      
                            </div>
                        </div>
                        <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                   
                                
                                   
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-primary" onclick="btnsave_Click" />                       
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
                        <asp:BoundField DataField="Usertype" HeaderText="User Type" />
                         <asp:BoundField DataField="WardName" HeaderText="Ward Name" />
                         <asp:BoundField DataField="username" HeaderText="Nurse Name" />
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

           </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>
