using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.IIOT.WebApp.Models;
using ITS.IIOT.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.IIOT.WebApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProductService _productService;

        public Product Product { get; set; }

        public DetailsModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnGet(int id)
        {
            Product = _productService.GetById(id);
        }
    }
}
