using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateArabicNumbersAndSymbols:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var patten = @"^([ء-ي0-9%#&!_*-@]+\s)*[ء-ي0-9%#&!_*-@]+";
            return Regex.IsMatch(value.ToString(), patten);
        }
    }
}
