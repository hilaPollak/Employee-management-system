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
    /// Interaction logic for AccountNanny.xaml
    /// </summary>
    public partial class AccountNanny : Window
    {
        /// <summary>
        /// show all the nannies func
        /// </summary>
        public AccountNanny()
        {
            InitializeComponent();
        }

        /// <summary>
        /// when the user press the button the window "AllChildrenOfNanny" will show
        /// </summary>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AllChildrenOfNanny();
            window.Show();
          
        }
        /// <summary>
        /// when the user press the button the window "MothersPhones" will show
        /// </summary>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MothersPhones();
            window.Show();
        }
        /// <summary>
        /// when the user press the button the window "BirthdaysOfChildren" will show
        /// </summary>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Window window = new BirthdaysOfChildren();
            window.Show();//show the window
        }
        /// <summary>
        /// when the user press the button the window "ChildrensSpacialNeeds" will show
        /// </summary>
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ChildrensSpacialNeeds();
            window.Show();//show the window
        }
        /// <summary>
        /// when the user press the button the window "NannyAllContracts" will show
        /// </summary>
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Window window = new NannyAllContracts();
            window.Show();//show the window
        }
    }
}
