using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsCar
    {

        public static DataTable GetAllCarsModels()
        {
            return ClsDataAccessCar.GetAllCarsModels();
        }
        public static DataTable GetAllCarsModelsBYName(String CarName)
            {
            return ClsDataAccessCar.GetAllCarsModelsBYName(CarName);
        }

        public static int FeesForRegisterANewCar(int Engine,int year,string Fule)


        {
            try
            {
                if (Fule == "GAS" || Fule == "DIESEL" || Fule == "HYBRID")
                {

                    if (Engine <= 1500 && year < (DateTime.Now.Year - 10))
                    {
                        return 40;
                    }
                    if (Engine <= 1500 && year >= (DateTime.Now.Year - 10))
                    {
                        return 30;
                    }


                    if ((Engine >= 1500 && Engine <= 2000) && year < (DateTime.Now.Year - 10))
                    {
                        return 80;
                    }

                    if ((Engine >= 1500 && Engine <= 2000) && year >= (DateTime.Now.Year - 10))
                    {
                        return 60;
                    }



                    if ((Engine >= 2000 && year < (DateTime.Now.Year - 10)))
                    {
                        return 200;
                    }

                    if ((Engine >= 2000 && year >= (DateTime.Now.Year - 10)))
                    {
                        return 100;
                    }



                }
                if (Fule == "EV")
                {
                    return 50;

                }
                



                else
                {
                    return 50;
                }
            }
            catch { }
            return 0;

        }



        public static int FeesForReRegister( int Price, string Fule)


        {
            try
            {
                if (Fule == "GAS" || Fule == "DIESEL")
                {

                    if (Price <= 10000)
                    {
                        return 50;
                    }

                    if (Price > 10000 && Price <= 25000)
                    {
                        return 125;
                    }

                    if (Price > 25000 && Price <= 50000)
                    {
                        return 300;
                    }

                    if (Price > 50000 && Price <= 100000)
                    {
                        return 500;
                    }

                    if (Price > 100000)
                    {
                        return 800;
                    }

                }
                if (Fule == "HYBRID")
                {

                    if (Price <= 10000)
                    {
                        return 50;
                    }

                    if (Price > 10000 && Price <= 25000)
                    {
                        return 100;
                    }

                    if (Price > 25000 && Price <= 50000)
                    {
                        return 200;
                    }

                    if (Price > 50000 && Price <= 100000)
                    {
                        return 400;
                    }

                    if (Price > 100000)
                    {
                        return 600;
                    }
                }

                if (Fule == "HYBRID")
                {

                    if (Price <= 10000)
                    {
                        return 50;
                    }

                    if (Price > 10000 && Price <= 25000)
                    {
                        return 100;
                    }

                    if (Price > 25000 && Price <= 50000)
                    {
                        return 200;
                    }

                    if (Price > 50000 && Price <= 100000)
                    {
                        return 400;
                    }

                    if (Price > 100000)
                    {
                        return 600;
                    }
                } 



            }



            catch { }
            return 0;

        }



        public static int AddNewCar(int PersonID, int UserID, string CarName, int CarEngine, string FueType, int NumberOfDoors,
int VIN, string Color, DateTime StartRegistrationDate, DateTime EndRegistrationDate,
  int ReRegistrationFees, int TaxFreePrice, string year)
        {
            return ClsDataAccessCar.AddNewCar(PersonID, UserID, CarName, CarEngine, FueType, NumberOfDoors,
           VIN, Color, StartRegistrationDate, EndRegistrationDate,
           ReRegistrationFees, TaxFreePrice,year);
        }


        public static DataTable GetCarInfoByCarID(int CarID)
        {
            return ClsDataAccessCar.GetCarInfoByCarID(CarID);
        }


        public static DataTable GetUnregisterdCars(int personID)
        {
            return ClsDataAccessCar.GetUnregisterdCars(personID);
        }
        public static bool ReRegister(int ID)
        {
            return ClsDataAccessCar.ReRegister(ID);
        }
    }
}
