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
    /// Interaction logic for ShowChildren.xaml
    /// </summary>
    public partial class ShowChildren : Window
    {
        List<string> THElist;
        IBL bl;
        Mother temp_mother;
        string choice;
        public ShowChildren()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            //--------------- we enter valus into the the comboBox BySpacialNeeds
            THElist = new List<string>();
            THElist.Add("has spacial needs");
            THElist.Add("without spacial needs");

            BySpacialNeeds.ItemsSource = THElist;
            //--------------- we enter valus into the the comboBox brothersbymother
            temp_mother = new Mother();
            brothersbymother.ItemsSource = bl.GetAllMother();
            brothersbymother.DisplayMemberPath = "Id";
            brothersbymother.SelectedValue = "Id";

        }

        /// <summary>
        /// to show all children without Nanny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void withoutNanny_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = bl.GetAllChildWithoutNanny();
        }

        /// <summary>
        /// show all children without and with Spacial Needs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BySpacialNeeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                choice = ((string)(BySpacialNeeds.SelectedItem));
                switch (choice)
                {
                    case "has spacial needs":
                        {
                            dataGrid.ItemsSource = bl.GetAllChild(s => s.HasSpecialNeeds);
                            break;
                        }
                    case "without spacial needs":
                        {
                            dataGrid.ItemsSource = bl.GetAllChild(s => !s.HasSpecialNeeds);
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
        /// show all brothers (chldren with the same mother)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brothersbymother_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_mother = (Mother)(brothersbymother.SelectedItem);
            dataGrid.ItemsSource = bl.GetAllChild(s => s.IdMother== temp_mother.Id);
        }

        /// <summary>
        /// show all children
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allchildren_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = bl.GetAllChild();
        }
    }
}
