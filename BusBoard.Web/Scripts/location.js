var longitude = document.getElementsByName("Location.Longitude")[0];
var latitude = document.getElementsByName("Location.Latitude")[0];
var text = document.getElementById("location-output");

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(setPosition);
    } else {
        longitude.value = "Geolocation is not supported by this browser.";
    }
}
function setPosition(position) {
    latitude.value = position.coords.latitude;
    longitude.value = position.coords.longitude;
}

function myMap() {
    var mapOptions = {
        center: new google.maps.LatLng(51.5, -0.12),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.HYBRID
    }
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}