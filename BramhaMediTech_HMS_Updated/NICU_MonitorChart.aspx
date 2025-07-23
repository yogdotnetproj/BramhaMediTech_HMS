<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="NICU_MonitorChart.aspx.cs" Inherits="NICU_MonitorChart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
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
        <h1>NICU Monitoring Chart</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">NICU Monitoring Chart</li>
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
             <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Date</strong>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                       <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtDate" runat="server"   CssClass="form-control" 
                                                             AutoPostBack="True" ></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                   
                        
                                                        </div>
                                        
                                    </div>
                                </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong>  Birth Weight</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtBirthWeight" placeholder="" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                         <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                       
                                      <strong> Today's Wt.</strong>
                                        
                                    </div>
                                </div>
                        <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtTodaysWeight" placeholder="" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                        </div>
                     </div>


                    <div class="col-lg-12 mt-2">
                    <div class="row">
                        <div class="col-lg-12 text-left">
                             <div class="form-group">
                                                                  <asp:gridview ID="GvHairLaser" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Time" >

            <ItemTemplate>

                <asp:TextBox ID="txtTime" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="Temp" >

            <ItemTemplate>

                <asp:TextBox ID="txtTemp" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="HR" >

            <ItemTemplate>

                <asp:TextBox ID="txtHR" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="RR" >
            <ItemTemplate>
                <asp:TextBox ID="txtRR" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="BP" >
            <ItemTemplate>
                <asp:TextBox ID="txtBP" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="BSL" >
            <ItemTemplate>
                <asp:TextBox ID="txtBSL" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="SpO2" >
            <ItemTemplate>
                <asp:TextBox ID="txtSpO2" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="AG" >
            <ItemTemplate>
                <asp:TextBox ID="txtAG" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="IntakePO" >
            <ItemTemplate>
                <asp:TextBox ID="txtIntakePO" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Intake IV" >
            <ItemTemplate>
                <asp:TextBox ID="txtIntakeIV" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Urine" >
            <ItemTemplate>
                <asp:TextBox ID="txtUrine" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Stool" >
            <ItemTemplate>
                <asp:TextBox ID="txtStool" CssClass="form-control" runat="server"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
             <asp:TemplateField HeaderText="Remark" >

            <ItemTemplate>

                <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
                  <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />

            </FooterTemplate>
        </asp:TemplateField>

             
           

        </Columns>

</asp:gridview>

                                 </div>
                            </div>
                         
                        </div>
                                  </div>
                             
                  <div class="col-lg-12 mt-3">
                <div class="row">
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                            Total Intake
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txttotalIntake" placeholder="" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                           ml/day
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          Fluid by Medication
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          <asp:TextBox ID="txtfluidbymedication" placeholder="" CssClass="form-control"   runat="server" />
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          ml
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          Oral Feeding
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          <asp:TextBox ID="txtoralFeeding" placeholder="" CssClass="form-control"   runat="server" />
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                        <div class="form-group">
                          ml
                            </div>
                        </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                          IV Fluid
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                        <div class="form-group">
                          <asp:TextBox ID="txtIVFluid" placeholder="" CssClass="form-control"   runat="server" />
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                        <div class="form-group">
                          ml
                            </div>
                        </div>
                    </div>
                      </div>

                   <div class="col-lg-12 mt-2">
                <div class="row">
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                         <strong> Output:</strong> 
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                        <div class="form-group">
                         Urine
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtUrine" placeholder="" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                    <div class="col-lg-1 text-left">
                        <div class="form-group">
                         Stool
                            </div>
                        </div>
                     <div class="col-lg-1 text-left">
                                    <div class="form-group">
                                      <asp:TextBox ID="txtstool" placeholder="" CssClass="form-control"   runat="server" />
                                        </div>
                              </div>
                    </div>
                       </div>


                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server"  Text="Save" class="btn btn-success btnSearch" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary btnSearch" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="btn btn-warning btnSearch" OnClick="btnReport_Click"  />                                       
                  
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


