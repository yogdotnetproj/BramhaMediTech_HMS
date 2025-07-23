<%@ Page Title="OT Schedule" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmOtSchedule.aspx.cs" Inherits="frmOtSchedule" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <h1>OT Schedule</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="content-header d-flex">
                <h1>OT Schedule</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">OT Schedule</li>
                    </ol>
            </section>
            <section class="content">
                <div class="box" runat="server">
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <span class="red pull-right">Fields marked with * are compulsory</span>
                                <asp:Label ID="lblMsg" class="red pull-center" runat="server" Text="" Font-Bold="true" ForeColor="green"></asp:Label>
                                <asp:HiddenField ID="txtTreatId" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="box-header with-border">
                        <div class="row">
                            <div class="col-lg-12 text-left">
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblPatientName" style="text-align: left">Name</label>
                                        <asp:Label ID="lblPatientName" runat="server" Text="A"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="txtpatientregid" style="text-align: left">PRN</label>
                                        <asp:Label ID="txtpatientregid" runat="server" Text="1"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblIpd" style="text-align: left">Ipd</label>
                                        <asp:Label ID="lblIpd" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblOpd" style="text-align: left">Opd</label>
                                        <asp:Label ID="lblOpd" runat="server" Text="11"></asp:Label>
                                    </div>
                                </div>

                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblEntryDate" style="text-align: left">EntryDate</label>
                                        <asp:Label ID="lblEntryDate" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-2 text-left">
                                    <div class="form-group">
                                        <label for="lblBranchId" style="text-align: left">Branch Id</label>
                                        <asp:Label ID="lblBranchId" runat="server" Text="0"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-4">
                                    <label for="opCategory"><b>Operation Category</b></label>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="opCategory" ID="RequiredFieldValidator1"
                                        runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="opCategory" runat="server" AutoPostBack="true" class="form-control" TabIndex="1" Height="30px"></asp:DropDownList>


                                    <%--<select id="opCategory" class="form-control  selectpicker" data-show-subtext="true" data-live-search="true"></select>--%>

                                    <label for="opName"><b>Operation Name</b></label>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="opName" ID="RequiredFieldValidator2"
                                        runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                    <%-- <select id="opName" class="form-control  selectpicker" data-show-subtext="true" data-live-search="true"> </select>--%>
                                    <asp:DropDownList ID="opName" runat="server" AutoPostBack="true" class="form-control" TabIndex="2" Height="30px"></asp:DropDownList>


                                    <label for="opTheater"><b>Operation Theater</b></label><asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="opTheater" ID="RequiredFieldValidator3"
                                        runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                    <%--<select id="opTheater" class="form-control  selectpicker" data-show-subtext="true" data-live-search="true"></select>--%>
                                    <asp:DropDownList ID="opTheater" runat="server" AutoPostBack="false" class="form-control" TabIndex="3" Height="30px"></asp:DropDownList>


                                    <label for="drName"><b>Doctor Name</b></label>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="drName" ID="RequiredFieldValidator4"
                                        runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                    <%-- <select id="drName" class="form-control  selectpicker" data-show-subtext="true" data-live-search="true"></select>--%>
                                    <asp:DropDownList ID="drName" runat="server" AutoPostBack="false" class="form-control" TabIndex="4" Height="30px"></asp:DropDownList>


                                    <label for="anName"><b>Anaesthesiast Name</b></label>
                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="anName" ID="RequiredFieldValidator5"
                                        runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                    <%-- <select id="anName" class="form-control  selectpicker" data-show-subtext="true" data-live-search="true"></select>--%>
                                    <asp:DropDownList ID="anName" runat="server" AutoPostBack="false" class="form-control" TabIndex="5" Height="30px"></asp:DropDownList>


                                    <div class="row">
                                        <div class="col-md-6">
                                            <label for="txtDate"><b>Date</b></label>
                                            <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                <asp:TextBox ID="txtDate" runat="server" AutoPostBack="true" class="form-control pull-right" TabIndex="6"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                            </div>
                                        </div>

                                        <div class='col-md-6 '>
                                            <label for="txtTime"><b>Time</b></label>
                                            <div class="input-group time" data-provide="timepicker" data-date-format="HH:mm" data-autoclose="true">
                                                <asp:TextBox ID="txtTime" runat="server" AutoPostBack="true" class="form-control pull-right" TabIndex="6"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                            <%--<div class='input-group date' id='datetimepicker4'>
                                        <input type="text" class="form-control" id="txtTime" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-time"></span>
                                        </span>
                                    </div>--%>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnClear" class="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                    <%-- <button type="button" id="btnAdd" class="btn btn-success">Add</button>
                            <button type="button" id="btnClear" class="btn btn-primary">Clear</button>--%>
                                    <%-- <input type="text" class="col-md-2 form-control" placeholder="reg id" id="txtpatientregid" />--%>
                                </div>
                                <div class="col-lg-8">
                                    <%-- OnRowDeleting="gvTempTable_RowDeleting" OnRowCommand="gvTempTable_RowCommand" OnRowEditing="gvTempTable_RowEditing"--%>
                                    <div class="table-responsive" style="width: 100%">

                                        <asp:GridView ID="gvTempTable" runat="server" AutoGenerateColumns="False"
                                            class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="OtSchId"
                                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" AllowPaging="True" BackColor="White"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                            OnPageIndexChanging="gvTempTable_PageIndexChanging" OnSelectedIndexChanged="gvTempTable_SelectedIndexChanged"
                                            OnRowDeleting="gvTempTable_RowDeleting" OnRowCommand="gvTempTable_RowCommand" OnRowEditing="gvTempTable_RowEditing">
                                            <Columns>
                                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                                <asp:BoundField DataField="otDate" HeaderText="Date" ItemStyle-Width="100" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="otTime" HeaderText="Time" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="OtSchId" HeaderText="OtSchId" Visible="true" />
                                                <asp:BoundField DataField="OpCategory" HeaderText="Category" />
                                                <asp:BoundField DataField="OpName" HeaderText="Name" />
                                                <asp:BoundField DataField="OpTheater" HeaderText="Theater" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="DrName" HeaderText="Dr. Name" />
                                                <asp:BoundField DataField="AnName" HeaderText="Anaesthesiast Name" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Images0/delete.gif"
                                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');"
                                                            AlternateText="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--  <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />--%>
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

                                    <%--<table class="table table-bordered" id="otList">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Date</th>
                                        <th>Category</th>
                                        <th>Name</th>
                                        <th>Theater</th>
                                        <th>Dr. Name</th>
                                        <th>Anaesthesiast Name</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <script src="Scripts/jquery-3.4.1.js"></script>
            <script src="Scripts/jquery-ui.min.js"></script>
            <script src="Scripts/moment.js"></script>
            <script src="Scripts/bootstrap.min.js"></script>
            <script src="Scripts/bootstrap-datetimepicker.js"></script>

            <%-- <script>
        $(document).ready(function () {
           // $("#txtTime").datetimepicker(
           //{
           //    format: "hh:mm A"
           //});

           // $("#txtDate").datetimepicker(
           // {

           //     format: "DD-MM-YYYY"
           // });

            var currentDate = moment().format('DD-MM-YYYY');

            $("#txtDate").val(currentDate);
            //$("#txtTime").val(moment().format("hh:mm A"));

            $("#btnClear").click(function () {
                ResetForm();
            });

            BindDefault();

            var id = $("#txtpatientregid").val();
            var patientregid = id.length == 0 ? "" : id;

            var opd = $("#lblOpd").val();
            var ipd = $("#lblIpd").val();

            BindOTSchedule(patientregid);

            $("#txtpatientregid").on('change', function () {
                var id1 = $("#txtpatientregid").val();
                var patientregid1 = id1.length == 0 ? "" : id1;
                BindOTSchedule(patientregid1);
            });


            $("#btnAdd").on("click", function () {
                debugger;



                if (true) {
                    var id2 = $("#txtpatientregid").val();
                    var patientregid1 = id2.length == 0 ? "0" : id2;

                    var OpCategory = $("#opCategory option:selected").html();
                    var OpName = $("#opName option:selected").html();
                    var OpTheater = $("#opTheater option:selected").html();
                    var DrName = $("#drName option:selected").html();
                    var AnName = $("#anName option:selected").html();
                    var OtDate = $('#txtDate').val();
                    var OtTime = $("#txtTime").val();
                    var type = 1;

                    InsertUpdate(type, patientregid1, opd, ipd, OpCategory, OpName, OpTheater, DrName, AnName, OtDate, OtTime);

                }
                else {
                    alert('Select all fields');
                }
            });

        });

        function InsertUpdate(type, patientregid, opd, ipd, OpCategory, OpName, OpTheater, DrName, AnName, OtDate, OtTime) {

            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                data: {
                    "type": type,
                    "PatRegId": patientregid, "Opd": opd, "Ipd": ipd, "OpCategory": OpCategory, "OpName": OpName,
                    "OpTheater": OpTheater, "DrName": DrName, "AnName": AnName, "OtDate": OtDate, "OtTime": OtTime
                },
                url: "OtSchedule.asmx/InsertUpdateOtScheduleTotalData",
                dataType: "json",
                success: function (json) {
                    // alert(JSON.stringify(json));

                    BindOTSchedule(patientregid);
                    ResetForm();
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });

        }

        function validData() {
            debugger;
            var ct = $("#opCategory option:selected").val();
            var op = $("#opName option:selected").val();
            var th = $("#opTheater option:selected").val();
            var dr = $("#drName option:selected").val();
            var an = $("#anName option:selected").val();

            var id = $("#txtpatientregid").val();

            if (ct > 0 && op > 0 && th > 0 && dr > 0 && an > 0 && id.length > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        function ResetForm() {
            $('#opCategory').val(-1);
            $('#opName').val(-1);
            $('#opTheater').val(-1);
            $('#drName').val(-1);
            $('#anName').val(-1);
        }

        function BindDefault() {
            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                url: "OtSchedule.asmx/GetOtScheduleData",
                dataType: "json",
                success: function (json) {
                    //alert(JSON.stringify(json.listOpCategory));
                    debugger;

                    $('#opCategory').append('<option value="-1">' + "--Select--" + '</option>');
                    $.each(json.listOpCategory, function (key, ans) {
                        $('#opCategory').append('<option value="' + key + '">' + ans + '</option>');
                    });

                    $('#opName').append('<option value="-1">' + "--Select--" + '</option>');
                    $.each(json.listOpName, function (key, ans) {
                        $('#opName').append('<option value="' + key + '">' + ans + '</option>');
                    });

                    $('#opTheater').append('<option value="-1">' + "--Select--" + '</option>');
                    $.each(json.listOpTheater, function (key, ans) {
                        $('#opTheater').append('<option value="' + key + '">' + ans + '</option>');
                    });

                    $('#drName').append('<option value="-1">' + "--Select--" + '</option>');
                    $.each(json.listDocName, function (key, ans) {
                        $('#drName').append('<option value="' + key + '">' + ans + '</option>');
                    });

                    $('#anName').append('<option value="-1">' + "--Select--" + '</option>');
                    $.each(json.listAnName, function (key, ans) {
                        $('#anName').append('<option value="' + key + '">' + ans + '</option>');
                    });
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });
        }

        function BindOTSchedule(patientregid) {
            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                data: { "patientregid": patientregid },
                url: "OtSchedule.asmx/GetOtScheduleTotalData",
                dataType: "json",
                success: function (json) {
                    // alert(JSON.stringify(json));
                    debugger;
                    BindTable(json);
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });
        }

        function BindTable(json) {
            $('#otList tbody').empty();
            var tr;
            var count = 1;

            for (var i = 0; i < json.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + count + "</td>");
                tr.append("<td>" + json[i].OtDate + " -" + json[i].OtTime + "</td>");
                tr.append("<td>" + json[i].OpCategory + "</td>");
                tr.append("<td>" + json[i].OpName + "</td>");
                tr.append("<td>" + json[i].OpTheater + "</td>");
                tr.append("<td>" + json[i].DrName + "</td>");
                tr.append("<td>" + json[i].AnName + "</td>");

                $('#otList tbody').append(tr);
                count = count + 1;
            }
        }
    </script>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


