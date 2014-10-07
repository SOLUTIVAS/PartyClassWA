//Documentación
//-------------------------------------------------------------------------
//Nombre del Archivo : Accidente.cs
//Proyecto           : Datos

//Autor              : Andrés Julián Chalarca Escoabar (AJCHE)
//Fecha Creación     : 02/15/2013

//Descripcion        : Clase que interactúa con la tabla tbl_Clientes de la base de datos TourColombia

//Modificaciones     : Nombre_Completo_A - INICIALES_COMPLETAS - yyyy/mm/dd
//                     Nombre_Completo_B - INICIALES_COMPLETAS - yyyy/mm/dd
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Datos
{
    public class Accidente
    {
        public string StoreProcedure = "sp_ObtenerAccidentes";
        Database db;
        
        public Accidente()
        {
        }

        public DataSet obtenerAccidente()
        {
            db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.StoredProcedure, StoreProcedure);             
        }
    }
}
