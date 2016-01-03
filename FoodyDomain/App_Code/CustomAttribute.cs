using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyDomain.App_Code
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return false;
        }
        
        public override string FormatErrorMessage(string name)
        {
            return "Custom Validation Error";
        }
    }
}
