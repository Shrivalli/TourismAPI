using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace tourismBigBang.Helpers
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;

        public MaxFileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maximum file size allowed is {_maxFileSize / 1024 / 1024}MB.";
        }
    }
}
