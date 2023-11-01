using EmployeeApp.DataAccessLayer;
using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeApp.ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        DataManager db = new DataManager();
        string conString = ConfigurationManager.AppSettings["connectionString"];
        static int i = 20;
        public async Task<List<Employee>> getEmployeesAsync()
        {
           // string conString = db.getConnectionString();
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "select * from Employees";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = int.Parse(reader["Id"].ToString());
                        employee.Name = reader["Name"].ToString();
                        employee.Address = reader["Address"].ToString();
                        employee.Mobile = reader["Mobile"].ToString();
                        DateTime date = ((DateTime)reader["DOB"]);
                        employee.DOBDateOnly = date.ToString("dd-MM-yyyy");
                        employees.Add(employee);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return employees;
        }

        public async Task<bool> addEmployeeAsync(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "insert into Employees (Name,Address,Mobile,DOB) values('" + employee.Name + "',' " + employee.Address + " ','" + employee.Mobile + "','" + employee.DOB + "')";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    await con.OpenAsync();
                    int rowAffected = await command.ExecuteNonQueryAsync();

                    if (rowAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
                return false;
            }
        }

        public async Task<Employee> getEmployeeByIdAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "Select * from Employees where Id =" + id + "";

                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    reader.Read();
                    Employee emp = new Employee();
                    emp.Id = int.Parse(reader["Id"].ToString());
                    emp.Name = reader["Name"].ToString();
                    emp.Address = reader["Address"].ToString();
                    emp.Mobile = reader["Mobile"].ToString();
                    DateTime date = ((DateTime)reader["DOB"]);
                    emp.DOBDateOnly = date.ToString("dd-MM-yyyy");//.Substring(0,10);
                    emp.DOB = ((DateTime)reader["DOB"]).Date;
                    return emp;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
                return null;
            }

        }

        public async Task<bool> updateEmployeeAsync(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "update Employees set Name='" + employee.Name + "',Address=' " + employee.Address + " ',Mobile='" + employee.Mobile + "',DOB='" + employee.DOBDateOnly + "' where  Id=" + employee.Id + "";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    await con.OpenAsync();
                    int rowAffected = await command.ExecuteNonQueryAsync();

                    if (rowAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
                return false;
            }
        }

        public async Task<bool> deleteEmployeeAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "delete from Employees where  Id=" + id + "";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    await con.OpenAsync();
                    int rowAffected = await command.ExecuteNonQueryAsync();

                    if (rowAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
                return false;
            }
        }
    }
}