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
    /// Interaction logic for AddNanny.xaml
    /// </summary>
    public partial class addNanny : Window
    {
        BE.Nanny temp_nanny;
        IBL bl;

        public addNanny()
        {
            bl = BL.FactoryBL.GetBL();
            InitializeComponent();
            temp_nanny = new BE.Nanny();
            dateOfBirthDatePicker.DataContext = new DateTime(2000, 1, 1);
            this.NannyDetailsGrid.DataContext = temp_nanny;
           
        }
    /// <summary>
    /// to add new nanny to the list in bl
    /// </summary>
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idTextBox.Text.Length > 9)// if the id to long throw exception
                {
                    idTextBox.BorderBrush = Brushes.Red;
                    throw new Exception("id to long");
                }
                idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                nameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                lastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (phoneTextBox.Text.Length > 10 || phoneTextBox.Text.Length < 5)// if the phone number to short or to long throw exception
                {
                    phoneTextBox.BorderBrush = Brushes.Red;
                    throw new Exception("phone number is incorrect");
                }
                phoneTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                addressTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                seniorityTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                numOfChildrenTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                maxChildrensTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                minMonthesAgeComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
                maxMonthesAgeComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
                salaryForHourTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                salaryForMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                recommendationsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                if(passwordTextBox.Text!=checkPasswordTextBox.Text)// if the passwords is not the same throw exception
                {
                    checkPasswordTextBox.BorderBrush = Brushes.Red;
                    throw new Exception("password is incorrect");
                }
                passwordTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                checkPasswordTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                bool[] workdays = new bool[6]; // the array

                workdays[0] = (bool)hours.SundayCheckBox.IsChecked;
                workdays[1] = (bool)hours.mondayCheckBox.IsChecked;
                workdays[2] = (bool)hours.tuesdayCheckBox.IsChecked;
                workdays[3] = (bool)hours.WednesdayCheckBox.IsChecked;
                workdays[4] = (bool)hours.ThursdayCheckBox.IsChecked;
                workdays[5] = (bool)hours.FridayCheckBox.IsChecked;

                temp_nanny.workDays = workdays;

                DateTime[,] hourswork = new DateTime[2, 6];//the matrix
                if (temp_nanny.workDays[0])
                {
                    int i = int.Parse(hours.sun.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.sun.BeginComboBoxMinute.Text);
                    hourswork[0, 0] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.sun.EndComboBoxHour.Text);
                    j = int.Parse(hours.sun.BeginComboBoxMinute.Text);
                    hourswork[1, 0] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_nanny.workDays[1])
                {
                    int i = int.Parse(hours.mon.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.mon.BeginComboBoxMinute.Text);
                    hourswork[0, 1] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.mon.EndComboBoxHour.Text);
                    j = int.Parse(hours.mon.BeginComboBoxMinute.Text);
                    hourswork[1, 1] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_nanny.workDays[2])
                {
                    int i = int.Parse(hours.tue.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.tue.BeginComboBoxMinute.Text);
                    hourswork[0, 2] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.tue.EndComboBoxHour.Text);
                    j = int.Parse(hours.tue.BeginComboBoxMinute.Text);
                    hourswork[1, 2] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_nanny.workDays[3])
                {
                    int i = int.Parse(hours.wed.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.wed.BeginComboBoxMinute.Text);
                    hourswork[0, 3] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.wed.EndComboBoxHour.Text);
                    j = int.Parse(hours.wed.BeginComboBoxMinute.Text);
                    hourswork[1, 3] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_nanny.workDays[4])
                {
                    int i = int.Parse(hours.thu.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.thu.BeginComboBoxMinute.Text);
                    hourswork[0, 4] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.thu.EndComboBoxHour.Text);
                    j = int.Parse(hours.thu.BeginComboBoxMinute.Text);
                    hourswork[1, 4] = new DateTime(2000, 1, 1, i, j, 0);
                }
                if (temp_nanny.workDays[5])
                {
                    int i = int.Parse(hours.fri.BeginComboBoxHour.Text);
                    int j = int.Parse(hours.fri.BeginComboBoxMinute.Text);
                    hourswork[0, 5] = new DateTime(2000, 1, 1, i, j, 0);
                    i = int.Parse(hours.fri.EndComboBoxHour.Text);
                    j = int.Parse(hours.fri.BeginComboBoxMinute.Text);
                    hourswork[1, 5] = new DateTime(2000, 1, 1, i, j, 0);
                }

                temp_nanny.workHours = hourswork;
                temp_nanny.DateOfBirth = (DateTime)dateOfBirthDatePicker.SelectedDate;

                bl.AddNanny(temp_nanny);
                MessageBox.Show("Nanny added");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }


    }

}
