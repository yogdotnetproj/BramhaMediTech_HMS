<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="PatientHistoryForm.aspx.cs" Inherits="PatientHistoryForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
       <style type="text/css">
      input.larger {
        width: 80px;
        height: 80px;
      }
    </style>
    <style type="text/css">
  .BigCheckBox input {width:20px; height:20px;}
</style>
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
    <script type="text/javascript">

        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
        </script>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header d-flex">
        <h1>Patient History</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Patient History</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
              
            
             <div class="box-body">

                

               
                <div class="col-lg-12 mt-3">
                <div class="row">
                    <div class="col-lg-12 mt-3 text-left">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>               
                   <div class="col-lg-12 mt-3" runat="server" visible="false">
                                 <div class="row"> 
                                       <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart">Case No:</label>     
                                                            </div>
                                           </div>
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txtcaseno" CssClass="form-control"  placeholder="Enter Case No"  />
                                                            </div>
                                           </div>
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart">Dr Name:</label>     
                                                            </div>
                                           </div>
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txtdrname" CssClass="form-control"  placeholder="Enter Dr Name"  />
                                                            </div>
                                           </div>
                                     </div>
                       </div>
                  <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0 wLabel">Medical History:</label> 
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkMedicalHistory" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                              <asp:TextBox runat="server" ID="txtmedicalhis" CssClass="form-control" TextMode="MultiLine"  placeholder="Enter Medical History"  />

                                                            </div>
                                         </div>
                                     </div>
                       </div>
                 <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                             <label for="txttimestart" class="mr-0 wLabel">Medication:</label> 
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkmedication" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-8 text-left" >
                                                        <div class="form-group">  
                                                              <asp:TextBox runat="server" ID="txtmedication" CssClass="form-control" TextMode="MultiLine"  placeholder="Enter Medication"  />

                                                            </div>
                                         </div>
                                     </div>
                       </div>
                 <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0 wLabel">Surgical History:</label>   
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chksurghis" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-8 text-left"  >
                                                        <div class="form-group">  
                                                              <asp:TextBox runat="server" ID="txtsurgicalhistory"  TextMode="MultiLine" class="form-control"  placeholder="Enter Surgical History"  />

                                                            </div>
                                         </div>
                                     </div>
                       </div>
                 <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0 wLabel">Gynae History:</label>
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkGynae" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                              <asp:TextBox runat="server" ID="txtGynaeHis"  TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Gynae History"  />

                                                            </div>
                                         </div>
                                     </div>
                       </div>

                        <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0 wLabel">Allergies History:</label>     
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkallergies" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                              <asp:TextBox runat="server" ID="txtallergiesHistory" TextMode="MultiLine" class="form-control"  placeholder="Enter Allergy History"  />

                                                            </div>
                                         </div>
                                     </div>
                       </div>
                  <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0 wLabel">Smoking:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkSmoking" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txtsmokeduration"  CssClass="form-control"  placeholder=" Duration"  />
                                                            </div>
                                           </div>
                                       <div class="col-sm-1 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txsmoketqty"  CssClass="form-control"  placeholder=" Qty"  />
                                                            </div>
                                           </div>
                                          <div class="col-sm-1 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart">Alcohol:</label>     
                                                            </div>
                                           </div>
                                     <div class="col-sm-1 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkalcohol" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txtalcoholdura"  CssClass="form-control"  placeholder=" Duration"  />
                                                            </div>
                                           </div>
                                       <div class="col-sm-1 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" ID="txtalcoholqty"  CssClass="form-control"  placeholder=" Qty"  />
                                                            </div>
                                           </div>
                                     </div>
                       </div>
                  <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0 wLabel">Family History:</label>
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkfamilyHis" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-6 text-left">
                                                        <div class="form-group">  
                                                              <asp:TextBox runat="server" ID="txtfamilyHistory" TextMode="MultiLine" class="form-control"  placeholder="Enter Family History"  />

                                                            </div>
                                         </div>
                                     </div>
                       </div>

                
                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-warning" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-primary btnSearch" OnClick="btnReport_Click"  />                                       
                  
                    </div>
                </div>
                <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:350px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="PhId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                   <asp:BoundField DataField="CreatedOn" HeaderText="Date"  DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                    <asp:BoundField DataField="CreatedBy" HeaderText="Enter by" />
                                    <asp:BoundField DataField="MedicalHis" HeaderText="Medical His" />
                                    <asp:BoundField DataField="MedicationHistory"  HeaderText="Medication History" />
                                    <asp:BoundField DataField="SurgicalHistory"  HeaderText="Surgical History" />
                                    <asp:BoundField DataField="AllergyHistory"  HeaderText="Allergy History" />
                                    <asp:BoundField DataField="FamilyHistory"  HeaderText="Family History" />
                                    <asp:BoundField DataField="SmokingDuration"  HeaderText="Smoking Duration" />
                                    <asp:BoundField DataField="SmokingQty"  HeaderText="Smoking Qty" />
                                    <asp:BoundField DataField="AlcoDuration"  HeaderText="AlcoDuration" />
                                     <asp:BoundField DataField="AlcoQty"  HeaderText="Alco Qty" />
                                       <asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="UpdatedBy" HeaderText="Updated by" />
                                <asp:ButtonField CommandName="Delete" Text="Delete" Visible="false" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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
                     
            
</section>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
</asp:Content>

