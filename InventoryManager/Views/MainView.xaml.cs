using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using InventoryManager.ViewModels;

using System.Text.RegularExpressions;

namespace InventoryManager.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            //MainViewModel.DateColoring dateColoring = new MainViewModel.DateColoring();
            //dateColoring.DefaultFor0Color = Properties.Settings.Default.DefaultFor0Color;
            //dateColoring.DefaultFor1Color = Properties.Settings.Default.DefaultFor1Color;
            //dateColoring.DefaultFor2Color = Properties.Settings.Default.DefaultFor2Color;
            //dateColoring.DefaultFor3Color = Properties.Settings.Default.DefaultFor3Color;

            //List<int> Coloring = new List<int>();
            //Coloring.Add((int)Properties.Settings.Default.DefaultFor0Color.TotalDays);
            //Coloring.Add((int)Properties.Settings.Default.DefaultFor1Color.TotalDays);
            //Coloring.Add((int)Properties.Settings.Default.DefaultFor2Color.TotalDays);
            //Coloring.Add((int)Properties.Settings.Default.DefaultFor3Color.TotalDays);

            //Colorxxx.



        }

        private void NumberValidationTextBoxQuantity(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^.0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
