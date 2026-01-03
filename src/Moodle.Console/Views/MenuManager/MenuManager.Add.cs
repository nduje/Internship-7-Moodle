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
    }
}
