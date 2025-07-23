<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OperationMainCategory.aspx.cs" Inherits="OperationMainCategory" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
       <script type = "text/javascript">
           function Validate() {

               if (document.getElementById("MainContent_txtPatientSubCat").value == "") {
                   alert("Please Enter Operation Main Category");
                   return false;
               }

               if (document.getElementById("MainContent_ddlDept").value == "0") {

                   alert("Please Select Department!");
                   return false;

               }
           }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Operation Main Category</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Operation Main Category</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>

                        <div class="box-body">
                            <div class="row">
                                <div class="col-lg-1" style="width:200px">
                                    <div class="form-group">
                                         <label for="ddlDept" style="text-align:left">Department Name:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">                                     
                                         <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" Class="form-control" TabIndex="2"></asp:DropDownList>
                                   </div>
                                </div>
                                <div class="col-lg-12" > 
                                            <div class="row">
                                                 <div class="col-lg-1" style="width:200px">
                                    <div class="form-group">
                                         <label for="txtOpMainCat" style="text-align:left">Operation Main Category:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtOpMainCat" runat="server" placeholder="Enter Operation Main Category(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
                                                
                                    

                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        
                                        <asp:Button ID="btnsave" runat="server" class="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnsave_Click"  />
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnReset_Click" />
                                        <%--<asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-primary"
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" />
                               --%>
                                       
                                    </div>
                                </div>
                                                </div>
               </div>
                                 <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvOpMainCat" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="592px" OnPageIndexChanging="gvOpMainCat_PageIndexChanging" OnRowEditing="gvOpMainCat_RowEditing"
                    DataKeyNames="OTDeptId" AllowPaging="True" PageSize="15" OnRowDeleting="gvOpMainCat_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                
                                </asp:CommandField>
                                <asp:BoundField DataField="OTDeptId" HeaderText="OPMainCatId" 
                                    Visible="False" />
                                <asp:BoundField DataField="OTDeptName" HeaderText="Operation Main Category" /> 
                                    
                                
                                
                               
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
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

                            </div>
                        </div>
                    </div>
                  
                </section>
        </ContentTemplate>
        </asp:UpdatePanel>


</asp:Content>

