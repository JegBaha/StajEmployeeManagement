using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace StajEmployeeManProje
{
    public partial class ControllAdd : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bahab\OneDrive\Belgeler\employee.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public ControllAdd()
        {
            InitializeComponent();

            empData();
        }
        public void empData()
        {
            EmployeeDatas data=new EmployeeDatas();
            List<EmployeeDatas> listEmp = data.employeeListThing();

            addDataGrid.DataSource = listEmp;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (idText.Text == "" || nameText.Text == "" || emailText.Text == "" || gendetText.Text == "" || statusBox.Text == "" || departmanText.Text == "")
            {
                MessageBox.Show("Lütfen gerekli yerleri doldurunuz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conn.State == ConnectionState.Closed)
                {
                    try { conn.Open();
                        string checkId = "SELECT * FROM employeesThing WHERE employeeId=@empID";
                        using (SqlCommand cmd=new SqlCommand(checkId, conn))
                        {
                          cmd.Parameters.AddWithValue("@empID", idText.Text.Trim());
                            int countThing=(int)cmd.ExecuteScalar();

                            if (countThing >= 1)
                            {
                                MessageBox.Show("Bu çalışan zaten var!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertThing = "INSERT INTO employeesThing (employeeId,fullName,gender,salary,email,departman,insertDate,status) VALUES(@employeeID,@fullName,@gender,@email,@departman,@salary,@status,@insertDate)";
                                
                                using (SqlCommand insertCmd=new SqlCommand(insertThing, conn))
                                {
                                    cmd.Parameters.AddWithValue("@emplyeeID", idText.Text.Trim());
                                    cmd.Parameters.AddWithValue("@fullName", nameText.Text.Trim());
                                    cmd.Parameters.AddWithValue("@gender", gendetText.Text.Trim());
                                    cmd.Parameters.AddWithValue("@email", emailText.Text.Trim());
                                    cmd.Parameters.AddWithValue("@salary", 0);
                                    cmd.Parameters.AddWithValue("@departman", departmanText.Text.Trim());
                                    cmd.Parameters.AddWithValue("@insertDate", DateTime.Today);
                                    
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Başarıyla Eklendi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                }
                            }
                        }
                    } catch(Exception ex) { MessageBox.Show("Bug"+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    finally { conn.Close(); }  
                }
            }
        }

        private void addDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = addDataGrid.Rows[e.RowIndex];
                idText.Text = row.Cells[1].Value.ToString();
                nameText.Text = row.Cells[2].Value.ToString();
                gendetText.Text = row.Cells[3].Value.ToString();
                departmanText.Text = row.Cells[4].Value.ToString();
                emailText.Text = row.Cells[5].Value.ToString();
                salaryText.Text = row.Cells[6].Value.ToString();

            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (idText.Text == "" || nameText.Text == "" || emailText.Text == "" || gendetText.Text == "" || statusBox.Text == "" || departmanText.Text == "")
            {
                MessageBox.Show("Lütfen gerekli yerleri doldurunuz!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                       
                    }
                    catch (Exception ex) { MessageBox.Show("Bug" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    finally { conn.Close(); }
                }
            }
        }
    }
}
