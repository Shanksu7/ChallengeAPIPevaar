using ChallengeAPIPevaar.Models;
using ChallengeDataObjects.Context;

namespace ChallengeAPIPevaar.Extensions
{
    public static class Extension
    {
        public static ProductDetailModel GetDetails(this Product product)
        {
            return new ProductDetailModel()
            {
                Description = product.Description,
                ID = product.Id,
                IsActive = product.IsActive,
                Type = product.TypeNavigation.Name.ToString()
            };
        }
    }
}
