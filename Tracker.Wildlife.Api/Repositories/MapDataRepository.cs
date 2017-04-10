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
    public class MapDataRepository
    {
        public async Task<List<MapData>> SelectAll()
        {
            List<MapData> mapDatas = new List<MapData>();
            SqlCeConnection con = new SqlCeConnection(WebConfigurationManager.ConnectionStrings["WildlifeTrackerConnectionString"].ConnectionString);
            SqlCeCommand cmd = new SqlCeCommand(@"SELECT a.Id AnimalId                                                      
                                                        ,s.Name Species                                                        
                                                        ,c.Name Category                                                         
                                                        ,l.Longitude                                                          
                                                        ,l.Latitude                                                          
                                                        ,l.Timestamp                                                    
                                                    FROM Location l                                                          
	                                                    INNER JOIN Animal a                                                              
		                                                    ON l.AnimalId = a.Id                                                          
	                                                    INNER JOIN Species s                                                             
		                                                    ON a.SpeciesId = s.Id                                                           
	                                                    INNER JOIN Category c                                                             
		                                                    ON s.CategoryId = c.Id
                                                    WHERE l.Longitude IS NOT NULL
                                                        AND l.Latitude IS NOT NULL
                                                        AND l.Timestamp IS NOT NULL", con);
            await con.OpenAsync();
            SqlCeDataReader rdr = await cmd.ExecuteReaderAsync() as SqlCeDataReader;
            while (await rdr.ReadAsync())
            {
                MapData mapData = new MapData();
                mapData.AnimalId = rdr.GetInt32(0);
                mapData.Species = rdr.GetString(1);
                mapData.Category = rdr.GetString(2);
                mapData.Latitude = rdr.GetDecimal(3);
                mapData.Longitude = rdr.GetDecimal(4);
                mapData.Timestamp = rdr.GetDateTime(5);
                mapDatas.Add(mapData);
            }

            return mapDatas;
        }
    }
}