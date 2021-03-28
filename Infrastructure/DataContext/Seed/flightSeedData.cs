using AirBangladesh.DataContext;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataContext.Seed
{
    public class flightSeedData
    {
        public static async Task SeedAsync(AppDataContext dataContext, int? retray = 0)
        {
            int retryForAvailability = retray.Value;

            try
            {
                dataContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    await SeedAsync(dataContext, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Flight> PrepareSeed()
        {
            return new List<Flight>()
            {
                new Flight(){
                    Id = Guid.NewGuid(),
  AirlineId=  "string",
  AirlineName = "string",
  FromLocation = "string",
 TOLocation = "string",
  FlightId = Guid.NewGuid(),
}
            };
        }
    }
}
