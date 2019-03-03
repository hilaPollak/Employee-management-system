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
    /// Interaction logic for AllChildrenOfNanny.xaml
    /// </summary>
    public partial class AllChildrenOfNanny : Window
    {
        BL.IBL bl;
        BE.Nanny temp_nanny;
        
        /// <summary>
        /// this window show all the chilren of the nanny
        /// </summary>
        public AllChildrenOfNanny()
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
        /// when the user press this button all the children of this nanny will show
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_nanny = bl.FindNanny(j);//find the nanny according the id
                dataGrid.ItemsSource = bl.GetAllChildOfNanny(temp_nanny);//show the nnany's children
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
