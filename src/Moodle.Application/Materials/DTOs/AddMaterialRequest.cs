namespace Moodle.Application.Materials.DTOs
{
    public class AddMaterialRequest
    {
        public required string Name { get; init; }
        public required string Url { get; init; }
        public required Guid CourseId {  get; init; }
    }
}
