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

Application.FailureUpdate = function (geo,
                                        bTimeout,
                                        bPermissionDenied,
                                        bLocationUnavailable,
                                        message) {
    var msg = message ? message : "default message";
    if (bTimeout) {
        msg = "timeout";
    }
    else if (bPermissionDenied) {
        msg = "permission denied";
    }
    else if (bLocationUnavailable) {
        msg = "location unavailable";
    }

    Application.UpdateLocationText("Failed To Update At " + Application.NowAsMMDDYYYY() + " due to: " + msg);
};


Application.AsWCFDate = function (datetime) { 
    return datetime.format("M$").replace("\\","").replace("\\",""); // TODO: find better way
    }
    Application.onGeoUpdate = function (coords) {
        // was getting circular ref trying to turn coords into json, so harvest what we want out of coords, jsonify that 
        // we need to find a better way to do this       
        var nonCircularCoord = { Accuracy: coords.accuracy, Altititude: coords.altitude, AltitudeAccuracy: coords.altitudeaccuracy,
            Heading: coords.heading, Latitude: coords.latitude, Longitude: coords.longitude, Speed: coords.speed,
            Timestamp: Application.AsWCFDate(coords.timestamp)
        };

        var jsonCoords = Ext.encode(nonCircularCoord);
        Ext.Ajax.request({
            url: Application.ServerUrl,
            method: 'POST',
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
            params: jsonCoords,
            success: Application.SuccessUpdate(geo),
            failure: Application.FailureUpdate(geo,bTimeout,bPermissionDenied,bLocationUnavailable,message)
        });
    };
    Ext.setup({
        onReady: function () {
            Application.GeoLocator = new Ext.util.GeoLocation({
                autoUpdate: false,
                listeners: {
                    locationupdate: Application.onGeoUpdate
                },
                timeout: 1000 * 10,
                maximumAge: 20000,
                enableHighAccuracy: true
            });
            Application.GeoLocator.updateLocation();
            //setInterval(Application.GeoLocator.updateLocation(), 1000 * 10);
        }
    });