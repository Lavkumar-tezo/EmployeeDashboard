using EmployeeDirectory.DAL.DataOperations;
using EmployeeDirectory.BAL.Interfaces;
using System.Text.Json;
namespace EmployeeDirectory.BAL.Providers
{
    public class RoleProvider : IRoleProvider, IComparer<DAL.Models.Role>
    {
        private readonly DataOperations _dataOperations;

        public RoleProvider()
        {
            _dataOperations = new DataOperations();
        }

        public void AddRole(Dictionary<string, string> inputs)
        {
            DAL.Models.Role role = new()
            {
                Name = inputs["Name"],
                Location = inputs["Location"],
                Department = inputs["Department"],
                Description = inputs["Description"],
                Id = GenerateRoleId()
            };
            _dataOperations.AddRole(role);
        }

        private string GenerateRoleId()
        {
            try
            {
                List<DAL.Models.Role> roles = _dataOperations.GetRoles();
                roles.Sort(Compare);
                string LastRoleId = roles[^1].Id ?? "";
                int lastRoleNumber = int.Parse(LastRoleId.Substring(2));
                lastRoleNumber++;
                string newId = "IN" + lastRoleNumber.ToString("D3");
                return newId;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
        }

        public int Compare(DAL.Models.Role? x, DAL.Models.Role? y)
        {
            if (x != null && y != null)
            {
                return x.Id.CompareTo(y.Id);
            }
            return 0;
        }

        public List<DAL.Models.Role> GetRoles()
        {
            try
            {
                return _dataOperations.GetRoles();
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
