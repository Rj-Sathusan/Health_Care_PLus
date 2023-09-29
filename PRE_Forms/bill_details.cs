using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Health_Care.DAL;
using Health_Care.BE_Classes;

namespace Health_Care
{
    public partial class bill_details : KryptonForm  
    {
        DAL.function_ dalFunction = new DAL.function_();
        private BE_Classes.Bill _bill = new BE_Classes.Bill();

        public bill_details()
        {
            InitializeComponent();
            BindBillDetails();
        }

     
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            dalFunction.SearchGridView(grid_view, search_box.Text);
        }

        private void BindBillDetails()
        {
            _bill.BindBillDetails2(grid_view);
        }
    
    }
}
