

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
                string remitente, contrase�a, servidor, destinatario, asunto, cuerpo;

                // Verifica si la opci�n de "prueba default" est� seleccionada
                if (chkPruebaDefault.Checked)
                {
                    remitente = "rubentablet007@gmail.com";
                    contrase�a = "ynoogegsyvjqfwbt";
                    servidor = "smtp.gmail.com";
                    destinatario = "rdfajardos@gmail.com";
                    asunto = "Asunto del correo";
                    cuerpo = "Cuerpo del correo";
                }
                else
                {
                    // Utiliza los datos ingresados por el usuario
                    remitente = txtRemitente.Text;
                    contrase�a = txtContrase�a.Text;
                    servidor = txtServidor.Text;
                    destinatario = txtDestinatario.Text;
                    asunto = txtAsunto.Text;
                    cuerpo = txtCuerpo.Text;
                }

                // Configuraci�n del cliente SMTP
                SmtpClient client = new SmtpClient(servidor, 587)
                {
                    Credentials = new NetworkCredential(remitente, contrase�a),
                    EnableSsl = true
                };


                // Ignora la validaci�n del certificado (NO RECOMENDADO PARA PRODUCCI�N)
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                try
                {
                    // Env�a el correo electr�nico
                    MailMessage message = new MailMessage(remitente, destinatario, asunto, cuerpo);
                    client.Send(message);
                    Console.WriteLine("Correo enviado con �xito.");
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
