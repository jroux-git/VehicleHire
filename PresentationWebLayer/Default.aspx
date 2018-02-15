<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentationWebLayer.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Vehicles</title>

    <link type="text/css" href="/CSS/themes/base/jquery-ui.css" rel="stylesheet" />
    <link type="text/css" href="/CSS/Site.css" rel="stylesheet"/>
</head>
<body ng-app="vehicleApp">
    <h1>Search Vehicles</h1>
    <div id="divMainBar">
        <a  class="nav" id="aVehicleSearch" href="javascript:void(0);">Search Vehciles</a>
        <a class="nav" id="aVehicleAdd" href="/VehicleAdd.aspx">Add Vehcile</a>
    </div>

    <div ng-app="" ng-controller="VehicleController">
        <div id="divSearchFilters" style="display:none;">
            <div class="searchLabel"><label>Type</label></div>
            <select id="cboSearchVehicleType">
                <option value="0"></option>
                <option value="1">City</option>
                <option value="2">Long Distance</option>
            </select>

            <div class="searchLabel"><label>No. of Seats</label></div>
            <select id="cboNoOfSeats">
                <option value="0"></option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
            </select>
        
            <button id="btnSearch" ng-click="getVehicles()">Searh</button>
            <button id="btnClear" ng-click="clear()">Clear Results</button>
        </div>

        <h2>Normal Ajax Results </h2>
        <table id="tblResults">
            <thead>
                <tr>
                    <th>Brand</th>
                    <th>Make</th>
                    <th>Year</th>
                    <th>Colour</th>
                    <th>Vehicle Type</th>
                    <th>Number Of Seats</th>
                    <th>Has Aircon</th>
                    <th>Has ABS</th>
                    <th>Has Radio</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
        
      <h2>AngularJS Results </h2>
        <table id="Table1">
        <thead>
            <tr>
                <th>Brand</th>
                <th>Make</th>
                <th>Year</th>
                <th>Colour</th>
                <th>Vehicle Type</th>
                <th>Number Of Seats</th>
                <th>Has Aircon</th>
                <th>Has ABS</th>
                <th>Has Radio</th>
            </tr>
        </thead>
        <tbody>
            <tr ng-repeat="x in vehicles" ng-class-odd="'alt'" >
                <td>{{ x.Brand }}</td>
                <td>{{ x.Model }}</td>
                <td>{{ x.Year }}</td>
                <td>{{ x.Colour }}</td>
                <td>{{ x.VehicleType }}</td>
                <td>{{ x.NumberOfSeats }}</td>
                <td>{{ x.HasAirConditioning ? "Yes" : "No" }}</td>
                <td>{{ x.HasABS ? "Yes" : "No"  }}</td>
                <td>{{ x.HasRadio ? "Yes" : "No"  }}</td>
            </tr>
          </tbody>
      </table>
    </div>

    <div id="divVehicleAdd" style="display:none;"></div>

    <script type="text/javascript" src="/Javascript/jquery-1.10.1.min.js"></script>
    <script type="text/javascript" src="/Javascript/ui/jquery-ui.js"></script>
    <script type="text/javascript" src="/Javascript/angularjs v1.2.js"></script>
    <script type="text/javascript" src="/Javascript/default.js"></script>
    <script type="text/javascript" src="/Javascript/angVehicleController.js"></script>
</body>
</html>
