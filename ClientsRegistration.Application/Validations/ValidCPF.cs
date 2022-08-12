using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace ClientsRegistration.Application.Validations
{
    public class ValidCPF : ValidationAttribute
    {
        public string GetErrorMessage()
        {
            return "O CPF informado é invalido";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            var cpf = value as string;
            if (CpfValidation.Validate(cpf) || cpf == null)
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
