using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StajEmployeeManProje
{
    internal class EmployeeDatas
    {

        public int ID { set; get; }
        public int EmployeeID { set; get; }
        public int Salary { get; set; }
        public string Name { set; get; }
        public string Gemder { set; get; } 
        public string Email { set; get; }   
        public string Departman { set; get; }
        public string Status { set; get; }  

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bahab\OneDrive\Belgeler\employee.mdf;Integrated Security=True;Connect Timeout=30");

        public List<EmployeeDatas> employeeListThing()
        {
            List<EmployeeDatas> listEmp = new List<EmployeeDatas>();

            if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                    string selectD = "SELECT * FROM employeesThing WHERE deleteDate IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectD, conn))
                    {
                        SqlDataReader reader=cmd.ExecuteReader();   

                        while (reader.Read())
                        {
                            EmployeeDatas data = new EmployeeDatas();
                            data.ID = (int)reader["id"];
                            data.Name = reader["fullName"].ToString();
                            data.EmployeeID = (int)reader["employeeID"];
                            data.Email = reader["email"].ToString();
                            data.Gemder = reader["gender"].ToString();
                            data.Departman = reader["departman"].ToString();
                            data.Salary = (int)reader["salary"];
                            data.Status= reader["status"].ToString();
                            listEmp.Add(data);
                        }
                    }

                }catch(Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
            return listEmp;

        }
    }

  


}
