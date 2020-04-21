using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

//For accessing the "ProtectedData" class: Add Reference, Assembly: System.Security.dll
namespace InventoryManager.ViewModels
{    
    partial class MainViewModel
    {
        private DispatcherTimer alarm;
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
                if (row.ColorSet.Color == Color.FromArgb(0x39, 0xFF, 0x00, 0x00))
                    //messageRed += $"{row.ProductName}\t{row.Description}\t{row.LocationName}\t{row.BestBefore}\t{row.Quantity}\t{row.UnitName}\n";
                    messageRed += String.Format("{0,-35}{1,-35}{2,-15}{3,-15:yyyy.MM.dd.}{4,-10:F}{5,-10}\n", row.ProductName, row.Description, row.LocationName, row.BestBefore, row.Quantity, row.UnitName);
                if (row.ColorSet.Color == Colors.SlateGray)
                    messageGrey += String.Format("{0,-35}{1,-35}{2,-15}{3,-15:yyyy.MM.dd.}{4,-10:F}{5,-10}\n", row.ProductName, row.Description, row.LocationName, row.BestBefore, row.Quantity, row.UnitName);
            }

            if (messageRed == "The following items will expire soon:\n")  messageRed = "Nothing will expire soon.\n";
            if (messageGrey == "The following items have already expired:\n") messageGrey = "Nothing has already expired.";
            
