using Moodle.Application.Announcements.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Persistence.Announcements;
using Moodle.Domain.Persistence.Courses;
using Moodle.Domain.Entities.Announcements;

namespace Moodle.Application.Announcements.Handlers
{
    public class AddAnnouncementRequestHandler
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly ICourseRepository _courseRepository;

        public AddAnnouncementRequestHandler(IAnnouncementRepository announcementRepository, ICourseRepository courseRepository)
        {
            _announcementRepository = announcementRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Result<AddAnnouncementResponse?>> AddAnnouncement(AddAnnouncementRequest request)
        {
            var course = await _courseRepository.GetById(request.CourseId);

            if (course == null)
            {
                return Fail(ValidationItems.Course.CourseNotFound);
            }

            var announcement = new Announcement
            {
                Title = request.Title,
                Content = request.Content,
                CourseId = request.CourseId,
                Course = course
            };

            if (await _announcementRepository.GetByTitle(request.Title, request.CourseId) != null)
            {
                return Fail(ValidationItems.Announcement.AnnouncementDuplicate);
            }

            var result = await announcement.Create(_announcementRepository);

            if (result.Value == null)
            {
                return new Result<AddAnnouncementResponse?>(null, result.ValidationResult);
            }

            var response = new AddAnnouncementResponse
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Content = announcement.Content,
                CreatedAt = announcement.CreatedAt,
                CourseId = announcement.CourseId
            };

            return new Result<AddAnnouncementResponse?>(response, result.ValidationResult);
        }

        private Result<AddAnnouncementResponse?> Fail(ValidationItem item)
        {
            return new Result<AddAnnouncementResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
