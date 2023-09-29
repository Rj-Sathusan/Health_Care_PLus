using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace Health_Care
{
    public partial class staff_details_for_staffs : KryptonForm
    {
        private int _id;
        private BE_Classes.StaffDetails _staffClass;

        public staff_details_for_staffs()
        {
            InitializeComponent();
            BindStaffDetails();
        }

       
      

        private void search_box_TextChanged(object sender, EventArgs e)
        {
            string searchText = search_box.Text;
            _staffClass.BindStaffDetailsSearch(grid_view, searchText);
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

     
    }
}
