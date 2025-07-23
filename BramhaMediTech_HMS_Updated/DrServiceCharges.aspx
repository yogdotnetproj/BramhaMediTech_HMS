<%@ Page Title=" Dr Service charges" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="DrServiceCharges.aspx.cs" Inherits="DrServiceCharges" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_ddlBillService").value == "0") {
                alert("Please Select Bill Service");
                return false;
            }

            if (document.getElementById("MainContent_ddlBillSubService").value == "0") {

                alert("Please Select Bill Sub Service!");
                return false;

            }
        }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>OPD Dr service charges</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">OPD Dr service charges</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>

                        <div class="box-body">
                            <div class="row mb-3">
                                <div class="col-sm-6">
                                                <div class="row">                                            
                                                   <div class="col-sm-4">
                                      <div class="form-group">
                                         <label for="ddlRateType">Patient Type:</label>                                                                                
                                      </div>
                                  </div>                               
                                       
                                        <div class="col-sm-8">
                                            <div class="form-group">                                                                                                       
                                               
                                                <asp:DropDownList ID="ddlPatientType" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPatientType_SelectedIndexChanged"  CssClass="form-control form-select"
                                                 TabIndex="2">
                                                  <asp:ListItem Selected="True" Value="1">OPD</asp:ListItem>
                                                 
                                              </asp:DropDownList>
                                                 
                                            </div>
                                        </div>
     
                                                 </div>
                                                </div>

                                 <div class="col-sm-6" > 
                                            <div class="row">
                                                  <div class="col-sm-4">
                                    <div class="form-group">
                                         <label for="ddlcategory">Category:</label>                                                                                
                                        </div>
                                    </div>
                                                  <div class="col-sm-8">
                                    <div class="form-group">                                     
                                              <asp:DropDownList ID="ddlcategory" runat="server" AutoPostBack="false" CssClass="form-control form-select"
                                                 TabIndex="2" ></asp:DropDownList>
                                   </div>
                                </div>
                                            </div>
                                    </div> 
                                </div>

                            <div class="row mb-3">
                                <div class="col-sm-6">
                                                <div class="row">                                            
                                                   <div class="col-sm-4">
                                      <div class="form-group">
                                         <label for="ddlRateType">Rate Type:</label>                                                                                
                                      </div>
                                  </div>                               
                                       
                                        <div class="col-sm-8">
                                            <div class="form-group">                                                                                                       
                                               
                                                
                                                <asp:DropDownList ID="ddlRateType" runat="server" cssclass="form-control form-select" AutoPostBack="True">
                                                 
                                                </asp:DropDownList>
                                                 
                                            </div>
                                        </div>
     
                                                 </div>
                                                </div>
                                 <div class="col-sm-6" > 
                                            <div class="row">
                                                  <div class="col-sm-4">
                                    <div class="form-group">
                                         <label for="ddlBillService">Bill Service:</label>                                                                                
                                        </div>
                                    </div>
                                                  <div class="col-sm-8">
                                    <div class="form-group">                                     
                                              <asp:DropDownList ID="ddlBillService" runat="server" AutoPostBack="true" CssClass="form-control form-select"
                                                 TabIndex="2" OnSelectedIndexChanged="ddlBillService_SelectedIndexChanged"></asp:DropDownList>
                                   </div>
                                </div>
                                            </div>
                                    </div>
                            </div>

                                 <div class="box-footer">
                            <div class="row">
                                <div class="col-lg-12 text-center">
                                   
                                
                                   
                                    <asp:Button ID="btnaction" runat="server" Text="Action" class="btn btn-primary" OnClick="btnaction_Click" />                       
                                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary" onclick="btnsave_Click" />                       
                                             </div> 
                                             </div> 
                        </div>
                                       <div class="box-body">

                                            <div class="row">
                                   <div class="table-responsive" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvBillServiceCharge" runat="server" AutoGenerateColumns="False" DataKeyNames="DrId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="1000"
                            OnRowDeleting="gvBillServiceCharge_RowDeleting" OnRowEditing="gvBillServiceCharge_RowEditing"
                             OnPageIndexChanging="gvBillServiceCharge_PageIndexChanging"
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                            <Columns>
                                
                                
                               
                                <asp:BoundField DataField="Empname"  HeaderText="Dr Name"/>   
                                <asp:BoundField DataField="DrId" Visible="false"  HeaderText="DrId"/>  
                                <asp:TemplateField HeaderText="Charges">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtserviceCharges" Text='<%#Bind("rate") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Dr Amt">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtsDrAmt" Text='<%#Bind("DrCompamt") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Dr Amt(%)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtsDrAmtpercent" Text='<%#Bind("DrCompPer") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
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
                  
                </section>
        </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>


