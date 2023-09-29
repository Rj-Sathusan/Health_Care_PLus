using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;




namespace Health_Care.DAL
{
    class function_
    {
        string i = Configurations.Config.ConnectionString;// @"server=127.0.0.1;user id=root;database=hardwear;default command timeout=1000";//arifpos


        //  string i = @"database='hardwear'; datasource='192.168.8.15'; username='root'; password='12345';default command timeout=1000";


        public void ClearTextBoxes(Control control)
        {
            try
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        (ctrl as TextBox).Clear();
                    }
                    else if (ctrl is ComboBox)
                    {
                        (ctrl as ComboBox).SelectedIndex = -1; // Clear selection in ComboBox
                    }
                    else
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message, "Error"); }
        }

       public void ErrorMessge(string validate) 
       { 
           MessageBox.Show(validate, "Warnig Message", MessageBoxButtons.OK, MessageBoxIcon.Error); 
       }


      public bool ShowMessage(string message, string Con)
        {
            try
            {
                if (Con != "Confirm")
                {
                    if (Con == "Warning")
                    {
                        MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (Con == "Information")
                    {
                        MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Con == "Error")
                    {
                        MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else if (MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }

      //List<int> cellsToIgnore = new List<int> { 0 }; <- if need ignore some cells
      public void SetTextBoxesFromSelectedRow(DataGridView dataGridView, List<Control> textBoxes, ref int idToSet, List<int> cellsToIgnore = null)
      {
          try
          {
              int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
              if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView.Rows.Count)
              {
                  DataGridViewRow selectedRow = dataGridView.Rows[selectedRowIndex];

                  // Loop through textboxes and DataGridView cells simultaneously
                  int textBoxIndex = 0; // Index to track the current textbox
                  for (int i = 1; i < selectedRow.Cells.Count; i++)
                  {
                      if (cellsToIgnore != null && cellsToIgnore.Contains(i))
                      {
                          // Skip cells that need to be ignored
                          continue;
                      }

                      // Check if there are more textboxes to populate
                      if (textBoxIndex < textBoxes.Count)
                      {
                          // Assign cell value to the current textbox
                          textBoxes[textBoxIndex].Text = selectedRow.Cells[i].Value.ToString();
                          textBoxIndex++; // Move to the next textbox
                      }
                      else
                      {
                          // If there are no more textboxes, exit the loop
                          break;
                      }
                  }

                  idToSet = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
              }
          }
          catch (Exception ex)
          {
              Console.WriteLine("An error occurred: " + ex.Message, "Error");
          }
      }

      public static bool IsNumeric(Control textBox, string fieldName)
      {
          try
          {
              if (!string.IsNullOrEmpty(textBox.Text))
              {
                  foreach (char c in textBox.Text)
                  {
                      if (!char.IsDigit(c))
                      {
                          textBox.Focus();
                          MessageBox.Show("Please enter a valid " + fieldName + " with numbers only.", "Validation Error");
                          return true; // Input is invalid
                      }
                  }
              }
              else
              {
                  textBox.Focus();
                  MessageBox.Show(fieldName + " cannot be empty.", "Validation Error");
                  return true; // Input is invalid (empty)
              }

              return false; // Input is valid (contains only numbers)
          }
          catch (Exception ex)
          {
              MessageBox.Show("An error occurred: " + ex.Message, "Error");
              return false; // Input is invalid due to an exception
          }
      }

      public static bool IsLettersOnly(Control textBox, string fieldName)
      {
          try
          {
              if (!string.IsNullOrEmpty(textBox.Text))
              {
                  foreach (char c in textBox.Text)
                  {
                      if (!char.IsLetter(c))
                      {
                          textBox.Focus();
                          MessageBox.Show("Please enter a valid " + fieldName + " with letters only.", "Validation Error");
                          return true; // Input is invalid
                      }
                  }
              }
              else
              {
                  textBox.Focus();
                  MessageBox.Show(fieldName + " cannot be empty.", "Validation Error");
                  return true; // Input is invalid (empty)
              }

              return false; // Input is valid (contains only letters)
          }
          catch (Exception ex)
          {
              MessageBox.Show("An error occurred: " + ex.Message, "Error");
              return true; // Input is invalid due to an exception
          }
      }


      private static bool IsAllLetters(string text)
      {
          try
          {
              foreach (char c in text)
              {
                  if (!Char.IsLetter(c))
                      return false;
              }
              return true;
          }
          catch (Exception ex)
          {
              MessageBox.Show("An error occurred: " + ex.Message, "Error");
              return false;
          }
      } 


        public void TextClear(TextBox[] Boxes)
        {
            try
            {
                for (int i = 0; i < Boxes.Length; i++)
                {
                    Boxes[i].Text = string.Empty;
                }
            }
            catch (Exception) { }
        }

        public static bool IsNotNullOrEmpty(Control textBox, string fieldName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Focus();
                    MessageBox.Show("Please enter a valid " + fieldName + ". It cannot be null or empty.", "Validation Error");
                    return true;
                }
                else
                {
                    return false;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
                return false;
            }
        }

       

        public void SearchGridView(DataGridView dgv, string searchText)
        {
            try
            {
                string searchLower = searchText.ToLower(); // Convert the search text to lowercase

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    bool matchFound = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            string cellContent = cell.Value.ToString().ToLower(); // Convert cell content to lowercase

                            if (cellContent.Contains(searchLower))
                            {
                                matchFound = true;
                                break; // No need to check other cells in this row
                            }
                        }
                    }

                    if (matchFound)
                    {
                        row.Visible = true; // Show the row if a match is found
                    }
                    else
                    {
                        row.Visible = false; // Hide the row if no match is found
                    }
                }
            }
            catch
            {
                // Handle any exceptions here
            }
        }



        public void BindGrid(DataGridView dgv, DataTable table)
        {
            try
            {
                dgv.Rows.Clear();
                dgv.RowCount = table.Rows.Count;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int x = 0; x < dgv.ColumnCount; x++)
                    {
                        dgv[x, i].Value = table.Rows[i].ItemArray[x].ToString().Trim();
                    }
                }
            }
            catch 
            {
               // Console.WriteLine("");
            }
        }


        public DataTable dataTable(string sql)
        {
            try
            {
                DataTable table = new DataTable();

                MySqlConnection con = new MySqlConnection(i);
                MySqlDataAdapter cmd = new MySqlDataAdapter(sql, con);

                con.Open();
                cmd.Fill(table);
                con.Close();

                return table;
            }
            catch (Exception ex)
            {
                 MessageBox.Show("An error occurred: " + ex.Message, "Error");
                 return null;
            }


        }

        }

    }



