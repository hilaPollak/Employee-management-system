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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    public partial class MotherWindow : Window
    {
        public MotherWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// when the user press on this button AddMother window will open
        /// </summary>
        private void addMother_Click(object sender, RoutedEventArgs e)
        {
            Window addMother = new AddMother();
            addMother.Show();//show the window
        }
        /// <summary>
        /// when the user press on this button UpdateMother window will open
        /// </summary>
        private void upDateMother_Click(object sender, RoutedEventArgs e)
        {
            Window upDateMother = new UpdateMother();
            upDateMother.Show();//show the window
        }
        /// <summary>
        /// when the user press on this button DeleteMother window will open
        /// </summary>
        private void deleteMother_Click(object sender, RoutedEventArgs e)
        {
            Window deleteMother = new DeleteMother();
            deleteMother.Show();//show the window
        }
        /// <summary>
        /// when the user press on this button ShowMothers window will open
        /// </summary>
        private void viewMother_Click(object sender, RoutedEventArgs e)
        {
            Window viewMother = new ShowMothers();
            viewMother.Show();//show the window
        }
    }
}
