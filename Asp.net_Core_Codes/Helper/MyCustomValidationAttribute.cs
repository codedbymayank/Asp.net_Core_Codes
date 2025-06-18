using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Codes.Helper
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                string bookname = value.ToString();
                if(bookname.Contains("DEMO"))
                {
                    //Success is a static member , that's why we have only use class name 
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("No value");
        }
    }
}
