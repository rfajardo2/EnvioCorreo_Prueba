

using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EnvioCorreoApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void txtAsunto_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string remitente, contraseña, servidor, destinatario, asunto, cuerpo;

                // Verifica si la opción de "prueba default" está seleccionada
                if (chkPruebaDefault.Checked)
                {
                    remitente = "rubentablet007@gmail.com";
                    contraseña = "ynoogegsyvjqfwbt";
                    servidor = "smtp.gmail.com";
                    destinatario = "rdfajardos@gmail.com";
                    asunto = "Asunto del correo";
                    cuerpo = "Cuerpo del correo";
                }
                else
                {
                    // Utiliza los datos ingresados por el usuario
                    remitente = txtRemitente.Text;
                    contraseña = txtContraseña.Text;
                    servidor = txtServidor.Text;
                    destinatario = txtDestinatario.Text;
                    asunto = txtAsunto.Text;
                    cuerpo = txtCuerpo.Text;
                }

                // Configuración del cliente SMTP
                SmtpClient client = new SmtpClient(servidor, 587)
                {
                    Credentials = new NetworkCredential(remitente, contraseña),
                    EnableSsl = true
                };


                // Ignora la validación del certificado (NO RECOMENDADO PARA PRODUCCIÓN)
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                try
                {
                    // Envía el correo electrónico
                    MailMessage message = new MailMessage(remitente, destinatario, asunto, cuerpo);
                    client.Send(message);
                    Console.WriteLine("Correo enviado con éxito.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
