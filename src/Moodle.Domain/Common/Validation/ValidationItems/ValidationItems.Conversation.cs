namespace Moodle.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class Conversation
        {
            public static string CodePrefix = nameof(Conversation);

            public static readonly ValidationItem ConversationNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Razgovor ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem ConversationUser1NotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = "Korisnik 1 ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem ConversationUser2NotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}3",
                Message = "Korisnik 2 ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem ConversationSameUsers = new ValidationItem()
            {
                Code = $"{CodePrefix}4",
                Message = "Korisnici u razgovoru ne mogu biti isti",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
};
