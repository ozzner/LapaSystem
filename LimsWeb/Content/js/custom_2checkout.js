//function OcultarMensaje() {
//    $("#message_span").fadeOut(4500);
//}

//function MostrarMensaje() {
//    $("#message_span").fadeIn(0);
//}

$(document).ready(function () {
    var isService = $("#type_service").text();   
    var lapaPackage = $("#type_plan").();
    
    if (isService) {

        $("#gratis_servicio").attr("disabled", true).hide();
        $("#gratis_empresa").attr("disabled",true).hide();
        $("#basico_servicio").attr("disabled", true).hide();
        $("#corporativo_servicio").hide();


        //Paquetes
        if (lapaPackage.text == "Corporativo") {
            $("#corporativo_servicio_btn").attr("disabled", true).hide();
        } else {
            $("#basico_servicio_btn").attr("disabled", true).hide();
        }
      
    } else {

        $("#gratis_empresa").attr("disabled", true).hide();
        $("#gratis_servicio").attr("disabled",true).hide();
        $("#basico_empresa").attr("disabled", true).hide();
        $("#corporativo_empresa").attr("disabled", true).hide();


        //Paquetes
        if (lapaPackage == 'Corporativo') {
            $("#corporativo_empresa_btn").attr("disabled", true).hide();
        } else {
            $("#basico_empresa_btn").attr("disabled", true).hide();
        }

    }


   


    
});

