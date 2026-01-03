using Moodle.Console.Actions.Users;
using Moodle.Console.Helpers;

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
                Writer.WriteMessage("0. Go Back");

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

                var course = courses[choice.Value - 1].Id;
            }
        }
    }
}
