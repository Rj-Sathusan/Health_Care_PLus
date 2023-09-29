using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace Health_Care
{
    public partial class phramecy_medicalrecords : KryptonForm
    {
        DAL.function_ dalFunction = new DAL.function_();

        private BE_Classes.MedicalRecords _medicalRecordsClass;


        public phramecy_medicalrecords()
        {
            InitializeComponent();
            BindMedicalRecords();
        }

     

        // Handle search box text change event
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view, search_box.Text);

        }
        // Bind medical records to the DataGridView
        private void  BindMedicalRecords()
        {
            try
            {
                _medicalRecordsClass = new BE_Classes.MedicalRecords();
                _medicalRecordsClass.BindMedicalRecords(grid_view);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

     

       

      
    }
}
