Ext.setup({
    tabletStartupScreen: 'tablet_startup.png',
    icon: 'icon.png',
    glossOnIcon: false,
        onReady: function () {        
        Application.UpdateLocationText(Application.GUID() + " is GUID <br />");
        geo = new Ext.util.GeoLocation({
            autoUpdate: true,
            listeners: {
                locationupdate: Application.onGeoUpdate
            },
            timeout: 10000,
            maximumAge: 200,
            enableHighAccuracy: true
        });
    }
});