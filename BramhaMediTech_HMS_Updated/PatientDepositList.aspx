<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientDepositList.aspx.cs" Inherits="PatientDepositList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

            <section class="content-header d-flex">
                    <h1>Patient List</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Patient List</li>
                    </ol>
                </section>
      <section class="content">
                      <div class="box" runat="server" id="show">
                             <div class="box-header with-border">
                           
                                    <span class="red pull-right">Fields marked with * are compulsory</span> 
                                </div>
                             <div class="box-body">
                                    <div class="row">                                
                                         <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtFromDate">From Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div>
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtToDate">To Date:</label>                                                                                
                                                    </div>
                                         </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy">
                                                        
                                                      <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Enter Entry Date(*)"></asp:TextBox>
                                                         <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                 </div>
                                             
                                            </div>
                                          
                                        </div>
                                        
                                       <%-- <div class="col-sm-1 text-left" style="width:220px">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtBarcode" runat="server" Width="210px" CssClass="form-control" placeholder="Enter Barcode(*)" ></asp:TextBox>
                                             </div>
                                              
                                        </div>                                      
                                        
                                      --%> 
                                        <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtPrnNo">PRN No:</label>                                                                                
                                                    </div>
                                         </div>
                                         <div class="col-sm-2">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtPrnNo" runat="server" CssClass="form-control" placeholder="PRN No.(*)"></asp:TextBox>                       
                                            </div>
                                        </div>
                                       


                                        <div class="col-lg-12 mt-3">
                                            <div class="row">
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtPatientName">Patient Name:</label>                                                                                
                                                    </div>
                                         </div>
                                                <div class="col-sm-2">
                                            <div class="form-group">       
                                                 
                                                <asp:TextBox ID="txtPatientName" runat="server"  AutoPostBack="True" ontextchanged="txtPatientName_TextChanged" CssClass="form-control" placeholder="Enter Patient Name(*)" ></asp:TextBox>                                  
                                             <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                 </div>
                                        </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                         <label for="txtMobileNo">Mobile No:</label>                                                                                
                                                    </div>
                                         </div>
                                                 <div class="col-sm-2">
                                              <div class="form-group">
                                                 <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="MobileNo.(*)" MaxLength="10" ></asp:TextBox>                       
                                              </div>
                                       </div>
                                                <div class="col-sm-2" >
                                            <div class="form-group">
                                                 <label for="txtBirthDate">BirthDate:</label>     
                                                </div>
                                             </div> 
                                 <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                 
                                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server"   CssClass="form-control" TabIndex="12" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
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
                                        <div class="col-sm-4">                                    
                                              <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success"   OnClick="btnSearch_Click" Text="Search"
                                                 />
                                              <asp:Button ID="btnNew" runat="server" CssClass="btn btn-primary"   onclick="btnNew_Click" Text="New" 
                                                />
                                        </div>
 
                                            </div>
                                        </div>
                                      
                                    </div>
                                </div>
                             
                                    
                                        
                                   
                      </div>
                      <div class="box" runat="server" id="List" >
                             <div class="box-header with-border">
                                    <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                          
                                </div>
                             <div class="box-body">
                                   <div class="table-responsive" style="width:100%">          
                     
                                    <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="PatientInfoId"
                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White"
                                     CellPadding="3" AllowPaging="True"
                                        BackColor="White"
                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    OnPageIndexChanging="gvPatientInfo_PageIndexChanging" PageSize="10" ShowHeaderWhenEmpty="True"
                                    TabIndex="27"  onrowcommand="gvPatientInfo_RowCommand" 
                                    onselectedindexchanged="gvPatientInfo_SelectedIndexChanged1">
                            
                                        <Columns>
             
                                <asp:ButtonField CommandName="Select" Text="Select" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                <asp:BoundField DataField="PatientInfoId" HeaderText="Patient Info Id" Visible="False">
                                </asp:BoundField>
                                <asp:BoundField DataField="PatRegId" HeaderText="PRN No." 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" 
                                ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                </asp:BoundField>

                               <%--<asp:TemplateField HeaderText="PatientCategory-SubCategory" SortExpression="PatientInsuType">
                               <ItemTemplate>
                               <asp:Label ID="lbl1" runat="server" Text='<%#Eval("PatMainType")+" / "+Eval("PatientInsuType") %>' >
                               </asp:Label>
                               </ItemTemplate>
                               </asp:TemplateField> --%>
                                
                                <asp:BoundField DataField="PatientAddress" HeaderText="Address" 
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:BoundField> 
                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" >
                                             <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                </asp:BoundField> 
                                             <asp:BoundField DataField="BirthDate" HeaderText="Date Of Birth" >
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                </asp:BoundField> 
                               
                                <asp:BoundField DataField="Email" HeaderText="Email" 
                                    ItemStyle-HorizontalAlign="Left" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                             <asp:BoundField DataField="DepositAmt" HeaderText="Deposit" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                               
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
      </section>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>


