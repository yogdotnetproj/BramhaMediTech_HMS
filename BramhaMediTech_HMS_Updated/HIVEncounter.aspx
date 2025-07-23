<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="HIVEncounter.aspx.cs" Inherits="HIVEncounter" %>
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
        <h1>HIV Encounter</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">HIV Encounter</li>
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
             
                 
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
               
                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblLmp"  runat="server" Text="Is the patient adult or Child?:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group form-check">
                                       
                                        <asp:RadioButtonList ID="rbladultchils" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">Adult</asp:ListItem>
                                            <asp:ListItem Value="0" >Child</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                        <div class="col-lg-4 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                         <asp:CheckBox ID="chkMTCT" Text="MTCT-Plus Patient" runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkdishusband" Text="Disclosed to husband" runat="server" />
                                    </div>
                                </div>
                         

                    </div>

                </div>

                    <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkismarried" Text="Married" runat="server" />
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                    <asp:Label ID="Label24"  runat="server" Text="Number of wives"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtnumwives" CssClass="form-control"  runat="server" placeholder="Number of wives" ></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                          <asp:Label ID="Label5"  runat="server" Text="Number of Children"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtnumberofchildren" CssClass="form-control" placeholder="Number of Children" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                         

                    </div>
                </div>

                 <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-2 text-left">
                                    <div class="form-group form-check pl-0 labelR">
                                       
                                        <asp:CheckBox ID="chkseparated" Text="Divorced/separated" runat="server" />
                                    </div>
                                </div>
                          <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                    <asp:Label ID="Label7"  runat="server" Text="Age of first child"></asp:Label>
                                    </div>
                                </div>
                        <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtageoffirstchild" CssClass="form-control"  runat="server" placeholder="Age of first child" ></asp:TextBox>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                          <asp:Label ID="Label8"  runat="server" Text="Age of last child"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtageoflastchild" CssClass="form-control" placeholder="Number of Children" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                         

                    </div>
                </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkspousedead" Text="Spouse dead" runat="server" />
                                    </div>
                                </div>
                          <div class="col-lg-5 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkSuspicion" Text="Suspicion of HIV as cause of dead" runat="server" />
                                    </div>
                                </div>
                        
                        

                    </div>
                </div>
                    <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkSuspected" Text="Sexual partner or co-wife suspected to have HIV or have died of HIV " runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-5 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                       <asp:CheckBox ID="chkspousaware" Text="Spouse aware of patients HIV status" runat="server" />
                                    </div>
                                </div>
                        

                    </div>
                </div>

                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkoutsidemarriage" Text="Patient has sex partner outside marriage" runat="server" />
                                    </div>
                                </div>
                          <div class="col-lg-5 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chkspouseoutsidemarriage" Text="Spouse suspected of sex partner outside marriage" runat="server" />
                                    </div>
                                </div>
                        <%--<div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:CheckBox ID="chksexualy6" Text="Sexually active in the last 6 month " runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-3 text-left">
                                    <div class="form-group">
                                       
                                       <asp:CheckBox ID="chkcondoms" Text="Always using condoms" runat="server" />
                                    </div>
                                </div>--%>
                        

                    </div>
                </div>
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         
                        <div class="col-lg-7 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                        <asp:CheckBox ID="chksexualy6" Text="Sexually active in the last 6 month " runat="server" />
                                    </div>
                                </div>
                         <div class="col-lg-5 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                       <asp:CheckBox ID="chkcondoms" Text="Always using condoms" runat="server" />
                                    </div>
                                </div>
                        

                    </div>
                </div>

                 
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label19"  runat="server" Font-Bold="true" Text="Number of different Partner:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtnumberofpartner" CssClass="form-control" runat="server" placeholder="Number of different Partner" ></asp:TextBox>
                                    </div>
                                </div>
                          <div class="col-lg-3 text-left">
                                    <div class="form-group form-check pl-0">
                                       
                                         <asp:CheckBox ID="chkhivtherapy" Text="Ever on HIV therapy" runat="server" />
                                    </div>
                                </div>
                        <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label22"   runat="server" Text="Comment:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-lg-4 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtComment" CssClass="form-control" placeholder="Comment" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                       
                        

                    </div>

                </div>

                    
                


                
                 
                  <div class="col-lg-12 mt-2">
                    <div class="row">
                         <div class="col-lg-12 text-center">
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
                                HIV Encounter:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Hid"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="PatientAdult" HeaderText="PType"  />
                                        
                                        <asp:BoundField DataField="MTCTPluse" HeaderText="MTCT Pluse"  />
                                        <asp:BoundField DataField="Married" HeaderText="Married"  />
                                         <asp:BoundField DataField="DiscloseToHubby" HeaderText="DiscloseTo Hubby "  />
                                         <asp:BoundField DataField="Divorced" HeaderText="Divorced"  />
                                          <asp:BoundField DataField="HIVTheraphy" HeaderText="HIV Theraphy"  />
                                          <asp:BoundField DataField="NumberofChildren" HeaderText=" Children"  />
                                          <asp:BoundField DataField="NumberOfPartner" HeaderText="NumberOfPartner"  />
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
