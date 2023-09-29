using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using Health_Care.DAL;
using Health_Care.BE_Classes;

namespace Health_Care
{
    public partial class payment : KryptonForm
    {
        private int _id;
        private string name;
        DAL.function_ dalFunction = new DAL.function_();
        private BE_Classes.payment _pay  = new BE_Classes.payment();

        public payment(string PID=null)
        {
            InitializeComponent();
            PID_lbl.Text = PID;
            BindPaymentDetails();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (function_.IsNumeric(amount_txt, "Amount")) { }
            else
            {
                DateTime currentDate = DateTime.Now;

                BE_Classes.payment pay = new BE_Classes.payment(int.Parse(PID_lbl.Text), decimal.Parse(amount_txt.Text), currentDate);
                bool action = pay.Save();
                if (action)
                {
                    RefreshForm();
                }
            }
        }

      
        
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view, search_box.Text);

        }

        private void RefreshForm()
        {
            dalFunction.ClearTextBoxes(this);
            BindPaymentDetails();
        }

        private void BindPaymentDetails()
        {
            _pay.BindPaymentDetails(grid_view);
        }

  

        
    }
}
