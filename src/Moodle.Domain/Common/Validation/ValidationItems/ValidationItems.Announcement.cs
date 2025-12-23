namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Announcement
        {
            public static string CodePrefix = nameof(Announcement);

            public static readonly ValidationItem AnnouncementNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Obavijest ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem AnnouncementTitleRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = "Naslov obavijesti je obavezan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem AnnouncementContentRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = "Sadržaj obavijesti je obavezan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem AnnouncementTitleMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}4",
                Message = $"Naslov obavijesti ne smije biti duži od {Entities.Announcements.Announcement.TitleMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem AnnouncementContentMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}5",
                Message = $"Sadržaj obavijesti ne smije biti duži od {Entities.Announcements.Announcement.ContentMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem AnnouncementCourseNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}6",
                Message = "Kolegij obavijesti ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
};
