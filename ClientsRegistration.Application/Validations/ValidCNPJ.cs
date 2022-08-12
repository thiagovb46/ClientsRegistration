using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace ClientsRegistration.Application.Validations
{
    public class ValidCNPJ : ValidationAttribute
    {
        public string GetErrorMessage()
        {
            return "O CNPJ informado é invalido";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var cnpj = value as string;
            if (CnpjValidation.Validate(cnpj))
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
