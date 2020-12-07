function InitMap() {
    var map = new atlas.Map('myMap', {
        center: [-2.93, 43.26],
        zoom: 13,
        language: 'en-US',
        authOptions: {
            authType: 'subscriptionKey',
            subscriptionKey: 'zhnISPrPbfsED8lUiuVuZnGa8lLovPTwf5ffd46IGHo'
        }
    });

    map.events.add('ready', function () {
        //Define an HTML template for a custom popup content laypout.
        var popupTemplate = '<div class="customInfobox"><div class="name">{name}</div>{description}</div>';

        var dataSource = new atlas.source.DataSource();
        map.sources.add(dataSource);

        dataSource.add(new atlas.data.Feature(new atlas.data.Point([-2.95, 43.264]), {
            name: 'San Mames Stadium',
            description: 'The home field of Athletico Bilbao',
            LocID: '12'
        }));

        var symbolLayer = (new atlas.layer.SymbolLayer(dataSource, null));
        map.layers.add(symbolLayer);

        popup = new atlas.Popup({
            pixelOffset: [0, -18],
            closeButton: false
        });

        //Add a hover event to the symbol layer.
        map.events.add('mouseover', symbolLayer, function (e) {
            //Make sure that the point exists.
            if (e.shapes && e.shapes.length > 0) {
                var content, coordinate;
                var properties = e.shapes[0].getProperties();
                content = popupTemplate.replace(/{name}/g, properties.name).replace(/{description}/g, properties.description);
                coordinate = e.shapes[0].getCoordinates();

                popup.setOptions({
                    //Update the content of the popup.
                    content: content,

                    //Update the popup's position with the symbol's coordinate.
                    position: coordinate

                });
                //Open the popup.
                popup.open(map);
            }
        });

        map.events.add('mouseleave', symbolLayer, function () {
            popup.close();
        });

        map.events.add('click', symbolLayer, function (e) {
            var properties = e.shapes[0].getProperties();
            location.href = '/locations/details/' + properties.LocID
        });
    });
}
function GiveMap() {
    return 
}