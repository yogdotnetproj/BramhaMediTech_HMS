<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OperationNameMst.aspx.cs" Inherits="OperationNameMst" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtOpCat").value == "") {
                 alert("Please Enter Operation Category");
                 return false;
             }
         }
        </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
                    <asp:PostBackTrigger ControlID="btnPrint" />
                </Triggers>--%>
              <ContentTemplate>
    <section class="content-header d-flex">
                    <h1>Operation Name</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Operation Name</li>
                    </ol>
                </section>

    
      <section class="content">
                            <div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                              
                                            <asp:Button ID="btnaddnew" runat="server" class="btn btn-primary pull-right" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
                                </div>
                                <div class="box-body">
                                    <div class="row mb-3">
                                         <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtoperation">Operation Name:</label>                                                                                
                                                    </div>
                                         </div>
                                         <div class="col-sm-3 text-left" >
                                                    <div class="form-group">  
                                                                                  
                                                         <asp:TextBox ID="txtoperation" runat="server"  CssClass="form-control" placeholder="Select Operation From List" AutoPostBack="true" OnTextChanged="txtoperation_TextChanged"></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                    
                                                    
                                                    </div>
                                                </div>
                                         <div class="col-sm-2">                                    
                                                  <asp:Button ID="btnSearch" runat="server"  class="btn btn-primary"  
                                                  Text="Search" OnClick="btnSearch_Click"/>                                    
                                          </div>
                                        </div>
                                        
                                    <div class="col-lg-12">
                                            <div class="row">
                                   <div class="table-responsive" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvOpName" runat="server" AutoGenerateColumns="False" DataKeyNames="OperationId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10"
                            OnRowDeleting="gvOpName_RowDeleting" OnRowEditing="gvOpName_RowEditing"
                             OnPageIndexChanging="gvOpName_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                                   <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                                
                               <%-- <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>--%>
                                <asp:BoundField DataField="OperationId" HeaderText="OprnId" Visible="False" />
                                <asp:BoundField DataField="OperationName" HeaderText="Operation Name"/> 
                                <%--<asp:BoundField DataField="OprnCd" HeaderText="Operation Code"/>       --%>                                          
                                   
                                
                                 <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Edit" runat="server" ImageUrl="~/Images0/edit.gif" 
                                            ToolTip="Click here to edit this record" CommandName="Edit"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CommandName="Delete"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
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
                                       
                               </div>
                                </div>
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div runat="server" visible="false">
                                        <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="ddlOpMainCat">Operation Main Category:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3 text-left">
                                    <div class="form-group"> 
                                          <asp:DropDownList ID="ddlOpMainCat" runat="server" AutoPostBack="True"
                                                 CssClass="form-control form-select" TabIndex="2"></asp:DropDownList>
                     
                                   </div>
                                </div>
                                            </div>
                                        </div>

                                       
                                            <div class="row mb-3">

                                                                          
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtOprn">Operation Name:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtOprn" runat="server" placeholder="Enter Operation Name(*)" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        
                                                 </div>
                                        
                                        
                                            <div class="row">
<div id="Div1" runat="server" visible="false">
                                         <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtOprnCode">Operation Code:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtOprnCode" runat="server" placeholder="Enter Operation Code(*)" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
    </div>
                                                 
                                        
                                                
                                                <div class="col-sm-4">                                    
                                                  <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  
                                                  Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"   CausesValidation="False" 
                                                    onclick="btnReset_Click" Text="Reset"/>

                                               </div>
                                                </div>
                                            

                                            
                                        
                                    
                                </div>
                                
                            </div>

                        </section>
                  </ContentTemplate>
        </asp:UpdatePanel>


</asp:Content>

