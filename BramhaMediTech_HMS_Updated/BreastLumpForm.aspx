<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="BreastLumpForm.aspx.cs" Inherits="BreastLumpForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: white;
            width: auto;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no .modalPopup .cancel {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup .cancel {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }
    </style> 
     <script src="Scripts/moment.js"></script>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script src="Scripts/jquery.auto-complete-1.0.7.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Breast Lump Examination</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Breast Lump Examination</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
           <!-- <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>-->
             <div class="box-header with-border">
                 
                <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
                 <div class="col-sm-12">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="txtHeight"  runat="server" Text="HCG:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtHCG" CssClass="form-control" placeholder="HCG" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="txtBMI"   runat="server" Text="Leukocytes:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtLeukocytes" CssClass="form-control" placeholder="Leukocytes" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="TextBox2"   runat="server" Text="Nitrite:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtNitrite" CssClass="form-control" placeholder="Nitrite" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                    <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label15"  runat="server" Text="Protein:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtProtein" CssClass="form-control" placeholder="Protein" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label16"   runat="server" Text="Glucose:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtGlucose" CssClass="form-control" placeholder="Glucose" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label17"   runat="server" Text="Blood:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBlood" CssClass="form-control" placeholder="Blood" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label18"  runat="server" Text="PH:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtPH" CssClass="form-control" placeholder="PH" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label19"   runat="server" Text="Specific Gravity:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtSpecificGravity" CssClass="form-control" placeholder="Specific Gravity" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label20"   runat="server" Text="Ketone:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtKetone" CssClass="form-control" placeholder="Ketone" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label21"  runat="server" Text="Urobilinogen:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtUrobilinogen" CssClass="form-control"  placeholder="Urobilinogen" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label22"   runat="server" Text="Biliruben:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBiliruben" CssClass="form-control" placeholder="Biliruben" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                       
                         <div class="col-sm-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtComment"  placeholder="Comment" CssClass="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lbldsmoke"   runat="server" Text="Do u Smoke?"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rblsmoking" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtSmokeRemark" CssClass="form-control" placeholder="Smoke Remark" runat="server" ></asp:TextBox>

                                    </div>
                                </div>
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="LblsmQu" runat="server" Text="DateQuite(if applicable)"></asp:Label>
                                    </div>
                                </div>

                        <div class="col-sm-3  text-left">
                                        <div class="form-group">
                                           <%-- <label for="txtStart">Start Date:</label>--%>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtStart" runat="server" CssClass="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                     </div>
                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label1"   runat="server" Text="HPI:"></asp:Label>
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-10 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txthpi"  placeholder="Comment" CssClass="form-control" runat="server"  ></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-6 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkleftBrest" Text="Left Breast" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-6 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkrightBrest" Text="Right Breast" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        
                                         <asp:TextBox ID="txtLeftBreastComp" CssClass="form-control"  runat="server" placeholder="Left Breast Complant"></asp:TextBox>
                                       
                                    </div>
                                </div>
                       <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        
                                         <asp:TextBox ID="txtLeftBreastDuration" CssClass="form-control"  runat="server" placeholder="Left Breast Duration"></asp:TextBox>
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:TextBox ID="txtRightBreastComp" CssClass="form-control"  runat="server" placeholder="Right Breast Complant"></asp:TextBox>

                                    </div>
                                </div>
                     <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        
                                         <asp:TextBox ID="txtRightBreastDuration" CssClass="form-control"  runat="server" placeholder="Right Breast Duration"></asp:TextBox>
                                       
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-6 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="lblll" Text="Consistency" Font-Bold="true" runat="server" />
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-6 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label23" Text="Consistency" Font-Bold="true" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkLsoft" Text="Soft/Cystic" runat="server" />
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtLSoft" CssClass="form-control" placeholder="SoftComment" runat="server" ></asp:TextBox>

                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkRsoft" Text="Soft/Cystic" runat="server" />
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtRSoft" CssClass="form-control" placeholder="SoftComment" runat="server" ></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="ChkLFirm" Text="Firm" runat="server" />
                                    </div>
                                </div> 
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtLFirm" CssClass="form-control" placeholder="Firm" runat="server" ></asp:TextBox>

                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="ChkRFirm" Text="Firm" runat="server" />
                                    </div>
                                </div>                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtRFirm" CssClass="form-control" placeholder="Firm" runat="server" ></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkLMobile" Text="Mobile" runat="server" />
                                    </div>
                                </div> 
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtlMobile" CssClass="form-control" placeholder="Mobile" runat="server" ></asp:TextBox>

                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkRMobile" Text="Mobile" runat="server" />
                                    </div>
                                </div>                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtRMobile" CssClass="form-control" placeholder="Mobile" runat="server" ></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkPreLMenopausal" Text="Pre Menopausal" runat="server" />
                                    </div>
                                </div> 
                        <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkPostLMenopausal" Text="Post Menopausal" runat="server" />

                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                       <asp:CheckBox ID="chkPreRMenopausal" Text="Pre Menopausal" runat="server" />
                                    </div>
                                </div>                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:CheckBox ID="chkPostRMenopausal" Text="Post Menopausal" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>

                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="LblS" Text="Assessment:" runat="server" />
                                    </div>
                                </div> 
                        </div>
                     </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                        <asp:CheckBox ID="chkFibrocystic" Text="Fibrocystic" runat="server" />
                                    </div>
                                </div> 
                        <div class="col-sm-4 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkClinicallyFeels" Text="Clinically feels cystic benign" runat="server" />

                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                       <asp:CheckBox ID="chkClinicallySuspic" Text="Clinically Suspicious" runat="server" />
                                    </div>
                                </div>                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox CssClass="form-control"  ID="txtremark" Text="" placeholder="Comment" runat="server" />

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                 
                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" />
                                         <asp:Button ID="BtnBirthRegister" runat="server" class="btn btn-primary btnSearch" Text="+" />
                                    </div>
                                </div>
                        
                        
                        </div>
                     </div>
            </div>
            
          
        </div>

    </section>
      <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="CheifPanel" TargetControlID="BtnBirthRegister"
                CancelControlID="btnCloseM1" BackgroundCssClass="modalBackground ">
            </asp:ModalPopupExtender>

            <asp:Panel ID="CheifPanel" runat="server" CssClass="modalPopup" align="center" Style="display: none" CancelControlID="btnCloseM1">
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="header">
                                Breast Lump Examination  :
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="BLFId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="DouSmoke" HeaderText="DouSmoke "  />
                                        
                                        <asp:BoundField DataField="LeftBrestComplant" HeaderText="LeftBrest Complant"  />
                                         <asp:BoundField DataField="RightBrestComplant" HeaderText="RightBrest Complant"  />
                                       
                                        
                                          
                                         <asp:BoundField DataField="CreatedOn" HeaderText="Created On"  />
                                       <%-- <asp:BoundField DataField="chiefcomplaints" ItemStyle-Width="80%" HeaderText="Complaints"  />--%>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCloseM1" runat="server" Text="Close" />
            </asp:Panel>
</asp:Content>

