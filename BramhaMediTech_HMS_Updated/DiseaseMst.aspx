<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DiseaseMst.aspx.cs" Inherits="DiseaseMst" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtDisease").value == "") {
                 alert("Please Enter Disease Name");
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
                    <h1>Disease  Master</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Disease Master</li>
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
                                                         <label for="txtdiseaseSearch">Disease Name:</label>                                                                                
                                                    </div>
                                         </div>
                                    <div class="col-sm-3 text-left" >
                                                    <div class="form-group">  
                                                                                        
                                                         <asp:TextBox ID="txtdiseaseSearch" runat="server"  CssClass="form-control" placeholder="Enter DISEASE" AutoPostBack="True" OnTextChanged="txtdiseaseSearch_TextChanged"></asp:TextBox>        
                                                       
                                      <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchDisease"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                            CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtdiseaseSearch"
                                                ID="AutoCompleteExtender8"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    
                                                    </div>
                                                </div>
                                    <div class="col-sm-2 text-left">                                    
                                                  <asp:Button ID="btnSearch" runat="server"  CssClass="btn btn-primary"  
                                                  Text="Search" OnClick="btnSearch_Click"/>                                    
                                          </div>
                                </div>

                                     <div class="col-lg-12">
                                            <div class="row">
                                   <div class="table-responsive" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvDisease" runat="server" AutoGenerateColumns="False" DataKeyNames="DiseaseId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10"
                            OnRowDeleting="gvDisease_RowDeleting" OnRowEditing="gvDisease_RowEditing"
                             OnPageIndexChanging="gvDisease_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                                   <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                                
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="DiseaseId" HeaderText="DiseaseId" Visible="False" />
                                <asp:BoundField DataField="DiseaseName" HeaderText="Disease Name"/>   
                                
                                   
                                
                                
                                <asp:TemplateField>
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
                                                                                
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtDisease">Disease Name:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtDisease" runat="server" placeholder="Enter Disease Name(*)" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        
                                                
                                                <div class="col-sm-4 text-left">                                    
                                                  <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  
                                                  Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" class="btn btn-primary"   CausesValidation="False" 
                                                    onclick="btnReset_Click" Text="Reset" width="80px" />

                                               </div>
                                                
                                 
                                            
                                        
                                    </div>
                                </div>
                                
                            </div>

                        </section>
                  </ContentTemplate>
        </asp:UpdatePanel>



</asp:Content>

