using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PrioridadNegocio
    {
        //IMPORTANTE PARA DROPDOWNLIST
        public List<Prioridad> listarConSP()
        {
            List<Prioridad> lista = new List<Prioridad>();
            Prioridad aux = new Prioridad();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ListarPrioridades");
                datos.ejecturaLectura();
                while (datos.Lector.Read())
                {

                    aux.IDPrioridad = (int)datos.Lector["ID"];
                    aux.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];


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


        public List<Prioridad> listar()
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, PRIORIDAD From Prioridades");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.IDPrioridad = (int)datos.Lector["ID"];
                    aux.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];


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

        public void agregar(Prioridad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Insert Into Prioridades(PRIORIDAD) Values(@PRIORIDAD)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@PRIORIDAD", nuevo.Nombre_Prioridad);


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

        public void modificar(Prioridad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Prioridades set PRIORIDAD = @PRIORIDAD Where ID = " + nuevo.IDPrioridad + "");
                datos.setearParametros("@PRIORIDAD", nuevo.Nombre_Prioridad);

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

        public void eliminar(Prioridad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Prioridadades Where ID = " + nuevo.IDPrioridad + "");
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

        public List<Prioridad> buscarID(Prioridad buscar)
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, PRIORIDAD From Prioridades Where ID = '" + buscar.IDPrioridad + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.IDPrioridad = (int)datos.Lector["ID"];
                    aux.Nombre_Prioridad = (string)datos.Lector["PRIORIDAD"];


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
