function setCookie(key, value) {
    document.cookie = key + "=" + value + ";path=/";
};

function getCookie(key) {
    var keyPrefix = key + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(";");
    for (var i = 0; i < cookieArray.length; i++) {
        var cookieObject = cookieArray[i];
        while (cookieObject.charAt(0) == " ") {
            cookieObject = cookieObject.substring(1);
        }
        if (cookieObject.indexOf(keyPrefix) == 0) {
            return cookieObject.substring(keyPrefix.length, cookieObject.length);
        }
    }
    return "";
};