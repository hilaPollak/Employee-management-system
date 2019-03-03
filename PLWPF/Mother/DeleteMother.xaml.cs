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
    /// Interaction logic for DeleteMother.xaml
    /// </summary>
    public partial class DeleteMother : Window
    {
        BE.Mother temp_mother;
        BL.IBL bl;
        /// <summary>
        /// delete the mother 
        /// </summary>
        public DeleteMother()
        {
            InitializeComponent();
            try
            {
                InitializeComponent();
                temp_mother = new BE.Mother();//the constructor is with default argument
                this.DataContext = temp_mother;
                bl = BL.FactoryBL.GetBL();


                idTextBox.ItemsSource = bl.GetAllMother();//update the id combo box on al mother'd id
                idTextBox.DisplayMemberPath = "Id";
                idTextBox.SelectedValue = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// when the user press this button the nanny who chosed will be delete
        /// </summary>
        
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ThePassword.Password != temp_mother.Password)//if the password is uncorrect
                {
                    ThePassword.BorderBrush = Brushes.Red;//brush in red the password textbox
                    throw new Exception("the password is incorrect");
                }
                bl.DeleteMother(temp_mother.Id);//delete the mother who chosen
                foreach(var c in bl.GetAllChild())
                {
                    if (c.IdMother == temp_mother.Id)
                        bl.DeleteChild(c.Id);
                }
                MessageBox.Show("Mother and her children Deleted");//show massage box
                Close();//close the window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }
        /// <summary>
        /// when the user choose the id the ditales of the mother will show up
        /// </summary>
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_mother = (Mother)idTextBox.SelectedItem;//update temp_mother according the user
            view.Content = temp_mother.ToString();//view all the ditales of the mother

        }
    }
}