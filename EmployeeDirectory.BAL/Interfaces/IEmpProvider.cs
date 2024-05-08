using Employee = EmployeeDirectory.DAL.Models.Employee;
namespace EmployeeDirectory.BAL.Interfaces
{
    internal interface IEmpProvider
    {
        public void AddEmployee(DTO.Employee employee);

        public List<Employee> GetEmployees();

        //public (bool, dynamic) GetEmployeeById(string id);

        public void UpdateEmployee(DTO.Employee employee);

        public void DeleteEmployee(string id);

        public DTO.Employee AddValueToEmp(Dictionary<string, string> values, string mode);
    }
}
