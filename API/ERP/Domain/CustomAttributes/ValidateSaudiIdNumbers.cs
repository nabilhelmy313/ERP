using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateSaudiIdNumbers:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var SaudiIdPatten = @"^[12]\d{9}$";
            return Regex.IsMatch(value.ToString(), SaudiIdPatten);
        }
    }
}
