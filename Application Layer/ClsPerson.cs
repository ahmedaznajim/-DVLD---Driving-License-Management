using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class Person
    {
        public string NationalNo
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }
        public string SecondName
        {
            get; set;

        }
        public string ThirdName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public DateTime DateOfBirth
        {
            get; set;
        }

        public string Gendor
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string Phone
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public int NationalityCountryID
        {
            get; set;
        }

        public string ImagePath
        {
            get; set;
        }

        public static DataTable GetPplInfo()
        {
            return ClsPeopleDataAccess.GetAllPeople();



        }

        public static int AddPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
             int Gendor, string Address, string Phone, string Email,
                int NationalityCountryID, string ImagePath)
        {

            return ClsPeopleDataAccess.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
             Gendor, Address, Phone, Email,
                NationalityCountryID, ImagePath);



        }


        public static bool SerchByNationalNumber(String s)
        {
            return ClsPeopleDataAccess.IsPersonExist(s);





        }

        public static bool UpdatePerson2(int ID, string NationalNo,
            string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth,
            string Address, string Phone, string Email,
             int NationalityCountryID, string ImagePath)
        {

            return ClsPeopleDataAccess.UpdatePerson(ID, NationalNo,
                FirstName, SecondName, ThirdName, LastName, DateOfBirth,
           0, Address, Phone, Email,
              NationalityCountryID, ImagePath);




        }

        public static bool DeletPerson(int id)
        {
            return ClsPeopleDataAccess.DeletePerson(id);



        }

        public static DataTable SerchByLName(string Lname)
        {
            return ClsPeopleDataAccess.SerchByLastName(Lname);


        }
        public static DataTable SerchByID(int ID)
        {
            return ClsPeopleDataAccess.SerchByID(ID);


        }
        public static DataTable SerchByNationalNo(string NationalNo)
        {
            return ClsPeopleDataAccess.SerchByNationalNo(NationalNo);

        }

    }
}
