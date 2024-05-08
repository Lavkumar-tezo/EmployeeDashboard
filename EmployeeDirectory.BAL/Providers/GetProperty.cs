using System.Reflection;
using EmployeeDirectory.BAL.DTO;
namespace EmployeeDirectory.BAL.Providers
{
    public class GetProperty
    {
        public static List<string> GetProperties(string className)
        {
            var propertiesList = new List<string>();
            Type type;

            if (className.Equals("Employee"))
            {
                Employee newEmp = new()
                {
                    FirstName = "",
                    LastName = "",
                    Email = "",
                    JoinDate = DateOnly.MinValue,
                    Location = "",
                    JobTitle = "",
                    Department = ""
                };
                type = newEmp.GetType();
            }
            else
            {
                DTO.Role newRole = new()
                {
                    Name = "",
                    Department = "",
                    Location = ""
                };
                type = newRole.GetType();
            }
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.GetIndexParameters().Length == 0)
                {
                    propertiesList.Add(property.Name);
                }
            }
            return propertiesList;
        }

        public static Dictionary<string, string> GetValueFromObject<T>(T obj)
        {
            var objectKeyValues = new Dictionary<string, string>();

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.GetIndexParameters().Length == 0)
                {
                    string propertyName = property.Name;
                    object propertyValue = property.GetValue(obj) ?? "default";
                    string value = propertyValue.ToString() ?? "";
                    objectKeyValues.Add(propertyName, value);
                }
            }
            return objectKeyValues;
        }
    }
}
