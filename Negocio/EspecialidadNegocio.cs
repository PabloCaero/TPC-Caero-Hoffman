using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class  EspecialidadNegocio
    {
        //IMPORTANTE PARA DROPDOWNLIST
        public List<Especialidad> listarConSP()
        {
            List<Especialidad> lista = new List<Especialidad>();
            Especialidad aux = new Especialidad();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ListarEspecialidades");
                datos.ejecturaLectura();
                while (datos.Lector.Read())
                {

                    aux.IDEspecialidad = (int)datos.Lector["ID"];
                    aux.Nombre_Especialidad = (string)datos.Lector["Especialidad"];


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


        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, Especialidad From Especialidades");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IDEspecialidad = (int)datos.Lector["ID"];
                    aux.Nombre_Especialidad = (string)datos.Lector["Especialidad"];


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

        public void agregar(Especialidad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Insert Into Especialidades(Especialidad) Values(@Especialidad)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@Especialidad", nuevo.Nombre_Especialidad);


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

        public void modificar(Especialidad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Especialidades set Especialidad = @Especialidad Where ID = " + nuevo.IDEspecialidad + "");
                datos.setearParametros("@Especialidad", nuevo.Nombre_Especialidad);

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

        public void eliminar(Especialidad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Especialidadades Where ID = " + nuevo.IDEspecialidad + "");
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

        public List<Especialidad> buscarID(Especialidad buscar)
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, Especialidad From Especialidades Where ID = '" + buscar.IDEspecialidad + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IDEspecialidad = (int)datos.Lector["ID"];
                    aux.Nombre_Especialidad = (string)datos.Lector["Especialidad"];


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
