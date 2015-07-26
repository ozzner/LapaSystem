function cargarInicio() {
    window.onload = function () {
        var btnIngresar = document.getElementById("btnIngresar");
        if (btnIngresar != null) {
            btnIngresar.onclick = function () {
                return (validarCodigo());
            }
        }
    }
}
function validarCodigo() {
    var txtCodigo = document.getElementById("txtCodigo");
    if (txtCodigo != null) {
        if (txtCodigo.value == "") {
            alert("Enter captcha code");
            txtCodigo.focus();
            return false;
        }
        if (txtCodigo.value.length < 5) {
            alert("The code must be 5 characters");
            txtCodigo.focus();
            return false;
        }
        return true;
    }
}
