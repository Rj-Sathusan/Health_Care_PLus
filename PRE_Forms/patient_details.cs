using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using Health_Care.DAL;
using Health_Care.BE_Classes;

namespace Health_Care
{
    public partial class patient_details : KryptonForm
    {
        private int _id;
        private string name;
        DAL.function_ dalFunction = new DAL.function_();
        private BE_Classes.patient_details p_details  = new BE_Classes.patient_details();

        public patient_details()
        {
            InitializeComponent();
            BindPatientDetails();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            bool action = save_btn.Text == "Save" ? CreatePatientAndSaveOrEditOrDelete("save") : CreatePatientAndSaveOrEditOrDelete("edit");

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            CreatePatientAndSaveOrEditOrDelete("delete");
        }
        private bool CreatePatientAndSaveOrEditOrDelete(string actionType)
        {
            if (ValidateInput())
            {
                BE_Classes.patient_details newPatient = new BE_Classes.patient_details(_id, name_txt.Text, gender_txt.Text, int.Parse(age_txt.Text), contact_txt.Text, nic_txt.Text);
                bool action = newPatient.Save(actionType);
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
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view, search_box.Text);

        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private bool ValidateInput()
        {

            if (function_.IsLettersOnly(name_txt, "Name")) return false;
            if (function_.IsNumeric(age_txt, "Age")) return false;
            if (function_.IsNumeric(contact_txt, "Contact")) return false;
            if (function_.IsNotNullOrEmpty(nic_txt, "Nic")) return false;
            return true;
        }


        private void RefreshForm()
        {
            dalFunction.ClearTextBoxes(this);
            BindPatientDetails();
            save_btn.Text = "Save";
        }

        private void BindPatientDetails()
        {
            p_details.BindPatientDetails(grid_view);
        }


       

        private void grid_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                name_txt.Text = grid_view.Rows[e.RowIndex].Cells[1].Value.ToString();
                gender_txt.Text = grid_view.Rows[e.RowIndex].Cells[2].Value.ToString();
                age_txt.Text = grid_view.Rows[e.RowIndex].Cells[3].Value.ToString();
                contact_txt.Text = grid_view.Rows[e.RowIndex].Cells[4].Value.ToString();
                nic_txt.Text = grid_view.Rows[e.RowIndex].Cells[5].Value.ToString();
                _id = Convert.ToInt32(grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());

                save_btn.Text = "Edit";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void appoientment_Click(object sender, EventArgs e)
        {
            appointments appointmentForm = new appointments(Convert.ToString(_id));
            appointmentForm.Show();

        }

        
    }
}
