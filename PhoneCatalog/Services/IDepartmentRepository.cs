using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Models;

namespace PhoneCatalog.Services
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);
        Department Search(string searchString);
        List<Department> GetDepartments();
        Department InsertDepartment(string DepName, int ParentsId);
        Department UpdateDepartment(int DepId, string DepName, int ParentsId);
        Department DeleteDepartment(int DepId);
        List<Department> SubDepartments(int id);
        int Create(string name);
    }
}
