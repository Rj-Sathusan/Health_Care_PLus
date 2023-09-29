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
using System.Windows.Forms.DataVisualization.Charting; // Add this namespace for charting

namespace Health_Care
{
    
    public partial class main_page : KryptonForm
    {
        private string role;
        BE_Classes.sign_up signup;
        BE_Classes.payment _pay;

        public main_page(string role=null)
        {
            InitializeComponent();
            privileged(role);
        }

        public void privileged(string Role)
        {
            role = Role;
            if (role != "Admin")
            {
                pay_btn.Hide();
                resorce_btn.Hide();
                if (role != "Doctor")
                {
                    d_btn.Hide();
                    //patient_btn.Hide();
                }
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateChart(chart1, SeriesChartType.Area);
            CreateChart(chart2, SeriesChartType.Pie);
            // Initialize the _pay object
            _pay = new BE_Classes.payment();
            DataTable amountTable = _pay.total_amount();
            try
            {
                if (amountTable.Rows.Count > 0)
                {
                    decimal totalAmount = Convert.ToDecimal(amountTable.Rows[0]["TotalAmount"]);
                    total_lbl.Text = "Rs." + totalAmount.ToString("0.00");
                }
                else
                {
                    label1.Text = "Rs.00";
                }
            }
            catch {  }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void sign_up_click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(ItemPanel);

        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Instantiate the sign_up form and then show it
            login signUpForm = new login();
            signUpForm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
       //     showSubMenu(Categorypanel);

        }

        private void button6_Click(object sender, EventArgs e)
        {
        //    showSubMenu(Categorypanel);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showSubMenu(ItemPanel);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            showSubMenu(p_panel);

        }

        private void staff_details_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new staff_details(role));

        }
        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void patient_details_Click(object sender, EventArgs e)
        {
            openChildForm(new patient_details());

        }

        private void appoienment_Click(object sender, EventArgs e)
        {
            openChildForm(new appointments());

        }

        private void medi_Click(object sender, EventArgs e)
        {
            openChildForm(new medicalrecords());

        }

        private void D_details_Click(object sender, EventArgs e)
        {
            openChildForm(new docter_details());

        }

        private void D_avilable_Click(object sender, EventArgs e)
        {
            openChildForm(new staff_details(role));

        }

        private void patient_book_Click(object sender, EventArgs e)
        {
            openChildForm(new staff_details(role));

        }

        private void payment_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new payment());

        }

        private void price_btn_Click(object sender, EventArgs e)
        {

        }

        private void bill_btn_Click(object sender, EventArgs e)
        {

        }

        private void resource_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new resource_details());

        }

        private void room_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new room_details());

        }

        private void resorce_btn_Click(object sender, EventArgs e)
        {
            showSubMenu(ItemPanel);

        }

        private void pay_btn_Click(object sender, EventArgs e)
        {
            showSubMenu(pay_panel);

        }

        private void d_btn_Click(object sender, EventArgs e)
        {
            showSubMenu(d_panel);

        }

        private void patient_btn_Click(object sender, EventArgs e)
        {
            showSubMenu(p_panel);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            login signUpForm = new login();
            signUpForm.Show();
            this.Hide();
        }

        private void CreateChart(Chart chart, SeriesChartType chartType)
        {
            _pay = new BE_Classes.payment();

            DataTable paymentData = _pay.GetTotalPaymentsByDate();

            if (paymentData != null && paymentData.Rows.Count > 0)
            {
                chart.Series.Clear();
                chart.ChartAreas.Clear();
                chart.Titles.Clear();

                // Create a new chart area
                ChartArea chartArea = new ChartArea();
                chart.ChartAreas.Add(chartArea);

                // Create a new series for the chart
                Series series = new Series();
                series.ChartType = chartType;
                series.BorderWidth = 2; // Adjust line thickness if needed

                // Set the data source for the series
                series.Points.DataBind(paymentData.DefaultView, "Date", "TotalAmount", null);

                // Add the series to the chart
                chart.Series.Add(series);

                // Set chart title
                Title chartTitle = new Title("Revenue Overview Chart");
                chart.Titles.Add(chartTitle);

                // Customize other chart properties as needed

                // Optionally, set the X-axis and Y-axis labels
                chartArea.AxisX.Title = "Date";
                chartArea.AxisY.Title = "Total Amount";

                // Refresh the chart to display the data
                chart.Invalidate();
            }
            else
            {
                // Handle the case where paymentData is empty or null
                MessageBox.Show("No data available for the chart.");
            }
        }


      
    }
}
