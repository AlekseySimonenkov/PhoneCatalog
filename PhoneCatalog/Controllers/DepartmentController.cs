using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using PhoneCatalog.Models;
using PhoneCatalog.Helpers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PhoneCatalog.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneCatalog.Controllers 
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;
        private readonly IConfiguration _configuration;
        public DepartmentController(IDepartmentRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]

        public Department GetDepartment()
        {
            return _repository.GetDepartments();
        }

        [HttpPost("insert")]

        public Department InsertDepartment(string DepName, int ParentsId)
        {
            return _repository.InsertDepartment(DepName, ParentsId);
        }
        [HttpPut("Update")]

        public Department UpdateDepartment(int DepId, string DepName, int ParentsId)
        {
            return _repository.UpdateDepartment(DepId, DepName, ParentsId);
        }

        [HttpDelete("{id}")]

        public Department DeleteDepartment(int DepId)
        {
            return _repository.DeleteDepartment(DepId);
        }

        [HttpGet("sub/{id}")]
        
         public IEnumerable<Department> SubDepartments([FromQuery] int DepId)
         {
             return _repository.SubDepartments(DepId);
         }

    }

}
