using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateTextAndNumbers:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var arabicAndNumberPatten = @"^([ء-ي][ء-ي0-9]+\s)*[ء-ي][ء-ي0-9]+";
                var englishAndNumberPatten = @"^([a-zA-Z][a-zA-Z0-9]+\s)*[a-zA-Z][a-zA-Z0-9]+";
                return Regex.IsMatch(value.ToString(), arabicAndNumberPatten) || Regex.IsMatch(value.ToString(), englishAndNumberPatten);
            }
            else
                return true;
           
        }
    }
}
