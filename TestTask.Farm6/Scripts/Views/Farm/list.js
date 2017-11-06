$(document).ready(function () {
    var mapData = JSON.parse($('#MapData').val()),
        markers,
        map,
        popoverContent = $('#map-marker-popover'),
        popoverContentFunc = function (model) {
            if (mapData && mapData.Ids) {
                mapData.Ids.forEach(function (item) {
                    var field = item.substr(item.indexOf('-') + 1),
                        fieldCtrl = $('#' + item);
                    fieldCtrl.text(model[field]);
                });
            }

            return popoverContent.html();
        },
        createMarker = function (pos, model) {
            var element = $('<image src="/Content/Images/map-marker.png" class="map-marker-img">');
            element.popover({
                html: true,
                content: function () {
                    return popoverContentFunc(model);
                }
            });
            return new ol.Overlay({
                position: pos,
                positioning: 'bottom-center',
                offset: [0, 0],
                element: element[0],
                stopEvent: false
            });
        },
        getCoords = function (model) {
            var gisX = model ? model.GisX : undefined,
                gisY = model ? model.GisY : undefined;

            if (typeof gisX !== 'number' && gisX) {
                gisX = parseFloat(gisX.replace(',', '.'));
            }

            if (typeof gisY !== 'number' && gisY) {
                gisY = parseFloat(gisY.replace(',', '.'));
            }

            return [gisX || 0, gisY || 0];
        },
        addMarkerToMap = function (coords, model) {
            var markerPos = ol.proj.transform(coords, 'EPSG:4326', 'EPSG:3857'),
                newMarker = createMarker(markerPos, model);
            map.addOverlay(newMarker);
            return newMarker;
        };

    map = new ol.Map({
        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View()
    });

    var view = map.getView();
    if (!mapData.Models || mapData.Models.length === 0) {
        view.setCenter([0, 0]);
    } else if (mapData.Models.length === 1) {
        var coords = getCoords(mapData.Models[0]);
        view.setCenter(coords);
        addMarkerToMap(coords, mapData.Models[0]);
    } else {
        var coords = mapData.Models.map(function (item) { return ol.proj.transform(getCoords(item), 'EPSG:4326', 'EPSG:3857'); });
        var ext = ol.extent.boundingExtent(coords);
        view.fit(ext, map.getSize(), { minResolution: 1 });
        mapData.Models.forEach(function (item) {
            addMarkerToMap(getCoords(item), item);
        });
    }
});