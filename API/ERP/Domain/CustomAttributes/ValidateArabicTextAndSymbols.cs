using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateArabicTextAndSymbols : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var patten = @"^([ء-ي%#&!_*-@]+\s)*[ء-ي%#&!_*-@]+";
            return Regex.IsMatch(value.ToString(), patten);

        }
    }
}
