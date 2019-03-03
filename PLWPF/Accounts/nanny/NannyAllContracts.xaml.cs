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
    public partial class NannyAllContracts : Window
    {
        BL.IBL bl;
        BE.Nanny temp_nanny;
        /// <summary>
        /// 
        /// this window show all the contracts that the nannt sign on them
        /// </summary>
        public NannyAllContracts()
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
        /// when the user press this button he will show all the contracts of this nanny
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_nanny = bl.FindNanny(j);//find the nanny according the id
                dataGrid.ItemsSource = bl.GetAllContract(s => s.NannyID == temp_nanny.Id);//show all the nanny's contracts
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
