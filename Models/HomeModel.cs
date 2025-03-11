using Microsoft.Build.Evaluation;

namespace PortfolioDT191G.Models
{
    public class HomeModel
    {
        public IEnumerable<CourseModel>? Courses { get; set; }
        public IEnumerable<SkillModel>? Skills { get; set; }
        public IEnumerable<FrameworkModel>? Frameworks { get; set; }
        public IEnumerable<ProjectModel>? Projects { get; set; }
    }
}