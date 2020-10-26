using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.Dottor.IITS.Northwind.Data;
using ITS.Dottor.IITS.Northwind.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITS.Dottor.IITS.Northwind.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }


        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoriesRepository.GetAll();
        }

        // GET api/Categories/5
        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var category = _categoriesRepository.GetById(categoryId);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST api/Categories
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _categoriesRepository.Insert(category);
            //return Created();
        }

        // PUT api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var dbCat = _categoriesRepository.GetById(id);
            if (dbCat == null)
                return NotFound();

            category.CategoryId = id;
            _categoriesRepository.Update(category);
            return NoContent();
        }

        // DELETE api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbCat = _categoriesRepository.GetById(id);
            if (dbCat == null)
                return NotFound();

            _categoriesRepository.Delete(id);
            return NoContent();
        }
    }
}
