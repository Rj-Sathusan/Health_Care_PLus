using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Health_Care.DAL
{
    class NewDataAccessLayer : DAL.function_
    {
        //DAL.function_ func;
        public static MySqlConnection sqlconnection;
        public static DataTable comtable;
        

        public bool OpenConnection()
        {
            sqlconnection = new MySqlConnection(Configurations.Config.ConnectionString);

            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
            try
            {
                sqlconnection.Open();
            }
            catch (Exception exception)
            {
                this.ErrorMessge(exception.Message);
                sqlconnection.Close();
                return false;
            }
            return true;
        }


        public bool CloseConnection()
        {
            sqlconnection = new MySqlConnection(Configurations.Config.ConnectionString);


            try
            {
                if (sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }
            catch (Exception exception)
            {
                this.ErrorMessge(exception.Message);
                sqlconnection.Close();
                return false;
            }
            return true;
        }

        public DataTable dataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandTimeout = 1000;
                sqlcmd.CommandText = sql;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = sqlconnection;


                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);

                // OpenConnection();
                da.Fill(dt);
                // CloseConnection();
                return dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return dt; }


        }

      
        public DataTable SelectData(string stored_procedure, MySqlParameter[] para)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 1000;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlconnection;

                if (para != null)
                {
                    for (Int32 i = 0; i < para.Length; i++)
                    {
                        sqlcmd.Parameters.Add(para[i]);

                    }

                }

                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);


                da.Fill(dt);

                return dt;
            }
            catch  {  return dt; }

        }

        public bool ExecuteCommand(string stored_procedure, MySqlParameter[] para)
        {
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlconnection;

                if (para != null)
                {

                    sqlcmd.Parameters.AddRange(para);
                }
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public DataTable ExecuteStoredProcedure(string storedProcedureName)
        {
            DataTable dt = new DataTable();

            if (OpenConnection())
            {
                dt = SelectData(storedProcedureName, null);
                CloseConnection();
            }

            return dt;
        }
        public bool run_procedure(string procedureName,string action, MySqlParameter[] parameters)
        {
            try
            {
                if (ShowMessage("Are You Sure You Want To "+action +"?", "Confirm"))
                {
                    if (OpenConnection())
                    {
                        if (ExecuteCommand(procedureName, parameters))
                        {
                            ShowMessage("Data" +action +" successfully.", "Success");
                            return true;
                        }
                        else
                        {
                            ShowMessage("Failed to " + action + " data. Duplicate entry or an error occurred.", "Error");
                            return false;
                        }
                    }
                    else
                    {
                        ShowMessage("Unable to connect to the server. Please check your connection.", "Error");
                        return false;
                    }
                }
                else
                {
                    // User did not confirm, return false
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





        public DataTable Get_search_data(string searchText,string procedureName)
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@search_text_param", MySqlDbType.VarChar, 50);
            param[0].Value = searchText;

            if (OpenConnection())
            {
                dt = SelectData(procedureName, param);
                CloseConnection();
            }

            return dt;
        }

        public DataTable view_all(string procedureName)
        {
            DataTable dataTable = null;

            if (OpenConnection())
            {
                dataTable = SelectData(procedureName, null);
                sqlconnection.Close();
            }

            return dataTable;
        }

        public void BindDetailsSearch(DataGridView dgv, string searchText)
        {
            BindGrid(dgv, Get_search_data(searchText, "sp_room_Search"));

            if (dgv.Rows.Count >= 1)
            {
                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

    //    public void Fill_Combobox_Desplaymember_Valauemenber(string store_producer, ComboBox com, string id, string name)
    //    {
    //        com.DataSource = SelectData(store_producer, null);
    //        com.DisplayMember = name;
    //        com.ValueMember = id;
    //        com.Text = "";

    //    }

    //    public DataTable dt { get; set; }
    }
}
