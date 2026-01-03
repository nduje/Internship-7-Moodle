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
    }
}
