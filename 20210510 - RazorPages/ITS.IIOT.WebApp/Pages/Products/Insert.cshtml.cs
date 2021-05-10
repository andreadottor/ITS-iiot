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
    public class InsertModel : PageModel
    {
        private readonly ProductService _productService;

        [BindProperty]
        public Product  Input { get; set; }

        public InsertModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Input = new Product();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(Input);
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
