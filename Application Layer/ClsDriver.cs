using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsDriver

    {
        public static DataTable GetAllDriver()
        {
            return ClsDataAccessDriver.GetAllDriver();
        }


                   public static int AddNewDriver(int ID,
          int CreatedByUserID, DateTime CreatedDate)
        {
          return  ClsDataAccessDriver.AddNewDriver(ID, CreatedByUserID, CreatedDate);

        }

              public static bool UpdateDriver(int DriverID, int ID,
     int CreatedByUserID, DateTime CreatedDate)
        {
            return ClsDataAccessDriver.UpdateDriver(DriverID, ID, CreatedByUserID,CreatedDate);

        }

              public static bool DeleteDriver(int DriverID)
        {
            return ClsDataAccessDriver.DeleteDriver(DriverID);
        }
        public static DataTable GetlDriverttoCreateInternatiomalDrivingLicence()
        {
            return ClsDataAccessDriver.GetlDriverttoCreateInternatiomalDrivingLicence();
        }
        public static int IsDriverExists(int PersonID)
        {
            return ClsDataAccessDriver.IsDriverExists(PersonID);
        }

    }
}
