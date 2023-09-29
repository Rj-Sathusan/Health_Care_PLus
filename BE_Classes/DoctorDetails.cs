using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace Health_Care.BE_Classes
{
    class DoctorDetails : DAL.NewDataAccessLayer
    {
        private int doctorID;
        private string name;
        private string specialization;
        private string availability;
        private string contactDetails;

        // Properties
        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public string Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public string ContactDetails
        {
            get { return contactDetails; }
            set { contactDetails = value; }
        }

        // Save, Edit, Delete methods
        private bool ExecuteDoctorCommand(string procedureName, MySqlParameter[] parameters)
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
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = doctorID },
                new MySqlParameter("@name_param", MySqlDbType.VarChar, 255) { Value = name },
                new MySqlParameter("@specialization_param", MySqlDbType.VarChar, 255) { Value = specialization },
                new MySqlParameter("@availability_param", MySqlDbType.VarChar, 255) { Value = availability },
                new MySqlParameter("@contact_details_param", MySqlDbType.VarChar, 255) { Value = contactDetails }
            };

            return ExecuteDoctorCommand("sp_doctor_Save", param);
        }

        public bool Edit()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = doctorID },
                new MySqlParameter("@name_param", MySqlDbType.VarChar, 255) { Value = name },
                new MySqlParameter("@specialization_param", MySqlDbType.VarChar, 255) { Value = specialization },
                new MySqlParameter("@availability_param", MySqlDbType.VarChar, 255) { Value = availability },
                new MySqlParameter("@contact_details_param", MySqlDbType.VarChar, 255) { Value = contactDetails }
            };

            return ExecuteDoctorCommand("sp_doctor_edit", param);
        }

        public bool Delete()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = doctorID }
            };

            return ExecuteDoctorCommand("sp_doctor_delete", param);
        }

        public void BindDoctoravilable(DataGridView dgv)
        {
            try
            {

                BindGrid(dgv, view_all("sp_getDoctorAvailability"));
            }
            catch { }
        }
        // Retrieve doctor details
        public DataTable GetDoctors()
        {
            DataTable dataTable = null;

            if (OpenConnection())
            {
                dataTable = SelectData("sp_doctor_SelectAll", null);
                sqlconnection.Close();
            }

            return dataTable;
        }

        public void BindDoctorDetails(DataGridView dgv)
        {
            BindGrid(dgv, GetDoctors());
        }

        public DataTable GetDoctorsBySpecialization(string searchText)
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@searchText_param", MySqlDbType.VarChar, 255);
            param[0].Value = searchText;

            if (OpenConnection())
            {
                dt = SelectData("sp_doctor_Search", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindDoctorDetailsSearch(DataGridView dgv, string searchText)
        {
            BindGrid(dgv, GetDoctorsBySpecialization(searchText));

            if (dgv.Rows.Count >= 1)
            {
                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

        public DoctorDetails(int doctorID)
        {
            this.doctorID = doctorID;
        }

        public DoctorDetails(string specialization)
        {
            this.specialization = specialization;
        }

        public DoctorDetails()
        {
        }

        // Constructor
        public DoctorDetails(int doctorID, string name, string specialization, string availability, string contactDetails)
        {
            this.doctorID = doctorID;
            this.name = name;
            this.specialization = specialization;
            this.availability = availability;
            this.contactDetails = contactDetails;
        }
    }
}
