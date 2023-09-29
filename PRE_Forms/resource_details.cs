using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace Health_Care
{
    public partial class resource_details : KryptonForm
    {
        private int _id;
        private string Patient_id;
        private BE_Classes.ResourceDetails _resourceClass;

        // Initialize the form and populate DataGridView with resource details
        public resource_details(string recived_id=null)
        {
            InitializeComponent();
            Patient_id = recived_id;
            BindResourceDetails();
        }


        // Handle "Save" button click event
        private void save_btn_Click(object sender, EventArgs e)
        {
            // Validate input and perform CRUD operation (Save or Edit)
            if (ValidateInput())
            {
                // Prompt user for confirmation before performing save,edit action
                DialogResult result = MessageBox.Show("Are you sure you want to save?", "Confirm save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BE_Classes.ResourceDetails newUser = CreateResourceDetailsInstance();
                    // Determine the action based on button text and execute the operation
                    bool action = save_btn.Text == "Save" ? newUser.Save() : newUser.Edit();

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
                DialogResult result = MessageBox.Show("Are you sure you want to delete this resource?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Perform deletion and display success or error message
                    BE_Classes.ResourceDetails newUser = new BE_Classes.ResourceDetails(_id);
                    bool save = newUser.Delete();
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

        // Handle double-click on DataGridView rows for editing
        private void grid_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Populate text boxes for editing based on selected row
            resource_txt.Text = grid_view.Rows[e.RowIndex].Cells[1].Value.ToString();
            avilability_txt.Text = grid_view.Rows[e.RowIndex].Cells[2].Value.ToString();
            _id = Convert.ToInt32(grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());

            save_btn.Text = "Edit";
        }

        // Handle search box text change event
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            string searchText = search_box.Text;

            // Filter and display search results in DataGridView
            _resourceClass.BindResourceDetailsSearch(grid_view, searchText);
        }

        // Clear all text boxes and reset form state
        private void clear_btn_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        // Validate input data before performing CRUD operations
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(resource_txt.Text))
            {
                MessageBox.Show("Please enter a valid resource.", "Validation Error");
                resource_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(avilability_txt.Text))
            {
                MessageBox.Show("Please enter a valid AVILABILITY.", "Validation Error");
                avilability_txt.Focus();
                return false;
            }

            return true;
        }

        // Create an instance of BE_Classes.ResourceDetails with current data
        private BE_Classes.ResourceDetails CreateResourceDetailsInstance()
        {
            return new BE_Classes.ResourceDetails(_id, resource_txt.Text, avilability_txt.Text);
        }

        // Refresh the form by clearing text boxes and updating DataGridView
        private void RefreshForm()
        {
            ClearTextBoxes(this);
            _resourceClass.BindResourceDetails(grid_view);
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

        // Bind resource details to the DataGridView
        private void BindResourceDetails()
        {
            try
            {
                _resourceClass = new BE_Classes.ResourceDetails();
                _resourceClass.BindResourceDetails(grid_view);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        // ... Other methods related to form initialization, data management, etc. ...

    }
}
