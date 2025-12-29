using Moodle.Application.Enrollments.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Enrollments.Handlers
{
    public class GetCoursesByStudentRequestHandler
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetCoursesByStudentRequestHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Result<IReadOnlyList<GetCoursesByStudentResponse>>> GetCourses(GetCoursesByStudentRequest reqeust)
        {
            var courses = await _enrollmentRepository.GetCoursesByStudentId(reqeust.StudentId);

            var response = courses.Select(course => new GetCoursesByStudentResponse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            }).ToList();

            return new Result<IReadOnlyList<GetCoursesByStudentResponse>>(response, new ValidationResult());
        }
    }
}
