using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioDT191G.Models
{
    public class ProjectModel
    {
        //Properties
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Url]
        public string? Url { get; set; }
    }
}