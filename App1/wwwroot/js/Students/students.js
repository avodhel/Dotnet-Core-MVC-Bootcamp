$("#saveStudents").click(function () {
    $.ajax({
        url: '/ogrenci-guncelle',
        method: 'POST',
        dataType: 'json',
        data: {
            Id: $("#id").val(),
            Name: $("#name").val(),
            Surname: $("#surname").val(),
            Class: $("#class").val(),
            Teacher: $("#teacher").val()
        },
        success: function (data) {
            alert(data.value);
        },
        error: function () {
            alert("hata");
        },
        statusCode: {
            200: function (data) {
                alert("Http Response :  200 => " + data.value)
            }
        }
    });
});