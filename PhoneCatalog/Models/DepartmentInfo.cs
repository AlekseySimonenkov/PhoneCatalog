namespace PhoneCatalog.Models
{
    public class DepartmentInfo
    {
        public Department Department { get; set; }
        public List<DepartmentInfo> Childs { get; set; }
    }
}
