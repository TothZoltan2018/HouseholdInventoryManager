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

        int _dairyInRefrigeratorForColor1 = Properties.Settings.Default.DairyInRefrigeratorForColor1;
        public int DairyInRefrigeratorForColor1
        {
            get { return _dairyInRefrigeratorForColor1; }
            set
            {
                _dairyInRefrigeratorForColor1 = value;
                Properties.Settings.Default.DairyInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _dairyInRefrigeratorForColor2 = Properties.Settings.Default.DairyInRefrigeratorForColor2;
        public int DairyInRefrigeratorForColor2
        {
            get { return _dairyInRefrigeratorForColor2; }
            set
            {
                _dairyInRefrigeratorForColor2 = value;
                Properties.Settings.Default.DairyInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _dairyInRefrigeratorForColor3 = Properties.Settings.Default.DairyInRefrigeratorForColor3;
        public int DairyInRefrigeratorForColor3
        {
            get { return _dairyInRefrigeratorForColor3; }
            set
            {
                _dairyInRefrigeratorForColor3 = value;
                Properties.Settings.Default.DairyInRefrigeratorForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _dairyInFreezerForColor1 = Properties.Settings.Default.DairyInFreezerForColor1;
        public int DairyInFreezerForColor1
        {
            get { return _dairyInFreezerForColor1; }
            set
            {
                _dairyInFreezerForColor1 = value;
                Properties.Settings.Default.DairyInFreezerForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _dairyInFreezerForColor2 = Properties.Settings.Default.DairyInFreezerForColor2;
        public int DairyInFreezerForColor2
        {
            get { return _dairyInFreezerForColor2; }
            set
            {
                _dairyInFreezerForColor2 = value;
                Properties.Settings.Default.DairyInFreezerForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _dairyInFreezerForColor3 = Properties.Settings.Default.DairyInFreezerForColor3;
        public int DairyInFreezerForColor3
        {
            get { return _dairyInFreezerForColor3; }
            set
            {
                _dairyInFreezerForColor3 = value;
                Properties.Settings.Default.DairyInFreezerForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _eggInRefrigeratorForColor1 = Properties.Settings.Default.EggInRefrigeratorForColor1;
        public int EggInRefrigeratorForColor1
        {
            get { return _eggInRefrigeratorForColor1; }
            set
            {
                _eggInRefrigeratorForColor1 = value;
                Properties.Settings.Default.EggInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _eggInRefrigeratorForColor2 = Properties.Settings.Default.EggInRefrigeratorForColor2;
        public int EggInRefrigeratorForColor2
        {
            get { return _eggInRefrigeratorForColor2; }
            set
            {
                _eggInRefrigeratorForColor2 = value;
                Properties.Settings.Default.EggInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _eggInRefrigeratorForColor3 = Properties.Settings.Default.EggInRefrigeratorForColor3;
        public int EggInRefrigeratorForColor3
        {
            get { return _eggInRefrigeratorForColor3; }
            set
            {
                _eggInRefrigeratorForColor3 = value;
                Properties.Settings.Default.EggInRefrigeratorForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _eggInFlatForColor1 = Properties.Settings.Default.EggInFlatForColor1;
        public int EggInFlatForColor1
        {
            get { return _eggInFlatForColor1; }
            set
            {
                _eggInFlatForColor1 = value;
                Properties.Settings.Default.EggInFlatForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _eggInFlatForColor2 = Properties.Settings.Default.EggInFlatForColor2;
        public int EggInFlatForColor2
        {
            get { return _eggInFlatForColor2; }
            set
            {
                _eggInFlatForColor2 = value;
                Properties.Settings.Default.EggInFlatForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _eggInFlatForColor3 = Properties.Settings.Default.EggInFlatForColor3;
        public int EggInFlatForColor3
        {
            get { return _eggInFlatForColor3; }
            set
            {
                _eggInFlatForColor3 = value;
                Properties.Settings.Default.EggInFlatForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _readyInFreezerForColor1 = Properties.Settings.Default.ReadyInFreezerForColor1;
        public int ReadyInFreezerForColor1
        {
            get { return _readyInFreezerForColor1; }
            set
            {
                _readyInFreezerForColor1 = value;
                Properties.Settings.Default.ReadyInFreezerForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _readyInFreezerForColor2 = Properties.Settings.Default.ReadyInFreezerForColor2;
        public int ReadyInFreezerForColor2
        {
            get { return _readyInFreezerForColor2; }
            set
            {
                _readyInFreezerForColor2 = value;
                Properties.Settings.Default.ReadyInFreezerForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _readyInFreezerForColor3 = Properties.Settings.Default.ReadyInFreezerForColor3;
        public int ReadyInFreezerForColor3
        {
            get { return _readyInFreezerForColor3; }
            set
            {
                _readyInFreezerForColor3 = value;
                Properties.Settings.Default.ReadyInFreezerForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _readyInRefrigeratorForColor1 = Properties.Settings.Default.ReadyInRefrigeratorForColor1;
        public int ReadyInRefrigeratorForColor1
        {
            get { return _readyInRefrigeratorForColor1; }
            set
            {
                _readyInRefrigeratorForColor1 = value;
                Properties.Settings.Default.ReadyInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _readyInRefrigeratorForColor2 = Properties.Settings.Default.ReadyInRefrigeratorForColor2;
        public int ReadyInRefrigeratorForColor2
        {
            get { return _readyInRefrigeratorForColor2; }
            set
            {
                _readyInRefrigeratorForColor2 = value;
                Properties.Settings.Default.ReadyInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _readyInRefrigeratorForColor3 = Properties.Settings.Default.ReadyInRefrigeratorForColor3;
        public int ReadyInRefrigeratorForColor3
        {
            get { return _readyInRefrigeratorForColor3; }
            set
            {
                _readyInRefrigeratorForColor3 = value;
                Properties.Settings.Default.ReadyInRefrigeratorForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _conserveForColor1 = Properties.Settings.Default.ConserveForColor1;
        public int ConserveForColor1
        {
            get { return _conserveForColor1; }
            set
            {
                _conserveForColor1 = value;
                Properties.Settings.Default.ConserveForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _conserveForColor2 = Properties.Settings.Default.ConserveForColor2;
        public int ConserveForColor2
        {
            get { return _conserveForColor2; }
            set
            {
                _conserveForColor2 = value;
                Properties.Settings.Default.ConserveForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _conserveForColor3 = Properties.Settings.Default.ConserveForColor3;
        public int ConserveForColor3
        {
            get { return _conserveForColor3; }
            set
            {
                _conserveForColor3 = value;
                Properties.Settings.Default.ConserveForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _vegsAndFruitsInRefrigeratorForColor1 = Properties.Settings.Default.VegsAndFruitsInRefrigeratorForColor1;
        public int VegsAndFruitsInRefrigeratorForColor1
        {
            get { return _vegsAndFruitsInRefrigeratorForColor1; }
            set
            {
                _vegsAndFruitsInRefrigeratorForColor1 = value;
                Properties.Settings.Default.VegsAndFruitsInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _vegsAndFruitsInRefrigeratorForColor2 = Properties.Settings.Default.VegsAndFruitsInRefrigeratorForColor2;
        public int VegsAndFruitsInRefrigeratorForColor2
        {
            get { return _vegsAndFruitsInRefrigeratorForColor2; }
            set
            {
                _vegsAndFruitsInRefrigeratorForColor2 = value;
                Properties.Settings.Default.VegsAndFruitsInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _vegsAndFruitsInRefrigeratorForColor3 = Properties.Settings.Default.VegsAndFruitsInRefrigeratorForColor3;
        public int VegsAndFruitsInRefrigeratorForColor3
        {
            get { return _vegsAndFruitsInRefrigeratorForColor3; }
            set
            {
                _vegsAndFruitsInRefrigeratorForColor3 = value;
                Properties.Settings.Default.VegsAndFruitsInRefrigeratorForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _vegsAndFruitsInFlatForColor1 = Properties.Settings.Default.VegsAndFruitsInFlatForColor1;
        public int VegsAndFruitsInFlatForColor1
        {
            get { return _vegsAndFruitsInFlatForColor1; }
            set
            {
                _vegsAndFruitsInFlatForColor1 = value;
                Properties.Settings.Default.VegsAndFruitsInFlatForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _vegsAndFruitsInFlatForColor2 = Properties.Settings.Default.VegsAndFruitsInFlatForColor2;
        public int VegsAndFruitsInFlatForColor2
        {
            get { return _vegsAndFruitsInFlatForColor2; }
            set
            {
                _vegsAndFruitsInFlatForColor2 = value;
                Properties.Settings.Default.VegsAndFruitsInFlatForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _vegsAndFruitsInFlatForColor3 = Properties.Settings.Default.VegsAndFruitsInFlatForColor3;
        public int VegsAndFruitsInFlatForColor3
        {
            get { return _vegsAndFruitsInFlatForColor3; }
            set
            {
                _vegsAndFruitsInFlatForColor3 = value;
                Properties.Settings.Default.VegsAndFruitsInFlatForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _deepFrozenInFreezerForColor1 = Properties.Settings.Default.DeepFrozenInFreezerForColor1;
        public int DeepFrozenInFreezerForColor1
        {
            get { return _deepFrozenInFreezerForColor1; }
            set
            {
                _deepFrozenInFreezerForColor1 = value;
                Properties.Settings.Default.DeepFrozenInFreezerForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _deepFrozenInFreezerForColor2 = Properties.Settings.Default.DeepFrozenInFreezerForColor2;
        public int DeepFrozenInFreezerForColor2
        {
            get { return _deepFrozenInFreezerForColor2; }
            set
            {
                _deepFrozenInFreezerForColor2 = value;
                Properties.Settings.Default.DeepFrozenInFreezerForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _deepFrozenInFreezerForColor3 = Properties.Settings.Default.DeepFrozenInFreezerForColor3;
        public int DeepFrozenInFreezerForColor3
        {
            get { return _deepFrozenInFreezerForColor3; }
            set
            {
                _deepFrozenInFreezerForColor3 = value;
                Properties.Settings.Default.DeepFrozenInFreezerForColor3 = value;
                Properties.Settings.Default.Save();
            }
        }
        
        int _deepFrozenInRefrigeratorForColor1 = Properties.Settings.Default.DeepFrozenInRefrigeratorForColor1;
        public int DeepFrozenInRefrigeratorForColor1
        {
            get { return _deepFrozenInRefrigeratorForColor1; }
            set
            {
                _deepFrozenInRefrigeratorForColor1 = value;
                Properties.Settings.Default.DeepFrozenInRefrigeratorForColor1 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _deepFrozenInRefrigeratorForColor2 = Properties.Settings.Default.DeepFrozenInRefrigeratorForColor2;
        public int DeepFrozenInRefrigeratorForColor2
        {
            get { return _deepFrozenInRefrigeratorForColor2; }
            set
            {
                _deepFrozenInRefrigeratorForColor2 = value;
                Properties.Settings.Default.DeepFrozenInRefrigeratorForColor2 = value;
                Properties.Settings.Default.Save();
            }
        }

        int _deepFrozenInRefrigeratorForColor3 = Properties.Settings.Default.DeepFrozenInRefrigeratorForColor3;
        public int DeepFrozenInRefrigeratorForColor3
        {
            get { return _deepFrozenInRefrigeratorForColor3; }
            set
            {
                _deepFrozenInRefrigeratorForColor3 = value;
                Properties.Settings.Default.DeepFrozenInRefrigeratorForColor3 = value;
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
                                                           "DairyInFreezerForColor1", "DairyInFreezerForColor2", "DairyInFreezerForColor3",
                                                           "DairyInRefrigeratorForColor1", "DairyInRefrigeratorForColor2", "DairyInRefrigeratorForColor3",
                                                           "EggInRefrigeratorForColor1", "EggInRefrigeratorForColor2", "EggInRefrigeratorForColor3",
                                                           "EggInFlatForColor1", "EggInFlatForColor2", "EggInFlatForColor3",
                                                           "ReadyInFreezerForColor1", "ReadyInFreezerForColor2", "ReadyInFreezerForColor3",
                                                           "ReadyInRefrigeratorForColor1", "ReadyInRefrigeratorForColor2", "ReadyInRefrigeratorForColor3",
                                                           "ConserveForColor1", "ConserveForColor2", "ConserveForColor3",
                                                           "VegsAndFruitsInRefrigeratorForColor1", "VegsAndFruitsInRefrigeratorForColor2", "VegsAndFruitsInRefrigeratorForColor3",
                                                           "VegsAndFruitsInFlatForColor1", "VegsAndFruitsInFlatForColor2", "VegsAndFruitsInFlatForColor3",
                                                           "DeepFrozenInFreezerForColor1", "DeepFrozenInFreezerForColor2", "DeepFrozenInFreezerForColor3",
                                                           "DeepFrozenInRefrigeratorForColor1", "DeepFrozenInRefrigeratorForColor2", "DeepFrozenInRefrigeratorForColor3" };
                int[] textBoxNameIntsForColoring = { DefaultForColor1, DefaultForColor2, DefaultForColor3,
                                                    MeatInFreezerForColor1, MeatInFreezerForColor2, MeatInFreezerForColor3,
                                                    MeatInRefrigeratorForColor1, MeatInRefrigeratorForColor2, MeatInRefrigeratorForColor3,
                                                    ColdCollationInFreezerForColor1, ColdCollationInFreezerForColor2, ColdCollationInFreezerForColor3,
                                                    ColdCollationInRefrigeratorForColor1, ColdCollationInRefrigeratorForColor2, ColdCollationInRefrigeratorForColor3,
                                                    DairyInFreezerForColor1, DairyInFreezerForColor2, DairyInFreezerForColor3,
                                                    DairyInRefrigeratorForColor1, DairyInRefrigeratorForColor2, DairyInRefrigeratorForColor3,
                                                    EggInRefrigeratorForColor1, EggInRefrigeratorForColor2, EggInRefrigeratorForColor3,
                                                    EggInFlatForColor1, EggInFlatForColor2, EggInFlatForColor3,
                                                    ReadyInFreezerForColor1, ReadyInFreezerForColor2, ReadyInFreezerForColor3,
                                                    ReadyInRefrigeratorForColor1, ReadyInRefrigeratorForColor2, ReadyInRefrigeratorForColor3,
                                                    ConserveForColor1, ConserveForColor2, ConserveForColor3,
                                                    VegsAndFruitsInRefrigeratorForColor1, VegsAndFruitsInRefrigeratorForColor2, VegsAndFruitsInRefrigeratorForColor3,
                                                    VegsAndFruitsInFlatForColor1, VegsAndFruitsInFlatForColor2, VegsAndFruitsInFlatForColor3,
                                                    DeepFrozenInFreezerForColor1, DeepFrozenInFreezerForColor2, DeepFrozenInFreezerForColor3,
                                                    DeepFrozenInRefrigeratorForColor1, DeepFrozenInRefrigeratorForColor2, DeepFrozenInRefrigeratorForColor3 };
            
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
                                                    DairyInFreezerForColor1, DairyInFreezerForColor2, DairyInFreezerForColor3,
                                                    DairyInRefrigeratorForColor1, DairyInRefrigeratorForColor2, DairyInRefrigeratorForColor3,
                                                    EggInRefrigeratorForColor1, EggInRefrigeratorForColor2, EggInRefrigeratorForColor3,
                                                    EggInFlatForColor1, EggInFlatForColor2, EggInFlatForColor3,
                                                    ReadyInFreezerForColor1, ReadyInFreezerForColor2, ReadyInFreezerForColor3,
                                                    ReadyInRefrigeratorForColor1, ReadyInRefrigeratorForColor2, ReadyInRefrigeratorForColor3,
                                                    ConserveForColor1, ConserveForColor2, ConserveForColor3,
                                                    VegsAndFruitsInRefrigeratorForColor1, VegsAndFruitsInRefrigeratorForColor2, VegsAndFruitsInRefrigeratorForColor3,
                                                    VegsAndFruitsInFlatForColor1, VegsAndFruitsInFlatForColor2, VegsAndFruitsInFlatForColor3,
                                                    DeepFrozenInFreezerForColor1, DeepFrozenInFreezerForColor2, DeepFrozenInFreezerForColor3,
                                                    DeepFrozenInRefrigeratorForColor1, DeepFrozenInRefrigeratorForColor2, DeepFrozenInRefrigeratorForColor3 };
            
            int timeTillExp = (int)(productModelAllTablesMerged.BestBefore - DateTime.Now).TotalDays;
            #region rules for coloring according to product categories and locationcategories
            if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Meat && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Freezer)
                return ColorsDependingOnCatAndLoc(timeTillExp, MeatInFreezerForColor1, MeatInFreezerForColor2, MeatInFreezerForColor3);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Meat && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, MeatInRefrigeratorForColor1, MeatInRefrigeratorForColor2, MeatInRefrigeratorForColor3);
            
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.ColdCollation && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Freezer)
                return ColorsDependingOnCatAndLoc(timeTillExp, ColdCollationInFreezerForColor1, ColdCollationInFreezerForColor2, ColdCollationInFreezerForColor3);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.ColdCollation && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, ColdCollationInRefrigeratorForColor1, ColdCollationInRefrigeratorForColor2, ColdCollationInRefrigeratorForColor3);
            
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Dairy && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Freezer)
                return ColorsDependingOnCatAndLoc(timeTillExp, DairyInFreezerForColor1, DairyInFreezerForColor2, DairyInFreezerForColor3);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Dairy && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, DairyInRefrigeratorForColor1, DairyInRefrigeratorForColor2, DairyInRefrigeratorForColor3);
            
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Egg && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, EggInRefrigeratorForColor1, EggInRefrigeratorForColor2, EggInRefrigeratorForColor3);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Egg && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Flat)
                return ColorsDependingOnCatAndLoc(timeTillExp, EggInFlatForColor1, EggInFlatForColor2, EggInFlatForColor3);
            
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Ready && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, ReadyInRefrigeratorForColor1, ReadyInRefrigeratorForColor2, ReadyInRefrigeratorForColor3);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Ready && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Freezer)
                return ColorsDependingOnCatAndLoc(timeTillExp, ReadyInFreezerForColor1, ReadyInFreezerForColor2, ReadyInFreezerForColor3);
           
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.Conserve && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Flat)
                return ColorsDependingOnCatAndLoc(timeTillExp, ConserveForColor1, ConserveForColor2, ConserveForColor3);

            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.VegsAndFruits && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Flat)
                return ColorsDependingOnCatAndLoc(timeTillExp, VegsAndFruitsInFlatForColor1, VegsAndFruitsInFlatForColor1, VegsAndFruitsInFlatForColor1);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.VegsAndFruits && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, VegsAndFruitsInRefrigeratorForColor1, VegsAndFruitsInRefrigeratorForColor2, VegsAndFruitsInRefrigeratorForColor3);

            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.DeepFrozen && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Refrigerator)
                return ColorsDependingOnCatAndLoc(timeTillExp, DeepFrozenInRefrigeratorForColor1, DeepFrozenInRefrigeratorForColor2, DeepFrozenInRefrigeratorForColor3);
            else if (productModelAllTablesMerged.ProdCatName == Properties.Settings.Default.DeepFrozen && productModelAllTablesMerged.LocCatName == Properties.Settings.Default.Freezer)
                return ColorsDependingOnCatAndLoc(timeTillExp, DeepFrozenInFreezerForColor1, DeepFrozenInFreezerForColor2, DeepFrozenInFreezerForColor3);

            else return ColorsDependingOnCatAndLoc(timeTillExp, DefaultForColor1, DefaultForColor2, DefaultForColor3);
            #endregion
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
