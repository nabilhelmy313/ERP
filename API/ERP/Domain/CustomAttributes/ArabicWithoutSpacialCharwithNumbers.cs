using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
   public class ArabicWithoutSpacialCharwithNumbers : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var arabicPatten = @"^[_\u0621-\u064A0-9]*((-|\s)*[_\u0621-\u064A0-9])*$";
            return Regex.IsMatch(value.ToString(), arabicPatten);
        }
    }
}
