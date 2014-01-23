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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ESTCustomerProfiles.ViewModels;

namespace ESTCustomerProfiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Search(object sender, RoutedEventArgs e)
        {

            string id = textbox_id.Text;
            CustomerVM customer = new CustomerVM(id);
            base.DataContext = customer;
            SearchControl details = new SearchControl(id);
            this.contentControl.Content = details;
            //Models.Customer customer = new Models.Customer();
            //Label_Name.Visibility = Visibility.Visible;
            //Label_Name.Content = "customer";
            //listbox_names.ItemsSource = new List<Models.Customer>();
            //LCSData lcs = new LCSData();
            //lcs.getData();
        }

        private void search_Keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Search(sender, e);
            }
        }
        
    }
}
