using System.ComponentModel.DataAnnotations;

namespace Meter.Readings.Api.DataAccess.ValidationAttributes;

/// <summary>
/// Extension to validate <see cref="IFormFile"/>
/// </summary>
public class AllowedFileExtensionsAttribute : ValidationAttribute
{
    /// <summary>
    /// Array of allowed file extensions
    /// </summary>
    private readonly string[] _allowedFileExtensions;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="allowedFileExtensions"></param>
    public AllowedFileExtensionsAttribute(string[] allowedFileExtensions)
    {
        _allowedFileExtensions = allowedFileExtensions;
    }
    
    /// <summary>
    /// Validate
    /// </summary>
    /// <param name="value"></param>
    /// <param name="validationContext"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Get error message
    /// </summary>
    /// <returns></returns>
    private static string GetErrorMessage()
    {
        return "This file extension is not allowed!";
    }
}