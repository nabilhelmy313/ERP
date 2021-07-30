using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
   public class EnglishWithoutSpacialCharandwithoutnumbers: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var englishPatten = @"^[_A-z]*((-|\s)*[_A-z])*$";
            return Regex.IsMatch(value.ToString(),englishPatten );
        }
    }
}
