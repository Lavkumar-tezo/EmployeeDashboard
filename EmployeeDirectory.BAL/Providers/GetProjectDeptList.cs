using EmployeeDirectory.DAL.DataOperations;
using System.Globalization;
using System.Text.Json;
namespace EmployeeDirectory.BAL.Providers
{
    public class GetProjectDeptList
    {
        /// <summary>
        /// Gets the static data for department or project.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>List of Department or Project</returns>
        public static string[] GetStaticData(string input)
        {
            try
            {
                Dictionary<string, string[]> list = DataOperations.GetProjectDepartment();
                return list[input];
            }
            catch (IOException)
            {
                throw;
            }
            catch (JsonException)
            {
                throw;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }

        }
    }
}
