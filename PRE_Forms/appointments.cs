using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Health_Care
{
    public partial class appointments : KryptonForm
    {
        private int? roomID;
        private int _id;

        private int? resourceID;
        private int Docid;
        private string  Pid;
        
        DAL.function_ dalFunction = new DAL.function_();
        private BE_Classes.Bill _billing;
        private BE_Classes.DoctorDetails _DocClass = new BE_Classes.DoctorDetails();
        private BE_Classes.appoientment appointment_details = new BE_Classes.appoientment();
        private BE_Classes.patient_details p_details = new BE_Classes.patient_details();



        public appointments(string PaID = null)
        {
            InitializeComponent();
            PID_lbl.Text = PaID; // Assign the value of PaID to the PID_lbl
            resource_room_combo_bind();
            BindAppointmentDetails();
        }


        // Handle "Save" button click event
        private void save_btn_Click(object sender, EventArgs e)
        {
          bool action = save_btn.Text == "Save" ? CreateAppointmentAndSaveOrEditOrDelete("save") : CreateAppointmentAndSaveOrEditOrDelete("edit");
        }


        private bool CreateAppointmentAndSaveOrEditOrDelete(string actionType)
        {
            if (ValidateInput())
            {
                BE_Classes.appoientment newAppointment = new BE_Classes.appoientment(_id, int.Parse(DID_lbl.Text), int.Parse(PID_lbl.Text), A_date.Value, statues_combo.Text, roomID, resourceID);
                bool action = newAppointment.Save(actionType);
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

       

        // Handle search box text change event
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view, search_box.Text);
        }

        // Handle clear button click event
        private void clear_btn_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        // Validate input data before performing CRUD operations
        private bool ValidateInput()
        {
            //if (function_.IsDateValid(date_picker, "Date")) return false;
            //if (function_.IsLettersOnly(statues_combo, "Status")) return false;
            //if (function_.IsNumeric(roomId_txt, "Room ID")) return false;
            //if (function_.IsNumeric(resourceId_txt, "Resource ID")) return false;
            return true;
        }

        
        // Refresh the form by clearing text boxes and updating DataGridView
        private void RefreshForm()
        {
            dalFunction.ClearTextBoxes(this);
            BindAppointmentDetails();
            save_btn.Text = "Save";
        }

        private void BindAppointmentDetails()
        {
            appointment_details.BindAppointmentDetails(grid_view);
            _DocClass.BindDoctoravilable(grid_view2);

        }
    
        // Handle DataGridView cell double-click event for editing
        private void grid_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
              

                save_btn.Text = "Edit";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

       
        public void resource_room_combo_bind()
        {
            try
            {
                //  BE_Classes.patient_details room = new BE_Classes.patient_details();
                this.room_com.DataSource = appointment_details.combo_room();
                this.room_com.ValueMember = "RoomID";
                this.room_com.DisplayMember = "Type";

                this.resource_com.DataSource = appointment_details.combo_roesource();
                this.resource_com.ValueMember = "ResourceID";
                this.resource_com.DisplayMember = "ResourceType";

            }
            catch
            { }
        }

        private void Enable_room_CheckedChanged(object sender, EventArgs e)
        {
            room_com.Enabled = Enable_room.Checked;
            if (Enable_room.Checked && room_com.SelectedValue != null)
            {
                roomID = Convert.ToInt32(room_com.SelectedValue);
            }
            else
            {
                roomID = null;
            }
           
        }

        private void Enable_resource_CheckedChanged(object sender, EventArgs e)
        {
            resource_com.Enabled = Enable_resource.Checked;
            if (Enable_resource.Checked && room_com.SelectedValue != null)
            {
                resourceID = Convert.ToInt32(resource_com.SelectedValue);
            }
            else
            {
                resourceID = null;
            }
        }

        private void grid_view2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Docid = Convert.ToInt32(grid_view2.Rows[e.RowIndex].Cells[0].Value.ToString());
        //    Dname_lbl.Text = grid_view2.Rows[e.RowIndex].Cells[2].Value.ToString();
            DID_lbl.Text = grid_view2.Rows[e.RowIndex].Cells[0].Value.ToString();
          //  PID_lbl.Text = grid_view2.Rows[e.RowIndex].Cells[2].Value.ToString();
           // Dname_txt.Text = grid_view2.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void Searct_txt_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view2, Searct_txt.Text);

        }

  

        private void grid_view_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //resource_com.Text = grid_view.Rows[e.RowIndex].Cells[7].Value.ToString();
            //room_com.Text = grid_view.Rows[e.RowIndex].Cells[6].Value.ToString();
            List<Control> controlsToUpdate = new List<Control> { DID_lbl, PID_lbl,Pname_lbl,A_date,statues_combo,room_com,resource_com};
            dalFunction.SetTextBoxesFromSelectedRow(grid_view, controlsToUpdate, ref _id);
            save_btn.Text = "Edit";
        }

        private void ADD_Appoientment_Click(object sender, EventArgs e)
        {
            payment paymentForm = new payment(PID_lbl.Text);
            paymentForm.Show();


        }

        private void room_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                roomID = Convert.ToInt32(room_com.SelectedValue);
            }
            catch { }
        }

        private void resource_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            resourceID = Convert.ToInt32(resource_com.SelectedValue);
             }
            catch { }
        }

        private void billing_Click(object sender, EventArgs e)
        {
            BE_Classes.Bill _bill = new BE_Classes.Bill();
            _bill.GetBillingDetails(int.Parse(PID_lbl.Text));
        }


     
    }
}
