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
    class RoomDetails : DAL.NewDataAccessLayer
    {
        DAL.function_ func;
        private int id{ get; set; }
        private string type{ get; set; }
        private int capacity { get; set; }
        private string availability { get; set; }


        public bool Save(string action)
        {

            MySqlParameter[] param = {
                new MySqlParameter("@id_param", MySqlDbType.Int32) { Value = id },
                new MySqlParameter("@room_type_param", MySqlDbType.VarChar, 50) { Value = type },
                new MySqlParameter("@capacity_param", MySqlDbType.Int32) { Value = capacity },
                new MySqlParameter("@availability_param", MySqlDbType.VarChar, 255) { Value = availability }
            };
            switch (action)
            {
                case "save":
                    {
                        return run_procedure("sp_room_Save", action, param);
                    }
                case "edit":
                    {
                        return run_procedure("sp_room_edit", action, param);
                    }

                case "delete":
                    {
                        return run_procedure("sp_room_delete", action, param);
                    }
                default:
                    return false;
             }
        }
   
        public void BindRoomDetails(DataGridView dgv=null)
        {
            try
            {
                BindGrid(dgv, view_all("sp_room_SelectAll"));
            }
        catch { }
        }
      
        public RoomDetails(){}

        public RoomDetails(int roomId, string roomType, int roomCapacity, string roomAvailability)
        {
            id = roomId;
            type = roomType;
            capacity = roomCapacity;
            availability = roomAvailability;
        }
    }
}
