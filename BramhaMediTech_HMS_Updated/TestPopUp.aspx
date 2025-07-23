<%@ Page Title="" Language="C#" MasterPageFile="~/Hospital.master" AutoEventWireup="true" CodeFile="TestPopUp.aspx.cs" Inherits="TestPopUp" %>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
   <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js">
    </script>
      
    <!-- Including Bootstrap JS -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js">
    </script>--%>





    <%--   <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">--%>
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <style type="text/css">
        .messagealert {
            width: 100%;
            position: fixed;
             top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
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
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

            setTimeout(function () {
                $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
                    $("#alert_div").remove();
                });
            }, 5000);//5000=5 seconds
        }
    </script>
   <%-- <div class="alert alert-danger">
       <strong>Success!</strong> Your message has been sent successfully.
    </div>
     <div class="alert alert-success">
       <strong>Success!</strong> Your message has been sent successfully.
    </div>
    <!-- Success Alert -->
    <div class="alert alert-success alert-dismissible fade show">
        <strong>Success!</strong> Your message has been sent successfully.
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    </div>

    <!-- Error Alert -->
    <div class="alert alert-danger alert-dismissible fade show">
        <strong>Error!</strong> A problem has been occurred while submitting your data.
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    </div>

    <!-- Warning Alert -->
    <div class="alert alert-warning alert-dismissible fade show">
        <strong>Warning!</strong> There was a problem with your network connection.
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    </div>

    <!-- Info Alert -->
    <div class="alert alert-info alert-dismissible fade show">
        <strong>Info!</strong> Please read the comments carefully.
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    </div>--%>


    <div>

   
     <div class="messagealert" id="alert_container">
            </div>

             <div style="margin-top: 100px; text-align:center;">
            <asp:Button ID="btnSuccess" runat="server" Text="Submit" CssClass="btn btn-success"
                OnClick="btnSuccess_Click" />
            <asp:Button ID="btnDanger" runat="server" Text="Danger" CssClass="btn btn-danger"
                OnClick="btnDanger_Click" />
            <asp:Button ID="btnWarning" runat="server" Text="Warning" CssClass="btn btn-warning"
                OnClick="btnWarning_Click" />
            <asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-info"
                OnClick="btnInfo_Click" />
            </div>

         </div>
      <%-- <script type="text/javascript">
           setTimeout(function () {

               // Closing the alert
               $('.alert').alert('close');
           }, 3000);
    </script>--%>
</asp:Content>

