using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class IncidenteNegocio
    {
        public List<Incidente> listar()
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
         
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("FECHA_CIERRE"))))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];

                    if(!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("DETALLES"))))
                        aux.Detalles = (string)datos.Lector["DETALLES"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("COMENTARIOFINAL"))))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //PARAMETROS "ABIERTO"
                datos.setearConsulta("Insert Into Incidentes(IDEMPLEADO, IDCLIENTE, FECHA_INICIO, DETALLES, IDESTADO, IDPRIORIDAD, IDESPECIALIDAD) Values(@IDEMPLEADO, @IDCLIENTE, getDate(), @DETALLES, 1, @IDPRIORIDAD, @IDESPECIALIDAD)"); 
                datos.setearParametros("@IDEMPLEADO", nuevo.Empleado.Legajo);
                datos.setearParametros("@IDCLIENTE", nuevo.Cliente.IDCliente);
                datos.setearParametros("@DETALLES", nuevo.Detalles);
                datos.setearParametros("@IDESPECIALIDAD", nuevo.Especialidad.IDEspecialidad);
                datos.setearParametros("@IDPRIORIDAD", nuevo.Prioridad.IDPrioridad);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void asignarIncidente(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //PARAMETROS "ASIGNADO"
                datos.setearConsulta("Update Incidentes set IDEMPLEADO = @IDEMPLEADO, IDESTADO = 5 Where ID = " + nuevo.ID + "");
                datos.setearParametros("@IDEMPLEADO", nuevo.Empleado.Legajo);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarDetalles(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //PARAMETROS "EN ANALISIS"
                datos.setearConsulta("Update Incidentes set DETALLES = @DETALLES, IDESTADO = 2 Where ID = " + nuevo.ID + "");
                datos.setearParametros("@DETALLES", nuevo.Detalles);
   
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void cerrarIncidente(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //PARAMETROS "CERRADO"
                datos.setearConsulta("Update Incidentes set COMENTARIOFINAL=@COMENTARIOFINAL, FECHA_CIERRE = GETDATE(), IDESTADO = 3 Where ID = '" + nuevo.ID + "'");
                datos.setearParametros("@COMENTARIOFINAL", nuevo.Detalles);              

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void resolverIncidente(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //PARAMETROS "RESUELTO"
                datos.setearConsulta("Update Incidentes set COMENTARIOFINAL=@COMENTARIOFINAL, FECHA_CIERRE = GETDATE(), IDESTADO = 6 Where ID = " + nuevo.ID + "");
                datos.setearParametros("@COMENTARIOFINAL", nuevo.Detalles);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void reabrirIncidente(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //PARAMETROS "REABIERTO"
                datos.setearConsulta("Update Incidentes set FECHA_CIERRE = NULL, IDESTADO = 4 Where ID = " + nuevo.ID + "");

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<Incidente> buscarID(Incidente buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND I.ID = '" + buscar.ID + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];

                    if(!(datos.Lector["FECHA_CIERRE"] is DBNull))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Incidente> buscarIncidentePorIDyLegajo(Incidente buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND I.ID = '" + buscar.ID + "' AND I.IDEMPLEADO = '"+buscar.Empleado.Legajo+"'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];

                    if (!(datos.Lector["FECHA_CIERRE"] is DBNull))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Incidente> buscarIncidentesxLegajoAsignado(int buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND I.IDEMPLEADO = '" + buscar + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];

                    if (!(datos.Lector["FECHA_CIERRE"] is DBNull))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Incidente> buscarEstado(Incidente buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND I.IDESTADO = '" + buscar.Estado.IDEstado + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];

                    if (!(datos.Lector["FECHA_CIERRE"] is DBNull))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Incidente> buscarEstadoyLegajo(Incidente buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND I.IDESTADO = '" + buscar.Estado.IDEstado + "' AND I.IDEMPLEADO = '"+buscar.Empleado.Legajo+"'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];

                    if (!(datos.Lector["FECHA_CIERRE"] is DBNull))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public Incidente traerUltimoIncidente()
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT TOP 1 I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.EMAIL AS EMAILEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.EMAIL AS EMAILCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID ORDER BY I.ID DESC");
                datos.ejecturaLectura();
                datos.Lector.Read();

                Incidente aux = new Incidente();
                aux.ID = (int)datos.Lector["ID"];

                if (!(datos.Lector["FECHA_CIERRE"] is DBNull))
                    aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                aux.Detalles = (string)datos.Lector["DETALLES"];

                if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                    aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                aux.Empleado = new Empleado();
                aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];
                aux.Empleado.Email = (string)datos.Lector["EMAILEMPLEADO"];

                aux.Especialidad = new Especialidad();
                aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                aux.Prioridad = new Prioridad();
                aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                aux.Cliente = new Cliente();
                aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];
                aux.Cliente.Email = (string)datos.Lector["EMAILCLIENTE"];

                aux.Estado = new Estado();
                aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];

                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public Incidente buscarIndividualID(Incidente buscar)
        {
            Incidente aux = new Incidente();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.EMAIL AS EMAILEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.EMAIL AS EMAILCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND I.ID = '" + buscar.ID + "'");
                datos.ejecturaLectura();
                datos.Lector.Read();

                aux.ID = (int)datos.Lector["ID"];

                    if (!(datos.Lector["FECHA_CIERRE"] is DBNull))
                        aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];

                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    if (!(datos.Lector["COMENTARIOFINAL"] is DBNull))
                        aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APEEMPLEADO"];
                    aux.Empleado.Email = (string)datos.Lector["EMAILEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMCLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APECLIENTE"];
                    aux.Cliente.Email = (string)datos.Lector["EMAILCLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];

                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        public List<Incidente> buscarxApenomCliente(Incidente buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDPRIORIDAD, P.PRIORIDAD, I.IDESPECIALIDAD, SP.ESPECIALIDAD, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM, Prioridades P, Especialidades SP WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID AND I.IDESPECIALIDAD = SP.ID AND I.IDPRIORIDAD = P.ID AND C.NOMBRE LIKE '%" + buscar.Cliente.Nombre + "%' OR C.APELLIDO LIKE '%"+ buscar.Cliente.Apellido +"'%");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];
                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];
                    aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMBREEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APELLIDOEMPLEADO"];

                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.IDEspecialidad = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.Especialidad.Nombre_Especialidad = (string)datos.Lector["ESPECIALIDAD"];

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.IDPrioridad = (int)datos.Lector["IDPRIORIDAD"];
                    aux.Prioridad.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMBRECLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APELLIDOCLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Incidente> buscarxApenomEmpleado(Incidente buscar)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select I.ID, I.IDEMPLEADO, I.IDCLIENTE, I.IDESTADO, I.DETALLES, I.COMENTARIOFINAL, I.FECHA_INICIO, I.FECHA_CIERRE, E.NOMBRE AS NOMBREEMPLEADO, E.APELLIDO AS APELLIDOEMPLEADO, C.NOMBRE AS NOMBRECLIENTE, C.APELLIDO AS APELLIDOCLIENTE, ES.NOMBREESTADO From Incidentes I, Empleados E, Clientes C, Estados ES Where I.IDCLIENTE = C.ID AND I.IDESTADO = ES.ID AND I.IDEMPLEADO = E.ID AND C.NOMBRE LIKE '%" + buscar.Cliente.Nombre + "%' OR C.APELLIDO LIKE '%" + buscar.Cliente.Apellido + "%'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Fecha_cierre = (DateTime)datos.Lector["FECHA_CIERRE"];
                    aux.Fecha_inicio = (DateTime)datos.Lector["FECHA_INICIO"];
                    aux.Detalles = (string)datos.Lector["DETALLES"];
                    aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];
                    aux.Empleado.Nombre = (string)datos.Lector["NOMBREEMPLEADO"];
                    aux.Empleado.Apellido = (string)datos.Lector["APELLIDOEMPLEADO"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["NOMBRECLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APELLIDOCLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];
                    aux.Estado.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];



                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
