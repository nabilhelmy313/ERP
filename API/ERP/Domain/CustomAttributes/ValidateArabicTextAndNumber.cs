using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateArabicTextAndNumber : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var arabicAndNumberPatten = @"^([ء-ي][ء-ي0-9]+\s)*[ء-ي][ء-ي0-9]+";
            return Regex.IsMatch(value.ToString(), arabicAndNumberPatten);
        }
    }
}
