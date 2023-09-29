using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace Health_Care.BE_Classes
{
    class MedicalRecords : DAL.NewDataAccessLayer
    {
        private int recordID;
        private int patientID;
        private string patientName;
        private string diagnosis;
        private string prescription;
        private string labResults;

        // Properties
        public int RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        public string Prescription
        {
            get { return prescription; }
            set { prescription = value; }
        }

        public string LabResults
        {
            get { return labResults; }
            set { labResults = value; }
        }

        // Save, Edit, Delete methods
        private bool ExecuteRecordCommand(string procedureName, MySqlParameter[] parameters)
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
                new MySqlParameter("@patientID_param", MySqlDbType.Int32) { Value = patientID },
                new MySqlParameter("@diagnosis_param", MySqlDbType.Text) { Value = diagnosis },
                new MySqlParameter("@prescription_param", MySqlDbType.Text) { Value = prescription },
                new MySqlParameter("@labResults_param", MySqlDbType.Text) { Value = labResults }
            };

            return ExecuteRecordCommand("sp_records_Save", param);
        }

        public bool Edit()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@recordID_param", MySqlDbType.Int32) { Value = recordID },
                new MySqlParameter("@patientID_param", MySqlDbType.Int32) { Value = patientID },
                new MySqlParameter("@diagnosis_param", MySqlDbType.Text) { Value = diagnosis },
                new MySqlParameter("@prescription_param", MySqlDbType.Text) { Value = prescription },
                new MySqlParameter("@labResults_param", MySqlDbType.Text) { Value = labResults }
            };

            return ExecuteRecordCommand("sp_records_Edit", param);
        }

        public bool Delete()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@recordID_param", MySqlDbType.Int32) { Value = recordID }
            };

            return ExecuteRecordCommand("sp_records_Delete", param);
        }

       
        
        // Constructors
        public MedicalRecords()
        {
            // Default constructor
        }

        public MedicalRecords(int recordID)
        {
            this.recordID = recordID;
        }

        public MedicalRecords(int patientID, string diagnosis, string prescription, string labResults)
        {
            this.patientID = patientID;
            this.diagnosis = diagnosis;
            this.prescription = prescription;
            this.labResults = labResults;
        }

        public MedicalRecords(int recordID, int patientID, string diagnosis, string prescription, string labResults)
        {
            this.recordID = recordID;
            this.patientID = patientID;
            this.diagnosis = diagnosis;
            this.prescription = prescription;
            this.labResults = labResults;
        }

        // Methods
        public void BindMedicalRecords(DataGridView dgv)
        {
            BindGrid(dgv, GetMedicalRecords());
        }

       

      
        public DataTable GetRecordsBypatientName(string patientName)
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@patientName_param", MySqlDbType.Text);
            param[0].Value = patientName;

            if (OpenConnection())
            {
                dt = SelectData("sp_medical_records_SelectAllWithPatientNameAndSearch", param);
                CloseConnection();
            }

            return dt;
        }

        // Retrieve all records
        public DataTable GetMedicalRecords()
        {
            DataTable dataTable = null;

            if (OpenConnection())
            {
                dataTable = SelectData("sp_medical_records_SelectAllWithPatientName", null);
                CloseConnection();
            }

            return dataTable;
        }

        // Bind searched resource details to a DataGridView
        public void SearchRecordsByPatientID(DataGridView dgv, string searchText)
        {
            BindGrid(dgv, GetRecordsBypatientName(searchText));

            if (dgv.Rows.Count >= 1)
            {
                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

    }
}
