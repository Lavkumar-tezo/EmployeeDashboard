using EmployeeDirectory.DAL.Models;
namespace EmployeeDirectory.DAL.Contracts.ProviderInterfaces
{
    internal interface IDataProvider
    {
        public List<Employee> GetEmployees();

        public static Dictionary<string, string[]> GetProjectDepartment()
        {
            return [];
        }

        public void AddEmployee(Employee newEmp);

        public void UpdateEmployee(Employee emp, int index);

        public Employee GetEmpById(string empId);

        public void DeleteEmployee(string id);

        public List<Role> GetRoles();

        public void AddRole(Role newRole);

    }
}
