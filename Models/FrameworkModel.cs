using System.ComponentModel.DataAnnotations;

namespace PortfolioDT191G.Models
{
    public class FrameworkModel
    {
        [Key]
        public int FrameworkId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}