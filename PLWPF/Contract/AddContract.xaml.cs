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
    /// Interaction logic for AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        
        BE.Contract temp_contract;
        BL.IBL bl;
        /// <summary>
        /// this window add a new contract
        /// </summary>
        public AddContract()
        {
            try
            {
                InitializeComponent();
                temp_contract = new BE.Contract();
                this.DataContext = temp_contract;
                startContractDatePicker.DataContext = DateTime.Now;//restart the date picker's date to now
                endContractDatePicker.DataContext = DateTime.Now;//restart the date picker's date to now
                bl = BL.FactoryBL.GetBL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }

     /// <summary>
     /// when the user press this button the contract will add
     /// </summary>
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
           
                Close();//close the window
            
        }
        /// <summary>
        /// we want the user will see all the contract's ditales(also all the properies who's concluse by the system
        /// so we show up all the ditales of the contract
        /// </summary>
        private void enter_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (childIDTextBox.Text.Length > 9)//uncorect id
                {
                    childIDTextBox.BorderBrush = Brushes.Red;//brush in red the child's id text box
                    throw new Exception("id to long");
                }
                childIDTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update chils id

                

                if (nannyIDTextBox.Text.Length > 9)//uncorrect id
                {
                    nannyIDTextBox.BorderBrush = Brushes.Red;//brush in red the nanny's id text box
                    throw new Exception("id to long");
                }
                int id = Convert.ToInt32(nannyIDTextBox.Text);//id of nanny
                add_button.Visibility = Visibility;//the add button will show up
                temp_contract.StartContract = (DateTime)startContractDatePicker.SelectedDate;
                temp_contract.EndContract = (DateTime)endContractDatePicker.SelectedDate;
                bl.AddContract(temp_contract);//ad the contract
                view.Content = temp_contract.ToString();//print the contract's ditales
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
           
        }
    }
}
