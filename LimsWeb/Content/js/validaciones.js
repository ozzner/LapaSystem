function ValidarSoloNumeros() {
    if ((event.keyCode < 48) || (event.keyCode > 57))
        event.returnValue = false;
}

function ValidarDecimales() {
    if (event.keyCode < 44 || event.keyCode > 57 || event.ctrlKey || event.keyCode == 47 || event.keyCode == 86 || event.keyCode == 46 || event.keyCode == 45)
        event.returnValue = false;
}

function SoloLectura() {
    if ((event.keyCode < 48) || (event.keyCode > 57)) {
        event.returnValue = false;
    } else {
        event.returnValue = false;
    }
}

$(function () {
    var lastValue = '';
        setInterval(function () {
            if ($("#ContentPlaceHolder1_txtMuestraa").val() != lastValue) {
                lastValue = $("#ContentPlaceHolder1_txtMuestraa").val();
                actualizarTimer();
            }
        }, 10);
});

function actualizarTimer() {
    var d = $("#ContentPlaceHolder1_txtTimeFin").val();
    var future = new Date(d);
    var now = new Date();
    if ($("#ContentPlaceHolder1_lblEqpUtilizados").text() == 'OPCIONES DE EQUIPO') {
        $("#MyTimer").prop("display", "block").countDownAndUp({ since: now, until: future });
    } else {
        $("#MyTimer").prop("display", "none");
    }

}