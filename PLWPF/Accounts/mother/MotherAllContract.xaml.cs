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
    /// Interaction logic for MotherAllContract.xaml
    /// </summary>
    public partial class MotherAllContract : Window
    {
        BL.IBL bl;
        BE.Mother temp_mother;
        /// <summary>
        /// show all mother's contract
        /// </summary>
        public MotherAllContract()
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
        /// when we press the button the data grid update according th id textbox
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);// get the id from the user
                temp_mother = bl.FindMother(j);// find the mother according the id
                List<Child> temp = bl.GetAllChild(s => s.IdMother == temp_mother.Id).ToList();//all the children of the mother

                for (int i = 0; i < temp.Count; i++)//get over all the child's list
                {
                    dataGrid.ItemsSource = bl.GetAllContract(s => s.ChildID == temp[i].Id);//all the contract that mother's child sign on them
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
