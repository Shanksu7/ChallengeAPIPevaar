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
                                 IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDetailModel> Get([FromQuery] Guid? id)
        {
            return _productService.Get(id);
        }


        [HttpGet]
        [Route("search")]
        public IEnumerable<ProductDetailModel> Search([FromQuery] string q)
        {
            var result = _productService.Search(q);
            _logger.LogInformation($"search: '{q}': {result.Count()}");
            return result;
        }

        [HttpPut]
        public IActionResult Update([FromQuery] Guid id,
                                    [FromBody] ProductEntryModel product)
        {
            var result = _productService.Update(id, product);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(ProductEntryModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

    }
}
