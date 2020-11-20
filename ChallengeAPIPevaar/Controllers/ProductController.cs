using ChallengeAPIPevaar.Extensions;
using ChallengeAPIPevaar.Models;
using ChallengeAPIPevaar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
                                 IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// GET: /product or /product?id=
        /// </summary>
        /// <param name="id">Id optional</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductDetailModel> Get([FromQuery] Guid? id)
        {
            return _productService.Get(id);
        }

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
        /// Update a product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        //PATCH products/d869fdb7-740b-4be2-bd8f-0631beab8de2
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id,
                                    [FromBody] ProductEntryModel product)
        {
            var result = _productService.Update(id, product);
            _logger.LogInformation($"Update for id: {id} [{result.Status()}]");
            return result ? Ok() : (IActionResult)BadRequest();
        }

        /// <summary>
        /// Patch a product by id and the given properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        //PATCH products/d869fdb7-740b-4be2-bd8f-0631beab8de2
        [HttpPatch]
        [Route("{id}")]
        public IActionResult Patch(Guid id,
                                    [FromBody] ProductUpdateModel product)
        {
            var result = _productService.Patch(id, product);
            _logger.LogInformation($"Patch for id: {id} [{result.Status()}]");
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
            var result = _productService.Insert(model);
            _logger.LogInformation($"Insert product [{result.Status()}]: {JsonConvert.SerializeObject(model)}");
            return result ? Ok() : (IActionResult)BadRequest(ModelState);
        }

        //DELETE products
        [HttpDelete]
        public IActionResult Delete([FromForm] Guid id)
        {
            var result = _productService.Delete(id);
            _logger.LogInformation($"Delete product [{result.Status()}] id: {id}");
            return result ? Ok() : (IActionResult)BadRequest(ModelState);
        }

    }
}
