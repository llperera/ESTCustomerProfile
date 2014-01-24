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
using ESTCustomerProfiles.Models;

namespace ESTCustomerProfiles
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchControl(string id)
        {
            CustomerVM customer = new CustomerVM(id);
            base.DataContext = customer;
            InitializeComponent();
            FlowDocument doc = new FlowDocument();


            doc = Severities(customer.Severities);
            this.richTextBox_sevSupp.Document = doc;
            doc = Support(customer.SuppOrg, customer.Support);
            this.richTextBox_support.Document = doc;

        }

        public FlowDocument Severities(List<string> severities)
        {
            FlowDocument doc = new FlowDocument();
            List list = new List();
            if (severities.Count == 0)
            {
                list.ListItems.Add(new ListItem(new Paragraph(new Run("Severities are not assigned"))));
            }
            else
            {
                foreach (string i in severities)
                {
                    Paragraph para = new Paragraph(new Run(i));
                    list.ListItems.Add(new ListItem(para));
                }
            }

            doc.Blocks.Add(list);
            return doc;
        }

        public FlowDocument Support(string suppOrg, List<Support> support)
        {
            FlowDocument doc = new FlowDocument();
            Paragraph para = new Paragraph(new Run("Support Organization: " + suppOrg));
            doc.Blocks.Add(para);
            Table table = new Table();
            doc.Blocks.Add(table);
            int noCol = 3;
            for (int x = 0; x < noCol; x++)
            {
                table.Columns.Add(new TableColumn());
            }
            table.RowGroups.Add(new TableRowGroup());
            table.RowGroups[0].Rows.Add(new TableRow());
            TableRow header = table.RowGroups[0].Rows[0];
            header.FontWeight = FontWeights.Bold;
            header.Cells.Add(new TableCell(new Paragraph(new Run("Support Key"))));
            header.Cells.Add(new TableCell(new Paragraph(new Run("Activity Description"))));
            header.Cells.Add(new TableCell(new Paragraph(new Run("Queue"))));

            //foreach (Support i in support)
            //{
            //    table.RowGroups[0].Rows.Add(new TableRow()); 
            //    TableRow row = table.RowGroups[0].Rows[1];
            //    row.FontWeight = FontWeights.Bold;
            //    row.Cells.Add(new TableCell(new Paragraph(new Run(i.supportKey.ToString()))));
            //    row.Cells.Add(new TableCell(new Paragraph(new Run(i.description.ToString()))));
            //    row.Cells.Add(new TableCell(new Paragraph(new Run(i.queue.ToString()))));
            //}

            return doc;
        }
    }
}
