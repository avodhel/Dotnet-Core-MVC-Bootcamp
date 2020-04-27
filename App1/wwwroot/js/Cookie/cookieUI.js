
$("#btnSetCookie").click(function () {
    var key = $("#textKey").val();
    var value = $("#textValue").val();
    setCookie(key, value);
});

$("#btnGetCookie").click(function () {
    var key = $("#textKey").val();
    var value = getCookie(key);
    alert(value);
});
