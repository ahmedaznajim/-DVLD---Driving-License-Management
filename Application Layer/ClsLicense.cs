using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsLicense
    {
        public static DataTable getLicensesClasses()
        {
            return ClsDataAccessLicense.getLicensesClasses();



        }

        public static DataTable GetAllLicence()
        {
            return ClsDataAccessLicense.GetAllLicence();

        }
        public static int AddNewLicence(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, String Notes, int PaidFees,
   int IsActive, int IssueReason, int CreatedByUserID)
        {
          return  ClsDataAccessLicense.AddNewLicence(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

        }


                  public static bool UpdateDriver(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, String Notes,
          int PaidFees,
          int IsActive, int IssueReason, int CreatedByUserID)
        {
            return ClsDataAccessLicense.UpdateDriver(LicenseID, ApplicationID, DriverID, LicenseClass,IssueDate, ExpirationDate, Notes,PaidFees,IsActive, IssueReason,CreatedByUserID);

        }


              public static bool DeleteDriver(int LicenseID)
        {
            return ClsDataAccessLicense.DeleteDriver(LicenseID);

        }
        public static DataTable ShowLicenceInfo(int LicenseID)
        {
            return ClsDataAccessLicense.ShowLicenceInfo(LicenseID);
        }
        public static DateTime getLicenceclassExpireDate(int LicenseClassID)
        {
            DataTable dt = ClsDataAccessLicense.getLicenceclassExpireDate(LicenseClassID);
            DataRow r=dt.Rows[0];

            DateTime d = DateTime.Now.AddYears(Convert.ToInt32(r[0]));

            return d;
        }
        public static bool IsLicenceExist(int AppID, int LicenseID)
        {

            return ClsDataAccessLicense.IsLicenceExist(AppID, LicenseID);
        }
        public static bool IsInternationalLicenceExist(int LicenseID)
        {
            return ClsDataAccessLicense.IsInternationalLicenceExist((int)LicenseID);
        }
        public static int AddNewInternationalLicence(int ApplicationID, int DriverID, int LicenseID, DateTime IssueDate, DateTime ExpirationDate,
   int IsActive, int CreatedByUserID)
        {
            return ClsDataAccessLicense.AddNewInternationalLicence(ApplicationID, DriverID, LicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }
        public static bool DeactivateInternationalDrivingLicence(int InternationalLicenseID)
        {
            return ClsDataAccessLicense.DeactivateInternationalDrivingLicence((int)InternationalLicenseID);
        }

        public static DataTable SerchLocalByLastName(string Lname)
        {
            return ClsDataAccessLicense.SerchLocalByLastName(Lname);
        }

        public static DataTable SerchLocaDLByID(int ID)
        {
            return ClsDataAccessLicense.SerchLocaDLByID((int)ID);
        }

        public static DataTable SerchLocalByNationalNo(string NationalNo)
        {
            return ClsDataAccessLicense.SerchLocalByNationalNo(NationalNo);
        }
        public static bool DeactivateLocalDrivingLicence(int LicenseID)
        {return ClsDataAccessLicense.DeactivateLocalDrivingLicence(LicenseID);

        }

        public static DataTable getLicensesHistoryForADriver(int DriverID)
        {
            return ClsDataAccessLicense.getLicensesHistoryForADriver(DriverID);
        }

        public static int DetainLicenec(int LicenseID, DateTime DetainDateime,
        int FineFeestive, int CreatedByUserID)
        {
            return ClsDataAccessLicense.DetainLicenec(LicenseID, DetainDateime, FineFeestive, CreatedByUserID);

        }
        public static bool IsDetaindedExist(int LicenseID)
        {
            return ClsDataAccessLicense.IsDetaindedExist(LicenseID);
        }

        public static string IsLicenceDetained(int LicenseID)
        {
            if (ClsDataAccessLicense.IsLicenceDetained(LicenseID))
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public static DataTable getDetainInfo(int LicenseID)
        {
            return ClsDataAccessLicense.getDetainInfo(LicenseID);
        }
        public static bool ReleaseLicenec(int LicenseID, DateTime DetainDateime,
  int FineFeestive, int CreatedByUserID, int IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            return ClsDataAccessLicense.ReleaseLicenec(LicenseID, DetainDateime, FineFeestive, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }
    }
}
