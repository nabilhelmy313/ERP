using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Bader.Domain.CustomAttributes
{
   public class EnglishWithoutSpacialCharwithNumbers : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var engPatten = @"^[_A-z0-9]*((-|\s)*[_A-z0-9])*$";
            return Regex.IsMatch(value.ToString(), engPatten);
        }
    }
    
    
}
