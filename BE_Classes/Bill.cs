using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text.RegularExpressions; // Make sure to include this at the top of your C# file
using System.Globalization;
using System.Diagnostics; // 

namespace Health_Care.BE_Classes
{
    class Bill : DAL.NewDataAccessLayer
    {
        private double pay_total;
        private double Bill_total;
        public string GetBillingDetails(int patientID)
        {
            string billDetails = "";

            if (OpenConnection())
            {
                using (MySqlCommand sqlCommand = new MySqlCommand("GetPatientBillingDetails", sqlconnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add the parameter for PatientID
                    sqlCommand.Parameters.AddWithValue("@PatientID", patientID);

                    using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string patientName = reader["PatientName"].ToString();
                            string patientGender = reader["PatientGender"].ToString();
                            string patientAge = reader["PatientAge"].ToString();
                            string patientContact = reader["PatientContact"].ToString();
                            string patientNIC = reader["PatientNIC"].ToString();
                            string appointmentDate = reader["AppointmentDate"].ToString();
                            //string appointmentTime = reader["AppointmentTime"].ToString();
                            string appointmentStatus = reader["AppointmentStatus"].ToString();
                            string roomID = reader["RoomID"].ToString();
                            string roomType = reader["RoomType"].ToString();
                            string roomPrice = reader["RoomPrice"].ToString();
                            string serviceDescription = reader["ServiceDescription"].ToString();
                            string servicePrice = reader["ServicePrice"].ToString();
                            string totalBillAmount = reader["TotalBillAmount"].ToString();
                            string billStatus = reader["BillStatus"].ToString();
                            string BillID = reader["BillID"].ToString();


                            string paymentDetails = "Payment History:";

                            // Read all payment rows
                            do
                            {
                                string paymentDate = reader["PaymentDate"].ToString();
                                string paymentAmount = reader["PaymentAmount"].ToString();
                                paymentDetails += "Payment Date: " + paymentDate + ", Payment Amount: " + paymentAmount + ", ";
                                pay_total = pay_total + Convert.ToDouble(paymentAmount);
                            } while (reader.Read());

                            string usedResourceType = reader["UsedResourceType"].ToString();
                            string usedResourcePrice = reader["UsedResourcePrice"].ToString();
                            string hospitalServiceCharge = reader["HospitalServiceCharge"].ToString();
                            string doctorsConsultationFee = reader["DoctorsConsultationFee"].ToString();
                            string paymentID = reader["PaymentID"].ToString();

                            Bill_total = Convert.ToDouble(roomPrice) + Convert.ToDouble(hospitalServiceCharge) + Convert.ToDouble(doctorsConsultationFee) + Convert.ToDouble(servicePrice);

                            if (Bill_total <= pay_total)
                            { billStatus = "paid"; }
                            else { billStatus = "Not paid"; }

                            MessageBox.Show(Convert.ToString(pay_total+Bill_total+billStatus));

                            string billDetails2 =
                                "Patient Name: " + patientName + "\n" +
                                "Gender: " + patientGender + "\n" +
                                "Age: " + patientAge + "\n" +
                                "Contact: " + patientContact + "\n" +
                                "NIC: " + patientNIC + "\n" +
                                "Appointment Date: " + appointmentDate + "\n" +
                               // "Appointment Time: " + appointmentTime + "\n" +
                                "Appointment Status: " + appointmentStatus + "\n" +
                                "Room ID: " + roomID + "\n" +
                                "Room Type: " + roomType + "\n" +
                                "Room Price: " + roomPrice + "\n" +
                                "Service Description: " + serviceDescription + "\n" +
                                "Service Price: " + servicePrice + "\n" +
                                "BillID" + BillID + "\n" +
                                "Total Bill Amount: " + Bill_total + "\n" +
                                "Bill Status: " + billStatus + "\n" +
                                paymentDetails + // Append the payment history here
                                "Used Resource Type: " + usedResourceType + "\n" +
                                "Used Resource Price: " + usedResourcePrice + "\n" +
                                "Hospital Service Charge: " + hospitalServiceCharge + "\n" +
                                "Doctor's Consultation Fee: " + doctorsConsultationFee + "\n" +
                                "Payment ID: " + paymentID + "\n";


                            GenerateBillPdfFromText(billDetails2, BillID);


                            // Add more columns to the billDetails string as needed
                        }
                    }
                }

                CloseConnection();
            }

            return billDetails;
        }

        public void GenerateBillPdfFromText(string billDetails, string pdf_name)
        {
            Document doc = new Document();

            try
            {
                string fileName = pdf_name + ".pdf"; // Change this to your desired PDF file name
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));

                doc.Open();



                // Create a table for the bill details
                PdfPTable table = new PdfPTable(2); // Two columns
                table.WidthPercentage = 100;

