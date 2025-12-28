using Moodle.Application.Courses.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Courses;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Courses.Handlers
{
    public class GetCoursesByProfessorRequestHandler
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesByProfessorRequestHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Result<IReadOnlyList<GetCoursesByProfessorResponse>>> GetCourses(GetCoursesByProfessorRequest request)
        {
            var courses = await _courseRepository.GetByProfessorId(request.ProfessorId);

            var response = courses.Select(course => new GetCoursesByProfessorResponse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description
            }).ToList();

            return new Result<IReadOnlyList<GetCoursesByProfessorResponse>>(response, new ValidationResult());
        }
    }
}
