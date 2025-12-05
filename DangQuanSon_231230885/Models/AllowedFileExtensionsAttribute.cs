using System.ComponentModel.DataAnnotations;

namespace DangQuanSon_231230885.Models
{
    public class AllowedFileExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedFileExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file == null) return new ValidationResult("Chưa chọn file ảnh");
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (!_extensions.Contains(ext))
                return new ValidationResult($"File phải là: {string.Join(", ", _extensions)}");
            return ValidationResult.Success;
        }
    }
}