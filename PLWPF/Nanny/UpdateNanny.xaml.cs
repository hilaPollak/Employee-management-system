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
    /// Interaction logic for UpdateNanny.xaml
    /// </summary>
    public partial class UpdateNanny : Window
    {
        IBL bl;
        Nanny temp_nanny;
        public UpdateNanny()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_nanny = new Nanny();
            idComboBox.ItemsSource = bl.GetAllNanny();
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
                temp_nanny = (Nanny)(idComboBox.SelectedItem);
                DataContext = temp_nanny;
                DataContext = temp_nanny;
                hours.SundayCheckBox.IsChecked = temp_nanny.workDays[0];
                hours.mondayCheckBox.IsChecked = temp_nanny.workDays[1];
                hours.tuesdayCheckBox.IsChecked = temp_nanny.workDays[2];
                hours.WednesdayCheckBox.IsChecked = temp_nanny.workDays[3];
                hours.ThursdayCheckBox.IsChecked = temp_nanny.workDays[4];
                hours.FridayCheckBox.IsChecked = temp_nanny.workDays[5];

                gridDetels.IsEnabled = true;
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
            temp_nanny.DateOfBirth = ((DateTime)dateOfBirthDatePicker.SelectedDate);
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

                if (ThePassword.Password != temp_nanny.Password)//only sameone with the writ password will be abel to cheang the data
                {
                    ThePassword.BorderBrush = Brushes.Red;
                    throw new Exception("the password is incorrect");
                }
                if ((dateOfBirthDatePicker.SelectedDate) > (DateTime.Now))
                {
                    dateOfBirthDatePicker.BorderBrush = Brushes.Red;
                    throw new Exception("INCORRECT DATE");
                }
                try
                {
                    bool[] workdays = new bool[6];//the array

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


                }
                catch (Exception ex)
                {
                    throw new Exception("please enter worksdays in the days you choose");
                }
                bl.UpDateNanny(temp_nanny);
                MessageBox.Show("Nanny update");//massage box will show
               
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
