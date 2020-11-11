using ChallengeAPIPevaar.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChallengeAPIPevaar
{
    public class ProductEntryModel
    {

        [Required(ErrorMessage = "Enter 'description' for product")]
        [StringLength(maximumLength: 500, MinimumLength = 20, ErrorMessage = "Length of description must be from 20 to 300 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a 'type' for product.")]
        [EnumDataType(typeof(ProductType))]
        public ProductType? Type { get; set; }

        [Required(ErrorMessage = "Enter a 'value' for product.")]
        [DataType(DataType.Currency)]
        public double? Value { get; set; }

        [Required(ErrorMessage = "Indicate if the product 'isActive' or not.")]
        public bool? IsActive { get; set; }

    }
}
