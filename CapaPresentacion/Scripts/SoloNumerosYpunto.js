// Solo permite ingresar numeros y PUNTO(46),COMA(44). valido para datos monetarios
function soloNumerosPuntoyComa(e) {
    var key = window.Event ? e.which : e.keyCode
    return ((key >= 48 && key <= 57) || key == 46||key==44)
}