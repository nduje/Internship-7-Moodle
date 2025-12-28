namespace Moodle.Application.Materials.DTOs
{
    public class GetMaterialsByCourseResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Url { get; init; }
    }
}
