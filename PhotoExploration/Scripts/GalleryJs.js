var form = $("#uploadForm");
var loader = $(".loader");

form.on("submit", function(e) {
    e.preventDefault();

    $.ajax({
        url: "Gallery/UploadPhoto",
        method: "POST",
        data: new FormData(form[0]),
        processData: false,
        contentType: false,
        timeout: 3000,
        success: function(data) {
            $("#addComment").html("");
        },
        beforeSend: function() {
            loader.show();
        },
        complete: function() {
            loader.hide();
            form[0].reset();
        }
    });
});