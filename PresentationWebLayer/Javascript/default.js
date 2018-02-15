$(document).ready(function () {
    //sest global var to addform
    $vehicleForm = null;

    //init buttons
    $("#aVehicleAdd")
       .button()
       .click(function (event) {
           event.preventDefault();
           $vehicleForm = new _public.vehicleForm();
       });

    $("#aVehicleSearch")
       .button()
       .click(function (event) {
           event.preventDefault();
           _public.showSearhFilters();
       });

    $("#btnClear, #btnSearch, #btnAngularSearch").button();

    $("#btnClear").on("click", function () {
        $("#tblResults tbody").empty();
        $("#cboSearchVehicleType").val(0);
        $("#cboNoOfSeats").val(0);
    });

    $("#btnSearch").on("click", function () {
        _public.search();
    });
});

var _public = (function ($) {
    var VehicleSearch = function () {
        var data = {};
        var self = this;
        this.vehicleType = {
            1: "City",
            2: "Long Distance"
        }

        this.init = function () {
            displayResults([]);
        };

        this.searchVehicle = function () {

            $.ajax({
                type: "POST",
                async: true,
                url: "Default.aspx/Search",
                data: JSON.stringify({ "vehicleType": + $("#cboSearchVehicleType").val(), "numberOfSeats": + $("#cboNoOfSeats").val() }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    displayResults($.parseJSON(data.d));
                },
                error: function (message) {
                    alert(message.responseText);
                }
            });
        };

        var displayResults = function (data) {
            var resultArr = [];

            if (data.length == 0) {
                resultArr.push("</tr>");
                resultArr.push("<td colspan='9' style='text-align:center;'>No Results</td>");
                resultArr.push("</tr>");
            } else {

                $.each(data, function (i, node) {
                    resultArr.push("<tr class='" + ((i % 2 == 0) ? "alt" : "") + "'>");
                    resultArr.push("<td>" + node.Brand + "</td>");
                    resultArr.push("<td>" + node.Model + "</td>");
                    resultArr.push("<td>" + node.Year + "</td>");
                    resultArr.push("<td>" + node.Colour + "</td>");
                    resultArr.push("<td>" + self.vehicleType[node.VehicleType] + "</td>");
                    resultArr.push("<td>" + node.NumberOfSeats + "</td>");
                    resultArr.push("<td>" + ((node.HasAirConditioning) ? "Yes" : "No") + "</td>");
                    resultArr.push("<td>" + ((node.HasABS) ? "Yes" : "No") + "</td>");
                    resultArr.push("<td>" + ((node.HasRadio) ? "Yes" : "No") + "</td>");
                    resultArr.push("</tr>");
                });
            }

            $("#tblResults tbody").html(resultArr.join(""));
        };

        this.showSearhFilters = function () {
            if ($("#divSearchFilters").css("display") == "none") {
                $("#aVehicleSearch > span.ui-button-text").html("Hide Search");
                var options = { percent: 100 };
                $("#divSearchFilters").show("slide", options, 500, null);
            } else {
                var options = { percent: 0 };
                $("#divSearchFilters").hide("slide", options, 500, null);
                $("#aVehicleSearch > span.ui-button-text").html("Search Vehicles");
            }
        };
    };

    var VehicleForm = function () {
        $("#divVehicleAdd").dialog({
            dialogClass: 'DynamicDialogStyle',
            modal: true,
            open: function () {
                $(this).load("VehicleAdd.aspx");
            },
            close: function (e) {
                $(this).empty();
                $(this).dialog('destroy');
            },
            height: 350,
            width: 900,
            title: 'Vehicle Add'

        });

        return $("#divVehicleAdd");
    };

    var instSite = new VehicleSearch();
    instSite.init();

    var local = {
        vehicleForm: VehicleForm,
        showSearhFilters: instSite.showSearhFilters,
        search: instSite.searchVehicle,
        vehicleType: instSite.vehicleType
    }

    return local;
})($);

function customersController($scope, $http) {
    $scope.names = response
}