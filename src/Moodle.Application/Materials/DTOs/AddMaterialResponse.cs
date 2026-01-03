using Moodle.Domain.Entities.Courses;

namespace Moodle.Application.Materials.DTOs
{
    public  class AddMaterialResponse
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Url { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required Guid CourseId { get; init; }
        public required Course Course { get; init; }
    }
}
