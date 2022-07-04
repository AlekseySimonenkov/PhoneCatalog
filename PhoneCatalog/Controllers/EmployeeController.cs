using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;
using PhoneCatalog.Models;
using MySql.Data.MySqlClient;

namespace PhoneCatalog.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController (IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        // GET api/<EmployeeController>/5
        [HttpGet("view")]
        public JsonResult GetDepartment()
        {
            string query = @"
                    EmpId, FirstName, LastName, PhoneNumber, Email, DepId from 
                    employees";
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

        [HttpPost("insert")]

        public JsonResult InsertDepartment(Employee emp)
        {
            string query = @"insert into employees (FirstName, LastName, PhoneNumber, Email, DepId) values (@FirstName, @LastName, @PhoneNumber, @Email, @DepId) ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefualtConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", emp.LastName);
                    myCommand.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                    myCommand.Parameters.AddWithValue("@Email", emp.Email);
                    myCommand.Parameters.AddWithValue("@DepId", emp.DepId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Succesfully!");
        }
        [HttpPut("update")]

        public JsonResult UpdateDepartment(Employee emp)
        {
            string query = @"
                    update employees set FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email, DepId = @DepId where EmpId = @EmpId ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmpId", emp.EmpId);
                    myCommand.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", emp.LastName);
                    myCommand.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                    myCommand.Parameters.AddWithValue("@Email", emp.Email);
                    myCommand.Parameters.AddWithValue("@DepId", emp.DepId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Succesfully!");
        }

        [HttpDelete("{id}")]

        public JsonResult DeleteDepartment(int EmpId)
        {
            string query = @"
                    delete from employees where EmpId = @EmpId ";
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

        [HttpPut("update/department")]

        public JsonResult DepartmentEmployeeUpdate(DepartmentEmployeeUpdate dto)
        {
            string query = @$"
                    update employees set DepId= {dto.DepId} where EmpId = {dto.EmpId} ";
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

        [HttpPost("Search/Name")]
        public JsonResult SearchName(Employee emp)
        {
            string query = @$"
                    select EmpId, FirstName, LastName, PhoneNumber, Email, DepID from 
                    Employees where lower(Name) like '{emp.FirstName}%'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost("Search/Email")]
        public JsonResult SearchEmail(Employee emp)
        {
            string query = @$"
                     select EmpId, FirstName, LastName, PhoneNumber, Email, DepID from 
                     Employees where lower(Email) like '{emp.Email}%'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Email", emp.Email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost("Search/PhoneNumber")]
        public JsonResult SearchPhoneNumber(Employee emp)
        {
            string query = @$"
                    select EmpId, FirstName, LastName, PhoneNumber, Email, DepID from 
                    Employees where lower(PhoneNumber) like '{emp.PhoneNumber}%'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost("Search/DepId")]
        public JsonResult SearchDepId(Employee emp)
        {
            string query = @$"
                    select  EmpId, FirstName, LastName, PhoneNumber, Email, DepID from 
                    Employees where DepId like '{emp.DepId}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId", emp.DepId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }

}

