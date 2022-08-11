using System.ComponentModel.DataAnnotations;

namespace ClientsRegistration.Application.Validations
{
    public class ReqWhenAttribute : ValidationAttribute
    {
        public List<object> ValuesToLookFor { get; set; }
        public string RelatedProperty { get; set; }

        public ReqWhenAttribute(string relatedProperty, params object[] values)
        {
            RelatedProperty = relatedProperty;
            ValuesToLookFor = new List<object>(values);
        }

        public string GetErrorMessage(ValidationContext validationContext) => $"{validationContext.DisplayName} is required when {RelatedProperty} is one of the following value [{string.Join(", ", ValuesToLookFor.Select(x => $"'{x}'"))}]";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            object valueInRelatedProperty = validationContext.ObjectType.GetProperty(RelatedProperty).GetValue(instance);
            if (!ValuesToLookFor.Contains(valueInRelatedProperty))
                return ValidationResult.Success;

            if (validationContext.ObjectType.GetProperty(validationContext.MemberName).PropertyType == typeof(string))
            {
                string inputValue = value as string;
                if (string.IsNullOrEmpty(inputValue))
                    return new ValidationResult(GetErrorMessage(validationContext));
            }

            if (value != default)
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage(validationContext));
        }
    }
}
