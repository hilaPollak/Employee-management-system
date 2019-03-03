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
    /// Interaction logic for UpdateMother.xaml
    /// </summary>
    public partial class UpdateMother : Window
    {
        IBL bl;
        Mother temp_mother;
        /// <summary>
        /// this window update a mother according the id
        /// </summary>
        public UpdateMother()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_mother = new Mother();
            idComboBox.ItemsSource = bl.GetAllMother();// update the combo box on all motherws id
            idComboBox.DisplayMemberPath = "Id";
            idComboBox.SelectedValuePath = "Id";

        }

        /// <summary>
        /// show all the mother's ditales according the id that the user choosed
        /// </summary>
        private void idComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                temp_mother = (Mother)(idComboBox.SelectedItem);//find the mother according the id
                DataContext = temp_mother;//update the datagrid according to temp_mother

                //update all the check box according the workdays array of the mother
                hours.SundayCheckBox.IsChecked= temp_mother.workDays[0];
                hours.mondayCheckBox.IsChecked = temp_mother.workDays[1];
                hours.tuesdayCheckBox.IsChecked = temp_mother.workDays[2];
                hours.WednesdayCheckBox.IsChecked = temp_mother.workDays[3];
                hours.ThursdayCheckBox.IsChecked = temp_mother.workDays[4];
                hours.FridayCheckBox.IsChecked = temp_mother.workDays[5];

               
                gridDeteles.IsEnabled = true;//change the edit of all the datagrid to enable
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }




        /// <summary>
        /// when the user press this button the detailes wiil be update
        /// </summary>
        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (ThePassword.Password != temp_mother.Password)// if the password is uncorrect
                {
                    ThePassword.BorderBrush = Brushes.Red;// brush the password text box in red
                    throw new Exception("the password is incorrect");
                }
                try
                {
                    bool[] workdays = new bool[6];//array of work's days

                    // update the value from datagrid
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
                        int j = int.Parse(hours.sun.BeginComboBoxMinute.Text);
                        hourswork[0, 0] = new DateTime(2000, 1, 1, i, j, 0);
                        i = int.Parse(hours.sun.EndComboBoxHour.Text);
                        j = int.Parse(hours.sun.BeginComboBoxMinute.Text);
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
                        hourswork[0, 4] = new DateTime(2000, 1, 1, i, j, 0);
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
                }
                catch (Exception ex)
                {
                    throw new Exception("please enter worksdays in the days you choose");
                }

                bl.UpDateMother(temp_mother);//update the mother
                MessageBox.Show("Mother update");//massage box will show
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
