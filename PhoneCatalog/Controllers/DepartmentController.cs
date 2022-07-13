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
        [Route("view departments")]

        public List<Department> GetDepartments()
        {
            return _repository.GetDepartments();
        }

        [HttpPost]
        [Route("insert")]

        public Department InsertDepartment(string DepName, int ParentsId)
        {
           return _repository.InsertDepartment(DepName, ParentsId);

            
        }
        [HttpGet]
        [Route("search department")]

        public Department Search(string searchString)
        {
            return _repository.Search(searchString);
        }

        [HttpDelete]
        [Route("delete")]

        public Department DeleteDepartment(int DepId)
        {
            return _repository.DeleteDepartment(DepId);


        }

        [HttpPut]
        [Route("update department")]


        public Department UpdateDepartment(int DepId, string DepName, int ParentsId)
        {
            return _repository.UpdateDepartment(DepId, DepName, ParentsId);


        }
    }

}
