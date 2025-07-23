<%@ Page Title="Service charges" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="BillServiceCharges.aspx.cs" Inherits="BillServiceCharges" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_ddlRateType").value == "0") {
                alert("Please Select Rate Type");
                return false;
            }
            //alert(document.getElementById("MainContent_RdbServicesFlag_1").checked)
            //if (document.getElementById("MainContent_RdbServicesFlag_1").checked == true)
            //{
            //    if (document.getElementById("MainContent_ddlBillService").value == "0")
            //    {
            //        alert("Please Select Service");
            //        return false;
            //    }
            //}
            
        }
        </script>

     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1> Bill service charges</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active"> Bill service charges</li>
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
                               <!-- ====================================================================================-->
                                 <div class="col-sm-12 mb-3">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlag_SelectedIndexChanged" >
                                                             <asp:ListItem>DocWise</asp:ListItem>
                                                             <asp:ListItem>RoomWise</asp:ListItem>
                                                             <asp:ListItem>Direct</asp:ListItem>
                                                              <asp:ListItem>Lab</asp:ListItem>
                                                             </asp:RadioButtonList>                                          
                                                     </div>                
                                    </div>
                                
                                                <div class="row mb-3">                                            
                                                   <div class="col-sm-2">
                                      <div class="form-group">
                                         <label for="ddlPatientType">Patient Type:</label>                                                                                
                                      </div>
                                  </div>                            
                                       
                                                   <div class="col-sm-3">
                                            <div class="form-group">                                                                                                       
                                               
                                                <asp:DropDownList ID="ddlPatientType" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPatientType_SelectedIndexChanged"  CssClass="form-control form-select"
                                                 TabIndex="2">
                                                  <asp:ListItem Selected="True" Value="1">OPD</asp:ListItem>
                                                  <asp:ListItem  Value="2">IPD</asp:ListItem>
                                              </asp:DropDownList>
                                                 
                                            </div>
                                        </div>
                                                            
                                                   <div class="col-sm-2">
                                      <div class="form-group">
                                         <label for="ddlRateType">Rate Type:</label>                                                                                
                                      </div>
                                  </div>                               
                                       
                                                   <div class="col-sm-3">
                                            <div class="form-group"> 
                                                <asp:DropDownList ID="ddlRateType" runat="server"  cssclass="form-control form-select" AutoPostBack="True">                                                 
                                                </asp:DropDownList>
                                            </div>
                                        </div>  
                                                    <div class="col-sm-2">
                                            <div class="form-group"> 
                                                  <asp:Button ID="btnok" runat="server" Visible="false" Text="OK" CssClass="btn btn-primary" OnClick="btnok_Click"  />                       

                                                </div>
                                                        </div>
                                                    </div>
                                      
                                                
                                                <div class="row mb-3">  
                                                     <div class="col-sm-2" >
                                                    <div class="form-group">
                                                         <label for="ddlBillGroupNameSearch">Group Name:</label>                                                                                
                                                    </div>
                                         </div>
                                                     <div class="col-sm-3">
                                            <div class="form-group">

                                                <asp:DropDownList ID="ddlBillGroupNameSearch" runat="server" CssClass="form-control form-select" 
                                                 AutoPostBack="true" OnSelectedIndexChanged="ddlBillGroupNameSearch_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                        </div> 
                                                     <div class="col-sm-2">
                                         <div class="form-group">
                                         <label for="ddlBillService">Bill Services:</label>                                                                                
                                        </div>
                                    </div>
                                                     <div class="col-sm-3">
                                    <div class="form-group">                                     
                                              <asp:DropDownList ID="ddlBillService" runat="server" AutoPostBack="true" CssClass="form-control form-select"
                                                 TabIndex="2" OnSelectedIndexChanged="ddlBillService_SelectedIndexChanged"></asp:DropDownList>
                                   </div>
                                </div>
                                                </div>
                                    
                                


                            </div>
                            <div class="box-footer">
                            <div class="row">
                                 <div class="col-sm-4 text-center">
                                     <asp:TextBox ID="txtsearch" Visible="false" runat="server" CssClass="form-control" Placeholder="Search" 
                                                ></asp:TextBox>   
                                     </div>
                                 <div class="col-sm-2 text-center">
                                     <asp:Button ID="btnSearch" Visible="false" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click"  />                       
                                     </div>
                                <div class="col-sm-6 text-left">
                                   
                                
                                   
                                    <asp:Button ID="btnaction" runat="server" Text="Action" CssClass="btn btn-warning" OnClientClick="return Validate();" OnClick="btnaction_Click" />                       
                                             </div> 
                            </div>
                        </div>


                                       <div class="box-body">

                                   <div class="row">
                                   <div class="table-responsive" runat="server" id="DoctorWise" style="width:100%">   
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
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                                       </div>
                                       <div class="table-responsive" runat="server" id="RoomWise" style="width:100%">                                                                                                   
                  
                            <asp:GridView ID="gvBillChargesRoomwise" runat="server"   AutoGenerateColumns="False" DataKeyNames="BillServiceId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="1000"                           
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                            <Columns>
                                
                              
                               
                                <asp:BoundField DataField="ServiceName"  HeaderText="Service Name"/>   
                               <%-- <asp:BoundField DataField="RTypeId" Visible="false"  HeaderText="RTypeId"/>  --%>
                                <asp:TemplateField HeaderText="Service Charges">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRoomCharges" Text='<%#Bind("rate") %>' runat="server"></asp:TextBox>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                 

                               
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                            </div>
                                   <div class="table-responsive" runat="server" id="Direct" style="width:100%;height: 1000px; ">                                                                                                   
                  
                            <asp:GridView ID="gvBillServiceChargesDirect" runat="server" AutoGenerateColumns="False" DataKeyNames="BillServiceId"
                            class="table table-responsive table-sm table-bordered" Width="100%" 
                            AlternatingRowStyle-BackColor="White" HeaderStyle-ForeColor="Black" 
                            CellPadding="3" AllowPaging="True" PageSize="10000"                            
                             EmptyDataText="No Records to Display" 
                            ShowHeaderWhenEmpty="True" TabIndex="5">
                            <Columns>
                                
                               
                               
                                <asp:BoundField DataField="ServiceName"  HeaderText="Service Name"/>   
                                <%--<asp:BoundField DataField="ServiceId" Visible="false"  HeaderText="ServiceId"/>  --%>
                                <asp:TemplateField HeaderText="Charges">
                                    <ItemTemplate >
                                        <asp:TextBox ID="txtserviceCharges" runat="server" Text='<%#Bind("rate") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                               <%-- <asp:BoundField DataField="MTCode"  HeaderText="Code"/> --%>
                                 <%--<asp:TemplateField HeaderText="Dr Amt">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtsDrAmt" Text='<%#Bind("DrCompamt") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Dr Amt(%)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtsDrAmtpercent" Text='<%#Bind("DrCompPer") %>' runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              --%>
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
                                
                                <div class="box-footer">
                            <div class="row">
                                <div class="col-sm-12 text-center">
                                   
                                
                                   
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" onclick="btnsave_Click" />                       
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

