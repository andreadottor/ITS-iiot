using dapper = Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITS.Dottor.IITS.Northwind.Data.Models
{
    [dapper.Table("Categories")]
    public class Category
    {
        [dapper.Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
