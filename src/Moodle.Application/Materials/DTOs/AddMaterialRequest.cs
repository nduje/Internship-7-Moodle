namespace Moodle.Application.Materials.DTOs
{
    public class AddMaterialRequest
    {
        public string Name { get; init; }
        public string Url { get; init; }
        public Guid CourseId {  get; init; }

        public AddMaterialRequest(string name, string url, Guid course_id)
        {
            Name = name;
            Url = url;
            CourseId = course_id;
        }
    }
}
