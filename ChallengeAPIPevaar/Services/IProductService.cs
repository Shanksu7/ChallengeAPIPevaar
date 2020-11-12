using ChallengeAPIPevaar.Models;
using System;
using System.Collections.Generic;

namespace ChallengeAPIPevaar.Services
{
    public interface IProductService
    {
        /// <summary>
        /// if 'id' is defined, try to return the product with this id, otherwise will return all products
        /// </summary>
        /// <param name="id">Product's id</param>
        /// <returns></returns>
        public IEnumerable<ProductDetailModel> Get(Guid? id);

        /// <summary>
        /// Look for products that include the value of 'q' in the description
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public IEnumerable<ProductDetailModel> Search(string q);

        /// <summary>
        /// Update a product based in the id and the new entry model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Update(Guid id, ProductEntryModel product);

        /// <summary>
        /// Insert a new product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(ProductEntryModel model);

        /// <summary>
        /// Delete a product based on Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id);


    }
}
