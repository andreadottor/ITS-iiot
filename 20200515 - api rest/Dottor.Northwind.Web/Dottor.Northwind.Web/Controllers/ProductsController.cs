using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Dottor.Northwind.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dottor.Northwind.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IConfiguration configuration, ILogger<ProductsController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        // GET: api/Products
        [HttpGet]
        public IEnumerable<ProductModel> Get(int? categoryId)
        {
            _logger.LogInformation("Entrato nel metodo GET");
            System.Diagnostics.Debug.WriteLine("Entrato nel metodo GET");

            var list = new List<ProductModel>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new ProductModel
                {
                    Id = i,
                    Name = $"Prodotto {i}",
                    Code = $"ABC{i}"
                });
            }

            return list;
        }

        // GET: api/Products/category/12
        [HttpGet("category/{categoryId}")]
        public IEnumerable<ProductModel> GetByCategory(int categoryId)
        {
            return null;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id > 100)
            {
                return NotFound();
                //return StatusCode((int)HttpStatusCode.NotFound);
                //return StatusCode(404);
                //return NotFound();
            }

            return Ok(new ProductModel
            {
                Id = id,
                Name = $"Prodotto {id}",
                Code = $"ABC{id}"
            });
        }



        // POST: api/Products
        [HttpPost]
        public IActionResult Post(ProductModel value)
        {
            if (value.Code == "ABC123")
                ModelState.AddModelError("Code", "Codice già esistente");
            

            if (ModelState.IsValid)
            {
               
                // salvo l'oggetto su db
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductModel value)
        {
            if (ModelState.IsValid)
            {

                // salvo l'oggetto su db
                return Ok();
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
