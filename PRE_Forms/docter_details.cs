using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Health_Care.DAL;
using Health_Care.BE_Classes;

namespace Health_Care
{

    public partial class docter_details : KryptonForm
    {
        private int _id;
        private BE_Classes.DoctorDetails _doctorClass;
        DAL.function_ dalFunction = new DAL.function_();

        public docter_details()
        {
            InitializeComponent();
            BindDoctorDetails();

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult result = MessageBox.Show("Are you sure you want to save?", "Confirm save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BE_Classes.DoctorDetails newDoctor = CreateDoctorDetailsInstance();
                    bool action = save_btn.Text == "Save" ? newDoctor.Save() : newDoctor.Edit();

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
                DialogResult result = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BE_Classes.DoctorDetails newDoctor = new BE_Classes.DoctorDetails(_id);
                    bool save = newDoctor.Delete();
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
            try
            {
                string searchText = search_box.Text;
                _doctorClass.BindDoctorDetailsSearch(grid_view, searchText);
            }
            catch { }
            
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private bool ValidateInput()
        {
            if (function_.IsLettersOnly(name_txt, "Name")) return false;
            if (function_.IsNotNullOrEmpty(specialization_txt, "specialization")) return false;
            if (function_.IsNotNullOrEmpty(availability_txt, "availability")) return false;
            if (function_.IsNumeric(contactDetails_txt, "contact")) return false;
            return true;
   
            
        }

        private BE_Classes.DoctorDetails CreateDoctorDetailsInstance()
        {
            return new BE_Classes.DoctorDetails(_id, name_txt.Text, specialization_txt.Text, availability_txt.Text, contactDetails_txt.Text);
        }

        private void RefreshForm()
        {
            ClearTextBoxes(this);
            BindDoctorDetails();
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

        private void BindDoctorDetails()
        {
            try
            {
                _doctorClass = new BE_Classes.DoctorDetails();
                _doctorClass.BindDoctorDetails(grid_view);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        private void gridview_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                name_txt.Text = grid_view.Rows[e.RowIndex].Cells[1].Value.ToString();
                specialization_txt.Text = grid_view.Rows[e.RowIndex].Cells[2].Value.ToString();
                availability_txt.Text = grid_view.Rows[e.RowIndex].Cells[3].Value.ToString();
                contactDetails_txt.Text = grid_view.Rows[e.RowIndex].Cells[4].Value.ToString();
                _id = Convert.ToInt32(grid_view.Rows[e.RowIndex].Cells[0].Value.ToString());

                save_btn.Text = "Edit";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        




        //public bool send_to_save

    }
}
