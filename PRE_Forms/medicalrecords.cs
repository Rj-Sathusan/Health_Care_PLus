using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace Health_Care
{
    public partial class medicalrecords : KryptonForm
    {
        private int _recordID;
        DAL.function_ dalFunction = new DAL.function_();

        private BE_Classes.MedicalRecords _medicalRecordsClass;
        private BE_Classes.patient_details _patient_details;


        public medicalrecords()
        {
            InitializeComponent();
            BindMedicalRecords();
        }

        // Handle "Save" button click event
        private void save_btn_Click(object sender, EventArgs e)
        {
            // Validate input and perform CRUD operation (Save or Edit)
            if (ValidateInput())
            {
                // Prompt user for confirmation before performing save or edit action
                DialogResult result = MessageBox.Show("Are you sure you want to save?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BE_Classes.MedicalRecords newRecord = CreateMedicalRecordsInstance();
                    // Determine the action based on button text and execute the operation
                    bool action = save_btn.Text == "Save" ? newRecord.Save() : newRecord.Edit();

                    // Display success message or error
                    if (action)
                    {
                        MessageBox.Show("Completed successfully!", "Success");
                        RefreshForm();
                    }
                    else
                    {
                        MessageBox.Show("Error saving data.");
                    }
                }
            }
        }

        // Handle "Delete" button click event
        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt user for confirmation before performing delete action
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Perform deletion and display success or error message
                    BE_Classes.MedicalRecords newRecord = new BE_Classes.MedicalRecords(_recordID);
                    bool save = newRecord.Delete();
                    if (save)
                    {
                        MessageBox.Show("Deleted successfully!", "Success");
                        RefreshForm();
                    }
                    else
                    {
                        MessageBox.Show("Error saving data.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
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
            if (string.IsNullOrWhiteSpace(diagnosis_txt.Text))
            {
                MessageBox.Show("Please enter a valid diagnosis.", "Validation Error");
                diagnosis_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(prescription_txt.Text))
            {
                MessageBox.Show("Please enter a valid prescription.", "Validation Error");
                prescription_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(labResults_txt.Text))
            {
                MessageBox.Show("Please enter valid lab results.", "Validation Error");
                labResults_txt.Focus();
                return false;
            }
          
            return true;
        }

        // Create an instance of BE_Classes.MedicalRecords with current data
        private BE_Classes.MedicalRecords CreateMedicalRecordsInstance()
        {
            return new BE_Classes.MedicalRecords(_recordID, int.Parse(patientID_txt.Text), diagnosis_txt.Text, prescription_txt.Text, labResults_txt.Text);
        }

        // Refresh the form by clearing text boxes and updating DataGridView
        private void RefreshForm()
        {
            ClearTextBoxes(this);
            BindMedicalRecords();
            save_btn.Text = "Save";
        }

        // Clear text boxes recursively within a control
        private void ClearTextBoxes(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Clear();
                }
                else
                {
                    ClearTextBoxes(ctrl);
                }
            }
        }

        // Bind medical records to the DataGridView
        private void  BindMedicalRecords()
        {
            try
            {
                _medicalRecordsClass = new BE_Classes.MedicalRecords();
                _patient_details = new BE_Classes.patient_details();
                _patient_details.BindPatientDetails(grid_view2);
                _medicalRecordsClass.BindMedicalRecords(grid_view);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        // Handle DataGridView cell double-click event for editing
        private void grid_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Populate text boxes for editing based on selected row
                patientID_txt.Text = grid_view.Rows[e.RowIndex].Cells[1].Value.ToString();
                name_txt.Text = grid_view.Rows[e.RowIndex].Cells[2].Value.ToString();
                diagnosis_txt.Text = grid_view.Rows[e.RowIndex].Cells[4].Value.ToString();
                prescription_txt.Text = grid_view.Rows[e.RowIndex].Cells[5].Value.ToString();
                labResults_txt.Text = grid_view.Rows[e.RowIndex].Cells[6].Value.ToString();
                _recordID = Convert.ToInt32(grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());

                save_btn.Text = "Edit";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void patientID_txt_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view2, patient_nic_txt.Text);

        }

        private void grid_view2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            patientID_txt.Text = grid_view2.Rows[e.RowIndex].Cells[0].Value.ToString();
            name_txt.Text = grid_view2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
