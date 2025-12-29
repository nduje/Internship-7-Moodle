using Moodle.Application.Enrollments.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Enrollments.Handlers
{
    public class GetStudentsByCourseRequestHandler
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetStudentsByCourseRequestHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Result<IReadOnlyList<GetStudentsByCourseResponse>>> GetStudents(GetStudentsByCourseRequest request)
        {
            var students = await _enrollmentRepository.GetStudentsByCourseId(request.CourseId);

            var response = students.Select(student => new GetStudentsByCourseResponse
            {
                Id = student.Id,
               FirstName = student.FirstName,
               LastName = student.LastName,
               Email = student.Email
            }).ToList();

            return new Result<IReadOnlyList<GetStudentsByCourseResponse>>(response, new ValidationResult());
        }
    }
}
