<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="TwoHourlyRepositioningTurningChart.aspx.cs" Inherits="TwoHourlyRepositioningTurningChart" %>

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
     <section class="content-header d-flex">
        <h1>Two Hourly Repositioning and Turning Chart</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Two Hourly Repositioning and Turning Chart</li>
                    </ol>
    </section>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnReport" />
              
        </Triggers>
        <ContentTemplate>

        
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
                <div class="col-lg-12" runat="server" >
                                 <div class="row"> 
                                     
                                       <div class="col-lg-3" >
                                                        <div class="form-group">  
                                                                                       
                                                             
                                                     <asp:CheckBox ID="ChkPressure" runat="server"   Text="Pressure Relieving Mattress" ></asp:CheckBox> 
                    
                                                            
                                                    
                                                        </div>
                                                    </div>
                                      <div class="col-lg-1" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkCushion" runat="server"   Text="Cushion" ></asp:CheckBox> 
                                                        </div>
                                                    </div>
                                     <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                     <asp:CheckBox ID="ChkHeelPads" runat="server"   Text="Heel Pads" ></asp:CheckBox> 
                                                        </div>
                                                    </div>
                                      <div class="col-lg-2" >
                                                        <div class="form-group">  
                                                   Date and Time Initiated
                                                        </div>
                                                    </div>
                                       <div class="col-lg-2 text-left" >
                                                        <div class="form-group">  
                                                                                
                                                             <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">                                                            
                                                          <asp:TextBox ID="txtRegistrationDate" runat="server"   class="form-control" TabIndex="12"  AutoPostBack="True"></asp:TextBox>
                                                             
                                                                 <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>                                                     
                        
                                                        </div>
                                                            </div>
                                           </div>   
                                         <div class="col-lg-2 text-left">
                                                    <div class="form-group">       
                                                         <asp:TextBox ID="txtTime" runat="server"  CssClass="form-control" 
                                                     Font-Bold="True"></asp:TextBox>  
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

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

                <asp:TextBox ID="txtDate" CssClass="form-control" Text='<%# Eval("Date") %>' runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Time" >

            <ItemTemplate>

                <asp:TextBox ID="txtTime" CssClass="form-control" Text='<%# Eval("Time") %>' runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Left Side" >

            <ItemTemplate>

                <asp:TextBox ID="txtLeftSide" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Right Side" >

            <ItemTemplate>

                <asp:TextBox ID="txtRightSide" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Supine" >

            <ItemTemplate>

                <asp:TextBox ID="txtSupine" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
              <asp:TemplateField HeaderText="30 or 40 Head Tilt" >

            <ItemTemplate>

                <asp:TextBox ID="txtHeadTilt" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="In Chair" >

            <ItemTemplate>

                <asp:TextBox ID="txtInChair" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Skin Integrity Observed" >

            <ItemTemplate>

                <asp:TextBox ID="txtSkinIntegrityObserved" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Comments" >
            <ItemTemplate>
                <asp:TextBox ID="txtComments" CssClass="form-control" runat="server"></asp:TextBox>
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
                 
                        <div id="Div2" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     <div class="col-lg-3" >
                                         <div class="form-group">  
                                         <strong>   Discussed With Patient:</strong> 
                                          </div>

                                     </div>

                                       <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                     <asp:CheckBox ID="ChkYes" runat="server"   Text="Yes" ></asp:CheckBox> 
                    
                                                        </div>
                                                    </div>
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                     <asp:CheckBox ID="ChkNo" runat="server"   Text="No" ></asp:CheckBox> 
                    
                                                        </div>
                                                    </div>
                                     <div class="col-lg-2" >
                                                        <div class="form-group"> 
                                                   <strong>  If No,Why?</strong>
                    
                                                        </div>
                                                    </div>
                                      <div class="col-lg-5" >
                                                        <div class="form-group"> 
                                                            <asp:TextBox ID="txtPatientRemark" runat="server" TextMode="MultiLine"  CssClass="form-control" ></asp:TextBox> 
                                                            </div>
                                         </div>
                                     </div>
                            </div>
                     <div id="Div3" class="col-lg-12 mt-2" runat="server" >
                                 <div class="row"> 
                                     <div class="col-lg-3" >
                                         <div class="form-group">  
                                         <strong>   Discussed With Relative:</strong> 
                                          </div>

                                     </div>

                                       <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                     <asp:CheckBox ID="ChkRYes" runat="server"   Text="Yes" ></asp:CheckBox> 
                    
                                                        </div>
                                                    </div>
                                     <div class="col-lg-1" >
                                                        <div class="form-group"> 
                                                     <asp:CheckBox ID="ChkRNo" runat="server"   Text="No" ></asp:CheckBox> 
                    
                                                        </div>
                                                    </div>
                                     <div class="col-lg-2" >
                                                        <div class="form-group"> 
                                                   <strong>  If No,Why?</strong>
                    
                                                        </div>
                                                    </div>
                                     <div class="col-lg-5" >
                                                        <div class="form-group"> 
                                                            <asp:TextBox ID="txtrelativeRemark" runat="server" TextMode="MultiLine"  CssClass="form-control" ></asp:TextBox> 
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
                <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:450px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="Id"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" Visible="false" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                <asp:BoundField DataField="EnterDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="EnterTime" HeaderText="Time" />
                                    <asp:BoundField DataField="LeftSide"  HeaderText="LeftSide" />
                                    <asp:BoundField DataField="RightSide"  HeaderText="RightSide" />
                                     <asp:BoundField DataField="Supine"  HeaderText="Supine" />
                                    <asp:BoundField DataField="HeadTilt"  HeaderText="Head Tilt" />
                                <asp:ButtonField CommandName="Delete" Text="Delete" Visible="false" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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


