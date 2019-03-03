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
using BL;
using System.Threading;
using BE;
namespace PLWPF
  
{
    /// <summary>
    /// Interaction logic for ShowContracts.xaml
    /// </summary>
    public partial class ShowContracts : Window
    {
       
        List<string> THElist;//help to meet_sign combo box

        IBL bl;
        string choice;
        /// <summary>
        /// this window show contracts according to the user's selected
        /// </summary>
        public ShowContracts()
        {
            try
            {
                bl = FactoryBL.GetBL();
                InitializeComponent();
                //---------------
                THElist = new List<string>();
                THElist.Add("Introductory Meeting");
                THElist.Add("Unintroductory Meeting");
                THElist.Add("Sign Contract");
                THElist.Add("Unsign Contract");
                ////---------------we enter values into  ByChildernsAgeLimit comboBox
                //contractsByDistance.ItemsSource = bl.GetAllContract();
                //contractsByDistance.DisplayMemberPath = "distance";
                //contractsByDistance.SelectedValuePath = "distance";
                
                meet_sign.ItemsSource = THElist;//update the combo box in choose
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }

       

      
 
        /// <summary>
        /// show all the contracts
        /// </summary>
        private void allcontracts_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dataGrid.ItemsSource = bl.GetAllContract();//data grid get all the contract

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }

    
        /// <summary>
        /// show contracts by delegate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void meet_sign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            choice = ((string)(meet_sign.SelectedItem));//get the selected from the user
            switch (choice)
            {
                case "Introductory Meeting"://delegate introductoryMeeting
                    {
                        dataGrid.ItemsSource = bl.GetAllContract(s => s.IntroductoryMeeting);
                        break;
                    }
                case "Sign Contract"://delegate SignContract
                    {
                        dataGrid.ItemsSource = bl.GetAllContract(s => s.SignContract);
                        break;
                    }
                case "Unintroductory Meeting"://delegate !introductoryMeeting
                    {
                        dataGrid.ItemsSource = bl.GetAllContract(s => !s.IntroductoryMeeting);
                        break;
                    }
                case "Unsign Contract"://delegate !SignContract
                    {
                        dataGrid.ItemsSource = bl.GetAllContract(s => !s.SignContract);
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
        }
        /// <summary>
        /// show all the valid contracts th this day
        /// </summary>
        private void Valid_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = bl.GetAllContract(s => bl.DaysToEndOfContract(s) != 0);//bl.DaysToEndOfContract !=0: still working
        }

        /// <summary>
        /// show all the contract by grouping of distance
        /// </summary>

        //private void contractsByDistance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        int count = 0;
        //        int a = ((Contract)contractsByDistance.SelectedItem).distance;
        //        foreach (var item in bl.GroupingContractByDistance(true))
        //        {
        //            if (item.Key == ((int)a / 10) * 10)
        //            {
        //                dataGrid.ItemsSource = item;
        //                count++;
        //            }
        //        }

        //        if (count == 0)
        //            dataGrid.ItemsSource = null;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        /// <summary>
        /// display gouping of contract according to distance
        /// </summary>
        /// <param name="grouping"></param>
        public void Act(List<IGrouping<int, BE.Contract>> grouping)
        {
            try
            {
                PLWPF.Grouping uc = new PLWPF.Grouping();// defind user control
                uc.Lable.Content = "Grouping By Distance";
                this.page.Content = uc;
                uc.Source = grouping;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Bydistance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                //new thread to calculate distance
                Thread t1 = new Thread(() =>
                {
                    try
                    {
                        var v = bl.GroupingOfDistance(true);// get grouping of contract accoding to distance
                        Action<List<IGrouping<int, BE.Contract>>> a = Act;
                        Dispatcher.BeginInvoke(a, v.ToList());//activation the thread on UI
                    }
                catch (Exception ex)
                    {
                        throw new Exception("calculate distance file, one of the adress is un correct");
                    }
                });
                t1.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
   
}
