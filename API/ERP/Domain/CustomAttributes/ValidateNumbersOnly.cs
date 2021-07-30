using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateNumbersOnly:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var patten = @"^[0-9]+$";
            return Regex.IsMatch(value.ToString(), patten);
        }
    }
}
