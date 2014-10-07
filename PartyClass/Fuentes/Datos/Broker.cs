using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Comun;
using Comun.EntidadesNegocio;
using Comun.TO;

namespace Datos
{
    public class Broker
    {
        Database db;

        public Broker()
        {
            db = DatabaseFactory.CreateDatabase ("ConStringProd");
        }

        #region Consultas Aquí se agrupan todos los métodos que hacen consultas a la base de datos

        public List<Registro> ConsultarRegistro(Registro oParRegistro, ref List<string> lstResultados)
        {
            List<Registro> lstRegistro = new List<Registro>();
            Registro oRegistro;
            DbCommand cmd = db.GetStoredProcCommand ("TC.SP_ConsultarRegistros");

            db.AddInParameter(cmd, "Estado", DbType.String, oParRegistro.Estado);
            db.AddInParameter(cmd, "idEvento", DbType.Double, oParRegistro.idEvento);

            DataSet ds = db.ExecuteDataSet(cmd);           

            lstResultados.Add("1");
            lstResultados.Add("1");
            lstResultados.Add("Operación Exitosa");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oRegistro = new Registro();
                oRegistro.idRegistro = Convert.ToDouble(dr[0]);
                oRegistro.Documento = dr[1] == DBNull.Value ? 0 : Convert.ToDouble(dr[1]);
                oRegistro.Nombres = Convert.ToString(dr[2]);
                oRegistro.Apellidos = Convert.ToString(dr[3]);
                oRegistro.Celular = Convert.ToString(dr[4]);
                oRegistro.Email = Convert.ToString(dr[5]);
                oRegistro.Estado = Convert.ToString(dr[6]);
                oRegistro.idMunicipio = Convert.ToInt32(dr[7]);
                oRegistro.RequiereHotel = Convert.ToBoolean(dr[8]);

                oRegistro.FechaCkeckInHotel = dr[9] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[9]);
                oRegistro.FechaCheckOutHotel = dr[10] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[10]);
                oRegistro.TipoAcomodacion = dr[11] == DBNull.Value ? string.Empty : Convert.ToString(dr[11]);
                oRegistro.RequierePasajes = Convert.ToBoolean(dr[12]);
                oRegistro.LugarSalida = dr[13] == DBNull.Value ? string.Empty : Convert.ToString(dr[13]);
                oRegistro.FechaSalidaPasajes = dr[14] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[14]);
                oRegistro.FechaRegresoPasajes = dr[15] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[15]);
                oRegistro.Observaciones = dr[17] == DBNull.Value ? string.Empty : Convert.ToString(dr[17]);
                oRegistro.FechaRegistro = dr[18] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[18]);
                oRegistro.idCliente = dr[18] == DBNull.Value ? 0 : Convert.ToDouble(dr[19]);

                lstRegistro.Add(oRegistro);
            }

            return lstRegistro;            
        }

        public List<CientePorEventoTO> obtenerDetalleEventoTO(CientePorEventoTO datosFiltro)
        {
            List<CientePorEventoTO> lstClientes = new List<CientePorEventoTO>();

            double documento = -1;
            double hotel = -1;
            if (datosFiltro.idHotel > 0)
            {
                hotel = Convert.ToDouble(datosFiltro.idHotel);
            }

            if (datosFiltro.Documento > 0)
            {
                documento = Convert.ToDouble(datosFiltro.Documento);
            }

            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarClientesPorEvento");

            db.AddInParameter(cmd, "idEvento", DbType.Double, Convert.ToDouble(datosFiltro.idEvento));
            db.AddInParameter(cmd, "Documento", DbType.Double, documento);
            db.AddInParameter(cmd, "Nombres", DbType.String, datosFiltro.Nombres);
            db.AddInParameter(cmd, "Apellidos", DbType.String, datosFiltro.Apellidos);
            db.AddInParameter(cmd, "idHotel", DbType.Double, hotel);
            db.AddInParameter(cmd, "idorganizacion", DbType.Double, datosFiltro.idOrganizacion);
            db.AddInParameter(cmd, "idcargo", DbType.Int32, datosFiltro.idCargo);
            db.AddInParameter(cmd, "iddepartamento", DbType.Int32, datosFiltro.idDepartamento);
            db.AddInParameter(cmd, "idmunicipio", DbType.Int32, datosFiltro.idMunicipio);
            db.AddInParameter(cmd, "idUsuario", DbType.Double, datosFiltro.idUsuario);


            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CientePorEventoTO row = new CientePorEventoTO();

                row.idDetalleEvento =       Convert.ToDouble(dr["idDetalleEvento"]);
                row.idPasajeAereo =         dr["idPasajeAereo"] == DBNull.Value ? 0 : Convert.ToDouble(dr["idPasajeAereo"]);
                row.idAsignacionHotel =     dr["idAsignacionHotel"] == DBNull.Value ? 0 : Convert.ToDouble(dr["idAsignacionHotel"]);
                row.TipoEvento =            dr["TipoEvento"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TipoEvento"]);
                row.NomreEvento =           dr["NombreEvento"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreEvento"]);
                row.Documento =             dr["Documento"] == DBNull.Value ? (double?)null : Convert.ToDouble(dr["Documento"]);
                row.Nombres =               dr["Nombres"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Nombres"]);
                row.Apellidos =             dr["Apellidos"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Apellidos"]);
                row.Cargo =                 Convert.ToString(dr["Cargo"]);
                row.Departamento =          Convert.ToString(dr["Departamento"]);
                row.Municipio =             Convert.ToString(dr["Municipio"]);
                row.Organizacion =          Convert.ToString(dr["Organizacion"]);
                row.FechaCheckIn_Hotel =    dr["FechaCheckIn_Hotel"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaCheckIn_Hotel"]);
                row.FechaCheckOut_Hotel =   dr["FechaCheckOut_Hotel"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaCheckOut_Hotel"]);
                row.NroHab =                dr["NroHab"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NroHab"]);
                row.NombreCama =            dr["Cama"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Cama"]);
                row.PrecioAsignacionHotel = dr["PrecioAsignacionHotel"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PrecioAsignacionHotel"]);
                row.Acommodacion =          dr["Acommodacion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Acommodacion"]);
                row.NombreHotel =           dr["NombreHotel"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreHotel"]);
                row.ObservacionesHotel =    dr["ObservacionesHotel"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ObservacionesHotel"]);
                row.FechaRegistroEvento =   Convert.ToDateTime(dr["FechaRegistroEvento"]);
                row.idEvento =              Convert.ToDouble(dr["idEvento"]);
                row.idHotel =               dr["idHotel"] == DBNull.Value ? (double?)null : Convert.ToDouble(dr["idHotel"]);
                row.idCama =                dr["idCama"] == DBNull.Value ? (double?)null : Convert.ToDouble(dr["idCama"]);
                row.Pazysalvo =             Convert.ToBoolean(dr["Pazysalvo"]);
                row.Aerolinea =             dr["Aerolinea"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Aerolinea"]);
                row.CiudadOrigen =          dr["CiudadOrigen"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CiudadOrigen"]);
                row.CiudadDestino =         dr["CiudadDestino"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CiudadDestino"]);
                row.FechaSalidaVuelo =      dr["FechaSalida"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaSalida"]);
                row.FechaRegresoVuelo =     dr["FechaRegreso"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaRegreso"]);
                row.PrecioVentaPasaje =     dr["PrecioVenta"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PrecioVenta"]);
                row.CodigoPasaje =          dr["CodigoPasaje"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CodigoPasaje"]);
                row.Clase =                 dr["Clase"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Clase"]);
                row.Avion =                 dr["Avion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Avion"]);
                row.ObservacionesPasajes =  dr["ObservacionesPasaje"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ObservacionesPasaje"]);
                row.NombreUsuario =         dr["Usuario"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Usuario"]);

                lstClientes.Add(row);
            }

            return lstClientes;
        }

        public List<DisponibilidadHotel> obtenerDisponibiliad(DisponibilidadHotel filtros, ref List<string> lstResultados)
        {
            double hotel = -1;
            if (filtros.idHotel > 0)
            {
                hotel = Convert.ToDouble (filtros.idHotel);
            }

            List<DisponibilidadHotel> lstDisponibilidadHotel = new List<DisponibilidadHotel>();
            DbCommand cmd = db.GetStoredProcCommand ("TC.SP_ConsultarDisponibilidad");

            db.AddInParameter(cmd, "p_idEvento", DbType.Double, Convert.ToDouble(filtros.idEvento));
            db.AddInParameter (cmd, "p_idHotel", DbType.Double, hotel);
            
            DataSet ds = db.ExecuteDataSet (cmd);

            lstResultados.Add ("1");
            lstResultados.Add ("1");
            lstResultados.Add ("Operación Exitosa");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DisponibilidadHotel row = new DisponibilidadHotel ();
                row.idEvento = Convert.ToDouble (dr["idEvento"]);
                row.FechaInicio = dr["FechaInicio"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime (dr["FechaInicio"]);
                row.FechaFin = dr["FechaFin"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime (dr["FechaFin"]);
                row.NombreHotel = Convert.ToString (dr["NombreHotel"]);
                row.NroHabitacion = Convert.ToString (dr["NroHabitacion"]);
                row.Acomodacion = Convert.ToString (dr["Acomodacion"]);
                row.CamasPorHabitacion = Convert.ToInt32 (dr["CamasPorHabitacion"]);
                row.CamasDisponibles = dr["CamasDisponibles"] == DBNull.Value ? (int?) null : Convert.ToInt32 (dr["CamasDisponibles"]);
                row.CamasOcupadas = dr["CamasOcupadas"] == DBNull.Value ? (int?) null : Convert.ToInt32 (dr["CamasOcupadas"]);
                row.idHotel = dr["idHotel"] == DBNull.Value ? (double?) null : Convert.ToDouble (dr["idHotel"]);

                lstDisponibilidadHotel.Add (row);
            }
            return lstDisponibilidadHotel;
        }

        public List<NoRegistrados> ConsultarNoRegistradosPorEvento(double idEvento, double? documento, string nombres, string Apellidos, char? Sexo, ref List<string> lstResultados)
        {
            if (documento == null)
            {
                documento = -1;
            }

            List<NoRegistrados> lstRegistro = new List<NoRegistrados>();
            NoRegistrados row;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarNoRegistrados");

            db.AddInParameter(cmd, "idEvento", DbType.Double, idEvento);
            db.AddInParameter(cmd, "Documento", DbType.Double, documento);
            db.AddInParameter(cmd, "Nombres", DbType.String, nombres);
            db.AddInParameter(cmd, "Apellidos", DbType.String, Apellidos);
            db.AddInParameter(cmd, "Sexo", DbType.Byte, Sexo);

            DataSet ds = db.ExecuteDataSet(cmd);

            lstResultados.Add("1");
            lstResultados.Add("1");
            lstResultados.Add("Operación Exitosa");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new NoRegistrados();

                row.Documento = dr["Documento"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Documento"]);
                row.idCliente = Convert.ToDouble(dr["idCliente"]);
                row.Nombres = dr["Nombres"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Nombres"]);
                row.Apellidos = dr["Apellidos"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Apellidos"]);
                row.Sexo = dr["Sexo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Sexo"]);
                row.Email = dr["Email"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Email"]);
                row.Direccion = dr["Direccion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Direccion"]);
                row.Estudios = dr["Estudios"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Estudios"]);
                row.Idiomas = dr["Idiomas"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Idiomas"]);
                row.Visas = dr["Visas"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Visas"]);
                row.EstadoCivil = dr["EstadoCivil"] == DBNull.Value ? string.Empty : Convert.ToString(dr["EstadoCivil"]);
                row.Hijos = dr["Hijos"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Hijos"]);

                lstRegistro.Add(row);
            }
            return lstRegistro;
        }

        public List<NoRegistrados> ConsultarNoRegistradosPorEvento(ClienteTO datosFiltro, ref List<string> lstResultados)
        {
            if (datosFiltro.Documento == 0)
            {
                datosFiltro.Documento = -1;
            }

            List<NoRegistrados> lstRegistro = new List<NoRegistrados>();
            NoRegistrados row;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarNoRegistrados");

            db.AddInParameter(cmd, "idEvento", DbType.Double, datosFiltro.idEvento);

            if (datosFiltro.Documento != -1)
                db.AddInParameter(cmd, "documento", DbType.Double, Convert.ToDouble(datosFiltro.Documento));
            if (Convert.ToString(datosFiltro.Nombres) != string.Empty)
                db.AddInParameter(cmd, "nombres", DbType.String, Convert.ToString(datosFiltro.Nombres));
            if (Convert.ToString(datosFiltro.Apellidos) != string.Empty)
                db.AddInParameter(cmd, "apellidos", DbType.String, Convert.ToString(datosFiltro.Apellidos));
            if (datosFiltro.idCargo != -1)
                db.AddInParameter(cmd, "idcargo", DbType.Int64, Convert.ToInt64(datosFiltro.idCargo));
            if (datosFiltro.idDepartamento != -1)
                db.AddInParameter(cmd, "iddepartamento", DbType.Int64, Convert.ToInt64(datosFiltro.idDepartamento));
            if (datosFiltro.idMunicipio != -1)
                db.AddInParameter(cmd, "idmunicipio", DbType.Int64, Convert.ToInt64(datosFiltro.idMunicipio));
            if (datosFiltro.idOrganizacion != -1)
                db.AddInParameter(cmd, "idorganizacion", DbType.Int64, Convert.ToInt64(datosFiltro.idOrganizacion));
            
            DataSet ds = db.ExecuteDataSet(cmd);

            lstResultados.Add("1");
            lstResultados.Add("1");
            lstResultados.Add("Operación Exitosa");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new NoRegistrados();

                row.Documento =         dr["Documento"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Documento"]);
                row.idCliente =         Convert.ToDouble(dr["idCliente"]);
                row.Nombres =           dr["Nombres"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Nombres"]);
                row.Apellidos =         dr["Apellidos"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Apellidos"]);
                row.Cargo =             dr["Cargo"] == DBNull.Value? string.Empty : Convert.ToString(dr["Cargo"]);
                row.Departamento =      dr["Departamento"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Departamento"]);
                row.Municipio =         dr["Municipio"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Municipio"]);
                row.Organizacion =      dr["Organizacion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Organizacion"]);
                row.Email =             dr["Email"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Email"]);
                row.Direccion =         dr["Direccion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Direccion"]);
                row.Estudios =          dr["Estudios"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Estudios"]);
                row.Idiomas =           dr["Idiomas"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Idiomas"]);
                row.Visas =             dr["Visas"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Visas"]);
                row.EstadoCivil =       dr["EstadoCivil"] == DBNull.Value ? string.Empty : Convert.ToString(dr["EstadoCivil"]);
                row.Hijos =             dr["Hijos"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Hijos"]);

                lstRegistro.Add(row);
            }
            return lstRegistro;
        }

        public List<Evento> ObtenerEvento(int idEvento, bool? activo)
        {
            List<Evento> lstEvento = new List<Evento>();
            Evento oEvento;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarEvento");

            if (idEvento != 0)
            {
                db.AddInParameter(cmd, "idEvento", DbType.Double, idEvento);
            }
            if (activo != null)
            {
                db.AddInParameter(cmd, "activo", DbType.Boolean, activo);
            }

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oEvento = new Evento();
                oEvento.idEvento = Convert.ToDouble(dr["idEvento"]);
                oEvento.idTipoEvento = dr["idTipoEvento"] == DBNull.Value ? 0 : Convert.ToInt32(dr["idTipoEvento"]);
                oEvento.Descripcion = Convert.ToString(dr["Descripcion"]);
                oEvento.Ciudad = Convert.ToString(dr["Ciudad"]);
                oEvento.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                oEvento.FechaFin = Convert.ToDateTime(dr["FechaFin"]);
                oEvento.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                oEvento.FechaLimiteInscripcion = dr["FechaLimiteInscripcion"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["FechaLimiteInscripcion"]);
                oEvento.Activo = Convert.ToBoolean(dr["Activo"]);
                lstEvento.Add(oEvento);
            }
            return lstEvento;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lstUsuario = new List<Usuario>();
            Usuario oUsuario;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarUsuario");

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oUsuario = new Usuario();
                oUsuario.Nombres = Convert.ToString(dr["Nombres"]);
                oUsuario.Apellidos = Convert.ToString(dr["Apellidos"]);
                oUsuario.Cargo = Convert.ToString(dr["Cargo"]);
                oUsuario.Username = Convert.ToString(dr["Usuario"]);
                oUsuario.Cedula = dr["Cedula"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Cedula"]);
                oUsuario.Email = Convert.ToString(dr["Email"]);
                oUsuario.idUsuario = Convert.ToDouble(dr["idUsuario"]);
                lstUsuario.Add(oUsuario);
            }
            return lstUsuario;
        }

        public List<DisponibilidadReservaHotel> ConsultarDisponibilidadHabitacion (double idEvento, double? idHotel, int? tipoHabitacion)
        {
            List<DisponibilidadReservaHotel> lstDisponibilidad = new List<DisponibilidadReservaHotel> ();
            DbCommand cmd = db.GetStoredProcCommand ("TC.SP_ConsultarDisponibilidadHabitacion");

            db.AddInParameter (cmd, "idEvento", DbType.Double, idEvento);
            db.AddInParameter (cmd, "idHotel", DbType.Double, idHotel);
            db.AddInParameter (cmd, "idTipoHabitacion", DbType.Int32, tipoHabitacion);

            DataSet ds = db.ExecuteDataSet (cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DisponibilidadReservaHotel oDisponibilidad = new DisponibilidadReservaHotel
                                                           {
                                                               NombreHotel = Convert.ToString(dr["hotel"]), 
                                                               NumeroHabitacion = Convert.ToString(dr["numHabitacion"]),
                                                               Acomodacion = Convert.ToString (dr["acomodacion"]),
                                                               IdCama = Convert.ToInt32(dr["idCama"]),
                                                               NumeroCama = Convert.ToString(dr["numCama"]), 
                                                               CamaDisponible = Convert.ToString(dr["camaDisponible"]),
                                                               ReservadoPor = Convert.ToString (dr["reservadoPor"]),
                                                               Disponible = Convert.ToBoolean (dr["disponible"]),
                                                               Precio = Convert.ToDouble(dr["Precio"])
                                                           };

                lstDisponibilidad.Add(oDisponibilidad);
            }

            return lstDisponibilidad;    
        }

        public List<ClienteTO> obtenerListaCliente(ClienteTO oCliente, Funcionario oFuncionario)
        {
            List<ClienteTO> lstCliente = new List<ClienteTO>();
            string sql;
            sql = "TC.SP_ConsultarClientes";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            if (oCliente.Documento != 0)
                db.AddInParameter(cmd, "documento", DbType.Double, Convert.ToDouble(oCliente.Documento));
            if (Convert.ToString(oCliente.Nombres) != string.Empty)
                db.AddInParameter(cmd, "nombres", DbType.String, Convert.ToString(oCliente.Nombres));
            if (Convert.ToString(oCliente.Apellidos) != string.Empty)
                db.AddInParameter(cmd, "apellidos", DbType.String, Convert.ToString(oCliente.Apellidos));
            if (oFuncionario.idCargo != 0)
                db.AddInParameter(cmd, "idcargo", DbType.Int64, Convert.ToInt64(oFuncionario.idCargo));
            if (oFuncionario.idDepartamento != 0)
                db.AddInParameter(cmd, "iddepartamento", DbType.Int64, Convert.ToInt64(oFuncionario.idDepartamento));
            if (oFuncionario.idMunicipio != 0)
                db.AddInParameter(cmd, "idmunicipio", DbType.Int64, Convert.ToInt64(oFuncionario.idMunicipio));
            if (oCliente.idEvento != 0)
                db.AddInParameter(cmd, "idEvento", DbType.Double, Convert.ToDouble(oCliente.idEvento));

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ClienteTO objCliente = new ClienteTO();
                objCliente.Documento = dr["Documento"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Documento"]);
                objCliente.LugarExpedicion = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objCliente.Nombres = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                objCliente.Apellidos = dr[3] == DBNull.Value ? string.Empty : Convert.ToString(dr[3]);
                objCliente.FechaNacimiento = dr[4] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[4]);
                objCliente.CiudadNacimiento = dr[5] == DBNull.Value ? string.Empty : Convert.ToString(dr[5]);
                objCliente.Sexo = dr[6] == DBNull.Value ? '0' : Convert.ToChar(dr[6]);
                objCliente.TipoSangre = dr[7] == DBNull.Value ? string.Empty : Convert.ToString(dr[7]);
                objCliente.TallaCamiseta = dr[8] == DBNull.Value ? string.Empty : Convert.ToString(dr[8]);
                objCliente.Email = dr[9] == DBNull.Value ? string.Empty : Convert.ToString(dr[9]);
                objCliente.Direccion = dr[10] == DBNull.Value ? string.Empty : Convert.ToString(dr[10]);
                objCliente.Estudios = dr[11] == DBNull.Value ? string.Empty : Convert.ToString(dr[11]);
                objCliente.Idiomas = dr[12] == DBNull.Value ? string.Empty : Convert.ToString(dr[12]);
                objCliente.Visas = dr[13] == DBNull.Value ? string.Empty : Convert.ToString(dr[13]);
                objCliente.EstadoCivil = dr[14] == DBNull.Value ? string.Empty : Convert.ToString(dr[14]);
                objCliente.Hijos = dr[15] == DBNull.Value ? 0 : Convert.ToInt32(dr[15]);
                objCliente.FechaRegistro = dr[16] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[16]);

                objCliente.Cargo = dr[17] == DBNull.Value ? string.Empty : Convert.ToString(dr[17]);
                objCliente.Municipio = dr[18] == DBNull.Value ? string.Empty : Convert.ToString(dr[18]);
                objCliente.Departamento = dr[19] == DBNull.Value ? string.Empty : Convert.ToString(dr[19]);
                objCliente.idCliente = dr["idCliente"] == DBNull.Value ? 0 : Convert.ToDouble(dr["idCliente"]);
                objCliente.idMunicipio = dr["idMunicipio"] == DBNull.Value ? 0 : Convert.ToInt32(dr["idMunicipio"]);
                objCliente.idDepartamento = dr["idDepartamento"] == DBNull.Value ? 0 : Convert.ToInt32(dr["idDepartamento"]);
                objCliente.CiudadResidencia = dr["CiudadResidencia"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CiudadResidencia"]);
                objCliente.Telefonos = dr["TelefonoFijo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TelefonoFijo"]);
                if (dr["TelefonoCelular"] != DBNull.Value)
                {
                    objCliente.Telefonos += objCliente.Telefonos.Length > 0 ? " - " : string.Empty;
                    objCliente.Telefonos += dr["TelefonoCelular"];
                }                

                objCliente.oFuncionario = new Funcionario();

                objCliente.oFuncionario.Asistente = dr["Asistente"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Asistente"]);
                objCliente.oFuncionario.Asociacion = dr["Asociacion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Asociacion"]);
                objCliente.oFuncionario.idCargo = dr["IdCargo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdCargo"]);
                objCliente.oFuncionario.Observaciones = dr["Observaciones"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Observaciones"]);
                objCliente.oFuncionario.PartidoPolitico = dr["PartidoPolitico"] == DBNull.Value ? string.Empty : Convert.ToString(dr["PartidoPolitico"]);
                objCliente.oFuncionario.Periodo = dr["Periodo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Periodo"]);
                objCliente.oFuncionario.Documento = dr["idClienteFuncionario"] == DBNull.Value ? 0 : Convert.ToDouble(dr["idClienteFuncionario"]);
                objCliente.oFuncionario.idOrganizacion = dr["idOrganizacion"] == DBNull.Value ? 0 : Convert.ToDouble(dr["idOrganizacion"]);

                lstCliente.Add(objCliente);
            }
            return lstCliente;
        }

        public List<ClienteTO> obtenerListaClienteLlamadas(Cliente oCliente, Funcionario oFuncionario)
        {
            List<ClienteTO> lstCliente = new List<ClienteTO>();
            string sql;
            sql = "TC.SP_ConsultarClientesLlamadas";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            if (oCliente.Documento != 0)
                db.AddInParameter(cmd, "documento", DbType.Double, Convert.ToDouble(oCliente.Documento));
            if (Convert.ToString(oCliente.Nombres) != string.Empty)
                db.AddInParameter(cmd, "nombres", DbType.String, Convert.ToString(oCliente.Nombres));
            if (Convert.ToString(oCliente.Apellidos) != string.Empty)
                db.AddInParameter(cmd, "apellidos", DbType.String, Convert.ToString(oCliente.Apellidos));
            if (oFuncionario.idCargo != 0)
                db.AddInParameter(cmd, "idcargo", DbType.Int64, Convert.ToInt64(oFuncionario.idCargo));
            if (oFuncionario.idDepartamento != 0)
                db.AddInParameter(cmd, "iddepartamento", DbType.Int64, Convert.ToInt64(oFuncionario.idDepartamento));
            if (oFuncionario.idMunicipio != 0)
                db.AddInParameter(cmd, "idmunicipio", DbType.Int64, Convert.ToInt64(oFuncionario.idMunicipio));
            if (oFuncionario.idOrganizacion != 0)
                db.AddInParameter(cmd, "idorganizacion", DbType.Int64, Convert.ToInt64(oFuncionario.idOrganizacion));

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ClienteTO objCliente = new ClienteTO();
                objCliente.Documento = dr["Documento"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Documento"]);
                objCliente.LugarExpedicion = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objCliente.Nombres = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                objCliente.Apellidos = dr[3] == DBNull.Value ? string.Empty : Convert.ToString(dr[3]);
                objCliente.FechaNacimiento = dr[4] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[4]);
                objCliente.CiudadNacimiento = dr[5] == DBNull.Value ? string.Empty : Convert.ToString(dr[5]);
                objCliente.Sexo = dr[6] == DBNull.Value ? '0' : Convert.ToChar(dr[6]);
                objCliente.TipoSangre = dr[7] == DBNull.Value ? string.Empty : Convert.ToString(dr[7]);
                objCliente.TallaCamiseta = dr[8] == DBNull.Value ? string.Empty : Convert.ToString(dr[8]);
                objCliente.Email = dr[9] == DBNull.Value ? string.Empty : Convert.ToString(dr[9]);
                objCliente.Direccion = dr[10] == DBNull.Value ? string.Empty : Convert.ToString(dr[10]);
                objCliente.Estudios = dr[11] == DBNull.Value ? string.Empty : Convert.ToString(dr[11]);
                objCliente.Idiomas = dr[12] == DBNull.Value ? string.Empty : Convert.ToString(dr[12]);
                objCliente.Visas = dr[13] == DBNull.Value ? string.Empty : Convert.ToString(dr[13]);
                objCliente.EstadoCivil = dr[14] == DBNull.Value ? string.Empty : Convert.ToString(dr[14]);
                objCliente.Hijos = dr[15] == DBNull.Value ? 0 : Convert.ToInt32(dr[15]);
                objCliente.FechaRegistro = dr[16] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[16]);

                objCliente.Cargo = dr[17] == DBNull.Value ? string.Empty : Convert.ToString(dr[17]);
                objCliente.Municipio = dr[18] == DBNull.Value ? string.Empty : Convert.ToString(dr[18]);
                objCliente.Departamento = dr[19] == DBNull.Value ? string.Empty : Convert.ToString(dr[19]);
                objCliente.idCliente = dr["idCliente"] == DBNull.Value ? 0 : Convert.ToDouble(dr["idCliente"]);
                objCliente.FechaUltLlamada = dr["FechaUltLlamada"] == DBNull.Value ? string.Empty : Convert.ToString(dr["FechaUltLlamada"]);

                lstCliente.Add(objCliente);
            }
            return lstCliente;
        }

        public List<ClienteTO> obtenerListaCliente(ClienteTO oCliente)
        {
            List<ClienteTO> lstCliente = new List<ClienteTO>();
            string sql = "TC.SP_ConsultarClientes";
            DbCommand cmd = db.GetStoredProcCommand(sql);
            
            if (oCliente.Documento != 0)
                db.AddInParameter(cmd, "documento", DbType.Double, Convert.ToDouble(oCliente.Documento));
            if (Convert.ToString(oCliente.Nombres) != string.Empty)
                db.AddInParameter(cmd, "nombres", DbType.String, Convert.ToString(oCliente.Nombres));
            if (Convert.ToString(oCliente.Apellidos) != string.Empty)
                db.AddInParameter(cmd, "apellidos", DbType.String, Convert.ToString(oCliente.Apellidos));
            //if (oCliente.idOrganizacion != 0)
            //    db.AddInParameter(cmd, "idorganizacion", DbType.Double, Convert.ToDouble(oCliente.idOrganizacion));
            //if (oCliente.idCargo != 0)
            //    db.AddInParameter(cmd, "idcargo", DbType.Int64, Convert.ToInt64(oCliente.idCargo));

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ClienteTO objCliente = new ClienteTO();
                objCliente.Documento = dr[0] == DBNull.Value ? 0 : Convert.ToDouble(dr[0]);
                objCliente.LugarExpedicion = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objCliente.Nombres = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                objCliente.Apellidos = dr[3] == DBNull.Value ? string.Empty : Convert.ToString(dr[3]);
                //objCliente.idOrganizacion = dr[4] == DBNull.Value ? 0 : Convert.ToDouble(dr[4]);
                objCliente.FechaNacimiento = dr[5] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[5]);
                objCliente.CiudadNacimiento = dr[6] == DBNull.Value ? string.Empty : Convert.ToString(dr[6]);
                //objCliente.Asistente = dr[7] == DBNull.Value ? string.Empty : Convert.ToString(dr[7]);
                //objCliente.Periodo = dr[8] == DBNull.Value ? string.Empty : Convert.ToString(dr[8]);
                objCliente.Sexo = dr[9] == DBNull.Value ? '0' : Convert.ToChar(dr[9]);
                objCliente.TipoSangre = dr[10] == DBNull.Value ? string.Empty : Convert.ToString(dr[10]);
                //objCliente.PresidenteCapCE = dr[12] == DBNull.Value ? '0' : Convert.ToChar(dr[12]);
                //objCliente.idCargo = dr[13] == DBNull.Value ? 0 : Convert.ToInt32(dr[13]);
                //objCliente.ConsejoEjecutivo = dr[14] == DBNull.Value ? string.Empty : Convert.ToString(dr[14]);
                objCliente.TallaCamiseta = dr[15] == DBNull.Value ? string.Empty : Convert.ToString(dr[15]);
                objCliente.PinBB = dr[16] == DBNull.Value ? string.Empty : Convert.ToString(dr[16]);
                objCliente.Email = dr[17] == DBNull.Value ? string.Empty : Convert.ToString(dr[17]);
                objCliente.Direccion = dr[18] == DBNull.Value ? string.Empty : Convert.ToString(dr[18]);
                objCliente.Estudios = dr[19] == DBNull.Value ? string.Empty : Convert.ToString(dr[19]);
                objCliente.Idiomas = dr[20] == DBNull.Value ? string.Empty : Convert.ToString(dr[20]);
                objCliente.Visas = dr[21] == DBNull.Value ? string.Empty : Convert.ToString(dr[21]);
                objCliente.EstadoCivil = dr[22] == DBNull.Value ? string.Empty : Convert.ToString(dr[22]);
                objCliente.Hijos = dr[23] == DBNull.Value ? 0 : Convert.ToInt32(dr[23]);
                //objCliente.PeriodosAnteriorAlcalde = dr[24] == DBNull.Value ? string.Empty : Convert.ToString(dr[24]);
                //objCliente.Votacion = dr[25] == DBNull.Value ? string.Empty : Convert.ToString(dr[25]);
                //objCliente.PartidoPolitico = dr[26] == DBNull.Value ? string.Empty : Convert.ToString(dr[26]);
                //objCliente.Asociacion = dr[27] == DBNull.Value ? string.Empty : Convert.ToString(dr[27]);
                objCliente.FechaRegistro = dr[28] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[28]);
                lstCliente.Add(objCliente);
            }
            return lstCliente;
        }

        public List<Departamento> obtenerDepartamento(int idDepartamento)
        {
            string sql = "TC.SP_ConsultarDepartamento";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            List<Departamento> lstDepartamento = new List<Departamento>();

            if (idDepartamento != 0)
                db.AddInParameter(cmd, "idDepartamento", DbType.Int32, idDepartamento);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Departamento objDepartamento = new Departamento();
                objDepartamento.idDepartamento = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]);
                objDepartamento.Descripcion = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objDepartamento.Estado = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                lstDepartamento.Add(objDepartamento);
            }
            return lstDepartamento;
        }

        public List<Cargo> obtenerCargo(int idCargo)
        {
            string sql = "TC.SP_ConsultarCargo";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            List<Cargo> lstCargo = new List<Cargo>();

            if (idCargo != 0)
                db.AddInParameter(cmd, "idCargo", DbType.Int32, idCargo);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Cargo objCargo = new Cargo();
                objCargo.Id = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]);
                objCargo.Descripcion = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                objCargo.Nombre = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                lstCargo.Add(objCargo);
            }
            return lstCargo;
        }

        public List<CuentaBancaria> obtenerCuentaBancaria(CuentaBancaria oCuentaBancariaParam)
        {
            string sql = "TC.SP_ConsultarCuentaBancaria";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            CuentaBancaria oCuenta = new CuentaBancaria();
            List<CuentaBancaria> lstCuenta = new List<CuentaBancaria>();

            if (oCuentaBancariaParam.idCuenta != 0)
                db.AddInParameter(cmd, "id", DbType.Int32, oCuentaBancariaParam.idCuenta);
            if (oCuentaBancariaParam.Banco != string.Empty)
                db.AddInParameter(cmd, "Banco", DbType.String, oCuentaBancariaParam.Banco);
            if (oCuentaBancariaParam.NumeroCuenta != string.Empty)
                db.AddInParameter(cmd, "NumeroCuenta", DbType.String, oCuentaBancariaParam.NumeroCuenta);
            if (oCuentaBancariaParam.TipoCuenta != string.Empty)
                db.AddInParameter(cmd, "TipoCuenta", DbType.String, oCuentaBancariaParam.TipoCuenta);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oCuenta = new CuentaBancaria();
                oCuenta.idCuenta = dr["idCuenta"] == DBNull.Value ? 0 : Convert.ToInt32(dr["idCuenta"]);
                oCuenta.Banco = dr["Banco"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Banco"]);
                oCuenta.NumeroCuenta = dr["NumeroCuenta"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NumeroCuenta"]);
                oCuenta.TipoCuenta = dr["TipoCuenta"] == DBNull.Value ? string.Empty : Convert.ToString(dr["TipoCuenta"]);
                oCuenta.Titular = dr["Titular"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Titular"]);
                oCuenta.NombreCuenta = dr["NombreCuenta"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreCuenta"]);
                oCuenta.Activa = dr["Activa"] == DBNull.Value ? true : Convert.ToBoolean(dr["Activa"]);
                lstCuenta.Add(oCuenta);
            }
            return lstCuenta;
        }

        public List<RegistroLlamada> obtenerRegistroLlamada(RegistroLlamada oRegistroLlamada)
        {
            string sql = "TC.SP_ConsultarLlamada";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            List<RegistroLlamada> lstRegistroLlamada = new List<RegistroLlamada>();

            if (oRegistroLlamada.idUsuario != 0)
                db.AddInParameter(cmd, "idUsuario", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idUsuario));
            if (oRegistroLlamada.idCliente != 0)
                db.AddInParameter(cmd, "idCliente", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idCliente));
            if (oRegistroLlamada.Documento != 0)
                db.AddInParameter(cmd, "documento", DbType.Double, Convert.ToDouble(oRegistroLlamada.Documento));
            if (!String.IsNullOrEmpty(oRegistroLlamada.NombresCliente))
                db.AddInParameter(cmd, "nombres", DbType.String, Convert.ToString(oRegistroLlamada.NombresCliente));
            if (!String.IsNullOrEmpty(oRegistroLlamada.ApellidosCliente))
                db.AddInParameter(cmd, "apellidos", DbType.String, Convert.ToString(oRegistroLlamada.ApellidosCliente));
            if (oRegistroLlamada.idOrganizacion != 0)
                db.AddInParameter(cmd, "idorganizacion", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idOrganizacion));
            if (oRegistroLlamada.idCargo != 0)
                db.AddInParameter(cmd, "idcargo", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idCargo));
            if (oRegistroLlamada.idDepartamento != 0)
                db.AddInParameter(cmd, "iddepartamento", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idDepartamento));
            if (oRegistroLlamada.idMunicipio != 0)
                db.AddInParameter(cmd, "idmunicipio", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idMunicipio));
            if (oRegistroLlamada.idEvento != 0)
                db.AddInParameter(cmd, "idEvento", DbType.Int64, Convert.ToInt64(oRegistroLlamada.idEvento));
            if (oRegistroLlamada.VolverALlamar != null)
                db.AddInParameter(cmd, "volverALlamar", DbType.Boolean, oRegistroLlamada.VolverALlamar);
            if (oRegistroLlamada.FechaHoraVolverALlamar != DateTime.MinValue)
                db.AddInParameter(cmd, "fechaHoraVolverALlamar", DbType.DateTime, oRegistroLlamada.FechaHoraVolverALlamar);
            if (oRegistroLlamada.Fecha != DateTime.MinValue)
                db.AddInParameter(cmd, "fechaHora", DbType.DateTime, oRegistroLlamada.Fecha);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                RegistroLlamada objRegistroLlamada = new RegistroLlamada();
                objRegistroLlamada.idRegistroLlamada = dr["idRegistroLlamada"] == DBNull.Value ? 0 : Convert.ToInt64(dr["idRegistroLlamada"]);
                objRegistroLlamada.Departamento = dr["DEPARTAMENTO"] == DBNull.Value ? string.Empty : Convert.ToString(dr["DEPARTAMENTO"]);
                objRegistroLlamada.Municipio = dr["MUNICIPIO"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MUNICIPIO"]);
                objRegistroLlamada.Cargo = dr["CARGO"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CARGO"]);
                objRegistroLlamada.idUsuario = dr["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt64(dr["idUsuario"]);
                objRegistroLlamada.Fecha = dr["FechaHora"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["FechaHora"]);
                objRegistroLlamada.idEvento = dr["idEvento"] == DBNull.Value ? 0 : Convert.ToInt64(dr["idEvento"]);
                objRegistroLlamada.Observacion = dr["Observacion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Observacion"]);
                objRegistroLlamada.VolverALlamar = dr["VolverALlamar"] == DBNull.Value ? false : Convert.ToBoolean(dr["VolverALlamar"]);
                objRegistroLlamada.FechaHoraVolverALlamar = dr["FechaHoraVolverALlamar"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["FechaHoraVolverALlamar"]);
                objRegistroLlamada.idCliente = dr["idCliente"] == DBNull.Value ? 0 : Convert.ToInt64(dr["idCliente"]);
                objRegistroLlamada.NombresCliente = dr["NombreCliente"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreCliente"]);
                objRegistroLlamada.NombreEvento = dr["NombreEvento"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreEvento"]);
                objRegistroLlamada.NombreUsuario = dr["Usuario"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Usuario"]);
                objRegistroLlamada.Telefono = dr["Telefono"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Telefono"]);
                lstRegistroLlamada.Add(objRegistroLlamada);
            }
            return lstRegistroLlamada;
        }

        public List<PagoTO> ConsultarPagos(PagoTO filtros)
        {
            List<PagoTO> pagos = new List<PagoTO>();
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarPagos");

            db.AddInParameter(cmd, "idEvento", DbType.Double, filtros.idEvento);
            db.AddInParameter(cmd, "documento", DbType.Double, filtros.Documento);
            db.AddInParameter(cmd, "idCliente", DbType.Double, filtros.idCliente);
            db.AddInParameter(cmd, "nombres", DbType.String, filtros.NombreCliente);
            db.AddInParameter(cmd, "apellidos", DbType.String, filtros.ApellidoCliente);
            db.AddInParameter(cmd, "idorganizacion", DbType.Double, filtros.idOrganizacion);
            db.AddInParameter(cmd, "idcargo", DbType.Int32, filtros.idCargo);
            db.AddInParameter(cmd, "iddepartamento", DbType.Int32, filtros.idDepartamento);
            db.AddInParameter(cmd, "idmunicipio", DbType.Int32, filtros.idMunicipio);

            DataSet ds = db.ExecuteDataSet(cmd);

            PagoTO row;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new PagoTO();

                row.idPagoEvento = Convert.ToDouble(dr["idPagoEvento"]);
                row.NombreEvento = Convert.ToString(dr["NombreEvento"]);
                row.ConceptoPago = dr["ConceptoPago"] == DBNull.Value ? string.Empty : Convert.ToString(dr["ConceptoPago"]);
                row.idMedioPago = Convert.ToInt32(dr["idMedioPago"]);
                row.MedioPago = dr["MedioPago"] == DBNull.Value ? string.Empty : Convert.ToString(dr["MedioPago"]);
                row.PagoVerificado = Convert.ToBoolean(dr["PagoVerificado"]);
                row.FechaPago = Convert.ToDateTime(dr["FechaPago"]);
                row.ValorPagado = Convert.ToDecimal(dr["ValorPagado"]);
                row.ValorDetalle = Convert.ToDecimal(dr["ValorDetalle"]);                
                row.CantReservas = Convert.ToInt32(dr["CantReservas"]);
                row.idUsuario = Convert.ToDouble(dr["idUsuario"]);
                row.Usuario = dr["Usuario"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Usuario"]);
                row.idEvento = Convert.ToDouble(dr["idEvento"]);
                row.NombreCliente = Convert.ToString(dr["Nombres"]);
                row.ApellidoCliente = Convert.ToString(dr["Apellidos"]);
                row.Documento = dr["Documento"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Documento"]);
                row.Cargo = Convert.ToString(dr["Cargo"]);
                row.Departamento = Convert.ToString(dr["Departamento"]);
                row.Municipio = Convert.ToString(dr["Municipio"]);
                row.Organizacion = Convert.ToString(dr["Organizacion"]);
                row.NumeroConsignacion = Convert.ToString(dr["NumeroConsignacion"]);
                row.NombreNumeroCuenta = dr["NombreCuenta"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreCuenta"]);                
                pagos.Add(row);
            }

            return pagos;
        }

        public List<EstadoCuentaTO> ConsultarEstadoCuenta(PagoTO filtros)
        {
            List<EstadoCuentaTO> lstEstadoCuenta = new List<EstadoCuentaTO>();

            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarEstadoCuenta");

            db.AddInParameter(cmd, "idEvento", DbType.Double, filtros.idEvento);
            db.AddInParameter(cmd, "documento", DbType.Double, filtros.Documento);
            db.AddInParameter(cmd, "nombres", DbType.String, filtros.NombreCliente);
            db.AddInParameter(cmd, "apellidos", DbType.String, filtros.ApellidoCliente);
            db.AddInParameter(cmd, "idorganizacion", DbType.Double, filtros.idOrganizacion);
            db.AddInParameter(cmd, "idcargo", DbType.Int32, filtros.idCargo);
            db.AddInParameter(cmd, "iddepartamento", DbType.Int32, filtros.idDepartamento);
            db.AddInParameter(cmd, "idmunicipio", DbType.Int32, filtros.idMunicipio);

            DataSet ds = db.ExecuteDataSet(cmd);

            EstadoCuentaTO row;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new EstadoCuentaTO();

                row.idCliente = Convert.ToDouble(dr["idCliente"]);
                row.Documento = dr["Documento"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Documento"]);
                row.Nombres = dr["Nombres"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Nombres"]);
                row.Apellidos = dr["Apellidos"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Apellidos"]);
                row.Cargo = dr["CARGO"] == DBNull.Value ? string.Empty : Convert.ToString(dr["CARGO"]);
                row.Departamento = dr["Departamento"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Departamento"]);
                row.Municipio = dr["Municipio"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Municipio"]);
                row.Organizacion = dr["Organizacion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Organizacion"]);
                row.NroEventos = dr["Eventos"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Eventos"]);
                row.SumPasajes = dr["PrecioPasaje"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PrecioPasaje"]);
                row.SumAsignacionHotel = dr["PrecioAsignacionHotel"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PrecioAsignacionHotel"]);
                row.SumServiciosAdicionales = dr["VlrServiciosAdicionales"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VlrServiciosAdicionales"]);
                row.VentaTotal = dr["VentaTotal"] == DBNull.Value ? 0 : Convert.ToDouble(dr["VentaTotal"]);
                row.SumValorPagado = dr["ValorPagado"] == DBNull.Value ? 0 : Convert.ToDouble(dr["ValorPagado"]);
                row.Saldo = dr["SALDO"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SALDO"]);

                lstEstadoCuenta.Add(row);
            }

            return lstEstadoCuenta;
        }

        public List<ClientePorReserva> ConsultarClientesPorPago (double idPagoEvento)
        {
            List<ClientePorReserva> clientes = new List<ClientePorReserva> ();
            DbCommand cmd = db.GetStoredProcCommand ("TC.SP_ConsultarClientesPorPago");

            db.AddInParameter (cmd, "idPagoEvento", DbType.Double, idPagoEvento);

            DataSet ds = db.ExecuteDataSet (cmd);

            ClientePorReserva row;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new ClientePorReserva {NombreCliente = Convert.ToString(dr["NombreCliente"])};

                clientes.Add (row);
            }

            return clientes;
        }

        public List<ClienteSinPago> ConsultarClinetesSinPago(PagoTO clienteFiltro)
        {
            List<ClienteSinPago> lstRegistro = new List<ClienteSinPago>();
            ClienteSinPago row;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarClientesSinPago");

            db.AddInParameter(cmd, "idEvento", DbType.Double, clienteFiltro.idEvento);
            db.AddInParameter(cmd, "documento", DbType.Double, clienteFiltro.Documento);
            db.AddInParameter(cmd, "nombres", DbType.String, clienteFiltro.NombreCliente);
            db.AddInParameter(cmd, "apellidos", DbType.String, clienteFiltro.ApellidoCliente);
            db.AddInParameter(cmd, "idorganizacion", DbType.Double, clienteFiltro.idOrganizacion);
            db.AddInParameter(cmd, "idcargo", DbType.Int32, clienteFiltro.idCargo);
            db.AddInParameter(cmd, "iddepartamento", DbType.Int32, clienteFiltro.idDepartamento);
            db.AddInParameter(cmd, "idmunicipio", DbType.Int32, clienteFiltro.idMunicipio);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new ClienteSinPago();

                row.idDetalleEvento = Convert.ToDouble(dr["idDetalleEvento"]);
                row.NombreEvento = Convert.ToString(dr["NombreEvento"]);
                row.idEvento = Convert.ToDouble(dr["idEvento"]);
                row.Documento = dr["Documento"] == DBNull.Value ? (double?)null : Convert.ToDouble(dr["Documento"]);
                row.idCliente = dr["idCliente"] == DBNull.Value ? (double?)null : Convert.ToDouble(dr["idCliente"]);
                row.NombreCliente = dr["NombreCliente"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreCliente"]);
                row.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                row.ReservaPasajeAereo = Convert.ToBoolean(dr["ReservaPasajeAereo"]);
                row.ReservaHotel = Convert.ToBoolean(dr["ReservaHotel"]);
                row.Pazysalvo = Convert.ToBoolean(dr["Pazysalvo"]);
                row.Cargo = dr["Cargo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Cargo"]);
                row.Municipio = dr["Municipio"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Municipio"]);
                row.Departamento = dr["Departamento"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Departamento"]);
                row.Organizacion = dr["Organizacion"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Organizacion"]);

                lstRegistro.Add(row);
            }

            return lstRegistro;
        }

        /// <summary>
        /// Obtiene los teléfonos de los clientes
        /// </summary>
        /// <param name="idCliente">Si envía id cliente recibirá los teléfonos del cliente. Envíe 0 para obtener de una organización</param>
        /// <param name="idOrganizacion">Ingrese el idOrganizacion o 0 para obtener el idcliente</param>
        /// <returns></returns>
        public List<Telefono> ObtenerTelefonos(double idCliente, double idOrganizacion)
        {
            List<Telefono> lstTelefono = new List<Telefono>();
            Telefono oTelefono;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarTelefonos");

            db.AddInParameter(cmd, "idCliente", DbType.Double, idCliente);
            db.AddInParameter(cmd, "idOrganizacion", DbType.Double, idOrganizacion);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                oTelefono = new Telefono();
                oTelefono.idTelefono = Convert.ToDouble(dr["Id"]);
                oTelefono.idOrganizacion = dr["IdOrganizacion"] == DBNull.Value ? 0 : Convert.ToDouble(dr["IdOrganizacion"]);
                oTelefono.Orden = dr["Orden"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Orden"]);
                oTelefono.Tipo = dr["Tipo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Tipo"]);
                oTelefono.NumeroTelefonico = Convert.ToString(dr["Numero"]);
                oTelefono.Indicativo = dr["Indicativo"] == DBNull.Value ? string.Empty : Convert.ToString(dr["Indicativo"]);
                oTelefono.idCliente = dr["IdCliente"] == DBNull.Value ? 0 : Convert.ToDouble(dr["IdCliente"]);
                lstTelefono.Add(oTelefono);
            }

            return lstTelefono;
        }

        public List<ClienteSinPago> ConsultarClientesPorPagoEdicion(double idPagoEvento)
        {
            List<ClienteSinPago> clientes = new List<ClienteSinPago>();
            ClienteSinPago row;
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_ConsultarClientesDelPago");

            db.AddInParameter(cmd, "idPagoEvento", DbType.Double, idPagoEvento);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = new ClienteSinPago();

                row.idDetalleEvento = Convert.ToDouble(dr["idDetalleEvento"]);
                row.NombreEvento = Convert.ToString(dr["NombreEvento"]);
                row.idEvento = Convert.ToDouble(dr["idEvento"]);
                row.idCliente = dr["idCliente"] == DBNull.Value ? (double?)null : Convert.ToDouble(dr["idCliente"]);
                row.NombreCliente = dr["NombreCliente"] == DBNull.Value ? string.Empty : Convert.ToString(dr["NombreCliente"]);
                row.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                row.ReservaPasajeAereo = Convert.ToBoolean(dr["ReservaPasajeAereo"]);
                row.ReservaHotel = Convert.ToBoolean(dr["ReservaHotel"]);
                row.Pazysalvo = Convert.ToBoolean(dr["Pazysalvo"]);

                clientes.Add(row);
            }

            return clientes;
        }

        #region Maestros

        public List<Cargo> obtenerListaCargo(Cargo oCargo)
        {
            List<Cargo> lstCargo = new List<Cargo>();
            string sql = "TC.SP_ConsultarCargo";
            DbCommand cmd = db.GetStoredProcCommand(sql);
            if (oCargo.Id != 0)
                db.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(oCargo.Id));
            if (oCargo.Nombre != string.Empty)
                db.AddInParameter(cmd, "nombre", DbType.String, Convert.ToString(oCargo.Nombre));
            if (Convert.ToString(oCargo.Descripcion) != string.Empty)
                db.AddInParameter(cmd, "descripcion", DbType.String, Convert.ToString(oCargo.Descripcion));

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Cargo objCargo = new Cargo();
                objCargo.Id = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]);
                objCargo.Nombre = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objCargo.Descripcion = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                lstCargo.Add(objCargo);
            }
            return lstCargo;
        }

        public List<Organizacion> obtenerListaOrganizacion(Organizacion oOrganizacion)
        {
            List<Organizacion> lstOrganizacion = new List<Organizacion>();
            string sql = "TC.SP_ConsultarOrganizacion";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            if (oOrganizacion.IdMunicipio != 0)
                db.AddInParameter(cmd, "idmunicipio", DbType.Int32, Convert.ToInt32(oOrganizacion.IdMunicipio));
            if (oOrganizacion.IdDepartamento != 0)
                db.AddInParameter(cmd, "iddepartamento", DbType.Int32, Convert.ToInt32(oOrganizacion.IdDepartamento));

            
            //if (oOrganizacion.Id != 0)
            //    db.AddInParameter(cmd, "id", DbType.Int32, Convert.ToInt32(oOrganizacion.Id));
            //if (Convert.ToString(oOrganizacion.Nombre) != string.Empty)
            //    db.AddInParameter(cmd, "nombre", DbType.String, Convert.ToString(oOrganizacion.Nombre));
            //if (oOrganizacion.Nit != 0)
            //    db.AddInParameter(cmd, "nit", DbType.Int32, Convert.ToInt32(oOrganizacion.Nit));
            //if (oOrganizacion.IdTipo != 0)
            //    db.AddInParameter(cmd, "idtipo", DbType.Int32, Convert.ToInt32(oOrganizacion.IdTipo));
            //if (oOrganizacion.IdMunicipio != 0)
            //    db.AddInParameter(cmd, "idmunicipio", DbType.Int32, Convert.ToInt32(oOrganizacion.IdMunicipio));
            //if (Convert.ToString(oOrganizacion.FechaFiestas) != string.Empty)
            //    db.AddInParameter(cmd, "fechafiestas", DbType.String, Convert.ToString(oOrganizacion.FechaFiestas));
            //if (oOrganizacion.IdDepartamento != 0)
            //    db.AddInParameter(cmd, "iddepartamento", DbType.Int32, Convert.ToInt32(oOrganizacion.IdDepartamento));

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Organizacion objOrganizacion = new Organizacion();
                objOrganizacion.Id = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]);
                objOrganizacion.Nombre = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objOrganizacion.Nit = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                objOrganizacion.IdTipo = dr[3] == DBNull.Value ? 0 : Convert.ToInt32(dr[3]);
                objOrganizacion.IdMunicipio = dr[4] == DBNull.Value ? 0 : Convert.ToInt32(dr[4]);
                objOrganizacion.Email = dr[5] == DBNull.Value ? string.Empty : Convert.ToString(dr[5]);
                objOrganizacion.Direccion = dr[6] == DBNull.Value ? string.Empty : Convert.ToString(dr[6]);
                objOrganizacion.SecretarioDespacho = dr[7] == DBNull.Value ? string.Empty : Convert.ToString(dr[7]);
                objOrganizacion.Email2 = dr[8] == DBNull.Value ? string.Empty : Convert.ToString(dr[8]);
                objOrganizacion.Fuente = dr[9] == DBNull.Value ? string.Empty : Convert.ToString(dr[9]);
                objOrganizacion.Pagina = dr[10] == DBNull.Value ? string.Empty : Convert.ToString(dr[10]);
                objOrganizacion.Cumpleanos = dr[11] == DBNull.Value ? string.Empty : Convert.ToString(dr[11]);
                objOrganizacion.FechaFiestas = dr[12] == DBNull.Value ? string.Empty : Convert.ToString(dr[12]);
                objOrganizacion.PeriodicidadFiestas = dr[13] == DBNull.Value ? string.Empty : Convert.ToString(dr[13]);
                objOrganizacion.FechaRegistro = dr[14] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr[14]);
                objOrganizacion.NombreFiestas = dr[15] == DBNull.Value ? string.Empty : Convert.ToString(dr[15]);
                objOrganizacion.IdDepartamento = dr[16] == DBNull.Value ? 0 : Convert.ToInt32(dr[16]);
                lstOrganizacion.Add(objOrganizacion);
            }
            return lstOrganizacion;
        }

        public List<Municipio> obtenerMunicipiosDepto(int idDepartamento)
        {
            string sql = "TC.SP_ConsultarMunicipios";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            List<Municipio> lstMunicipio = new List<Municipio>();

            if (idDepartamento != 0)
                db.AddInParameter(cmd, "idDepartamento", DbType.Int32, idDepartamento);

            DataSet ds = db.ExecuteDataSet(cmd);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Municipio objMunicipio = new Municipio();
                objMunicipio.idMunicipio = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]);
                objMunicipio.Nombre = dr[1] == DBNull.Value ? string.Empty : Convert.ToString(dr[1]);
                objMunicipio.CodigoDANE = dr[2] == DBNull.Value ? string.Empty : Convert.ToString(dr[2]);
                objMunicipio.idDepartamento = dr[3] == DBNull.Value ? 0 : Convert.ToInt32(dr[3]);
                objMunicipio.Categoria = dr[4] == DBNull.Value ? string.Empty : Convert.ToString(dr[4]);
                objMunicipio.Capital = dr[5] == DBNull.Value ? false : Convert.ToString(dr[5]) == "N" ? false : true;
                lstMunicipio.Add(objMunicipio);
            }
            return lstMunicipio;
        }
        #endregion

        #endregion Consultas FIN

        #region Inserciones:  Aquí se agrupan todos los métodos que hacen inserciones a la base de datos

        /// <summary>
        /// Inserta una instancia de registro de un cliente a un evento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public void insertarRegistro(Registro oRegistro, ref List<string> lstResultados)
        {
            string sql = "TC.SP_InsertarRegistro";
            DbCommand cmd = db.GetStoredProcCommand(sql);
            db.AddInParameter(cmd, "Documento", DbType.Double, oRegistro.Documento);
            db.AddInParameter(cmd, "IdCliente", DbType.Double, oRegistro.idCliente);
            db.AddInParameter(cmd, "Nombres", DbType.String, oRegistro.Nombres);
            db.AddInParameter(cmd, "Apellidos", DbType.String, oRegistro.Apellidos);
            db.AddInParameter(cmd, "Celular", DbType.String, oRegistro.Celular);
            db.AddInParameter(cmd, "Email", DbType.String, oRegistro.Email);
            db.AddInParameter(cmd, "idMunicipio", DbType.Int32, oRegistro.idMunicipio);
            db.AddInParameter(cmd, "RequiereHotel", DbType.Boolean, oRegistro.RequiereHotel);
            db.AddInParameter(cmd, "FechaCkeckInHotel", DbType.DateTime, Utilidades.NullCheck(oRegistro.FechaCkeckInHotel));
            db.AddInParameter(cmd, "FechaCheckOutHotel", DbType.DateTime, Utilidades.NullCheck(oRegistro.FechaCheckOutHotel));
            db.AddInParameter(cmd, "RequierePasajes", DbType.Boolean, oRegistro.RequierePasajes);
            db.AddInParameter(cmd, "TipoAcomodacion", DbType.String, Utilidades.NullCheck(oRegistro.TipoAcomodacion));
            db.AddInParameter(cmd, "LugarSalida", DbType.String, Utilidades.NullCheck(oRegistro.LugarSalida));
            db.AddInParameter(cmd, "FechaSalidaPasajes", DbType.DateTime, Utilidades.NullCheck(oRegistro.FechaSalidaPasajes));
            db.AddInParameter(cmd, "FechaRegresoPasajes", DbType.DateTime, Utilidades.NullCheck(oRegistro.FechaRegresoPasajes));
            db.AddInParameter(cmd, "idEvento", DbType.Double, oRegistro.idEvento);
            db.AddInParameter(cmd, "Observaciones", DbType.String, oRegistro.Observaciones);

            //Parametros de salida
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Byte, 1);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);
        }

        /// <summary>
        /// Insertar o modificar un clinete
        /// </summary>
        /// <param name="oCliente"></param>
        /// <param name="lstTelefono"></param>
        /// <param name="oFuncionario"></param>
        /// <param name="lstResultados"></param>
        public void insertarModificarCliente(ClienteTO oCliente, List<Telefono> lstTelefono, Funcionario oFuncionario, ref List<string> lstResultados)
        {
            string sql = "TC.SP_InsertarModificarCliente";            
            DbCommand cmd = db.GetStoredProcCommand(sql);
            if (oCliente.idCliente > 0)            
                db.AddInParameter(cmd, "idCliente", DbType.Double, oCliente.idCliente);
            db.AddInParameter(cmd, "Documento", DbType.Double, Utilidades.NullCheck(oCliente.Documento));
            db.AddInParameter(cmd, "LugarExpedicion", DbType.String, Utilidades.NullCheck(oCliente.LugarExpedicion));
            db.AddInParameter(cmd, "Nombres", DbType.String, oCliente.Nombres);
            db.AddInParameter(cmd, "Apellidos", DbType.String, oCliente.Apellidos);
            db.AddInParameter(cmd, "FechaNacimiento", DbType.DateTime, Utilidades.NullCheck(oCliente.FechaNacimiento));
            db.AddInParameter(cmd, "CiudadNacimiento", DbType.String, Utilidades.NullCheck(oCliente.CiudadNacimiento));
            db.AddInParameter(cmd, "Sexo", DbType.String, oCliente.Sexo == '0' ? (object)DBNull.Value : oCliente.Sexo);
            db.AddInParameter(cmd, "TipoSangre", DbType.String, Utilidades.NullCheck(oCliente.TipoSangre));
            db.AddInParameter(cmd, "TallaCamiseta", DbType.String, Utilidades.NullCheck(oCliente.TallaCamiseta));
            db.AddInParameter(cmd, "Email", DbType.String, Utilidades.NullCheck(oCliente.Email));
            db.AddInParameter(cmd, "Direccion", DbType.String, Utilidades.NullCheck(oCliente.Direccion));
            db.AddInParameter(cmd, "Estudios", DbType.String, Utilidades.NullCheck(oCliente.Estudios));
            db.AddInParameter(cmd, "Idiomas", DbType.String, Utilidades.NullCheck(oCliente.Idiomas));
            db.AddInParameter(cmd, "Visas", DbType.String, Utilidades.NullCheck(oCliente.Visas));
            db.AddInParameter(cmd, "EstadoCivil", DbType.String, Utilidades.NullCheck(oCliente.EstadoCivil));
            db.AddInParameter(cmd, "Hijos", DbType.Int32, Utilidades.NullCheck(oCliente.Hijos));
            db.AddInParameter(cmd, "CiudadResidencia", DbType.String, Utilidades.NullCheck(oCliente.CiudadResidencia));
            db.AddInParameter(cmd, "UsuarioRegistroModificacion", DbType.Double, oCliente.idUsuarioRegistroMod);
            //DatosFuncionario
            db.AddInParameter(cmd, "Asistente", DbType.String, Utilidades.NullCheck(oFuncionario.Asistente));
            db.AddInParameter(cmd, "Periodo", DbType.String, Utilidades.NullCheck(oFuncionario.Periodo));
            //db.AddInParameter(cmd, "IdCargo", DbType.Int32, Utilidades.NullCheck(oFuncionario.idCargo));
            db.AddInParameter(cmd, "IdCargo", DbType.Int32, oFuncionario.idCargo == 0 ? (object)DBNull.Value : oFuncionario.idCargo);
            db.AddInParameter(cmd, "PartidoPolitico", DbType.String, Utilidades.NullCheck(oFuncionario.PartidoPolitico));
            db.AddInParameter(cmd, "Asociacion", DbType.String, Utilidades.NullCheck(oFuncionario.Asociacion));
            db.AddInParameter(cmd, "Observaciones", DbType.String, Utilidades.NullCheck(oFuncionario.Observaciones));
           // db.AddInParameter(cmd, "idOrganizacion", DbType.Double, Utilidades.NullCheck(oFuncionario.idOrganizacion));
            db.AddInParameter(cmd, "idOrganizacion", DbType.Double, oFuncionario.idOrganizacion == 0 ? (object)DBNull.Value : oFuncionario.idOrganizacion);

            foreach (Telefono tel in lstTelefono)
            {
                if (tel.Tipo=="Fijo")
                {
                    db.AddInParameter(cmd, "Telefono", DbType.String, Utilidades.NullCheck(tel.NumeroTelefonico));
                }
                if (tel.Tipo == "Celular")
                {
                    db.AddInParameter(cmd, "Celular", DbType.String, Utilidades.NullCheck(tel.NumeroTelefonico));
                }
            }
            
            //Parametros de salida
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Byte, 1);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);
        }

        public List<string> insertarDetalleEvento(DetalleEventoTO oAsignarEventoClienteTO)
        {
            List<string> lstResultados = new List<string>();
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_InsertarDetalleEvento");

            db.AddInParameter(cmd, "p_idEvento", DbType.Double, oAsignarEventoClienteTO.idEvento.NullCheck());
            db.AddInParameter(cmd, "p_idDetalleEvento", DbType.Double, oAsignarEventoClienteTO.idDetalleEvento);
            db.AddInParameter(cmd, "p_idCliente", DbType.Double, Utilidades.NullCheck(oAsignarEventoClienteTO.idCliente));
            db.AddInParameter(cmd, "p_Pazysalvo", DbType.Boolean, oAsignarEventoClienteTO.Pazysalvo);
            db.AddInParameter(cmd, "p_Aerolinea", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.Aerolinea));
            db.AddInParameter(cmd, "p_Avion", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.Avion));
            db.AddInParameter(cmd, "p_CiudadOrigen", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.CiudadOrigen));
            db.AddInParameter(cmd, "p_CiudadDestino", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.CiudadDestino));
            db.AddInParameter(cmd, "p_idMunicipioOrigen", DbType.Int32, Utilidades.NullCheck(oAsignarEventoClienteTO.idMunicipioOrigen));
            db.AddInParameter(cmd, "p_idMunicipioDestino", DbType.Int32, Utilidades.NullCheck(oAsignarEventoClienteTO.idMunicipioDestino));
            db.AddInParameter(cmd, "p_FechaHoraSalida", DbType.DateTime, Utilidades.NullCheck(oAsignarEventoClienteTO.FechaSalida));
            db.AddInParameter(cmd, "p_FechaHoraRegreso", DbType.DateTime, Utilidades.NullCheck(oAsignarEventoClienteTO.FechaRegreso));
            db.AddInParameter(cmd, "p_Redondo", DbType.Boolean, oAsignarEventoClienteTO.Redondo);
            db.AddInParameter(cmd, "p_Clase", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.Clase));
            db.AddInParameter(cmd, "p_PrecioVenta", DbType.Decimal, Utilidades.NullCheck(oAsignarEventoClienteTO.PrecioVenta));
            db.AddInParameter(cmd, "p_ObservacionesPasaje", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.ObservacionesPasaje));
            db.AddInParameter(cmd, "p_PrecioHotel", DbType.Decimal, oAsignarEventoClienteTO.PrecioHotel);
            db.AddInParameter(cmd, "p_Costo", DbType.Decimal, Utilidades.NullCheck(oAsignarEventoClienteTO.Costo));
            db.AddInParameter(cmd, "p_CodigoPasaje", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.CodigoPasaje));
            db.AddInParameter(cmd, "p_idCama", DbType.Int32, Utilidades.NullCheck(oAsignarEventoClienteTO.idCama));
            db.AddInParameter(cmd, "p_FechaCheckIn", DbType.DateTime, Utilidades.NullCheck(oAsignarEventoClienteTO.FechaCheckIn));
            db.AddInParameter(cmd, "p_FechaCheckOut", DbType.DateTime, Utilidades.NullCheck(oAsignarEventoClienteTO.FechaCheckOut));
            db.AddInParameter(cmd, "p_ObservacionesHotel", DbType.String, Utilidades.NullCheck(oAsignarEventoClienteTO.ObservacionesHotel));
            db.AddInParameter(cmd, "P_RequiereHotel", DbType.Boolean, oAsignarEventoClienteTO.RequiereHotel);
            db.AddInParameter(cmd, "P_RequierePasajes", DbType.Boolean, oAsignarEventoClienteTO.RequierePasajes);
            db.AddInParameter(cmd, "p_idUsuario", DbType.Double, oAsignarEventoClienteTO.idUsuario.NullCheck());

            //Parametros de salida
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Boolean, 1);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);

            return lstResultados;
        }

        /// <summary>
        /// Inserta una llamada
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public void insertarLlamada(RegistroLlamada oRegistro, ref List<string> lstResultados)
        {
            string sql = "TC.SP_InsertarLlamada";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            db.AddInParameter(cmd, "idUsuario", DbType.Double, oRegistro.idUsuario);
            db.AddInParameter(cmd, "idCliente", DbType.Double, oRegistro.idCliente);
            db.AddInParameter(cmd, "idEvento", DbType.Double, oRegistro.idEvento);
            db.AddInParameter(cmd, "volverALlamar", DbType.Boolean, oRegistro.VolverALlamar);
            db.AddInParameter(cmd, "fechaHoraVolverALlamar", DbType.DateTime, Utilidades.NullCheck(oRegistro.FechaHoraVolverALlamar));
            db.AddInParameter(cmd, "Telefono", DbType.String, oRegistro.Telefono);
            db.AddInParameter(cmd, "Observacion", DbType.String, oRegistro.Observacion);
            //Parametros de salida
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Byte, 1);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);
        }

        public void GuardarPagoEvento(Pago pagoNuevo, List<ClienteSinPago> lstClienteDelPago)
        {
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_InsertarPagoEvento");

            db.AddInParameter(cmd, "ConceptoPago", DbType.String, pagoNuevo.ConceptoPago);
            db.AddInParameter(cmd, "idMedioPago", DbType.Int32, pagoNuevo.idMedioPago);
            db.AddInParameter(cmd, "PagoVerificado", DbType.Boolean, pagoNuevo.PagoVerificado);
            db.AddInParameter(cmd, "FechaPago", DbType.DateTime, pagoNuevo.FechaPago);
            db.AddInParameter(cmd, "ValorPagado", DbType.Decimal, pagoNuevo.ValorPagado);
            db.AddInParameter(cmd, "idUsuario", DbType.Double, pagoNuevo.idUsuario);
            db.AddInParameter(cmd, "NumeroConsignacion", DbType.String, pagoNuevo.NumeroConsignacion);
            db.AddInParameter(cmd, "idCuenta", DbType.String, pagoNuevo.idCuenta);

            db.AddOutParameter(cmd, "idPagoEvento", DbType.Double, 18);

            db.ExecuteNonQuery(cmd);
            double idPagoEvento = Convert.ToDouble(db.GetParameterValue(cmd, "idPagoEvento"));

            foreach (ClienteSinPago row in lstClienteDelPago)
            {
                DbCommand cmd1 = db.GetStoredProcCommand("TC.SP_InsertarPagoEventoDetalle");

                db.AddInParameter(cmd1, "idDetalleEvento", DbType.Double, row.idDetalleEvento);
                db.AddInParameter(cmd1, "idPagoEvento", DbType.Double, idPagoEvento);
                db.AddInParameter(cmd1, "ValorPagadoDetalle", DbType.Double, row.ValorAsignado);

                db.ExecuteNonQuery(cmd1);
            }
        }

        #endregion Inserciones

        #region Actualizaciones

        public void ActualizarPagoEvento(Pago pagoEdicion, List<ClienteSinPago> lstClienteDelPago)
        {
            DbCommand cmd = db.GetStoredProcCommand ("TC.SP_ActualizarPagoEvento");

            db.AddInParameter (cmd, "idPagoEvento", DbType.String, pagoEdicion.idPagoEvento);
            db.AddInParameter (cmd, "ConceptoPago", DbType.String, pagoEdicion.ConceptoPago);
            db.AddInParameter (cmd, "idMedioPago", DbType.Int32, pagoEdicion.idMedioPago);
            db.AddInParameter (cmd, "PagoVerificado", DbType.Boolean, pagoEdicion.PagoVerificado);
            db.AddInParameter (cmd, "FechaPago", DbType.DateTime, pagoEdicion.FechaPago);
            db.AddInParameter (cmd, "ValorPagado", DbType.Decimal, pagoEdicion.ValorPagado);
            db.AddInParameter (cmd, "idUsuario", DbType.Double, pagoEdicion.idUsuario);

            db.ExecuteNonQuery (cmd);

            foreach (ClienteSinPago row in lstClienteDelPago)
            {
                DbCommand cmd1 = db.GetStoredProcCommand ("TC.SP_InsertarPagoEventoDetalle");

                db.AddInParameter (cmd1, "idDetalleEvento", DbType.Double, row.idDetalleEvento);
                db.AddInParameter (cmd1, "idPagoEvento", DbType.Double, pagoEdicion.idPagoEvento);

                db.ExecuteNonQuery (cmd1);
            }
        }

        #endregion

        #region Eliminaciones

        public void EliminarPago(double idPagoEvento, double idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand ("TC.SP_EliminarPago");

            db.AddInParameter(cmd, "idPagoEvento", DbType.Double, idPagoEvento);
            db.AddInParameter(cmd, "idUsuario", DbType.Double, idUsuario);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
        }

        public void EliminarDetalleEvento(double idDetalleEvento, double idUsuario, ref List<string> lstResultados)
        {
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_EliminarDetalleEvento");

            db.AddInParameter(cmd, "idDetalleEvento", DbType.Double, idDetalleEvento);
            db.AddInParameter(cmd, "idUsuario", DbType.Double, idUsuario);
            
            //Parámetros de salida
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Byte, 1);
            
            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);            
        }

        public void EliminarCliente(double idCliente, ref List<string> lstResultados)
        {
            DbCommand cmd = db.GetStoredProcCommand("TC.SP_EliminarCliente");

            db.AddInParameter(cmd, "idCliente", DbType.Double, idCliente);
            //Parámetros de salida
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 500);
            db.AddOutParameter(cmd, "Exito", DbType.Byte, 1);

            string resultado = Convert.ToString(db.ExecuteNonQuery(cmd));
            string Exito = Convert.ToString(db.GetParameterValue(cmd, "Exito"));
            string Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"));

            lstResultados.Add(resultado);
            lstResultados.Add(Exito);
            lstResultados.Add(Mensaje);            
        }

        #endregion
    }
}
