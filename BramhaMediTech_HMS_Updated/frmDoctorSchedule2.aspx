<%@ Page Title="Doctors Schedule" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" 
    CodeFile="frmDoctorSchedule2.aspx.cs" Inherits="frmDoctorSchedule2" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucPatientInfo.ascx" TagPrefix="uc1" TagName="ucPatientInfo" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <h1>Doctors Schedule</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <style type="text/css">
        .cssPager span {
            text-underline-position: below;
            font-size: 20px;
        }

        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <section class="content-header d-flex">
                <h1>Doctors Schedule</h1>
                <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Doctors Schedule</li>
                    </ol>
            </section>

            <section class="content">
                <div class="box" runat="server">
                    <div class="box-header with-border">
                        <span class="red pull-right">Fields marked with * are compulsory</span>
                        <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="False"></asp:Label>
                        <asp:HiddenField ID="txtSchId" runat="server" />
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-4">
                                        <div class="row">
                                            <div class="col-md-12 ">
                                                <%--<div class="form-group">
                                                    <label for="doctorNames">Search Doctor Name<span style="color: red">*</span></label>
                                                    <asp:TextBox ID="doctorNames" runat="server" AutoCompleteType="None"
                                                        AutoPostBack="false" TabIndex="1" CssClass="form-control" placeholder="Search Drug Name">
                                                    </asp:TextBox>
                                                    <asp:AutoCompleteExtender
                                                        MinimumPrefixLength="1"
                                                        ServiceMethod="GetDoctorNames"
                                                        CompletionInterval="100"
                                                        EnableCaching="false"
                                                        CompletionSetCount="10"
                                                        TargetControlID="doctorNames"
                                                        ID="AutoCompleteExtender3"
                                                        runat="server">
                                                    </asp:AutoCompleteExtender>
                                                    <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="doctorNames" ID="RequiredFieldValidator11"
                                                        runat="server" ForeColor="Red" ErrorMessage="Please select"></asp:RequiredFieldValidator>
                                                </div>--%>
                                                <label for="doctorNames"><b>Doctors</b></label>
                                                <asp:DropDownList ID="doctorNames" AutoPostBack="true"
                                                    class="form-control" runat="server"
                                                    OnSelectedIndexChanged="doctorNames_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator InitialValue="-1" Display="Dynamic" ControlToValidate="doctorNames"
                                                    ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Please select">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <label for="txtStartDate">Start Date:</label>
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                    <asp:TextBox class="form-control" ID="txtStartDate" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                </div>
                                            </div>

                                            <div class="col-lg-6">
                                                <label for="txtEndDate">End Date:</label>
                                                <div class="input-group date" data-provide="datepicker" data-date-format="dd/mm/yyyy" data-autoclose="true">
                                                    <asp:TextBox class="form-control" ID="txtEndDate" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                </div>
                                                <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Date" ForeColor="Red" runat="server"
                                                    ControlToValidate="txtStartDate" ControlToCompare="txtEndDate" Operator="LessThanEqual" Type="Date"
                                                    ErrorMessage="Must be greater"></asp:CompareValidator>
                                            </div>

                                            <%--<div class="col-md-6">
                                                <label for="txtStartDate">Start date <span style="color: red">*</span></label>
                                                <div class='input-group date' id='datetimepicker11'>

                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                                <asp:RequiredFieldValidator ControlToValidate="txtStartDate" ID="RequiredFieldValidator4" runat="server"
                                                    ForeColor="Red" ErrorMessage="select valid date"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-6 ">
                                                <label for="txtEndDate">End date <span style="color: red">*</span></label>
                                                <div class='input-group date' id='datetimepicker12'>

                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                                <asp:RequiredFieldValidator ControlToValidate="txtEndDate" ID="RequiredFieldValidator1" runat="server"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>--%>
                                        </div>

                                        <div class="row">
                                            <%-- <div class=" col-md-4 form-group">
                                                <label for="txtStartTime">Start time <span style="color: red">*</span></label>
                                                <div class='input-group date' id='datetimepicker13'>
                                                    <asp:TextBox class="form-control" ID="txtStartTime" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-time"></span>
                                                    </span>
                                                </div>
                                                <asp:RequiredFieldValidator ControlToValidate="txtStartTime" ID="RequiredFieldValidator3" runat="server"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>


                                            </div>
                                            <div class=" col-md-4 form-group">
                                                <label for="txtEndTime">End Time <span style="color: red">*</span></label>
                                                <div class='input-group date' id='datetimepicker14'>
                                                    <asp:TextBox class="form-control" ID="txtEndTime" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-time"></span>
                                                    </span>
                                                </div>
                                                <asp:RequiredFieldValidator ControlToValidate="txtEndTime" ID="RequiredFieldValidator5" runat="server"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>--%>

                                            <div class="col-lg-4  text-left">
                                                <div class="form-group">
                                                    <label for="txtStartTime">Start time:</label>

                                                    <div class="input-group bootstrap-timepicker timepicker" data-provide="timepicker" data-date-format="HH:mm" data-autoclose="true">
                                                        <asp:TextBox class="form-control timepicker" ID="txtStartTime" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-4  text-left">
                                                <div class="form-group">
                                                    <label for="txtEndTime">End time:</label>
                                                    <div class="input-group bootstrap-timepicker timepicker" data-provide="timepicker" data-date-format="HH:mm" data-autoclose="true">
                                                        <asp:TextBox class="form-control timepicker" ID="txtEndTime" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-4 form-group">
                                                <label for="txtSlot">Slot <span style="color: red">*</span></label>
                                                <asp:TextBox Text="0" AutoPostBack="true" OnTextChanged="txtSlot_TextChanged" class="form-control" ID="txtSlot" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator ControlToValidate="txtSlot" ID="RequiredFieldValidator6" runat="server"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <label for="txtNote"><b>Note</b></label>
                                                <asp:TextBox TextMode="MultiLine" Rows="2" class="form-control" ID="txtNote" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <%--OnClientClick="return checkData();"--%>
                                                <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnClear"  class="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                                <%-- <button type="button" id="btnAdd" class="btn btn-primary" style="margin-top: 32px;">Add</button>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:GridView ID="gvTempTable" runat="server" AutoGenerateColumns="False" 
                                            class="table table-responsive table-sm table-bordered" Width="100%" DataKeyNames="ScheduleId"
                                            HeaderStyle-ForeColor="Black" AlternatingRowStyle-BackColor="White" CellPadding="3" OnRowDeleting="gvTempTable_RowDeleting"
                                            AllowPaging="True" BackColor="White" OnRowCommand="gvTempTable_RowCommand" OnRowEditing="gvTempTable_RowEditing"
                                            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="10" ShowHeaderWhenEmpty="True"
                                            OnPageIndexChanging="gvTempTable_PageIndexChanging">
                                            <Columns>

                                                <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Image" ImageUrl="~/Images0/edit.gif" />
                                                <asp:BoundField DataField="ScheduleId" HeaderText="Sr No" ItemStyle-Width="50" Visible="false" />
                                                <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="EndDate" HeaderText="EndDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="StartTime" HeaderText="StartTime" ItemStyle-Width="50" />
                                                <asp:BoundField DataField="EndTime" HeaderText="EndTime"  />
                                                 <asp:BoundField DataField="DoctorId" HeaderText="DoctorId" Visible="true"   />
                                                 <asp:BoundField DataField="Note" HeaderText="Note" Visible="true"   />
                                               <%-- <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Image" ImageUrl="~/Images0/delete.gif" />--%>
                                                 <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Images0/delete.gif"
                                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this event?');"
                                                            AlternateText="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>


                                        <%--<table class="table table-bordered" id="patientList">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Start Date</th>
                                                    <th>End Date</th>
                                                    <th>Start Time</th>
                                                    <th>End Time</th>
                                                    <th>Slot Interval</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <script src="Scripts/jquery-3.4.1.js"></script>

            <script src="Scripts/bootstrap-timepicker.js"></script>

            <%--<script>
                $(function () {
                    $("#txtStartTime").timepicker({
                        showInputs: false //Set showInputs to false
                    });
                    $("#txtEndTime").timepicker({
                        showInputs: false //Set showInputs to false
                    });
                })
            </script>--%>

            <script>
                //$('#txtStartDate, #txtEndDate').datepicker({
                //    orientation: 'bottom'
                //})
            </script>
            <%-- <script type="text/javascript">
        var timeDiff;//= 10;

        $(document).ready(function () {
            debugger;
            //$("#txtStartTime, #txtEndTime").datetimepicker(
            //{
            //    format: "hh:mm A"
            //});

            //$("#txtStartDate, #txtEndDate").datetimepicker(
            //{
            //    format: "DD-MM-YYYY"
            //});

            var docId = 0;

            $('#doctorNames').on('change', function () {
                docId = this.value;

                if (docId > 0) {
                    debugger;
                    //timeDiff = $('option:selected', this).attr('myTag');
                    BindPatientLists(docId, null);
                }
            });

            docId = $('#doctorNames').val();

            $.ajax({
                type: "POST",
                url: "calendars.asmx/GetDocList",
                dataType: "json",
                success: function (res) {
                    for (var x = 0; x < res.length; x++) {
                        var selectList = "<option value='" + res[x].docId + "' myTag='" + res[x].slotInterval + "'>" + res[x].docName + "</option>";
                        $("#doctorNames").append(selectList);
                    }
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });

            $('#txtStartDate').keyup(function () {
                //checkDate($('#txtStartDate').val(), $('#txtEndDate').val(), docId, $('#txtStartTime').val(), $('#txtEndTime').val(), $('#txtSlot').val());
            });

            $('#txtEndDate').keyup(function () {
                //checkDate($('#txtStartDate').val(), $('#txtEndDate').val(), docId, $('#txtStartTime').val(), $('#txtEndTime').val(), $('#txtSlot').val());
            });

            $('#txtStartTime').keyup(function () {
                //checkDate($('#txtStartDate').val(), $('#txtEndDate').val(), docId, $('#txtStartTime').val(), $('#txtEndTime').val(), $('#txtSlot').val());
            });

            $('#txtEndTime').keyup(function () {
                //checkDate($('#txtStartDate').val(), $('#txtEndDate').val(), docId, $('#txtStartTime').val(), $('#txtEndTime').val(), $('#txtSlot').val());
            });

            //checkDate($('#txtStartDate').val(), $('#txtEndDate').val(), docId, $('#txtStartTime').val(), $('#txtEndTime').val(), $('#txtSlot').val());

            BindPatientLists(docId, null);

            $('#btnAdd').on('click', function () {
                var date1 = $('#txtStartDate').val().split("-").reverse().join("-");
                var date2 = $('#txtEndDate').val().split("-").reverse().join("-");
                var docId = $('#doctorNames').val();
                var time1 = moment($('#txtStartTime').val(), ["h:mm A"]).format("HH:mm");
                var time2 = moment($('#txtEndTime').val(), ["h:mm A"]).format("HH:mm");
                var slotId = $('#txtSlot').val();

                if (date1 != '' && date2 != '' && (docId != '' && docId != 0) && time1 != '' && time2 != '') {
                    $.ajax({
                        type: "POST",
                        contentType: 'application/x-www-form-urlencoded',
                        data: {
                            "date1": date1, "date2": date2, "docId": docId, "time1": time1, "time2": time2, "slotId": slotId
                        },
                        url: "calendars.asmx/SaveDocSchedule",
                        dataType: "json",
                        success: function (data) {
                            if (data) {
                                alert("Saved successfully");
                                BindPatientLists(docId, null);
                                //clear form
                                //clearFormControls();
                            }
                        },
                        error: function (jqXHR, exception) {
                            //errorFun();
                        }
                    });
                }
                else {
                    alert('Please enter all fields.');
                }
            });
        });

        function BindPatientLists(doctorId, clickedDate) {
            debugger;

            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                url: "calendars.asmx/GetDocScheduleList",
                data: { "docId": doctorId },
                dataType: "json",
                success: function (json) {
                    $('#patientList tbody').empty();

                    var tr;
                    var count = 1;
                    for (var i = 0; i < json.length; i++) {
                        tr = $('<tr/>');
                        tr.append("<td>" + count + "</td>");
                        tr.append("<td>" + moment(json[i].Date1).format("DD-MM-YYYY") + "</td>");
                        tr.append("<td>" + moment(json[i].Date2).format("DD-MM-YYYY") + "</td>");
                        tr.append("<td>" + moment(json[i].Time1, ["h:mm A"]).format("h:mm A") + "</td>");
                        tr.append("<td>" + moment(json[i].Time2, ["h:mm A"]).format("h:mm A") + "</td>");
                        tr.append("<td>" + json[i].Slot + "</td>");
                        $('#patientList tbody').append(tr);
                        count = count + 1;
                    }
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });
        }

        //function errorFun() {
        //    //debugger;
        //    var msg = '';
        //    if (jqXHR.status === 0) {
        //        msg = 'Not connect.\n Verify Network.';
        //    } else if (jqXHR.status == 404) {
        //        msg = 'Requested page not found. [404]';
        //    } else if (jqXHR.status == 500) {
        //        msg = 'Internal Server Error [500].';
        //    } else if (exception === 'parsererror') {
        //        msg = 'Requested JSON parse failed.';
        //    } else if (exception === 'timeout') {
        //        msg = 'Time out error.';
        //    } else if (exception === 'abort') {
        //        msg = 'Ajax request aborted.';
        //    } else {
        //        msg = 'Uncaught Error.\n' + jqXHR.responseText;
        //    }
        //    alert(msg);
        //}

        function checkDate(date1, date2, docId, time1, time2) {
            debugger;
            $('#btnAdd').prop('disabled', true);

            if (date1 != '' && date2 != '' && docId != '' && docId != 0 && time1 != '' && time2 != '') {
                if ((date2 > date1) && (time2 > time1)) {
                    $('#btnAdd').prop('disabled', false);
                }
            }

        }
    </script>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

