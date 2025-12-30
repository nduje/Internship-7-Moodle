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
        public Guid Id { get; init; } = Guid.NewGuid();

        // Attributes
        public required string Title { get; set; } = string.Empty;
        public required string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; init; } = DateTime.Now;

        // Foreign Keys
        public required Guid CourseId { get; set; }

        // Navigation Properties
        public required Course Course { get; set; }

        public async Task<Result<Guid?>> Create(IAnnouncementRepository announcementRepository)
        {
            var validationResult = await CreateOrUpdateValidation();

            if (validationResult.HasError)
            {
                return new Result<Guid?>(null, validationResult);
            }

            await announcementRepository.InsertAsync(this);

            return new Result<Guid?>(Id, validationResult);
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
