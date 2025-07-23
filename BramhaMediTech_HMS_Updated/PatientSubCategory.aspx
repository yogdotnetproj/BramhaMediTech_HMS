<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientSubCategory.aspx.cs" Inherits="PatientSubCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

      <script type = "text/javascript">
          function Validate() {

              if (document.getElementById("MainContent_txtPatientSubCat").value == "") {
                  alert("Please Enter Patient SubCategory");
                  return false;
              }

              if (document.getElementById("MainContent_ddlpatmaincat").value == "0") {

                  alert("Please Select Main Type!");
                  return false;

              }
          }
        </script>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>--%>
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
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Patient SubCategory</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Patient SubCategory</li>
                    </ol>
                </section>
    <section class="content">
        
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" class="red pull-center"  runat="server" Text="" Font-Bold="true" ForeColor="green" ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>
                         <div class="messagealert" id="alert_container">
            </div>
                        <div class="box-body">
                            <div class="row mb-3">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="ddlpatmaincat">Patient Category:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">                                     
                   <asp:DropDownList ID="ddlpatmaincat" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlpatmaincat_SelectedIndexChanged" CssClass="form-control form-select"
                                                 TabIndex="2"></asp:DropDownList>
                                   </div>
                                </div>
                           
                                                 <div class="col-sm-2 p-0">
                                    <div class="form-group">
                                         <label for="txtPatientSubCat">Patient SubCategory:</label>                                                                                
                                        </div>
                                    </div>
                                                <div class="col-sm-4">
                                    <div class="form-group"> 
                                          <asp:TextBox ID="txtPatientSubCat"  runat="server" placeholder="Enter Patient SubCategory(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                        <asp:TextBox ID="txtPatientSubCatins" Visible="false" runat="server" placeholder="Enter Insurance Company(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                        <asp:AutoCompleteExtender 
                                                MinimumPrefixLength="1"  
                                                ServiceMethod="SearchPatient"                                                
                                                CompletionInterval="100"
                                                EnableCaching="false" 
                                                CompletionSetCount="10" 
                                                TargetControlID="txtPatientSubCatins"
                                                ID="AutoCompleteExtender1"
                                                runat="server">
                                                   </asp:AutoCompleteExtender>
                                   </div>
                                </div>
                                           
                            </div>

                              <div class="row mb-3">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="ddlpatmaincat">Rate Type:</label>                                                                                
                                        </div>
                                    </div>
                                  <div class="col-sm-3">
                                    <div class="form-group">                                     
                   <asp:DropDownList ID="ddlRateType" runat="server" cssclass="form-control form-select" AutoPostBack="True">                                                 
                                                </asp:DropDownList>
                                   </div>
                                </div>
                                   <div class="col-sm-2 p-0">
                                    <div class="form-group">
                                         <label for="txtPatientSubCat">Company Code:</label>                                                                                
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                            <div class="form-group"> 
                                               <asp:TextBox ID="txtcompanyCode" runat="server" placeholder="Company Code" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                            </div>
                                        </div>     
                              

                                  </div>
                            <div class="row mb-3">
                                                   <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtPatientSubCat">LAB Rate Type:</label>                                                                                
                                        </div>
                                    </div>
                                                <div class="col-sm-3">
                                    <div class="form-group"> 
                                         <asp:DropDownList ID="ddlLabRateType" runat="server" cssclass="form-control form-select" AutoPostBack="True">                                                 
                                                </asp:DropDownList>
                                   </div>
                                </div>
                                                 <div class="col-sm-2">
                                      <div class="form-group">
                                         <label for="ddlRateType" style="text-align:left">Order No:</label>                                                                                
                                      </div>
                                  </div>                               
                                       
                                                   <div class="col-sm-3">
                                            <div class="form-group"> 
                                               <asp:TextBox ID="txtOrderNo" runat="server" placeholder="Order No" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                            </div>
                                        </div>     
                                          
                                   
                                    
                                               

                             
                            </div>
                              <div class="row mb-3">
                                   <div class="col-sm-12 text-center">
                                    <div class="form-group">
                                                  <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnsave_Click"  />
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnReset_Click" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" Visible="False" />                                                                      
                                        </div>
                                    </div>
                                  </div>

                            <div class="row mb-3">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvPatientSubCat" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                     OnPageIndexChanging="gvPatientSubCat_PageIndexChanging" OnRowEditing="gvPatientSubCat_RowEditing"
                    DataKeyNames="PatientInsuTypeId" AllowPaging="True" PageSize="10" OnRowDeleting="gvPatientSubCat_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                      <AlternatingRowStyle BackColor="#95deff"></AlternatingRowStyle>
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="PatientInsuTypeId" HeaderText="Patient Category Id" 
                                    Visible="False" />
                                <asp:BoundField DataField="PatMainType" HeaderText="Patient Category" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PatientInsuType" HeaderText="Patient SubCategory" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                           <asp:BoundField DataField="RateType" HeaderText="Rate Type" 
                                    ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Delete" runat="server" CommandName="Delete" 
                                             ImageUrl="~/Images0/delete.gif" 
                                            OnClientClick="return ValidateDelete()" 
                                            ToolTip="Click here to Delete this record" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
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
                  
                </section>
        </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>

