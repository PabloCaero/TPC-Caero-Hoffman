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
                datos.setearConsulta("Select ID, IDEMPLEADO, IDCLIENTE, DETALLES, IDESTADO From Incidentes");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    
                    
                    Incidente aux = new Incidente();
         
                    aux.ID = (int)datos.Lector["ID"];

                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (int)datos.Lector["IDEMPLEADO"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    //aux.Fecha_Inicio = new DateTime();
                    //aux.Fecha_Inicio.ToString() = (DateTime)datos.Lector["FECHANACIMIENTO"];
                    //aux.Fecha_Cierre = new DateTime();
                    //aux.Fecha_Cierre.ToString('YYMMDD') = (DateTime)datos.Lector["Fe"]
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];

                    //aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];
                  

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
                
                datos.setearConsulta("Insert Into Incidentes(IDEMPLEADO, IDCLIENTE, FECHA_INICIO, FECHA_CIERRE, DETALLES, IDESTADO, COMENTARIOFINAL) Values(@IDEMPLEADO, @IDCLIENTE, '2021/02/03', '2021/08/02', @DETALLES, @IDESTADO, @COMENTARIOFINAL)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@IDEMPLEADO", nuevo.Empleado.Legajo);
                datos.setearParametros("@IDCLIENTE", nuevo.Cliente.IDCliente);
                datos.setearParametros("@DETALLES", nuevo.Detalles);
                datos.setearParametros("@IDESTADO", nuevo.Estado.IDEstado);
                datos.setearParametros("@COMENTARIOFINAL", nuevo.ComentarioFinal);
              
                //FALTA FECHA 
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

        public void modificar(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Incidentes set IDEMPLEADO = @IDEMPLEADO, IDCLIENTE = @IDCLIENTE, FECHA_INICIO = '2021/01/02', FECHA_CIERRE = getDate(), DETALLES = @DETALLES, IDESTADO = @IDESTADO, COMENTARIOFINAL = @COMENTARIOFINAL Where ID = " + nuevo.ID + "");
                datos.setearParametros("@IDEMPLEADO", nuevo.Empleado.Legajo);
                datos.setearParametros("@IDCLIENTE", nuevo.Cliente.IDCliente);
                datos.setearParametros("@DETALLES", nuevo.Detalles);
                datos.setearParametros("@IDESTADO", nuevo.Estado.IDEstado);
                datos.setearParametros("@COMENTARIOFINAL", nuevo.ComentarioFinal);

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

        public void eliminar(Incidente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Incidentes Where ID = " + nuevo.ID + "");
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
                datos.setearConsulta("Select ID, IDEMPLEADO, IDCLIENTE, IDESTADO Where ID = '" + buscar.ID + "'");
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

                    //IMPORTANTE PARA COMPOSICION y PARA TRAER COSAS DE OTRAS TABLAS REGISTROS COMPUESTOS

                    /*aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];*/


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
