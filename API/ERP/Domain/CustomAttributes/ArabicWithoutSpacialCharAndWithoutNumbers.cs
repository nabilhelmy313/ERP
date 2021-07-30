using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
   public class ArabicWithoutSpacialCharAndWithoutNumbers: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var arabicPatten = @"^[_\u0621-\u064A]*((-|\s)*[_\u0621-\u064A])*$";
            return Regex.IsMatch(value.ToString(), arabicPatten);
        }
    }
}
