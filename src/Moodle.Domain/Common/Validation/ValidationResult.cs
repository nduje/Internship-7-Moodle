using Moodle.Domain.Common.Model;

namespace Moodle.Domain.Common.Validation
{
    public class ValidationResult
    {
        private List<ValidationItem> _validationItems = new List<ValidationItem>();
        public IReadOnlyList<ValidationItem> ValidationItems => _validationItems.AsReadOnly();

        public bool HasInfo => _validationItems.Any(validationResult => validationResult.ValidationSeverity == ValidationSeverity.Info);
        public bool HasWarning => _validationItems.Any(validationResult => validationResult.ValidationSeverity == ValidationSeverity.Warning);
        public bool HasError => _validationItems.Any(validationResult => validationResult.ValidationSeverity == ValidationSeverity.Error);

        public ValidationResult AddValidationItem(ValidationItem validationItem)
        {
            _validationItems.Add(validationItem);

            return this;
        }

        public ValidationResult AddValidationItems(IEnumerable<ValidationItem> items)
        {
            if (items != null && items.Any())
                _validationItems.AddRange(items);

            return this;
        }
    }
}
