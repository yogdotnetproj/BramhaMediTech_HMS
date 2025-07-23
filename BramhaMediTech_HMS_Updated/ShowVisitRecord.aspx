<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="ShowVisitRecord.aspx.cs" Inherits="ShowVisitRecord" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
     <section class="content-header d-flex">
        <h1>Visit Record</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Visit Record</li>
                    </ol>
    </section>
             <section class="content">
        <div id="Div1" class="box" runat="server">
            <div class="box-header with-border">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
             <div class="box-body">
                
                      


                <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <div class="form-group">
                            <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>   
                 <div class="col-lg-12 mt-3">
                                            <div class="row"> 
                                                <div class="col-sm-12">
                                                      <div class="table-responsive" style="width:100%">             

                            <asp:GridView ID="gvAddMEdicalRecord" runat="server" AllowPaging="True" class="table table-responsive table-sm table-bordered" Width="100%"  
                            HeaderStyle-ForeColor="Black" DataKeyNames="MedicalId"  AutoGenerateColumns="False" 
                         
                            EmptyDataText="No Records to Display" 
                            OnPageIndexChanging="gvAddMEdicalRecord_PageIndexChanging" 
                           
                            PageSize="25" ShowHeaderWhenEmpty="True" TabIndex="4">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                            <Columns>
                               
                            
                                <asp:BoundField DataField="Patregid" HeaderText="Patregid" 
                                    ItemStyle-HorizontalAlign="Left">
                               
                                </asp:BoundField>
                               
                                <asp:BoundField DataField="PatientType" HeaderText="Patient Type" />
                                <asp:BoundField DataField="AdmissionDate" HeaderText="Admission Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />

                                <asp:BoundField DataField="DischargeDate" HeaderText="Discharge Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                                <asp:BoundField DataField="DrName" HeaderText="Dr Name" />

                                 <asp:BoundField DataField="DocumentNumber" HeaderText="Document Number" />
                                <asp:BoundField DataField="Diagnostics" HeaderText="Diagnosis" />
                                
                                <asp:TemplateField HeaderText="ViewPres" >
                            <ItemTemplate>
<asp:HyperLink ID="Hyp_viewPres" runat="server" onclientclick="target = '_blank';"  NavigateUrl='<%# Eval("DocumentFilePath") %>'>View Pres</asp:HyperLink>
                            </ItemTemplate>
                            </asp:TemplateField>

                               
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#38C8DD" Font-Bold="True" ForeColor="White" />
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

</section>
    <script language="javascript" type="text/javascript">
        function OpenReport() {

            window.open("Reports.aspx");
        }
               </script>
             </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

