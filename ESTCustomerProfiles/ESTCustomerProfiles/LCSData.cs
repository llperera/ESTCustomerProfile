using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESTCustomerProfiles.Models;
using ESTCustomerProfiles.ESTDataSetTableAdapters;

namespace ESTCustomerProfiles
{
    class LCSData
    {
        private LCSEntities db_lcs = new LCSEntities();
        public void getData(int customerId, int supportKey)
        {
            string query;
            List<List<string>> lcsInfo;
            Customer customer = new Customer();
            //customerName, spptOrganization, offset
            query = "select rndprod.customer_info.name, rndprod.case_support_site.organization_id, rndprod.case_time_zone.offset from rndprod.customer_info join rndprod.case_support_site on rndprod.customer_info.supp_organization_id = rndprod.case_support_site.organization_id join rndprod.case_time_zone on rndprod.case_time_zone.time_zone = rndprod.case_support_site.time_zone where rndprod.customer_info.customer_id ='" + customerId + "'";
            lcsInfo = db_lcs.ReadData(query);
            foreach (var i in lcsInfo)
            {
                customer.customerId = customerId;
                customer.customerName = i[0].ToString();
                customer.offset = decimal.Parse(i[1]);
                customer.spptOrganization = i[2].ToString();
            } 

            /*
            //Contacts : name, jobTitle, workPhone, mobilePhone, email, jobDescription, 
            query = "select person_name, job_title_name, work_phone, work_mobile_phone, work_email, job_title_description, contact_id, customer_type from RNDPROD.customer_contact_persons where customer_id ='" + customerId + "'";
            lcsInfo = db_lcs.ReadData(query);
            foreach (var i in lcsInfo)
            {
                
            }
            */
            
            // Support : description, Customer : queue
            query = "select support_key_description, queue from RNDPROD.installation_support where customer_id ='" + customerId + "' and support_key ='" + supportKey + "'";
            lcsInfo = db_lcs.ReadData(query);
            foreach (var i in lcsInfo)
            {
                Support support = new Support();
                support.customerId = customerId;
                support.supportKey = supportKey;
                support.description = i[0].ToString();
                if (customer.queue == null)
                {
                    customer.queue = i[1].ToString();
                }
                customer.Supports.Add(support);  

                SupportTableAdapter sta = new SupportTableAdapter();

                sta.Insert(
                    customer.customerId,
                    support.supportKey,
                    support.description
                );
            }

            CustomerTableAdapter cta = new CustomerTableAdapter();

            cta.Insert(
                customer.customerId,
                customer.customerName,
                customer.documentPath,
                customer.spptOrganization,
                customer.queue,
                customer.offset
            );

            
                
       }
        
    }

}
