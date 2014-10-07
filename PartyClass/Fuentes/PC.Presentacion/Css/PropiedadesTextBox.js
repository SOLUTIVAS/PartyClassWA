// JScript File

function ValidarNumeros()
{
      // Restringir sólo números
      if(event.shiftKey || event.altKey) event.returnValue = false;
      
      if(event.keyCode == 13 || //Enter 
         event.keyCode == 8  || //Backspace
         event.keyCode == 9  || //Tab
         event.keyCode == 46 || //Supr
         event.keyCode == 35  || //Fin
         event.keyCode == 36  || //Inicio
         (event.keyCode >= 37 && event.keyCode <= 40) || //Flechas
         (event.keyCode >= 48 && event.keyCode <= 57) || //Números Alfanúmerico
         (event.keyCode >= 96 && event.keyCode <= 105)) //Números Númerico
            return;
      else
            event.returnValue = false;
}
function ValidarNumerosDecimales(objeto)
{
    if(ValidarIngresoSeparadorDecimales(event.keyCode,objeto) || ValidarNumeros())
        return;
}

function ValidarIngresoSeparadorDecimales(codigo,objeto)
{
//,->188 .->190 .->110
    if(codigo!=188)
        return false;

    if(objeto.value.indexOf(",")<0)
        return true;
    else
        return false;
}

function validarEntero()
{ 
      //intento convertir a entero. 
     //si era un entero no le afecta, si no lo era lo intenta convertir 
     var valorApegar=window.clipboardData.getData("Text");
     var valor = parseInt(valorApegar) 

      //Compruebo si es un valor numérico 
      if (isNaN(valor))
      { 
     // alert("hola False");
          return false;      
      }
      else
      { 
            //En caso contrario (Si era un número) devuelvo el valor 
          //  alert("");
           return true;
          
          
      } 
} 

function ValidarCarasteresPermitidos(control)
{
	var string = document.getElementById(control).value;
	var filter =/[&#<>~]+/;
	
	if (string.length == 0 )
	{
			return true;
	}
	else
	{
		if (filter.test(string))
		{
			alert('La cadena de texto ingresada en el control\ncontiene caracteres no permitidos.');
			document.getElementById(control).focus();
			return false;
		}
		else
		{
			return true;
		}
	}
}
 