            return messageRed + "\n" + messageGrey;
        }

        public void Send()
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

                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on sending mail:\n{ex.Message}");
            }            
        }

        bool _sendOnMondays = Properties.Settings.Default.SendOnMondays;
        public bool SendOnMondays
        {
            get { return _sendOnMondays; }
            set
            {
                _sendOnMondays = value;
                Properties.Settings.Default.SendOnMondays = value;
                Properties.Settings.Default.Save();
            }
        }

        bool _sendOnTuesdays = Properties.Settings.Default.SendOnTuesdays;
        public bool SendOnTuesdays
        {
            get { return _sendOnTuesdays; }
            set
            {
                _sendOnTuesdays = value;
                Properties.Settings.Default.SendOnTuesdays = value;
                Properties.Settings.Default.Save();
            }
        }

        bool _sendOnWednesdays = Properties.Settings.Default.SendOnWednesdays;
        public bool SendOnWednesdays
        {
            get { return _sendOnWednesdays; }
            set
            {
                _sendOnWednesdays = value;
                Properties.Settings.Default.SendOnWednesdays = value;
                Properties.Settings.Default.Save();
            }
        }

        bool _sendOnThursdays = Properties.Settings.Default.SendOnThursdays;
        public bool SendOnThursdays
        {
            get { return _sendOnThursdays; }
            set
            {
                _sendOnThursdays = value;
                Properties.Settings.Default.SendOnThursdays = value;
                Properties.Settings.Default.Save();
            }
        }

        bool _sendOnFridays = Properties.Settings.Default.SendOnFridays;
        public bool SendOnFridays
        {
            get { return _sendOnFridays; }
            set
            {
                _sendOnFridays = value;
                Properties.Settings.Default.SendOnFridays = value;
                Properties.Settings.Default.Save();
            }
        }

        bool _sendOnSaturdays = Properties.Settings.Default.SendOnSaturdays;
        public bool SendOnSaturdays
        {
            get { return _sendOnSaturdays; }
            set
            {
                _sendOnSaturdays = value;
                Properties.Settings.Default.SendOnSaturdays = value;
                Properties.Settings.Default.Save();
            }
        }

        bool _sendOnSundays = Properties.Settings.Default.SendOnSundays;
        public bool SendOnSundays
        {
            get { return _sendOnSundays; }
            set
            {
                _sendOnSundays = value;
                Properties.Settings.Default.SendOnSundays = value;
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtMondays = Properties.Settings.Default.TimeAtMondays;
        public string TimeAtMondays
        {
            get { return _timeAtMondays; }
            set
            {
                _timeAtMondays = value;
                Properties.Settings.Default.TimeAtMondays = value;
                //NotifyOfPropertyChange(() => TimeAtMondays);
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtTuesdays = Properties.Settings.Default.TimeAtTuesdays;
        public string TimeAtTuesdays
        {
            get { return _timeAtTuesdays; }
            set
            {
                _timeAtTuesdays = value;
                Properties.Settings.Default.TimeAtTuesdays = value;
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtWednesdays = Properties.Settings.Default.TimeAtWednesdays;
        public string TimeAtWednesdays
        {
            get { return _timeAtWednesdays; }
            set
            {
                _timeAtWednesdays = value;
                Properties.Settings.Default.TimeAtWednesdays = value;
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtThursdays = Properties.Settings.Default.TimeAtThursdays;
        public string TimeAtThursdays
        {
            get { return _timeAtThursdays; }
            set
            {
                _timeAtThursdays = value;
                Properties.Settings.Default.TimeAtThursdays = value;
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtFridays = Properties.Settings.Default.TimeAtFridays;
        public string TimeAtFridays
        {
            get { return _timeAtFridays; }
            set
            {
                _timeAtFridays = value;
                Properties.Settings.Default.TimeAtFridays = value;
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtSaturdays = Properties.Settings.Default.TimeAtSaturdays;
        public string TimeAtSaturdays
        {
            get { return _timeAtSaturdays; }
            set
            {
                _timeAtSaturdays = value;
                Properties.Settings.Default.TimeAtSaturdays = value;
                Properties.Settings.Default.Save();
            }
        }

        string _timeAtSundays = Properties.Settings.Default.TimeAtSundays;
        public string TimeAtSundays
        {
            get { return _timeAtSundays; }
            set
            {
                _timeAtSundays = value;
                Properties.Settings.Default.TimeAtSundays = value;
                Properties.Settings.Default.Save();
            }
        }


        public void Scheduler()
        {
            alarm = new DispatcherTimer(TimeSpan.FromMinutes(10), DispatcherPriority.Normal, IsEmailSendingTime, Application.Current.Dispatcher);
            alarm.Start();
        }

        bool emailSendingOrdered = false;
        private void IsEmailSendingTime(object sender, EventArgs e)
        {
            CheckDayAndTimeToSendMail(SendOnMondays, DayOfWeek.Monday, TimeAtMondays);
            CheckDayAndTimeToSendMail(SendOnTuesdays, DayOfWeek.Tuesday, TimeAtTuesdays);
            CheckDayAndTimeToSendMail(SendOnWednesdays, DayOfWeek.Wednesday, TimeAtWednesdays);
            CheckDayAndTimeToSendMail(SendOnThursdays, DayOfWeek.Thursday, TimeAtThursdays);
            CheckDayAndTimeToSendMail(SendOnFridays, DayOfWeek.Friday, TimeAtFridays);
            CheckDayAndTimeToSendMail(SendOnSaturdays, DayOfWeek.Saturday, TimeAtSaturdays);
            CheckDayAndTimeToSendMail(SendOnSundays, DayOfWeek.Sunday, TimeAtSundays);
        }

        private void CheckDayAndTimeToSendMail(bool sendOnThatDay, DayOfWeek dayOfWeek, string timeOfThatDay)
        {
            if (sendOnThatDay && DateTime.Now.DayOfWeek == dayOfWeek)//ToDo true is for test, to be removed
            {
                DateTime.TryParseExact(timeOfThatDay, "HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime timeToSend);
                var timePassedSinceEnteringTheSendingWindow = DateTime.Now - timeToSend;
                if (timePassedSinceEnteringTheSendingWindow > TimeSpan.FromSeconds(0) && timePassedSinceEnteringTheSendingWindow < TimeSpan.FromMinutes(20)) //We are in the sending time window      
                { 
                    if (!emailSendingOrdered)
                    {
                        Send();
                        emailSendingOrdered = true;
                    }
                }
                else emailSendingOrdered = false;//We are out of the sending time window, so ready to send again
            }
        }
    }
}
