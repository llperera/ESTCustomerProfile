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
        ESTDataSet dataSet = new ESTDataSet();
        CustomerVM _viewModel = new CustomerVM();
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
            
        }
        
        private void Search(object sender, RoutedEventArgs e)
        {
            //Models.Customer customer = new Models.Customer();
            //Label_Name.Visibility = Visibility.Visible;
            //Label_Name.Content = "customer";
            //listbox_names.ItemsSource = new List<Models.Customer>();
            LCSData lcs = new LCSData();
            lcs.getData(301814, 1592998);
        }
    }
}
