using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data;
using PhoneCatalog.Models;
using PhoneCatalog.Helpers;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneCatalog.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get_department()
        {
            string query = @"
                    select DepId, DepName, ParentsId  from 
                    departments";
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

        public JsonResult InsertDepartment(Department dep)
        {
            string query = @"insert into departments (DepName, ParentsId ) values (@DepName, @ParentsId) ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepName", dep.DepName);
                    myCommand.Parameters.AddWithValue("@ParentsId", dep.ParentsId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Succesfully!");
        }

        [HttpPut("Update")]

        public JsonResult UpdateDepartment(Department dep)
        {
            string query = @"
                    update departments set DepName = @DepName, ParentsId= @ParentsId where DepId = @DepId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId", dep.DepId);
                    myCommand.Parameters.AddWithValue("@DepName", dep.DepName);
                    myCommand.Parameters.AddWithValue("@ParentsId", dep.ParentsId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Succesfully!");
        }

        [HttpDelete("{id}")]

        public JsonResult DeleteDepartment(int id)
        {
            string query = @"
                    delete from departments where DepId = @DepId ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Succesfully!");
        }

        [HttpGet("sub/{id}")]

        public ActionResult<List<DepartmentInfo>> GetSubDepartments(int id)
        {
            var info = new DepartmentInfo();
            var query = @$"
                    select * from 
                    departments where DepID = {id}";
            var table = new DataTable();
            var sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (var myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (var myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            foreach (var v in table.AsEnumerable())
            {
                info.Department = Helper.CreateItemFromRow<Department>(v);
            }

            return StatusCode(200, GetChildDepartments(id));
        }

        private List<DepartmentInfo> GetChildDepartments(int id)
        {
            var result = new List<DepartmentInfo>();
            var query = @$"
                    select * from 
                    departments where ParentsId = {id}";
            var table = new DataTable();
            var sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (var myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (var myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            foreach (var v in table.AsEnumerable())
            {
                var item = Helper.CreateItemFromRow<Department>(v);
                result.Add(new DepartmentInfo { Department = item, Childs = GetChildDepartments(item.DepId) });
            }

            return result;
        }

    }

}
