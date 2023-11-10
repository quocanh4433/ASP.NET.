using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.CustomValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person : IValidatableObject
    {
        //[Display(Name = "Person Name 02")]
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [DisplayName("Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should be contain only alphabet, space, dot(.)")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} shoulb be a proper email address")]
        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should be contain 10 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [DisplayName("Re-enter password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999, ErrorMessage = "{0} shoul be between {1} and {2}")]
        public double? Price { get; set; }

        [MinimumYearValidator(2005)]
        public DateTime? DateOfBirth { get; set; }

        public DateTime FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To Date' ")]
        public DateTime ToDate { get; set; }
        public int? Age { get; set; }

        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false ) 
            {
                yield return new ValidationResult("Either of Date of Brith or Age must be supplied", new[] { nameof(Age) });
            }
        }
    }
}
