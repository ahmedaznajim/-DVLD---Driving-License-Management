using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }


        public static DataTable GetCountries()
        {
            return ClsDataAccessCountry.GetCountries();

        }
        
        }
}
