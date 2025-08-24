using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Presentation
{
    public class ClsUsers
    {
        public int PersonID {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }

        public static int CheckUserLogInInfo(string UserName, string Password)
        {
            DataTable dt = ClsUserDataAccess.UserLogInInfo(UserName);
            try
            {
                if (dt.Rows[0] == null)
                {
                    return 1;


                }
                DataRow dr = dt.Rows[0];
                string temp1 = dr[2].ToString();
                string temp2 = "";
                for (int i = 0; i < (dr[2].ToString().Length); i++)
                {
                    if (temp1[i] == ' ')
                    {
                        break;

                    }
                    else
                    {
                        temp2 = temp2 + temp1[i];


                    }




                }

                if (dr != null)
                {
                    if (temp2 == Password )
                    {
                        if (Convert.ToInt32(dr[3]) == 1)
                        {

                            return 0;

                        }
                        else
                        {
                            return 2;
                        }

                    }

                }

            }
            catch
            {

            }

            return 1;



        }
        public static int FindUserIdByUserName(string UserName)
        {
            DataTable dt = ClsUserDataAccess.UserLogInInfo(UserName);
            DataRow dr = dt.Rows[0];
            return Convert.ToInt32(dr[0].ToString());


        }

        public static DataTable FindUserInInfoByUserName(string UserName)
        {
           int PersonId=ClsUsers.FindUserIdByUserName(UserName);
            DataTable dt=ClsUserDataAccess.UserFullInfo(PersonId);



            return dt;



        }

        public static DataTable GetAllUsrers()
        {
            return ClsUserDataAccess.GetAllUsrers();

        }
        public static bool UpdatUser(int UserID, int PersonID, string UserName,
       string Password, int IsActive)
        {
            return ClsUserDataAccess.UpdatUser(UserID, PersonID, UserName,
                    Password, IsActive);

        }
        public static int AddNewUser(int PersonId, string UserName, string Password, int IsActive)
        {
            return ClsUserDataAccess.AddNewUser(PersonId, UserName, Password, IsActive);

        }
        public static DataTable SerchByUserID(int UserID)
        {
            return ClsUserDataAccess.SerchByUserID(UserID);

        }
        public static DataTable SerchByUserName(string UserName)
        {

            return ClsUserDataAccess.SerchByUserName(UserName);

        }
        public static DataTable SerchByPersonID(int PersonID)
        {
            return ClsUserDataAccess.SerchByPersonID(PersonID);
        }

    }
}
