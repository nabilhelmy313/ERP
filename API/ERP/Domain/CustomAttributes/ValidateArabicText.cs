using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateArabicText:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var arabicPatten = @"^([ء-ي]+\s)*[ء-ي]+";
            return Regex.IsMatch(value.ToString(), arabicPatten);
        }
    }
}
