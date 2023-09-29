using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace Health_Care.BE_Classes
{
    class ResourceDetails : DAL.NewDataAccessLayer
    {
        // Properties to store resource details
        private int id;
        private string resourceType;
        private string availability;

        // ID property with getter and setter
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        // ResourceType property with getter and setter
        public string ResourceType
        {
            get { return resourceType; }
            set { resourceType = value; }
        }

        // Availability property with getter and setter
        public string Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        // Database Logic - CRUD operations

        // Execute a resource-related database command
        private bool ExecuteResourceCommand(string procedureName, MySqlParameter[] parameters)
        {
            try
            {
                // Open database connection
                if (OpenConnection())
                {
                    // Execute command and handle result
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

        // Save resource details to the database
        public bool Save()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = id },
                new MySqlParameter("@resource_type_param", MySqlDbType.VarChar, 60) { Value = resourceType },
                new MySqlParameter("@availability_param", MySqlDbType.VarChar, 60) { Value = availability }
            };

            return ExecuteResourceCommand("sp_resource_Save", param);
        }

        // Edit existing resource details in the database
        public bool Edit()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = id },
                new MySqlParameter("@resource_type_param", MySqlDbType.VarChar, 60) { Value = resourceType },
                new MySqlParameter("@availability_param", MySqlDbType.VarChar, 60) { Value = availability }
            };

            return ExecuteResourceCommand("sp_resource_edit", param);
        }

        // Delete resource details from the database
        public bool Delete()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = id }
            };

            return ExecuteResourceCommand("sp_resource_delete", param);
        }

        // Retrieve resource details from the database
        public DataTable GetResource()
        {
            DataTable dataTable = null;

            if (OpenConnection())
            {
                dataTable = SelectData("sp_resource_SelectAll", null);
                sqlconnection.Close();
            }

            return dataTable;
        }

        // Bind resource details to a DataGridView
        public void BindResourceDetails(DataGridView dgv)
        {
            BindGrid(dgv, GetResource());
        }

        // Search for resource details by type in the database
        public DataTable GetResourceByType(string searchText)
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@searchText_param", MySqlDbType.VarChar, 50);
            param[0].Value = searchText;

            if (OpenConnection())
            {
                dt = SelectData("sp_resource_Search", param);
                CloseConnection();
            }

            return dt;
        }

        // Bind searched resource details to a DataGridView
        public void BindResourceDetailsSearch(DataGridView dgv, string searchText)
        {
            BindGrid(dgv, GetResourceByType(searchText));

            if (dgv.Rows.Count >= 1)
            {
                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

        // Constructors to initialize resource details
        public ResourceDetails(int resourceId)
        {
            id = resourceId;
        }

        public ResourceDetails(string Type)
        {
            resourceType = Type;
        }

        public ResourceDetails()
        {
        }

        public ResourceDetails(int resourceId, string type, string avail)
        {
            id = resourceId;
            resourceType = type;
            availability = avail;
        }
    }
}
