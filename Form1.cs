using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Email_Sending_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  VARIABLES

            string to;
            string from;
            string password;
            string title;
            string mail;

            //  Variables = TextBox.Text(s)

            to = (txtReceiver.Text).ToString();
            from = (txtSender.Text).ToString();
            password = (txtPassword.Text).ToString();
            title = (txtTitle.Text).ToString();
            mail = (txtMail.Text).ToString();

            //  Backend Proccess

            MailMessage msg = new MailMessage();
            msg.To.Add(to);
            msg.From = new MailAddress(from);
            msg.Body = mail;
            msg.Subject = title;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, password);

            //  EXCEPTION HANDLING

            try
            {
                smtp.Send(msg);
                MessageBox.Show("Email is sent succesfully !", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
