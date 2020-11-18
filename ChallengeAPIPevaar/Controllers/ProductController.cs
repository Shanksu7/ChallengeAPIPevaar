using ChallengeAPIPevaar.Models;
using ChallengeAPIPevaar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeAPIPevaar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
                                 IProductService productService) => 
            (_logger, _productService) = (logger, productService);

        /// <summary>
        /// Get all Products or specify by Id
        /// </summary>
        /// <param name="id">Id optional</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductDetailModel> Get([FromQuery] Guid? id)
        {
            return _productService.Get(id);
        }

        /// <summary>
        /// Query products by description
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        //GET products/search?q
        [HttpGet]
        [Route("search")]
        public IEnumerable<ProductDetailModel> Search([FromQuery] string q)
        {
            var result = _productService.Search(q);
            _logger.LogInformation($"search: '{q}': {result.Count()}");
            return result;
        }

        /// <summary>
        /// Update product by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        //PUT products/d869fdb7-740b-4be2-bd8f-0631beab8de2
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id,
                                    [FromBody] ProductUpdateModel product)
        {
            var result = _productService.Update(id, product);
            return result ? Ok() : (IActionResult)BadRequest();
        }

        /// <summary>
        /// Insert products into the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //POST products
        [HttpPost]
        public IActionResult Post(ProductEntryModel model)
        {
            return _productService.Insert(model) ? Ok() : (IActionResult)BadRequest(ModelState);
        }

        /// <summary>
        /// Delete products by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //DELETE products
        [HttpDelete]
        public IActionResult Delete([FromForm] Guid id)
        {
            return _productService.Delete(id) ? Ok() : (IActionResult)BadRequest(ModelState);
        }

    }
}
