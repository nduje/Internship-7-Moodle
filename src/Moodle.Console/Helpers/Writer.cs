using Moodle.Application.Announcements.DTOs;
using Moodle.Application.Courses.DTOs;
using Moodle.Application.Enrollments.DTOs;
using Moodle.Application.Materials.DTOs;
using Moodle.Application.Users.DTOs;

namespace Moodle.Console.Helpers
{
    public static class Writer
    {
        public static void WriteStudents(IReadOnlyList<GetUsersResponse> students)
        {
            var studentList = students.ToList();

            if (!studentList.Any())
            {
                System.Console.Clear();
                WriteMessage("No students found.");
                WaitForKey();
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                var student = studentList[i];

                System.Console.WriteLine($"{i + 1}. First Name: {student.FirstName}\n" +
                    $"   Last Name: {student.LastName}\n" +
                    $"   Email: {student.Email}\n");
            }
        }

        public static void WriteStudentCourses(IReadOnlyList<GetCoursesByStudentResponse> courses)
        {
            var courseList = courses.ToList();

            if (!courseList.Any())
            {
                System.Console.Clear();
                WriteMessage("No courses found.");
                WaitForKey();
                return;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                var course = courseList[i];

                var professor = course.Professor != null
                    ? $"{course.Professor.FirstName} {course.Professor.LastName}"
                    : "N/A";

                System.Console.WriteLine($"{i + 1}. Name: {course.Name}\n" +
                    $"   Description: {course.Description ?? "N/A"}\n" +
                    $"   Professor: {professor}\n");
            }
        }

        public static void WriteProfessorCourses(IReadOnlyList<GetCoursesByProfessorResponse> courses)
        {
            var courseList = courses.ToList();

            if (!courseList.Any())
            {
                System.Console.Clear();
                WriteMessage("No courses found.");
                WaitForKey();
                return;
            }

            for (int i = 0; i < courses.Count; i++)
            {
                var course = courseList[i];

                System.Console.WriteLine($"{i + 1}. Name: {course.Name}\n" +
                    $"   Description: {course.Description ?? "N/A"}\n");
            }
        }

        public static void WriteCourseStudents(IReadOnlyList<GetStudentsByCourseResponse> students)
        {
            var studentList = students.ToList();

            if (!studentList.Any())
            {
                System.Console.Clear();
                WriteMessage("No students found.");
                WaitForKey();
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                var student = studentList[i];

                System.Console.WriteLine($"{i + 1}. First Name: {student.FirstName}\n" +
                    $"   Last Name: {student.LastName}\n" +
                    $"   Email: {student.Email}\n");
            }
        }

        public static void WriteCourseMaterials(IReadOnlyList<GetMaterialsByCourseResponse> materials)
        {
            var materialList = materials.ToList();

            if (!materialList.Any())
            {
                System.Console.Clear();
                WriteMessage("No materials found.");
                WaitForKey();
                return;
            }

            for (int i = 0; i < materials.Count; i++)
            {
                var material = materialList[i];

                System.Console.WriteLine($"{i + 1}. Name: {material.Name}\n" +
                    $"   Description: {material.Url ?? "N/A"}\n" +
                    $"   Created At: {material.CreatedAt}\n");
            }
        }

        public static void WriteCourseAnnouncements(IReadOnlyList<GetAnnouncementsByCourseResponse> announcements)
        {
            var announcementsList = announcements.ToList();

            if (!announcementsList.Any())
            {
                System.Console.Clear();
                WriteMessage("No materials found.");
                WaitForKey();
                return;
            }

            for (int i = 0; i < announcements.Count; i++)
            {
                var announcement = announcementsList[i];

                System.Console.WriteLine($"{i + 1}. Name: {announcement.Title}\n" +
                    $"   Description: {announcement.Content ?? "N/A"}\n" +
                    $"   Created At: {announcement.CreatedAt}\n");
            }
        }

        public static void DisplayMenu(string title, Dictionary<string, (string Description, Func<Task<bool>> Action)> options)
        {
            System.Console.WriteLine($"=== {title} ===");

            foreach (var option in options)
            {
                System.Console.WriteLine($"{option.Key}: {option.Value.Description}");
            }
        }

        public static void WriteMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        public static void WaitForKey()
        {
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}
