<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="Dr_OT_Register.aspx.cs" Inherits="Dr_OT_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1> Dr OT Register </h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Dr OT Register</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row" runat="server" id="gvshow">
                            
                            
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" autocomplete="off"  runat="server" CssClass="form-control pull-right" TabIndex="1"></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                        </div>
                                    </div>
                                    
                                     <div class="col-sm-2">
                                        <div class="form-group">
                                           
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" class="form-control pull-right" TabIndex="2"></asp:TextBox>
                                                <span class="input-group-addon">
                                                   <i class="fa fa-calendar"></i>
                                                 </span>
                                            </div>
                                            
                                        </div>
                                    </div>
                               <div class="col-sm-4  text-left" runat="server" visible="false" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                            <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlRoomCategory" Visible="false" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                              TabIndex="18" >
                                                            </asp:DropDownList>                   
                                                        <asp:RadioButtonList ID="RblOTType"  runat="server" Visible="false" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1" Text="General"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="EYE"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                            <asp:Label runat="server" ForeColor="Red" Font-Bold="true" ID="pcount"></asp:Label>
                                            </div>
                                </div>
                            <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-primary btnSearch" />
                                        </div>
                                            </div>
                                    </div>
                             <div class="col-sm-1">
                                        <div class="form-group">
                                            
                                            <div>
                                            <asp:Button ID="btnAddnew"  runat="server" Text="Add" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-success btnSearch" OnClick="btnAddnew_Click" />
                                        </div>
                                            </div>
                                    </div>
                               
                             <div class="row mt-3" runat="server" visible="false">
                                   
                                        <div class="col-sm-3">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtsurgan" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Surgan Name"
                                                AutoPostBack="True" ontextchanged="txtsurgan_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtsurgan"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                         <div class="col-sm-3" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtanesticia" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Anestia Name"
                                                AutoPostBack="True" ontextchanged="txtanesticia_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchAnaesthetist"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtanesticia"
                                                ID="AutoCompleteExtender3"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                        <div class="col-sm-2">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtoperation" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Operation Name"
                                                AutoPostBack="True" ontextchanged="txtoperation_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender4"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                         <div class="col-sm-2" >
                                        <div class="form-group">
                                            <asp:TextBox ID="txtdieses" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Disease Name"
                                                AutoPostBack="True"  onkeyPress="return alpha_only(event);" OnTextChanged="txtdieses_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDisease"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtdieses"
                                                ID="AutoCompleteExtender5"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                            </div>
                                   </div>
                                  <div class="col-sm-2" >
                                        <div class="form-group">
                                             <asp:UpdatePanel ID="ASASA" runat="server">

                                                               <ContentTemplate>
                                                                     
                                                                           <asp:DropDownList ID="ddlSurgeryType" runat="server"   Class="form-control form-select" >                                                      
                                                       
                                                              <asp:ListItem Value="0">select</asp:ListItem>
                                                              <asp:ListItem  Value="A">A</asp:ListItem>
                                                              <asp:ListItem Value="A+">A+</asp:ListItem>
                                                              <asp:ListItem Value="B">B</asp:ListItem>
                                                              <asp:ListItem Value="B+">B+</asp:ListItem>
                                                              <asp:ListItem Value="C">C</asp:ListItem>
                                                              <asp:ListItem Value="C+">C+</asp:ListItem>
                                                       
                                                    </asp:DropDownList>                                                         
                                                       
                                                               </ContentTemplate>
                                                           </asp:UpdatePanel>
                                            </div>
                                      </div>
                                       
                                  </div>
                                    <div class="col-lg-12 mt-3" >
                                        
                               
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="DrOtId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True" OnRowDataBound="gvPatientInfo_RowDataBound" OnRowDeleting="gvPatientInfo_RowDeleting">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         <asp:ButtonField CommandName="Select" Text="Select" Visible="false" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                      
                                                        
                                                        <asp:BoundField DataField="SurganName" HeaderText="Surgan Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OperationName" HeaderText="Operation Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                       
                                                        <asp:BoundField DataField="ScheduleDate" HeaderText="OT Reg Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                       
                                                          <asp:ButtonField CommandName="SelectEMR" Visible="false" Text="EMR" HeaderText="EMR"  ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField> 
                                                        <asp:ButtonField CommandName="Report" Text="Report" Visible="false" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        <asp:ButtonField CommandName="Notes" Text="Notes" Visible="false" HeaderText="Notes"  ControlStyle-CssClass="btn btn-primary" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                         <asp:ButtonField CommandName="Summary" Text="Summary" Visible="false"  HeaderText="Summary"  ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-primary" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                         <asp:ButtonField CommandName="Investigation" Visible="false" HeaderText="Investigations" Text="Investigations"  ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                     <asp:TemplateField HeaderText="Delete" Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CommandName="Delete"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
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

                                        </div>
                                    </div>
                             <div class="row">
                                    <div class="col-lg-12 mt-3 text-center" >
                                         <asp:Button ID="btnReport"  runat="server" Text="Report" TabIndex="3" ValidationGroup="Date" class="btn btn-primary btnSearch" OnClick="btnReport_Click" />
                                       <asp:Label runat="server" ID="LblMsg"  ></asp:Label>    
                                    </div>
                                 </div>
                                 </div>
                              <div class="col-lg-12 mt-3 " runat="server" id="DrAdd" visible="false">
                        <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label37" runat="server" Font-Bold="true" Text="Surgeon Name" ></asp:label>
                                        </div>
                                    </div>
                             <div class="col-lg-4">
                                    <div class="form-group">
 <asp:TextBox ID="txtsurgenname_Add" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Surgan Name"
                                                AutoPostBack="True" ontextchanged="txtsurgenname_Add_TextChanged"  onkeyPress="return alpha_only(event);"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtsurgenname_Add"
                                                ID="AutoCompleteExtender6"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                        </div>
                                    </div>
                              <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label1" runat="server" Font-Bold="true" Text="Operation Name" ></asp:label>
                                        </div>
                                    </div>
                              <div class="col-lg-4">
                                    <div class="form-group">
 <asp:TextBox ID="txtoperationAdd" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Operation Name"
                                               onkeyPress="return alpha_only(event);"></asp:TextBox>
                            </div>
                             
                                  
                                </div>
                            </div>
 <div class="row" style="padding-bottom: 5px">
                            <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label2" runat="server" Font-Bold="true" Text="Surgery Date" ></asp:label>
                                        </div>
                                    </div>
      <div class="col-lg-4  text-center">
                                            <div class="form-group">
                                                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtRegistrationDate" runat="server"   class="form-control"  AutoPostBack="true"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                     
                        
                                                        </div>
                                                </div>
                                                     </div>
      <div class="col-lg-2">
                                    <div class="form-group">
                                         <asp:label id="Label3" runat="server" Font-Bold="true" Text="Remark" ></asp:label>
                                        </div>
                                    </div>
      <div class="col-lg-4">
                                    <div class="form-group">
                                        
 <asp:TextBox ID="txtremark" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Remark"
                                               ></asp:TextBox>
                                        </div>
          </div>
     </div>
                      <div class="row">
                                    <div class="col-lg-12 mt-3 text-center" >
                                         <asp:Button ID="btnsave"  runat="server" Text="save" TabIndex="3" ValidationGroup="Date" class="btn btn-success btnSearch" OnClick="btnsave_Click"  />
                                       <asp:Label runat="server" ID="Label4"  ></asp:Label>    
                                    </div>
                                 </div> 
                    </div>
             
                        </div>
                    </div>
            </section>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        function OpenReport() {
            window.open("Reports.aspx");
        }
               </script>
    
</asp:Content>

