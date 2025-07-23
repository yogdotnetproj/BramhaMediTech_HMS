<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="BirthRegister.aspx.cs" Inherits="BirthRegister" %>

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
        <h1>Birth Register</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Birth Register</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                <asp:HiddenField ID="txtTreatId" runat="server" />
            </div>
             <div class="box-header with-border">
                <div class="row">
                    
                            <div class="col-sm-12 text-left">
                                <div class="col-sm-4 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName">Name:</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="">PRN:</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblIpd"   title="">IPD No:</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" title="">OPD No:</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                              
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" title="">Mobile No:</label>
                                        <asp:Label ID="lblMobileNo" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-lg-12 text-left mt-3">
                                <div class="col-sm-4 text-left">
                                    <div class="form-group">
                                        <label for="lbldName" title="">Dr Name:</label>
                                        <asp:Label ID="lbldrname" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPrnNo" title="">Age:</label>
                                        <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="Red" Text=" Vitals Taken:"></asp:Label>
                                        <asp:Label ID="lblvtaken" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                         <label for="lblIpd"   title=""></label>
                                        <label for="lblOpd" title=""></label>
                                        
                                    </div>
                                </div>

                               
                                <div class="col-sm-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId"></label>
                                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-lg-12 text-left">
                                    <div class="form-group">
                                         <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                                        </div>
                             </div>
                        </div>
                      </div>
                 
               
                 <div class="col-lg-12">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="lblLmp"  runat="server" Text="Baby Name:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        
                                       <asp:TextBox ID="txtBabyName"   runat="server" placeholder="Baby Name" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label1"  runat="server" Text="Mother Name:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtMotherName"   runat="server" placeholder="Mother Name" ></asp:TextBox>
                                    </div>
                                </div>   
                    </div>

                </div>
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label2"  runat="server" Text="Father Name:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        
                                       <asp:TextBox ID="txtFatherName"   runat="server" placeholder="Father Name" ></asp:TextBox>
                                    </div>
                                </div>
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label9"  runat="server" Text="Birth Time:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtBirthTime"   runat="server" placeholder="Birth Time" ></asp:TextBox>
                                    </div>
                                </div>   
                    </div>

                </div>
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label10"  runat="server" Text="Birth date:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-3 text-left">
                                    <div class="form-group">                                        
                                      
                                        <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtBirthDate" runat="server" placeholder="Birth Date" class="form-control pull-right"></asp:TextBox>
                                                <div class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                            </div>
                                    </div>
                                </div>
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                         <asp:Label ID="Label11"  runat="server" Text="Sex:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group form-check">
                                       
                                       <asp:RadioButtonList ID="rblGenderBaby" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1" Selected="True">Male</asp:ListItem>
                                            <asp:ListItem  Value="2" >Femail</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>   
                    </div>

                </div>
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label5"  runat="server" Text="Mode of Delivery:"></asp:Label>
                                    </div>
                                </div>
                          <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                        
                                       <asp:DropDownList ID="ddlModeofDelivery" runat="server" CssClass="form-control form-select">
                                              <asp:ListItem Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Cesarean</asp:ListItem>
                                            <asp:ListItem Value="3">ForceFully</asp:ListItem>
                                            <asp:ListItem Value="4">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                        <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label7"  runat="server" Text="Wait in Gram:"></asp:Label>
                                    </div>
                                </div>
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:TextBox ID="txtwaitingram"   runat="server" placeholder="Wait in Gram" ></asp:TextBox>
                                        
                                    </div>
                                </div>   
                    </div>

                </div>

                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-sm-3 text-left">
                                    <div class="form-group">
                                       
                                        <asp:Label ID="Label14"  runat="server" Text="Comment:"></asp:Label>
                                    </div>
                                </div>
                          
                        <div class="col-sm-9 text-left">
                                    <div class="form-group">
                                       
                                          <asp:TextBox ID="txtComment" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                        
                    </div>
                </div>
                        
                 
                  <div class="col-lg-12">
                    <div class="row">
                         <div class="col-sm-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary btnSearch" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary btnSearch" />
                                          <asp:Button ID="BtnBirthRegister" runat="server" CssClass="btn btn-primary btnSearch" Text="+" />
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
                                Birth Register:
                            </div>
                            <div class="body">
                                <asp:GridView ID="gvdChief" runat="server" AutoGenerateColumns="false"
                                    class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Bid"
                                    HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvdChief_RowDeleting"
                                    AllowPaging="True" BackColor="White" OnRowCommand="gvdChief_RowCommand" OnRowEditing="gvdChief_RowEditing"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="15" ShowHeaderWhenEmpty="True"
                                    OnPageIndexChanging="gvdChief_PageIndexChanging">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="BabyName" HeaderText="Baby Name"  />
                                         <asp:BoundField DataField="MotherName" HeaderText="Mother Name"  />
                                        <asp:BoundField DataField="BirthDate" HeaderText="Birth Date"  />
                                         <asp:BoundField DataField="BirthTime" HeaderText="Birth Time"  />
                                          <asp:BoundField DataField="WaitInGram" HeaderText="WaitIn Gram"  />
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

