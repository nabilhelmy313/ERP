using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateEnglishText:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var englishPatten = @"^([a-zA-Z0-9]+\s)*[a-zA-Z0-9]+";
            return Regex.IsMatch(value.ToString(), englishPatten) ;
        }
    }
}
