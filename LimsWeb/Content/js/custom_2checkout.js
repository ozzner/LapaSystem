//function OcultarMensaje() {
//    $("#message_span").fadeOut(4500);
//}

//function MostrarMensaje() {
//    $("#message_span").fadeIn(0);
//}

$(document).ready(function () {
    var isService = $("#type_service").text();
    
    if (isService) {

        $("#gratis_servicio").attr("disabled", true).hide();
        $("#basico_servicio").attr("disabled", true).hide();
        $("#corporativo_servicio").attr("disabled", true).hide();


    } else {
        $("#gratis_empresa").attr("disabled", true).hide();
        $("#basico_empresa").attr("disabled", true).hide();
        $("#corporativo_empresa").attr("disabled", true).hide();
    }

    
});

