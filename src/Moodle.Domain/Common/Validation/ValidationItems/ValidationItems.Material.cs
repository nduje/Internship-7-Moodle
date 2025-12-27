namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Material
        {
            public static string CodePrefix = nameof(Material);

            public static readonly ValidationItem MaterialNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Materijal ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MaterialNameRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = "Naziv materijala je obavezan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MaterialUrlRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = "URL materijala je obavezan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MaterialNameMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}4",
                Message = $"Naziv materijala ne smije biti duži od {Entities.Materials.Material.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MaterialUrlMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}5",
                Message = $"URL materijala ne smije biti duži od {Entities.Materials.Material.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MaterialCourseNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}6",
                Message = "Kolegij materijala ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MaterialDuplicate = new ValidationItem()
            {
                Code = $"{CodePrefix}8",
                Message = "Materijal s ovim imenom već postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
};
