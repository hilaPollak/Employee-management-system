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
    /// Interaction logic for _5_best_match.xaml
    /// </summary>
    public partial class _5_best_match : Window
    {
        BL.IBL bl;
        BE.Mother temp_mother;
        /// <summary>
        /// this window show the best 5 match nannies to the mother's requests
        /// according the work days matrix
        /// </summary>
        public _5_best_match()
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
        }/// <summary>
        /// when we press on the button the data grid gets the mother according the id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//find the mother according the id user press
                temp_mother = bl.FindMother(j);//find the mother

                dataGrid.ItemsSource = bl.Get5BestMatchNannies(temp_mother);//show the 5 best nannies
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
