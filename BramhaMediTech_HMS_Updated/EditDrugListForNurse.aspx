<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="EditDrugListForNurse.aspx.cs" Inherits="EditDrugListForNurse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type = "text/javascript">
        function Validate() {

            if (document.getElementById("MainContent_txtItemUnit").value == "") {
                alert("Please Enter Item Unit");
                return false;
            }
            if (document.getElementById("MainContent_txtItemUnitCode").value == "") {
                alert("Please Enter Item UnitCode");
                return false;
            }
        }
        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
    <section class="content-header d-flex">
        <h1>Treatment</h1>
        <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Treatment</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right">Fields marked with * are compulsory</span>
                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>
               <div class="panel panel-info" >
      <div class="panel-heading" style="font-size:medium;font-weight:bold ;background-color:#B24592" ">Patient Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Label  ID="lblVaccinationStatus" Font-Bold="true" ForeColor="Red"  runat="server" Text=""></asp:Label> </div>
      <div class="panel-body bg-white"  >
    
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name:</label>
                                        <asp:Label ID="lblPatientName" ForeColor="Red" Font-Bold="true" Font-Italic="true" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-3 text-left" >
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div id="Div7" class="col-lg-2 text-left" runat="server" visible="false">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left" id="Div8" runat="server" >
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblMobileNo" title="" style="text-align: left">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                      <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblVisitingNo"   title="" style="text-align: left">Visit No:</label>
                                        <asp:Label ID="lblVisitingNo" runat="server" Text=" "></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>
                             
                       
                            <div class="col-lg-12 text-left">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="" style="text-align: left">Consultant:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left" >
                                    <div class="form-group">
                                        <label for="lblDept" title="" style="text-align: left">Dept:</label>
                                        <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblAge" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="col-lg-2 text-left"  >
                                    <div class="form-group">
                                        <label for="lblToken" title="" style="text-align: left">Token No:</label>
                                        <asp:Label ID="lblToken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                               
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left">DOB:</label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                            </div>

           <div class="col-lg-12 text-left" runat="server" id="IpdRmCat">
                                <div class="row">
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblPa" runat="server"  Text="Sponsor:"></asp:Label>
                                        <asp:Label ID="lblPatCat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                        <asp:Label id="lblAde" runat="server"  Text="Adm.Date:"> </asp:Label>
                                        <asp:Label ID="lblAdmissionDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                                     <div id="Div3" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="lblm"   runat="server" Text="Room Name :"></asp:Label>
                                        <asp:Label ID="lblRoomName" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <asp:label id="kk" runat="server"  Text="Bed number:"></asp:label>
                                        <asp:Label ID="lblBedName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                               
                            </div>
                        </div>
     
            <div class="col-lg-12 text-left">
                                  <div class="row">
                                      <div class="col-lg-6 text-left" >
                                    <div class="form-group">
                                        <label for="lblAddress" title="" style="text-align: left">Address:</label>
                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                      <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label1" runat="server"  Text="Relative:"></asp:Label>
                                        <asp:Label ID="lblKin" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <asp:Label id="Label3" runat="server"  Text="Contact:"> </asp:Label>
                                        <asp:Label ID="lblConct" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                
                               
                                     <div id="Div4" class="col-lg-2 text-left" runat="server" >
                                    <div class="form-group">
                                        <asp:Label id="Label5"   runat="server" Text="Relation:"></asp:Label>
                                        <asp:Label ID="lblRelation" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                    </div>
                                 </div>
           </div>
                                       <div style="height:2px; background:#B24592;"> </div>
                            </div>
            <div class="box-body">
               
               
                    <div class="col-lg-12"  >
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="row">
                                    
                                    <div class="col-lg-6 text-left" >
                                        <div class="form-group">
                                            <asp:RadioButtonList ID="rdbpkg" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbpkg_SelectedIndexChanged">
                                                <asp:ListItem Selected="True">Drug</asp:ListItem>
                                                <asp:ListItem>Package</asp:ListItem>
                                            </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    
                                             <div class="row">
                                    <div class="col-lg-12 mt-2 text-left" >
                                            <label for="txtDrugName">Search Drug Name<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtDrugName" runat="server" AutoCompleteType="None"
                                                AutoPostBack="true" TabIndex="1" CssClass="form-control" placeholder="Search Drug Name" OnTextChanged="txtDrugName_TextChanged">
                                            </asp:TextBox>
                                            <asp:AutoCompleteExtender
                                                MinimumPrefixLength="1"
                                                ServiceMethod="GetDrugsName"
                                                CompletionInterval="100"
                                                EnableCaching="false"
                                                CompletionSetCount="10"
                                                 CompletionListCssClass="AutoExtender"
                                                CompletionListItemCssClass="AutoExtenderList"
                                                 CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                TargetControlID="txtDrugName"
                                                ID="AutoCompleteExtender3"
                                                runat="server">
                                            </asp:AutoCompleteExtender>
                                          
                                        </div>
                                    </div>
                               </div>
                                 <div class="row">

                                     <div class="col-lg-4 mt-2 text-left" >
                                        <div class="form-group">
                                            <label for="txtDays">Qty <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" Text="1"  placeholder="0"
                                                onkeyPress="return numeric_only(event);" TabIndex="3"  AutoPostBack="false"></asp:TextBox>

                                        </div>
                                    </div>
                                  

                                    <div id="Div2" runat="server" visible="false">
                                         <div class="col-lg-1  text-left">
                                        <div class="form-group">
                                            <label for="txtStart">Start Date:</label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" runat="server" OnTextChanged="txtStart_TextChanged" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                         <div class="col-lg-2  text-left">
                                        <div class="form-group">
                                            <label for="txtEnd">End Date:</label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEnd" autocomplete="off" runat="server" OnTextChanged="txtEnd_TextChanged" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                         <div class="col-lg-2 text-left">
                                        <div class="form-group">
                                            <label for="txtFollowUp">Follow-Up Date<span style="color: red">*</span></label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtFollowUp" autocomplete="off" AutoPostBack="true" runat="server" class="form-control pull-right" TabIndex="5"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="txtFollowUp" ID="RequiredFieldValidator12"
                                                    runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                   </div>

                                </div>

                                <div class="row">
                                    <div class="col-lg-12 text-left">
                                        <div class="form-group">
                                            <label for="txtNote">Note</label>
                                            <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" 
                                                AutoPostBack="false" TabIndex="4" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>

                                   </div>
                                 <div class="row">
                                    <div class="col-lg-10 mt-3" >
                                         <div class="form-group"> 
                                        <asp:Button ID="btnAdd" runat="server" TabIndex="6" Text="Save" OnClick="btnAdd_Click"
                                             class="btn btn-warning" CausesValidation="False" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                            CausesValidation="False" class="btn btn-primary btnSearch"  />
                                             <asp:Button ID="btnreport" runat="server" Text="Prescription" 
                                            class="btn btn-success" CausesValidation="False" OnClick="btnreport_Click" />

                                        <asp:Button ID="btnBack" runat="server" 
                                            Text="Back"  class="btn btn-danger" CausesValidation="False" OnClick="btnBack_Click" />
                                  
                                             </div>
                                    </div>
                                     </div>

                                  
                            </div>
                            
                            
                                </div>
                     
                    </div>
               <div class="col-lg-12 text-right" runat="server" visible="false">
                        <div class="row">
                             
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                                            Width="80px" class="btn btn-primary btnSearch" CausesValidation="False" />
                             
                            </div>
                   </div>
                <div class="row">
                    <div class="col-lg-12 mt-3">
                        <div class="row">
                            <div class="table-responsive" style="width: 100%">
                                 <div runat="server" id="PackDetails" style="height:300px;overflow:scroll"> 

                                <asp:GridView ID="GvNoteIngrid" runat="server" DataKeyNames="TreatmentId,TransId" AutoGenerateColumns="False"
                                    class="table table-responsive table-sm table-bordered" Width="100%" 
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" 
                                    BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  ShowHeaderWhenEmpty="True" OnDataBound="GvNoteIngrid_DataBound" OnRowDeleting="GvNoteIngrid_RowDeleting" OnRowEditing="GvNoteIngrid_RowEditing" >
                                    <Columns>

                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" ShowEditButton="True" >                           
                                                <ItemStyle Width="70px" HorizontalAlign="Center"/> </asp:CommandField>                                        
                                        <asp:BoundField DataField="DrugName" HeaderText="DrugName" />
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" />      
                                         <asp:BoundField DataField="DrName" HeaderText="Dr Name" />
                                              <asp:BoundField DataField="FrequencyType" HeaderText="Frequency Type"  />                                
                                        <asp:BoundField DataField="Note" HeaderText="Note" />                                       
                                       
                                        <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" 
                                                        ImageUrl="~/Images0/delete.gif" OnClientClick="return ValidateDelete()" CausesValidation="false"
                                                        ToolTip="Click here to Delete this record" />
                                                    
                                                </ItemTemplate>
                                                <ItemStyle Width="70px"  HorizontalAlign="Center" />
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
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>



