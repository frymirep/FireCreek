Ext.ns("Application");

Application.UpdateLocationText = function (text) {
    Ext.fly("location").update(text, false);
}

Application.NowAsMMDDYYYY = function () {
    return new Date().dateFormat("m/d/Y H:i:s");
}

Application.SuccessUpdate = function (geo) {
    Application.UpdateLocationText("Last Updated At " + Application.NowAsMMDDYYYY() + " Latitude: " + geo.latitude + " Longitude: " + geo.longitude);
};

Application.FailureUpdate = function (geo) {
    Application.UpdateLocationText("Failed To Update At " + Application.NowAsMMDDYYYY() );
};


Application.AsWCFDate = function (datetime) {
    return datetime.format("M$").replace("\\", "").replace("\\", ""); // TODO: find better way
};
Application.onGeoUpdate = function (coords) {
    // was getting circular ref trying to turn coords into json, so harvest what we want out of coords, jsonify that        
    var nonCircularCoord = { Accuracy: coords.accuracy, Altititude: coords.altitude, AltitudeAccuracy: coords.altitudeaccuracy,
        Heading: coords.heading, Latitude: coords.latitude, Longitude: coords.longitude, Speed: coords.speed,
        Timestamp: Application.AsWCFDate(coords.timestamp)
    };

    var jsonCoords = Ext.encode(nonCircularCoord);
    debugger;
    Ext.Ajax.request({
        url: Application.ServerUrl,
        method: 'POST',
        headers: { 'Content-Type': 'application/json; charset=utf-8' },
        params: jsonCoords,
        success: Application.SuccessUpdate(geo),
        failure: Application.FailureUpdate(geo)
    });
};
Ext.setup({
    onReady: function () {
        geo = new Ext.util.GeoLocation({
            autoUpdate: true,
            listeners: {
                locationupdate: Application.onGeoUpdate
            },           
            timeout: 10000000,
            maximumAge: 20000,
            enableHighAccuracy: true
        });
    }
});