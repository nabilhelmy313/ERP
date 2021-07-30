using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateSaudiPhone:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var saudiPattern = @"^(5)[0-9]{8}$";
            return Regex.IsMatch(value.ToString(), saudiPattern);
        }
    }
}
