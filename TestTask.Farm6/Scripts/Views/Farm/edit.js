$(document).ready(function () {
    var gisXInput = $('#GisX'),
        gisYInput = $('#GisY'),
        defaultCoords = $("#MapDefaultCoords").val()
            ? $("#MapDefaultCoords").val().split(',').map(function (item) {
                try {
                    var val = parseFloat(item);
                    return val;
                } catch (e) {
                    return 0;
                }
            })
            : [0, 0],
        gisX = gisXInput.val(),
        gisY = gisYInput.val(),
        getCoordinateByClickModeEnabled = false,
        currentMarker,
        map,
        changeMarkerPlace = function (pos, moveCenter) {
            if (!currentMarker) {
                currentMarker = createMarker(pos);
                let overlays = map.getOverlays().getArray();
                if (overlays.length) {
                    for (var i = overlays.length - 1; i >= 0; i--) {
                        map.removeOverlay(overlays[i]);
                    }
                }

                map.addOverlay(currentMarker);
            }

            currentMarker.setPosition(pos);
            if (moveCenter) {
                map.getView().setCenter(pos);
                map.getView().setResolution(0.75);
            }
        },
        createMarker = function(pos) {
            return new ol.Overlay({
                position: pos,
                positioning: 'bottom-center',
                offset: [0, 0],
                element: $('<image src="/Content/Images/map-marker.png" class="map-marker-img">')[0],
                stopEvent: false
            });
        };
    if (gisX) {
        gisX = parseFloat(gisX.replace(',', '.'));
    }

    if (gisY) {
        gisY = parseFloat(gisY.replace(',', '.'));
    }

    map = new ol.Map({
        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([gisX || defaultCoords[0], gisY || defaultCoords[1]]),
            zoom: 9
        })
    });
    var markerPos = ol.proj.transform([gisX, gisY], 'EPSG:4326', 'EPSG:3857');
    currentMarker = createMarker(markerPos);
    map.addOverlay(currentMarker);

    map.on('singleclick', function (evt) {
        if (getCoordinateByClickModeEnabled) {
            let coords = ol.proj.transform(evt.coordinate, 'EPSG:3857', 'EPSG:4326');
            changeMarkerPlace(evt.coordinate, false);
            gisX = coords[0];
            gisY = coords[1];
        }
    });
    
    var selectAddressBtn = $('<button class="deactivated" title="Проставить координаты вручную"><i class="glyphicon glyphicon-map-marker"></button>'),
        selectAddressBtnIcon = $('i', selectAddressBtn),
        selectAddressBtnClick = function (e) {
            if (getCoordinateByClickModeEnabled) {
                selectAddressBtnIcon.addClass('glyphicon-map-marker');
                selectAddressBtnIcon.removeClass('glyphicon-ok');
                selectAddressBtn.attr('title', 'Проставить координаты вручную');
                gisXInput.val(gisX);
                gisYInput.val(gisY);
            } else {
                selectAddressBtnIcon.addClass('glyphicon-ok');
                selectAddressBtnIcon.removeClass('glyphicon-map-marker');
                selectAddressBtn.attr('title', 'Зафиксировать координаты');
            }

            getCoordinateByClickModeEnabled = !getCoordinateByClickModeEnabled;
            return false;
        };
    selectAddressBtn.on('click', selectAddressBtnClick);

    element = $('<div class="select-coords ol-unselectable ol-control"></div>');
    element.append(selectAddressBtn);

    var selectAddressControl = new ol.control.Control({
        element: element[0]
    });

    map.addControl(selectAddressControl);
});