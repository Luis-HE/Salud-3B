function PopUpMessage(tipo, texto) {
    var n = noty({
        text: texto,
        type: tipo, // alert | error | success | information | warning | confirm
        dismissQueue: true,
        layout: 'center',
        theme: 'defaultTheme',
        modal: true
    });
    console.log('html: ' + n.options.id);
}