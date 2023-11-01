using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApp.DataAccessLayer
{
    public class DataManager
    {
        public DataManager() { }
        public string getConnectionString()
        {
            string conString = @"server=LAPTOP-J226ROD6\MSSQLSERVER2022;database=MicroTelecom;integrated security=True"; //;MultipleActiveResultSets=True; providerName = System.Data.SqlClient";
            return conString;
        }

    }
}