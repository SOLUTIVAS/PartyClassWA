using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data.Common;
using Comun.EntidadesNegocio;

namespace Datos
{
    public class Autenticacion
    {
        Database db;

        public Autenticacion()
        {
            db = DatabaseFactory.CreateDatabase ("ConStringProd");
        }

        public string validarUsuario(string usuario, string password)
        {
            string sql = "PC.SP_PCAutenticarUsuarios";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            db.AddInParameter(cmd, "Usuario", DbType.String, usuario);
            db.AddInParameter(cmd, "Password", DbType.String, password);

            object resultado = db.ExecuteScalar(cmd).ToString();
            if (resultado == null)
            {
                return string.Empty;
            }
            else
            {
                return resultado.ToString();
            }
        }


        public Usuario validarUsuario(Usuario oUsuario, ref List<string> lstResultados)
        {
            string sql = "PC.SP_PCAutenticarUsuarios";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            db.AddInParameter(cmd, "Usuario", DbType.String, oUsuario.Username);
            db.AddInParameter(cmd, "Password", DbType.String, oUsuario.Password);

            db.AddOutParameter(cmd, "Nombres", DbType.String, 50);
            db.AddOutParameter(cmd, "Apellidos", DbType.String, 50);
            db.AddOutParameter(cmd, "Cargo", DbType.String, 50);
            db.AddOutParameter(cmd, "Cedula", DbType.Double, 100);
            db.AddOutParameter(cmd, "Email", DbType.String, 100);
            db.AddOutParameter(cmd, "idUsuario", DbType.Double, 1);
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Byte, 1);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);            

            if (Exito == "1")
            {
                oUsuario.Nombres = Convert.ToString(db.GetParameterValue(cmd, "Nombres"));
                oUsuario.Apellidos = Convert.ToString(db.GetParameterValue(cmd, "Apellidos"));
                oUsuario.Cargo = Convert.ToString(db.GetParameterValue(cmd, "Cargo"));
                oUsuario.Cedula = Convert.ToDouble(db.GetParameterValue(cmd, "Cedula"));
                oUsuario.Email = Convert.ToString(db.GetParameterValue(cmd, "Email"));
                oUsuario.idUsuario = Convert.ToDouble(db.GetParameterValue(cmd, "idUsuario"));
            }            

            return oUsuario;
        }
    }
}
