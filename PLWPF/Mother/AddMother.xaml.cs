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
    /// Interaction logic for AddMother.xaml
    /// </summary>
    public partial class AddMother : Window
    {
        BE.Mother temp_mother;
        BL.IBL bl;
       /// <summary>
       /// this window add mother
       /// </summary>
        public AddMother()
        {
            try
            {
                InitializeComponent();
                temp_mother = new BE.Mother();
                this.DataContext = temp_mother;
               
                bl = BL.FactoryBL.GetBL();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// when the user press this button the mother wil add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                

                if (idTextBox.Text.Length > 9)//id uncorrect
                {
                    idTextBox.BorderBrush = Brushes.Red;//brush in red the id textbox
                    throw new Exception("id to long");
                }
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update id
                nameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update name
                lastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update lastname
                if (phoneTextBox.Text.Length > 10 || phoneTextBox.Text.Length < 5)//uncorect phone number
                {
                    phoneTextBox.BorderBrush = Brushes.Red;//brush in red phone text box
                    throw new Exception("phone number is incorrect");
                }
                phoneTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update phonetext
                addressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update adress
                addressForNannyTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();////update adress for nanny
                commentsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update comment
                if (passwordTextBox.Text != checkPasswordTextBox.Text)//if the check password is'nt match to the password
                {
                    checkPasswordTextBox.BorderBrush = Brushes.Red;//brush in red password text box
                    throw new Exception("password is incorrect");
                }
                passwordTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update password
                checkPasswordTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();//update check password
                
                bool[] workdays = new bool[6];//array of work's days

                //get the value from datagrid
                workdays[0] = (bool)hours.SundayCheckBox.IsChecked;
                workdays[1] = (bool)hours.mondayCheckBox.IsChecked;
                workdays[2] = (bool)hours.tuesdayCheckBox.IsChecked;
                workdays[3] = (bool)hours.WednesdayCheckBox.IsChecked;
                workdays[4] = (bool)hours.ThursdayCheckBox.IsChecked;
                workdays[5] = (bool)hours.FridayCheckBox.IsChecked;

                temp_mother.workDays = workdays;//update workdays

                DateTime[,] hourswork = new DateTime[2, 6];//matrix of hour's work
                if (temp_mother.workDays[0])//if the user mark this day that he want a keeping hour's for this days
                {
                    //get the value from datagrid
                    int i = int.Parse(hours.sun.BeginComboBoxHour.Text);
                    int j= int.Parse(hours.sun.BeginComboBoxMinute.Text);
                    hourswork[0, 0] = new DateTime(2000, 1, 1, i , j, 0);
                    i = int.Parse(hours.sun.EndComboBoxHour.Text);
                    j= int.Parse(hours.sun.BeginComboBoxMinute.Text);
                    hourswork[1, 0] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_mother.workDays[1])//if the user mark this day that he want a keeping hour's for this days
                {
                    //get the value from datagrid
                    int i = int.Parse(hours.mon.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.mon.BeginComboBoxMinute.Text);
                    hourswork[0, 1] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.mon.EndComboBoxHour.Text);
                    j = int.Parse(hours.mon.BeginComboBoxMinute.Text);
                    hourswork[1, 1] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_mother.workDays[2])//if the user mark this day that he want a keeping hour's for this days
                {
                    //get the value from datagrid
                    int i = int.Parse(hours.tue.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.tue.BeginComboBoxMinute.Text);
                    hourswork[0, 2] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.tue.EndComboBoxHour.Text);
                    j = int.Parse(hours.tue.BeginComboBoxMinute.Text);
                    hourswork[1, 2] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_mother.workDays[3])//if the user mark this day that he want a keeping hour's for this days
                {
                    //get the value from datagrid
                    int i = int.Parse(hours.wed.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.wed.BeginComboBoxMinute.Text);
                    hourswork[0, 3] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.wed.EndComboBoxHour.Text);
                    j = int.Parse(hours.wed.BeginComboBoxMinute.Text);
                    hourswork[1, 3] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_mother.workDays[4])//if the user mark this day that he want a keeping hour's for this days
                {
                    //get the value from datagrid
                    int i = int.Parse(hours.thu.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.thu.BeginComboBoxMinute.Text);
                    hourswork[0, 4] = new DateTime(2000, 1, 1, i,j, 0);
                    i = int.Parse(hours.thu.EndComboBoxHour.Text);
                    j = int.Parse(hours.thu.BeginComboBoxMinute.Text);
                    hourswork[1, 4] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_mother.workDays[5])//if the user mark this day that he want a keeping hour's for this days
                {
                    //get the value from datagrid
                    int i = int.Parse(hours.fri.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.fri.BeginComboBoxMinute.Text);
                    hourswork[0, 5] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.fri.EndComboBoxHour.Text);
                    j = int.Parse(hours.fri.BeginComboBoxMinute.Text);
                    hourswork[1, 5] = new DateTime(2000, 1, 1, i, j, 0);
                }

                temp_mother.workTimePerDay = hourswork;//update work time per day

                
                bl.AddMother(temp_mother);//add the mother
                MessageBox.Show("Mother added");//massage box will show
                Close();//close the window

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }

        }
    }
}
