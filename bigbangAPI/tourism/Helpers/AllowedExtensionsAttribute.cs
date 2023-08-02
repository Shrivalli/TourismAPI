using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace tourismBigBang.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public AllowedExtensionsAttribute(string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                if (!_allowedExtensions.Contains(fileExtension))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Invalid file format. Only {string.Join(", ", _allowedExtensions)} are allowed.";
        }
    }
}
