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
    /// Interaction logic for NannyWindow.xaml
    /// </summary>
    public partial class NannyWindow : Window
    {
        public NannyWindow()
        {
            InitializeComponent();
        }
    	/// <summary>
    	/// to open the addNanny window 
    	/// </summary>
        private void addNanny_Click(object sender, RoutedEventArgs e)
        {
            Window AddNanny = new addNanny(); //WindowStartupLocation= new addNanny();
            AddNanny.Show();
        }
    	/// <summary>
    	/// to open the updateNanny window 
    	/// </summary>
        private void upDateNanny_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateNanny = new UpdateNanny();
            UpdateNanny.Show();
        }
    	/// <summary>
    	/// to open the deleteNanny window 
    	/// </summary>
        private void deleteNanny_Click(object sender, RoutedEventArgs e)
        {
            Window deleteNanny = new DeleteNanny();
            deleteNanny.Show();
        }
    	/// <summary>
    	/// to open the showNanny window 
    	/// </summary>
        private void viewNanny_Click(object sender, RoutedEventArgs e)
        {
            Window viewNanny = new ShowNannies();
            viewNanny.Show();
        }
    }
}
