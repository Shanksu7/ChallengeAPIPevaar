using ChallengeAPIPevaar.Attributes;
using ChallengeAPIPevaar.Enums;

namespace ChallengeAPIPevaar.Models
{
    public class ProductUpdateModel
    {
        [StringNotRequired(20, 500, ErrorMessage = "String must have a length of 20 to 500 characters")]
        public string Description { get; set; }

        public ProductType? Type { get; set; }

        public double? Value { get; set; }

        public bool? IsActive { get; set; }
    }
}
