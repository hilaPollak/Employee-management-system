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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Window
    {
        public Accounts()
        {
            InitializeComponent();
        }
        /// <summary>
        /// when we press on the button nanny account window open
        /// </summary>
        private void ButtonNannyAccount_Click(object sender, RoutedEventArgs e)
        {
            Window Enter = new EnterNaanysAccount();//
            Enter.Show();//show the window
        }
        /// <summary>
        /// when we press on the button mother account window open
        /// </summary>
        private void ButtonMotherAccount_Click(object sender, RoutedEventArgs e)
        {
            Window Enter = new EnterMothersAccount();
            Enter.Show();// show the window
        }
    }
}
