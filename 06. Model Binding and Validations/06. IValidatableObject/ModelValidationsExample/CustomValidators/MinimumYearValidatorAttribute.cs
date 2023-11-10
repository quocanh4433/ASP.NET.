using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { set; get; } = 2000;
        public string DefaultErrorMessage { set; get; } = "Minimum year allowed is {0}";
        public MinimumYearValidatorAttribute(int minimumYear) { 
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if(date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }

            }
            return null;
        }
    }
}
