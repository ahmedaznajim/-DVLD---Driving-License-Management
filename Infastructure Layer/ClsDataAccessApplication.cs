using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public class ClsDataAccessApplication
    {
       public static DataTable GetAllApplicationsType()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes ;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        
    }
        public static bool UpdateApplcationType(int ApplicationTypeID, int ApplicationFees, string ApplicationTypeTitle)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[ApplicationTypes]
   SET [ApplicationTypeTitle] =@ApplicationTypeTitle
      ,[ApplicationFees] = @ApplicationFees
 WHERE ApplicationTypeID=@ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
           
           



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetLocalApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT  ROW_NUMBER() OVER(ORDER BY(SELECT NULL)) AS Num, PersonID, LocalDrivingLicenseApplications.ApplicationID,     LicenseClasses.LicenseClassID,  ClassName,       FirstName,   LastName,    ApplicationDate,   CASE WHEN Applications.ApplicationStatus = 1 THEN 'New'        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'       WHEN Applications.ApplicationStatus = 3 THEN 'Completed'       ELSE 'Unknown'     END AS ApplicationStatus,     Applications.[Passed Tests],   Applications.PaidFees,    NationalNo,LocalDrivingLicenseApplicationID FROM LocalDrivingLicenseApplications INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID; ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddNewLocalApplication(int ApplicationID, int LicenseClassID)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[LocalDrivingLicenseApplications]
           ([ApplicationID]
           ,[LicenseClassID])
     VALUES
           (@ApplicationID
           ,@LicenseClassID)
    SELECT SCOPE_IDENTITY();"
            ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return PersonID;
        }

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus
            ,DateTime LastStatusDate, int PaidFees, int  CreatedByUserID)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Applications]
           ([ApplicantPersonID]
           ,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
           ,[LastStatusDate]
           ,[PaidFees]
           ,[CreatedByUserID])
     VALUES
           (@ApplicantPersonID
           ,@ApplicationDate
           ,@ApplicationTypeID
           ,@ApplicationStatus
           ,@LastStatusDate
           ,@PaidFees
           ,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return PersonID;
        }
        public static bool ISLocalApplicationExists(int PersonID,int  LicenseClassID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT \r\n    LocalDrivingLicenseApplications.ApplicationID, \r\n    ClassName, \r\n    FirstName, \r\n    LastName, \r\n    ApplicationDate, \r\n    CASE \r\n        WHEN Applications.ApplicationStatus = 1 THEN 'New'\r\n        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'\r\n        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'\r\n        ELSE 'Unknown' -- Optional: Handle unexpected status values\r\n    END AS ApplicationStatus , Applications.[Passed Tests]\r\nFROM \r\n    LocalDrivingLicenseApplications\r\nINNER JOIN \r\n    Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID\r\nINNER JOIN \r\n    LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID\r\nINNER JOIN \r\n    People ON Applications.ApplicantPersonID = People.PersonID where People.PersonID=@PersonID and LicenseClasses.LicenseClassID=@LicenseClassID and ApplicationStatus=1 ;";
      
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                  return true;
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;


        }
        public static bool DeleteLocalLicencesApplication(int ApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[LocalDrivingLicenseApplications]
      WHERE ApplicationID=@ApplicationID;

DELETE FROM [dbo].[Applications]
      WHERE Applications.ApplicationID=@ApplicationID;
";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);



        }
        public static bool CancelLocalLicenceApplication(int ApplicationTypeID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Applications]
   SET 
      [ApplicationStatus] = 2
      
 WHERE Applications.ApplicationID=@ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
         





            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetApplicationsByAppID(int APPID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "  SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Num,    PersonID,     LocalDrivingLicenseApplications.ApplicationID,    LicenseClasses.LicenseClassID,       ClassName,        FirstName,       LastName,      ApplicationDate,       CASE         WHEN Applications.ApplicationStatus = 1 THEN 'New'     WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'       WHEN Applications.ApplicationStatus = 3 THEN 'Completed'       ELSE 'Unknown'       END AS ApplicationStatus,  Applications.[Passed Tests],  Applications.PaidFees,   NationalNo,LocalDrivingLicenseApplicationID FROM LocalDrivingLicenseApplications  INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID where Applications.ApplicationID=@APPID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@APPID", APPID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;


        }
        public static bool ISInternationalApplicationExists(int PersonID, int LicenseClassID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT \r\n    LocalDrivingLicenseApplications.ApplicationID, \r\n    ClassName, \r\n    FirstName, \r\n    LastName, \r\n    ApplicationDate, \r\n    CASE \r\n        WHEN Applications.ApplicationStatus = 1 THEN 'New'\r\n        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'\r\n        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'\r\n        ELSE 'Unknown' -- Optional: Handle unexpected status values\r\n    END AS ApplicationStatus , Applications.[Passed Tests]\r\nFROM \r\n    LocalDrivingLicenseApplications\r\nINNER JOIN \r\n    Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID\r\nINNER JOIN \r\n    LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID\r\nINNER JOIN \r\n    People ON Applications.ApplicantPersonID = People.PersonID where People.PersonID=@PersonID and LicenseClasses.LicenseClassID=@LicenseClassID and ApplicationStatus=1 ;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    return true;
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;


        }
        public static bool SetStatuesToComplete(int ID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "UPDATE [dbo].[Applications]\r\n   SET \r\n      ,[ApplicationStatus] = 3\r\n     \r\n WHERE ApplicationID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
  

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    return true;
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return false;


        }
        public static bool CompleteLocalLicenceApplication(int ApplicationTypeID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Applications]
   SET 
      [ApplicationStatus] = 3
      
 WHERE Applications.ApplicationID=@ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);






            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetInternationalApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT   InternationalLicenseID,PersonID,   InternationalLicenses.ApplicationID,     FirstName,     LastName,    ApplicationDate,    CASE       WHEN Applications.ApplicationStatus = 1 THEN 'New'        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'       ELSE 'Unknown'    END AS ApplicationStatus , Applications.[Passed Tests] ,Applications.PaidFees ,InternationalLicenses.IsActive FROM     InternationalLicenses  INNER JOIN     Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID   INNER JOIN     People ON Applications.ApplicantPersonID = People.PersonID;"
          ;
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static DataTable GetLocalApplications2()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT  PersonID,   LocalDrivingLicenseApplications.ApplicationID, LicenseClasses.LicenseClassID,    ClassName,     FirstName,     LastName,    ApplicationDate,    CASE       WHEN Applications.ApplicationStatus = 1 THEN 'New'    WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'       WHEN Applications.ApplicationStatus = 3 THEN 'Completed'        ELSE 'Unknown'    END AS ApplicationStatus , Applications.[Passed Tests] ,Applications.PaidFees,NationalNo,LicenseID ,DriverID,IsActive FROM     LocalDrivingLicenseApplications  INNER JOIN     Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN     LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  INNER JOIN    People ON Applications.ApplicantPersonID = People.PersonID inner join Licenses on Licenses.ApplicationID=Applications.ApplicationID;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
