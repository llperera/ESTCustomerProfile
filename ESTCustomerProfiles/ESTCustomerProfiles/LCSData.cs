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
        public void getData()
        {
            string query1, query2;
            List<List<string>> cusInfo, supInfo;
            Customer customer = new Customer();
            decimal offset;
            int id;
            CustomerTableAdapter cta = new CustomerTableAdapter();
            SupportTableAdapter sta = new SupportTableAdapter();

            //customerName, spptOrganization, offset
            query1 = "select rndprod.customer_info.customer_id, rndprod.customer_info.name, rndprod.case_support_site.organization_id, rndprod.case_time_zone.offset from rndprod.customer_info join rndprod.case_support_site on rndprod.customer_info.supp_organization_id = rndprod.case_support_site.organization_id join rndprod.case_time_zone on rndprod.case_time_zone.time_zone = rndprod.case_support_site.time_zone";
            cusInfo = db_lcs.ReadData(query1);
            foreach (var i in cusInfo)
            {
                bool x = int.TryParse(i[0], out id );
                if (x)
                {
                    customer.customerId = id;
                    customer.customerName = i[1].ToString();
                    float f = float.Parse(i[3]);
                    customer.offset = (decimal)f;
                    //bool y = decimal.TryParse(i[2], out offset);
                    //if (y)
                    //{
                    //    customer.offset = offset;
                    //}
                    customer.spptOrganization = i[2].ToString();

                    cta.Insert(
                        customer.customerId,
                        customer.customerName,
                        customer.documentPath,
                        customer.spptOrganization,
                        customer.offset
                    );

                    query2 = "select support_key, support_key_description, queue from RNDPROD.installation_support where customer_id ='" + customer.customerId + "'";
                    supInfo = db_lcs.ReadData(query2);
                    Support support = new Support();
                    foreach (var j in supInfo)
                    {
                        support.customerId = customer.customerId;
                        support.supportKey = int.Parse(j[0]);
                        support.description = j[1].ToString();
                        support.queue = j[2].ToString();

                        //if (customer.queue == null)
                        //{
                        //    customer.queue = i[2].ToString();
                        //}
                        customer.Supports.Add(support);
                            sta.Insert(
                            customer.customerId,
                            support.supportKey,
                            support.description,
                            support.queue
                        );
                    }
                
                }
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
            

            

            
            

            
                
       }
        
    }

}
