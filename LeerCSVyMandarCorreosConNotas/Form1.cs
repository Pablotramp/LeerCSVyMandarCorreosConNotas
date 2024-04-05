using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LeerCSVyMandarCorreosConNotas
{
    public partial class Form1 : Form
    {
        public static System.IO.FileInfo infoFichero;
        public static List<Alumno> listaAlumnos;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LblRutaFichero.Text = "";
        }

        private static List<Alumno> CargarFichero(string rutaFichero)
        {
            listaAlumnos = new List<Alumno> { };
            string[] entrada;
            using (StreamReader ficheroLectura = new StreamReader(rutaFichero))
            {
                ficheroLectura.ReadLine(); // leo la cabecera para descartarla
                int noRegistros = 0;
                int sucesful = 0;
                while (!ficheroLectura.EndOfStream)
                {
                    noRegistros++;
                    try
                    {
                        entrada = ficheroLectura.ReadLine().Split(';');
                        listaAlumnos.Add(new Alumno(int.Parse(entrada[0]), entrada[1], entrada[2], decimal.Parse(entrada[3])));
                        sucesful++;
                    }
                    catch (Exception) { }
                }
                ficheroLectura.Close();
                if (noRegistros > sucesful) MessageBox.Show($"{noRegistros - sucesful} alumno(s) no ha(n) sido añadido(s) correctamente");
            }
            return listaAlumnos;
        }
        private void BtnCargarFichero_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                infoFichero = new System.IO.FileInfo(openFileDialog1.FileName);
                LblRutaFichero.Text = infoFichero.Name;
            }
        }
        private void BtnEnviarEmails_Click(object sender, EventArgs e)
        {
            if (LblRutaFichero.Text != "")
            {
                CargarFichero(infoFichero.FullName);
                string profesorEmail = "XXXXXXX@gmail.com";
                string profesorPass = "XXXXXXXX";

                System.Net.Mail.SmtpClient smtpGmail = new System.Net.Mail.SmtpClient();
                System.Net.Mail.MailMessage miCorreo = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential misDatos = new System.Net.NetworkCredential(profesorEmail, profesorPass);

                // configuracion del correo saliente
                smtpGmail.Host = "smtp.gmail.com";  // servidor         (se mira en la documentación del servidor)
                smtpGmail.Port = 587;               // puerto saliende  (se mira en la documentación del servidor)
                smtpGmail.EnableSsl = true;         // certificado
                smtpGmail.Credentials = misDatos;   // mail y password  (se genera uno para aplicaciones externas en la configuración de la cuenta)

                int enviados = 0;

                // configuración mensaje
                foreach (Alumno alumno in listaAlumnos)
                {
                    try
                    {
                        miCorreo.To.Add(alumno.Email_Alumno);
                        miCorreo.To.Add(profesorEmail);
                        miCorreo.Subject = "Calificación curso AFD";
                        miCorreo.Body = alumno.ToString();
                        miCorreo.From = new System.Net.Mail.MailAddress(profesorEmail, "Calificación curso AFD");

                        smtpGmail.Send(miCorreo);
                        enviados++;
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString().Contains("cliente no se autenticó")) MessageBox.Show("La dirección de correo o la contraseña del remitente son erróneas", "Error de autentificación: ");
                        else if (ex.ToString().Contains("no tiene la forma obligatoria para una direcc")) MessageBox.Show($"La dirección de correo de {alumno.Nombre_Alumno} es incorrecta", "Direccion de Correo Erronea: ");
                        else MessageBox.Show(ex.ToString(), "Error genérico: ");
                    }
                }
                MessageBox.Show($"Se han enviado {enviados} de {listaAlumnos.Count} correos", "CUIDADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    public class Alumno
    {
        public int Id_Alumno;
        public string Nombre_Alumno;
        public string Email_Alumno;
        public decimal Calificacion_Alumno;
        public bool Aprobado;

        public Alumno(int id_Alumno, string nombre_Alumno, string email_Alumno, decimal calificacion_Alumno)
        {
            Id_Alumno = id_Alumno;
            Nombre_Alumno = nombre_Alumno;
            Email_Alumno = email_Alumno;
            Calificacion_Alumno = calificacion_Alumno;
            if (calificacion_Alumno >= 5) Aprobado = true;
            else Aprobado = false;
        }
        public override string ToString()
        {
            if (Aprobado) return $"Estimad@ {Nombre_Alumno}\n \n A tua calificación no curso é: APTO\n \nNoraboa. \n \nO Titor.";
            else return $"Estimad@ {Nombre_Alumno}\n \nA tua calificación no curso é: NON APTO\n \n Lembra que tes unha recuperación en Setembro.\n \nO Titor.";
        }
    }
}
