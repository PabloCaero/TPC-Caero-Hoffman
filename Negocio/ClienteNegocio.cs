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
                datos.setearConsulta("Select NOMBRE, APELLIDO, DNI,IDDIRECCION, EMAIL, TELEFONO From Clientes");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Nombre= (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Dni = (string)datos.Lector["DNI"];
                    aux.Direccion = new Direccion();
                    aux.Direccion.IDDireccion = (int)datos.Lector["IDDIRECCION"];
                    aux.Email = (string)datos.Lector["EMAIL"];
                    aux.Telefono = (string)datos.Lector["TELEFONO"];
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
    }
}