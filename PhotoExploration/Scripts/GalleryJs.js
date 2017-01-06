var form = $("uploadForm");
var loader = $(".loader").hide();

form.on("submit", function(e) {
    e.preventDefault();

    $.ajax({
        url: "Gallery/UploadPhoto",
        method: "POST",
        data: new FormData(form[0]),
        processData: false,
        contentType: false,
        sucess: function(data) {
            $("#addComment").html("");
            form.reset();
        },
        beforeSend: function() {
            loader.show();
        },
        complete: function() {
            loader.hide();
        }
    });
});