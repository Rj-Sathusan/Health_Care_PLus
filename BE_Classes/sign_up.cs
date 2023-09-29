using MySql.Data.MySqlClient;
 using System.Windows.Forms;
 using System.Data;
using System;

namespace Health_Care.BE_Classes
{
    class sign_up : DAL.NewDataAccessLayer
    {
        private string user_name{ get; set; }
        private string password{ get; set; }

        //public DataTable Login(string value)
        //{
        //    return ExecuteStoredProcedure("sp_room_SelectAll");
        //}

        public void Login(out string role)
        {
            role = null; // Initialize the role to null

            MySqlParameter[] param = new MySqlParameter[3]; // Add an extra parameter for the role

            param[0] = new MySqlParameter("@p_username", MySqlDbType.VarChar, 255);
            param[0].Value = user_name;

            param[1] = new MySqlParameter("@p_password", MySqlDbType.VarChar, 255); // Fix parameter name
            param[1].Value = password;

            param[2] = new MySqlParameter("@p_role", MySqlDbType.VarChar, 50);
            param[2].Direction = ParameterDirection.Output; // Specify that this is an output parameter

            if (OpenConnection())
            {
                SelectData("CheckUserAndGetRole", param);

                // Retrieve the role from the output parameter
                role = param[2].Value.ToString();

                CloseConnection();
            }
        }

        //public DataTable Login()
        //{
        //    DataTable dt = new DataTable();

        //    MySqlParameter[] param = new MySqlParameter[2];

        //    param[0] = new MySqlParameter("@p_username", MySqlDbType.VarChar, 255);
        //    param[0].Value = user_name; 
        //    param[1] = new MySqlParameter("@p_username", MySqlDbType.VarChar, 255);
        //    param[1].Value = password;
          
        //    if (OpenConnection())
        //    {
        //        dt = SelectData("CheckUserAndGetRole", param);
        //        CloseConnection();
        //    }

        //    return dt;
        //}

        public sign_up(string user_name, string pass)
        {

            this.user_name = user_name;
            this.password = pass;

        }

        public sign_up()
        {
            // TODO: Complete member initialization
        }
    }
    }