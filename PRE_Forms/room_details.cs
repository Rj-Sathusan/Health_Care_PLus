using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Health_Care.DAL;
using Health_Care.BE_Classes;

namespace Health_Care
{
    public partial class room_details : KryptonForm  
    {
        private int _id;
        private string Patient_id;
         DAL.function_ dalFunction = new DAL.function_();
        private BE_Classes.RoomDetails _roomClass = new BE_Classes.RoomDetails();

        public room_details(string recived_id = null)
        {
            InitializeComponent();
            BindRoomDetails();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            bool action = save_btn.Text == "Save" ? CreateRoomAndSaveOrEditOrDelete("save") : CreateRoomAndSaveOrEditOrDelete("edit");
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            CreateRoomAndSaveOrEditOrDelete("delete");
        }

        private void search_box_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view, search_box.Text);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void grid_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Control> controlsToUpdate = new List<Control> { type_txt, capacity_txt, availability_txt };
            // Call the function
            dalFunction.SetTextBoxesFromSelectedRow(grid_view, controlsToUpdate, ref _id);
            save_btn.Text = "Edit";
        }


        private bool ValidateInput()
        { 
            if (function_.IsNumeric(capacity_txt,"Capacity")) return false;
            if (function_.IsLettersOnly(type_txt,"Type")) return false;
            if (function_.IsLettersOnly(availability_txt, "Avilability")) return false;
            return true;
        }

        private bool CreateRoomAndSaveOrEditOrDelete(string actionType)
        {
            if (ValidateInput())
            {
                BE_Classes.RoomDetails newRoom = new BE_Classes.RoomDetails(_id, type_txt.Text, int.Parse(capacity_txt.Text), availability_txt.Text);
                bool action = newRoom.Save(actionType);
                if (action)
                {
                    RefreshForm();
                }
                return action;
            }
            else
            {
                return false;
            }
        }

        private void RefreshForm()
        {
            dalFunction.ClearTextBoxes(this);
            BindRoomDetails();
            save_btn.Text = "Save";
        }

        private void BindRoomDetails()
        {
           _roomClass.BindRoomDetails(grid_view);
        }
    
    }
}
