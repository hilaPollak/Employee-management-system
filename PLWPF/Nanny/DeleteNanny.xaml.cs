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
    /// Interaction logic for DeleteNanny.xaml
    /// </summary>
    public partial class DeleteNanny : Window
    {
        BE.Nanny temp_nanny;
        BL.IBL bl;

        public DeleteNanny()
        {
            try
            {
                InitializeComponent();
                temp_nanny = new BE.Nanny();//the constructor is with default argument
                this.NannyDetailsGrid.DataContext = temp_nanny;
                bl = BL.FactoryBL.GetBL();

                idComboBox.ItemsSource = bl.GetAllNanny();
                idComboBox.DisplayMemberPath = "Id";
                idComboBox.SelectedValue = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }
    /// <summary>
    /// to delet the nanny from the list
    /// </summary>
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ThePassword.Password !=temp_nanny.Password)//befor we will alow sameone to delete - we will check he have the password
                {
                    ThePassword.BorderBrush = Brushes.Red;
                    throw new Exception("the password is incorrect");
                }
                bl.DeleteNanny(temp_nanny.Id);
                MessageBox.Show("Nanny Deleted");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }
    /// <summary>
    /// after one was deleted she wont apper in the combobox enymore
    /// </summary>
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_nanny = (Nanny)idComboBox.SelectedItem;
            view.Content = temp_nanny.ToString();

        }
    }
}
