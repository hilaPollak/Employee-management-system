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
    /// Interaction logic for WantedNannies.xaml
    /// </summary>
    public partial class WantedNannies : Window
    {
        BL.IBL bl;
        BE.Mother temp_mother;

        /// <summary>
        /// get all the wanted nannies according the hours of work
        /// </summary>
        public WantedNannies()
        {
            try
            {
                bl = BL.FactoryBL.GetBL();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// when the user press the button all the wanted nannies will show
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_mother = bl.FindMother(j);// find the mother according the id

                dataGrid.ItemsSource = bl.GetAllWantedNannies(temp_mother);//update the data grid according the temp_mother

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
