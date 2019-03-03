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
using BL;
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction CloseNannies.xaml
    /// </summary>
    public partial class CloseNannies : Window
        //closer nanny down then 60 km
    {
        BL.IBL bl;
        BE.Mother temp_mother;
        /// <summary>
        /// the window show all the close nannies of the mother
        /// </summary>
        public CloseNannies()
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
        /// when the user press the butoon the datagrid show the closes nannies
        /// </summary>
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int j = int.Parse(id.Text);//get the id from the user
                temp_mother = bl.FindMother(j);//find the mother according the id
                Thread t = new Thread(
                       () =>
                       {


                           var v = bl.CloseNannies(temp_mother).ToList();

                           Action a = () =>
                           {
                               dataGrid.ItemsSource = v;
                               // this.listView.ItemsSource = v;

                           };
                           Dispatcher.BeginInvoke(a);//activation the thread on UI
                       });
                t.Start();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}