using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//For accessing the "ProtectedData" class: Add Reference, Assembly: System.Security.dll
namespace InventoryManager.ViewModels
{    
    partial class MainViewModel
    {
        //public string GmailUsernameOfSender { get; private set; } = "toth.tozso.zoltan@gmail.com";
        string _gmailUsernameOfSender = Properties.Settings.Default.GmailUsernameOfSender;
        public string GmailUsernameOfSender
        {
            get { return _gmailUsernameOfSender; }
            set
            {
                _gmailUsernameOfSender = value;                
                Properties.Settings.Default.GmailUsernameOfSender = value;
                Properties.Settings.Default.Save();
            }
        }

        string _gmailPasswordOfSender = Properties.Settings.Default.GmailPasswordOfSender;
        public string GmailPasswordOfSender
        {
            get { return _gmailPasswordOfSender; }
            set
            {
                _gmailPasswordOfSender = Protect(value);
                Properties.Settings.Default.GmailPasswordOfSender = Protect(value);
                Properties.Settings.Default.Save();
            }
        }

        string _gmailUsernameOfReceiver = Properties.Settings.Default.GmailUsernameOfReceiver;
        public string GmailUsernamesOfReceiver
        {
            get { return _gmailUsernameOfReceiver; }
            set
            {
                _gmailUsernameOfReceiver = value;
                Properties.Settings.Default.GmailUsernameOfReceiver = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string Protect(string str)
        {
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            byte[] data = Encoding.ASCII.GetBytes(str);
            string protectedData = Convert.ToBase64String(ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser));
            return protectedData;
        }

        public static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.ASCII.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }

        public void Send(string alertMessage)
        {
            try
            {
                NetworkCredential credential = new NetworkCredential(GmailUsernameOfSender, Unprotect(GmailPasswordOfSender));

                SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.gmail.com",                   
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = credential
                };
                
                MailMessage message = new MailMessage()//(GmailUsernameOfSender, GmailUsernameOfReceiver)
                {
                    From = new MailAddress(GmailUsernameOfSender),
                    Subject = $"Invenrory Manager auto generated report on {DateTime.Now.ToShortDateString()}.",
                    Body = $"XXXXXXXXXXXXXXx"
                };

                foreach (string addr in GmailUsernamesOfReceiver.Split(';'))
                {
                    message.To.Add(addr);
                }


                //var prot = Protect("Titkos");
                //var unprot = Unprotect(prot);
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on sending mail:\n{ex.Message}");
            }

        }
    }
}
