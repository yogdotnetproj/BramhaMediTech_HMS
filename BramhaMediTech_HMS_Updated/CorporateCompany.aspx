<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="CorporateCompany.aspx.cs" Inherits="CorporateCompany" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <script type = "text/javascript">
         function Validate() {

             if (document.getElementById("MainContent_txtCorporateCompanyName").value == "") {
                 alert("Please Enter Company Name");
                 return false;
             }
             if (document.getElementById("MainContent_txtCorporateCompanyAddress").value == "") {
                 alert("Please Enter Company Address");
                 return false;
             }

             if (document.getElementById("MainContent_ddlCountryName").value == "0") {
                 alert("Please Select Country");
                 return false;
             }
             if (document.getElementById("MainContent_ddlStateName").value == "0") {
                 alert("Please Select State");
                 return false;
             }
             if (document.getElementById("MainContent_ddlCityName").value == "0") {
                 alert("Please Select City");
                 return false;
             }
             if (document.getElementById("MainContent_txtContactPersonName").value == "") {
                 alert("Please Enter Contact Person");
                 return false;
             }


         }
        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <section class="content-header d-flex">
                    <h1>Corporate Company</h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                         <li class="breadcrumb-item active">Corporate Company</li>
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
                                   <div class="table-responsive" style="width:100%">                                                                                  
             

                            <asp:GridView ID="gvCorporateCompany" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="CorporateCompanyId" OnRowDeleting="gvCorporateCompany_RowDeleting"
                            OnRowEditing="gvCorporateCompany_RowEditing"  CellPadding="3" 
                             class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            AllowPaging="True" onpageindexchanging="gvCorporateCompany_PageIndexChanging" 
                            PageSize="5" TabIndex="17" ShowHeaderWhenEmpty="True">
                            <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="70px" HorizontalAlign="Center"/>
                                </asp:CommandField>
                                <asp:BoundField DataField="CorporateCompanyId" HeaderText="Corp Company Id"
                                    Visible="False" />
                                <asp:BoundField DataField="CorporateCompanyName" HeaderText="Corp. Company Name" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CorporateCompanyAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CountryName" HeaderText="Country" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StateName" HeaderText="State" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CityName" HeaderText="City" 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PostalCode" HeaderText="Postal Code" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FaxNo" HeaderText="Fax No" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ContactPersonName" HeaderText="CP. Name " 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CPMobileNo" HeaderText="C. P. Mobile" 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CPPhone" HeaderText="C. P. Phone" 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CPEmail" HeaderText="C. P. Email" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Notes" HeaderText="Notes" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CommandName="Delete"  CausesValidation="false" />
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
                         <!--   ======================== -->
                           <div class="box" runat="server" id="show">
                                <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                            <div class="col-lg-12">
                                                     <div class="row">
                                               <div class="col-lg-6">
                                                     <div class="row mb-3">
                                
                                        <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtCorporateCompanyName">Insurance Companye:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-8">                                            
                                            <div class="form-group">
                                                                                            
                                                <asp:TextBox ID="txtCorporateCompanyName" runat="server" CssClass="form-control" Placeholder="Corporate Company Name(*)" height="30px"
                                                 AutoPostBack="True" OnTextChanged="txtCorporateCompanyName_TextChanged" 
                                                 TabIndex="1"></asp:TextBox>
                                                         
                                                 
                                            </div>
                                          </div>
                                        </div>

                                                <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtEmail">Email Id:</label>                                                                                
                                                    </div>
                                         </div>
                                            
                                        <div class="col-sm-8">                                                                                            
                                            <div class="form-group"> 
                                              <asp:TextBox ID="txtEmail" runat="server"  CssClass="form-control" Placeholder="Enter Email Id(*)" AutoPostBack="True"
                                             OnTextChanged="txtEmail_TextChanged" TabIndex="8"></asp:TextBox> 
                                                                                              
                                            </div>
                                          </div>
                                                


                                                </div>
                                       
                                       
                                            <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtCorporateCompanyAddress">Corporate Companye:</label>                                                                                
                                                    </div>
                                         </div>
                                                 <div class="col-sm-8">                                            
                                            <div class="form-group"> 
                                                     
                                                 <asp:TextBox ID="txtCorporateCompanyAddress" runat="server" AutoPostBack="True"
                                                TextMode="MultiLine" TabIndex="2" CssClass="form-control" Placeholder="Corporate Company Address(*)" ></asp:TextBox>
                                               
                                            
                                            </div>
                                          </div>
                                               </div>                                           

                                       
                                            <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="ddlCountryName">Country:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-8">                                            
                                            <div class="form-group">                                               
 
                                                  <asp:DropDownList ID="ddlCountryName" runat="server" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged"
                                                 AutoPostBack="True" CssClass="form-control form-select" TabIndex="3">
                                                </asp:DropDownList>
                                               

                                            </div>
                                          </div>
                                                </div>                                          

                                       
                                           <div class="row mb-3">                                               
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="ddlStateName">State:</label>                                                                                
                                                    </div>
                                                </div>                                              
                                                   <div class="col-sm-8">
                                                        <div class="form-group">
                                                            
                                                            <asp:DropDownList ID="ddlStateName" runat="server" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged"
                                                                AutoPostBack="True" CssClass="form-control form-select" TabIndex="4">
                                                            </asp:DropDownList>  
                                                                  
                                                         </div>
                                                      
                                                     </div>
                                               </div>
                                          
                                        
                                           <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="ddlCityName">City:</label>                                                                                
                                                    </div>
                                                </div>   
                                                   <div class="col-sm-8">
                                                        <div class="form-group">
                                                            
                                                            <asp:DropDownList ID="ddlCityName" runat="server" OnSelectedIndexChanged="ddlCityName_SelectedIndexChanged"
                                                                  CssClass="form-control form-select" AutoPostBack="True" TabIndex="5">
                                                            </asp:DropDownList>
                                                           
                                                         </div>
                                                      
                                                     </div>
                                               </div>
                                             
                                        
                                           
                                            
                                        
                                           <div class="row mb-3">
                                               <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtPhoneNo">Phone No:</label>                                                                                
                                                    </div>
                                                </div>   
                                                   <div class="col-sm-8">
                                                       <div class="form-group">
                                                             
                                                            <asp:TextBox ID="txtPhoneNo" runat="server" AutoPostBack="True" CssClass="form-control" placeholder="Enter Phone No."
                                                             OnTextChanged="txtPhoneNo_TextChanged" TabIndex="9"></asp:TextBox>
                                                          
