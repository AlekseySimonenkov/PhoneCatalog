using PhoneCatalog.Models;

namespace PhoneCatalog.Services
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);
        List<Department> Search(string searchString);
        Department GetDepartments();
        Department InsertDepartment(string DepName, int ParentsId);
        Department UpdateDepartment(int DepId, string DepName, int ParentsId);
        Department DeleteDepartment(int DepId);
        List<Department> SubDepartments(int DepId);
        int Create(string name);
    }
}
