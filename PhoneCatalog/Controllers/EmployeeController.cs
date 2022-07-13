using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;
using PhoneCatalog.Models;
using MySql.Data.MySqlClient;
using PhoneCatalog.Services;

namespace PhoneCatalog.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("view")]

        public Employee GetEmployee()
        {
            return _repository.GetEmployee();
        }

        [HttpPost("insert")]

        public Employee InsertEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            return _repository.InsertEmployee(EmpId, FirstName, LastName, PhoneNumber, Email, DepId);
        }


        [HttpPut("update")]

       public Employee UpdateEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            return _repository.UpdateEmployee(EmpId, FirstName, LastName, PhoneNumber, Email, DepId);
        }

        [HttpDelete("{id}")]

       public Employee DeleteEmployee(int EmpId)
        {
            return _repository.DeleteEmployee(EmpId);
        }

        [HttpPut("update/department")]

        public Employee DepartmentEmployeeUpdate(int EmpId, int DepId)
        {
            return _repository.UpdateDepartment(EmpId, DepId);
        }

        [HttpPost("Search/Name")]
        
        public IEnumerable<Employee> SearchName([FromQuery]string searchName)
        {
             return _repository.SearchName(searchName);
        }
        public IEnumerable<Employee> SearchLastName([FromQuery] string searchLastName)
        {
            return _repository.SearchName(searchLastName);
        }
        [HttpPost("Search/Email")]
        public Employee SearchEmail(string searchEmail)
        {
            return _repository.SearchEmail(searchEmail);
        }

        [HttpPost("Search/PhoneNumber")]
        
        public Employee SearchPhoneNumber(int PhoneNumber)
        {
            return _repository.SearchPhoneNumber(PhoneNumber);  
        }
        [HttpPost("Search/DepId")]
        public IEnumerable<Employee> SearchDepartment([FromQuery] int DepId)
        {
            return _repository.SearchDepartment(DepId);
        }
    }

}

