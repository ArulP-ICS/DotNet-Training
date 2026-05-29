using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Validators
{
    public class NumericIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            long temp;
            return long.TryParse(value.ToString(), out temp);
        }

        public override string FormatErrorMessage(string name)
        {
            return name + " must be numeric only";
        }
    }
}