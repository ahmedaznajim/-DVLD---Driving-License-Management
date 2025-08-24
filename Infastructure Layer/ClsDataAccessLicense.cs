using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClsDataAccessLicense
    {
        public static DataTable getLicensesClasses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses ;";

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
        public static DataTable GetAllLicence()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select People.FirstName,People.LastName,People.ImagePath,People.NationalNo,People.DateOfBirth,Licenses.DriverID,Licenses.ExpirationDate,Licenses.IssueDate,Licenses.IsActive,Licenses.Notes,Licenses.PaidFees,Drivers.DriverID,NationalNo from Licenses inner join Drivers on Drivers.DriverID=Licenses.DriverID inner join People on People.PersonID=Drivers.PersonID;";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int AddNewLicence(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, String Notes, int PaidFees,
            int IsActive, int IssueReason, int CreatedByUserID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Licenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@LicenseClass
           ,@IssueDate
           ,@ExpirationDate
           ,@Notes
           ,@PaidFees
           ,@IsActive
           ,@IssueReason
           ,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
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

        public static bool UpdateDriver(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, String Notes,
            int PaidFees,
            int IsActive, int IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Licenses]
   SET [ApplicationID] = @ApplicationID
      ,[DriverID] =@DriverID
      ,[LicenseClass] = @LicenseClass
      ,[IssueDate] =@IssueDate
      ,[ExpirationDate] = @ExpirationDate
      ,[Notes] = @Notes
      ,[PaidFees] =@PaidFees
      ,[IsActive] =@IsActive
      ,[IssueReason] =@IssueReason
      ,[CreatedByUserID] =@CreatedByUserID
 WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);




            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteDriver(int LicenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[Licenses]
      WHERE LicenseID=@LicenseID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static DataTable ShowLicenceInfo(int LicenseID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select  LicenseID,ClassName, FirstName,LastName,LicenseID,NationalNo,Gendor,IssueDate,IssueReason,Notes,IsActive,DateOfBirth,Drivers.DriverID,ExpirationDate,People.PersonID ,Licenses.LicenseClass from People inner join Drivers on Drivers.PersonID=People.PersonID inner join Licenses on Licenses.DriverID=Drivers.DriverID inner join LicenseClasses on LicenseClasses.LicenseClassID=Licenses.LicenseClass where LicenseID=@LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static DataTable getLicenceclassExpireDate(int LicenseClassID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select LicenseClasses.DefaultValidityLength from LicenseClasses where LicenseClassID=@LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool IsLicenceExist(int AppID, int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT [LicenseID]\r\n      ,[ApplicationID]\r\n      ,[DriverID]\r\n      ,[LicenseClass]\r\n      ,[IssueDate]\r\n      ,[ExpirationDate]\r\n      ,[Notes]\r\n      ,[PaidFees]\r\n      ,[IsActive]\r\n      ,[IssueReason]\r\n      ,[CreatedByUserID]\r\n  FROM [dbo].[Licenses] where ApplicationID=@AppID and LicenseClass=@LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AppID", AppID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool IsInternationalLicenceExist(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from InternationalLicenses where IssuedUsingLocalLicenseID = @LicenseID ;";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewInternationalLicence(int ApplicationID, int DriverID, int LicenseID, DateTime IssueDate, DateTime ExpirationDate,
           int IsActive, int CreatedByUserID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[InternationalLicenses]
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
     VALUES
           ( @ApplicationID
           ,@DriverID
           ,@LicenseID
           ,@IssueDate
           ,@ExpirationDate
           ,@IsActive
           ,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);


            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);




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
        public static bool DeactivateInternationalDrivingLicence(int InternationalLicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[InternationalLicenses]
   SET 
      [IsActive] = 0
     
 WHERE InternationalLicenseID=@InternationalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);




            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable SerchLocalByLastName(string Lname)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT  PersonID,   LocalDrivingLicenseApplications.ApplicationID, LicenseClasses.LicenseClassID,    ClassName,     FirstName,     LastName,    ApplicationDate,    CASE       WHEN Applications.ApplicationStatus = 1 THEN 'New'        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'        ELSE 'Unknown'      END AS ApplicationStatus , Applications.[Passed Tests] ,Applications.PaidFees,NationalNo FROM     LocalDrivingLicenseApplications  INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID  INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  INNER JOIN    People ON Applications.ApplicantPersonID = People.PersonID where LastName=@Lname ;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Lname", Lname);
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

        public static DataTable SerchLocaDLByID(int ID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT  PersonID,   LocalDrivingLicenseApplications.ApplicationID, LicenseClasses.LicenseClassID,    ClassName,     FirstName,     LastName,    ApplicationDate,    CASE       WHEN Applications.ApplicationStatus = 1 THEN 'New'        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'        ELSE 'Unknown'      END AS ApplicationStatus , Applications.[Passed Tests] ,Applications.PaidFees,NationalNo FROM     LocalDrivingLicenseApplications  INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID  INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  INNER JOIN    People ON Applications.ApplicantPersonID = People.PersonID where PersonID = @ID ;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
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

        public static DataTable SerchLocalByNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT  PersonID,   LocalDrivingLicenseApplications.ApplicationID, LicenseClasses.LicenseClassID,    ClassName,     FirstName,     LastName,    ApplicationDate,    CASE       WHEN Applications.ApplicationStatus = 1 THEN 'New'        WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'        WHEN Applications.ApplicationStatus = 3 THEN 'Completed'        ELSE 'Unknown'      END AS ApplicationStatus , Applications.[Passed Tests] ,Applications.PaidFees,NationalNo FROM     LocalDrivingLicenseApplications  INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID  INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID  INNER JOIN    People ON Applications.ApplicantPersonID = People.PersonID where NationalNo = @NationalNo ;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
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
        public static bool DeactivateLocalDrivingLicence(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Licenses]
   SET 
      [IsActive] = 0
     
 WHERE Licenses.LicenseID=@LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);




            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable getLicensesHistoryForADriver(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Licenses inner join Drivers on Drivers.DriverID=Licenses.DriverID where Licenses.DriverID=@DriverID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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
        public static bool IsDetaindedExist(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from DetainedLicenses where LicenseID = @LicenseID ;";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int DetainLicenec(int LicenseID, DateTime DetainDateime,
         int FineFeestive, int CreatedByUserID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[DetainedLicenses]
           ([LicenseID]
           ,[DetainDate]
           ,[FineFees]
           ,[CreatedByUserID]
           ,[IsReleased]
           ,[ReleaseDate]
           ,[ReleasedByUserID]
           ,[ReleaseApplicationID])
     VALUES
           (@LicenseID
           ,@DetainDateime
           ,@FineFees
           ,@CreatedByU
           ,@IsReleased
           ,@ReleaseDate
           ,@ReleasedByUserID
           ,@ReleaseApplicationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDateime", DetainDateime);
            command.Parameters.AddWithValue("@FineFees", FineFeestive);

            command.Parameters.AddWithValue("@CreatedByU", CreatedByUserID);



            command.Parameters.AddWithValue("@IsReleased", System.DBNull.Value);




            command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);



            command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);


            command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);





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

        public static bool IsLicenceDetained(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM[dbo].[DetainedLicenses] where LicenseID = @LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool ReleaseLicenec(int LicenseID, DateTime DetainDateime,
        int FineFeestive, int CreatedByUserID, int IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[DetainedLicenses]
   SET 
      [DetainDate] = @DetainDateime
      ,[FineFees] =   @FineFees
      ,[CreatedByUserID] = @CreatedByUserID
      ,[IsReleased] = 1
      ,[ReleaseDate] = @ReleaseDate
      ,[ReleasedByUserID] = @ReleasedByUserID
      ,[ReleaseApplicationID] = @ReleaseApplicationID
 WHERE [LicenseID]=@LicenseID;
DELETE FROM [dbo].[DetainedLicenses]
      WHERE [LicenseID]=@LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDateime", DetainDateime);
            command.Parameters.AddWithValue("@FineFees", FineFeestive);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            command.Parameters.AddWithValue("@IsReleased", IsReleased);




            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);



            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);


            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);





            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    


        public static DataTable getDetainInfo( int LicenseID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT* FROM [dbo].[DetainedLicenses] where LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
