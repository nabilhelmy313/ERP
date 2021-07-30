using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bader.Domain.CustomAttributes
{
    public class ValidateGuidKey:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Guid CheckGuid ;

            // var isvalid = Guid.Parse(value.ToString()) != Guid.Empty;
            var isvalid = Guid.TryParse(value.ToString(),out CheckGuid);

            return isvalid;
        }
            
                
    }
}
