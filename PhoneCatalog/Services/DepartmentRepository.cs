using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PhoneCatalog.Models;
using System.Data;
using PhoneCatalog.Helpers;

namespace PhoneCatalog.Services
{
    public class DepartmentRepository : ControllerBase, IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Department _dep;
        public DepartmentRepository(Department dep, IConfiguration configuration)
        {
            _dep = dep;
            _configuration = configuration;
        }
        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Department> Search(string searchString)
        {
            var result = new List<Department>();
            var sqlExpression = $"SELECT * FROM Departments WHERE Name LIKE {searchString}";

            return result;
        }
        public int Create(string name)
        {
            var departmentId = 0;
            var sqlExpression = $"INSERT INTO [departments] (Name) VALUES ('{name}');";

            return departmentId;
        }

        public JsonResult Get_department()
        {
            string query = @"
                    select *  from 
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

            //string json = Helper.DataTableToJSONWithJSONNet(table);
            return new JsonResult(table);
        }

        public JsonResult InsertDepartment(string DepName, int ParentsId)
        {
            
            string query = @$"insert into departments (DepName, ParentsId ) values ('{DepName}', '{ParentsId}') ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepName", _dep.DepName);
                    myCommand.Parameters.AddWithValue("@ParentsId", _dep.ParentsId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Succesfully!");
        }
        public JsonResult UpdateDepartment(int DepId, string DepName, int ParentsId)
        {
            string query = @$"
                    update departments set DepName = '{DepName}', ParentsId= '{ParentsId}' where DepId = '{DepId}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId", _dep.DepId);
                    myCommand.Parameters.AddWithValue("@DepName", _dep.DepName);
                    myCommand.Parameters.AddWithValue("@ParentsId", _dep.ParentsId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Update Succesfully!");

        }
        public JsonResult DeleteDepartment(int DepId)
        {
            string query = @$"
                    delete from departments where DepId = '{DepId}' ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepId", DepId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted Succesfully!");
        }

       /* public ActionResult<List<DepartmentInfo>> GetSubDepartments(int id)
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
                    departments where ParentsId = '{id}'";
            var sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection myCon = new MySqlConnection(sqlDataSource);
            myCon.Open();
            MySqlCommand myCommand = new MySqlCommand(query, myCon);
            MySqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                int DepId = myReader.GetInt32(0);
                string DepName = myReader.GetString(1);
                int ParentsID = myReader.GetInt32(2);
                Department department = new Department()
                {
                    DepId = DepId,
                    DepName = DepName,
                    ParentsId = ParentsID,
                };
            }
            
            myReader.Close();
            myCon.Close();
            foreach (var v in table.AsEnumerable()) //я хрен знает что делать с этим куском кода
            {
                var item = Helper.CreateItemFromRow<Department>(v);
                result.Add(new DepartmentInfo { Department = item, Childs = GetChildDepartments(item.DepId) });
            }

            return result;
        }*/

        Department IDepartmentRepository.InsertDepartment(string DepName, int ParentsId)
        {
            throw new NotImplementedException();
        }

      

        Department IDepartmentRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Department> IDepartmentRepository.Search(string searchString)
        {
            throw new NotImplementedException();
        }

        Department IDepartmentRepository.UpdateDepartment(int DepID, string DepName, int ParentsId)
        {
            throw new NotImplementedException();
        }

        Department IDepartmentRepository.DeleteDepartment(int DepID)
        {
            throw new NotImplementedException();
        }

        int IDepartmentRepository.Create(string name)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartments()
        {
            throw new NotImplementedException();
        }

        public List<Department> SubDepartments(int DepId)
        {
            throw new NotImplementedException();
        }
    }
}
