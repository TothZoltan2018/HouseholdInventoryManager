using Caliburn.Micro;
using InventoryManager.Models;
using InventoryManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace InventoryManager.ViewModels
{
    partial class MainViewModel : Screen
    {
        //public class DateColoring
        //{
        //public int DefaultFor1Color { get; set; } = Properties.Settings.Default.DefaultFor1Color;
        int _defaultFor1Color = Properties.Settings.Default.DefaultFor1Color;
        public int DefaultFor1Color
        {
            get { return _defaultFor1Color; }
            set {
                _defaultFor1Color = value;
                //NotifyOfPropertyChange(() => DefaultFor1Color);                
                Properties.Settings.Default.DefaultFor1Color = value;
                Properties.Settings.Default.Save();
            }
        }
            public int DefaultFor2Color { get; set; } = Properties.Settings.Default.DefaultFor2Color;
            public int DefaultFor3Color { get; set; } = Properties.Settings.Default.DefaultFor3Color;
            

            //public int[] MeatInFreezer { get; set; }
            //public int[] MeatInRefrigerator { get; set; }           
            //public int[] ColdCollationInFreezer  { get; set; }
            //public int[] ColdCollationInRefrigerator { get; set; }


            /// <summary>
            /// Sets the backgroundcolor each row of the table on the basis of time left before reaching "BestBefore" date.
            /// </summary>
            /// <returns></returns>
            public SolidColorBrush ColorDataBestBeforeColumn(DateTime getIn, DateTime bestBefore)
            {
                
                NotifyOfPropertyChange(() => DefaultFor1Color);
                int timeTillExp = (int)(bestBefore - DateTime.Now).TotalDays;            

                if (timeTillExp < 0) return new SolidColorBrush(Colors.SlateGray);    
                if (timeTillExp < DefaultFor3Color) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0x00, 0x00));  //Red
                if (timeTillExp < DefaultFor2Color) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0x80, 0x00)); //Orange
                if (timeTillExp < DefaultFor1Color) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0xFF, 0x80)); //Yellow
                else return new SolidColorBrush(Color.FromArgb(0x39, 0x00, 0xFF, 0x00)); //Green
            }
        }


   // }
}
