using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsApplication
    {
       public int ApplicantPersonID {  get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }



        public static DataTable GetAllApplicationsType()
        {
            return ClsDataAccessApplication.GetAllApplicationsType();
        }
        public static bool UpdateApplcationType(int ApplicationTypeID, int ApplicationFees, string ApplicationTypeTitle)
        {
            return ClsDataAccessApplication.UpdateApplcationType(ApplicationTypeID, ApplicationFees, ApplicationTypeTitle);
        }
        public static DataTable GetLocalApplications()
        {
          return  ClsDataAccessApplication.GetLocalApplications();

        }
        public static int AddNewLocalApplication(int ApplicationID, int LicenseClassID)
        {
            return ClsDataAccessApplication.AddNewLocalApplication(ApplicationID, LicenseClassID);
        }
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus
           , DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            return ClsDataAccessApplication.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus , LastStatusDate, PaidFees, CreatedByUserID);

        }
        public static bool ISLocalApplicationExists(int PersonID, int LicenseClassID)
        {
            return ClsDataAccessApplication.ISLocalApplicationExists(PersonID, LicenseClassID);

        }
        public static bool DeleteLocalLicencesApplication(int ApplicationID)
        {
            return ClsDataAccessApplication.DeleteLocalLicencesApplication(ApplicationID);

        }
        public static bool CancelLocalLicenceApplication(int ApplicationTypeID)
        {
            return ClsDataAccessApplication.CancelLocalLicenceApplication(ApplicationTypeID);

        }
        public static DataTable GetApplicationsByAppID(int APPID)
        {
            return ClsDataAccessApplication.GetApplicationsByAppID((int)APPID);

        }
        public static bool SetStatuesToComplete(int ID)
        {
           return ClsDataAccessApplication.CompleteLocalLicenceApplication(ID);
        }
        public static DataTable GetInternationalApplications()
        {
            return ClsDataAccessApplication. GetInternationalApplications();
        }

        public static DataTable GetLocalApplications2()
        {
            return ClsDataAccessApplication.GetLocalApplications2();
        }
    }
}
