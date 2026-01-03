using Moodle.Console.Actions.Users;
using Moodle.Console.Helpers;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        public async Task ShowStudentCoursesAsync()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var courses = await _enrollmentActions.GetCoursesByStudentAsync(_currentUser.Id);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== {_currentUser.FirstName}'s Courses ===\n");
                Writer.WriteStudentCourses(courses);
                Writer.WriteMessage("0: Go Back");

                var choice = Reader.ReadInt("\nSelect a course: ");

                if (choice == 0)
                    return;

                if (choice < 0 || choice > courses.Count)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                if (!choice.HasValue)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                _currentCourseId = courses[choice.Value - 1].Id;
                
                await StudentCourseMenuAsync();
            }
        }

        public async Task ShowProfessorCoursesAsync(bool manage_courses)
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var courses = await _courseActions.GetCoursesByProfessorAsync(_currentUser.Id);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== {_currentUser.FirstName}'s Courses ===\n");
                Writer.WriteProfessorCourses(courses);
                Writer.WriteMessage("0: Go Back");

                var choice = Reader.ReadInt("\nSelect a course: ");

                if (choice == 0)
                    return;

                if (choice < 0 || choice > courses.Count)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                if (!choice.HasValue)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                _currentCourseId = courses[choice.Value - 1].Id;

                if (!manage_courses)
                    await ProfessorCourseMenuAsync();

                else
                    await ProfessorManageCourseMenuAsync();

            }
        }

        public async Task ShowCourseStudentsAsync()
        {
            if (_currentCourseId == Guid.Empty)
                throw new InvalidOperationException("No course has been selected.");

            System.Console.Clear();

            var students = await _enrollmentActions.GetStudentsByCourseAsync(_currentCourseId);

            Writer.WriteMessage($"=== Students ===\n");
            Writer.WriteCourseStudents(students);
            Writer.WaitForKey();
        }

        public async Task ShowCourseMaterialsAsync()
        {
            if (_currentCourseId == Guid.Empty)
                throw new InvalidOperationException("No course has been selected.");

            System.Console.Clear();

            var materials = await _materialActions.GetMaterialsByCourseAsync(_currentCourseId);

            Writer.WriteMessage($"=== Materials ===\n");
            Writer.WriteCourseMaterials(materials);
            Writer.WaitForKey();
        }

        public async Task ShowCourseAnnouncementsAsync()
        {
            if (_currentCourseId == Guid.Empty)
                throw new InvalidOperationException("No course has been selected.");

            System.Console.Clear();

            var announcements = await _announcementActions.GetAnnouncementsByCoursesAsync(_currentCourseId);

            Writer.WriteMessage($"=== Announcements ===\n");
            Writer.WriteCourseAnnouncements(announcements);
            Writer.WaitForKey();
        }

        public async Task ShowNewChatsAsync()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var conversations = await _conversationActions.GetNonChatUsersAsync(_currentUser.Id);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== {_currentUser.FirstName}'s New Chats ===\n");
                Writer.WriteNewChatUsers(conversations);
                Writer.WriteMessage("0: Go Back");

                var choice = Reader.ReadInt("\nSelect an user: ");

                if (choice == 0)
                    return;

                if (choice < 0 || choice > conversations.Count)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                if (!choice.HasValue)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                _chosenUserId = conversations[choice.Value - 1].Id;

                _currentConversationId = await HandleCreateConversationAsync();

                if (_currentConversationId == Guid.Empty)
                {
                    return;
                }

                await HandleSendMessageAsync();
                _currentConversationId = Guid.Empty;

                return;
            }
        }

        public async Task ShowChatsAsync()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var conversations = await _conversationActions.GetChatUsersAsync(_currentUser.Id);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== {_currentUser.FirstName}'s Chats ===\n");
                Writer.WriteChatUsers(conversations);
                Writer.WriteMessage("0: Go Back");

                var choice = Reader.ReadInt("\nSelect an user: ");

                if (choice == 0)
                    return;

                if (choice < 0 || choice > conversations.Count)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                if (!choice.HasValue)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                _currentConversationId = conversations[choice.Value - 1].ConversationId;

                await HandleOpenChatAsync();
            }
        }

        public async Task ShowMessagesAsync()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user has been selected.");

            if (_currentConversationId == Guid.Empty)
                throw new InvalidOperationException("No conversation has been selected.");

            System.Console.Clear();

            var messages = await _messageActions.GetMessagesByConversationAsync(_currentConversationId, _currentUser.Id);

            Writer.WriteMessage($"=== Messages ===\n");
            Writer.WriteMessages(messages);
        }

        public async Task HandleOpenChatAsync()
        {
            while (true)
            {
                if (_currentConversationId == Guid.Empty)
                {
                    return;
                }

                await ShowMessagesAsync();
                var exit_required = await HandleSendMessageAsync();

                if (exit_required)
                {
                    _currentConversationId = Guid.Empty;
                    return;
                }
            }
        }
        
        public async Task<bool> ShowStudentsAsync()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var students = await _userActions.GetUsersAsync(UserRole.Student);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== Students ===\n");
                Writer.WriteUsers(students);
                Writer.WriteMessage("0: Go Back");

                var choice = Reader.ReadInt("\nSelect a student: ");

                if (choice == 0)
                    return true;

                if (choice < 0 || choice > students.Count)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                if (!choice.HasValue)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                _chosenUserId = students[choice.Value - 1].Id;
                return false;
            }
        }

        public async Task<bool> ShowProfessorsAsync()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var professors = await _userActions.GetUsersAsync(UserRole.Professor);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== Professors ===\n");
                Writer.WriteUsers(professors);
                Writer.WriteMessage("0: Go Back");

                var choice = Reader.ReadInt("\nSelect a professor: ");

                if (choice == 0)
                    return true;

                if (choice < 0 || choice > professors.Count)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                if (!choice.HasValue)
                {
                    Writer.WriteMessage("Invalid selection, try again.");
                    Writer.WaitForKey();
                    continue;
                }

                _chosenUserId = professors[choice.Value - 1].Id;
                return false;
            }
        }
    }
}
