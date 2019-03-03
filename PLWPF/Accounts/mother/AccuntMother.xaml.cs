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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AccuntMother.xaml
    /// </summary>
    public partial class AccuntMother : Window
    {/// <summary>
    /// enter to the mother's account
    /// </summary>
        public AccuntMother()
        {
            InitializeComponent();
        }
        /// <summary>
        /// when we press the button window 5_best_match will show
        /// </summary>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Window window = new _5_best_match();
            window.Show();//show the window
        }
        /// <summary>
        /// when we press the button window WantedNannies will show
        /// </summary>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window window = new WantedNannies();
            window.Show();//show the window
        }
        /// <summary>
        /// when we press the button window CloseNannies will show
        /// </summary>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {

            Window window = new CloseNannies();
            window.Show();//show the window
        }
        /// <summary>
        /// when we press the button window MotherAllContract will show
        /// </summary>
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MotherAllContract();
            window.Show();//show the window
        }
    }
   
}
