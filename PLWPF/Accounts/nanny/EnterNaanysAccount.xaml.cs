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
    /// Interaction logic for EnterNaanysAccount.xaml
    /// </summary>
    public partial class EnterNaanysAccount : Window
    {
        BE.Nanny temp_nanny;
        BL.IBL bl;
        /// <summary>
        /// check the ditales and enter to the nanny's account
        /// </summary>
        public EnterNaanysAccount()
        {
            try
            {
                InitializeComponent();
                temp_nanny = new BE.Nanny();//the constructor is with default argument
                this.NannyDetailsGrid.DataContext = temp_nanny;//update the datagrid
                bl = BL.FactoryBL.GetBL();

                idComboBox.ItemsSource = bl.GetAllNanny();//update the combobox to the al nannies id
                idComboBox.DisplayMemberPath = "Id";
                idComboBox.SelectedValue = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }

        /// <summary>
        /// when the user press this button he will get into the nanny's account
        /// </summary>
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(idComboBox.Text);//get the id from the combobox
                temp_nanny = bl.FindNanny(j);//find the nanny according the id
                if (ThePassword.Password != temp_nanny.Password)//check the password
                {
                    //password uncorrect
                    ThePassword.BorderBrush = Brushes.Red;// brosh in red the password's textbox
                    throw new Exception("the password is incorrect");
                }
                Window window = new AccountNanny();
                window.Show();//show the window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }
    }
}
