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
    /// Interaction logic for EnterMothersAccount.xaml
    /// </summary>
    public partial class EnterMothersAccount : Window
    {
        BE.Mother temp_mother;
        BL.IBL bl;
        /// <summary>
        /// check the mother's protection and enter to the mother account
        /// </summary>
        public EnterMothersAccount()
        {
            try
            {
                InitializeComponent();
                temp_mother = new BE.Mother();//the constructor is with default argument
                
                bl = BL.FactoryBL.GetBL();

                //update the id combo box
                idComboBox.ItemsSource = bl.GetAllMother();
                idComboBox.DisplayMemberPath = "Id";
                idComboBox.SelectedValue = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }

        /// <summary>
        /// enter the mother's account if the password is correct
        /// </summary>
        private void enter_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(idComboBox.Text);//get the id from the combobox
                temp_mother = bl.FindMother(j);//find the mother according the id
                if (ThePassword.Password != temp_mother.Password)//if the password is uncorrect
                {
                    ThePassword.BorderBrush = Brushes.Red;// brush the password text box in red
                    throw new Exception("the password is incorrect");
                }
                Window ACMOTHER = new AccuntMother();
                ACMOTHER.Show();// show AccuntMother window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }
    }
}
