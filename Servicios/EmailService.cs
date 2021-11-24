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
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreoIncidenteAbierto(Cliente cliente)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@callcenter.com");
            email.To.Add(cliente.Email);
            email.Subject = "Apertura de incidente #";
            email.IsBodyHtml = true;
            email.Body = "<h1> Prueba Apertura </h1>";
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
