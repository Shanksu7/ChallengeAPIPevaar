using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAPIPevaar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringNotRequiredAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public StringNotRequiredAttribute(int min, int max)
        {
            MinLength = min;
            MaxLength = max;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object? value)
        {

            if (value != null && !(value is string))
            {
                var str = value.ToString();
                if (str.Length >= MinLength && str.Length <= MaxLength)
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
