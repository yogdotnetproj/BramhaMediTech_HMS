<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientDepositMaster.aspx.cs" Inherits="PatientDepositMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <script type = "text/javascript">
        function Validate() {
            //  alert("R");
            // alert(document.getElementById("Rbldisctype").value);
           
            if (document.getElementById("MainContent_txtDepositAmt").value == "") {
                alert("Please Enter Amount!");
                return false;
            }
            if (document.getElementById("MainContent_ddlType").value == "0") {
                alert("Please Select Type of Transaction!");
                return false;
            }
        }
        </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
              <asp:PostBackTrigger ControlID="btnReport" />
            </Triggers>
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>Patient Deposit</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Patient Deposit</li>
                    </ol>
            </section>

            <section class="content">
                <div id="Div1" class="box" runat="server">
                   <!-- <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                 <asp:Label ID="lblMessage" ForeColor="DarkRed" runat="server" Text="" EnableViewState="False"></asp:Label>
                               
                            </div>
                        </div>
                    </div>-->
                    <div class="box-header with-border">
                       
                            <div class="col-lg-12 text-left">
                                
                                 <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">RegId:</label>
                                        <asp:Label ID="lblPatRegId" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Patient Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="Div2" class="col-lg-4 text-left" runat="server" >
                                    <div class="form-group">
                                        <label for="lblAddress"   title="" style="text-align: left">Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="" style="text-align: left">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                         
                            <div class="col-lg-12 text-left mt-3">
                                <div class="row">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblGender" title="" style="text-align: left">Gender:</label>
                                        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                     <%--<div class="col-lg-12">
                                                <div class="row"> 
                                <div class="col-lg-1 text-left" style="width:600px">

                                                    <div class="form-Inline"> 
                                                         <asp:RadioButtonList ID="RdbServicesFlag" runat="server" Width="400px" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbServicesFlag_SelectedIndexChanged" >
                                                            <asp:ListItem Value="All">All</asp:ListItem>
                                                              <asp:ListItem Value="Consultation">Consultation</asp:ListItem>
                                                             <asp:ListItem Value="Lab">Lab</asp:ListItem>
                                                             <asp:ListItem Value="Room" Selected="True">Room</asp:ListItem>
                                                             <asp:ListItem Value="Drugs" >Drugs</asp:ListItem>
                                                             <asp:ListItem Value="Other">Other</asp:ListItem>
                                                             </asp:RadioButtonList>                                              
                      
                                                        </div>
                                                     </div>
                                                    </div>
                                    </div>--%>

                      
      
                                         
                                         
                                       
                                        <div class="col-lg-12">                                            
                                            <div class="row"> 
                                                    
                                                              <div class="col-lg-2 text-left">
                                                                   <label> Payment By: </label>
                                                              </div>
                                                    
                                                        <div class="col-lg-10 text-left">

                                                    <div class="form-Inline form-check"> 
                                                         <asp:RadioButtonList ID="RdbPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RdbPayment_SelectedIndexChanged" >
                                                             </asp:RadioButtonList>                                                
                      
                                                        </div>
                                                     </div>

                                                
                                                              
                                                 </div>
                                              </div>                                               
                                        <div id="PaymentDetails" runat="server">
                                                
                                                       <div class="col-lg-12 mt-3">
                                                           <div class="form-group"> 
                                                       <div class="col-lg-2">
                                                           <div class="form-group">  
                                                       <asp:TextBox ID="txtNumber" runat="server"  class="form-control"  placeholder="Card/Cheque No."
                                                     TabIndex="8"></asp:TextBox>
                                                
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2">
                                                           <div class="form-group">  
                                                                               
                                                       <asp:DropDownList ID="txtbankName" runat="server"  CssClass="form-control"    placeholder="Bank Name"  ></asp:DropDownList>

                                                               </div>
                                                        </div>
                                                       <div class="col-lg-2" runat="server" id="ChequeDate">
                                            <div class="form-group">
                                                <div class="input-group date" data-date-format="dd/mm/yyyy" data-provide="datepicker" >
                                                            
                                                           <input id="txtchequedate" class="form-control"  type="text" runat="server" autopostback="true" placeholder="dd/mm/yyyy" /> 
                                                        
                                                    <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                  </span>
                                                </div>
                                                      </div>
                                        </div>   
                                                               </div>
                                                           </div>
                                                       
                                                       </div>
                                        <div class="col-lg-12 mt-3">                                            
                                                   <div class="row"> 
                                                       
                                                       <div class="col-lg-2">
                                                           <div class="form-group">  
                                                        <label> Deposit Amount: </label>
                                                               </div>
                                                        </div>
                                                       <div class="col-lg-3">
                                                           <div class="form-group">  
                                                                               
                                                        <asp:TextBox ID="txtDepositAmt" runat="server" Text="0"  class="form-control"  placeholder="Enter Amount"
                                                      TabIndex="8"></asp:TextBox>
                                                               </div>
                                                        </div>
                                                               
                                                       
                                                
                                                    
                                                         
                                                        </div>
                                                        </div>
                                        <div class="col-lg-12 mt-3">     
                                                     <div class="row">
                                                       
                                                         

                                                          <div class="col-lg-2">
                                                           <div class="form-group">  
                                                        <label> Type : </label>
                                                               </div>
                                                        </div>
                                                          <div class="col-lg-2">
                                                           <div class="form-group">  
                                                       
                                                               <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True"  CssClass="form-control form-select" >
                                                                   <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                   <asp:ListItem>Deposit</asp:ListItem>
                                                                   <asp:ListItem>Withdrawal</asp:ListItem>
                                                    </asp:DropDownList>
                                                               </div>
                                                        </div>
                                                               
                                                       </div>
                                           </div>
                        <div class="col-lg-12 mt-3">     
                         <div class="row">
                              <div class="col-lg-2">
                                                           <div class="form-group">  
                                                        <label> Remark : </label>
                                                               </div>
                                                        </div>
                                            <div class="col-lg-3">
                                               
                                                   <textarea  runat="server" id="txtRemark" cols="15"  rows="2"></textarea>        
                                                       
                                            </div>
                                        </div>
                            </div>
                                        <div class="col-lg-12 text-center">
                                              <asp:Label ID="lblvalidate" class="red pull-left"  runat="server" Text="" Font-Bold="true" ForeColor="red" ></asp:Label>
                                            <asp:Button ID="btnsave" runat="server" Text="Save"   OnClick="btnSave_Click"  OnClientClick="return Validate();"
                                        TabIndex="15" Width="80px" class="btn btn-success"  />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-primary" Width="80px" /> 
                                             <asp:Button ID="btnReport" runat="server" Text="Report" 
                                        CausesValidation="False" TabIndex="16" class="btn btn-warning" Width="100px"   OnClick="btnReport_Click" />
                                                            
                                             
                                        </div>
                                        <div class="col-lg-12 mt-3">                                            
                                           
                                             <div class="row">
                                               
                                                    <div class="form-group">  
                                        <div class="table-responsive" style="width:100%" >
                                <asp:GridView ID="gvBill" runat="server" AutoGenerateColumns="False" DataKeyNames="DepositId"
                                OnRowDeleting="gvBill_RowDeleting"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                class="table table-responsive table-sm table-bordered" Width="100%"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"   
                                 BorderWidth="1px" CellPadding="3" AllowPaging="True" TabIndex="17"
                                 ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvBill_PageIndexChanging" 
                                 EmptyDataText="No Records to Display"  
                                ShowFooter="True"  OnRowEditing="gvBill_RowEditing" OnRowCommand="gvBill_RowCommand">
                                 <FooterStyle Font-Bold="true" BackColor="#61A6F8" ForeColor="black" />
                            <Columns>
                                <asp:ButtonField CommandName="Select" Text="Report" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                 <asp:CommandField ButtonType="Image" Visible="false" EditImageUrl="~/Images0/edit.gif" 
                                    ShowCancelButton="False" ShowEditButton="True">
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                </asp:CommandField>
                                    <asp:BoundField DataField="DepositDate" HeaderText="Date"  > 
                                <ItemStyle Width="120px" /></asp:BoundField>
                                    <%--<asp:BoundField DataField="BillGroup" HeaderText="BillGroup"  > <ItemStyle Width="150px" /></asp:BoundField>--%>
                               <asp:BoundField DataField="DepositAmt" HeaderText="Amount"  >  <ItemStyle Width="70px" /></asp:BoundField>
                               
                                <asp:BoundField DataField="Type" HeaderText="Type"  >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>
                                 <asp:BoundField DataField="Remark" HeaderText="Remark"  ><ItemStyle Width="150px" /> </asp:BoundField>
                                <asp:BoundField DataField="CreatedBy" HeaderText="Username"  >  
                                <ItemStyle Width="50px" HorizontalAlign="center" /></asp:BoundField>

                                
                                  <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" Visible="false" CommandName="Delete"  CausesValidation="false"
                                            ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                             <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="center" />                                     
                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <%--<SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />--%>
                        </asp:GridView>
                                </div>
                                </div>

                                               
                                                 </div>
                                                               
                                       </div>
                                       
                                              
                                              
                    </div>
                    </div>
                </section>
              <script language="javascript" type="text/javascript">
                  function OpenReport() {
                      window.open("Reports.aspx");
                  }
               </script>
                    <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>

