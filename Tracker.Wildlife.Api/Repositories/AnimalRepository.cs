using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Tracker.Wildlife.Api.Models;

namespace Tracker.Wildlife.Api.Repositories
{
    public class AnimalRepository
    {
        //string connectionString = "Persist Security Info = False; Data Source ='App_Data\\WildlifeTracker.sdf';File Mode='shared read';Max Database Size=256;Max Buffer Size=1024";

        public async Task<List<Animal>> SelectAll()
        {
            List<Animal> animals = new List<Animal>();
            SqlCeConnection conn = new SqlCeConnection(WebConfigurationManager.ConnectionStrings["WildlifeTrackerConnectionString"].ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Animal", conn);
            SqlCeDataReader rdr = await cmd.ExecuteReaderAsync() as SqlCeDataReader;
            while (await rdr.ReadAsync())
                {
                Animal animal = new Animal();
                animal.Id = rdr.GetInt32(0);
                animal.SpeciesId = rdr.GetInt32(1);
                animals.Add(animal);
            }
            return 
        }
    }
}