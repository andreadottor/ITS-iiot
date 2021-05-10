using System.ComponentModel.DataAnnotations;

namespace ITS.IIOT.WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 3)]
        public string Code { get; set; }
    }
}
