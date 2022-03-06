using System.ComponentModel.DataAnnotations;

namespace Meter.Readings.Api.DataAccess.ValidationAttributes;

public class AllowedFileExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _allowedFileExtensions;
    
    public AllowedFileExtensionsAttribute(string[] allowedFileExtensions)
    {
        _allowedFileExtensions = allowedFileExtensions;
    }
    
    protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
    {
        if (value is not IFormFile file)
        {
            return ValidationResult.Success;
        }
        
        var extension = Path.GetExtension(file.FileName);
        return !_allowedFileExtensions.Contains(extension.ToLower()) ? 
            new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
    }

    private static string GetErrorMessage()
    {
        return "This file extension is not allowed!";
    }
}