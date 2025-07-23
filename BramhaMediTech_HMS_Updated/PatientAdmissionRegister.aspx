<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientAdmissionRegister.aspx.cs" Inherits="PatientAdmissionRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />            
        </Triggers>
        <ContentTemplate>--%>
            <section class="content-header d-flex">
                <h1>IPD Patient Admission Register</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">IPD Patient Admission Register</li>
                    </ol>
            </section>
            <section class="content">
                <div id="Div1" class="box" runat="server">
                    <div class="box-body">
                        <div class="row">
                                 <div class="col-sm-1 pr-0">
                                                             <div class="form-group">
                                                                 
                                                             <label for="txtFrom">From Date:</label> 
                                                             </div>
                                                         </div>                             
                                    
                                                         
                                                        
                                                          <div class="col-sm-2">
                                                     <div class="form-group">
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="Div2" data-provide="datepicker" >
                                                           <asp:TextBox id="txtFrom" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                      </div>
                                                    </div> 

                                                   
                                     <div class="col-sm-1">
                                                             <div class="form-group">
                                                               <label for="txtTo">To Date:</label>
                                                             </div>
                                                         </div>
                                     <div class="col-sm-2">
                                                     <div class="form-group">
                                                         
                                                         
                                                         <div class="input-group date" data-date-format="dd/mm/yyyy"  runat="server" id="datepicker1" data-provide="datepicker" >
                                                           <asp:TextBox id="txtTo" class="form-control" type="text" runat="server" autopostback="true" placeholder="Enter From Date" /> 
                                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                         </div>
                                                     

                                                     </div>
                                                 </div>
                            <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="ddlPatientCategoryName">Sponser Category</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>
                                                 <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                           <asp:DropDownList ID="ddlPatientCategoryName" runat="server" AutoPostBack="True" TabIndex="2" CssClass="form-control form-select"
                                                                
                                                            OnSelectedIndexChanged="ddlPatientCategoryName_SelectedIndexChanged" >
                                                         </asp:DropDownList>                    
                                                                       
                                                       </div>
                                                    </div>
                                  
                              <div class="col-sm-2">
                                                    <div class="form-group">
                                                       
                     <asp:TextBox ID="txtConsDoctorName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Select Dr Name(*)"
                                                AutoPostBack="True"  OnTextChanged="txtConsDoctorName_TextChanged"></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="3"  
                                                ServiceMethod="SearchConsultDoc"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtConsDoctorName"
                                                ID="AutoCompleteExtender4"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                    </div>
                                                   </div> 
                                                        
                                     
                                      
                            <div class="col-lg-12 mt-3" >
                                <div class="row">
                                      
                                     
                                   
                                        <div class="col-sm-4">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Enter Patient Name(*)"
                                                 AutoPostBack="True" ontextchanged="txtPatientName_TextChanged" ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="3"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                                  
                              
                                              <div class="col-sm-2">
                                                    <div class="form-group">
                                        
                                                         <asp:DropDownList ID="ddlPatientSubCategoryName" runat="server"  TabIndex="3" CssClass="form-control form-select" >
                                                         </asp:DropDownList>                    
                                                       
                                                    </div>
                                                </div> 
                                    <div class="col-sm-2">
                                                    <div class="form-group">
                                        
                                                         <asp:DropDownList ID="ddlSurgeryType" runat="server"  TabIndex="3" CssClass="form-control form-select" >
                                                         </asp:DropDownList>                    
                                                       
                                                    </div>
                                                </div>
                                    <div class="col-sm-2">
                                                    <div class="form-group">
                                        
                                                           <asp:TextBox ID="txtreferdr" runat="server" AutoCompleteType="None"  CssClass="form-control" placeholder="Refer Dr"
                                                 AutoPostBack="True" OnTextChanged="txtreferdr_TextChanged"  ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="3"  
                                                ServiceMethod="SearchReferDr"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtreferdr"
                                                ID="AutoCompleteExtender2"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>                  
                                                       
                                                    </div>
                                                </div> 
                                                <div class="col-sm-2">
                                                            <div class="form-group">                                                                                           
                                   
                                                            <asp:DropDownList ID="ddlRoomCategory" runat="server" CssClass="form-control form-select"
                                                              TabIndex="18">
                                                            </asp:DropDownList>                   
                                                        
                                                    </div>
                                                </div> 
                                    </div>
                                 </div>
                                   
                                <div class="col-lg-12 mt-3 center" >
                                <div class="row">
                                      <div class="col-sm-2 text-center">
                                        <div class="form-group">
                                            <asp:RadioButtonList id="RblType" runat="server" RepeatDirection="Horizontal" >
                                                <asp:ListItem  Value="0">Admited</asp:ListItem>
                                                <asp:ListItem Value="1">Discharge</asp:ListItem>
                                                   <asp:ListItem Selected="True" Value="2">All</asp:ListItem>
                                            </asp:RadioButtonList>
                                            </div>
                                          </div>
                                     <div class="col-sm-10 text-left">
                                        <div class="form-group">
                                            
                                           
                                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search" TabIndex="3" ValidationGroup="Date" CssClass="btn btn-warning btnSearch" />
                                       <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-success" 
                                            OnClick="Print_Click"  Text="Print" />
                                            <asp:Button ID="btnexcel" runat="server" CausesValidation="False" CssClass="btn btn-warning" 
                                            Text="Excel" OnClick="btnexcel_Click" />
                                                <asp:Label runat="server" ID="LblMsg" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                 
                                            </div>
                                    </div>
                                       
                                        </div>
                                  </div>

                            <div class="row">
                                    <div class="col-lg-12 mt-3">
                                        <div class="row">
                                            <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="IpdId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                         <asp:ButtonField CommandName="Select" Text="FrontSheet"  ControlStyle-CssClass="btn btn-success" ButtonType="Button" ItemStyle-Width="80" >                                                    
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="IpdNo" HeaderText="IpdNo" ItemStyle-Width="60" >
                                                        
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="PatientName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="DoctorName" HeaderText="Dr.Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                          <asp:BoundField DataField="SurgeryType" HeaderText="Surgery Type" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        
                                                        <asp:BoundField DataField="RType" HeaderText="RType" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="150px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="EntryDate" HeaderText="Admission Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="PatientAddress" HeaderText="Address" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="DateOfDischarge" HeaderText="Discharge Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:ButtonField CommandName="Report" Text="FrontSheet Summary" ControlStyle-CssClass="btn btn-warning" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-warning" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                         <asp:ButtonField CommandName="Summary" Text="Summary" ControlStyle-CssClass="btn btn-success" ItemStyle-Width="80" ButtonType="Button" >
                                                         <ControlStyle CssClass="btn btn-success" />
                                                         <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                         </asp:ButtonField>
                                                       <%-- <asp:HyperLinkField Text="Get" DataNavigateUrlFields="RegId,OpdNo,Name,EntryDate"
                                                            DataNavigateUrlFormatString="frmTreatment.aspx?id={0}&opd={1}&Name={2}&EntryDate={3}" />--%>
                                                    </Columns>
                                                   

                                                     <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
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
                </div>
            </section>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>

       <script language="javascript" type="text/javascript">
           function OpenReport() {
               window.open("Reports.aspx");
           }
               </script>
</asp:Content>


