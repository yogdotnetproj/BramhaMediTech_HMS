<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DepartmentMaster.aspx.cs" Inherits="DepartmentMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtDepartmentName").value == "") {
                alert("Please Enter Department");
                return false;
            }
            //if (document.getElementById("MainContent_txtdeptcode").value == "") {
            //    alert("Please Enter Department");
            //    return false;
            //}
        }
        </script>
   
     <script type="text/javascript">
         function ShowMessage(message, messagetype) {
             var cssclass;
             switch (messagetype) {
                 case 'Success':
                     cssclass = 'alert-success'
                     break;
                 case 'Error':
                     cssclass = 'alert-danger'
                     break;
                 case 'Warning':
                     cssclass = 'alert-warning'
                     break;
                 default:
                     cssclass = 'alert-info'
             }
             $('#exampleModal').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert p-2 in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

             setTimeout(function () {
                 $("#alert_div").fadeTo(1000, 500).slideUp(500, function () {
                     $("#alert_div").remove();
                 });
             }, 500);//5000=5 seconds
         }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
                    <asp:PostBackTrigger ControlID="btnPrint" />
                </Triggers>
              <ContentTemplate>
    <section class="content-header d-flex">
                    <h1>Department Master</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Department Master</li>
                    </ol>
                </section>

    
      <section class="content">
                            <div class="box" runat="server" id="List" >
                               <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <asp:Button ID="btnPrint" runat="server" CausesValidation="False" class="btn btn-primary pull-right"  
                                             OnClick="btnPrint_Click" Visible="false" onclientclick="target = '_blank';" Text="Print" />
                                    
                                            <asp:Button ID="btnaddnew" runat="server" class="btn btn-primary pull-right" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
                                </div>
                                <div class="box-body">

                                            <div class="row">
                                   <div class="table-responsive" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False" DataKeyNames="DeptId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10"
                            OnRowDeleting="gvDepartment_RowDeleting" OnRowEditing="gvDepartment_RowEditing"
                             OnPageIndexChanging="gvDepartment_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                                <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                                  <asp:CommandField HeaderText="Edit" ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:CommandField>
                             
                                <asp:BoundField DataField="DeptId" HeaderText="DeptId" Visible="False" />
                                <asp:BoundField DataField="DeptName" HeaderText="Department"/>
                                    <asp:BoundField DataField="DeptCode" HeaderText="Department Code"/>
                                   
                                
                                 
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="col-lg-12-3">
                                    <div class="row mb-3">
                                                                                
                                        <div class="col-lg-3" >
                                                    <div class="form-group">
                                                         <label for="txtDepartmentName" style="text-align:left">Department Name:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtDepartmentName" runat="server" placeholder="Enter Department (*)" Class="form-control" 
                                                    AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                              </div>   
                                        <div class="col-lg-12-3">
                                             <div class="row mb-3"> 
                                                  <div class="col-lg-3" >
                                                    <div class="form-group">
                                                         <label for="txtdeptcode" style="text-align:left">Department Code:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">                                                    
                                              
                                              <asp:TextBox ID="txtdeptcode" runat="server" placeholder="Enter Department Code (*)" Class="form-control" 
                                                    AutoPostBack="True" 
                                                    TabIndex="1"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                                <div class="col-lg-4 text-left">
                                    
                                                  <asp:Button ID="btnsave" runat="server"   data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-primary"  
                                                 Text="Save" onclick="btnSave_Click" OnClientClick="return Validate();"/>                                    
                                     
                                                     <asp:Button ID="btnReset" runat="server" class="btn btn-primary"   CausesValidation="False" 
                                                    onclick="btnReset_Click" Text="Reset"  />

                                        </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                                
                            </div>

                        </section>
                  
                  </ContentTemplate>
        </asp:UpdatePanel>
    
    <div class="modal fade" id="exampleModal"  tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
           <center><img id="Img1" src="~/Images0/Progress-Bar.png" height="100" runat="server" /></center>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <asp:Button type="button" runat="server"  id="mClose" class="btn btn-secondary" Text="Close" data-bs-dismiss="modal"/>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
</asp:Content>

