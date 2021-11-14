using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DireccionNegocio
    {
        public List<Direccion> listar()
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Select ID, CALLE, ALTURA, LOCALIDAD, CODIGOPOSTAL, PROVINCIA From Direccion");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.IDDireccion = (int)datos.Lector["ID"];
                    aux.Numero = (int)datos.Lector["ALTURA"];
                    aux.Calle = (string)datos.Lector["CALLE"];
                    aux.Localidad = (string)datos.Lector["LOCALIDAD"];
                    aux.Codigo_Postal = (string)datos.Lector["CODIGOPOSTAL"];
                    aux.Provincia = (string)datos.Lector["PROVINCIA"];
  
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

        public void agregar(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Insert Into Direccion(CALLE, ALTURA, LOCALIDAD, CODIGOPOSTAL, PROVINCIA) Values(@CALLE, @ALTURA, @LOCALIDAD, @CODIGOPOSTAL, @PROVINCIA)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@CALLE", nuevo.Calle);
                datos.setearParametros("@ALTURA", nuevo.Numero);
                datos.setearParametros("@LOCALIDAD", nuevo.Localidad);
                datos.setearParametros("@CODIGOPOSTAL", nuevo.Codigo_Postal);
                datos.setearParametros("@PROVINCIA", nuevo.Provincia);

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

        public void modificar(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Direccion set CALLE = @CALLE, ALTURA= @ALTURA, LOCALIDAD= @LOCALIDAD, CODIGOPOSTAL= @CODIGOPOSTAL, PROVINCIA= @PROVINCIA Where ID = " + nuevo.IDDireccion + "");
                datos.setearParametros("@CALLE", nuevo.Calle);
                datos.setearParametros("@ALTURA", nuevo.Numero);
                datos.setearParametros("@LOCALIDAD", nuevo.Localidad);
                datos.setearParametros("@CODIGOPOSTAL", nuevo.Codigo_Postal);
                datos.setearParametros("@PROVINCIA", nuevo.Provincia);

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

        public void eliminar(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Direccion Where ID = " + nuevo.IDDireccion + "");
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

        public List<Direccion> buscarID(Direccion buscar)
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select CALLE, ALTURA, LOCALIDAD, CODIGOPOSTAL, PROVINCIA From Direccion Where ID = '" + buscar.IDDireccion + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.IDDireccion = (int)datos.Lector["ID"];
                    aux.Numero = (int)datos.Lector["ALTURA"];
                    aux.Calle = (string)datos.Lector["CALLE"];
                    aux.Localidad = (string)datos.Lector["LOCALIDAD"];
                    aux.Codigo_Postal = (string)datos.Lector["CODIGOPOSTAL"];
                    aux.Provincia = (string)datos.Lector["PROVINCIA"];

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