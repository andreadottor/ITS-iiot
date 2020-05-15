using System.ComponentModel.DataAnnotations;


namespace Dottor.Northwind.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [StringLength(6, MinimumLength=3)]
        public string Code { get; set; }
    }
}
