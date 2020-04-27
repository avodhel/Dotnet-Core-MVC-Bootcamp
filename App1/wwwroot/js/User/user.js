$("[id^=detail-]").click(function () {
    var userId = $(this).attr("id").split("-")[1];
    var userKey = "User-" + userId;
    var value = getCookie(userKey);
    if (value != "") {
        //burası çokomelli :)
        var jsonObject = jQuery.parseJSON(value);
        renderUserModal(jsonObject);
    }
    else {
        $.ajax({
            url: '/User/GetAsJson?id=' + userId,
            dataType: 'json',
            success: function (data) {
                setCookie(userKey, JSON.stringify(data));
                renderUserModal(data);
            }
        });
    }
});

$("[id^=delete-]").click(function () {
    var userId = $(this).attr("id").split("-")[1];
    $.ajax({
        url: '/User/Delete?id=' + userId,
        type: 'DELETE',
        success: function (data) {
            $("#modalTitle").html("Kullanıcı Silme")
            $("#modalBody").html(data);
            var selectorKey = "#record-" + userId;
            $(selectorKey).remove();
        }
    });
});

$("#newUser").click(function () {
    console.log("new user clicked.")
    $.ajax({
        url: '/User/NewUserPartial',
        dataType: 'html',
        success: function (data) {
            $("#modalTitle").html("Yeni Kullanıcı")
            $("#modalBody").html(data);
        }
    });
});

function renderUserModal(data) {
    var modalBody =
        `<div class="container">
                            <div class="row">
                                <label class="col-md-4"><strong>Sıra No</strong></label>
                                <label class="col-md-2">`+ data.id + `</label>
                            </div>

                            <div class="row">
                                <label class="col-md-4"><strong>İsim</strong></label>
                                <label class="col-md-2">`+ data.name + `</label>
                            </div>

                            <div class="row">
                                <label class="col-md-4"><strong>Soy İsim</strong></label>
                                <label class="col-md-2">`+ data.surname + `</label>
                            </div>

                            <div class="row">
                                <label class="col-md-4"><strong>Cinsiyet</strong></label>
                                <label class="col-md-2">`+ data.gender + `</label>
                            </div>

                            <div class="row">
                                <label class="col-md-4"><strong>Github Adresi</strong></label>
                                <label class="col-md-2">`+ data.githubAccountUrl + `</label>
                            </div>

                            <div class="row">
                                <label class="col-md-4"><strong>Email</strong></label>
                                <label class="col-md-2">`+ data.email + `</label>
                            </div>
                        </div>`;
    $("#modalTitle").html("Kullanıcı Detay")
    $("#modalBody").html(modalBody);
};