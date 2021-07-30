using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class Validate24Hour : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var patten = @"^(([2-2][0-4])|([1-1][0-9])|[0-9])$";
            return Regex.IsMatch(value.ToString(), patten);
        }
    
    }
}
