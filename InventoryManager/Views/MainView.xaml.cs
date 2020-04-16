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
using InventoryManager.ViewModels;

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
        }

        /// <summary>
        /// General check for TextBoxes for inputting float-like numbers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^.0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ManageDataTab_Clicked(object sender, MouseButtonEventArgs e)
        {
            //GenerateTableProductsToDisplay();
        }

        private void TabsOfMyApp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
