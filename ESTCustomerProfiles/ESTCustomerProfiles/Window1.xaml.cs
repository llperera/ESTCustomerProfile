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

namespace ESTCustomerProfiles
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        SupportKeyVM svm;

        public Window1()
        {
            svm = new SupportKeyVM ();
            DataContext = svm.supportkeys;


            SupportKey sk1 = new SupportKey("1212", "desc1");
            SupportKey sk2 = new SupportKey("4344", "desc12");
            svm.supportkeys.Add(sk2);
            svm.supportkeys.Add(sk1);



            InitializeComponent();
            

            
            
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var skey = button.DataContext as SupportKey;

                svm.supportkeys.Remove(skey);
            }
            else
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SupportKey sk2 = new SupportKey("4344", "desc12");
            svm.supportkeys.Add(sk2);

            MessageBox.Show("aa" + svm.supportkeys.Count);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SupportKey sk = new SupportKey(textbox_key.Text, textbox_description.Text);

            if (textbox_key.Text != "" && textbox_description.Text != "") {
                svm.supportkeys.Add(sk);
                textbox_key.Text = "";
                textbox_description.Text = "";

            }

            
        }
    }
}
