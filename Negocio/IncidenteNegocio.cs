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
                datos.setearConsulta("SELECT I.ID, I.FECHA_INICIO, I.FECHA_CIERRE, I.IDEMPLEADO, EM.NOMBRE AS NOMEMPLEADO, EM.APELLIDO AS APEEMPLEADO, I.IDCLIENTE, CS.NOMBRE AS NOMCLIENTE, CS.APELLIDO AS APECLIENTE, I.DETALLES, I.IDESTADO, E.NOMBREESTADO, I.COMENTARIOFINAL FROM INCIDENTES I, ESTADOS E, CLIENTES CS, EMPLEADOS EM WHERE E.ID = I.IDESTADO AND I.IDCLIENTE = CS.ID AND I.IDEMPLEADO = EM.ID");
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
                datos.setearConsulta("Insert Into Incidentes(IDEMPLEADO, IDCLIENTE, FECHA_INICIO, DETALLES, IDESTADO) Values(@IDEMPLEADO, @IDCLIENTE, getDate(), @DETALLES, 1)"); 
                datos.setearParametros("@IDEMPLEADO", nuevo.Empleado.Legajo);
                datos.setearParametros("@IDCLIENTE", nuevo.Cliente.IDCliente);
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
                datos.setearConsulta("Update Incidentes set COMENTARIOFINAL=@COMETARIOFINAL, FECHA_CIERRE = GETDATE(), IDESTADO = 3 Where ID = " + nuevo.ID + "");
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
                datos.setearConsulta("Update Incidentes set COMENTARIOFINAL=@COMETARIOFINAL, FECHA_CIERRE = GETDATE(), IDESTADO = 6 Where ID = " + nuevo.ID + "");
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
                datos.setearConsulta("Select ID, IDEMPLEADO, IDCLIENTE, IDESTADO, DETALLES Where ID = '" + buscar.ID + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["ID"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];

                    aux.Detalles = (string)datos.Lector["DETALLES"];

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
