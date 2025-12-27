namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem UserNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Korisnik ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem FirstNameMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = $"Ime korisnika ne smije biti duže od {Entities.Users.User.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem LastNameMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = $"Prezime korisnika ne smije biti duže od {Entities.Users.User.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EmailMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}4",
                Message = $"Email adresa korisnika ne smije biti duže od {Entities.Users.User.EmailMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem PasswordMinLength = new ValidationItem()
            {
                Code = $"{CodePrefix}5",
                Message = $"Lozinka ne smije biti kraća od {Entities.Users.User.PasswordMinLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem PasswordMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}6",
                Message = $"Lozinka ne smije biti duža od {Entities.Users.User.PasswordMinLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem FirstNameRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}7",
                Message = "Ime korisnika je obavezno",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem LastNameRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}8",
                Message = "Prezime korisnika je obavezno",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EmailRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}9",
                Message = "Email adresa korisnika je obavezna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem PasswordRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}10",
                Message = "Lozinka je obavezna",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EmailInvalidFormat = new ValidationItem()
            {
                Code = $"{CodePrefix}11",
                Message = "Email adresa nije ispravnog formata",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem PasswordInvalidFormat = new ValidationItem()
            {
                Code = $"{CodePrefix}12",
                Message = "Lozinka nije ispravnog formata",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem EmailAlreadyExists = new ValidationItem()
            {
                Code = $"{CodePrefix}13",
                Message = "Email adresa je već u uporabi",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem DateOfBirthInFuture = new ValidationItem()
            {
                Code = $"{CodePrefix}14",
                Message = "Datum rođenja ne može biti u budućnosti",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem InvalidUserRole = new ValidationItem()
            {
                Code = $"{CodePrefix}15",
                Message = "Neispravna korisnička uloga",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem InvalidCredentials = new ValidationItem()
            {
                Code = $"{CodePrefix}16",
                Message = "Neispravni pristupni podaci",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
}
