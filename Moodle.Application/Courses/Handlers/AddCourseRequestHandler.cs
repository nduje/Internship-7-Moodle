using Moodle.Application.Courses.DTOs;
using Moodle.Domain.Common.Model;
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

            var validationResult = await course.CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<AddCourseResponse?>(null, validationResult);
            }

            var existing = await _courseRepository.GetByName(request.Name);

            if (existing != null)
            {
                validationResult.AddValidationItem(ValidationItems.Course.CourseDuplicate);

                return new Result<AddCourseResponse?>(null, validationResult);
            }

            await _courseRepository.InsertAsync(course);

            var response = new AddCourseResponse
            {
                Id = course.Id
            };

            return new Result<AddCourseResponse?>(response, validationResult);
        }
    }
}
