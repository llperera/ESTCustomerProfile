using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ESTCustomerProfiles
{


    public class LCSEntities : DbContext
    {

        static string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=lkplcsdb)" + "(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=lcs)));User Id=iswalk;Password=iswalk123;";

        public LCSEntities() : base(new OracleConnection(connectionString).ToString())
        {
            this.conn = new OracleConnection(connectionString);
        }

        public OracleConnection conn { get; set; }



        public List<List<string>> ReadData(string sql)
        {
            
            List<List<string>> items = new List<List<string>>();

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open(); // open the oracle connection
            }
             

            using (OracleCommand comm = new OracleCommand(sql, conn)) // create the oracle sql command
            {
                using (OracleDataReader rdr = comm.ExecuteReader()) // execute the oracle sql and start reading it
                {
                        while (rdr.Read()) // loop through each row from oracle
                        {
                            int fieldcount = rdr.FieldCount;
                            int i = 0;
                            List<string> entry = new List<string>();
                            while (i < fieldcount)
                            {
                                entry.Add(rdr[i].ToString());
                                i++;
                            }
                            items.Add(entry);
                        }
                        rdr.Close(); // close the oracle reader  
                }
            }
            
            return items;

        }
    }

}