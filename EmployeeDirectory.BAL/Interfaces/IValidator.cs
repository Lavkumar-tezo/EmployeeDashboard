
namespace EmployeeDirectory.BAL.Interfaces
{
    internal interface IValidator
    {
        bool ValidateEmployeeInputs(string mode, ref bool isAllInputCorrect);

        bool ValidateRoleInputs(ref bool isAllInputCorrect);
    }
}
