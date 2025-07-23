<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="StateMaster.aspx.cs" Inherits="StateMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_ddlCountryName").value == "0") {
                 alert("Please Select Country Name");
                 return false;
             }

             if (document.getElementById("MainContent_txtStateName").value == "") {

                 alert("Please Enter State Name!");
                 return false;

             }
         }
        </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
        <ContentTemplate>

      <section class="content-header d-flex">
                    <h1>State Master</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">state Master</li>
                    </ol>
                </section>

   
                   <section class="content">
                            <div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMsg" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                                     <span class="red pull-right">Fields marked with * are compulsory</span> 
                                   
                                </div>
                                
                              
                           
                                <div class="box-body">
                                    <div class="row mb-3">
                                         <div class="col-sm-2">
                                                 <div class="form-group">
                                                     <label for="ddlCountryName">Country Name(*):</label>                                                                                
                                                </div>
                                        </div>
                                         <div class="col-sm-3">
                                            <div class="form-group">                                                                                      
                                                <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="True"  CssClass="form-control form-select" 
                                                onselectedindexchanged="ddlCountryName_SelectedIndexChanged" TabIndex="2"> 
                                                </asp:DropDownList>
                                          
                   
                                                 </div>
                                        </div>
                                    </div>
                                        
                                    <div class="row mb-3">
                                        
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtStateName">State Name:</label>                                                                                
                                                    </div>
                                                 </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group">                                                           
                                                        <asp:TextBox ID="txtStateName" runat="server" AutoPostBack="true" 
                                                        ontextchanged="txtStateName_TextChanged" TabIndex="2" placeholder="Enter State Name(*)" Class="form-control"></asp:TextBox>
                                                        
                                                   </div>
                                                 </div>
                                                <div class="col-sm-4">
                                    
                                             <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  
                                              Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                             <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"   CausesValidation="False" 
                                             onclick="btnReset_Click" Text="Reset"/>

                                            <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" Visible="False" />
                            

                                        </div>
                                           
                                    </div>

                                    <div class="row mb-3">
                                         
                                                <div class="table-responsive" style="width:100%">                                                                                                      
                         
                                         <asp:GridView ID="gvState" runat="server" AutoGenerateColumns="False" 
                                         class="table table-responsive table-sm table-bordered" Width="100%" 
                                         AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                                        onrowdeleting="gvState_RowDeleting" onrowediting="gvState_RowEditing" 
                                        DataKeyNames="StateId" CellPadding="3" AllowPaging="True" 
                                        PageSize="5" onpageindexchanging="gvState_PageIndexChanging" TabIndex="5" 
                                        EmptyDataText="No Records to Display" ShowHeaderWhenEmpty="True">
                                                    <Columns>
                                                     <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif"  
                                                                    ShowCancelButton="False" ShowEditButton="True"> <ItemStyle Width="70px" HorizontalAlign="Center" /> </asp:CommandField>
                       
                                                        <asp:BoundField DataField="StateId" HeaderText="StateId" Visible="False" />
                                                        <asp:BoundField DataField="StateName" HeaderText="State Name" >
                                                        <ItemStyle Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CountryName" HeaderText="Country Name" >
                                                        <ItemStyle Width="200px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IsActive" HeaderText="IsActive" Visible="False" />
                                                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" Visible="False" />
                                                        <asp:BoundField DataField="CreatedDateTime" HeaderText="CreatedDateTime" 
                                                            Visible="False" />
                                                        <asp:BoundField DataField="UpdatedBy" HeaderText="UpdatedBy" Visible="False" />
                                                        <asp:BoundField DataField="UpdatedDateTime" HeaderText="UpdatedDateTime" 
                                                            Visible="False" />
                       
                                                             <asp:TemplateField >
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                                                            OnClientClick="return ValidateDelete()" CausesValidation="false"  ToolTip="Click here to Delete this record"
                                                                            CommandName="Delete" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
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

                        </section>
                  </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

