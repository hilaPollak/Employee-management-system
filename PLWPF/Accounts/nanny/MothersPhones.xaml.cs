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
    /// Interaction logic for MothersPhones.xaml
    /// </summary>
    public partial class MothersPhones : Window
    {
        BL.IBL bl;
        BE.Nanny temp_nanny;

        /// <summary>
        /// this window show al the mother's phones of the nanny
        /// </summary>
        public MothersPhones()
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
        /// when the user press this button the mother's phone will show up
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_nanny = bl.FindNanny(j);//find the nanny according the id
                view.Content = bl.MothersPhones(temp_nanny);//show the string according temp_nanny
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
