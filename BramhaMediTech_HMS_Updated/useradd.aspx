<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Hospital.master" CodeFile="useradd.aspx.cs" Inherits="useradd" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Create User</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="Login.aspx"><i class="fa fa-fw fa-lock"></i> Login</a></li>
                        <li class="breadcrumb-item"><a href="Login.aspx"><i class="fa fa-fw fa-power-off"></i> Log out</a></li>
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Create User</li>
                    </ol>
                </section>

            <section class="content">
                    <div class="box">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-lg-12" runat="server" visible="false" >
                                    <div class="form-group">
                                            <label>User Category</label>
                                            <div class="radio1">
                                              
                                                    <div class="row">
                                                        <div class="col-lg-4 col-xs-4">
                                                            <label>
                                                                <asp:RadioButtonList ID="RblDType"  Width="170Px" runat="server" 
                                                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                                                onselectedindexchanged="RblDType_SelectedIndexChanged">
                                                                <asp:ListItem Selected="True" Value="0">Other</asp:ListItem>
                                                                <asp:ListItem Value="1">Doctor</asp:ListItem>
                                                                 </asp:RadioButtonList>
                                                            </label>
                                                        </div>    
                                                        <div class="col-lg-4 col-xs-4">
                                                            <label>
                                                               
                                                            </label>
                                                        </div>
                                                    </div>
                                                
                                            </div>
                                        </div>
                                </div>
                          <div class="col-lg-12">
                               <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Employee Name <span class="red">*</span></label>
                                        
                                        <asp:TextBox id="ddlempname" runat="server"  class="form-control" AutoPostBack="True" 
                            ontextchanged="ddlempname_TextChanged" ></asp:TextBox>
                            <%--<asp:TextBox id="ddlempname1" runat="server"  class="form-control"  ></asp:TextBox>--%>
                                          <cc1:AutoCompleteExtender
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="FillInfo"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="ddlempname"
                                                ID="AutoCompleteExtender4"
                                                runat="server">
                                                    </cc1:AutoCompleteExtender>

                        <%--<div style="display: none; overflow: scroll; width: 112px; height: 100px; text-align: right"
                                   id="Div09">
                               </div>
                               <cc1:AutoCompleteExtender ID="" runat="server"
                                   CompletionListElementID="Div09" ServiceMethod="FillInfo" TargetControlID="ddlempname"
                                   MinimumPrefixLength="1">
                               </cc1:AutoCompleteExtender>--%>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>User Name <span class="red">*</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton id="lnkavail" onclick="lnkavail_Click" runat="server" Width="122px" SkinID="not" Font-Size="9pt" Font-Names="Verdana">Check Availability</asp:LinkButton></label>
                                      
                                        <asp:TextBox id="txtuname" runat="server" class="form-control" ValidationGroup="vd"></asp:TextBox>

 <asp:Label id="lbluser" runat="server" Width="357px"  Text="User Already Exists.. Enter Another User Name.." Font-Size="8pt" Font-Names="Verdana" Visible="False" ForeColor="Red"></asp:Label> 

                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label>Password <span class="red">*</span></label>
                                      
                                        <asp:TextBox ID="txtpwd" runat="server" ValidationGroup="vd"   class="form-control"></asp:TextBox>
                                    </div>
                                </div>   
                                   </div>
                              </div>
                            
                                
                           <div class="col-lg-12">
                               <div class="row">  
                                    <div class="col-sm-3">
                                    <div class="form-group">
                                         <label>Modules <span class="red">*</span></label>
                                       <asp:DropDownList ID="ddlModuleName" runat="server" CssClass="form-control form-select">
                                           <asp:ListItem>HMS</asp:ListItem>
                                           <asp:ListItem>Radiology</asp:ListItem>
                                            <asp:ListItem>Pathology</asp:ListItem>
                                           <asp:ListItem>PHARMACY</asp:ListItem>
                                           <asp:ListItem>Inventory</asp:ListItem>
                    </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Department <span class="red">*</span></label>
                                        
                                        <asp:DropDownList id="ddldept"  runat="server" class="form-control" OnSelectedIndexChanged="ddldept_SelectedIndexChanged" AutoPostBack="True" DataTextField="DeptName"></asp:DropDownList>
                                    </div>
                                </div>
                                    <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Employee Category <span class="red">*</span></label>
                                        
                                        <asp:DropDownList id="ddlEmpCategory"  runat="server" class="form-control" OnSelectedIndexChanged="ddldept_SelectedIndexChanged" AutoPostBack="True">
                                              <asp:ListItem Value="0">Select Type</asp:ListItem>
                                                            <asp:ListItem Value="Consultant">Consultant Doctor</asp:ListItem>
                                                            <asp:ListItem Value="Reference">Reference Doctor</asp:ListItem>
                                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4" runat="server" visible="false">
                                    <div class="form-group">
                                        <label>Lab Unit <span class="red">*</span></label>
                                       
                                         <asp:DropDownList ID="ddlLab" runat="server" AppendDataBoundItems="true"
                        DataTextField="DoctorName" DataValueField="DocCode" ForeColor="Navy" 
                        class="form-control">
                        
                    </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>User Type <span class="red">*</span></label>
                                       
                                        <asp:DropDownList ID="ddltype" runat="server" class="form-control"  
                        onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                                    </div>
                                </div>

                       </div>
                               </div>

                                <div class="col-lg-12">
                               <div class="row">                               
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Email <span class="red">*</span></label>
                                       
                                        <asp:TextBox id="txtemail" runat="server" class="form-control" ValidationGroup="vd"></asp:TextBox>



                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Phone <span class="red">*</span></label>
                                       
                                        <asp:TextBox id="txtphone" runat="server" MaxLength="13" class="form-control"></asp:TextBox> 

                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Mobile <span class="red">*</span></label>
                                      
                                        <asp:TextBox id="txtmobile"  MaxLength="10" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                </div>

                                    <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Active <span class="red">*</span></label>
                                      
                                       <%-- <asp:CheckBox id="ChkIsActive" Text="Status"   runat="server"></asp:CheckBox>--%>
                                        <br />
                                        <asp:CheckBox id="ChkIsActive" Text="Is Active"  ForeColor="Red"  runat="server" class="form-check-input"></asp:CheckBox>
                                    </div>
                                </div>

                               </div>
                                </div>
                                <div class="col-lg-4" id="Collid" runat="server" visible="false"  >
                                    <div class="form-group">
                                        <label>Center Code <span class="red">*</span></label>
                                        <asp:DropDownList id="ddlCentercode" runat="server" class="form-control"
