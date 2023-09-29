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

namespace Health_Care
{
    
    public partial class sign_up : KryptonForm
    {
        BE_Classes.sign_up signup;

        public sign_up()
        {
            InitializeComponent();
        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }


        public bool ValidateInput()
        {
            // Validate username
            if (string.IsNullOrWhiteSpace(user_name_txt.Text))
            {
                MessageBox.Show("Please enter a valid username.", "Validation Error");
                user_name_txt.Focus();
                return false;
            }

            // Validate name
            if (string.IsNullOrWhiteSpace(name_txt.Text) || !Regex.IsMatch(name_txt.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter your name. Only letters are allowed.", "Invalid Name");
                name_txt.Focus();
                return false;
            }

            // Validate NIC
            if (string.IsNullOrWhiteSpace(nic_txt.Text))
            {
                MessageBox.Show("Please enter a valid NIC (e.g., 123456789V)", "Invalid NIC");
                nic_txt.Focus();
                return false;
            }

            return true;
        }


        //public bool send_to_save

        private void sign_up_click(object sender, EventArgs e)
        {
            try{
                if (ValidateInput())
                {
                  //  BE_Classes.sign_up newUser = new BE_Classes.sign_up(0, user_name_txt.Text, name_txt.Text, nic_txt.Text, gender_txt.Text, role_txt.Text);
                  //  bool save = newUser.Save();

                    //if (save)
                    //{
                    //    MessageBox.Show("Registration completed successfully!", "Success");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error saving data.");
                    //}
                    // try
                    //{
                    //    this.idtxt.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //    this.user_nametxt.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //    this.nametxt.Text=dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    //    this.nictxt.Text=dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //    this.gendertxt.Text=dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    //    this.roletxt.Text=dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

      
    }
}
