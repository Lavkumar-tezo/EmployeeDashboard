using EmployeeDirectory.Helpers;
using EmployeeDirectory.BAL.Validators;
namespace EmployeeDirectory
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int input;
            bool isValidInput;

            Printer.Print(true, "-----------------Welcome to Employee Directory-----------------");
            do
            {
                Printer.Print(true, "1. Employee Management", "2. Role Management", "3. Exit");
                Printer.Print(false, "Enter the choice (Numeric): ");
                try
                {
                    input = Validator.ValidateOption(Console.ReadLine() ?? "");

                    if (input < 1 || input > 3)
                    {
                        isValidInput = false;
                        Printer.Print(true, "Please enter valid input ranging from 1 to 3");
                    }
                    switch (input)
                    {
                        case 1:
                            isValidInput = false;
                            Views.Employee emp = new();
                            emp.ShowEmployeeMenu();
                            break;
                        case 2:
                            isValidInput = false;
                            Views.Role role = new();
                            role.ShowRoleMenu();
                            break;
                        default:
                            Printer.Print(true, "Program Ended");
                            isValidInput = true;
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    isValidInput = false;
                    Printer.Print(true, ex.Message);
                }

            } while (!isValidInput);
        }

    }
}