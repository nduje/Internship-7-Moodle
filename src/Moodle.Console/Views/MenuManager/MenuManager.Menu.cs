using Moodle.Console.Helpers;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        public async Task UserMenuAsync()
        {
            _currentUser = null;
            _currentUser = await HandleLoginUserAsync();

            if (_currentUser == null)
            {
                return;
            }

            switch (_currentUser.Role)
            {
                case UserRole.Student:
                    await StudentMenuAsync();
                    break;
                case UserRole.Professor:
                    await ProfessorMenuAsync();
                    break;
                case UserRole.Admin:
                    await AdminMenuAsync();
                    break;
                default:
                    return;
            }
        }

        public async Task StudentMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateStudentMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
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

            _currentUser = null;
        }

        public async Task ProfessorMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateProfessorMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
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

            _currentUser = null;
        }

        public async Task AdminMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateAdminMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Admin Menu", main_menu_options);

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

            _currentUser = null;
        }

        public async Task StudentCourseMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateStudentCourseMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Course Menu", main_menu_options);

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

        public async Task ProfessorCourseMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateProfessorCourseMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Course Menu", main_menu_options);

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

        public async Task ProfessorManageCourseMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateProfessorManageCourseMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Manage Course Menu", main_menu_options);

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

        public async Task PrivateChatMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreatePrivateChatMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Private Chat Menu", main_menu_options);

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

        public async Task ManageUsersMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateManageUsersMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Manage Users Menu", main_menu_options);

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

        public async Task DeleteUsersMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateDeleteUsersMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Delete Users Menu", main_menu_options);

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

        public async Task UpdateEmailMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateUpdateEmailMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Update Email Menu", main_menu_options);

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

        public async Task ChangeRoleMenuAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateChangeRoleMenuOptions(this);

            while (!exit_requested)
            {
                System.Console.Clear();
                Writer.DisplayMenu("Moodle - Change Role Menu", main_menu_options);

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
