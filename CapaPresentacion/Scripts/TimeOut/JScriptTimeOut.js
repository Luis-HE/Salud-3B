var sess_pollInterval = 60000;
var sess_expirationMinutes = 15;
var sess_warningMinutes = 10;
var sess_intervalID;
var sess_lastActivity;

function initSession() {
    sess_lastActivity = new Date();
    sessSetInterval();
    $(document).bind('keypress.session', function (ed, e) {
        sessKeyPressed(ed, e);
    });
}
function sessSetInterval() {
    sess_intervalID = setInterval('sessInterval()', sess_pollInterval);
}
function sessClearInterval() {
    clearInterval(sess_intervalID);

}
function sessKeyPressed(ed, e) {
    sess_lastActivity = new Date();
}
function sessLogOut() {
    window.location.href = 'frmLogin.aspx';
}
function sessInterval() {
    var now = new Date();
    //get milliseconds of differneces
    var diff = now - sess_lastActivity;
    //get minutes between differences
    var diffMins = (diff / 1000 / 60);
    if (diffMins >= sess_warningMinutes) {
        //warn before expiring
        //stop the timer
        sessClearInterval();
        //prompt for attention
        var active = confirm('Su session expirará en ' + (sess_expirationMinutes - sess_warningMinutes) + ' minutos (a partir de ' + now.toTimeString() + '). \nPresione Aceptar para permanacer conectado o \npresione Cancelar para cerrar la sesión. \nSi se desconecta,se perderán los cambios.');
        if (active == true) {

            now = new Date();
            diff = now - sess_lastActivity;
            diffMins = (diff / 1000 / 60);
            if (diffMins > sess_expirationMinutes) {
                sessLogOut();
            }
            else {
                initSession();
                sessSetInterval();
                sess_lastActivity = new Date();
            }
        }
    else {
            sessLogOut();
    }
}
}