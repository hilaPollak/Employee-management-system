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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        /// <summary>
        /// when the user press this button "NannyWindow" will show up
        /// </summary>

        private void ButtonNanny_Click(object sender, RoutedEventArgs e)
        {
            Window NannyWindow = new NannyWindow();
            NannyWindow.Show();//show the window
        }
        /// <summary>
        /// when the user press this button "MotherWindow" will show up
        /// </summary>
        private void ButtonMother_Click(object sender, RoutedEventArgs e)
        {
            Window MotherWindow = new MotherWindow();
            MotherWindow.Show();//show the window
        }
        /// <summary>
        /// when the user press this button "ChildWindow" will show up
        /// </summary>
        private void ButtonChild_Click(object sender, RoutedEventArgs e)
        {
            Window ChildWindow = new ChildWindow();
            ChildWindow.Show();//show the window
        }
        /// <summary>
        /// when the user press this button "ContractWindow" will show up
        /// </summary>
        private void ButtonContract_Click(object sender, RoutedEventArgs e)
        {
            Window ContractWindow = new ContractWindow();
            ContractWindow.Show();//show the window
        }
        /// <summary>
        /// when the user press this button "Accounts" will show up
        /// </summary>
        private void ButtonAccount_Click(object sender, RoutedEventArgs e)
        {
            Window account = new Accounts();
            account.Show();//show the window
        }
    }
}
