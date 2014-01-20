using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTCustomerProfiles.Models;

namespace ESTCustomerProfiles.ViewModels
{
    class CustomerVM
    {
        public CustomerVM(){
            _customer = new Customer();
        }

        Customer _customer;

        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

        public string Name
        {
            get { return Customer.customerName; }
            set { Customer.customerName = value; }
        }

        public decimal? Offset
        {
            get { return Customer.offset; }
            set { Customer.offset = value; }

        }

        
    }
}
