namespace Moodle.Application.Materials.DTOs
{
    public class GetMaterialsByCourseRequest
    {
        public Guid CourseId { get; init; }
    
        public GetMaterialsByCourseRequest(Guid course_id)
        {
            CourseId = course_id;
        }
    }
}
