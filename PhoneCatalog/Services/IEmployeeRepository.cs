using PhoneCatalog.Models;

namespace PhoneCatalog.Services
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee();
        public Employee InsertEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId);
        public Employee UpdateEmployee(int EmpId, string FirstName, string LastName, int PhoneNumber, string Email, int DepId);
        public Employee UpdateDepartment(int EmpId, int DepId);
        public Employee DeleteEmployee(int EmpId);
        List<Employee> SearchName(string searchName);
        List<Employee> SearchLastname(string searchLastName);
        public Employee SearchPhoneNumber(int PhoneNumber);
        public Employee SearchEmail(string searchEmail);
        List<Employee> SearchDepartment(int DepId);

    }
}
