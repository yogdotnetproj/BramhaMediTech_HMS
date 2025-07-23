<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="OTBookingForm.aspx.cs" Inherits="OTBookingForm" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
               $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert p-2 in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

               setTimeout(function () {
                   $("#alert_div").fadeTo(1000, 500).slideUp(500, function () {
                       $("#alert_div").remove();
                   });
               }, 500);//5000=5 seconds
           }
    </script>
      <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <%-- <Triggers>
           
             <asp:PostBackTrigger ControlID="btnCaseReport" />
            <asp:PostBackTrigger ControlID="btnsave" />
             
        </Triggers>--%>
        <ContentTemplate>
        

            <section class="content-header d-flex">
                    <h1>OT Booking Form</h1>
                    <ol class="breadcrumb">
                       
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">OT Booking Form</li>
                    </ol>
                </section>
              <div class="box" runat="server" id="Show">
            <div class="box-body">
                                    <div class="row"> 

                                         <div class="messagealert" id="alert_container">   </div>  
                                        </div>
                 <div class="col-lg-12 mt-3" > 
                                            <div class="row">  
                                                <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtPatientName">Patient Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>                             
                                                <div class="col-sm-10">
                                                    <div class="form-group">                 
                                   
                                                <asp:TextBox ID="txtPatientName" runat="server" TabIndex="3" AutoCompleteType="None" cssclass="form-control"  placeholder="Enter Patient Name(*)"
                                                AutoPostBack="True" ontextchanged="txtPatientName_TextChanged" Font-Bold="True" Font-Size="Medium"  ></asp:TextBox>
                                               <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                     CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtPatientName"
                                                ID="AutoCompleteExtender1"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                             </div>
                                        </div>
                                               
                                                
                                                
                                                
                                                 
                                 </div>
                                          
                                            </div> 
                                        <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Birth Date</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                                                                                                                                                                                                                    
                                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtBirthDate" runat="server"   TabIndex="4" CssClass="form-control"
                                                             AutoPostBack="True" OnTextChanged="txtBirthDate_TextChanged" BorderStyle="Outset"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                    
                        
                                                        </div>
                                                       
                                                        </div>
                                                    </div>
                                                                                         
                                                        <div class="col-sm-1">
                                                        <div class="form-group"> 
                                                            <label for="txtAge">Age</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>     
                                                                                                       
                                                           <div class="col-sm-1">
                                                           <div class="form-group"> 
                                                                                                                     
                                                       
                                                                <asp:TextBox ID="txtAge" runat="server" TabIndex="5" CssClass="form-control" placeholder="Age" 
                                                                ontextchanged="txtAge_TextChanged"  onkeyPress="return numeric_only(event);" AutoPostBack="True"></asp:TextBox>
                                                            
                                                           </div>
                                                         </div>     
                                                                                                                                                   
                                                           <div class="col-sm-2">
                                                            <div class="form-group">
                                                                
                                                                    <asp:DropDownList ID="ddlAge" runat="server" AutoPostBack="True" 
                                                                        CssClass="form-control form-select" TabIndex="6" 
                                                                        onselectedindexchanged="ddlAge_SelectedIndexChanged">
                                                                        <asp:ListItem>Year</asp:ListItem>
                                                                        <asp:ListItem>Month</asp:ListItem>
                                                                        <asp:ListItem>Day</asp:ListItem>
                                                                    </asp:DropDownList>
                                                           </div>
                                                           
                                                         
                                                        </div>
                                                  <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtMobileNo">Mobile No</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div>    
                                                <div class="col-sm-2">
                                                    <div class="form-group">
                                                       
                                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Enter Mobile No." 
                                                             onkeyPress="return numeric_only(event);" TabIndex="7" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                   <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Surgen</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                 <div class="col-sm-4">
                                                        <div class="form-group"> 
                                                             <asp:TextBox ID="txtsurgen" runat="server"  CssClass="form-control" placeholder="Enter Surgeon" AutoPostBack="True" OnTextChanged="txtsurgen_TextChanged"></asp:TextBox>     
                                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="Searchsurgan"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                              CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtsurgen"
                                                ID="AutoCompleteExtender2"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                            </div>
                                                     </div>
                                                <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Operation Name</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                 <div class="col-sm-4">
                                                        <div class="form-group"> 
                                                             <asp:TextBox ID="txtoperation" runat="server"  CssClass="form-control" placeholder="Enter OPERATION" bddcc OnTextChanged="txtoperation_TextChanged"></asp:TextBox>        
                                                         <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchOperaation"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                               CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtoperation"
                                                ID="AutoCompleteExtender9"
                                                runat="server"><%--ServicePath="~/AutoCompleteService.asmx"--%>
                                                   </asp:AutoCompleteExtender>
                                                            </div>
                                                     </div>
                                                </div>
                       </div>

                 <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Schedule Date</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                 <div class="col-sm-4">
                                                        <div class="form-group"> 
                                                             <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtScheduleDate" runat="server"   TabIndex="4" CssClass="form-control"
                                                             AutoPostBack="True"  BorderStyle="Outset"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                    
                        
                                                        </div>
                                                            </div>
                                                     </div>
                                                 <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Estimated Cost</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                 <div class="col-sm-4">
                                                        <div class="form-group"> 
                                                            <asp:TextBox ID="txtestimatedCost" runat="server" CssClass="form-control" placeholder="Enter Estimated Cost." 
                                                            ></asp:TextBox>
                                                            </div>
                                                     </div>
                                                </div>
                     </div>

                 <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                             <div class="col-sm-2">
                                                        <div class="form-group"> 
                                                            <label for="txtBirthDate">Non Ref Deposit</label>                                                                                                                                                                                              
                                                         </div>
                                                      </div> 
                                                 <div class="col-sm-4">
                                                        <div class="form-group"> 
                                                             <asp:TextBox ID="txtNonRefDeposit" runat="server" CssClass="form-control" placeholder="Enter Non Refundable Deposit." 
                                                            ></asp:TextBox>
                                                            </div>
                                                     </div>
                                                <div class="col-sm-1">
                                                        <div class="form-group"> 
                                                               <asp:Button ID="btnsave" runat="server" Text="Save"   OnClick="btnSave_Click" 
                                       class="btn btn-success"  />
                                                            </div>
                                                    </div>
                                                 <div class="col-sm-1">
                                                        <div class="form-group"> 
                                                               <asp:Button ID="btnreport" runat="server" Visible="false" Text="Report"    
                                         class="btn btn-primary" OnClick="btnreport_Click"  />
                                                            </div>
                                                    </div>
                                                </div>
                     </div>

                 <div class="col-lg-12 mt-3"> 
                                            <div class="row">
                                             <div class="col-sm-12">
                                                  <div class="table-responsive" style="width: 100%">
                                                <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="BookId"
                                                    class="table table-responsive table-sm table-bordered" Width="100%"
                                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                    AllowPaging="True" BackColor="White" OnRowCommand="gvPatientInfo_RowCommand" OnPageIndexChanging="gvPatientInfo_PageIndexChanging"
                                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True" OnRowDataBound="gvPatientInfo_RowDataBound" OnRowDeleting="gvPatientInfo_RowDeleting">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>  
                                                        
                                                        <asp:BoundField DataField="PatRegId" HeaderText="Reg Id" ItemStyle-Width="60" Visible="True" >
                                                         <ItemStyle Width="60px" />
                                                         </asp:BoundField>
                                                       
                                                        
                                                        <asp:BoundField DataField="FirstName" HeaderText="Patient Name" ItemStyle-Width="200" >
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="PatAgeType" HeaderText="Age Type" ItemStyle-Width="100" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" ItemStyle-Width="100" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="OperationName" HeaderText="Operation Name" ItemStyle-Width="200" >
                                                       
                                                         <ItemStyle Width="200px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="SurganName" HeaderText="Surgan Name" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        <asp:BoundField DataField="CreatedOn" HeaderText="OT Reg Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                       
                                                        
                                                        <asp:BoundField DataField="EstimatedCost" HeaderText="EstimatedCost" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="NonRefDeposit" HeaderText="NonRef Deposit" ItemStyle-Width="100"  >
                                                         <ItemStyle Width="100px" />
                                                         </asp:BoundField>
                                                        
                                                    <%-- <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()"
                                            ToolTip="Click here to Delete this record" CommandName="Delete"  />
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                </asp:TemplateField>--%>
                                                  
                                                         </Columns>
                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                    <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
                                                    <PagerSettings Mode="NumericFirstLast" />
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
                     </div>

                </div>
                  </div>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

