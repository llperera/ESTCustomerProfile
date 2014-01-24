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
using ESTCustomerProfiles;
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
            namesVM names = new namesVM();
            Subscribe();
            textbox_id.ItemsSource = names.names;
            textbox_id.FilterMode = AutoCompleteFilterMode.Contains;
        }
        
        private void Search(object sender, RoutedEventArgs e)
        {

            string id = textbox_id.Text;
            CustomerVM customer = new CustomerVM(id);
            base.DataContext = customer;
            SearchControl details = new SearchControl(id);
            this.contentControl.Content = details;

            //LCSData lcs = new LCSData();
            //lcs.getData();
        }

        //private void search_keyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        Search(sender, e);
        //    }
        //}

        public void Subscribe()
        {
            textbox_id.KeyDown += search_keyDown;
        }

        public void search_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Search(sender, e);
            }
        }
        
    }
}
