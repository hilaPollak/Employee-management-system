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
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public ContractWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// when the user press on this button AddContract window will open
        /// </summary>
        private void addContract_Click(object sender, RoutedEventArgs e)
        {
            Window addContract = new AddContract();
            addContract.Show();//show the window
        }
        /// <summary>
        /// when the user press on this button UpdateContract window will open
        /// </summary>
        private void upDateContract_Click(object sender, RoutedEventArgs e)
        {
            Window upDateContract = new UpdateContract();
            upDateContract.Show();//show the window
        }
        /// <summary>
        /// when the user press on this button DeleteContract window will open
        /// </summary>
        private void deleteContract_Click(object sender, RoutedEventArgs e)
        {
            Window deleteContract = new DeleteContract();
            deleteContract.Show();//show the window
        }
        /// <summary>
        /// when the user press on this button ShowContracts window will open
        /// </summary>
        private void viewContract_Click(object sender, RoutedEventArgs e)
        {
            Window viewContrac = new ShowContracts();
            viewContrac.Show();//show the window
        }
    }
}
