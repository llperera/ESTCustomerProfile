using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTCustomerProfiles.Properties;
using ESTCustomerProfiles.Models;

namespace ESTCustomerProfiles.ViewModels
{
    class CustomerVM
    {
        public CustomerVM(string id)
        {
            _customer = Search(id);
            _sev = _customer.Supported_Severities.ToList();
            _support = _customer.Supports.ToList();
            foreach (Supported_Severity i in _sev)
            {
                severities.Add(i.severity.ToString());
            }
        }
        
        Customer _customer = new Customer();
        List<Supported_Severity> _sev = new List<Supported_Severity>();
        List<string> severities = new List<string>();
        List<Support> _support = new List<Support>();
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value;}
        }

        public string Name
        {
            get { return Customer.customerName; }
            set { Customer.customerName = value; }
        }

        public string Info
        {
            get { return Customer.customerName + " (" + Customer.customerId + ")"; }
        }

        public decimal? Offset
        {
            get { return Customer.offset; }
            set { Customer.offset = value; }
        }

        public string SuppOrg
        {
            get { return Customer.spptOrganization; }
            set { Customer.spptOrganization = value; }
        }
        
        public List<string> Severities
        {
            get { return severities; }
            set { severities = value; }
        }

        public List<Support> Support
        {
            get { return _support; }
            set { _support = value; }
        }

        public Customer Search(string searchString)
        {
            ESTEntities db = new ESTEntities();
            Customer customer = new Customer();
            if (!String.IsNullOrEmpty(searchString))
            {
                int id = 0;
                bool num = int.TryParse(searchString, out id);

                if (num)
                {
                    customer = db.Customers.FirstOrDefault(m => m.customerId == id);
                }
                else
                {
                    customer = db.Customers.FirstOrDefault(m => m.customerName.Contains(searchString));
                }

                //customer = db.Customers.Find(id);                
            }

            return customer;
        }

        
    }
}
