<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="PhysicalExamination.aspx.cs" Inherits="PhysicalExamination" %>

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
        <h1>Physical Examination</h1>
         <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Physical Examination</li>
                    </ol>
    </section>
    <section class="content">
        <div id="Div1" class="box" runat="server">
             
            <div class="box-header">
                <span class="red pull-right"></span>
                <asp:Label ID="lblMsg1" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
             
            </div>
            
             <div class="box-body">
               
                
                       
                   <div class="col-lg-12">
                                 <div class="row"> 
                                       <div class="col-sm-2 text-left">
                                                       
                                            <div class="form-group form-check pl-0">  
                                                <label for="txttimestart" class="mr-0">Bedsore:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkBedsore" />
                                                            </div>
                                           </div>
                                    
                                    
                                       <div class="col-sm-2 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Dentures:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkDentures" />
                                                            </div>
                                           </div>
                                    
                                       <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Spectacles:</label>
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkSpectacles" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>


                  <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       <div class="col-sm-3 text-left">
                                                       
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Physical Injuries:</label>    
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkPhyinj" />
                                                            </div>
                                           </div>
                                      <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Physical Injuries"  ID="txtphyinjremark" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>

                                <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group form-check pl-0"> 
                                                            <label for="txttimestart" class="mr-0">Foleys:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkFoleys" />
                                                            </div>
                                           </div>
                                     
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">NG Tube:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkNGTube" />
                                                            </div>
                                           </div>
                                     
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                             <label for="txttimestart" class="mr-0">Intra-Cath:</label> 
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkIntraCatch" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-1 text-left">
                                                         <div class="form-group">  
                                                               <label for="txttimestart">Size:</label>     
                                                            </div>
                                           </div>
                                      <div class="col-sm-4 text-left">
                                         
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Size"  ID="txtsize" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>


                        <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Central Line:</label> 
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkcentralline" />
                                                            </div>
                                           </div>
                                      <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Central Line"  ID="txtcentralline" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>

                        <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Any Implantable Device:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkimpladevice" />
                                                            </div>
                                           </div>
                                      <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Any Implantable Device"  ID="txtimpladevice" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>

                  <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       
                                     <div class="col-sm-2 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Jewellery:</label>  
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkJewellery" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-4 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">If yes remove and give to family:</label> 
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkjevfamily" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>
                        <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group form-check pl-0">  
                                                            <label for="txttimestart" class="mr-0">Checked by patient's family:</label> 
                                                               <asp:CheckBox runat="server" CssClass="BigCheckBox" ID="chkpatfamily" />
                                                            </div>
                                           </div>
                                     
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" class="form-control"  placeholder="Enter Signature" ID="txtsignature" />
                                                            </div>
                                           </div>
                                     <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" class="form-control" placeholder="Enter Relationship" ID="txtrelationship" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>


                  <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart">Other Remarks:</label>     
                                                            </div>
                                           </div>
                                   
                                      <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Other Remark"  ID="txtotherremark" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>
                 <div class="col-lg-12 mt-3">
                                 <div class="row"> 
                                       <div class="col-sm-3 text-left">
                                                        <div class="form-group">  
                                                               <label for="txttimestart">Nurse:</label>     
                                                            </div>
                                           </div>
                                   
                                      <div class="col-sm-8 text-left">
                                                        <div class="form-group">  
                                                               <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Enter Nurse"  ID="txtnurserem" />
                                                            </div>
                                           </div>
                                     </div>
                       </div>
               
                <div class="col-lg-12 mt-3 text-center">
                    <div class="form-group">
                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnsave_Click" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-warning" OnClick="btnReset_Click" />                                       
                        <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn btn-primary btnSearch" OnClick="btnReport_Click"  />                                       
                  <asp:Label ID="LblMSg"  Font-Bold="true" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-lg-12 mt-3">
                    <div class="row">
                        <div runat="server" id="UploadedFiles" style="height:150px; width:1200px; overflow:scroll">   
                             <div class="table-responsive" style="width: 100%">
                                <asp:GridView ID="gvDailyNurseNote" runat="server" AutoGenerateColumns="False" AutoPostBack="false"
                                class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="PhId"
                                HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvDailyNurseNote_RowDeleting"
                                AllowPaging="True" BackColor="White" OnRowEditing="gvDailyNurseNote_RowEditing"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="100" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvDailyNurseNote_PageIndexChanging">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                <Columns>

                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                   <asp:BoundField DataField="CreatedOn" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="CreatedBy" HeaderText="Enter by" />
                                    <asp:BoundField DataField="BedsoreType" HeaderText="Bedsore" />
                                    <asp:BoundField DataField="DenturesType"  HeaderText="Dentures" />
                                    <asp:BoundField DataField="SpectaclesType"  HeaderText="Spectacles" />
                                    <asp:BoundField DataField="PhysicalInjuries"  HeaderText="Physical Injuries" />
                                     <asp:BoundField DataField="CentralLine"  HeaderText="Central Line" />
                                    <asp:BoundField DataField="NurseRemark"  HeaderText="Nurse Remark" />
                                     <asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                     <asp:BoundField DataField="UpdatedBy" HeaderText="Updated by" />
                                <asp:ButtonField CommandName="Delete" Visible="false" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />

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

