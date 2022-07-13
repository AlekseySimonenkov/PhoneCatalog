using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PhoneCatalog.Models;
using System.Data;


namespace PhoneCatalog.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        
        

        public EmployeeRepository(IConfiguration configuration)
        {
            
            _configuration = configuration;
           
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> result = new List<Employee>();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = "SELECT * FROM employees";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int EmpId = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                int PhoneNumber = reader.GetInt32(3);
                string Email = reader.GetString(4);
                int DepId = reader.GetInt32(5);
                Employee emp = new Employee()

                
                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepId
                };
                result.Add(emp);

            }
            reader.Close();
            conn.Close();
            return result;
        }

        Employee IEmployeeRepository.DeleteEmployee(int EmpId)
        {
            Employee result = new Employee();
            string query = $"delete from employees where EmpId like '{EmpId}' ";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpId", EmpId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        

        Employee IEmployeeRepository.InsertEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            Employee result = new Employee();
            string query = @$"insert into employees (EmpId, FirstName, LastName, PhoneNumber, Email, DepId) values ('{EmpId}', '{FirstName}', '{LastName}', '{PhoneNumber}', '{Email}', '{DepId}') ";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpId", EmpId);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@DepId", DepId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        List<Employee> IEmployeeRepository.SearchDepartment(int DepId)
        {
            List<Employee> result = new List<Employee>();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = $"SELECT * FROM employees where DepId like '{DepId}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int EmpId = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                int PhoneNumber = reader.GetInt32(3);
                string Email = reader.GetString(4);
                int DepID = reader.GetInt32(5);
                Employee emp = new Employee()


                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepID
                };
                result.Add(emp);

            }
            reader.Close();
            conn.Close();
            return result;
        }

        Employee IEmployeeRepository.SearchEmail(string searchEmail)
        {
            Employee result = new Employee();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = $"SELECT * FROM employees where Email like '{searchEmail}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int EmpId = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                int PhoneNumber = reader.GetInt32(3);
                string Email = reader.GetString(4);
                int DepID = reader.GetInt32(5);
                Employee emp = new Employee()


                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepID
                };
               result = emp;

            }
            reader.Close();
            conn.Close();
            return result;
        }

        List<Employee> IEmployeeRepository.SearchLastname(string searchLastName)
        {
            List<Employee> result = new List<Employee>();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = $"SELECT * FROM employees where LastName like '{searchLastName}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int EmpId = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                int PhoneNumber = reader.GetInt32(3);
                string Email = reader.GetString(4);
                int DepID = reader.GetInt32(5);
                Employee emp = new Employee()


                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepID
                };
                result.Add(emp);

            }
            reader.Close();
            conn.Close();
            return result;
        }

        List<Employee> IEmployeeRepository.SearchName(string searchName)
        {
            List<Employee> result = new List<Employee>();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = $"SELECT * FROM employees where FirstName like '{searchName}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int EmpId = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                int PhoneNumber = reader.GetInt32(3);
                string Email = reader.GetString(4);
                int DepID = reader.GetInt32(5);
                Employee emp = new Employee()


                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepID
                };
                result.Add(emp);

            }
            reader.Close();
            conn.Close();
            return result;
        }

        Employee IEmployeeRepository.SearchPhoneNumber(int PhoneNumber)
        {
            Employee result = new Employee();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = $"SELECT * FROM employees where PhoneNumber like '{PhoneNumber}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int EmpId = reader.GetInt32(0);
                string FirstName = reader.GetString(1);
                string LastName = reader.GetString(2);
                int PhoneNumbeR = reader.GetInt32(3);
                string Email = reader.GetString(4);
                int DepID = reader.GetInt32(5);
                Employee emp = new Employee()


                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumbeR,
                    Email = Email,
                    DepId = DepID
                };
                result = emp;

            }
            reader.Close();
            conn.Close();
            return result;
        }

        Employee IEmployeeRepository.UpdateDepartment(int EmpId, int DepId)
        {
            Employee result = new Employee();
            string query = $"update employees set  DepId = '{DepId}' where EmpId = '{EmpId}' ";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpId", EmpId);
                    command.Parameters.AddWithValue("@DepId", DepId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        Employee IEmployeeRepository.UpdateEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            Employee result = new Employee();
            string query = $"update employees set FirstName = '{FirstName}', LastName = '{LastName}', PhoneNumber = '{PhoneNumber}', Email = '{Email}', DepId = '{DepId}' where EmpId = '{EmpId}'  ";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpId", EmpId);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@DepId", DepId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }
    }
}
