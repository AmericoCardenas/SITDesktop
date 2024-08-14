using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace SIT.SmtpEmail
{
    public class EnviarEmail
    {

        SmtpClient smtpClient;
        public string subject,body;
        public List<string> recipients = new List<string>();
       


        public EnviarEmail()
        {
             smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("facturaciontdavila@gmail.com", "xleezmwuccdcjjbp"),
                EnableSsl = true,
            };
        }

        public string DataGridViewToHtml(DataGridView dataGridView)
        {
            StringBuilder sb = new StringBuilder();

            // Start HTML table
            sb.Append("<table border='1'>");

            // Append column headers
            sb.Append("<tr>");
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                sb.Append("<th>").Append(column.HeaderText).Append("</th>");
            }
            sb.Append("</tr>");

            // Append data rows
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                sb.Append("<tr>");
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append("<td>").Append(cell.Value).Append("</td>");
                }
                sb.Append("</tr>");
            }

            // End HTML table
            sb.Append("</table>");

            return sb.ToString();
        }


        public void SendEmail()
        {
            foreach(var x in recipients)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.From = new MailAddress("facturaciontdavila@gmail.com");
                    mail.To.Add(new MailAddress(x));
                    mail.Subject = subject;
                    mail.Body = body;
                    smtpClient.Send(mail);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

            }
        }

        public void SendEmail2()
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = false;
            mail.From = new MailAddress("facturaciontdavila@gmail.com");
            mail.To.Add(new MailAddress("rh@transportesdavila.com.mx"));

            foreach (var x in recipients)
            {
                mail.CC.Add(new MailAddress(x));
            }


            mail.Subject = subject;
            mail.Body = body;
            smtpClient.Send(mail);
        }


    }
}
