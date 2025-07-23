<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EmployeeMaster.aspx.cs" Inherits="EmployeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtEmpName").value == "") {
                alert("Please Enter Name");
                return false;
            }

            if (document.getElementById("MainContent_ddlTitleName").value == "Select Title") {

                alert("Please Select Initial!");
                return false;

            }
            if (document.getElementById("MainContent_txtEmployeeAddress").value == "") {
                alert("Please Enter Address");
                return false;
            }

            if (document.getElementById("MainContent_ddlDepartment").value == "0") {

                alert("Please Select Department!");
                return false;

            }
            if (document.getElementById("MainContent_ddlDesignation").value == "0") {

                alert("Please Select Designation!");
                return false;

            }
            if (document.getElementById("MainContent_ddlEmployeeType").value == "0") {

                alert("Please Select Type!");
                return false;

            }
            
            if (document.getElementById("MainContent_txtMobileNo").value == "") {

                alert("Please Enter Mobile No!");
                return false;

            }
            //if (document.getElementById("MainContent_txtPanCardNo").value == "") {

            //    alert("Please Enter PAN Card No!");
            //    return false;

            //}
           // ddlEmployeeType
            
        }

        function numeric_only(e) {
            var keycode;
            if (window.event)
                keycode = window.event.keyCode;
            else if (event)
                keycode = event.keyCode;
            else if (e)
                keycode = e.which;
            else
                return true;
            if ((keycode == 45) || (keycode == 46) || (keycode >= 48 && keycode <= 57)) {
                return true;
            }
            else {
                return false;
            }
            return true;
        }
        </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            
            
            <section class="content-header d-flex">
                    <h1>Employee Registration</h1>
                    <ol class="breadcrumb">
                        
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Employee Registration</li>
                    </ol>
                </section>
            <section class="content">
                            <div class="box" runat="server" id="List" >
                                <div class="box-header">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                           <asp:TextBox ID="txtEmployeeSearch" runat="server" class="form-control" placeholder="Search Employee Name(*)" Width="500px" height="30px" AutoPostBack="True"
                                                  TabIndex="1" OnTextChanged="txtEmployeeSearch_TextChanged"></asp:TextBox>   
                                       <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtEmployeeSearch"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>    
                                            <asp:Button ID="btnaddnew" runat="server" class="btn btn-primary pull-right" 
                                                Text="Add New" onclick="btnaddnew_Click"/>
                                        </div>
                                    
                                <div class="box-body">
                                   <div class="table-responsive" style="width:100%">                       
                                   <asp:GridView ID="gvEmployee" runat="server" AllowPaging="True"
                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="DrId" 
                                    onpageindexchanging="gvEmployee_PageIndexChanging" 
                                    OnRowDeleting="gvEmployee_RowDeleting" OnRowEditing="gvEmployee_RowEditing" 
                                    PageSize="10">
                                        <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                            <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>                              
                                
                                <asp:BoundField DataField="EmpName" HeaderText="Name" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="DeptName" HeaderText="Department" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Designation" HeaderText="Designation" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="EmployeeType" HeaderText="Employee Type" 
                                    ItemStyle-HorizontalAlign="Left" >
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Qualification" HeaderText="Qualification" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mobile" HeaderText="Mobile No" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                               <asp:BoundField DataField="Email" HeaderText="Email" 
                                    ItemStyle-HorizontalAlign="Left" Visible="False">
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                              
                                <div class="box-body">
                                     
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtEmpName">Employee Name:</label>                                                                                
                                        </div>
                                    </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">  
                                               
                                                <asp:DropDownList ID="ddlTitleName"  CssClass="form-control form-select" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                   
                                                
                    
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">                                                
                                               <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control" placeholder="Enter Patient Name(*)" AutoPostBack="True"
                                                  TabIndex="1"></asp:TextBox>                    
                                                
                                                 </div>
                                        </div>                           
                                 
                                       <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtEmpCode">Employee Code:</label>                                                                                
                                        </div>
                                    </div>
                                 
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                 <asp:TextBox ID="txtEmpCode" runat="server" AutoPostBack="True"
                                               CssClass="form-control" placeholder="Enter Employee Code" TabIndex="2"></asp:TextBox>
                   
                                                 </div>
                                        </div>
                                        
                                         

                                        <div class="col-lg-12 mt-3">
                                            <div class="row">
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtEmployeeAddress"> Address:</label>                                                                                
                                                    </div>
                                                </div>
                                                <div class="col-sm-10" >
                                                    <div class="form-group">                                                         
                                                         <%--<asp:TextBox ID="txtEmployeeAddress" runat="server" AutoPostBack="True" class="form-control" Placeholder="Enter Address"
                                                             Height="80px"  TabIndex="4"></asp:TextBox> --%>
                                                        <textarea rows="2" cols="90" ID="txtEmployeeAddress" runat="server"  placeholder="Enter Address" class="form-control"
                                                              tabindex="4"></textarea>
                                                    </div>
                                                 </div>
                                               
                                               
                                            </div>
                                      </div>
                                   <div class="col-lg-12 mt-3">
                                            <div class="row">
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="ddlEmployeeType">Employee Type:</label>                                                                                
                                                    </div>
                                            </div> 
                                             <div class="col-sm-3">
                                                    <div class="form-group">  
                                                          
                                                        <asp:DropDownList ID="ddlEmployeeType" runat="server" CssClass="form-control form-select" AutoPostBack="True"
                                                            TabIndex="17">
                                                            <asp:ListItem Value="0">Select Type</asp:ListItem>
                                                            <asp:ListItem Value="Consultant">Consultant Doctor</asp:ListItem>
                                                            <asp:ListItem Value="Reference">Reference Doctor</asp:ListItem>
                                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                                        </asp:DropDownList>
                   
                                                            
                                                    </div>
                                                </div>                                       
                                                 
                                              <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtEmail"> Email:</label>                                                                                
                                                    </div>
                                              </div> 
                                              <div class="col-sm-3">
                                                    <div class="form-group">
                                                         
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email Id" height="30px" AutoPostBack="True"
                                                         TabIndex="9"></asp:TextBox>
                   
                                                     </div>
                                                 </div>
                                                </div>
                                       </div>
                                       <div class="col-lg-12 mt-3">
                                            <div class="row">
                                             <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtMobileNo"> Mobile:</label>                                                                                
                                                    </div>
                                              </div>                                                 
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                         <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Enter Mobile No.(*)" height="30px" AutoPostBack="True" onkeypress="return numeric_only(event);"
                                                          TabIndex="10"></asp:TextBox>                   
                                                        
                                                     </div>

                                                 </div>
                                               
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtPhoneNo">Phone No:</label>                                                                                
                                                    </div>
                                                </div> 
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                           
                                                            <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="form-control" Placeholder="Enter Phone No." height="30px" AutoPostBack="True" onkeypress="return numeric_only(event);"
                                                              TabIndex="11"></asp:TextBox>
                                                        </div>

                                                 </div>
                                                </div>
                                             </div>
                                <div class="col-lg-12 mt-3">
                                        <div class="row">
                                             <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="ddlDepartment">Department:</label>                                                                                
                                                    </div>
                                                </div>  
                                             <div class="col-sm-3">
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="True" CssClass="form-control form-select"
                                                            TabIndex="18">
                                                            </asp:DropDownList>                   
                                                        
                                                    </div>
                                                </div>                                            
                                             <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="ddlDesignation">Designation:</label>                                                                                
                                                    </div>
                                                </div>  
                                             <div class="col-sm-3">
                                                    <div class="form-group">                                                          
                                                        <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="True" 
                                                         CssClass="form-control form-select" TabIndex="15">
                                                        </asp:DropDownList>                  
                                              
                                                        </div>
                                                 
                                                 </div>
                                        </div>
                                       </div>


                                             <div class="col-lg-12 mt-3">
                                            <div class="row">     
                                               
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtJoinDate">Joining Date:</label>                                                                                
                                                    </div>
                                                </div>      
                                                 <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true" >                                                            
                                                                <asp:TextBox ID="txtJoinDate" runat="server"  CssClass="form-control" height="30px" AutoPostBack="True" placeholder="Enter Joining Date"
                                                                 TabIndex="13"></asp:TextBox>
                                                                 <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                         </div>
                                                    </div>
                                               </div>
                                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtBirthDate">Birth Date:</label>                                                                                
                                                    </div>
                                                </div> 
                                                 <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true" >                                                            
                                                                <asp:TextBox ID="txtBirthDate" runat="server"   CssClass="form-control pull-right" placeholder="Enter Birthdate" height="30px" AutoPostBack="True"
                                                                TabIndex="12"></asp:TextBox>
                                                             <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                                        </div>
                                                    </div>
                                               </div>
                                               

                                                </div>
                                           </div>
                                        
                                           
                                            
                                        <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtQualification">Qualification:</label>                                                                                
                                                    </div>
                                            </div> 
                                            <div class="col-sm-3">
                                                <div class="form-group">                                                           
                                                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Enter Qualification(*)" height="30px" AutoPostBack="True"
                                                        TabIndex="16"></asp:TextBox>                                                        
                                                </div>
                                            </div>
                                            
                                            <div class="col-sm-2" runat="server" visible="false">
                                                    <div class="form-group">
                                                    <label for="txtPanCardNo">PAN Card No:</label>                                                                                
                                                    </div>
                                            </div> 
                                            <div class="col-sm-3" runat="server" visible="false">
                                                <div class="form-group">                                                           
                                                    <asp:TextBox ID="txtPanCardNo" runat="server" CssClass="form-control" placeholder="Enter PAN Card No(*)" height="30px" AutoPostBack="True"
                                                        TabIndex="16"></asp:TextBox>                                                        
                                                </div>
                                            </div>
                                            </div>
                                            </div>

                                <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="col-sm-2">
                                                    <div class="form-group">
                                                    <label for="txtQualification">Signature:</label>                                                                                
                                                    </div>
                                            </div>
                                            <div class="col-sm-3">
                                                <div class="form-group">                                                           
                                                   <asp:FileUpload ID="FUFileUpload" runat="server"></asp:FileUpload>                                                      
                                                </div>
                                            </div> 
                                              <div class="col-sm-3">
                                                <div class="form-group">                                                           
                                                  <asp:Image ID="Image1" runat="server"></asp:Image>                                             
                                                </div>
                                            </div>
                                           
                                            </div>
                                    </div>

                                      

                                        

                                <div class="box-footer">
                                    <div class="row">
                                        <div class="col-sm-12 text-center">
                                    
                                             <asp:Button ID="btnsave" runat="server"  CssClass="btn btn-primary"  OnClientClick="return Validate();" 
                                             Text="Save" onclick="btnSave_Click"/>                                    
                                     
                                             <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" CausesValidation="False" 
                                             onclick="btnReset_Click" Text="Reset" />

                                             
                                        </div>
                                    </div>
                                </div>
                            </div>
                                         </div>
                               
                          </div>
                        </section>
          
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

