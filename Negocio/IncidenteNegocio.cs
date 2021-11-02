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
                datos.setearConsulta("Select Select ID, IDEMPLEADO, IDCLIENTE, DETALLES, IDESTADO, COMENTARIOFINAL From Incidentes");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.ID = (int)datos.Lector["NOMBRE"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IDCliente = (int)datos.Lector["IDCLIENTE"];
                    //aux.Fecha_Inicio = new DateTime();
                    //aux.Fecha_Inicio.ToString() = (DateTime)datos.Lector["FECHANACIMIENTO"];
                    //aux.Fecha_Cierre = new DateTime();
                    //aux.Fecha_Cierre.ToString('YYMMDD') = (DateTime)datos.Lector["Fe"]
                    aux.Detalles = (string)datos.Lector["DETALLES"];

                    aux.Estado = new Estado();
                    aux.Estado.IDEstado = (int)datos.Lector["IDESTADO"];

                    aux.ComentarioFinal = (string)datos.Lector["COMENTARIOFINAL"];
                  

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
