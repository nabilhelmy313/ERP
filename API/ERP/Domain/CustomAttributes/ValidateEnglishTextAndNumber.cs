using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateEnglishTextAndNumber : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var englishAndNumberPatten = @"^([a-zA-Z][a-zA-Z0-9]+\s)*[a-zA-Z][a-zA-Z0-9]+";
            return Regex.IsMatch(value.ToString(), englishAndNumberPatten);
        }
    }
}
