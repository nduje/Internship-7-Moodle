using Moodle.Application.Announcements.DTOs;
using Moodle.Application.Announcements.Handlers;

namespace Moodle.Console.Actions.Announcements
{
    public class AnnouncementActions
    {
        private readonly AddAnnouncementRequestHandler _addAnnouncemenetRequestHandler;
        private readonly GetAnnouncementByCourseRequestHandler _getAnnouncementByCourseRequestHandler;

        public AnnouncementActions(AddAnnouncementRequestHandler addAnnouncemenetRequestHandler, GetAnnouncementByCourseRequestHandler getAnnouncementByCourseRequestHandler)
        {
            _addAnnouncemenetRequestHandler = addAnnouncemenetRequestHandler;
            _getAnnouncementByCourseRequestHandler = getAnnouncementByCourseRequestHandler;
        }

        public async Task<AddAnnouncementResponse?> AddAnnouncementAsync(string title, string content, Guid course_id)
        {
            var result = await _addAnnouncemenetRequestHandler.AddAnnouncement(new AddAnnouncementRequest(title, content, course_id));

            if (result.Value == null)
            {
                return null;
            }

            return new AddAnnouncementResponse
            {
                Id = result.Value.Id,
                Title = result.Value.Title,
                Content = result.Value.Content,
                CreatedAt = result.Value.CreatedAt,
                CourseId = result.Value.CourseId,
                Course = result.Value.Course
            };
        }

        public async Task<IReadOnlyList<GetAnnouncementsByCourseResponse>> GetAnnouncementsByCoursesAsync(Guid course_id)
        {
            var result = await _getAnnouncementByCourseRequestHandler.GetAnnouncements(new GetAnnouncementsByCourseRequest(course_id));

            if (result.Value == null)
            {
                return Array.Empty<GetAnnouncementsByCourseResponse>();
            }

            return result.Value.Select(a => new GetAnnouncementsByCourseResponse
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedAt = a.CreatedAt
            }).ToList();
        }
    }
}
