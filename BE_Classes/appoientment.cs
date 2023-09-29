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
    class appoientment : DAL.NewDataAccessLayer
    {
        
         private int id { get; set; }
        private int doctorAvailabilityId { get; set; }
        private int patientId { get; set; }
        private DateTime date { get; set; }
        private string status { get; set; }
        private int? roomId { get; set; }
        private int? resourceId { get; set; }

        public bool Save(string action)
        {
            MySqlParameter[] param = {
                new MySqlParameter("@appointment_id_param", MySqlDbType.Int32) { Value = id },
                new MySqlParameter("@doctor_availability_id_param", MySqlDbType.Int32) { Value = doctorAvailabilityId },
                new MySqlParameter("@patient_id_param", MySqlDbType.Int32) { Value = patientId },
                new MySqlParameter("@date_param", MySqlDbType.Date) { Value = date },
                new MySqlParameter("@status_param", MySqlDbType.VarChar, 20) { Value = status },
                new MySqlParameter("@room_id_param", MySqlDbType.Int32) { Value = roomId },
                new MySqlParameter("@resource_id_param", MySqlDbType.Int32) { Value = resourceId }
            };

            switch (action)
            {
                case "save":
                    {
                        return run_procedure("sp_appointment_Save", action, param);
                    }
                case "edit":
                    {
                        return run_procedure("sp_appointment_Edit", action, param);
                    }

                case "delete":
                    {
                        return run_procedure("sp_appointment_Delete", action, param);
                    }
                default:
                    return false;
            }
        }

        //public void BindAppointmentDetails(DataGridView dgv = null)
        //{
        //    try
        //    {
        //        BindGrid(dgv, view_all("sp_appointment_SelectAll"));
        //    }
        //    catch { }
        //}

        public appoientment() { }

        public appoientment(int appointmentId, int doctorAvailablilityId, int patientId, DateTime appointmentDate, string appointmentStatus, int? room, int? resource)
        {
            id = appointmentId;
            doctorAvailabilityId = doctorAvailablilityId;
            this.patientId = patientId;
            date = appointmentDate;
            status = appointmentStatus;
            roomId = room;
            resourceId = resource;
        }

        public void BindAppointmentDetails(DataGridView dgv)
        {
            try
             {

                BindGrid(dgv, view_all("GetAppointmentsWithDetails"));
            }
            catch { }
        }

        public DataTable combo_room()
        {
            return ExecuteStoredProcedure("sp_room_SelectAll");
        }

        public DataTable combo_roesource()
        {
            return ExecuteStoredProcedure("sp_resource_SelectAll");
        }

        }

    }


