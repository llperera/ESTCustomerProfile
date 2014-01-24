using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTCustomerProfiles.Models;

namespace ESTCustomerProfiles.ViewModels
{
    class namesVM
    {
        ESTEntities db = new ESTEntities();
        List<Customer> customers = new List<Customer>();
        public namesVM()
        {
            names = getNames(db.Customers.ToList());
        }
        public List<string> names;

        public List<string> getNames(List<Customer> customers)
        {
            List<string> names = new List<string>();
            string name;
            foreach(Customer customer in customers)
            {
                name = customer.customerId + " " + customer.customerName;
                names.Add(name);
            }

            return names;
        }
    }
}
