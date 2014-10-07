//vble de control de guardado
var guardado = false;
//maneja el evento click
function doMainClick(sender, keyEventArgs){
        if (sender.srcElement.tagName == "A") //verifica si el click es a un elemento de tipo hipervinculo
        {
            //alert(guardado); //test. muestra el valor de la vble
            if (!guardado) //si no ha guardado los cambios muestra mensaje de alerta
            {
               return confirm('Si continua puede perder los cambios realizados a la orden de trabajo. Esta seguro de continuar?');
            }
        }
}
//maneja el evento keypress
function doMainKeypress(sender, keyEventArgs){
        guardado = false;
}

//adjunta los eventhandler
document.attachEvent("onclick", doMainClick);
document.attachEvent("onkeypress", doMainKeypress);