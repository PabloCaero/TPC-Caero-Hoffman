using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Select E.ID, E.NOMBREUSUARIO, E.CONTRASEÑA, E.NOMBRE, E.APELLIDO, E.DNI, E.IDCARGO, C.NOMBRECARGO, E.IDDIRECCION, D.CALLE, D.ALTURA, D.LOCALIDAD, D.CODIGOPOSTAL, D.PROVINCIA, E.EMAIL, E.TELEFONO, E.FECHANACIMIENTO From Empleados E INNER JOIN Direccion D ON E.IDDIRECCION = D.ID INNER JOIN Cargos C ON C.ID = E.IDCARGO");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Legajo= (int)datos.Lector["ID"];
                    aux.NombreUsuario = (string)datos.Lector["NOMBREUSUARIO"];
                    aux.Contrasena = (string)datos.Lector["CONTRASEÑA"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["EMAIL"];
                    aux.Telefono = (string)datos.Lector["TELEFONO"];
                    aux.Fecha_Nac = (DateTime)datos.Lector["FECHANACIMIENTO"];//ES ESTO

                    aux.Cargo = new Cargo();
                    aux.Cargo.IDCargo = (int)datos.Lector["IDCARGO"];
                    aux.Cargo.Nombre_Cargo = (string)datos.Lector["NOMBRECARGO"];

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

        public void agregar(Empleado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert Into Empleados(NOMBREUSUARIO, CONTRASEÑA, NOMBRE, APELLIDO, DNI, IDDIRECCION, IDCARGO, EMAIL, TELEFONO, FECHANACIMIENTO) Values(@NOMBREUSUARIO, @CONTRASEÑA, @NOMBRE, @APELLIDO, @DNI, (Select ID From Direccion WHERE ID = (Select max(ID) From Direccion)), @IDCARGO, @EMAIL, @TELEFONO, @FECHANACIMIENTO)"); 
                datos.setearParametros("@NOMBRE", nuevo.Nombre);
                datos.setearParametros("@APELLIDO", nuevo.Apellido);
                datos.setearParametros("@NOMBREUSUARIO", nuevo.NombreUsuario);
                datos.setearParametros("@CONTRASEÑA", nuevo.Contrasena);
                datos.setearParametros("@DNI", nuevo.Dni);
                datos.setearParametros("@EMAIL", nuevo.Email);
                datos.setearParametros("@IDCARGO", nuevo.Cargo.IDCargo);
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

        public void modificar(Empleado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Empleados set NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, DNI = @DNI,  EMAIL = @EMAIL, TELEFONO = @TELEFONO, FECHANACIMIENTO = @FECHANACIMIENTO, IDCARGO = @IDCARGO Where ID = " + nuevo.Legajo + "");
                datos.setearParametros("@NOMBRE", nuevo.Nombre);
                datos.setearParametros("@APELLIDO", nuevo.Apellido);
                datos.setearParametros("@IDCARGO", nuevo.Cargo.IDCargo);
                datos.setearParametros("@DNI", nuevo.Dni);
                datos.setearParametros("@EMAIL", nuevo.Email);
                datos.setearParametros("@TELEFONO", nuevo.Telefono);
                datos.setearParametros("@FECHANACIMIENTO", nuevo.Fecha_Nac);

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

        public void modificarPassword(Empleado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Empleados set CONTRASEÑA = @CONTRASEÑA Where ID = " + nuevo.Legajo + "");
                datos.setearParametros("@CONTRASEÑA", nuevo.Contrasena);
               
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

        public void eliminar(Empleado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Empleados Where ID = " + nuevo.Legajo + "");
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

       
        public List<Empleado> buscarLegajo(Empleado buscar)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, DNI, NOMBRE, APELLIDO From Empleados Where ID = '" + buscar.Legajo + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.Legajo = (int)datos.Lector["ID"];
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