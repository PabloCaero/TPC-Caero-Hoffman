using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Dominio;
using Negocio;

namespace Servicios
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("pcaero_programacion@hotmail.com", "123698745PROGRAMACION");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.live.com";
        }

        //ENVIO DE CORREO AL CLIENTE (ABIERTO)
        public void armarCorreoIncidenteAbierto(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Cliente.Email);
                email.Subject = "Apertura de Incidente #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #"+ incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + " </p><p> ESTADO: " + incidente.Estado.Nombre_Estado + " </p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL EMPLEADO (ABIERTO)
        public void armarCorreoIncidenteAbiertoEmpleado(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Empleado.Email);
                email.Subject = "SE TE HA ASIGNADO AL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO ASIGNADO EN EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy")+ "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "<p>ESTADO: " + incidente.Estado.Nombre_Estado + " </p></p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL EMPLEADO (ASIGNADO)
        public void armarCorreoIncidenteAsignadoEmpleado(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Empleado.Email);
                email.Subject = "SE TE HA REASIGNADO AL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO REASIGNADO EN EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + " </p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL CLIENTE (ASIGNADO)
        public void armarCorreoIncidenteAsignadoCliente(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Empleado.Email);
                email.Subject = "SE HA REASIGNADO AL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO REASIGNADO EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + " </p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL EMPLEADO (CERRADO)
        public void armarCorreoIncidenteCerradoEmpleado(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Empleado.Email);
                email.Subject = "SE HA CERRADO EL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO CERRADO EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + " </p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>FECHA CIERRE: " + incidente.Fecha_cierre.Date.ToString("dd/MM/yyyy") +"</p><p>COMENTARIO FINAL: " + incidente.ComentarioFinal + " </p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL CLIENTE (CERRADO)
        public void armarCorreoIncidenteCerradoCliente(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Cliente.Email);
                email.Subject = "SE HA CERRADO EL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO CERRADO EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + "</p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>FECHA CIERRE: " +incidente.Fecha_cierre.Date.ToString("dd / MM / yyyy")+ "</p><p>COMENTARIO FINAL: " + incidente.ComentarioFinal + " </p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL EMPLEADO (RESUELTO)
        public void armarCorreoIncidenteResueltoEmpleado(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Empleado.Email);
                email.Subject = "SE HA RESUELTO EL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO RESUELTO EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + "</p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>FECHA CIERRE: "+incidente.Fecha_cierre.Date.ToString("dd / MM / yyyy")+ "</p><p>COMENTARIO FINAL: " + incidente.ComentarioFinal + " </p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL CLIENTE (RESUELTO)
        public void armarCorreoIncidenteResueltoCliente(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Cliente.Email);
                email.Subject = "SE HA RESUELTO EL INCIDENTE #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO RESUELTO EL INCIDENTE #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + "</p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>FECHA CIERRE: "+incidente.Fecha_cierre.Date.ToString("dd/MM/yyyy")+"</p><p>COMENTARIO FINAL: " + incidente.ComentarioFinal + " </p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL CLIENTE (REABIERTO)
        public void armarCorreoIncidenteReabierto(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Cliente.Email);
                email.Subject = "Reapertura de Incidente #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO REABIERTO EL INCIDENTE #" + incidente.ID + "<p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + " </p><p> ESTADO: " + incidente.Estado.Nombre_Estado + " </p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ENVIO DE CORREO AL EMPLEADO (REABIERTO)
        public void armarCorreoIncidenteReabiertoEmpleado(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Empleado.Email);
                email.Subject = "SE TE HA ASIGNADO AL INCIDENTE REABIERTO #" + incidente.ID + " - Cliente: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre;
                email.IsBodyHtml = true;
                email.Body = "<p>&nbsp;ATENCION, HA SIDO ASIGNADO EN EL INCIDENTE REABIERTO #" + incidente.ID + "</p><p>&nbsp;***INICIO DETALLE DEL INCIDENTE***</p><p>NUMERO DE INCIDENTE: #" + incidente.ID + "</p><p>FECHA INICIO: " + incidente.Fecha_inicio.Date.ToString("dd/MM/yyyy") + "</p><p>CLIENTE: " + incidente.Cliente.Apellido + ", " + incidente.Cliente.Nombre + "</p><p>TÉCNICO ASIGNADO: " + incidente.Empleado.Apellido + ", " + incidente.Empleado.Nombre + "</p><p>ESPECIALIDAD: " + incidente.Especialidad.Nombre_Especialidad + "</p><p>ESTADO: " + incidente.Estado.Nombre_Estado + "</p><p>DETALLES: " + incidente.Detalles + "</p><p>PRIORIDAD: " + incidente.Prioridad.Nombre_Prioridad + "</p><p>***FIN DETALLE DEL INCIDENTE***</p><p><br></p><p><br></p><p><br></p>";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
