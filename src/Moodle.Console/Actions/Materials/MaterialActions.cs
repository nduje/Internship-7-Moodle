using Moodle.Application.Materials.DTOs;
using Moodle.Application.Materials.Handlers;

namespace Moodle.Console.Actions.Materials
{
    public class MaterialActions
    {
        private readonly AddMaterialRequestHandler _addMaterialRequestHandler;
        private readonly GetMaterialsByCourseRequestHandler _getMaterialsByCourseRequestHandler;
        
        public MaterialActions(AddMaterialRequestHandler addMaterialRequestHandler, GetMaterialsByCourseRequestHandler getMaterialsByCourseRequestHandler)
        {
            _addMaterialRequestHandler = addMaterialRequestHandler;
            _getMaterialsByCourseRequestHandler = getMaterialsByCourseRequestHandler;
        }

        public async Task<AddMaterialResponse?> AddMaterialAsync(string name, string url, Guid course_id)
        {
            var result = await _addMaterialRequestHandler.AddMaterial(new AddMaterialRequest(name, url, course_id));

            if (result.Value == null)
            {
                return null;
            }

            return new AddMaterialResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Url = result.Value.Url,
                CreatedAt = result.Value.CreatedAt,
                CourseId = result.Value.CourseId,
                Course = result.Value.Course
            };
        }

        public async Task<IReadOnlyList<GetMaterialsByCourseResponse>> GetMaterialsByCourseAsync(Guid course_id)
        {
            var result = await _getMaterialsByCourseRequestHandler.GetMaterials(new GetMaterialsByCourseRequest(course_id));

            if (result.Value == null)
            {
                return Array.Empty<GetMaterialsByCourseResponse>();
            }

            return result.Value.Select(m => new GetMaterialsByCourseResponse
            {
                Id = m.Id,
                Name = m.Name,
                Url = m.Url,
                CreatedAt = m.CreatedAt
            }).ToList();
        }
    }
}
