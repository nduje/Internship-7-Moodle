using Moodle.Application.Materials.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Materials;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Materials.Handlers
{
    public class GetMaterialsByCourseRequestHandler
    {
        private readonly IMaterialRepository _materialRepository;

        public GetMaterialsByCourseRequestHandler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Result<IReadOnlyList<GetMaterialsByCourseResponse>>> GetMaterials(GetMaterialsByCourseRequest request)
        {
            var materials = await _materialRepository.GetByCourseId(request.CourseId);

            var response = materials.Select(material => new GetMaterialsByCourseResponse
            {
                Id = material.Id,
                Name = material.Name,
                Url = material.Url
            }).ToList();

            return new Result<IReadOnlyList<GetMaterialsByCourseResponse>>(response, new ValidationResult());
        }
    }
}
