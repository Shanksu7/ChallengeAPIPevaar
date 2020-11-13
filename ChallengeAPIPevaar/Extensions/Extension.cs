using ChallengeAPIPevaar.Models;
using ChallengeDataObjects.Context;

namespace ChallengeAPIPevaar.Extensions
{
    public static class Extension
    {
        public static ProductDetailModel GetDetails(this Product product)
        {
            return new()
            {
                Description = product.Description,
                ID = product.Id,
                IsActive = product.IsActive,
                Type = product.TypeNavigation.Name.ToString()
            };
        }

        public static Product FromEntry(this ProductEntryModel detail)
        {
            return new()
            {
                Description = detail.Description,
                IsActive = detail.IsActive.GetValueOrDefault(),
                Type = (int)detail.Type,
                Value = detail.Value.GetValueOrDefault()
            };
        }
    }
}
