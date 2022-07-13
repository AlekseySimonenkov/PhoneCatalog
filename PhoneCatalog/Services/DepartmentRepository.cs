using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PhoneCatalog.Models;
using System.Data;
using PhoneCatalog.Helpers;

namespace PhoneCatalog.Services
{
    public class DepartmentRepository :  IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
       
        public DepartmentRepository(IConfiguration configuration)
        {
            
            _configuration = configuration;
        }

        int IDepartmentRepository.Create(string name)
        {
            throw new NotImplementedException();
        }

        Department IDepartmentRepository.DeleteDepartment(int DepId)
        {
            Department result = new Department();
            string query = $"delete from departments  where DepId like '{DepId}' ";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Dep", DepId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        Department IDepartmentRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Department> IDepartmentRepository.GetDepartments()
        {
            List<Department> result = new List<Department>();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = "SELECT * FROM departments";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int depId = reader.GetInt32(0);
                int parentsId = reader.GetInt32(1);
                string depName = reader.GetString(2);

                Department dep = new Department()
                {
                    DepId = depId,
                    DepName = depName,
                    ParentsId = parentsId
                };
                result.Add(dep);

            }
            reader.Close();
            conn.Close();
            return result;
        }

        public Department InsertDepartment(string DepName, int ParentsId)
        {
            Department result = new Department();
            string query = @$"insert into departments (DepName, ParentsId ) values ('{DepName}', '{ParentsId}') ";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@DepName", DepName);
                    command.Parameters.AddWithValue("@ParentsId", ParentsId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        Department IDepartmentRepository.Search(string searchString)
        {
            Department result = new Department();
            string query = _configuration.GetConnectionString("DefaultConnection");
            MySqlConnection conn = new MySqlConnection(query);
            conn.Open();
            string sql = $"SELECT * FROM departments where DepName like '{searchString}'";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int depId = reader.GetInt32(0);
                int parentsId = reader.GetInt32(1);
                string depName = reader.GetString(2);

                Department dep = new Department()
                {
                    DepId = depId,
                    DepName = depName,
                    ParentsId = parentsId
                };
                result = dep;

            }
            reader.Close();
            conn.Close();
            return result;
        }

         

            /*public ActionResult<List<DepartmentInfo>> GetSubDepartments(int id)
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
                 var sql = _configuration.GetConnectionString("DefaultConnection");
                 MySqlConnection conn = new MySqlConnection(sql);
                 conn.Open();
                 MySqlCommand command = new MySqlCommand(query, conn);
                 MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int depId = reader.GetInt32(0);
                        string depName = reader.GetString(1);
                        int parentsId = reader.GetInt32(2);
                        
                        Department dep = new Department()


                        {
                            DepId = depId,
                            DepName = depName,
                            ParentsId = parentsId
                        };
                        result.Add((DepartmentInfo)dep);

                    }
                    reader.Close();
                    conn.Close();

            foreach (var v in result.AsEnumerable())
                 {
                     var item = Helper.CreateItemFromRow<Department>(v);
                     result.Add(new DepartmentInfo { Department = (Department)item, Childs = GetChildDepartments(item.DepId) });
                 }

                 return result;
             }*/
   

    Department IDepartmentRepository.UpdateDepartment(int DepId, string DepName, int ParentsId)
        {
            Department result = new Department();
            string query = $"update departments set DepName = '{DepName}', ParentsId= '{ParentsId}' where DepId = '{DepId}'";
            DataTable table = new DataTable();
            string sql = _configuration.GetConnectionString("DefaultConnection");
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@DepId", DepId);
                    command.Parameters.AddWithValue("@DepName", DepName);
                    command.Parameters.AddWithValue("@ParentsId", ParentsId);
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }
            return result;
        }

        public List<Department> SubDepartments(int id)
        {
            throw new NotImplementedException();
        }
    }
}
