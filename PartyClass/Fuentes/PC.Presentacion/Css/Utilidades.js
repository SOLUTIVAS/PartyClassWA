// JScript File
function MostrarModificarCuadrillaOT(idsOrdenesTrabajo,idTipoSolicitud)
{

ALert("Hola");
	var windowValue;
	var page =  "OrdenesDeTrabajo/ModificarCuadrillasOT.aspx"
	var options = "dialogHeight: 1024px; dialogWidth:768px; edge: raised; center: yes; help: no; resizable: no; status: no; scroll: yes; ";
	window.showModalDialog(page + "?idOrdenesTrabajo=" + idsOrdenesTrabajo+"&idTipoSolicitud="+idTipoSolicitud,null,options);
}
