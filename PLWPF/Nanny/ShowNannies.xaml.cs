using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ShowNannies.xaml
    /// </summary>
    public partial class ShowNannies : Window
    {
        
        List<string> THElist;
        List<string> THElist2;
        
        IBL bl;
        string choice;
        public ShowNannies()
        {
            try
            {
                bl = FactoryBL.GetBL();
                InitializeComponent();
                //--------------- we enter values into bySalary comboBox
                THElist = new List<string>();
                THElist.Add("with TMT");
                THElist.Add("salary by hour");
                THElist.Add("salary by month");

                BySalary.ItemsSource = THElist;
                //--------------- we enter values into ByPaymentHigh comboBox
                THElist2 = new List<string>();
                THElist2.Add("low payment");
                THElist2.Add("regular payment");
                THElist2.Add("high payment");

                ByPaymentHigh.ItemsSource = THElist2;
                //---------------we enter values into  ByChildernsAgeLimit comboBox
                //ByChildernsAgeLimit.ItemsSource = bl.GetAllNanny();
                //ByChildernsAgeLimit.DisplayMemberPath = "MaxMonthesAge";
                //ByChildernsAgeLimit.SelectedValuePath = "MaxMonthesAge";


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }
    	///// <summary>
    	///// show all nannies by their age limit for the childern 
    	///// </summary>
     //   private void ByChildernsAgeLimit_SelectionChanged(object sender, SelectionChangedEventArgs e)
     //   {
     //       int count = 0;
     //       a = ((Nanny)ByChildernsAgeLimit.SelectedItem).MaxMonthesAge;
     //       foreach (var item in bl.GroupingNannyByAge(true,true))
     //       {
     //           if (item.Key == ((int)a/3)*3 )
     //           {
     //               dataGrid.ItemsSource = item;
     //               count++;
     //           }
     //       }

     //       if (count == 0)
     //           dataGrid.ItemsSource = null;

     //   }

    	/// <summary>
    	/// show all nannies by their selery prepherns 
    	/// </summary>
        private void ByTMT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                choice = ((string)(BySalary.SelectedItem));
                switch (choice)
                {
                    case "with TMT":
                        {
                            dataGrid.ItemsSource = bl.GetAllTMTNannies();
                            break;
                        }
                    case "salary by hour":
                        {
                            dataGrid.ItemsSource = bl.GetAllNanny(s=> s.SalaryByHour);
                            break;
                        }
                    case "salary by month":
                        {
                            dataGrid.ItemsSource = bl.GetAllNanny(s => !s.SalaryByHour);
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }
    	/// <summary>
    	/// show all nannies by their payment
    	/// </summary>
        private void ByPayment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                choice = ((string)(ByPaymentHigh.SelectedItem));
                switch (choice)
                {
                    case "low payment":
                        {
                            dataGrid.ItemsSource = bl.GetAllNanny(s=> s.SalaryForHour<=50);
                            break;
                        }
                    case "regular payment":
                        {
                            dataGrid.ItemsSource = bl.GetAllNanny(s => (s.SalaryForHour > 50 && s.SalaryForHour <=100));
                            break;
                        }
                    case "high payment":
                        {
                            dataGrid.ItemsSource = bl.GetAllNanny(s => s.SalaryForHour >100);
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }
    	/// <summary>
    	/// show all nannies
    	/// </summary>
        private void allnannies_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dataGrid.ItemsSource = bl.GetAllNanny();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '\n' + "check your input and try again");
            }
        }

        private void ByChildernsAgeLimit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                Grouping uc = new Grouping();//defind user control
                uc.Lable.Content = "Groups By Age";
                uc.Source = bl.GroupingNannyByAge(true, true);//return the grouping of nanny according to the age she receives
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
