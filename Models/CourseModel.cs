using System.ComponentModel.DataAnnotations;

namespace PortfolioDT191G.Models
{
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Url]
        public string? Syllabus { get; set; }
    }
}