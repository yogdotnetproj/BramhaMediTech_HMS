<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="AntenatalCare.aspx.cs" Inherits="AntenatalCare" %>

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
        <h1>Antenatal Care</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Antenatal Care</li>
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
               
                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblLmp"  runat="server" Text="LMP Date:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <%--<asp:TextBox ID="txtLPMDate"  placeholder="LMP Date" runat="server" Text=""></asp:TextBox>--%>
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtLPMDate" runat="server"  placeholder="LMP Date" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            </div>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblestdate"   runat="server" Text="Est.Delivery Date:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <%--<asp:TextBox ID="txtEstimateDelDate"  placeholder="Est.Delivery Date" runat="server" Text=""></asp:TextBox>--%>
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtEstimateDelDate" runat="server"  placeholder="Est.Delivery Date" class="form-control pull-right"></asp:TextBox>
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            </div>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblfmh"   runat="server" Text="Fundel Height:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtFundelHeight" CssClass="form-control" placeholder="Fundel Height" runat="server" Text=""></asp:TextBox><asp:Label ID="Label23"   runat="server" Text="(Cm)"></asp:Label>
                                    </div>
                                </div>

                    </div>

                </div>

                    <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label15"  runat="server" Text="Gestation:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtGestation" CssClass="form-control" placeholder="Gestation" runat="server" Text=""></asp:TextBox><asp:Label ID="Label24"  runat="server" Text="Wks"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label16"   runat="server" Text="Foetal Movement:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:RadioButtonList ID="rblFoetalMovement" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label17"   runat="server" Text="Parity"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtParity" CssClass="form-control" placeholder="Parity" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label18"  runat="server" Text="Featel heart Beat:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtFetalHearthBeat" CssClass="form-control" placeholder="Featel heart Beat" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="ChkTT1" Text="TT1" runat="server" />
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                       <asp:CheckBox ID="ChkTT2" Text="TT2" runat="server" />
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkIPT1" Text="IPT1" runat="server" />
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                       <asp:CheckBox ID="chkIPT2" Text="IPT2" runat="server" />
                                    </div>
                                </div>
                        

                    </div>

                </div>



                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkISHiv" Text="HIV" runat="server" />
                                    </div>
                                </div>
                          <div class="col-sm-1 p-0">
                                    <div class="form-group form-check pl-0">
                                       
                                       <asp:CheckBox ID="chkHB" Text="HB" runat="server" />
                                    </div>
                                </div>
                        <div class="col-sm-2 p-0">
                                    <div class="form-group form-check">
                                       
                                        <asp:CheckBox ID="ChkBloodGroup" Text="Blood Group" runat="server" />
                                    </div>
                                </div>
                         <div class="col-sm-2 p-0">
                                    <div class="form-group form-check">
                                       
                                       <asp:CheckBox ID="ChkSyphilis" Text="Syphilis Test" runat="server" />
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group form-check">
                                       
                                         <asp:CheckBox ID="chkurinalysis" Text="Urinalysis" runat="server" />
                                    </div>
                                </div>
                         <div class="col-sm-3 p-0">
                                    <div class="form-group form-check">
                                       
                                       <asp:CheckBox ID="ChkUltraScoundScan" Text="Ultrasound Scan" runat="server" />
                                    </div>
                                </div>
                        

                    </div>

                </div>



                 <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label19"  runat="server" Font-Bold="true" Text="Growth Parameters:"></asp:Label>
                                    </div>
                                </div>
                        </div>
                  <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label21"  runat="server" Text="BPD:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBPD" CssClass="form-control" placeholder="BPD" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label22"   runat="server" Text="FL:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtFL" CssClass="form-control" placeholder="FL" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                       
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label20"   runat="server" Text="HL:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtHL" CssClass="form-control" placeholder="HL" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>

                    </div>

                </div>

                     <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label25"  runat="server" Text="HC:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtHC" CssClass="form-control" placeholder="HC" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label26"   runat="server" Text="AC:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtAC" CssClass="form-control" placeholder="AC" runat="server" Text=""></asp:TextBox>
                                    </div>
                                </div>
                       
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label27"   runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                       
                                      <asp:Label ID="Label28"   runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                    </div>

                </div>
                     <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label1"   runat="server" Font-Bold="true" Text="Estimated foetal size:"></asp:Label>
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                           <asp:TextBox ID="txtestimatelfoetalsize" CssClass="form-control"  placeholder="Estimated foetal size"  runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label2"   runat="server" Font-Bold="true" Text="Estimated foetal weight:"></asp:Label>
                                       
                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                         <asp:TextBox ID="txtestimatelfoetalweight" CssClass="form-control" placeholder="Estimated foetal weight"  runat="server" Text=""></asp:TextBox>
                                       
                                    </div>
                                </div>

                        
                        </div>
                     </div>

                      <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label29"   runat="server" Font-Bold="true" Text="Complant:"></asp:Label>
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-10 text-left">
                                    <div class="form-group">
                                       
                                           <asp:TextBox ID="txtCompalnt"  placeholder="Complant" CssClass="form-control" runat="server" Text=""></asp:TextBox>

                                    </div>
                                </div>

                        
                        </div>
                     </div>
                      <div class="col-sm-12 mt-2">
                    <div class="row">
                         <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <asp:Label ID="Label30"   runat="server" Font-Bold="true" Text="Conclusion:"></asp:Label>
                                       
                                    </div>
                                </div>
                        
                        
                        <div class="col-sm-10 text-left">
                                    <div class="form-group">
                                       
                                           <asp:TextBox ID="txtConclusion"  placeholder="Conclusion" CssClass="form-control" runat="server" Text="" ></asp:TextBox>

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
                                Antenatal care(ANC) :
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="ANCId"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="LMPDate" HeaderText="LMP Date "  />
                                        
                                        <asp:BoundField DataField="EstDeliveryDate" HeaderText="Est Delivery Date"  />
                                       
                                         <asp:BoundField DataField="FotealMovement" HeaderText="Foteal Movement "  />
                                         <asp:BoundField DataField="FeatelHEarthBeat" HeaderText="Featel Hearth Beat"  />
                                          <asp:BoundField DataField="TT1" HeaderText="TT1"  />
                                          <asp:BoundField DataField="TT2" HeaderText="TT2"  />
                                          <asp:BoundField DataField="IPT1" HeaderText="IPT1"  />
                                         <asp:BoundField DataField="IPT2" HeaderText="IPT2"  />
                                         <asp:BoundField DataField="UltrasoundScan" HeaderText="UltrasoundScan"  />
                                          <asp:BoundField DataField="Urinalysis" HeaderText="Urinalysis"  />
                                         <asp:BoundField DataField="HIVTest" HeaderText="HIVTest"  />
                                        <asp:BoundField DataField="SyphilisTest" HeaderText="SyphilisTest"  />
                                          <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group Know"  />
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

