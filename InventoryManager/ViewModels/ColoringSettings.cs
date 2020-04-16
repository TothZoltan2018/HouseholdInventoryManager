using Caliburn.Micro;
using InventoryManager.Models;
using InventoryManager.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace InventoryManager.ViewModels
{
    partial class MainViewModel : Screen, IDataErrorInfo
    {
        #region Coloring properties                    
        int _defaultForColor1 = Properties.Settings.Default.DefaultForColor1;
        public int DefaultForColor1
        {
            get
            {

                return _defaultForColor1;
            }
            set
            {
                _defaultForColor1 = value;
                //NotifyOfPropertyChange(() => DefaultFor1Color);                
                Properties.Settings.Default.DefaultForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _defaultForColor2 = Properties.Settings.Default.DefaultForColor2;
        public int DefaultForColor2
        {
            get { return _defaultForColor2; }
            set
            {
                _defaultForColor2 = value;
                Properties.Settings.Default.DefaultForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _defaultForColor3 = Properties.Settings.Default.DefaultForColor3;
        public int DefaultForColor3
        {
            get { return _defaultForColor3; }
            set
            {
                _defaultForColor3 = value;
                Properties.Settings.Default.DefaultForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _meatInFreezerForColor1 = Properties.Settings.Default.MeatInFreezerForColor1;
        public int MeatInFreezerForColor1
        {
            get { return _meatInFreezerForColor1; }
            set
            {
                _meatInFreezerForColor1 = value;
                Properties.Settings.Default.MeatInFreezerForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _meatInFreezerForColor2 = Properties.Settings.Default.MeatInFreezerForColor2;
        public int MeatInFreezerForColor2
        {
            get { return _meatInFreezerForColor2; }
            set
            {
                _meatInFreezerForColor2 = value;
                Properties.Settings.Default.MeatInFreezerForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _meatInFreezerForColor3 = Properties.Settings.Default.MeatInFreezerForColor3;
        public int MeatInFreezerForColor3
        {
            get { return _meatInFreezerForColor3; }
            set
            {
                _meatInFreezerForColor3 = value;
                Properties.Settings.Default.MeatInFreezerForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _meatInRefrigeratorForColor1 = Properties.Settings.Default.MeatInRefrigeratorForColor1;
        public int MeatInRefrigeratorForColor1
        {
            get { return _meatInRefrigeratorForColor1; }
            set
            {
                _meatInRefrigeratorForColor1 = value;
                Properties.Settings.Default.MeatInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _meatInRefrigeratorForColor2 = Properties.Settings.Default.MeatInRefrigeratorForColor2;
        public int MeatInRefrigeratorForColor2
        {
            get { return _meatInRefrigeratorForColor2; }
            set
            {
                _meatInRefrigeratorForColor2 = value;
                Properties.Settings.Default.MeatInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _meatInRefrigeratorForColor3 = Properties.Settings.Default.MeatInRefrigeratorForColor3;
        public int MeatInRefrigeratorForColor3
        {
            get { return _meatInRefrigeratorForColor3; }
            set
            {
                _meatInRefrigeratorForColor3 = value;
                Properties.Settings.Default.MeatInRefrigeratorForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _coldCollationInFreezerForColor1 = Properties.Settings.Default.ColdCollationInFreezerForColor1;
        public int ColdCollationInFreezerForColor1
        {
            get { return _coldCollationInFreezerForColor1; }
            set
            {
                _coldCollationInFreezerForColor1 = value;
                Properties.Settings.Default.ColdCollationInFreezerForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _coldCollationInFreezerForColor2 = Properties.Settings.Default.ColdCollationInFreezerForColor2;
        public int ColdCollationInFreezerForColor2
        {
            get { return _coldCollationInFreezerForColor2; }
            set
            {
                _coldCollationInFreezerForColor2 = value;
                Properties.Settings.Default.ColdCollationInFreezerForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _coldCollationInFreezerForColor3 = Properties.Settings.Default.ColdCollationInFreezerForColor3;
        public int ColdCollationInFreezerForColor3
        {
            get { return _coldCollationInFreezerForColor3; }
            set
            {
                _coldCollationInFreezerForColor3 = value;
                Properties.Settings.Default.ColdCollationInFreezerForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _coldCollationInRefrigeratorForColor1 = Properties.Settings.Default.ColdCollationInRefrigeratorForColor1;
        public int ColdCollationInRefrigeratorForColor1
        {
            get { return _coldCollationInRefrigeratorForColor1; }
            set
            {
                _coldCollationInRefrigeratorForColor1 = value;
                Properties.Settings.Default.ColdCollationInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _coldCollationInRefrigeratorForColor2 = Properties.Settings.Default.ColdCollationInRefrigeratorForColor2;
        public int ColdCollationInRefrigeratorForColor2
        {
            get { return _coldCollationInRefrigeratorForColor2; }
            set
            {
                _coldCollationInRefrigeratorForColor2 = value;
                Properties.Settings.Default.ColdCollationInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _coldCollationInRefrigeratorForColor3 = Properties.Settings.Default.ColdCollationInRefrigeratorForColor3;
        public int ColdCollationInRefrigeratorForColor3
        {
            get { return _coldCollationInRefrigeratorForColor3; }
            set
            {
                _coldCollationInRefrigeratorForColor3 = value;
                Properties.Settings.Default.ColdCollationInRefrigeratorForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        #endregion Coloring properties 


        #region checking that days of yellow > orange > red
        //ToDo: Inconsistent. E.g switching to an other tab an then back, removes the red rectangle which shows the validation error. And some other issues.
        public string Error => throw new NotImplementedException();
        public string this[string columnName]
        {
            get
            {
                string[] textBoxNameStringsForColoring = { "DefaultForColor1", "DefaultForColor2", "DefaultForColor3",
                                                           "MeatInFreezerForColor1", "MeatInFreezerForColor2", "MeatInFreezerForColor3",
                                                           "MeatInRefrigeratorForColor1", "MeatInRefrigeratorForColor2", "MeatInRefrigeratorForColor3",
                                                           "ColdCollationInFreezerForColor1", "ColdCollationInFreezerForColor2", "ColdCollationInFreezerForColor3",
                                                           "ColdCollationInRefrigeratorForColor1", "ColdCollationInRefrigeratorForColor2", "ColdCollationInRefrigeratorForColor3",

                                                           };
                int[] textBoxNameIntsForColoring = { DefaultForColor1, DefaultForColor2, DefaultForColor3,
                                                     MeatInFreezerForColor1, MeatInFreezerForColor2, MeatInFreezerForColor3,
                                                     MeatInRefrigeratorForColor1, MeatInRefrigeratorForColor2, MeatInRefrigeratorForColor3,
                                                     ColdCollationInFreezerForColor1, ColdCollationInFreezerForColor2, ColdCollationInFreezerForColor3,
                                                     ColdCollationInRefrigeratorForColor1, ColdCollationInRefrigeratorForColor2, ColdCollationInRefrigeratorForColor3,


                                                    };
                string result = null;

                for (int i = 0; i < textBoxNameStringsForColoring.Length - 2; i += 3)
                {
                    if (columnName == textBoxNameStringsForColoring[i])
                    {
                        if (textBoxNameIntsForColoring[i] < textBoxNameIntsForColoring[i + 1] || textBoxNameIntsForColoring[i] < textBoxNameIntsForColoring[i + 2])
                            result = "Please set the values as follows: Yellow \"Days till exp.\" > Orange \"Days till exp. > Red \"Days till exp.\"";
                    }
                    else if (columnName == textBoxNameStringsForColoring[i + 1])
                    {
                        if (textBoxNameIntsForColoring[i] < textBoxNameIntsForColoring[i + 1] || textBoxNameIntsForColoring[i + 1] < textBoxNameIntsForColoring[i + 2])
                            result = "Please set the values as follows: Yellow \"Days till exp.\" > Orange \"Days till exp. > Red \"Days till exp.\"";
                    }
                    else if (columnName == textBoxNameStringsForColoring[i + 2])
                    {
                        if (textBoxNameIntsForColoring[i] < textBoxNameIntsForColoring[i + 2] || textBoxNameIntsForColoring[i + 1] < textBoxNameIntsForColoring[i + 2])
                            result = "Please set the values as follows: Yellow \"Days till exp.\" > Orange \"Days till exp. > Red \"Days till exp.\"";
                    }
                }
                //if (columnName == "DefaultFor1Color")
                //{                    
                //    if (DefaultFor1Color < DefaultFor2Color || DefaultFor1Color < DefaultFor3Color)
                //            result = "Please set the values as follows: Yellow \"Days till exp.\" > Orange \"Days till exp. > Red \"Days till exp.\"";                    
                //}
                //else if (columnName == "DefaultFor2Color")
                //{
                //    if (DefaultFor1Color < DefaultFor2Color || DefaultFor2Color < DefaultFor3Color)
                //        result = "Please set the values as follows: Yellow \"Days till exp.\" > Orange \"Days till exp. > Red \"Days till exp.\"";
                //}
                //else if (columnName == "DefaultFor3Color")
                //{
                //    if (DefaultFor1Color < DefaultFor3Color || DefaultFor2Color < DefaultFor3Color)
                //        result = "Please set the values as follows: Yellow \"Days till exp.\" > Orange \"Days till exp. > Red \"Days till exp.\"";
                //}
                return result;
            }
        }
        # endregion checking that days of yellow > orange > red

        /// <summary>
        /// Sets the backgroundcolor each row of the table on the basis of time left before reaching "BestBefore" date.
        /// </summary>
        /// <returns></returns>
        public SolidColorBrush ColorDataBestBeforeColumn(ProductModelAllTablesMerged productModelAllTablesMerged)
        {
            //NotifyOfPropertyChange(() => DefaultForColor1);
            //NotifyOfPropertyChange(() => DefaultForColor2);
            //NotifyOfPropertyChange(() => DefaultForColor3);
            int[] textBoxNameIntsForColoring = { DefaultForColor1, DefaultForColor2, DefaultForColor3,
                                                     MeatInFreezerForColor1, MeatInFreezerForColor2, MeatInFreezerForColor3,
                                                     MeatInRefrigeratorForColor1, MeatInRefrigeratorForColor2, MeatInRefrigeratorForColor3,
                                                     ColdCollationInFreezerForColor1, ColdCollationInFreezerForColor2, ColdCollationInFreezerForColor3,
                                                     ColdCollationInRefrigeratorForColor1, ColdCollationInRefrigeratorForColor2, ColdCollationInRefrigeratorForColor3,
                                                };
            //ToDo ide kene, hogy prodcatid ez es a loc id az, akkor MeatInRefrigeratorForColor1, MeatInRefrigeratorForColor2, MeatInRefrigeratorForColor3,
            int timeTillExp = (int)(productModelAllTablesMerged.BestBefore - DateTime.Now).TotalDays;
 
            if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Meat && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Freezer)
                  return ColorsDependingOnCatAndLoc(timeTillExp, MeatInFreezerForColor1, MeatInFreezerForColor2, MeatInFreezerForColor3);
            
            //elseif ()
            else return ColorsDependingOnCatAndLoc(timeTillExp, DefaultForColor1, DefaultForColor2, DefaultForColor3);

            //if (timeTillExp < 0) return new SolidColorBrush(Colors.SlateGray);    
            //if (timeTillExp < DefaultForColor3) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0x00, 0x00));  //Red
            //if (timeTillExp < DefaultForColor2) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0x80, 0x00)); //Orange
            //if (timeTillExp < DefaultForColor1) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0xFF, 0x80)); //Yellow
            //else return new SolidColorBrush(Color.FromArgb(0x39, 0x00, 0xFF, 0x00)); //Green
            
        }

        private SolidColorBrush ColorsDependingOnCatAndLoc(int timeTillExp, int DayNumForColor1, int DayNumForColor2, int DayNumForColor3)
        {
            if (timeTillExp < 0) return new SolidColorBrush(Colors.SlateGray);
            if (timeTillExp < DayNumForColor3) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0x00, 0x00));  //Red
            if (timeTillExp < DayNumForColor2) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0x80, 0x00)); //Orange
            if (timeTillExp < DayNumForColor1) return new SolidColorBrush(Color.FromArgb(0x39, 0xFF, 0xFF, 0x80)); //Yellow
            else return new SolidColorBrush(Color.FromArgb(0x39, 0x00, 0xFF, 0x00)); //Green
        }


        // }
    }
}
