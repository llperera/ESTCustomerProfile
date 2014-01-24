using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTCustomerProfiles.Models;

namespace ESTCustomerProfiles.ViewModels
{
    class SupportVM
    {
        public SupportVM(Customer customer)
        {
            _support = customer.Supports.ToList();
        }
        List<Support> _support = new List<Support>();


    }
}