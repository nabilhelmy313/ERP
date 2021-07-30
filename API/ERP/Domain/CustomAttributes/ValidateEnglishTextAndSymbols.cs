using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    class ValidateEnglishTextAndSymbols:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var patten = @"^([a-zA-Z%#&!_*-@]+\s)*[a-zA-Z%#&!_*-@]+";
            return Regex.IsMatch(value.ToString(), patten);
        }
    }
}
