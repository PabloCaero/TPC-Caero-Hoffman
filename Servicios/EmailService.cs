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
            server.Port = 25;
            server.Host = "smtp.live.com";
        }

        public void armarCorreoIncidenteAbierto(Incidente incidente)
        {
            try
            {
                email = new MailMessage();
                email.From = new MailAddress("pcaero_programacion@hotmail.com");
                email.To.Add(incidente.Cliente.Email);
                email.Subject = "Apertura de incidente #" + incidente.ID + "";
                email.IsBodyHtml = true;
                email.Body = "<h1>******DETALLES DE INCIDENTE #"+ incidente.ID + "******</h1>";
            }
            catch(Exception ex)
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
