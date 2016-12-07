$(document)
    .ready(function() {
        var form = $("form");
        form.submit(function(e) {
            $.ajax({
                method: "POST",
                url: "Gallery/UploadPhoto",
                data: new FormData(document.getElementsByTagName("form")[0]),
                success: function(data) {
                    $("div#galleryList").html(data);
                },
                processData: false,
                contentType: false
            });
        });
    });


function Success() {
    $("#addComment").html("");
}