using Moodle.Application.Announcements.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Persistence.Announcements;
using Moodle.Domain.Common.Validation;

namespace Moodle.Application.Announcements.Handlers
{
    public class GetAnnouncementByCourseRequestHandler
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public GetAnnouncementByCourseRequestHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<Result<IReadOnlyList<GetAnnouncementsByCourseResponse>>> GetAnnouncements(GetAnnouncementsByCourseRequest request)
        {
            var announcements = await _announcementRepository.GetByCourseId(request.CourseId);

            var response = announcements.Select(announcement => new GetAnnouncementsByCourseResponse
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Content = announcement.Content,
                CreatedAt = announcement.CreatedAt
            }).ToList();

            return new Result<IReadOnlyList<GetAnnouncementsByCourseResponse>>(response, new ValidationResult());
        }
    }
}
