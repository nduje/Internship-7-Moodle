using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Courses;
using Moodle.Domain.Persistence.Announcements;

namespace Moodle.Domain.Entities.Announcements
{
    public class Announcement
    {
        public const int TitleMaxLength = 128;
        public const int ContentMaxLength = 1024;

        // Primary Key
        public required int Id { get; set; }

        // Attributes
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        // Foreign Keys
        public required int CourseId { get; set; }

        // Navigation Properties
        public required Course Course { get; set; }

        public async Task<Result<int?>> Create(IAnnouncementRepository announcementRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<int?>(null, validationResult);
            }

            await announcementRepository.InsertAsync(this);

            return new Result<int?>(Id, validationResult);
        }

        public async Task<ValidationResult> CreateOrUpdateValidation()
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Title))
                validationResult.AddValidationItem(ValidationItems.Announcement.AnnouncementTitleRequired);

            if (Title.Length > TitleMaxLength)
                validationResult.AddValidationItem(ValidationItems.Announcement.AnnouncementTitleMaxLength);

            if (string.IsNullOrWhiteSpace(Content))
                validationResult.AddValidationItem(ValidationItems.Announcement.AnnouncementContentRequired);

            if (Content.Length > ContentMaxLength)
                validationResult.AddValidationItem(ValidationItems.Announcement.AnnouncementContentMaxLength);

            if (Course == null)
                validationResult.AddValidationItem(ValidationItems.Announcement.AnnouncementCourseNotFound);

            return validationResult;
        }
    }
}
