using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;


namespace Health_Care.BE_Classes
{
    class patient_details: DAL.NewDataAccessLayer
    {
          DAL.function_ func;
        private int patientID { get; set; }
        private string name { get; set; }
        private string gender { get; set; }
        private int age { get; set; }
        private string contactDetails { get; set; }
        private string nic { get; set; }
        private string medicalHistory { get; set; }

        public bool Save(string action)
        {
            try
            {
                // Define MySQL parameters
                MySqlParameter[] param = {
                    new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = patientID },
                    new MySqlParameter("@name_param", MySqlDbType.VarChar, 100) { Value = name },
                    new MySqlParameter("@gender_param", MySqlDbType.VarChar, 10) { Value = gender },
                    new MySqlParameter("@age_param", MySqlDbType.Int32) { Value = age },
                    new MySqlParameter("@contact_details_param", MySqlDbType.VarChar, 255) { Value = contactDetails },
                    new MySqlParameter("@nic_param", MySqlDbType.VarChar, 20) { Value = nic },
                    new MySqlParameter("@medical_history_param", MySqlDbType.VarChar, 500) { Value = medicalHistory }
                };

                switch (action)
                {
                    case "save":
                        return run_procedure("sp_patient_Save", action, param);
                    case "edit":
                        return run_procedure("sp_patient_Update", action, param);
                    case "delete":
                        return run_procedure("sp_patient_Delete", action, param);
                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void BindPatientDetails(DataGridView dgv)
        {
            try
            {

                BindGrid(dgv, view_all("sp_patient_SelectAll"));
            }
        catch { }
        }

       
          public void BindPatientDetailsSearch(DataGridView dgv, string searchText)
        {
            try
            {
                BindGrid(dgv, Get_search_data(searchText, "sp_patient_Search"));
            }
            catch
            {
            }
        }

        public patient_details(){}

        public patient_details(int pID, string pName, string pGender, int pAge, string pContact, string pNIC)
        {
            patientID = pID;
            name = pName;
            gender = pGender;
            age = pAge;
            contactDetails = pContact;
            nic = pNIC;
        }

     

    }
}
