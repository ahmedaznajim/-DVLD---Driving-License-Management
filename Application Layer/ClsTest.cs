using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsTest
    {
        public string TestTypes
        {
            get; set;
        }
        public string TestTypeTitle
        {
            get; set;
        }
        public string TestTypeDescription
        {
            get; set;
        }

        public int TestTypeFees
        {
            get; set;
        }

        public int TestAppointmentID
        {
            get; set;
        }

        public int TestResult
        {
            get; set;
        }

        public int CreatedByUserID
        {
            get; set;
        }
        public string Notes
        {
            get; set;
        }
      
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            return ClsDataAccessTestType.UpdateTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

        }

        public static DataTable GetAllTestType()
        {
            return ClsDataAccessTestType.GetAllTestType();

        }
        public static int AddAnTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, int PaidFees, int CreatedByUserID, int IsLocked)
        {
            return ClsDataAccessTestAppointments.AddAnTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
        }
        public static DataTable GetVisionTestOppointmentsByLDID(int LocalDrivingLicenseApplicationID)
        {
            return ClsDataAccessTestAppointments.GetVisionTestOppointmentsByLDID(LocalDrivingLicenseApplicationID);
        }
        public static bool UpdatTestOppointment(DateTime dateTime, int TestAppointmentID)
        {
            return ClsDataAccessTestAppointments.UpdatTestOppointment(dateTime, TestAppointmentID);
        }
        public static bool PassVidionTestDateTime(int TestAppointmentID, int ApplicationID)
        {
            return ClsDataAccessTestAppointments.PassVidionTestDateTime(TestAppointmentID, ApplicationID);

        }
        public static bool FaildVidionTestDateTime(int TestAppointmentID)
        {
            return ClsDataAccessTestAppointments.FaildVidionTestDateTime(TestAppointmentID);
        }
        public static DataTable GetWrittenTestOppointmentsByLDID(int LocalDrivingLicenseApplicationID) { return ClsDataAccessTestAppointments.GetWrittenTestOppointmentsByLDID(LocalDrivingLicenseApplicationID); }

        public static bool PassWrittenTestDateTime(int TestAppointmentID, int ApplicationID)
        {
            return ClsDataAccessTestAppointments.PassWrittenTestDateTime(TestAppointmentID, ApplicationID);


        }
        public static bool PassStreetTestDateTime(int TestAppointmentID, int ApplicationID)
        {
            return ClsDataAccessTestAppointments.PassStreetTestDateTime(TestAppointmentID, ApplicationID);
        }

        public static DataTable GetStreetTestOppointmentsByLDID(int LocalDrivingLicenseApplicationID)
        {
            return ClsDataAccessTestAppointments.GetStreetTestOppointmentsByLDID(LocalDrivingLicenseApplicationID);
        }
    }
}
