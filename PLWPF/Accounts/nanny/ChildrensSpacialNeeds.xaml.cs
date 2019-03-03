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
    /// Interaction logic for ChildrensSpacialNeeds.xaml
    /// </summary>
    public partial class ChildrensSpacialNeeds : Window
    {
        BL.IBL bl;
        BE.Nanny temp_nanny;
        /// <summary>
        /// show all children's spacial need of the nanny
        /// </summary>
        public ChildrensSpacialNeeds()
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
        /// when the user press this button the string of the spacial needs will show
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_nanny = bl.FindNanny(j);//find the nanny according the id
                view.Content = bl.ChildSpecialNeeds(temp_nanny);// show the string according temp_nanny
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
