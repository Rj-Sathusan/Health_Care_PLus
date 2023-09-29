using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace Health_Care.BE_Classes
{
    class StaffDetails : DAL.NewDataAccessLayer
    {
        private int id;
        private string name;
        private string username;
        private string password;
        private string role;
        private string todayTask;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public string TodayTask
        {
            get { return todayTask; }
            set { todayTask = value; }
        }

        private bool ExecuteStaffCommand(string procedureName, MySqlParameter[] parameters)
        {
            try
            {
                if (OpenConnection())
                {
                    if (ExecuteCommand(procedureName, parameters))
                    {
                        ShowMessage("Data saved successfully.", "Success");
                        return true;
                    }
                    else
                    {
                        ShowMessage("Failed to save data. Duplicate entry or an error occurred.", "Error");
                        return false;
                    }
                }
                else
                {
                    ShowMessage("Unable to connect to the server. Please check your connection.", "Error");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("An error occurred: " + ex.Message, "Error");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool Save()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@name_param", MySqlDbType.VarChar, 255) { Value = name },
                new MySqlParameter("@username_param", MySqlDbType.VarChar, 255) { Value = username },
                new MySqlParameter("@password_param", MySqlDbType.VarChar, 255) { Value = password },
                new MySqlParameter("@role_param", MySqlDbType.VarChar, 50) { Value = role },
                new MySqlParameter("@todaytask_param", MySqlDbType.Text) { Value = todayTask }
            };

            return ExecuteStaffCommand("sp_staff_Save", param);
        }

        public bool Edit()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = id },
                new MySqlParameter("@name_param", MySqlDbType.VarChar, 255) { Value = name },
                new MySqlParameter("@username_param", MySqlDbType.VarChar, 255) { Value = username },
                new MySqlParameter("@password_param", MySqlDbType.VarChar, 255) { Value = password },
                new MySqlParameter("@role_param", MySqlDbType.VarChar, 50) { Value = role },
                new MySqlParameter("@todaytask_param", MySqlDbType.Text) { Value = todayTask }
            };

            return ExecuteStaffCommand("sp_staff_Edit", param);
        }

        public bool Delete()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = id }
            };

            return ExecuteStaffCommand("sp_staff_Delete", param);
        }

        public DataTable GetStaff()
        {
            DataTable dataTable = null;

            if (OpenConnection())
            {
                dataTable = SelectData("sp_staff_SelectAll", null);
                CloseConnection();
            }

            return dataTable;
        }

        public void BindStaffDetails(DataGridView dgv)
        {
            BindGrid(dgv, GetStaff());
        }

        public DataTable GetStaffByName(string searchText)
        {
            
                DataTable dt = new DataTable();

                MySqlParameter[] param = {
                new MySqlParameter("@searchText_param", MySqlDbType.VarChar, 255) { Value = searchText }
                     };

                if (OpenConnection())
                {
                    dt = SelectData("sp_staff_Search", param);
                    CloseConnection();
                }

                return dt;
           

        }

        public void BindStaffDetailsSearch(DataGridView dgv, string searchText)
        {
            try
            {
                BindGrid(dgv, GetStaffByName(searchText));

                if (dgv.Rows.Count >= 1)
                {
                    if (dgv.SelectedRows.Count >= 1)
                    {
                        dgv.SelectedRows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        public StaffDetails(int staffId)
        {
            id = staffId;
        }

        public StaffDetails()
        {
        }

        public StaffDetails(int _id,string staffName, string staffUsername, string staffPassword, string staffRole, string staffTodayTask)
        {
            id = _id;
            name = staffName;
            username = staffUsername;
            password = staffPassword;
            role = staffRole;
            todayTask = staffTodayTask;
        }
    }
}
