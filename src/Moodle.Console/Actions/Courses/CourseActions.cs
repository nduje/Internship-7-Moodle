using Moodle.Application.Courses.DTOs;
using Moodle.Application.Courses.Handlers;

namespace Moodle.Console.Actions.Courses
{
    public class CourseActions
    {
        private readonly AddCourseRequestHandler _addCourseRequestHandler;
        private readonly GetCoursesByProfessorRequestHandler _getCoursesByProfessorRequestHandler;

        public CourseActions(AddCourseRequestHandler addCourseRequestHandler, GetCoursesByProfessorRequestHandler getCoursesByProfessorRequestHandler)
        {
            _addCourseRequestHandler = addCourseRequestHandler;
            _getCoursesByProfessorRequestHandler = getCoursesByProfessorRequestHandler;
        }

        public async Task<AddCourseResponse?> AddCourseAsync(string name, string description, Guid professor_id)
        {
            var result = await _addCourseRequestHandler.AddCourse(new AddCourseRequest(name, description, professor_id));

            if (result.Value == null)
            {
                return null;
            }

            return new AddCourseResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Description = result.Value.Description,
                ProfessorId = result.Value.ProfessorId
            };
        }

        public async Task<IReadOnlyList<GetCoursesByProfessorResponse>> GetCoursesByProfessorAsync(Guid professor_id)
        {
            var result = await _getCoursesByProfessorRequestHandler.GetCourses(new GetCoursesByProfessorRequest(professor_id));

            if (result.Value == null)
            {
                return Array.Empty<GetCoursesByProfessorResponse>();
            }

            return result.Value.Select(c => new GetCoursesByProfessorResponse
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
        }
    }
}
