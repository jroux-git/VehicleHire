var myApp = angular.module('vehicleApp', []);

myApp.controller('VehicleController', ['$scope','$http', function ($scope,$http) {
    $scope.vehicles = {};

    $scope.getVehicles = function () {
        $http({
            method: 'post',
            url: "Default.aspx/Search",
            headers: { 'Content-Type': 'application/json' },
            data: { vehicleType: $("#cboSearchVehicleType").val(), numberOfSeats: $("#cboNoOfSeats").val() }
        }).success(function (response) {
            var responseJSON = $.parseJSON(response.d);
            $.each(responseJSON, function (i, node) {
                if (node.VehicleType != undefined) {
                    node.VehicleType = ((_public.vehicleType[node.VehicleType]))
                }
            });
            
            $scope.vehicles = responseJSON;
        });
    };

    $scope.clear = function () {
        $scope.vehicles = {};
    }
}]);