                // Extract information from the billDetails string using regex
                string patientName = ExtractValue(billDetails, "Patient Name:");
                string patientGender = ExtractValue(billDetails, "Gender:");
                int patientAge = int.Parse(ExtractValue(billDetails, "Age:"));
                string patientContact = ExtractValue(billDetails, "Contact:");
                string patientNIC = ExtractValue(billDetails, "NIC:");
                DateTime appointmentDate = DateTime.ParseExact(
                    ExtractValue(billDetails, "Appointment Date:"), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                string appointmentTime = ExtractValue(billDetails, "Appointment Time:");
                string appointmentStatus = ExtractValue(billDetails, "Appointment Status:");
                int roomID = int.Parse(ExtractValue(billDetails, "Room ID:"));
                string roomType = ExtractValue(billDetails, "Room Type:");
                decimal roomPrice = decimal.Parse(ExtractValue(billDetails, "Room Price:").TrimStart('$'));
                string serviceDescription = ExtractValue(billDetails, "Service Description:");
                decimal servicePrice = decimal.Parse(ExtractValue(billDetails, "Service Price:").TrimStart('$'));
                decimal totalBillAmount = decimal.Parse(ExtractValue(billDetails, "Total Bill Amount:").TrimStart('$'));
                string billStatus = ExtractValue(billDetails, "Bill Status:");
                string BillID = ExtractValue(billDetails, "BillID");


                // string payment_history = ExtractValue(billDetails, "Payment History:");


                // Create a table for patient details
                PdfPTable patientTable = new PdfPTable(2);
                patientTable.WidthPercentage = 100;
                patientTable.AddCell("Patient Details");
                patientTable.AddCell("");
                AddRowToTable(patientTable, "Patient Name:", patientName);
                AddRowToTable(patientTable, "Gender:", patientGender);
                AddRowToTable(patientTable, "Age:", patientAge.ToString());
                AddRowToTable(patientTable, "Contact:", patientContact);
                AddRowToTable(patientTable, "NIC:", patientNIC);
                AddRowToTable(patientTable, "Appointment Date:", appointmentDate.ToShortDateString());
                AddRowToTable(patientTable, "Appointment Time:", appointmentTime);
                AddRowToTable(patientTable, "Appointment Status:", appointmentStatus);

                // Create a table for room details
                PdfPTable roomTable = new PdfPTable(2);
                roomTable.WidthPercentage = 100;
                roomTable.AddCell("Room Details");
                roomTable.AddCell("");
                AddRowToTable(roomTable, "Room ID:", roomID.ToString());
                AddRowToTable(roomTable, "Room Type:", roomType);
                AddRowToTable(roomTable, "Room Price:", roomPrice.ToString("C"));

                // Create a table for service details
                PdfPTable serviceTable = new PdfPTable(2);
                serviceTable.WidthPercentage = 100;
                serviceTable.AddCell("Service Details");
                serviceTable.AddCell("");
                AddRowToTable(serviceTable, "Service Description:", serviceDescription);
                AddRowToTable(serviceTable, "Service Price:", servicePrice.ToString("C"));

                // Extract payment history section
                string paymentHistorySection = ExtractValue(billDetails, "Payment History:");
                // Split payment history into individual payments
                string[] paymentHistoryLines = paymentHistorySection.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                // Create a table for payment history
                PdfPTable paymentHistoryTable = new PdfPTable(2);
                paymentHistoryTable.WidthPercentage = 100;
                paymentHistoryTable.AddCell("Payment History");
                paymentHistoryTable.AddCell("");
                foreach (string paymentLine in paymentHistoryLines)
                {
                    paymentHistoryTable.AddCell(paymentLine);
                }

                // Add additional charges
                decimal hospitalServiceCharge = decimal.Parse(ExtractValue(billDetails, "Hospital Service Charge:").TrimStart('$'));
                decimal doctorsConsultationFee = decimal.Parse(ExtractValue(billDetails, "Doctor's Consultation Fee:").TrimStart('$'));

                PdfPTable chargesTable = new PdfPTable(2);
                chargesTable.WidthPercentage = 100;
                chargesTable.AddCell("Additional Charges");
                chargesTable.AddCell("");
                AddRowToTable(chargesTable, "Hospital Service Charge:", hospitalServiceCharge.ToString("C"));
                AddRowToTable(chargesTable, "Doctor's Consultation Fee:", doctorsConsultationFee.ToString("C"));

                doc.Add(new Paragraph(" Health Care Plus                                                                 Billing ID:" + BillID + "\n\n\n"));
                // Add all the tables to the document
                doc.Add(patientTable);
                doc.Add(roomTable);
                doc.Add(serviceTable);
                doc.Add(paymentHistoryTable);
                // doc.Add(chargesTable);
                doc.Add(chargesTable);
                // Create a table for total bill details
                doc.Add(new Paragraph("Total Bill Details"));
                //  doc.Add(new Paragraph("Total Bill Amount: " + totalBillAmount.ToString("C")));
                doc.Add(new Paragraph("Bill Status: " + billStatus + "                                                     Total Bill Amount:" + totalBillAmount.ToString("C")));
                // Add bill issue date and time
                DateTime billIssueDateTime = DateTime.Now;
                doc.Add(new Paragraph("Bill Issue Date and Time: " + billIssueDateTime.ToString("MM/dd/yyyy HH:mm:ss")));
                doc.Close();
                writer.Close();
                // Automatically open the generated PDF
                Process.Start(outputPath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        private void AddRowToTable(PdfPTable table, string title, string value)
        {
            table.AddCell(title);
            table.AddCell(value);
        }




        private string ExtractValue(string input, string pattern)
        {
            Match match = Regex.Match(input, pattern + @"(.*?)\n");
            return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
        }

        private string ExtractSection(string input, string pattern)
        {
            Match match = Regex.Match(input, pattern + @"(.*?)\n\n", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
        }
    }
}
