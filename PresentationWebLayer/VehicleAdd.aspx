<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleAdd.aspx.cs" Inherits="PresentationWebLayer.VehicleAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Vehicles</title>
</head>
<body>
    <fieldset>
        <legend>Detail</legend>
        <div style="float:left;width:50%;">
            <div class="label"><label>Type</label></div>
            <select id="cboVehicleType">
                <option value="1">City</option>
                <option value="2">Long Distance</option>
            </select>
            <br />
            <div class="label"><label>Brand</label></div>
            <select id="cboBrand">
                <option value="Alfa Romeo">Alfa Romeo</option>
                <option value="BMW">BMW</option>
                <option value="Mercedes Benz">Mercedes Benz</option>
                <option value="VW">Volkswagen</option>
            </select>
            <br />
            <div class="label"><label>Model</label></div>
            <input type="text" id="txtModel" />
            <br />
            <div class="label"><label>Colour</label></div>
            <input type="text" id="txtColour" />
            <br />
        </div>
        <div style="float:left;width:50%;">
            <div class="label"><label>Year</label></div>
            <select id="cboYear">
                <option value="2008">2008</option>
                <option value="2009">2009</option>
                <option value="2010">2010</option>
                <option value="2011">2011</option>
                <option value="2012">2012</option>
                <option value="2013">2013</option>
                <option value="2013">2014</option>
            </select>
            <br />
            <div class="label"><label>No. of Seats</label></div>
            <select id="cboNoOfSeats">
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
            </select>
            <br />
            <div class="label"><label>Aircon</label></div>
            <input type="checkbox" id="chkAircon" />
            <br />
            <div class="label"><label>ABS</label></div>
            <input type="checkbox" id="chkABS" />
            <br />
            <div class="label"><label>Radio</label></div>
            <input type="checkbox" id="chkRadio" />
            <br />
        </div>
    </fieldset>

    <div class="buttons">
        <button id="btnSaveVehicle">Save</button>
        <button id="btnReset">Reset</button>
    </div>

    <script type="text/javascript" src="/Javascript/addVehicle.js"></script>
</body>
</html>
