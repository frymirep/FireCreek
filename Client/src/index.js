Ext.setup({
    tabletStartupScreen: 'tablet_startup.png',
    phoneStartupScreen: 'phone_startup.png',
    icon: 'icon.png',
    glossOnIcon: false,
    onReady: function () {
        Application.UpdateLocationText(Application.GUID() + " is GUID <br />");
        try {
            geo = new Ext.util.GeoLocation({
                autoUpdate: false,
                listeners: {
                    locationupdate: Application.onGeoUpdate
                },
                timeout: 1000000,
                maximumAge: 200,
                enableHighAccuracy: true
            });

            while (true) { 
                setInterval(geo.
            }
        } catch (e) {
        } finally {
        }
    }
});