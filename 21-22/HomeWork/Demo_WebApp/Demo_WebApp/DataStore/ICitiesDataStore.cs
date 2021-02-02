using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_WebApp.DataStore
{
    public interface ICitiesDataStore
    {
        List<City> Cities { get; }

        int GetNewId();
    }
}
