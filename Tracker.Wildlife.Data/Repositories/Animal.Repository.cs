using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Wildlife.Data.Models;

namespace Tracker.Wildlife.Data.Repositories
{
    public class AnimalRepository
    {
        string connectionString = "Persist Security Info = False; Data Source ='SalesData.sdf';Password='<password>';File Mode='shared read';Max Database Size=256;Max Buffer Size=1024";
        SqlCeConnection conn = new SqlCeConnection( SqlCeConnection();

        // Set some connection string properties e.g.:
        // 
        conn.ConnectionString = 
            public async List<Animal> 
    }
}
