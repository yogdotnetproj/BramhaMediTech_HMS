<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="CityMaster.aspx.cs" Inherits="CityMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_ddlStateName").value == "0") {
                alert("Please Select State Name");
                return false;
            }

            if (document.getElementById("MainContent_txtCityName").value == "") {

                alert("Please Enter City Name!");
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
                    <h1>City Master</h1>
                    <ol class="breadcrumb">                       
                        
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb active">City Master</li>
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
                                                     <label for="ddlStateName">State Name(*):</label>                                                                                
                                                </div>
                                        </div>
                                     <div class="col-sm-3">
                                            <div class="form-group">                                                                          
                                               <asp:DropDownList ID="ddlStateName" runat="server" AutoPostBack="True" CssClass="form-control form-select" 
                                                OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged" TabIndex="2" 
                                                HEIGHT="30px">
                                                </asp:DropDownList>
                                                
                                             </div>
                                        </div>
                                        </div>

                                    <div class="row mb-3">
                                        
                                        <div class="col-sm-2">
                                                 <div class="form-group">
                                                     <label for="txtCityName">City Name(*):</label>                                                                                
                                                </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                           
                                               <asp:TextBox ID="txtCityName" runat="server" TabIndex="1" placeholder="Enter City Name(*)" CssClass="form-control" height="30px">
                                               </asp:TextBox> 
                                                 
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                    
                                             <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  
                                              Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                             <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"   CausesValidation="False" 
                                             onclick="btnReset_Click" Text="Reset" />
                                            <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary"  
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" Visible="False" />
                            

                                            
                                        </div>
                                               
                                    </div>

                                    <div class="row mb-3">
                                        <div class="col-sm-12">
                                            <div class="row">
                                       <div class="table-responsive" style="width:100%">                                                                                                          
                                <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvCity_RowDeleting"
                                class="table table-responsive table-sm table-bordered" Width="100%" 
                                AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black"
                                OnRowEditing="gvCity_RowEditing" DataKeyNames="CityId" 
                                 CellPadding="3" AllowPaging="True"
                                OnPageIndexChanging="gvCity_PageIndexChanging" PageSize="5" 
                                TabIndex="5" EmptyDataText="No Records to Display" ShowHeaderWhenEmpty="True">
                                <Columns>
                                    
                                    <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                        ShowCancelButton="False" ShowEditButton="True">
                                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="CityId" HeaderText="CityId" Visible="False" />
                                    <asp:BoundField DataField="CityName" HeaderText="City Name">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StateName" HeaderText="State Name">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                   
                                    <asp:TemplateField >
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images0/delete.gif"
                                                OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record"
                                                CommandName="Delete" />
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
                                
                            </div>
                        

                        </section>
                  </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

