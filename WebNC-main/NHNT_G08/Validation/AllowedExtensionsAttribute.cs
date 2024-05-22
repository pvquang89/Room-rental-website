using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Validation
{
    public class AllowedExtensionsAttribute: ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var listFile = value as List<IFormFile>;
            if(listFile != null)
            {
                if (listFile.Count > 0)
                {
                    foreach (var file in listFile)
                    {
                        if (file != null)
                        {
                            var extension = Path.GetExtension(file.FileName);
                            if (!_extensions.Contains(extension.ToLower()))
                            {
                                return new ValidationResult(GetErrorMessage());
                            }
                        }
                    }
                }
            }
            

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Định dạng không được cho phép, chỉ chấp nhận file có phần mở rộng .png và .jpg";
        }

    }
}
