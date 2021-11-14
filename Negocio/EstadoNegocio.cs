using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> listar()
        {
            List<Estado> lista = new List<Estado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, NOMBREESTADO From Estados");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Estado aux = new Estado();
                    aux.IDEstado = (int)datos.Lector["ID"];
                    aux.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];

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

        public void agregar(Estado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Insert Into Estado(NOMBREESTADO) Values(@NOMBREESTADO)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@NOMBREESTADO", nuevo.Nombre_Estado);


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

        public void modificar(Estado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Estado set NOMBREESTADO = @NOMBREESTADO Where ID = " + nuevo.IDEstado + "");
                datos.setearParametros("@NOMBREESTADO", nuevo.Nombre_Estado);

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

        public void eliminar(Estado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Estados Where ID = " + nuevo.IDEstado + "");
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

        public List<Estado> buscarID(Estado buscar)
        {
            List<Estado> lista = new List<Estado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, NOMBREESTADO From Estados Where ID = '" + buscar.IDEstado + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Estado aux = new Estado();
                    aux.IDEstado = (int)datos.Lector["ID"];
                    aux.Nombre_Estado = (string)datos.Lector["NOMBREESTADO"];


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