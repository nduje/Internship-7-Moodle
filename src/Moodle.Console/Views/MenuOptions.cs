namespace Moodle.Console.Views
{
    public class MenuOptions
    {
        private readonly Dictionary<string, (string Description, Func<Task<bool>> Action)> _options;

        public MenuOptions()
        {
            _options = [];
        }

        public MenuOptions AddOption(string key, string description, Func<Task<bool>> action)
        {
            _options.Add(key, (description, action));
            return this;
        }

        public Dictionary<string, (string Description, Func<Task<bool>> Action)> Build()
        {
            return _options;
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateMainMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "Login", async () => { await menuManager.UserMenuAsync(); System.Console.Clear(); return false; })
                .AddOption("2", "Registration", async () => { await menuManager.HandleRegisterUserAsync(); System.Console.Clear(); return false; })
                .AddOption("3", "Exit", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }
        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateStudentMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "My Courses", async () => { await menuManager.ShowStudentCoursesAsync(); System.Console.Clear(); return false; })
                .AddOption("2", "Private Chat", async () => { await menuManager.PrivateChatMenuAsync(); System.Console.Clear(); return false; })
                .AddOption("3", "Logout", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateProfessorMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "My Courses", async () => { await menuManager.ShowProfessorCoursesAsync(false); System.Console.Clear(); return false; })
                .AddOption("2", "Manage Courses", async () => { await menuManager.ShowProfessorCoursesAsync(true); System.Console.Clear(); return false; })
                .AddOption("3", "Private Chat", async () => { await menuManager.PrivateChatMenuAsync(); System.Console.Clear(); return false; })
                .AddOption("4", "Logout", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateAdminMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "Manage Users", async () => { await menuManager.Placeholder(); System.Console.Clear(); return false; })
                .AddOption("2", "Private Chat", async () => { await menuManager.PrivateChatMenuAsync(); System.Console.Clear(); return false; })
                .AddOption("3", "Logout", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateStudentCourseMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "Announcements", async () => { await menuManager.ShowCourseAnnouncementsAsync(); System.Console.Clear(); return false; })
                .AddOption("2", "Materials", async () => { await menuManager.ShowCourseMaterialsAsync(); System.Console.Clear(); return false; })
                .AddOption("3", "Go Back", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateProfessorCourseMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "Enrolled Students", async () => { await menuManager.ShowCourseStudentsAsync(); System.Console.Clear(); return false; })
                .AddOption("2", "Announcements", async () => { await menuManager.ShowCourseAnnouncementsAsync(); System.Console.Clear(); return false; })
                .AddOption("3", "Materials", async () => { await menuManager.ShowCourseMaterialsAsync(); System.Console.Clear(); return false; })
                .AddOption("4", "Go Back", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreateProfessorManageCourseMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "Enroll Student", async () => { await menuManager.HandleEnrollStudent(); System.Console.Clear(); return false; })
                .AddOption("2", "Publish Announcement", async () => { await menuManager.HandlePublishAnnouncement(); System.Console.Clear(); return false; })
                .AddOption("3", "Add Material", async () => { await menuManager.HandleAddMaterial(); System.Console.Clear(); return false; })
                .AddOption("4", "Go Back", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }

        public static Dictionary<string, (string Description, Func<Task<bool>> Action)> CreatePrivateChatMenuOptions(MenuManager menuManager)
        {
            return new MenuOptions()
                .AddOption("1", "New Message", async () => { await menuManager.ShowNewChatsAsync(); System.Console.Clear(); return false; })
                .AddOption("2", "My Conversations", async () => { await menuManager.ShowChatsAsync(); System.Console.Clear(); return false; })
                .AddOption("3", "Go Back", async () => { System.Console.WriteLine("Exiting application..."); return true; })
                .Build();
        }
    }
}
