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
    /// Interaction logic for BirthdaysOfChildren.xaml
    /// </summary>
    public partial class BirthdaysOfChildren : Window
    {
        BL.IBL bl;
        BE.Nanny temp_nanny;
        /// <summary>
        /// this window show al the children of the nanny who have a birthday this month
        /// </summary>
        public BirthdaysOfChildren()
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
        /// when the user press this button al the childre that have a birthday will show
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_nanny = bl.FindNanny(j);//find the nanny according the id
                dataGrid.ItemsSource = bl.GetAllMonthBirthdayChild(temp_nanny);// update the datagrid according the temp_nanny
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
