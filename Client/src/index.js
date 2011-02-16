Ext.setup({
        onReady: function () {
        tabletStartupScreen: 'tablet_startup.png',
        phoneStartupScreen: 'phone_startup.png',
        icon: 'icon.png',
        glossOnIcon: false,
        Application.UpdateLocationText(Application.GUID() + " is GUID <br />");
        geo = new Ext.util.GeoLocation({
            autoUpdate: true,
            listeners: {
                locationupdate: Application.onGeoUpdate
            },
            timeout: 100000,
            maximumAge: 20000,
            enableHighAccuracy: true
        });
    }
});