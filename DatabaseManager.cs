using Microsoft.Data.Sqlite;
using System.Collections.Generic;

public class DatabaseManager
{
    public static List<Employee> GetEmployees()
    {
        var employees = new List<Employee>();
        string connectionString = "Data Source=Northwind.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"SELECT EmployeeID, LastName, FirstName,Title,FROM Employees;";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Employee = new Employee
                    {
                        EmployeeId = reader["EmployeeID"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        Title = reader["Title"].ToString(),
                        
                    };
                    employees.Add(Employee);
                }
            }
        }
        return employees;
    }
    public static void CreateEmployee(Employee Employee)
    {
        string connectionString = "Data Source=Northwind.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"INSERT INTO Employees (EmployeeID, FirstName, LastName,Title) VALUES (@EmployeeId, @LastName, @FirstName, @Title);";
            
            command.Parameters.AddWithValue("@EmployeeId", Employee.EmployeeId);
            command.Parameters.AddWithValue("@LastName", Employee.LastName);
            command.Parameters.AddWithValue("@FirstName", Employee.FirstName);
            command.Parameters.AddWithValue("@Title", Employee.Title);
            

            command.ExecuteNonQuery();
        }
    }
}