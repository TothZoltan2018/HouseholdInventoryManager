using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

//For accessing the "ProtectedData" class: Add Reference, Assembly: System.Security.dll
namespace InventoryManager.ViewModels
{    
    partial class MainViewModel
    {        
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

        public string CreateMessageToSendInEmail()
        {            
            string messageRed = "The following items will expire soon:\n";
            string messageGrey = "The following items have already expired:\n";
            foreach (var row in ProductsAllTablesMerged)
            {
                //If the item is red that is will be expired soon                
                if (row.ColorSet.Color ==  Color.FromArgb(0x39, 0xFF, 0x00, 0x00))            
                    messageRed += $"{row.ProductName}\t{row.Description}\t{row.LocationName}\t{row.BestBefore}\t{row.Quantity}\t{row.UnitName}\n";
                if (row.ColorSet.Color == Colors.SlateGray)
                    messageGrey += $"{row.ProductName}\t{row.Description}\t{row.LocationName}\t{row.BestBefore}\t{row.Quantity}\t{row.UnitName}\n";
            }

            if (messageRed == "The following items will expire soon:\n")  messageRed = "Nothing will expire soon.\n";
            if (messageGrey == "The following items have already expired:\n") messageGrey = "Nothing has already expired.";
            
            return messageRed + "\n" + messageGrey;
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
                    Body = CreateMessageToSendInEmail()
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
//Todo: Level elkuldve status uzenet, idozotes, annak konfigolasa. A mar lejart termekeket is belevenni a riportba