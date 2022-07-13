using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PhoneCatalog.Models;
using System.Data;


namespace PhoneCatalog.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Employee _emp;
        

        public EmployeeRepository(IConfiguration configuration, Employee employee)
        {
            
            _configuration = configuration;
            _emp = employee;
        }

        public JsonResult GetEmployee()
        {
            string query = @" select * from employees";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        public JsonResult InsertEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            string query = $"insert into employees (FirstName, LastName, PhoneNumber, Email, DepId) values ('{FirstName}', '{LastName}', '{PhoneNumber}', '{Email}', '{DepId}') ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefualtConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", _emp.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", _emp.LastName);
                    myCommand.Parameters.AddWithValue("@PhoneNumber", _emp.PhoneNumber);
                    myCommand.Parameters.AddWithValue("@Email", _emp.Email);
                    myCommand.Parameters.AddWithValue("@DepId", _emp.DepId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Succesfully!");
        }

        public JsonResult UpdateEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            string query = $@"
                    update employees set FirstName = '{FirstName}', LastName = '{LastName}', PhoneNumber = '{PhoneNumber}', Email = '{Email}', DepId = '{DepId}' where EmpId = '{EmpId}' ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmpId", _emp.EmpId);
                    myCommand.Parameters.AddWithValue("@FirstName", _emp.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", _emp.LastName);
                    myCommand.Parameters.AddWithValue("@PhoneNumber", _emp.PhoneNumber);
                    myCommand.Parameters.AddWithValue("@Email", _emp.Email);
                    myCommand.Parameters.AddWithValue("@DepId", _emp.DepId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Succesfully!");
        }

        public JsonResult DeleteEmployee(int EmpId)
        {
            string query = @$"
                    delete from employees where EmpId = '{EmpId}' ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmpId", EmpId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Succesfully!");
        }

        public JsonResult DepartmentEmployeeUpdate(int EmpId, int DepId)
        {
            string query = @$"
                    update employees set DepId= '{DepId}' where EmpId = '{EmpId}' ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Succesfully!");
        }

        public List<Employee> SearchName(string searchName)
        {
            var result = new List<Employee>();
            string query = @$"
                    select * from 
                    Employees where lower(LastName) like '{searchName}%'";

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection myCon = new MySqlConnection(sqlDataSource);
            myCon.Open();
            MySqlCommand myCommand = new MySqlCommand(query, myCon);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            myCommand.Parameters.AddWithValue("@FirstName", _emp.FirstName);

            while (myReader.Read())
            {
                int EmpId = myReader.GetInt32(0);
                string FirstName = myReader.GetString(1);
                string LastName = myReader.GetString(2);
                int PhoneNumber = myReader.GetInt32(3);
                string Email = myReader.GetString(4);
                int DepId = myReader.GetInt32(5);
                Employee employee = new Employee()
                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepId
                };
            }
            myReader.Close();
            myCon.Close();
            return result;
        }
        public List<Employee> SearchLastName(string searchLastName)
        {
            var result = new List<Employee>();
            string query = @$"
                    select * from 
                    Employees where lower(LastName) like '{searchLastName}%'";
            
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection myCon = new MySqlConnection(sqlDataSource);
            myCon.Open();
            MySqlCommand myCommand = new MySqlCommand(query, myCon);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            myCommand.Parameters.AddWithValue("@LastName", _emp.LastName);
            
            while (myReader.Read())
            {
                int EmpId = myReader.GetInt32(0);
                string FirstName = myReader.GetString(1);
                string LastName = myReader.GetString(2);
                int PhoneNumber = myReader.GetInt32(3);
                string Email = myReader.GetString(4);
                int DepId = myReader.GetInt32(5);
                Employee employee = new Employee()
                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepId
                };
            }
            myReader.Close();
            myCon.Close();
                
            
            return result;
        }
        public JsonResult SearchEmail(string searchEmail)
        {
            string query = @$"
                     select * from 
                     Employees where lower(Email) like '{searchEmail}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Email", _emp.Email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        public JsonResult SearchPhoneNumber(int PhoneNumber)
        {
            string query = @$"
                    select * from 
                    Employees where PhoneNumber like '{PhoneNumber}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PhoneNumber", _emp.PhoneNumber);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        public List<Employee> SearchDepartment(int DepId)
        {
            var result = new List<Employee>();
            string query = @$"
                    select * from 
                    Employees where lower(DepId) like '{DepId}%'";

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection myCon = new MySqlConnection(sqlDataSource);
            myCon.Open();
            MySqlCommand myCommand = new MySqlCommand(query, myCon);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            myCommand.Parameters.AddWithValue("@DepId", _emp.DepId);

            while (myReader.Read())
            {
                int EmpId = myReader.GetInt32(0);
                string FirstName = myReader.GetString(1);
                string LastName = myReader.GetString(2);
                int PhoneNumber = myReader.GetInt32(3);
                string Email = myReader.GetString(4);
                int DepID = myReader.GetInt32(5);
                Employee employee = new Employee()
                {
                    EmpId = EmpId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DepId = DepID
                };
            }
            myReader.Close();
            myCon.Close();


            return result;
        }
        Employee IEmployeeRepository.DeleteEmployee(int EmpId)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployee()
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.InsertEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepIp)
        {
            throw new NotImplementedException();
        }

       

        Employee IEmployeeRepository.SearchPhoneNumber(int PhoneNumber)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.UpdateDepartment(int EmpId, int DepId)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.UpdateEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepIp)
        {
            throw new NotImplementedException();
        }

        List<Employee> IEmployeeRepository.SearchLastname(string searchLastName)
        {
            throw new NotImplementedException();
        }

        List<Employee> IEmployeeRepository.SearchDepartment(int DepId)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.SearchEmail(string searchEmail)
        {
            throw new NotImplementedException();
        }
        
    }
}
