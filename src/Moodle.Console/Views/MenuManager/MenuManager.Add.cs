using Moodle.Console.Helpers;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Console.Views
{
    public partial class MenuManager
    {
        public async Task HandleEnrollStudent()
        {
            if (_currentUser == null)
                    throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var students = await _userActions.GetUsersAsync(UserRole.Student);

            while (true)
            {
                System.Console.Clear();
                Writer.WriteMessage($"=== Enroll Student ===\n");
                Writer.WriteStudents(students);
                Writer.WriteMessage("0. Go Back");

                var choice = Reader.ReadInt("\nSelect a student: ");

                if (choice == 0)
                    return;

                if (choice< 0 || choice> students.Count)
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

                var enrollment = await _enrollmentActions.AddEnrollmentAsync(students[choice.Value - 1].Id, _currentCourseId);

                if (enrollment == null)
                {
                    Writer.WriteMessage("\nStudent is already enrolled in the course.");
                    Writer.WaitForKey();
                    continue;
                }

                else
                {
                    Writer.WriteMessage($"\nStudent {enrollment.Student.FirstName + " " + enrollment.Student.LastName} has been enrolled in course {enrollment.Course.Name}.");
                    Writer.WaitForKey();
                    break;
                }
            }
        }

        public async Task HandlePublishAnnouncement()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var title = Reader.ReadInput("Enter announcement title (type /exit to go back):");

            if (title == "/exit")
            {
                return;
            }

            var content = Reader.ReadInput("\nEnter announcement content (type /exit to go back):");

            if (content == "/exit")
            {
                return;
            }

            var announcement = await _announcementActions.AddAnnouncementAsync(title, content, _currentCourseId);

            if (announcement == null)
            {
                Writer.WriteMessage("\nInvalid input.");
                Writer.WaitForKey();
            }

            else
            {
                Writer.WriteMessage($"\nAnnouncement '{announcement.Title}' has been added in course {announcement.Course.Name}.");
                Writer.WaitForKey();
            }
        }

        public async Task HandleAddMaterial()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            System.Console.Clear();

            var name = Reader.ReadInput("Enter material name (type /exit to go back):");

            if (name == "/exit")
            {
                return;
            }

            var url = Reader.ReadInput("\nEnter material URL (type /exit to go back):");

            if (url == "/exit")
            {
                return;
            }

            var material = await _materialActions.AddMaterialAsync(name, url, _currentCourseId);

            if (material == null)
            {
                Writer.WriteMessage("\nInvalid input.");
                Writer.WaitForKey();
            }

            else
            {
                Writer.WriteMessage($"\nMaterial '{material.Name}' has been added in course {material.Course.Name}.");
                Writer.WaitForKey();
            }
        }

        public async Task<Guid> HandleCreateConversation()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            if (_chosenUserId == Guid.Empty)
                throw new InvalidOperationException("No user is currently chosen.");

            var conversation = await _conversationActions.CreateConversationAsync(_currentUser.Id, _chosenUserId);

            _chosenUserId = Guid.Empty;

            if (conversation == null)
            {
                Writer.WriteMessage("\nInvalid input.");
                Writer.WaitForKey();
                return Guid.Empty;
            }

            else
            {
                Writer.WriteMessage($"\nConversation between " +
                    $"{conversation.User1.FirstName + " " + conversation.User1.LastName} and " +
                    $"{conversation.User2.FirstName + " " + conversation.User2.LastName} has been created.");
                Writer.WaitForKey();
                return conversation.Id;
            }
        }

        public async Task<bool> HandleSendMessage()
        {
            if (_currentUser == null)
                throw new InvalidOperationException("No user is currently logged in.");

            if (_currentConversationId == Guid.Empty)
                throw new InvalidOperationException("No conversation is currently chosen.");

            var text = Reader.ReadInput("\nEnter message text (type /exit to go back):");

            if (text == "/exit")
            {
                return true;
            }

            var message = await _messageActions.SendMessageAsync(_currentConversationId, _currentUser.Id, text);

            if (message == null)
            {
                Writer.WriteMessage("\nInvalid input.");
                Writer.WaitForKey();
            }

            else
            {
                Writer.WriteMessage($"\nMessage by {_currentUser.FirstName + " " + _currentUser.LastName} has been sent.");
                Writer.WaitForKey();
            }

            return false;
        }
    }
}
