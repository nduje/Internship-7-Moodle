using Moodle.Console.Helpers;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        public async Task HandleUserMenuAsync()
        {
            var user = await HandleLoginUserAsync();

            switch (user)
            {
                case UserRole.Student:
                    await HandleStudentMenuAsync();
                    break;
                case UserRole.Professor:
                    await HandleProfessorMenuAsync();
                    break;
                case UserRole.Admin:
                    await HandleAdminMenuAsync();
                    break;
                default:
                    return;
            }
        }

        public async Task HandleStudentMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateStudentMenuOptions(this);

            while (!exit_requested)
            {
                Writer.DisplayMenu("Moodle - Professor Menu", main_menu_options);

                var choice = Reader.ReadMenuChoice();

                if (main_menu_options.ContainsKey(choice))
                {
                    exit_requested = await main_menu_options[choice].Action();
                }

                else
                {
                    Writer.WriteMessage("Invalid option. Please try again.");
                }
            }
        }

        public async Task HandleProfessorMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateProfessorMenuOptions(this);

            while (!exit_requested)
            {
                Writer.DisplayMenu("Moodle - Student Menu", main_menu_options);

                var choice = Reader.ReadMenuChoice();

                if (main_menu_options.ContainsKey(choice))
                {
                    exit_requested = await main_menu_options[choice].Action();
                }

                else
                {
                    Writer.WriteMessage("Invalid option. Please try again.");
                }
            }
        }

        public async Task HandleAdminMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateAdminMenuOptions(this);

            while (!exit_requested)
            {
                Writer.DisplayMenu("Moodle - Student Menu", main_menu_options);

                var choice = Reader.ReadMenuChoice();

                if (main_menu_options.ContainsKey(choice))
                {
                    exit_requested = await main_menu_options[choice].Action();
                }

                else
                {
                    Writer.WriteMessage("Invalid option. Please try again.");
                }
            }
        }

    }
}
