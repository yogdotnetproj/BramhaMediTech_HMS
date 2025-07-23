<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="Vaccnation_Master.aspx.cs" Inherits="Vaccnation_Master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtPatientCat").value == "") {
                 alert("Please Enter Patient Category");
                 return false;
             }
         }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Vaccnation Master</h1>
                    <ol class="breadcrumb">
                         <li  class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Vaccnation Master</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>

                        <div class="box-body">
                            <div class="row">
                               
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">                                     
                                
                                       
                <asp:TextBox ID="txtPatientCat" runat="server" placeholder="Enter Vaccnation Name(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
                               
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">                                     
                                
                                       
                <asp:TextBox ID="txtFromRange" runat="server" placeholder="Enter From Range(*)" class="form-control" TabIndex="2"></asp:TextBox>
                                   </div>
                                </div>
                              
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">                                     
                                
                                       
                <asp:TextBox ID="txtToRange" runat="server" placeholder="Enter To Range(*)" class="form-control" TabIndex="3"></asp:TextBox>
                                   </div>
                                </div <div class="col-lg-1 text-left" style="width:100px">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        class="form-control" 
                                                                        TabIndex="4" Width="90px" >
                                                                         <asp:ListItem>Days</asp:ListItem>                                                                      
                                                                        <asp:ListItem>Months</asp:ListItem>
                                                                          <asp:ListItem>Years</asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                           </div>
                                                           
                                                         
                                                        </div>



                                <div class="col-lg-4 text-center">
                                    <div class="form-group">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                        
                                        <asp:Button ID="btnsave" runat="server" class="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnsave_Click"  />
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnReset_Click" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-primary"
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" Visible="False" />
                               
                                       
                                    </div>
                                </div>

                                 <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvPatientCat" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="1000px" OnPageIndexChanging="gvPatientCat_PageIndexChanging" OnRowEditing="gvPatientCat_RowEditing"
                    DataKeyNames="VaccianId" AllowPaging="True" PageSize="15" OnRowDeleting="gvPatientCat_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="VaccnationName" HeaderText="Vaccnation Name" 
                                   />
                                <asp:BoundField DataField="FromAge" HeaderText="From Age" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                            <asp:BoundField DataField="ToAge" HeaderText="To Age" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                            <asp:BoundField DataField="AgeType" HeaderText="Age Type" 
                                    ItemStyle-HorizontalAlign="Left">
                                
                                </asp:BoundField>
                               
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

