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
    public class LocationRepository
    {
        public async Task<List<Location>> SelectAll()
        {
            List<Location> locations = new List<Location>();
            SqlCeConnection con = new SqlCeConnection(WebConfigurationManager.ConnectionStrings["WildlifeTrackerConnectionString"].ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand(@"SELECT * FROM Location", con);
            await con.OpenAsync();
            SqlCeDataReader rdr = await cmd.ExecuteReaderAsync() as SqlCeDataReader;
            while (await rdr.ReadAsync())
            {
                Location location = new Location();
                location.Id = rdr.GetInt32(0);
                location.AnimalId = rdr.GetInt32(1);
                location.Latitude = rdr.GetDecimal(2);
                location.Longitude = rdr.GetDecimal(3);
                location.Timestamp = rdr.GetDateTime(4);
                locations.Add(location);
            }

            return locations;
        }
    }
}