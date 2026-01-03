using Moodle.Console.Actions.Announcements;
using Moodle.Console.Actions.Conversations;
using Moodle.Console.Actions.Courses;
using Moodle.Console.Actions.Enrollments;
using Moodle.Console.Actions.Materials;
using Moodle.Console.Actions.Messages;
using Moodle.Console.Actions.Users;
using Moodle.Console.Helpers;
using Moodle.Domain.Entities.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        private readonly UserActions _userActions;
        private readonly CourseActions _courseActions;
        private readonly EnrollmentActions _enrollmentActions;
        private readonly MaterialActions _materialActions;
        private readonly AnnouncementActions _announcementActions;
        private readonly ConversationActions _conversationActions;
        private readonly MessageActions _messageActions;

        private User? _currentUser;

        public MenuManager(
            UserActions userActions,
            CourseActions courseActions,
            EnrollmentActions enrollmentActions,
            MaterialActions materialActions,
            AnnouncementActions announcementActions,
            ConversationActions conversationActions,
            MessageActions messageActions)
        {
            _userActions = userActions;
            _courseActions = courseActions;
            _enrollmentActions = enrollmentActions;
            _materialActions = materialActions;
            _announcementActions = announcementActions;
            _conversationActions = conversationActions;
            _messageActions = messageActions;
            _currentUser = null;
        }

        public async Task RunAsync()
        {
            bool exit_requested = false;

            var main_menu_options = MenuOptions.CreateMainMenuOptions(this);

            while (!exit_requested)
            {
                Writer.DisplayMenu("Moodle - Main Menu", main_menu_options);

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
        
        public Task Placeholder()
        {
            return Task.CompletedTask;
        }
    }
}
