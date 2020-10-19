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
    [Route("api/[controller]")]
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
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoriesRepository.GetById(id);
        }

        // POST api/Categories
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _categoriesRepository.Insert(category);
        }

        // PUT api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            category.CategoryId = id;
            _categoriesRepository.Update(category);
        }

        // DELETE api/Categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoriesRepository.Delete(id);
        }
    }
}
