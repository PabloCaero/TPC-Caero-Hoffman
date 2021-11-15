using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CargoNegocio
    {
        //IMPORTANTE PARA DROPDOWNLIST
        public List<Cargo> listarConSP()
        {
            List<Cargo> lista = new List<Cargo>();
            Cargo aux = new Cargo();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ListarCargos");
                datos.ejecturaLectura();
                while (datos.Lector.Read())
                {
                    
                    aux.IDCargo = (int)datos.Lector["ID"];
                    aux.Nombre_Cargo = (string)datos.Lector["NOMBRECARGO"];


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


        public List<Cargo> listar()
        {
            List<Cargo> lista = new List<Cargo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, NOMBRECARGO From Cargos");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cargo aux = new Cargo();
                    aux.IDCargo = (int)datos.Lector["ID"];
                    aux.Nombre_Cargo = (string)datos.Lector["NOMBRECARGO"];
                  

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

        public void agregar(Cargo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Insert Into Cargo(NOMBRECARGO) Values(@NOMBRECARGO)"); //AGREGO FECHA DE NAC PORQUE NO SABEMOS COMO UTILIZARLO
                datos.setearParametros("@NOMBRECARGO", nuevo.Nombre_Cargo);
                

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

        public void modificar(Cargo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Cargo set NOMBRECARGO = @NOMBRECARGO Where ID = " + nuevo.IDCargo + "");
                datos.setearParametros("@NOMBRECARGO", nuevo.Nombre_Cargo);      

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

        public void eliminar(Cargo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From Cargo Where ID = " + nuevo.IDCargo + "");
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

        public List<Cargo> buscarID(Cargo buscar)
        {
            List<Cargo> lista = new List<Cargo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select ID, NOMBRECARGO From CargoS Where ID = '" + buscar.IDCargo + "'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cargo aux = new Cargo();
                    aux.IDCargo = (int)datos.Lector["ID"];
                    aux.Nombre_Cargo = (string)datos.Lector["NOMBRECARGO"];
                 

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