using ChallengeAPIPevaar.Extensions;
using ChallengeAPIPevaar.Models;
using ChallengeDataObjects.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAPIPevaar.Services
{
    public class ProductService : IProductService
    {
        private readonly MasterContext _masterContext;

        public ProductService(MasterContext masterContext) =>
            (_masterContext) = (masterContext);

        public IEnumerable<ProductDetailModel> Get(Guid? id)
        {
            if (id.HasValue)
                return _masterContext
                        .Products.Include(x => x.TypeNavigation)
                        .AsNoTracking()
                        .Where(x => x.Id == id.Value)
                        .Select(x => x.GetDetails());

            return _masterContext.Products.Include(x => x.TypeNavigation).AsNoTracking()
                                 .Select(x => x.GetDetails());
        }

        public bool Insert(ProductEntryModel model)
        {
            _masterContext.Products.Add(model.FromEntry());

            return _masterContext.SaveChanges() is not 0;
        }

        public IEnumerable<ProductDetailModel> Search(string q)
        {
            var result = _masterContext.Products.Include(x => x.TypeNavigation).AsNoTracking()
                                       .Where(x => x.Description.ToLower().Contains(q.ToLower()));

            return result.Select(x => x.GetDetails());
        }

        public bool Update(Guid id, ProductUpdateModel product)
        {
            var original = _masterContext.Products.Include(x => x.TypeNavigation).FirstOrDefault(prd => prd.Id == id);
            if (original is null) return false;

            original.Description = product.Description != null ? product.Description : original.Description;
            original.IsActive = product.IsActive.HasValue ? product.IsActive.Value : original.IsActive;
            original.Type = product.Type.HasValue ? (int)product.Type.Value : original.Type;
            original.Value = product.Value.HasValue ? product.Value.Value : original.Value;

            _masterContext.Products.Update(original);

            return _masterContext.SaveChanges() is not 0;
        }

        public bool Delete(Guid id)
        {
            var target = _masterContext.Products.FirstOrDefault(x => x.Id == id);
            if (target is null)
                return false;

            _masterContext.Products.Remove(target);

            return _masterContext.SaveChanges() is not 0;
        }
    }
}
