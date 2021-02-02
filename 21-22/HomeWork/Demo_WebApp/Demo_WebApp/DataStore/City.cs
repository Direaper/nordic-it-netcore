using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_WebApp.DataStore
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int NumberOfPoi { get; set; }

        public City(int id, string name, string desc, int numberOfPoi)
        {
            Id = id;
            Name = name;
            Description = desc;
            NumberOfPoi = numberOfPoi;
        }
    }
}
