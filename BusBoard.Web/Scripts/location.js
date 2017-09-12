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
    text.innerHTML = "Values populated " + latitude.value + "</br>" + longitude.value + "  " + typeof (longitude);
}