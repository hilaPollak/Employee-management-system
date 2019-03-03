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
    /// Interaction logic for AddChild.xaml
    /// </summary>
    public partial class AddChild : Window
    {

        BE.Child temp_child;
        BL.IBL bl;
      
        public AddChild()
        {
            try
            {
                InitializeComponent();
                temp_child = new BE.Child();
                this.DataContext = temp_child;
                dateOfBirthDatePicker.DataContext = new DateTime(2000, 1, 1);
                bl = BL.FactoryBL.GetBL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// to add new child to the list in the bl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idTextBox.Text.Length > 9)//check if the id to long ather way throw exception
                {
                    idTextBox.BorderBrush = Brushes.Red;
                    throw new Exception("id to long");
                }
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                nameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                lastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (idMotherTextBox.Text.Length > 9)
                {
                    idMotherTextBox.BorderBrush = Brushes.Red;
                    throw new Exception("mother's id to long");//check if the id to long ather way throw exception
                }
                idMotherTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                temp_child.DateOfBirth = (DateTime)dateOfBirthDatePicker.DataContext;
                bl.AddChild(temp_child);
                MessageBox.Show("child added");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }

        
    }
}