<%--                                                           <asp:RegularExpressionValidator ID="revPhoneNo" runat="server" ControlToValidate="txtPhoneNo"
                                                          ErrorMessage="Enter Proper" ForeColor="#FF3300" 
                                                            ValidationExpression="0+\d{9}"></asp:RegularExpressionValidator>    
                                            --%>
                                                       </div>
                                                  </div>
                           
                                            </div>   
                                      
                                                         
                                                   </div>

                    <%--     Contact        --%>      
                                         <div class="col-lg-6">
                                                     <div class="row mb-3">
                                         
                                                 <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtContactPersonName">Contact Person:</label>                                                                                
                                                    </div>
                                                </div>
                                                <div class="col-sm-8">
                                                       <div class="form-group">                                                           
                                                            <asp:TextBox ID="txtContactPersonName" runat="server" CssClass="form-control" placeholder="Enter Contact Person Name" Height="30px"
                                                            AutoPostBack="True" OnTextChanged="txtContactPersonName_TextChanged" 
                                                            TabIndex="11"></asp:TextBox>
                                                           
                                            
                                                       </div>
                                                  </div>
                                                </div>
                                            
                                        
                                            <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtCPMobileNo">Mobile No:</label>                                                                                
                                                    </div>
                                                </div>
                                                <div class="col-sm-8">
                                                       <div class="form-group">  
                                                                                                                     
                                                           <asp:TextBox ID="txtCPMobileNo" runat="server" CssClass="form-control" AutoPostBack="True"
                                                             Placeholder="Enter C.P. Mobile No." OnTextChanged="txtCPMobileNo_TextChanged" TabIndex="12"></asp:TextBox>
                                                           <%--      
                                                           <asp:RegularExpressionValidator ID="revCPMobileNo" runat="server" ControlToValidate="txtCPMobileNo"
                                                               ErrorMessage=" Enter Proper " ForeColor="#FF3300" 
                                                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>--%>
                                                       </div>
                                                  </div>
                                                </div>
                                            
                                        
                                            <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtCPPhoneNo">Phone No:</label>                                                                                
                                                    </div>
                                                </div>
                                                <div class="col-sm-8">
                                                       <div class="form-group">
                                                           
                                                            <asp:TextBox ID="txtCPPhoneNo" runat="server" CssClass="form-control" Placeholder="Enter C.P. Phone No." Height="30px" AutoPostBack="True"
                                                            OnTextChanged="txtCPPhoneNo_TextChanged" TabIndex="13"></asp:TextBox>
                                                           
