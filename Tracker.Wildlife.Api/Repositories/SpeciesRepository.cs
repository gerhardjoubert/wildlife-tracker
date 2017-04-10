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
    public class SpeciesRepository
    {
        public async Task<List<Species>> SelectAll()
        {
            List<Species> species = new List<Species>();
            SqlCeConnection con = new SqlCeConnection(WebConfigurationManager.ConnectionStrings["WildlifeTrackerConnectionString"].ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Species", con);
            await con.OpenAsync();
            SqlCeDataReader rdr = await cmd.ExecuteReaderAsync() as SqlCeDataReader;
            while (await rdr.ReadAsync())
            {
                Species specie = new Species();
                specie.Id = rdr.GetInt32(0);
                specie.CategoryId = rdr.GetInt32(1);
                specie.Name = rdr.GetString(2);
                species.Add(specie);
            }

            return species;
        }
    }
}