using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ClsDataAccessCar
    {


        public static DataTable GetAllCarsModels()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccesSettingsCarTable.ConnectionString);

            string query = "select Vehicle_Display_Name,[Year],Engine_CC,FuelTypeID ,NumDoors from VehicleDetails;";

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

        public static DataTable GetAllCarsModelsBYName(String CarName)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccesSettingsCarTable.ConnectionString);
            CarName =  CarName + "%";
            string query = "select Vehicle_Display_Name,[Year],Engine_CC,FuelTypeID ,NumDoors from VehicleDetails where Vehicle_Display_Name LIKE @CarName;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarName", CarName);

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

        public static int AddNewCar(int PersonID, int UserID, string CarName, int CarEngine, string FueType, int NumberOfDoors,
  int VIN, string Color, DateTime StartRegistrationDate, DateTime EndRegistrationDate,
     int ReRegistrationFees, int TaxFreePrice,string year)
        {
           
            int CarID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Cars]
           ([PersonID]
           ,[UserID]
           ,[CarName]
           ,[CarEngine]
           ,[FueType]
           ,[NumberOfDoors]
           ,[VIN]
           ,[Color]
           ,[StartRegistrationDate]
           ,[EndRegistrationDate]
           ,[ReRegistrationFees]
           ,[TaxFreePrice]
,[year])
     VALUES
           (@PersonID
           ,@UserID
           ,@CarName
           ,@CarEngine
           ,@FueType
           ,@NumberOfDoors
           ,@VIN
           ,@Color
           ,@StartRegistrationDate
           ,@EndRegistrationDate
           ,@ReRegistrationFees
           ,@TaxFreePrice
           ,@year);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@CarName", CarName);
            
                command.Parameters.AddWithValue("@CarEngine", CarEngine);
            
                command.Parameters.AddWithValue("@FueType", FueType);

            command.Parameters.AddWithValue("@NumberOfDoors", NumberOfDoors);
            command.Parameters.AddWithValue("@VIN", VIN);

          
                command.Parameters.AddWithValue("@Color", Color);
          
                command.Parameters.AddWithValue("@StartRegistrationDate", StartRegistrationDate);

            command.Parameters.AddWithValue("@EndRegistrationDate", EndRegistrationDate);
            command.Parameters.AddWithValue("@ReRegistrationFees", ReRegistrationFees);
            command.Parameters.AddWithValue("@TaxFreePrice", TaxFreePrice);
            command.Parameters.AddWithValue("@year", year);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CarID = insertedID;
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


            return CarID;
        }


        public static DataTable GetCarInfoByCarID(int CarID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
           
            string query = "SELECT * FROM [dbo].[Cars]   where CarID=@CarID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CarID", CarID);

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


        public static DataTable GetUnregisterdCars(int personID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM [dbo].[Cars] where PersonID=@personID and EndRegistrationDate<GETDATE(); ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);

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


        public static bool ReRegister(int ID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Cars]
SET 
    StartRegistrationDate = CAST(GETDATE() AS DATE),
    EndRegistrationDate = DATEADD(YEAR, 1, CAST(GETDATE() AS DATE))
WHERE CarID=@ID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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

    }
}
