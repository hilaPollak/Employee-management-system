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
    /// Interaction logic for DeleteContract.xaml
    /// </summary>
    public partial class DeleteContract : Window
    {
        BE.Contract temp_contract;
        BL.IBL bl;
        /// <summary>
        /// this window delete the contract
        /// </summary>
        public DeleteContract()
        {
            InitializeComponent();
            temp_contract = new BE.Contract();//the constructor is with default argument
            this.DataContext = temp_contract;
            bl = BL.FactoryBL.GetBL();
            codeComboBox.ItemsSource = bl.GetAllContract();// update the code combo box in all the codes
            codeComboBox.DisplayMemberPath = "Code";
            codeComboBox.SelectedValue = "Code";

        }
        /// <summary>
        /// when the user press this button the contract will be delete
        /// </summary>
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteContract(temp_contract.Code);//delete the contract
                MessageBox.Show("Contract Deleted");//show massege box
                Close();//close the window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }

        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_contract = (Contract)codeComboBox.SelectedItem;//update the contract according the code of the combo box
            view.Content = temp_contract.ToString();//print all the contract's ditales

        }
    }
}
