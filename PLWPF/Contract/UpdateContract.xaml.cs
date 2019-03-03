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
    /// Interaction logic for UpdateContract.xaml
    /// </summary>
    public partial class UpdateContract : Window
    {
        IBL bl;
        Contract temp_contract;
        /// <summary>
        /// this window update the contract
        /// </summary>
        public UpdateContract()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_contract = new Contract();
            codeComboBox.ItemsSource = bl.GetAllContract();// update the combo box according the code of all the contracts
            codeComboBox.DisplayMemberPath = "Code";
            codeComboBox.SelectedValuePath = "Code";

        }
        /// <summary>
        /// when the user choose the code from the combo box the details will show up
        /// </summary>
        private void codeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                temp_contract = (Contract)(codeComboBox.SelectedItem);// find the contract
                DataContext = temp_contract;// update the datagrid according the contract
                gridDeteles.IsEnabled = true;// enuble the detail's edit
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }


        /// <summary>
        /// update the start day
        /// </summary>
        private void startContractDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_contract.StartContract = ((DateTime)startContractDatePicker.SelectedDate);
        }
        /// <summary>
        /// update the end day
        /// </summary>
        private void endContractDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_contract.EndContract = ((DateTime)endContractDatePicker.SelectedDate);
        }

        /// <summary>
        /// when the user press this button all the details will update
        /// </summary>
        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.UpDateContract(temp_contract);//update the mother
                
                view.Content = temp_contract.ToString();//print the contract's details
                MessageBox.Show("Contract update");//massage box will show
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
