using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace Health_Care
{
    public partial class staff_details : KryptonForm
    {
        private int _id;
        private BE_Classes.StaffDetails _staffClass;

        public staff_details(string role=null)
        {
            InitializeComponent();
            BindStaffDetails();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult result = MessageBox.Show("Are you sure you want to save?", "Confirm save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BE_Classes.StaffDetails newStaff = CreateStaffDetailsInstance();
                    bool action = save_btn.Text == "Save" ? newStaff.Save() : newStaff.Edit();

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

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BE_Classes.StaffDetails newStaff = new BE_Classes.StaffDetails(_id);
                    bool save = newStaff.Delete();
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

        private void search_box_TextChanged(object sender, EventArgs e)
        {
            string searchText = search_box.Text;
            _staffClass.BindStaffDetailsSearch(grid_view, searchText);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(name_txt.Text))
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error");
                name_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(username_txt.Text))
            {
                MessageBox.Show("Please enter a valid username.", "Validation Error");
                username_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(password_txt.Text))
            {
                MessageBox.Show("Please enter a valid password.", "Validation Error");
                password_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(role_txt.Text))
            {
                MessageBox.Show("Please enter a valid role.", "Validation Error");
                role_txt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(task_txt.Text))
            {
                MessageBox.Show("Please enter valid today's task.", "Validation Error");
                task_txt.Focus();
                return false;
            }

            return true;
        }

        private BE_Classes.StaffDetails CreateStaffDetailsInstance()
        {
            return new BE_Classes.StaffDetails(_id,name_txt.Text, username_txt.Text, password_txt.Text, role_txt.Text, task_txt.Text);
        }

        private void RefreshForm()
        {
            ClearTextBoxes(this);
            BindStaffDetails();
            save_btn.Text = "Save";
        }

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

        private void BindStaffDetails()
        {
            try
            {
                _staffClass = new BE_Classes.StaffDetails();
                _staffClass.BindStaffDetails(grid_view);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void grid_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                name_txt.Text = grid_view.Rows[e.RowIndex].Cells[1].Value.ToString();
                username_txt.Text = grid_view.Rows[e.RowIndex].Cells[2].Value.ToString();
                password_txt.Text = grid_view.Rows[e.RowIndex].Cells[3].Value.ToString();
                role_txt.Text = grid_view.Rows[e.RowIndex].Cells[4].Value.ToString();
                task_txt.Text = grid_view.Rows[e.RowIndex].Cells[5].Value.ToString();
                _id = Convert.ToInt32(grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());

                save_btn.Text = "Edit";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }
    }
}
