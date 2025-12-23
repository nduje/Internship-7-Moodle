namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Course
        {
            public static string CodePrefix = nameof(Course);

            public static readonly ValidationItem CourseNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Kolegij ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem CourseNameMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = $"Naziv kolegija ne smije biti duži od {Entities.Courses.Course.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem CourseDescriptionMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = $"Opis kolegija ne smije biti duži od {Entities.Courses.Course.DescriptionMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem CourseNameRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}4",
                Message = "Naziv kolegija je obavezan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
};
