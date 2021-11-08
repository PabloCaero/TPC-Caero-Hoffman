using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Select ID, NOMBRE, APELLIDO, DNI, IDDIRECCION, EMAIL, TELEFONO From Clientes");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IDCliente = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];
                    aux.Direccion = new Direccion();
                    aux.Direccion.IDDireccion = (int)datos.Lector["IDDIRECCION"];
                    aux.Email = (string)datos.Lector["EMAIL"];
                    aux.Telefono = (string)datos.Lector["TELEFONO"];
                    //aux.Fecha_Alta = DateTime.Parse((string)datos.Lector["FECHA"]);
                    aux.Fecha_Alta = (DateTime)datos.Lector["FECHA"];//ES ESTO
                    

                    //aux.Fecha_Alta = new DateTime();
                    //aux.Fecha_Alta.ToString(d) = (DateTime)datos.Lector["FECHANACIMIENTO"];
                    //aux.Fecha_Nac = new DateTime();
                    //aux.Fecha_Nac.ToString('YYMMDD') = (DateTime)datos.Lector["Fe"]

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

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Clientes(NOMBRE, APELLIDO, DNI, IDDIRECCION, EMAIL, TELEFONO, FECHANACIMIENTO) Values(@NOMBRE, @APELLIDO, @DNI, @IDDIRECCION, @EMAIL, @TELEFONO, @FECHA_NAC)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@NOMBRE", nuevo.Nombre);
                datos.setearParametros("@APELLIDO", nuevo.Apellido);
                datos.setearParametros("@DNI", nuevo.Dni);
                datos.setearParametros("@IDDIRECCION", nuevo.Direccion.IDDireccion);
                datos.setearParametros("@EMAIL", nuevo.Email);
                datos.setearParametros("@TELEFONO", nuevo.Telefono);
                datos.setearParametros("@FECHA_NAC", nuevo.Fecha_Alta);//ES ESTO
                //FALTA FECHA NAC
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

        public void modificar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Clientes set NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, DNI = @DNI, IDDIRECCION = @IDDIRECCION, EMAIL = @EMAIL, TELEFONO = @TELEFONO, FECHANACIMIENTO = '2021/2/2' Where ID = " + nuevo.IDCliente + "");
                datos.setearParametros("@NOMBRE", nuevo.Nombre);
                datos.setearParametros("@APELLIDO", nuevo.Apellido);
                datos.setearParametros("@DNI", nuevo.Dni);
                datos.setearParametros("@IDDIRECCION", nuevo.Direccion.IDDireccion);
                datos.setearParametros("@EMAIL", nuevo.Email);
                datos.setearParametros("@TELEFONO", nuevo.Telefono);

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

        public void eliminar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Clientes Where ID = " + nuevo.IDCliente + "");
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

        public List<Cliente> buscarDNI(Cliente buscar)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select DNI, NOMBRE, APELLIDO Where DNI = '" + buscar.Dni + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];

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

        public List<Cliente> buscarNombre(Cliente buscar)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select DNI, NOMBRE, APELLIDO Where NOMBRE= '" + buscar.Nombre + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];

                    //IMPORTANTE PARA COMPOSICION y PARA TRAER COSAS DE OTRAS TABLAS REGISTROS COMPUESTOS

                    
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