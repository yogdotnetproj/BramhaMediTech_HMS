<%@ Page Title="" Language="C#" MasterPageFile="~/DermatologyMaster.master" AutoEventWireup="true" CodeFile="HairLaser.aspx.cs" Inherits="HairLaser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <script type="text/javascript">
          function ShowMessage(message, messagetype) {
              var cssclass;
              switch (messagetype) {
                  case 'Success':
                      cssclass = 'alert-success'
                      break;
                  case 'Error':
                      cssclass = 'alert-danger'
                      break;
                  case 'Warning':
                      cssclass = 'alert-warning'
                      break;
                  default:
                      cssclass = 'alert-info'
              }
              $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert p-2 in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

              setTimeout(function () {
                  $("#alert_div").fadeTo(1000, 500).slideUp(500, function () {
                      $("#alert_div").remove();
                  });
              }, 500);//5000=5 seconds
          }
    </script>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
            <asp:PostBackTrigger ControlID="btnreport" />
             
        </Triggers>
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Hair Laser</h1>
                    <ol class="breadcrumb">
                       <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Hair Laser</li>
                    </ol>                
                </section>

               <section class="content"> 
                 <div class="box" runat="server" id="Show">
                 <div class="box-body">
                     <div class="row">    
                          <div class="col-lg-12 mt-2" id="Antagonist" runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                         <asp:gridview ID="GvHairLaser" runat="server" ShowFooter="true" Width="100%" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" ItemStyle-Width="15px" HeaderText="Row " />

        <asp:TemplateField HeaderText="Date" >

            <ItemTemplate>

                
                 <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtHairDate" autocomplete="off" runat="server" class="form-control pull-right" ></asp:TextBox>
                                                <span class="input-group-addon">
                                                     <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

       <asp:TemplateField HeaderText="Pulse" >

            <ItemTemplate>

                <asp:TextBox ID="txtPulse" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Energy" >

            <ItemTemplate>

                <asp:TextBox ID="txtEnergy" CssClass="form-control" runat="server"></asp:TextBox>

            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Center" />
             <HeaderStyle Width="150px" HorizontalAlign="right" />
        </asp:TemplateField>

             <asp:TemplateField HeaderText="Charge" >

            <ItemTemplate>

                <asp:TextBox ID="txtCharge" CssClass="form-control" runat="server"></asp:TextBox>

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
                         <div class="messagealert" id="alert_container">
            </div>
                          <div class="col-lg-12 mt-2" id="Div1" runat="server" >
                    <div class="row">
                            <div class="col-lg-12 text-center">
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success" OnClick="btnsave_Click" />
                                       
                                        <asp:Button ID="btnreport" runat="server" class="btn btn-primary btnSearch" Text="Report" OnClick="btnreport_Click" />
                                        </div>
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

