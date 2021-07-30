using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateTwoDigitNumber : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var patten = @"^(([1-9][0-9])|[1-9])$";
            return Regex.IsMatch(value.ToString(), patten);
        }

    }
}
