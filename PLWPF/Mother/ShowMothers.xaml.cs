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
    /// Interaction logic for ShowMothers.xaml
    /// </summary>
    public partial class ShowMothers : Window
    {
        IBL bl;
        Mother temp_mother;
        /// <summary>
        /// this window show an Ienumurable of the mothers according the user's request
        /// </summary>
        public ShowMothers()
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            temp_mother = new Mother();
            By_motherID.ItemsSource = bl.GetAllMother();//update the combobox on all mother's id
            By_motherID.DisplayMemberPath = "Id";
            By_motherID.SelectedValue = "Id";
        }

       
        /// <summary>
        /// show all the mothers by id select
        /// </summary>
        private void By_motherID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_mother = (Mother)(By_motherID.SelectedItem);
            dataGrid.ItemsSource = bl.GetAllMother(s => s.Id == temp_mother.Id);//all the mothers with the same id
        }

      
        /// <summary>
        /// show all the mothers
        /// </summary>
        private void show_all_mothers_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = bl.GetAllMother();//show all the mothers
        }
    }
}
