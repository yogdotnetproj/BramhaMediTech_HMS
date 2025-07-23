<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="PatientCategory.aspx.cs" Inherits="PatientCategory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<%--    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/2.3.2/css/bootstrap.min.css" />--%>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>--%>
    <script type = "text/javascript">
        function Validate() {
            
            if (document.getElementById("MainContent_txtPatientCat").value == "") {
                   alert("Please Enter Patient Category");
                return false;
            }
        }
        </script>
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

       <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />--%>
        <script type="text/javascript">
            $("body").on("click", "#btnsave", function () {
                $.ajax({
                    url: 'PatientCategory.aspx',
                    type: 'POST',
                    data: new FormData($('form')[0]),
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (file) {
                        setTimeout(function () {
                            $(".progress").hide();
                            $("#lblMessage").html("<b>" + file.name + "</b> has been uploaded.");
                        }, 1000);
                    },
                    error: function (a) {
                        $("#lblMessage").html(a.responseText);
                    },
                    failure: function (a) {
                        $("#lblMessage").html(a.responseText);
                    },
                    xhr: function () {
                        var fileXhr = $.ajaxSettings.xhr();
                        if (fileXhr.upload) {
                            $(".progress").show();
                            fileXhr.upload.addEventListener("progress", function (e) {
                                if (e.lengthComputable) {
                                    var percentage = Math.ceil(((e.loaded / e.total) * 100));
                                    $('.progress-bar').text(percentage + '%');
                                    $('.progress-bar').width(percentage + '%');
                                    if (percentage == 100) {
                                        $('.progress-bar').text('100%');
                                    }
                                }
                            }, false);
                        }
                        return fileXhr;
                    }
                });
            });
        </script>
     <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                    <h1>Patient Category</h1>
                    <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                        <li class="breadcrumb-item active">Patient Category</li>
                    </ol>
                </section>
    <section class="content">
                    <div class="box">
                        <div class="box-header with-border">
                            <asp:Label ID="lblMessage" Visible="false"  runat="server"  ></asp:Label>
                            <span class="red pull-right">Fields marked with * are compulsory</span> 
                        </div>
                      <div class="messagealert" id="alert_container">
            </div>
                        <div class="box-body">
                            <div class="row mb-3">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                         <label for="txtPatientCat">Patient Category:</label>                                                                                
                                        </div>
                                    </div>
                                <div class="col-sm-3">
                                    <div class="form-group">                                     
                                
                                       
                <asp:TextBox ID="txtPatientCat" runat="server" placeholder="Enter Patient Category(*)" class="form-control" TabIndex="1"></asp:TextBox>
                                   </div>
                                </div>
                               <div class="progress" style="display: none">
            <div class="progress-bar" role="progressbar"></div>
        </div>
                                  
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary"  TabIndex="3" Text="Save" OnClientClick="return Validate();" OnClick="btnsave_Click"  />
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary"  TabIndex="2" Text="Reset" OnClick="btnReset_Click" />
                                        <asp:Button ID="btnPrint" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                             OnClick="btnPrint_Click" onclientclick="target = '_blank';" Text="Print" Visible="False" />
                               
                                       
                                    </div>
                                </div>
                            </div>

                                 <div class="col-lg-12" > 
                                            <div class="row">
                   <div class="table-responsive" style="width:100%">
                  <asp:GridView ID="gvPatientCat" runat="server" class="table table-responsive table-sm table-bordered" AutoGenerateColumns="False" 
                    Width="592px" OnPageIndexChanging="gvPatientCat_PageIndexChanging" OnRowEditing="gvPatientCat_RowEditing"
                    DataKeyNames="PatMainTypeId" AllowPaging="True" PageSize="15" OnRowDeleting="gvPatientCat_RowDeleting"   HeaderStyle-ForeColor="Black"
                    AlternatingRowStyle-BackColor="White">
                       <Columns>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/Images0/edit.gif" 
                                     ShowCancelButton="False" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="PatMainTypeId" HeaderText="Patient Category Id" 
                                    Visible="False" />
                                <asp:BoundField DataField="PatMainType" HeaderText="Patient Category" 
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
                    </div>
                  
                </section>
            <script type="text/javascript">
                setTimeout(function () {

                    // Closing the alert
                    $('.alert').alert('close');
                }, 3000);
    </script>
        </ContentTemplate>
        </asp:UpdatePanel>
    
</asp:Content>

