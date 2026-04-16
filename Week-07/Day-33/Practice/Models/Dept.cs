namespace WebApplication1.Models
{
    public class Dept
    {

        public int DeptId {  get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
