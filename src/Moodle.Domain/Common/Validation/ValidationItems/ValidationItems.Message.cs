namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Message
        {
            public static string CodePrefix = nameof(Message);

            public static readonly ValidationItem MessageNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Poruka ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MessageTextMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = $"Tekst poruke ne smije biti duži od {Entities.Messages.Message.TextMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MessageTextRequired = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = "Tekst poruke je obavezan",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MessageConversationNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}4",
                Message = "Razgovor ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem MessageUserNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}5",
                Message = "Korisnik ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
};
