using Moodle.Application.Enrollments.DTOs;

namespace Moodle.Console.Helpers
{
    public static class Writer
    {
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
