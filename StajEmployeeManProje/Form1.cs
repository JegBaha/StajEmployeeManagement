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
using System.CodeDom;

namespace StajEmployeeManProje
{
    public partial class Form1 : Form
    {
        public static Form1 Instence;
        public string loginUserName;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bahab\OneDrive\Belgeler\employee.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
            Instence = this;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernTextBox.Text == "" || passTextBox.Text == "")
            {
                MessageBox.Show("Lütfen Gerekli Yerleri Boş Bırakmayınız.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                        string selectEmployee = "SELECT * FROM employees WHERE eName=@usernTextBox AND ePass=@passTextBox";

                        using (SqlCommand cmd=new SqlCommand(selectEmployee, conn))
                        {
                            cmd.Parameters.AddWithValue(@"usernTextBox", usernTextBox.Text.Trim());
                            cmd.Parameters.AddWithValue(@"passTextBox", passTextBox.Text.Trim());
                            loginUserName=usernTextBox.Text.Trim();

                            SqlDataAdapter adapt=new SqlDataAdapter(cmd);

                            DataTable dataT = new DataTable();
                            adapt.Fill(dataT);

                            if (dataT.Rows.Count >= 1)
                            {
                                MessageBox.Show("Hoş geldin " +usernTextBox.Text.Trim(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainF mainF = new MainF();
                                mainF.Show();
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Yanlış şifre veya UserName", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        conn.Close();

                    }
                }
           
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (usernTextBox.Text == "" || passTextBox.Text == "")
            {
                MessageBox.Show("Lütfen Gerekli Yerleri Boş Bırakmayınız.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (conn.State != ConnectionState.Open)
                {
                    try
                    {
                        conn.Open();

                       
                        string selectEmployeeN = "SELECT COUNT(id) FROM employees WHERE eName=@usernTextBox";
                        using (SqlCommand checkUser=new SqlCommand(selectEmployeeN, conn))
                        {
                            checkUser.Parameters.AddWithValue("@usernTextBox", usernTextBox.Text.Trim());
                            int count = (int)checkUser.ExecuteScalar();
                            if (count >= 1)
                            {
                                MessageBox.Show("Bu kullanıcı adı zaten kayıtlı", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DateTime dateTime = DateTime.Now;
                                string insertD = "INSERT INTO employees (eName,ePass,registerDate) VALUES(@usernTextBox,@passTextBox,@dateT)";
                                using (SqlCommand cmd = new SqlCommand(insertD, conn))
                                {
                                    cmd.Parameters.AddWithValue("@usernTextBox", usernTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@passTextBox", passTextBox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dateT", dateTime);
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Kayıt Olundu.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                        }
                      
                    }catch (Exception ex) {
                        MessageBox.Show("Error: "+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { 
                        conn.Close();
                    }

                }
            }
        }
    }
}
