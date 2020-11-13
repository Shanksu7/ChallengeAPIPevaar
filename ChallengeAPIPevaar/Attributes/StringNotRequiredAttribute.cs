using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAPIPevaar.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringNotRequiredAttribute : ValidationAttribute
    {
        public int MinLength { get; init; }
        public int MaxLength { get; init; }

        public StringNotRequiredAttribute(int min, int max)
        => (MinLength, MaxLength) = (min, max);

        public override string FormatErrorMessage(string name)
        => base.FormatErrorMessage(name);

        public override bool IsValid(object value)
        {
            if (value is not string str)
                return false;

            return str.Length >= MinLength && str.Length <= MaxLength;
        }
    }
}