<%--                                                            <asp:RegularExpressionValidator ID="revCPPhoneNo" runat="server" ControlToValidate="txtCPPhoneNo"
                                                            ErrorMessage ="Enter Proper" ForeColor="#FF3300" 
                                                            ValidationExpression="0+\d{9}"></asp:RegularExpressionValidator>--%>
                         
                                                       </div>
                                                  </div>
                                                </div>
                                            
                                        
                                            <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtCPEmailId">Email ID:</label>                                                                                
                                                    </div>
                                                </div>
                                                <div class="col-sm-8">
                                                       <div class="form-group">
                                                           
                                                            <asp:TextBox ID="txtCPEmailId" runat="server" CssClass="form-control" Placeholder="Enter C.P. Email Id."  Height="30px" AutoPostBack="True"
                                                            OnTextChanged="txtCPEmailId_TextChanged" TabIndex="14"></asp:TextBox>
                                                           
                                                           
                                                       </div>
                                                  </div>
                                                


                                            </div>
                                        

                                       
                                            <div class="row mb-3">
                                                 <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtNotes">Notes:</label>                                                                                
                                                    </div>
                                                </div>
                                                  <div class="col-sm-8">
                                                       <div class="form-group">
                                                             
                                                            <asp:TextBox ID="txtNotes" runat="server" AutoPostBack="True"  TextMode="MultiLine" CssClass="form-control"
                                                             placeholder="Enter Notes" TabIndex="7"></asp:TextBox>
                                                       </div>
                                                  </div>
                                                </div>
                                           
                                                
                                            <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtFaxNo">Fax No:</label>                                                                                
                                                    </div>
                                                </div>
                                                  <div class="col-sm-8">
                                                       <div class="form-group"> 
                                                                                                                    
                                                           <asp:TextBox ID="txtFaxNo" runat="server" AutoPostBack="True" CssClass="form-control" Placeholder="Enter Fax No."
                                                            OnTextChanged="txtFaxNo_TextChanged" TabIndex="10"></asp:TextBox>
                                                           
                                                           <%--<asp:RegularExpressionValidator ID="revFaxNo" runat="server" ControlToValidate="txtFaxNo"
                                                             ErrorMessage="Enter Proper" ForeColor="#FF3300" ValidationExpression="0+\d{9}"></asp:RegularExpressionValidator>
                     --%>
                                                       </div>
                                                  </div>
                                        </div>     
                                             
                                             <div class="row mb-3">
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                         <label for="txtPostalCode">Postal Code:</label>                                                                                
                                                    </div>
                                                </div>   
                                                   <div class="col-sm-8">
                                                       <div class="form-group">
                                                               
                                                            <asp:TextBox ID="txtPostalCode" runat="server" AutoPostBack="True" CssClass="form-control"
                                                            OnTextChanged="txtPostalCode_TextChanged" placeholder="Enter Postal Code" MaxLength="6" TabIndex="6"></asp:TextBox>
                                                           
                                                       </div>
                                                  </div>
                                              
                                               </div>                               
                                       
                                                         </div>
                                             </div>

                                                         </div>
                                                </div>
                                     </div>
                                   </div>
                           
                                
                                <div class="box-footer">
                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                    
                                             <asp:Button ID="btnsave" runat="server"  class="btn btn-primary"  OnClientClick="return Validate();" 
                                              Text="Save" onclick="btnSave_Click"/>                                    
                                     
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

