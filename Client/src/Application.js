Ext.ns("Application");

Application.UpdateLocationText = function (text) {
    var location = Ext.get("location");
    location.update(text + "<br />" + location.dom.innerHTML);
}

Application.NowAsMMDDYYYY = function () {
    return new Date().dateFormat("m/d/Y H:i:s");
}

Application.SuccessUpdate = function (geo) {
    Application.UpdateLocationText("Last Updated At " + Application.NowAsMMDDYYYY() + " Latitude: " + geo.latitude + " Longitude: " + geo.longitude);
};

Application.FailureUpdate = function (geo) {
    Application.UpdateLocationText("Failed To Update At " + Application.NowAsMMDDYYYY());
};

Application.RandomGUID = function () {
    // GUID function from killer answer at http://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid-in-javascript
    var lowerCaseGUID = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0;
        var v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
    return lowerCaseGUID.toUpperCase();
};

Application.GUID = function () {
    if (localStorage.getItem("-THRocks-AppGUID") === "undefined") {
        localStorage.setItem("-THRocks-AppGUID", Application.RandomGUID());
    };
    return localStorage.getItem("-THRocks-AppGUID");
};

Application.AsWCFDate = function (datetime) {
    return datetime.format("M$").replace("\\", "").replace("\\", ""); // TODO: find better way
};
Application.onGeoUpdate = function (coords) {
    // was getting circular ref trying to turn coords into json, so harvest what we want out of coords, jsonify that        
    var nonCircularCoord = {
        Accuracy: coords.accuracy, Altititude: coords.altitude, AltitudeAccuracy: coords.altitudeaccuracy,
        Heading: coords.heading, Latitude: coords.latitude, Longitude: coords.longitude, Speed: coords.speed,
        Timestamp: Application.AsWCFDate(coords.timestamp), PhoneId: Application.GUID()
    };

    var jsonCoords = Ext.encode(nonCircularCoord);
    try {
        Ext.Ajax.request({
            url: Application.ServerUrl,
            method: 'POST',
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
            params: jsonCoords,
            success: Application.SuccessUpdate(geo),
            failure: Application.FailureUpdate(geo),
            scope: Application
        });
    } catch (e) {
        alert(e);
    } finally {
    }

};
