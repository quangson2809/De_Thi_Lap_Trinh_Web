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
            if (file == null) return new ValidationResult("Ảnh không được bỏ trống");
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (!_extensions.Contains(ext))
                return new ValidationResult("Chỉ chấp nhận file .jpg, .png, .jpeg");
            return ValidationResult.Success;
        }
    }
}