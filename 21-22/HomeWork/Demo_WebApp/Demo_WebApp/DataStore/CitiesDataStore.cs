using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_WebApp.Models;


namespace Demo_WebApp.DataStore
{
    public class CitiesDataStore : ICitiesDataStore
    {
        public List<City> Cities { get; }
        public CitiesDataStore()
        {
            Cities = new List<City>
            {
                new City(1, "Moscow", "The city", 99),
                new City(2, "Piter", "The city", 100),
                new City(3, "New York", "The city", 98)
            };
        }

        public int GetNewId()
        {
            return Cities
               .Select(c => c.Id)
               .Max() + 1;
        }
    }
}
