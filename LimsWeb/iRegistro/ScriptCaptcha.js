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
    
    if (txtCodigo != null) {
        if (txtCodigo.value == "") {
            var ln = x = window.navigator.language || navigator.browserLanguage;
           
                alert("Ingresa el código");
                     
            txtCodigo.focus();
            return false;
        }
        if (txtCodigo.value.length < 5) {
            alert("El código debe ser de 5 caracteres");
            txtCodigo.focus();
            return false;
        }
        return true;
    }
}
