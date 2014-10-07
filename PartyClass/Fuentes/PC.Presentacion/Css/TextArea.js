// JScript File

function TamañoTextArea(control,limiteTamaño)
{
  
    var str; 
    str = document.getElementById(control).value;
   
        if(str.length>limiteTamaño)
        {
             document.getElementById(control).value = str.substring(0,limiteTamaño);
             return true;
        }
}
function TamañoTextAreaClick(limiteTamaño)
{
  
    var str; 
    str = window.clipboardData.getData("Text");
   
        if(str.length>limiteTamaño)
        {
             document.getElementById(control).value = str.substring(0,limiteTamaño);
             return true;
        }
}

