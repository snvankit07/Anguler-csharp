using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace sweetnes18.AhelperClass
{
    public class message
    {
        public String msg; 
    }
    public class DatabaseConnection
    { 
       
            private string ConnectionString;
        

        public DatabaseConnection()
            {
                // get the connection string
                this.ConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            }
            public DataSet Select(string query)
            {
                SqlConnection dbcon;
                using (dbcon = new SqlConnection(this.ConnectionString))
                {
                    // open the connection
                    dbcon.Open(); 
                    // create a new adapter between the connection and query
                    SqlDataAdapter adapter = new SqlDataAdapter(query, dbcon);
                    // create a new dataset to store the query results
                    DataSet ds = new DataSet();
                    // fill the dataset with the results from the adapter,
                    adapter.Fill(ds, "result");
                    // return the dataset
                    return ds;
                }
            }
        /*----------------------Select Table Query------------------------*/
            public DataSet SelectTable(string Tablename,string whr=null)
            {
                string w = ""; 
                if (whr != null) {
                    w = " where " + whr;
                }

                string qur = "select * from " + Tablename+w;
            
                return this.Select(qur);
            }
        /*----------------------Select Table Query------------------------*/
        public bool Execute(string query)
            {
                SqlConnection dbcon;
                using (dbcon = new SqlConnection(this.ConnectionString))
                {
                    // create a new SQL command on thie connection
                    SqlCommand command = new SqlCommand(query, dbcon);
                    // open the connection
                    dbcon.Open();
                    // execute the query and return the number of affected rows
                    int affectedrows = command.ExecuteNonQuery();
                    // there were no rows affected - the command failed
                    if (affectedrows == 0)
                    {
                        return false;
                        // the command affected at least one row
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
}
    
