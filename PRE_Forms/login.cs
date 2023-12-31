﻿using ComponentFactory.Krypton.Toolkit;
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
    
    public partial class login : KryptonForm
    {
        BE_Classes.sign_up _signup;
        
        public login()
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
            this.Hide();

            // Instantiate the sign_up form and then show it
            sign_up signUpForm = new sign_up();
            signUpForm.Show();
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

            return true;
        }


        //public bool send_to_save

        private void sign_up_click(object sender, EventArgs e)
        {
            try{
                if (ValidateInput())
                {
                    var role = "";
                    _signup = new BE_Classes.sign_up(user_name_txt.Text,pass_txt.Text);
                    _signup.Login(out role);

                    if (!string.IsNullOrEmpty(role))
                    {
                        // The 'role' variable now contains the user's role.
                        MessageBox.Show("Welcome \n Role : " + role);
                        medicalrecords doctor_form = new medicalrecords();
                        phramecy_medicalrecords phrmacy_form = new phramecy_medicalrecords();
                        main_page main_page = new main_page(role);
                        staff_details_for_staffs for_staff = new staff_details_for_staffs();

                       // staff_details staff_form = staff_details();
                        if (role == "Admin")
                            main_page.Show();
                        else if (role == "Doctor")
                            doctor_form.Show();
                        else
                            for_staff.Show();
                        
                       // main_page.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

      
    }
}
