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
    /// Interaction logic for DeleteChild.xaml
    /// </summary>
    public partial class DeleteChild : Window
    {
        BE.Child temp_child = new Child();
        BL.IBL bl;
        public DeleteChild()
        {

            try
            {
                InitializeComponent();
                bl = BL.FactoryBL.GetBL();
                
                idComboBox.ItemsSource = bl.GetAllChild();//enter values to the  idComboBox
                idComboBox.DisplayMemberPath = "Id";
                idComboBox.SelectedValue = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// delete a child from the bl list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(idComboBox.Text);
                temp_child = bl.FindChild(id);
                BE.Mother m = bl.FindMother(temp_child.IdMother);

                if (ThePassword.Password != m.Password )//befor delet you mast have the correct password
                {
                    ThePassword.BorderBrush = Brushes.Red;
                    throw new Exception("the password is incorrect");
                }
               
                bl.DeleteChild(id);
                MessageBox.Show("Child Deleted");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }

        /// <summary>
        /// after we deleted one it will remove from the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_child = (Child)idComboBox.SelectedItem;
            view.Content = temp_child.ToString();

        }
    }
}
