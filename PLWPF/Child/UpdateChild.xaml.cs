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
    /// Interaction logic for UpdateChild.xaml
    /// </summary>
    public partial class UpdateChild : Window
    {
        IBL bl;
        Child temp_child;
        public UpdateChild()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_child = new Child();
            idComboBox.ItemsSource = bl.GetAllChild();//conect the comboBox to the children id 
            idComboBox.DisplayMemberPath = "Id";
            idComboBox.SelectedValuePath = "Id";

        }
        /// <summary>
        /// after you chose one id -all the detels will apper - by the id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                temp_child = (Child)(idComboBox.SelectedItem);
                DataContext = temp_child;
                gridDeteles.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }


        /// <summary>
        /// if one cheang the date it will up date in the temperery nanny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateOfBirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_child.DateOfBirth = ((DateTime)dateOfBirthDatePicker.SelectedDate);
        }

        /// <summary>
        /// after up date the data you press the button to chang and save the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.Mother m = bl.FindMother(temp_child.IdMother);
                if (ThePassword.Password != m.Password)//only the mother with the password can update the child
                {
                    ThePassword.BorderBrush = Brushes.Red;
                    throw new Exception("the password is incorrect");
                }
                if ((dateOfBirthDatePicker.SelectedDate) > (DateTime.Now))//if the child dident born yet
                {
                    dateOfBirthDatePicker.BorderBrush = Brushes.Red;
                    throw new Exception("INCORRECT DATE");
                }
                bl.UpDateChild(temp_child);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}