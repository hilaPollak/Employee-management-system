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
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// to open the window to add child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addChild_Click(object sender, RoutedEventArgs e)
        {
            Window addChild = new AddChild();
            addChild.Show();
        }
        /// <summary>
        /// to open the window to update child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDateChild_Click(object sender, RoutedEventArgs e)
        {
            Window upDateChild = new UpdateChild();
            upDateChild.Show();
        }
        /// <summary>
        /// to open the window to delete child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteChild_Click(object sender, RoutedEventArgs e)
        {
            Window deleteChild = new DeleteChild();
            deleteChild.Show();
        }
        /// <summary>
        /// to open the window to show all children
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewChild_Click(object sender, RoutedEventArgs e)
        {
            Window viewChild = new ShowChildren();
            viewChild.Show();
        }
    }
}
