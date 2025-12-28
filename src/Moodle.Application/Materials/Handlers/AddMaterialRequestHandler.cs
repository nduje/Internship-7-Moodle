using Moodle.Application.Materials.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Materials;
using Moodle.Domain.Persistence.Courses;
using Moodle.Domain.Persistence.Materials;

namespace Moodle.Application.Materials.Handlers
{
    public class AddMaterialRequestHandler
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly ICourseRepository _courseRepository;

        public AddMaterialRequestHandler(IMaterialRepository materialRepository, ICourseRepository courseRepository)
        {
            _materialRepository = materialRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Result<AddMaterialResponse?>> AddMaterial(AddMaterialRequest request)
        {
            var course = await _courseRepository.GetById(request.CourseId);

            if (course == null)
            {
                return Fail(ValidationItems.Course.CourseNotFound);
            }

            var material = new Material
            {
                Name = request.Name,
                Url = request.Url,
                CourseId = request.CourseId,
                Course = course
            };

            if (await _materialRepository.GetByName(request.Name, request.CourseId) != null)
            {
                return Fail(ValidationItems.Material.MaterialDuplicate);
            }

            var result = await material.Create(_materialRepository);

            if (result.Value == null)
            {
                return new Result<AddMaterialResponse?>(null, result.ValidationResult);
            }

            var response = new AddMaterialResponse
            {
                Id = material.Id,
                Name = material.Name,
                Url = material.Url,
                CourseId = material.CourseId,
            };

            return new Result<AddMaterialResponse?>(response, result.ValidationResult);
        }

        private Result<AddMaterialResponse?> Fail(ValidationItem item)
        {
            return new Result<AddMaterialResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
