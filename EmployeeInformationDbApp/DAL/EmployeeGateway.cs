using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationDbApp.Model;

namespace EmployeeInformationDbApp.DAL
{
   public class EmployeeGateway
   {
       string connectionString = ConfigurationManager.ConnectionStrings["emplyeeConnString"].ConnectionString;

       public int Save(Employee aEmployee)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = string.Format("INSERT INTO employeeTbl VALUES ('{0}','{1}','{2}','{3}')", aEmployee.name,
                aEmployee.email,
                aEmployee.address, aEmployee.salary);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

       List<Employee> allEmployees = new List<Employee>(); 
       public List<Employee> GetAllEmployee()
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM employeeTbl";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           
           while (reader.Read())
           {
               Employee aEmployee = aEmployee = new Employee();
               aEmployee.Id = int.Parse(reader[0].ToString());
               aEmployee.name = reader["Name"].ToString();
               aEmployee.email = reader["Email"].ToString();
               aEmployee.address = reader["Address"].ToString();
               aEmployee.salary = decimal.Parse(reader["Salary"].ToString());
               allEmployees.Add(aEmployee);

           }
           reader.Close();
           connection.Close();
           return allEmployees;

       }

       public Employee GetEmployeeByEmail(string employeeEmail)
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM employeeTbl WHERE Email = '" + employeeEmail + "'";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           Employee aEmployee = null;
           while (reader.Read())
           {
               if (aEmployee == null)
               {
                   aEmployee = new Employee();
               }
               aEmployee.Id = int.Parse(reader[0].ToString());
               aEmployee.name = reader["Name"].ToString();
               aEmployee.email = reader["Email"].ToString();
               aEmployee.address = reader["Address"].ToString();
               aEmployee.salary = int.Parse(reader["Salary"].ToString());

           }
           reader.Close();
           connection.Close();
           return aEmployee;
       }
       public Employee GetEmployeeById(int employeeId)
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "SELECT * FROM employeeTbl WHERE ID = '" + employeeId + "'";
           SqlCommand command = new SqlCommand(query, connection);
           connection.Open();
           SqlDataReader reader = command.ExecuteReader();
           Employee aEmployee = null;
           while (reader.Read())
           {
               if (aEmployee == null)
               {
                   aEmployee = new Employee();
               }
               aEmployee.Id = int.Parse(reader[0].ToString());
               aEmployee.name = reader["Name"].ToString();
               aEmployee.email = reader["Email"].ToString();
               aEmployee.address = reader["Address"].ToString();
               aEmployee.salary = int.Parse(reader["Salary"].ToString());

           }
           reader.Close();
           connection.Close();
           return aEmployee;
       }

       public int Update(Employee aEmployee)
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "UPDATE employeeTbl SET Name = '" + aEmployee.name + "',Email = '"+aEmployee.email +"', Address = '" + aEmployee.address +
                          "', Salary = '" + aEmployee.salary + "' WHERE ID = " + aEmployee.Id;
           SqlCommand command = new SqlCommand(query,connection);
           connection.Open();
           int rowAffected = command.ExecuteNonQuery();
           connection.Close();
           return rowAffected;
       }

       public int Delete(Employee employee)
       {
           SqlConnection connection = new SqlConnection(connectionString);
           string query = "DELETE employeeTbl WHERE ID = " + employee.Id;
           SqlCommand command = new SqlCommand(query,connection);
           connection.Open();
           int rowAffected = command.ExecuteNonQuery();
           return rowAffected;
       }
   }
}
