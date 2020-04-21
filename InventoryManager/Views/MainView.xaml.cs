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
            Regex regex = new Regex("[^.0-9]+"); //If not a digit or . then true and the character is not shown up in the textBox
            e.Handled = regex.IsMatch(e.Text);            
        }

        //List<char> textInput = new List<char>();
        //private void TimeValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    textInput.Add(e.Text.ToCharArray()[0]);

        //    if (textInput.Count() == 5)
        //    {
        //        var collectedChars = new string(textInput.ToArray());

        //        Regex regex = new Regex(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$");
        //        e.Handled = !regex.IsMatch(collectedChars);
        //        textInput.Clear();                
        //    }
        //    //else e.Handled = false;

        //    if (textInput.Count() > 5)
        //    {
        //        textInput.Clear();
        //        e.Handled = false;
        //    }


        //    //Regex regex = new Regex(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$");
        //    //e.Handled = regex.IsMatch(e.Text);
        //    DateTime unUsed;            
        //    e.Handled = !DateTime.TryParseExact(e.Text, "HH:mm",  System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out unUsed);
        //}

    }
}
