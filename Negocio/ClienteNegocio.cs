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
                datos.setearConsulta("Select C.ID, C.NOMBRE, C.APELLIDO, C.DNI, C.IDDIRECCION, D.CALLE, D.ALTURA, D.LOCALIDAD, D.CODIGOPOSTAL, D.PROVINCIA, C.EMAIL, C.TELEFONO, C.FECHANACIMIENTO From Clientes C INNER JOIN Direccion D ON C.IDDIRECCION = D.ID");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IDCliente = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["EMAIL"];
                    aux.Telefono = (string)datos.Lector["TELEFONO"];
                    aux.Fecha_Nac = (DateTime)datos.Lector["FECHANACIMIENTO"];//ES ESTO

                    aux.Direccion = new Direccion();
                    aux.Direccion.IDDireccion = (int)datos.Lector["IDDIRECCION"];
                    aux.Direccion.Calle = (string)datos.Lector["CALLE"];
                    aux.Direccion.Numero = (int)datos.Lector["ALTURA"];  
                    aux.Direccion.Localidad = (string)datos.Lector["LOCALIDAD"];
                    aux.Direccion.Codigo_Postal = (string)datos.Lector["CODIGOPOSTAL"];
                    aux.Direccion.Provincia = (string)datos.Lector["PROVINCIA"];

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
                //AGREGA EL ID DE LA DIRECCION EN EL INCIDENTE   

                datos.setearConsulta("Insert Into Clientes(NOMBRE, APELLIDO, DNI, IDDIRECCION, EMAIL, TELEFONO, FECHANACIMIENTO) Values(@NOMBRE, @APELLIDO, @DNI, (Select ID From Direccion WHERE ID = (Select max(ID) From Direccion)), @EMAIL, @TELEFONO, @FECHANACIMIENTO)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@NOMBRE", nuevo.Nombre);
                datos.setearParametros("@APELLIDO", nuevo.Apellido);
                datos.setearParametros("@DNI", nuevo.Dni);
                datos.setearParametros("@EMAIL", nuevo.Email);
                datos.setearParametros("@TELEFONO", nuevo.Telefono);
                datos.setearParametros("@FECHANACIMIENTO", nuevo.Fecha_Nac);//ES ESTO
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
                datos.setearConsulta("Update Clientes set NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, DNI = @DNI,  EMAIL = @EMAIL, TELEFONO = @TELEFONO Where ID = " + nuevo.IDCliente + "");
                datos.setearParametros("@NOMBRE", nuevo.Nombre);
                datos.setearParametros("@APELLIDO", nuevo.Apellido);
                datos.setearParametros("@DNI", nuevo.Dni);
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
                datos.setearConsulta("Delete From Incidentes Where IDCliente = " + nuevo.IDCliente + "");
                datos.ejecutarAccion();
                datos.cerrarConexion();
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
                datos.setearConsulta("Select C.ID, C.NOMBRE, C.APELLIDO, C.DNI, C.IDDIRECCION, D.CALLE, D.ALTURA, D.LOCALIDAD, D.CODIGOPOSTAL, D.PROVINCIA, C.EMAIL, C.TELEFONO, C.FECHANACIMIENTO From Clientes C INNER JOIN Direccion D ON C.IDDIRECCION = D.ID AND C.DNI = '" + buscar.Dni + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IDCliente = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["EMAIL"];
                    aux.Telefono = (string)datos.Lector["TELEFONO"];
                    aux.Fecha_Nac = (DateTime)datos.Lector["FECHANACIMIENTO"];//ES ESTO

                    aux.Direccion = new Direccion();
                    aux.Direccion.IDDireccion = (int)datos.Lector["IDDIRECCION"];
                    aux.Direccion.Calle = (string)datos.Lector["CALLE"];
                    aux.Direccion.Numero = (int)datos.Lector["ALTURA"];
                    aux.Direccion.Localidad = (string)datos.Lector["LOCALIDAD"];
                    aux.Direccion.Codigo_Postal = (string)datos.Lector["CODIGOPOSTAL"];
                    aux.Direccion.Provincia = (string)datos.Lector["PROVINCIA"];

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

        public List<Cliente> buscarFecha(Cliente buscar)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select FECHAALTA, DNI, NOMBRE, APELLIDO From Clientes Where FECHAALTA= '" + buscar.Fecha_Alta + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Fecha_Alta = (DateTime)datos.Lector["FECHAALTA"];
                    aux.Dni = (string)datos.Lector["DNI"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
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