using Moodle.Application.Courses.DTOs;
using Moodle.Application.Materials.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Persistence.Courses;

namespace Moodle.Application.Courses.Handlers
{
    public class AddCourseRequestHandler
    {
        private readonly ICourseRepository _courseRepository;

        public AddCourseRequestHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Result<AddCourseResponse?>> AddCourse(AddCourseRequest request)
        {
            var course = new Course
            {
                Name = request.Name,
                Description = request.Description,
                ProfessorId = request.ProfessorId
            };

            if (await _courseRepository.GetByName(request.Name) != null)
            {
                return Fail(ValidationItems.Course.CourseDuplicate);
            }

            var result = await course.Create(_courseRepository);

            if (result.Value == null)
            {
                return new Result<AddCourseResponse?>(null, result.ValidationResult);
            }

            var response = new AddCourseResponse
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ProfessorId = course.ProfessorId
            };

            return new Result<AddCourseResponse?>(response, result.ValidationResult);
        }

        private Result<AddCourseResponse?> Fail(ValidationItem item)
        {
            return new Result<AddCourseResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
