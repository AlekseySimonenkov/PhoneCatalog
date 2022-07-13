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

        [HttpGet]
        [Route("get employees")]

        public List<Employee> GetEmployees()
        {
            return _repository.GetEmployees();
        }

        [HttpPost]
        [Route("insert employee")]
        public Employee InsertEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            return _repository.InsertEmployee(EmpId, FirstName, LastName, PhoneNumber, Email, DepId);


        }

        [HttpDelete]
        [Route("delete")]

        public Employee DeleteEmployee(int EmpId)
        {
            return _repository.DeleteEmployee(EmpId);


        }

        [HttpGet]
        [Route("searh department")]
        public List<Employee> SearchDepartment(int DepId)
        {
            return _repository.SearchDepartment(DepId);
        }

        [HttpGet]
        [Route("searh Email")]
        public Employee SearchEmail(string Email)
        {
            return _repository.SearchEmail(Email);
        }


        [HttpGet]
        [Route("searh Name")]
        public List<Employee> SearchName(string searchName)
        {
            return _repository.SearchName(searchName);
        }

        [HttpGet]
        [Route("searh LastName")]
        public List<Employee> SearchLastName(string searchLastName)
        {
            return _repository.SearchLastname(searchLastName);
        }

        [HttpGet]
        [Route("searh PhoneNumber")]
        public Employee SearchPhoneNumber(int PhoneNumber)
        {
            return _repository.SearchPhoneNumber(PhoneNumber);
        }

        [HttpPut]
        [Route("update employee")]
        
        public Employee UpdateEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId)
        {
            return _repository.UpdateEmployee(EmpId, FirstName, LastName, PhoneNumber, Email, DepId);
        }

        [HttpPut]
        [Route("update department")]

        public Employee UpdateDepartment(int EmpId, int DepId)
        {
            return _repository.UpdateDepartment(EmpId, DepId);
        }
    }

}

