using System.ComponentModel.DataAnnotations;

namespace PortfolioDT191G.Models
{
    public class SkillModel
    {
        [Key]
        public int SkillId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}