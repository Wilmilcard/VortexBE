using System.Net.Mail;
using System.Net;
using VortexBE.Domain.Models;

namespace VortexBE.Utils
{
    public class EmailTools
    {
        public EmailTools(){ }

        public async Task SendEmailAsync(User user, Pago pago, Entrada entrada, Funcion funcion, string subject)
        {
            MailAddress addresFrom = new MailAddress("correo que envia", "Prueba Vortex");
            MailAddress addresTo = new MailAddress(user.Email);
            var message = new MailMessage(addresFrom, addresTo);
            message.Subject = subject;
            message.IsBodyHtml = true;
            

            var client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("correo que envia", "clave seguridad");

            var path = Globals.PathSystem(["VortexBE.Domain", "Assets"]);

            string emailBody = File.ReadAllText($"{path}\\confirmacion_pago.html")
                .Replace("{NOMBRE_CLIENTE}", $"{user.Nombre} {user.Apellido}")
                .Replace("{NUMERO_ORDEN}", pago.PagoId.ToString())
                .Replace("{CINE}", funcion.Sala.Cine.Nombre)
                .Replace("{SEDE}", funcion.Sala.Cine.Direccion)
                .Replace("{SALA}", funcion.Sala.Numero.ToString())
                .Replace("{PELICULA}", funcion.Pelicula.Titulo)
                .Replace("{FECHA_FUNCION}", funcion.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
                .Replace("{MONTO}", $"${entrada.Total}")
                .Replace("{MONEDA}", "COP")
                .Replace("{FECHA_PAGO}", Globals.SystemDate().ToString("dd/MM/yyyy HH:mm:ss"))
                .Replace("{METODO_PAGO}", pago.MetodoPago)
                .Replace("{URL_SOPORTE}", "https://vortexbird.com/")
                .Replace("{AÑO}", DateTime.Now.Year.ToString());

            message.Body = emailBody;

            try
            {
                client.Send(message);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error enviando correo: {ex.Message}");
            }
        }
    }
}
