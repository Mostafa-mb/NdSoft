using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ProductDetailsDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ProductDate { get; set; }
        [Required]
        public string ManufacturePhone { get; set; }
        [Required]
        public string ManufactureEmail { get; set; }
    }
}
