$(document).ready(function () { });

(function($) {
    var VehicleAdd = function () {
        var data = {
            VehicleType: 0,
            Brand: "",
            Model: "",
            Colour: "",
            Year: 0,
            NumberOfSeats: 0,
            HasAirConditioning: false,
            HasABS: false,
            HasRadio: false
        };

        var self = this;

        this.init = function () {
            $("#btnReset").on("click", function () {
                $("#cboVehicleType").val(0);
                $("#cboBrand").val(0);
                $("#txtModel").val("");
                $("#txtColour").val("");
                $("#cboYear").val(0);
                $("#cboNoOfSeats").val(0);
                $("#chkAircon").prop("checked", false);
                $("#chkABS").prop("checked", false);
                $("#chkRadio").prop("checked", false);
            });

            $("#btnSaveVehicle").on("click", function () {
                saveVehicle();
            });
        };

        var saveVehicle = function () {
            data.VehicleType = $("#cboVehicleType").val();
            data.Brand = $("#cboBrand").val();
            data.Model = $("#txtModel").val();
            data.Colour = $("#txtColour").val();
            data.Year = $("#cboYear").val();
            data.NumberOfSeats = $("#cboNoOfSeats").val();
            data.HasAirConditioning = $("#chkAircon").prop("checked");
            data.HasABS = $("#chkABS").prop("checked");
            data.HasRadio = $("#chkRadio").prop("checked")
            
            $.ajax({
                type: "POST",
                async: true,
                url: "VehicleAdd.aspx/Add",
                data: JSON.stringify({"vehicleType" : data.VehicleType , "brand" : data.Brand
                 , "model" : data.Model , "colour" : data.Colour
                 , "year" : data.Year , "numberOfSeats" : data.NumberOfSeats
                 , "hasAirConditioning" : data.HasAirConditioning , "hasABS" : data.HasABS
                 , "hasRadio" : data.HasRadio}),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
            }).success(function (data) {
                var saved = $.parseJSON(data.d);
                if (saved.Saved) {
                    $("<div id='divMessage'>").dialog({
                        modal: true,
                        buttons: {
                            Ok: function () {
                                $(this).empty();
                                $(this).dialog('destroy');

                                $vehicleForm.empty();
                                $vehicleForm.dialog('destroy');
                                
                                window.parent._public.search();
                            }
                        }
                    }).html("Vehicle added successfully");
                } else {
                    $("<div id='divMessage'>").dialog({
                        modal: true,
                        buttons: {
                            Ok: function () {
                                $(this).empty();
                                $(this).dialog('destroy');

                                $vehicleForm.empty();
                                $vehicleForm.dialog('destroy');

                                window.parent._public.search();
                            }
                        }
                    }).html("Vehicle save failed");
                }
                
            }).error(function (message) {
                alert("Error:" + message.responseText);
            });
        };
    }

    var instSite = new VehicleAdd();
        instSite.init();
})($);