$("#like").click(function () {
    var blogId = $("#blogId").val();
    var key = "BlogRateStatus" + blogId;
    if (getCookie(key) == false) {
        //istek atılacak
        $.ajax({
            url: "../Like?id=" + blogId,
            method: "GET",
            success: function (data) {
                $("#likeCount").text(data);
                setCookie(key, true);
            }
        })
    }
});
$("#dislike").click(function () {
    var blogId = $("#blogId").val();
    var key = "BlogRateStatus" + blogId;
    if (getCookie(key) == false) {
        //istek atılacak
        $.ajax({
            url: "../Dislike?id=" + blogId,
            method: "GET",
            success: function (data) {
                $("#dislikeCount").text(data);
                setCookie(key, true);
            }
        })
    }
});