></asp:DropDownList>
                                                                           </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label> </label>
                                       <asp:TextBox id="TextBox1" runat="server" Visible="false" class="form-control"></asp:TextBox> 
                                        .
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label> </label>
                                        <asp:TextBox id="TextBox2" runat="server" Visible="false" class="form-control"></asp:TextBox> 
                                        .
                                    </div>
                                </div>

                                 <div class="col-lg-12" id="DocDeg" runat="server" visible="false"  >
                                    <div class="form-group">
                                    <table width="50%">
                                    <tr>
                                    <td>
                                    Doctor Degree
                                    </td>
                                    <td>
                                    Upoad Signature
                                    </td>
                                    </tr>
                                     <tr>
                                    <td>
                                    <asp:TextBox id="txtDoctorDegree" runat="server"  class="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                     <asp:FileUpload ID="FUFileUpload" runat="server"></asp:FileUpload>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td id="Td1" colspan="2" runat="server">
                                    <asp:Image ID="Image1" runat="server"></asp:Image>
                                    
                                    </td>
                                    </tr>
                                    </table>
                                    </div>
                                    </div>


                               

                            </div>
                        </div>
                        <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                   
                                     <asp:Button ID="Button1" runat="server" OnClick="CmdSave_Click" Text="Save" OnClientClick="return Validate();"  ValidationGroup="vd" class="btn btn-primary" />
                              
                                     <asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click"
                            Text="Cancel"   UseSubmitBehavior="False" class="btn btn-primary" />
                            <asp:Label ID="LBLMsg" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                             <asp:Button ID="btnreport" runat="server" CausesValidation="False" 
                            Text="Report"  class="btn btn-primary" onclick="btnreport_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                  
                </section>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Content>