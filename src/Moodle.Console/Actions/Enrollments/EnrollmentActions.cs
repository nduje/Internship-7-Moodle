using Moodle.Application.Enrollments.DTOs;
using Moodle.Application.Enrollments.Handlers;

namespace Moodle.Console.Actions.Enrollments
{
    public class EnrollmentActions
    {
        private readonly AddEnrollmentRequestHandler _addEnrollmentRequestHandler;
        private readonly GetCoursesByStudentRequestHandler _getCoursesByStudentRequestHandler;
        private readonly GetStudentsByCourseRequestHandler _getStudentsByCourseRequestHandler;

        public EnrollmentActions(
            AddEnrollmentRequestHandler addEnrollmentRequestHandler,
            GetCoursesByStudentRequestHandler getCoursesByStudentRequestHandler,
            GetStudentsByCourseRequestHandler getStudentsByCourseRequestHandler)
        {
            _addEnrollmentRequestHandler = addEnrollmentRequestHandler;
            _getCoursesByStudentRequestHandler = getCoursesByStudentRequestHandler;
            _getStudentsByCourseRequestHandler = getStudentsByCourseRequestHandler;
        }

        public async Task<AddEnrollmentResponse?> AddEnrollmentAsync(Guid student_id, Guid course_id)
        {
            var result = await _addEnrollmentRequestHandler.AddEnrollment(new AddEnrollmentRequest(student_id, course_id));

            if (result.Value == null)
            {
                return null;
            }

            return new AddEnrollmentResponse
            {
                Id = result.Value.Id,
                StudentId = result.Value.StudentId,
                CourseId = result.Value.CourseId,
                EnrolledAt = result.Value.EnrolledAt
            };

        }

        public async Task<IReadOnlyList<GetCoursesByStudentResponse>> GetCoursesByStudentAsync(Guid student_id)
        {
            var result = await _getCoursesByStudentRequestHandler.GetCourses(new GetCoursesByStudentRequest(student_id));

            if (result.Value == null)
            {
                return Array.Empty<GetCoursesByStudentResponse>();
            }

            return result.Value.Select(e => new GetCoursesByStudentResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description
            }).ToList();
        }

        public async Task<IReadOnlyList<GetStudentsByCourseResponse>> GetStudentsByCourseAsync(Guid course_id)
        {
            var result = await _getStudentsByCourseRequestHandler.GetStudents(new GetStudentsByCourseRequest(course_id));

            if (result.Value == null)
            {
                return Array.Empty<GetStudentsByCourseResponse>();
            }

            return result.Value.Select(e => new GetStudentsByCourseResponse
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToList();
        }
    }
}
