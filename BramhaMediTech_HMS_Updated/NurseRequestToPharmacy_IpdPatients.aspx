<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="NurseRequestToPharmacy_IpdPatients.aspx.cs" Inherits="NurseRequestToPharmacy_IpdPatients" %>

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
        <h1>Drug Req.By Nurse for IPD Patient</h1>
        <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Drug Req.By Nurse for IPD Patient</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right">Fields marked with * are compulsory</span>
                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>
             <div class="box-header with-border">
                <div class="row">
                    
                            <div class="col-lg-12 text-left">
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">PRN:</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="" style="text-align: left">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" title="" style="text-align: left">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" title="" style="text-align: left">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-lg-12 text-left">
                                <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="" style="text-align: left">Dr Name:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="" style="text-align: left">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=" Vitals Taken:"></asp:Label>
                                        <asp:Label ID="lblvtaken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                         <label for="lblIpd"   title="  " style="text-align: left"></label>
                                        <label for="lblOpd" title="" style="text-align: left"></label>
                                        
                                    </div>
                                </div>

                               
                                <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left"></label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
               
            </div>
            <div class="box-body">
               
               
                    <div class="col-lg-12"  >
                        <div class="row">
                            <div class="col-lg-6" style="width:540px">
                                <div class="row">
                                    <div class="col-lg-6 text-left" style="width:540px">
                                        <div class="form-group">
                                              <asp:RadioButtonList ID="rdbpkg" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdbpkg_SelectedIndexChanged">
                                                <asp:ListItem Selected="True">Drug</asp:ListItem>
                                                <asp:ListItem>Package</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <label for="txtDrugName">Search Drug Name<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtDrugName" runat="server" Width="540" AutoCompleteType="None"
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
                                           <%-- <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="txtDrugName" ID="RequiredFieldValidator11"
                                                runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                               </div>
                                 <div class="row">

                                    <div class="col-lg-2 text-left"  style="width:180px">
                                              <div class="form-group"> 
                                                   <label CssClass="control-label">
                                                    Dose Time
                                                  </label> 
                                                 <asp:DropDownList ID="ddlDoseTime" runat="server"  CssClass="form-control" AutoPostBack="true" Width="170px"  BackColor="#99CCFF" Font-Bold="True" Font-Size="Small" ></asp:DropDownList>
                                                   
                                                  </div>
                                            </div>
                                    <div class="col-lg-2 text-left" style="width:180px">
                                        <div class="form-group">
                                            <label for="drpfrequency" style="text-align: left">DoseQty<span style="color: red">*</span></label>
                                            <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="false"
                                                class="form-control" OnSelectedIndexChanged="drpfrequency_SelectedIndexChanged"
                                                TabIndex="2" width="170px">
                                                
                                            </asp:DropDownList>
<%--                                            <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drpfrequency" ID="RequiredFieldValidator1"
                                                runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>

                                    <div class="col-lg-1 text-left" style="width:180px">
                                        <div class="form-group">
                                            <label for="txtDays">Days <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtDays" runat="server" CssClass="form-control" Width="170" placeholder="0"
                                                onkeyPress="return numeric_only(event);" TabIndex="3" AutoPostBack="true"
                                                OnTextChanged="txtDays_TextChanged"></asp:TextBox>

                                        </div>
                                    </div>
                                  

                                    <div id="Div2" runat="server" visible="false">
                                         <div class="col-lg-2  text-left">
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
                                    <div class="col-lg-6 text-left">
                                        <div class="form-group">
                                            <label for="txtNote">Note</label>
                                            <asp:TextBox ID="txtNote" runat="server" Width="540px" TextMode="MultiLine" Rows="4"
                                                AutoPostBack="false" TabIndex="4" CssClass="form-control">
                                            </asp:TextBox>
                                        </div>
                                    </div>

                                   </div>
                                 <div class="row">
                                    <div class="col-lg-6">
                                         <div class="form-group"> 
                                        <asp:Button ID="btnAdd" runat="server" TabIndex="6" Text="Add" OnClick="btnAdd_Click"
                                            Width="80px" class="btn btn-primary btnSearch" CausesValidation="False" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                            CausesValidation="False" class="btn btn-primary btnSearch" Width="80px" />
                                             </div>
                                    </div>
                                     </div>

                                  
                            </div>
                            <div class="col-lg-6" style="width:500px">
                               
                                              <div class="form-group">  
                                    
                                                 <div runat="server" id="Div3" style="height:250px; width:540px; overflow:scroll"   >                                          
                                                         <div class="table-responsive" style="width:100%" >
                                                                <asp:GridView ID="GvNoteIngrid" DataKeyNames="TreatmentId,TransId" runat="server" AutoGenerateColumns="false"
                                                class="table table-responsive table-lg table-bordered" Width="100%" 
                                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3"
                                                BackColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  ShowHeaderWhenEmpty="True"  OnRowCommand="GvNoteIngrid_RowCommand" OnDataBound="GvNoteIngrid_DataBound" OnRowDeleting="GvNoteIngrid_RowDeleting" OnRowEditing="GvNoteIngrid_RowEditing">
                                                <Columns>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" ShowEditButton="True" >                           
                                                <ItemStyle Width="70px" HorizontalAlign="Center"/> </asp:CommandField>
                                                    <asp:BoundField DataField="updatedon" ItemStyle-Width="20%" HeaderText="Date"  />
                                                    
                                                    <asp:BoundField DataField="DrName" ItemStyle-Width="30%" HeaderText="Doctor"  />
                                                    <asp:BoundField DataField="DrugName" ItemStyle-Width="50%" HeaderText="Drugs"  />
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
                                                    <asp:Button ID="btnnotedetails" Visible="false" runat="server" Text="Details" />
                                               </div>
                                 
                                             </div>
                            
                                </div>
                     
                    </div>
               <div class="col-lg-12 text-right">
                        <div class="row">
                             
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                                            Width="80px" class="btn btn-primary btnSearch" CausesValidation="False" />
                             <asp:Button ID="btnreport" runat="server" Text="Prescription" 
                                            Width="112px" class="btn btn-primary btnSearch" CausesValidation="False" OnClick="btnreport_Click" />

                                        <asp:Button ID="btnBack" runat="server" OnClientClick="window.history.back()"
                                            Text="Back" Width="80px" class="btn btn-primary btnSearch" CausesValidation="False" />
                                  
                            </div>
                   </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div runat="server" id="Div4" style="height:450px; width:100%; overflow:scroll"   >  
                            <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvTempTable" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Id"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvTempTable_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvTempTable_RowCommand" OnRowEditing="gvTempTable_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="1000" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvTempTable_PageIndexChanging">
                                    <Columns>

                                        <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                        <asp:BoundField DataField="Id" HeaderText="Sr No" ItemStyle-Width="50" Visible="False" />
                                        <asp:BoundField DataField="DrugName" HeaderText="DrugName" />
                                         <asp:BoundField DataField="Dose" HeaderText="Dose" />
                                        <asp:BoundField DataField="Frequency" HeaderText="Frequency" ItemStyle-Width="150" />
                                        <asp:BoundField DataField="Days" HeaderText="Days" ItemStyle-Width="50" />
                                       <%-- <asp:BoundField DataField="StartDate" HeaderText="StartDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                       --%> <asp:BoundField DataField="Note" HeaderText="Note" />
                                         <asp:BoundField DataField="DoseTimeId" Visible="true" />
                                         <asp:BoundField DataField="DoseId" Visible="true" />
                                         <asp:BoundField DataField="ItemId" Visible="true" />
                                        <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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

