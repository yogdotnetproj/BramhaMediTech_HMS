<%@ Page Title="Surgery Checklist Master" Language="C#" MasterPageFile="~/mainMaster.master" AutoEventWireup="true" CodeFile="frmCheckList.aspx.cs" Inherits="frmCheckList" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <h1>Surgery Checklist Master</h1>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--MainContent--%>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <style>
        .table-condensed > thead > tr > th, .table-condensed > tbody > tr > th, .table-condensed > tfoot > tr > th, .table-condensed > thead > tr > td, .table-condensed > tbody > tr > td, .table-condensed > tfoot > tr > td {
            padding: 3px;
        }

        .table tr th:nth-child(3) {
            width: 70%; /*Custom your width*/
        }

        .table tr th:nth-child(2) {
            width: 10%; /*Custom your width*/
        }
    </style>

    <section class="content-header d-flex">
        <h1>Surgery Checklist Master</h1>
        <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
                          <li class="breadcrumb-item active">Surgery Checklist Master</li>
                    </ol>
    </section>
    <section class="content">
        <div class="box" runat="server">
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg-4">
                                <label for="checkListType"><b>CheckList Type</b></label>
                                <select id="checkListType" class="form-control"></select>

                                <label for="txtDetails"><b>Details</b></label>
                                <input type="text" id="txtDetails" class="form-control" />

                                <button type="button" id="btnAdd" class="btn btn-success" >Add</button>
                                <button type="button" id="btnUpdate" class="btn btn-success" >Update</button>
                                <button type="button" id="btnClear" class="btn btn-primary" >Clear/Cancel</button>
                                <input type="text" hidden="hidden" id="txtSchId" />
                            </div>
                            <div class="col-lg-8">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-condensed" id="otList">
                                        <thead>
                                            <tr>
                                                <th>Edit</th>
                                                <th># </th>
                                                <th>Details</th>
                                                <th>Delete</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                </div>
                                <div class="col-lg-12 text-center">
                                    <ul class="pagination pagination-lg pager" id="myPager"></ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <%--    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-lg-4">
                    <label for="checkListType"><b>CheckList Type</b></label>
                    <select id="checkListType" class="form-control"></select>

                    <label for="txtDetails"><b>Details</b></label>
                    <input type="text" id="txtDetails" class="form-control" />

                    <button type="button" id="btnAdd" class="btn btn-success" style="margin-top: 32px;">Add</button>
                    <button type="button" id="btnUpdate" class="btn btn-success" style="margin-top: 32px;">Update</button>
                    <button type="button" id="btnClear" class="btn btn-primary" style="margin-top: 32px;">Clear/Cancel</button>
                    <input type="text" hidden="hidden" id="txtSchId" />
                </div>
                <div class="col-lg-8">
                    <div class="table-responsive">
                        <table class="table table-bordered table-condensed" id="otList">
                            <thead>
                                <tr>
                                    <th>Edit</th>
                                    <th># </th>
                                    <th>Details</th>
                                    <th>Delete</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/moment.js"></script>
    <script src="Scripts/paginationScript.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnUpdate").hide();
            $("#btnAdd").show();
            $("#txtSchId").val(0);

            BindCheckListTypes();

            $("#btnClear").click(function () {
                ResetForm();
                $("#btnUpdate").hide();
                $("#btnAdd").show();
                $("#otList").find("button").attr("disabled", false);

                $("#txtSchId").val(0);
                $("#txtDetails").val('');
                $("#checkListType").val(-1);
            });

            BindCheckListTable();

            $("#checkListType").on('change', function () {
                BindCheckListTable();
            });

            $("#btnAdd").click(function () {
                debugger;
                if (parseInt($("#checkListType").val()) > -1 && $("#txtDetails").val()) {
                    var checkListType = $("#checkListType").val();
                    var details = $("#txtDetails").val();
                    var schId = $("#txtSchId").val();
                    // alert(DrName + " " + OpTheater + " " + Duration + " " + tDate + " " + tTime)
                    var type = 1;
                    InsertUpdate(type, schId, checkListType, details);
                }
                else {
                    alert("Enter all fields");
                }
            });

            $("#btnUpdate").click(function () {
                debugger;
                if (parseInt($("#checkListType").val()) > -1 && $("#txtDetails").val() && parseInt($("#txtSchId").val()) > 0) {
                    var checkListType = $("#checkListType").val();
                    var details = $("#txtDetails").val();
                    var schId = $("#txtSchId").val();
                    // alert(DrName + " " + OpTheater + " " + Duration + " " + tDate + " " + tTime)
                    var type = 2;
                    InsertUpdate(type, schId, checkListType, details);
                }
                else {
                    alert("Enter all fields");
                }
            });

            $('#otList tbody').on('click', '.edit', function () {
                var rowData = $(this).parents("tr").children("td").map(function () {
                    return $(this).text();
                }).get();

                var schId = rowData[1].split('-')[1];
                var catId = rowData[1].split('-')[2];
                var details = rowData[2];


                disableTableControls();

                $("#checkListType").val(catId);
                $("#txtSchId").val(schId);
                $("#txtDetails").val(details);
            });

            $('#otList tbody').on('click', '.delete', function () {
                var rowData = $(this).parents("tr").children("td").map(function () {
                    return $(this).text();
                }).get();

                var schId = rowData[1].split('-')[1];

                DeleteSch(schId);
            });
        });

        function ResetForm() {

        }

        function BindCheckListTypes() {
            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                url: "serviceCheckList.asmx/GetCheckListCategories",
                dataType: "json",
                success: function (json) {
                    // alert(JSON.stringify(json));
                    debugger;

                    $('#checkListType').append('<option value="-1">' + "--Select--" + '</option>');
                    $.each(json, function (key, value) {
                        $('#checkListType').append('<option value="' + key + '">' + value + '</option>');
                    });

                },
                error: function (jqXHR, exception) {
                    //errorFun();
                    alert('error');
                }
            });
        }

        function disableTableControls() {
            $("#otList").find("button").attr("disabled", true);
            $("#btnUpdate").show();
            $("#btnAdd").hide();
        }

        function BindCheckListTable() {
            debugger;
            var checkListType = $("#checkListType").val();
            var details = $("#txtDetails").val();
            var schId = $("#txtSchId").val();
            var type = "Select";
            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                data: { "type": type, "schId": schId, "checkListType": checkListType, "details": details },
                url: "serviceCheckList.asmx/GetCheckListData",
                dataType: "json",
                success: function (json) {
                    //alert(JSON.stringify(json));
                    debugger;
                    BindTable(json);
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });
        }

        function InsertUpdate(type, schId, checkListType, details) {
            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                data: { "type": type, "schId": schId, "checkListType": checkListType, "details": details },
                url: "serviceCheckList.asmx/InsertUpdateCheckList",
                dataType: "json",
                success: function (json) {
                    alert(JSON.stringify(json));
                    debugger;
                    BindCheckListTable();

                    $("#txtDetails").val('');
                    $("#txtSchId").val(0);

                    if (type == 1) {

                    }
                    else if (type == 2) {
                        $("#otList").find("button").attr("disabled", false);
                        $("#btnUpdate").hide();
                        $("#btnAdd").show();
                    }
                },
                error: function (jqXHR, exception) {
                    //errorFun();
                }
            });
        }

        function DeleteSch(id) {
            var type = 3;
            var checkListType = '';
            var details = '';

            $.ajax({
                type: "POST",
                contentType: 'application/x-www-form-urlencoded',
                data: { "type": type, "schId": id, "checkListType": checkListType, "details": details },
                url: "serviceCheckList.asmx/InsertUpdateCheckList",
                dataType: "json",
                success: function (json) {
                    alert(JSON.stringify(json));
                    debugger;
                    BindCheckListTable();
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
            var i = 1;
            $.each(json, function (key, value) {
                tr = $('<tr/>');
                tr.append('<td><button class="btn btn-primary edit" id="btnEdit" data-id="' + i + '"  > Edit</button></td>');
                tr.append("<td>" + count + "<span style='display:none;'>-" + key + "</span>" + "</td>");
                tr.append("<td>" + value + "</td>");
                tr.append('<td><button class="btn btn-danger delete" id="btnDelete" data-id="' + i + '"  > Delete</button></td>');

                $('#otList tbody').append(tr);
                count = count + 1;

            });
        }
    </script>
</asp:Content>

