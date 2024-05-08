﻿using EmployeeDirectory.BAL.Providers;
using EmployeeDirectory.BAL.Validators;
using EmployeeDirectory.Helpers;
using System.Text.Json;
using EmployeeDirectory.BAL.Helper;
namespace EmployeeDirectory.Views
{
    public class Role
    {
        private readonly Validator _validator;
        private readonly BAL.Providers.RoleProvider _roleProvider;

        public Role()
        {
            _validator = new Validator();
            _roleProvider = new BAL.Providers.RoleProvider();
        }

        public void ShowRoleMenu()
        {
            int input;

        startRoleMenu: Printer.Print(true, "---------Role Management Menu---------", "1. Add Role", "2. Display All", "3. Go Back");
            input = ChoiceTaker.CheckChoice(1, 3);
            switch (input)
            {
                case 1:
                    AddRole();
                    goto NextProcess;
                case 2:
                    DisplayRoleList();
                    goto NextProcess;
                case 3:
                    Printer.Print(true, "Welcome Back to Main Menu");
                    break;
            }
        NextProcess: Printer.Print(true, "Where do u want to go", "1. Go to Main Menu", "2. Go to Previous Menu");
            input = ChoiceTaker.CheckChoice(1, 2);
            switch (input)
            {
                case 1:
                    Printer.Print(true, "Welcome Back to Main Menu");
                    break;
                case 2:
                    goto startRoleMenu;

            }
        }

        private void AddRole()
        {
            try
            {
                List<string> inputFields = GetProperty.GetProperties("Role");
                bool isAllInputCorrect = true;

                Printer.Print(true, "Enter the details of New Role (* represents required fields)");
                do
                {
                    foreach (var inputName in inputFields)
                    {
                        if (MessagesInputStore.validationMessages.ContainsKey(inputName) || isAllInputCorrect)
                        {
                            Printer.Print(false, inputName);
                            MessagesInputStore.inputFieldValues[inputName] = Console.ReadLine() ?? "";
                        }
                    }
                    isAllInputCorrect = _validator.ValidateRoleInputs(ref isAllInputCorrect);
                    if (!isAllInputCorrect)
                    {
                        foreach (var item in MessagesInputStore.validationMessages)
                        {
                            Printer.Print(true, item.Value);
                        }
                    }
                } while (!isAllInputCorrect);
                MessagesInputStore.validationMessages.Clear();
                _roleProvider.AddRole(MessagesInputStore.inputFieldValues);
                MessagesInputStore.inputFieldValues.Clear();
                Printer.Print(true, "Role Added");
            }
            catch (JsonException ex)
            {
                Printer.Print(true, ex.Message);
            }

        }

        private void DisplayRoleList()
        {
            try
            {
                List<DAL.Models.Role> RoleList = _roleProvider.GetRoles();
                if (RoleList == null)
                {
                    Console.WriteLine("No role found");
                }
                else
                {
                    for (int i = 0; i < RoleList.Count; i++)
                    {
                        DisplayRole(RoleList[i]);
                    }
                }
            }
            catch (JsonException ex)
            {
                Printer.Print(true, ex.Message);
            }

        }

        private void DisplayRole(DAL.Models.Role role)
        {
            Console.WriteLine($"Name: {role.Name} -- Department: {role.Department} -- Location: {role.Location} -- Description: {role.Description}");
        }
    }
}