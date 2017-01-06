setInterval(reloadComments, 10000);

function reloadComments() {
    $.ajax({
        type: "GET",
        url: window.location.href,
        success: function (data) {
            $("photoComments").html(data);
        }
    });
}