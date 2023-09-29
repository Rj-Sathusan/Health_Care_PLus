using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Health_Care.BE_Classes
{
    class payment:DAL.NewDataAccessLayer
    {
        private int PatientID { get; set; }
        private decimal Amount { get; set; }
        private DateTime Date { get; set; }

        DAL.function_ func;

        public payment()
        {
        }

        public payment(int patientID, decimal amount, DateTime date)
        {
            PatientID = patientID;
            Amount = amount;
            Date = date;

           
        }

        public bool Save()
        {
            MySqlParameter[] param = {
                new MySqlParameter("@PatientID_param", MySqlDbType.Int32) { Value = PatientID },
                new MySqlParameter("@Amount_param", MySqlDbType.Decimal) { Value = Amount },
                new MySqlParameter("@Date_param", MySqlDbType.Date) { Value = Date }
            };
           
             return run_procedure("sp_payment_Save", "save", param);
        }

        public void BindPaymentDetails(DataGridView dgv = null)
        {
            try
            {
                DataTable dt = view_all("sp_payment_SelectAll");
                BindGrid(dgv, dt);
            }
            catch { }
        }

        public DataTable total_amount()
        {
            return ExecuteStoredProcedure("GetTotalPaymentsToday");
        }

        public DataTable GetTotalPaymentsByDate()
        {
            return ExecuteStoredProcedure("GetPaymentDataByDate");
        }

    }
}
