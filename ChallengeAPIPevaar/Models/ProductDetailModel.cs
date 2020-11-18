using System;

namespace ChallengeAPIPevaar.Models
{
    public class ProductDetailModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }

    }
}
