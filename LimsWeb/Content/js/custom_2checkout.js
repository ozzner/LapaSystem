function OcultarMensaje() {
    $("#message_span").fadeOut(4500);
}

function MostrarMensaje() {
    $("#message_span").fadeIn(0);
}

$(document).ready(function () {
    $("#message_span").hide();
});

function showMessage(id) {
    alert(id);
    $("#message_span").show();
    $("#message_span").val(id);

}